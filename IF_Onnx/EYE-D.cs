using IFOnnxRuntime.DTOs;
using IFOnnxRuntime.Models;
using Microsoft.ML.OnnxRuntime;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace IFOnnxRuntime
{
    public class EYED
    {
        #region Fields
        private Dictionary<string, V8Base> models = new Dictionary<string, V8Base> { };
        #endregion

        #region Properties
        public Dictionary<string, V8Base> Models { get => models; private set => models = value; }
        #endregion

        #region Constructors
        public EYED()
        {

        }
        #endregion

        #region Methods
        public void AddModel(OnnxInfo onnxInfo)
        {
            V8Base model;
            InferenceSession tempSession = new InferenceSession(onnxInfo.OnnxPath);
            string task = tempSession.ModelMetadata.CustomMetadataMap["task"];
            //model = new DetModel(onnxPath, device, detectTreshold, nmsThreshold); // 임시로 생성 (onnx의 정보를 읽어 
            tempSession.Dispose();
            switch (task)
            {
                case "detect":
                    //TODO : IFOnnxRuntimeControl에 datagridview랑 propertygridview 세팅해보고 Model 매개변수를 OnnxInfo로 바꾸는 것도 고려해볼 것
                    model = new DetModel(onnxInfo.OnnxPath, onnxInfo.Device, onnxInfo.NmsThreshold);
                    break;
                case "segment":
                    model = new SegModel(onnxInfo.OnnxPath, onnxInfo.Device, onnxInfo.NmsThreshold);
                    break;
                default:
                    throw new ArgumentException();
            }
            models.Add(onnxInfo.OnnxName, model);
        }
        public void RemoveModel(string onnxName)
        {
            models[onnxName].Dispose();
            models.Remove(onnxName);
        }
        public void ClearModel()
        {
            foreach (KeyValuePair<string, V8Base> kvp in models)
            {
                V8Base model = kvp.Value;
                model.Dispose();
            }
            models.Clear();
        }
        public List<BaseResultDTO> RunModel(string onnxName, Mat image, float threshold)
        {
            List<BaseResultDTO> ret = new List<BaseResultDTO>();
            BaseResult result = models[onnxName].Run(image, threshold);
            Dictionary<int, string> classes = models[onnxName].MetaData.Classes;
            if (result is DetResult detResult)
            {
                foreach (DetData detData in detResult.datas)
                {
                    ret.Add(new DetectionResultDTO()
                    {
                        Class = classes[detData.index],
                        Box = (detData.box.X, detData.box.Y, detData.box.Width, detData.box.Height),
                        Score = detData.score,
                    });
                }
            }
            else if (result is SegResult segResult)
            {
                foreach (SegData segData in segResult.datas)
                {
                    Bitmap mask = BitmapConverter.ToBitmap(segData.mask);
                    ret.Add(new SegmentResultDTO()
                    {
                        //Index = segData.index,
                        Class = classes[segData.index],
                        Box = (segData.box.X, segData.box.Y, segData.box.Width, segData.box.Height),
                        Mask = mask,
                        Score = segData.score,
                    });
                }
            }
            return ret;
        }
        public List<BaseResultDTO> RunModel(string onnxName, string imagePath, float threshold)
        {
            Mat image = Cv2.ImRead(imagePath);
            return RunModel(onnxName, image, threshold);
        }
        public List<BaseResultDTO> RunModel(string onnxName, Bitmap bitmap, float threshold)
        {
            Mat image = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitmap);
            return RunModel(onnxName, image, threshold);
        }
        #endregion

        #region Events
        // Events go here
        #endregion

        #region Interfaces
        // Interfaces go here
        #endregion

        #region Constants
        // Constants go here
        #endregion

        #region Destructors
        /// <summary>
        /// Finalizes an instance of the EYED class.
        /// </summary>
        ~EYED()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged resources used by the EYED and optionally releases managed resources.
        /// </summary>
        /// <param onnxName="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
            }
            // Dispose unmanaged resources
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Classes
        // Classes go here
        #endregion


    }
}
