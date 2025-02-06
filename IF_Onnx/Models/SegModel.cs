using OpenCvSharp;
using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFOnnxRuntime
{
    public class SegModel : V8Base
    {

        #region Fields
        // Add your fields here
        #endregion

        #region Properties
        // Add your properties here
        #endregion

        #region Constructors
        public SegModel(string onnx, string device, float nmsThreshold) : base(onnx, device, nmsThreshold)
        {

        }
        #endregion

        #region Methods
        protected override float[] PreProcess(Mat image)
        {
            throw new NotImplementedException();
        }
        protected override List<float[]> Inference(float[] inputData)
        {
            throw new NotImplementedException();
        }
        protected override BaseResult PostProcess(List<float[]> results, float threshold)
        {
            throw new NotImplementedException();
        }

        public override BaseResult Run(Mat image, float threshold)
        {
            throw new NotImplementedException();
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
