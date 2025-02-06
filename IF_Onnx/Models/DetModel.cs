using Microsoft.ML.OnnxRuntime;
using OpenCvSharp;
using OpenCvSharp.Dnn;
using OpenVinoSharp.Extensions.process;
using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IFOnnxRuntime
{
    public class DetModel : V8Base
    {
        #region Fields
        private (int width, int height) imageSize;
        private float factor;
        //private Predictor predictor;
        #endregion

        #region Properties
        public (int width, int height) ImageSize { get => imageSize; set => imageSize = value; }
        #endregion

        #region Constructors
        public DetModel(string onnxModel, string device, float nmsThreshold) : base(onnxModel, device, nmsThreshold)
        {
            //predictor = new Predictor(onnxModel, device);
        }
        #endregion

        #region Methods
        protected override float[] PreProcess(Mat image)
        {
            imageSize = ((int)image.Size().Width, (int)image.Size().Height);
            Mat mat = new Mat();
            Cv2.CvtColor(image, mat, ColorConversionCodes.BGR2RGB);
            mat = YUtil.Letterbox_img(mat);
            //mat = Resize.Letterbox_img(mat, (int)m_input_size[2], out m_factor);
            factor = (float)Math.Max(image.Size().Width, image.Size().Height) / (float)MetaData.Size.Width;
            Cv2.Resize(mat, mat, new Size(MetaData.Size.Width, MetaData.Size.Height));
            mat.ConvertTo(mat, MatType.CV_32FC3, 1.0 / 255);
            //mat = Normalize.run(mat, true);
            return Permute.run(mat);
        }

        protected override List<float[]> Inference(float[] inputData)
        {
            List<float[]> returns = new List<float[]>();

            var inputOrtValue = OrtValue.CreateTensorValueFromMemory(inputData, new long[] { MetaData.BatchSize, 3, MetaData.Size.Height, MetaData.Size.Width });
            var inputs = new Dictionary<string, OrtValue> { { "images", inputOrtValue } };
            var runOptions = new RunOptions();

            // Pass inputs and request the first output
            // Note that the output is a disposable collection that holds OrtValues
            var outputs = Session.Run(runOptions, inputs, Session.OutputNames);
            //Parallel.ForEach()
            foreach (var output in outputs)
            {
                var outputData = output.GetTensorDataAsSpan<float>();
                float[] data = new float[outputData.Length];
                output.GetTensorDataAsSpan<float>().CopyTo(data);
                returns.Add(data);
            }
            return returns;
        }

        public override BaseResult Run(Mat image, float threshold)
        {
            //TODO : threshold를 여기 인자로 받거나 SetThreshold메서드를 만들어라. ui에는 detail setting에다가 추가하든지 해야될듯 ?
            float[] data = PreProcess(image);
            List<float[]> ret = Inference(data);
            return PostProcess(ret, threshold);
        }

        protected override BaseResult PostProcess(List<float[]> results, float detectThreshold)
        {
            Mat result_data = new Mat(Session.OutputMetadata[Session.OutputNames[0]].Dimensions[1], Session.OutputMetadata[Session.OutputNames[0]].Dimensions[2], MatType.CV_32F, results[0]);
            result_data = result_data.T();
            // Storage results list
            List<Rect> position_boxes = new List<Rect>();
            List<int> class_ids = new List<int>();
            List<float> confidences = new List<float>();
            // Preprocessing output results
            for (int i = 0; i < result_data.Rows; i++)
            {
                Mat classes_scores = new Mat(result_data, new Rect(4, i, MetaData.Classes.Count, 1));
                // Obtain the maximum value and its position in a set of data
                Cv2.MinMaxLoc(classes_scores, out double min_score, out double max_score,
                    out Point min_classId_point, out Point max_classId_point);
                // Confidence level between 0 ~ 1
                // Obtain identification box information
                if (max_score > detectThreshold)
                {
                    float cx = result_data.At<float>(i, 0);
                    float cy = result_data.At<float>(i, 1);
                    float ow = result_data.At<float>(i, 2);
                    float oh = result_data.At<float>(i, 3);
                    int x = (int)((cx - 0.5 * ow) * factor);
                    int y = (int)((cy - 0.5 * oh) * factor);
                    int width = (int)(ow * factor);
                    int height = (int)(oh * factor);
                    Rect box = new Rect
                    {
                        X = x,
                        Y = y,
                        Width = width,
                        Height = height
                    };

                    position_boxes.Add(box);
                    class_ids.Add(max_classId_point.X);
                    confidences.Add((float)max_score);
                }
            }
            // NMS non maximum suppression
            int[] indexes = new int[position_boxes.Count];
            CvDnn.NMSBoxes(position_boxes, confidences, detectThreshold, NmsThreshold, out indexes);
            DetResult re = new DetResult();
            foreach (int index in indexes)
            {
                re.add(class_ids[index], confidences[index], position_boxes[index]);
            }
            return re;
        }
        public void Test()
        {

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
        #endregion

        #region Classes
        // Classes go here
        #endregion


    }
}
