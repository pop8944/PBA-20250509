using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static PanasonicPlcTest.Mewtocol.LinkedData;

namespace PanasonicPlcTest.Mewtocol
{
    public abstract class EngineBase : IDisposable
    {
        public string StationNumber { get; set; } = "01";
        public abstract bool IsConnected { get; }
        public abstract void Connect();
        public abstract void Disconnect();
        public void Dispose()
        {
            OnDisposing();
        }
        protected internal abstract void OnDisposing();

        #region Low level command handling

        protected internal abstract Task<string> OnCommandSending(byte[] request);

        protected internal async Task<CommandResult> SendCommandAsync(string command)
        {
            CommandResult result = new CommandResult();
            try
            {
                string msg = command.BuildBCCFrame();
                msg += "\r";
                var message = msg.ToHexASCIIBytes();
                var response = await OnCommandSending(message);
                if (string.IsNullOrEmpty(response))
                {
                    result.Error = "0";
                    result.ErrorDescription = ErrorCodes[Convert.ToInt32(result.Error)];
                }
                else
                {
                    Regex errorcheck = new Regex(@"\%[0-9]{2}\!([0-9]{2})", RegexOptions.IgnoreCase);
                    Match m = errorcheck.Match(response);
                    if (m.Success)
                    {
                        result.Error = m.Groups[1].Value;
                        result.ErrorDescription = ErrorCodes[Convert.ToInt32(result.Error)];

                        response = await OnCommandSending(message);
                        m = errorcheck.Match(response);

                        if (m.Success)
                        {

                        }
                        else
                        {
                            result.Success = true;
                            result.Response = response;
                        }
                    }
                    else
                    {
                        result.Success = true;
                        result.Response = response;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //protected internal async Task<CommandResult> SendCommandAsyncEx(string buff)
        //{
        //    CommandResult result = new CommandResult();
        //    try
        //    {
        //        //"%01#WDD098000980930003000330039002f003000300034003000"

        //        string msg = command.BuildBCCFrame();
        //        msg += "\r";
        //        var message = msg.ToHexASCIIBytes();
        //        var response = await OnCommandSending(message);
        //        if (string.IsNullOrEmpty(response))
        //        {
        //            result.Error = "0";
        //            result.ErrorDescription = ErrorCodes[Convert.ToInt32(result.Error)];
        //        }
        //        else
        //        {
        //            Regex errorcheck = new Regex(@"\%[0-9]{2}\!([0-9]{2})", RegexOptions.IgnoreCase);
        //            Match m = errorcheck.Match(response);
        //            if (m.Success)
        //            {
        //                result.Error = m.Groups[1].Value;
        //                result.ErrorDescription = ErrorCodes[Convert.ToInt32(result.Error)];
        //            }
        //            else
        //            {
        //                result.Success = true;
        //                result.Response = response;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return result;
        //}

        /// <summary>
        /// Covert response value to specify type
        /// </summary>
        /// <param name="result"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private (object, CommandResult) CommandResultValueTypeCovert(CommandResult result, Type type)
        {
            try
            {
                if (type == typeof(short))
                {
                    var resultBytes = result.Response.ParseDTByteString(4).ReverseByteOrder();
                    if (resultBytes != null)
                        return (short.Parse(resultBytes, NumberStyles.HexNumber), result);
                }
                else if (type == typeof(ushort))
                {
                    var resultBytes = result.Response.ParseDTByteString(4).ReverseByteOrder();
                    if (resultBytes != null)
                        return (ushort.Parse(resultBytes, NumberStyles.HexNumber), result);
                }
                else if (type == typeof(int))
                {
                    var resultBytes = result.Response.ParseDTByteString(8).ReverseByteOrder();
                    if (resultBytes != null)
                        return (int.Parse(resultBytes, NumberStyles.HexNumber), result);
                }
                else if (type == typeof(uint))
                {
                    var resultBytes = result.Response.ParseDTByteString(8).ReverseByteOrder();
                    if (resultBytes != null)
                        return (uint.Parse(resultBytes, NumberStyles.HexNumber), result);
                }
                else if (type == typeof(float))
                {
                    var resultBytes = result.Response.ParseDTByteString(8).ReverseByteOrder();
                    if (resultBytes != null)
                    {
                        var val = uint.Parse(resultBytes, NumberStyles.HexNumber);
                        byte[] floatVals = BitConverter.GetBytes(val);
                        float finalFloat = BitConverter.ToSingle(floatVals, 0);
                        return (finalFloat, result);
                    }
                }
                else if (type == typeof(TimeSpan))
                {
                    var resultBytes = result.Response.ParseDTByteString(8).ReverseByteOrder();
                    if (resultBytes != null)
                    {
                        var vallong = long.Parse(resultBytes, NumberStyles.HexNumber);
                        var valMillis = vallong * 10;
                        var ts = TimeSpan.FromMilliseconds(valMillis);
                        return (ts, result);
                    }
                }
                else if (type == typeof(string))
                    return (result.Response.ParseDTString(), result);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Error = "0000";
                result.ErrorDescription = ex.Message;
                return (null, result);
            }
            return (null, result);
        }

        #endregion

        #region public command

        /// <summary>
        /// Get PLC Controller Information
        /// </summary>
        /// <returns></returns>
        public PLCInfo GetPLCInfo()
        {
            var result = SendCommandAsync($"%{StationNumber}#RT").Result;
            if (!result.Success) return null;
            var reg = new Regex(@"\%([0-9]{2})\$RT([0-9]{2})([0-9]{2})([0-9]{2})([0-9]{2})([0-9]{2})([0-9]{2})([0-9]{4})..", RegexOptions.IgnoreCase);
            Match m = reg.Match(result.Response);
            if (m.Success)
            {
                string station = m.Groups[1].Value;
                string cpu = m.Groups[2].Value;
                string version = m.Groups[3].Value;
                string capacity = m.Groups[4].Value;
                string operation = m.Groups[5].Value;
                string errorflag = m.Groups[7].Value;
                string error = m.Groups[8].Value;

                PLCInfo retInfo = new PLCInfo
                {
                    CpuInformation = CpuInfo.BuildFromHexString(cpu, version, capacity),
                    OperationMode = PLCMode.BuildFromHex(operation),
                    ErrorCode = error,
                    StationNumber = int.Parse(station ?? "0"),
                };
                return retInfo;
            }
            return null;
        }

        #endregion

        #region Data read

        /// <summary>
        /// This reads the on and off status for only one contact.
        /// External input X: X
        /// External output Y: Y
        /// Internal relay R: R
        /// Link relay L: L
        /// Timer T: T
        /// Count C: C
        /// </summary>
        /// <param name="code"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public (bool? Value, CommandResult Result) ReadContactAreaSinglePoint(string code, int address)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains(code))
            {
                StringBuilder asciistring = new StringBuilder(code);
                asciistring.Append(address.ToString().PadLeft(4, '0'));
                string requeststring = $"%{StationNumber}#RCS{asciistring}";
                var result = SendCommandAsync(requeststring).Result;
                if (result.Success)
                {
                    return (result.Response.ParseRCSingleBit(), result);
                }
                return (null, result);
            }
            else
                return (null, new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." });
        }

        public (bool? Value, CommandResult Result) ReadContactAreaWord(int address)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains("R"))
            {
                StringBuilder asciistring = new StringBuilder("R");
                asciistring.Append(address.ToString().PadLeft(4, '0'));
                asciistring.Append(address.ToString().PadLeft(4, '0'));
                string requeststring = $"%{StationNumber}#RCC{asciistring}";
                var result = SendCommandAsync(requeststring).Result;
                if (result.Success)
                {
                    return (result.Response.ParseRCSingleBit(), result);
                }
                return (null, result);
            }
            else
                return (null, new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." });
        }

        public (bool[] Value, CommandResult Result) ReadContactsAreaWord(
            string[] address)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains("R"))
            {
                StringBuilder asciistring = new StringBuilder();

                if (address.Length == 4)
                {
                    asciistring.Append(address[0]);
                    asciistring.Append(address[1]);
                    asciistring.Append(address[2]);
                    asciistring.Append(address[3]);
                    //asciistring.Append(address[4]);
                    //asciistring.Append(address[5]);
                    //asciistring.Append(address[6]);
                    //asciistring.Append(address[7]);
                }

                string requeststring = $"%{StationNumber}#RCP4{asciistring}";
                var result = SendCommandAsync(requeststring).Result;
                if (result.Success)
                {
                    return (result.Response.ParseRCWordBit(), result);
                }
                return (null, result);
            }
            else
                return (null, new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." });
        }

        public (bool[] Value, CommandResult Result) ReadContactsAreaWord8(
           string[] address)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains("R"))
            {
                StringBuilder asciistring = new StringBuilder();

                string requeststring = "";
                if (address.Length == 8)
                {
                    asciistring.Append(address[0]);
                    asciistring.Append(address[1]);
                    asciistring.Append(address[2]);
                    asciistring.Append(address[3]);
                    asciistring.Append(address[4]);
                    asciistring.Append(address[5]);
                    asciistring.Append(address[6]);
                    asciistring.Append(address[7]);

                    requeststring = $"%{StationNumber}#RCP8{asciistring}";
                }
                else if (address.Length == 4)
                {
                    asciistring.Append(address[0]);
                    asciistring.Append(address[1]);
                    asciistring.Append(address[2]);
                    asciistring.Append(address[3]);

                    requeststring = $"%{StationNumber}#RCP4{asciistring}";
                }


                var result = SendCommandAsync(requeststring).Result;
                if (result.Success)
                {
                    return (result.Response.ParseRCWordBit(), result);
                }
                return (null, result);
            }
            else
                return (null, new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." });
        }

        public (bool? Value, CommandResult Result) ReadContactMC(string code, int address)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains(code))
            {
                StringBuilder asciistring = new StringBuilder();
                asciistring.Append(code + address.ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 1).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 2).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 3).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 4).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 5).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 6).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 7).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 8).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 9).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 10).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 11).ToString().PadLeft(4, '0'));
                asciistring.Append(code + (address + 12).ToString().PadLeft(4, '0'));
                string requeststring = $"%{StationNumber}#MC{asciistring}";
                var result = SendCommandAsync(requeststring).Result;
                if (result.Success)
                {
                    return (result.Response.ParseRCSingleBit(), result);
                }
                return (null, result);
            }
            else
                return (null, new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." });
        }

        /// <summary>
        /// To read the contents of DT, LD, and FL.
        /// DT: D
        /// LD: L
        /// FL: F
        /// </summary>
        /// <param name="code"></param>
        /// <param name="address"></param>
        /// <param name="length"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public (object Value, CommandResult Result) ReadDataAreaRegister(string code, int address, Type type, int length = 1)
        {
            string[] allow = { "D", "F", "L" };
            if (allow.Contains(code))
            {
                StringBuilder asciistring = new StringBuilder(code);
                asciistring.Append(address.ToString().PadLeft(5, '0'));
                asciistring.Append((address + length - 1).ToString().PadLeft(5, '0'));
                string requeststring = $"%{StationNumber}#RD{asciistring}";
                var result = SendCommandAsync(requeststring).Result;
                if (result.Success)
                    return CommandResultValueTypeCovert(result, type);
                else
                    return (null, result);
            }
            else
                return (null, new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." });
        }

        #endregion

        #region Data write

        /// <summary>
        /// Write contact area (single point): This turns only one contact on or off.
        /// External input X: X
        /// External output Y: Y
        /// Internal relay R: R
        /// Link relay L: L
        /// Timer T: T
        /// Count C: C
        /// </summary>
        /// <param name="code"></param>
        /// <param name="address"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public CommandResult WriteContactAreaSinglePoint(string code, int address, bool value)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains(code))
            {
                StringBuilder asciistring = new StringBuilder(code);
                asciistring.Append(address.ToString().PadLeft(4, '0'));
                string requeststring = $"%{StationNumber}#WCS{asciistring}{(value ? "1" : "0")}";
                return SendCommandAsync(requeststring).Result;
            }
            else
                return new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." };
        }

        public CommandResult WriteContactAreaSinglePoint(string code, string address, bool value)
        {
            string[] allow = { "X", "Y", "R", "L", "T", "C" };
            if (allow.Contains(code))
            {
                StringBuilder asciistring = new StringBuilder(code);
                asciistring.Append(address.ToString().PadLeft(4, '0'));
                string requeststring = $"%{StationNumber}#WCS{asciistring}{(value ? "1" : "0")}";
                return SendCommandAsync(requeststring).Result;
            }
            else
                return new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." };
        }
        /// <summary>
        /// Writ to the contents of DT, LD, and FL.
        /// DT: D
        /// LD: L
        /// FL: F
        /// </summary>
        /// <param name="code"></param>
        /// <param name="address"></param>
        /// <param name="type"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public CommandResult WriteDataAreaRegister(string code, int address, Type type, object value, int length = 1)
        {
            string[] allow = { "D", "F", "L" };
            int lengthofString = 0;
            if (allow.Contains(code))
            {
                byte[] toWriteVal = null;
                string sendBuff_onlyString = null;
                if (type == typeof(short))
                {
                    short temp = Convert.ToInt16(value);
                    toWriteVal = BitConverter.GetBytes(Convert.ToInt16(value));
                }
                else if (type == typeof(ushort))
                {
                    toWriteVal = BitConverter.GetBytes(Convert.ToUInt16(value));
                }
                else if (type == typeof(int))
                {
                    toWriteVal = BitConverter.GetBytes(Convert.ToInt32(value));
                }
                else if (type == typeof(uint))
                {
                    toWriteVal = BitConverter.GetBytes(Convert.ToUInt32(value));
                }
                else if (type == typeof(float))
                {
                    var fl = value as float?;
                    if (fl == null)
                        throw new NullReferenceException("Float cannot be null");
                    toWriteVal = BitConverter.GetBytes(fl.Value);
                }
                else if (type == typeof(TimeSpan))
                {
                    var fl = value as TimeSpan?;
                    if (fl == null)
                        throw new NullReferenceException("Timespan cannot be null");
                    var tLong = (uint)(fl.Value.TotalMilliseconds / 10);
                    toWriteVal = BitConverter.GetBytes(tLong);
                }
                else if (type == typeof(string))
                {
                    var fl = value;
                    if (fl == null)
                        throw new NullReferenceException("String cannot be null");

                    byte[] retbyte = new byte[100];
                    retbyte = Encoding.Default.GetBytes(fl as string);

                    List<int> valueToBytes = new List<int>();
                    for (int k = 0; k < retbyte.Length; k++) valueToBytes.Add(retbyte[k]);

                    string[] cdata = new string[100];
                    lengthofString = address;

                    for (int i = 0; i < valueToBytes.Count; i++)
                    {
                        cdata[i] = Convert.ToString(valueToBytes[i], 16);
                        cdata[i] = cdata[i].PadLeft(4, '0');
                        cdata[i] = cdata[i][2].ToString() + cdata[i][3].ToString() + cdata[i][0].ToString() + cdata[i][1].ToString();
                        sendBuff_onlyString += cdata[i];
                        lengthofString++;
                    }
                }
                else
                    toWriteVal = null;

                string requeststring = "";

                if (type == typeof(string))
                {
                    StringBuilder asciistring = new StringBuilder(code);
                    asciistring.Append(address.ToString().PadLeft(5, '0'));
                    asciistring.Append((lengthofString).ToString().PadLeft(5, '0'));
                    requeststring = $"%{StationNumber}#WD{asciistring}{sendBuff_onlyString}";
                }
                else
                {
                    StringBuilder asciistring = new StringBuilder(code);
                    asciistring.Append(address.ToString().PadLeft(5, '0'));
                    asciistring.Append((address + length - 1).ToString().PadLeft(5, '0'));
                    requeststring = $"%{StationNumber}#WD{asciistring}{toWriteVal.ToHexString()}";
                }

                return SendCommandAsync(requeststring).Result;
            }
            else
                return new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." };
        }
        public CommandResult WriteString(string code, int address, string value, int length = 1)
        {
            string[] allow = { "D", "F", "L" };
            int lengthofString = 0;
            if (allow.Contains(code))
            {
                byte[] toWriteVal = null;
                string sendBuff_onlyString = null;


                byte[] retbyte = new byte[100];
                retbyte = Encoding.Default.GetBytes(value);

                List<int> valueToBytes = new List<int>();
                for (int k = 0; k < retbyte.Length; k++) valueToBytes.Add(retbyte[k]);

                string[] cdata = new string[100];
                lengthofString = address;

                for (int i = 0; i < valueToBytes.Count; i++)
                {
                    cdata[i] = Convert.ToString(valueToBytes[i], 16);
                    cdata[i] = cdata[i].PadLeft(4, '0');
                    cdata[i] = cdata[i][2].ToString() + cdata[i][3].ToString() + cdata[i][0].ToString() + cdata[i][1].ToString();
                    sendBuff_onlyString += cdata[i];
                    lengthofString++;
                }
                string requeststring = "";
                StringBuilder asciistring = new StringBuilder(code);
                asciistring.Append(address.ToString().PadLeft(5, '0'));
                asciistring.Append((lengthofString - 1).ToString().PadLeft(5, '0'));
                requeststring = $"%EE#WD{asciistring}{sendBuff_onlyString}";
                //requeststring = $"%{StationNumber}#WD{asciistring}{toWriteVal.ToHexString()}";
                return SendCommandAsync(requeststring.ToUpper()).Result;
            }
            else
                return new CommandResult { Success = false, Error = "0000", ErrorDescription = "Code is not allow." };
        }

        #endregion

    }
}
