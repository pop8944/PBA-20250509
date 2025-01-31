using Cognex.VisionPro.OCRMax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.ML;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace IntelligentFactory.Onnx
{
    internal class ClassificationTool
    {
        public string NAME { get; set; } = "";
        public string ModelCode { get; set; } = "";
        public class ImageData
        {
            public Bitmap Image { get; set; }
        }

        public class ImagePrediction
        {
            public float[] Score { get; set; }
        }
        public void LoadConfig()
        {
            //var mlContext = new MLContext();
            //var pipeline = mlContext.Transforms.LoadImages(outputColumnName: "input_name", imageFolder: "", inputColumnName: nameof(ImageData.Image))
            //                .Append(mlContext.Transforms.ApplyOnnxModel(modelFile: "path_to_your_model.onnx"));

            //var model = pipeline.Fit(mlContext.Data.LoadFromEnumerable(new List<ImageData>()));

            //var predictionEngine = mlContext.Model.CreatePredictionEngine<ImageData, ImagePrediction>(model);
        }
    }
}
