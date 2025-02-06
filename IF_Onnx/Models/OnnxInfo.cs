using System.ComponentModel;

namespace IFOnnxRuntime.Models
{
    public class OnnxInfo
    {
        [Description]
        public string OnnxName { get; set; }
        public string OnnxPath { get; set; }
        public string Device { get; set; }
        //public float DetectThreshold { get; set; } = 0.25F;
        public float NmsThreshold { get; set; } = 0.5F;
        public OnnxValidationResult ValidateOnnx()
        {
            if (string.IsNullOrEmpty(OnnxName)) return new OnnxValidationResult() { IsValid = false, Message = "Onnx Name is Null" };
            if (string.IsNullOrEmpty(OnnxPath)) return new OnnxValidationResult() { IsValid = false, Message = "Onnx Path is Null" };
            if (NmsThreshold > 1) return new OnnxValidationResult() { IsValid = false, Message = "Nms Threshold must be less than or equal to 1." };

            return new OnnxValidationResult() { IsValid = true, Message = "Valid is OK" };
        }
    }
    public class OnnxValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
