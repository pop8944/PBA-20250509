using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFOnnxRuntime
{
    public class Predictor
    {
        #region Fields
        private SessionOptions options;
        private InferenceSession onnx_infer;
        private (int batch, int channel, int height, int width) input;
        #endregion

        #region Properties
        // Add your properties here
        #endregion

        #region Constructors
        public Predictor(string model_path, string device)
        {
            if (device.ToUpper() == "CPU")
            {
                options = new SessionOptions();
                options.LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO;
                options.AppendExecutionProvider_CPU(0);
                onnx_infer = new InferenceSession(model_path, options);
            }
            else if (device.ToUpper() == "GPU")
            {
                options = new SessionOptions();
                options.LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO;
                options.AppendExecutionProvider_CUDA(0);
                onnx_infer = new InferenceSession(model_path, options);
            }
            // input = (height: onnx_infer.ModelMetadata.CustomMetadataMap["imgsz"][0], width: onnx_infer.ModelMetadata.CustomMetadataMap["imgsz"][1]);
            input = (onnx_infer.InputMetadata["images"].Dimensions[0], onnx_infer.InputMetadata["images"].Dimensions[1], onnx_infer.InputMetadata["images"].Dimensions[2], onnx_infer.InputMetadata["images"].Dimensions[3]);
        }
        #endregion

        #region Methods
        public void inference(float[] inputData)
        {
            List<float[]> returns = new List<float[]>();

            var inputOrtValue = OrtValue.CreateTensorValueFromMemory(inputData, new long[] { input.batch, input.channel, input.height, input.width });
            var inputs = new Dictionary<string, OrtValue> { { "sssssss", inputOrtValue } };
            var runOptions = new RunOptions();

            // Pass inputs and request the first output
            // Note that the output is a disposable collection that holds OrtValues
            var outputs = onnx_infer.Run(runOptions, inputs, onnx_infer.OutputNames);
            foreach (var output in outputs)
            {
                var outputData = output.GetTensorDataAsSpan<float>();
                float[] data = new float[outputData.Length];
                output.GetTensorDataAsSpan<float>().CopyTo(data);
                returns.Add(data);
            }
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
        public void Dispose()
        {
            onnx_infer.Dispose();
            options.Dispose();
            GC.Collect();
        }

        #endregion

        #region Classes
        // Classes go here
        #endregion


    }
}
