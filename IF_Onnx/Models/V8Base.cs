using IFOnnxRuntime.DTOs;
using IFOnnxRuntime.Models;
using Microsoft.ML.OnnxRuntime;
using OpenCvSharp;
using OpenCvSharp.Aruco;
using OpenVinoSharp.Extensions.result;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace IFOnnxRuntime
{
    public abstract class V8Base
    {
        #region Fields
        private string onnxModel;
        private string device;
        private InferenceSession session;
        private SessionOptions options;
        private OnnxMetaData metaData;
        private float nmsThreshold;
        private string onnxName;
        #endregion

        #region Properties
        public string OnnxModel { get => onnxModel; set => onnxModel = value; }
        protected InferenceSession Session { get => session; set => session = value; }
        public OnnxMetaData MetaData { get => metaData; set => metaData = value; }
        public float NmsThreshold { get => nmsThreshold; protected set => nmsThreshold = value; }
        public string Device { get => device; set => device = value; }
        public string OnnxName { get => onnxName; set => onnxName = value; }

        //public OnnxInfo OnnxInfomation { get => onnxInfomation; set => onnxInfomation = value; }
        #endregion

        #region Constructors
        protected V8Base(string onnx, string device, float nmsThreshold, string onnxName)
        {
            this.nmsThreshold = nmsThreshold;
            onnxModel = onnx;
            this.device = device;
            this.onnxName = onnxName;
            InitSession();
            Dictionary<string, string> customMetaData = session.ModelMetadata.CustomMetadataMap;
            Dictionary<int, string> metaClasses = new Dictionary<int, string> { };
            string[] size = customMetaData["imgsz"].Trim('[', ']').Split(',');
            string[] classes = customMetaData["names"].Trim('{', '}').Split(',');
            foreach (string cls in classes)
            {
                int key = int.Parse(cls.Split(':')[0].Trim());
                string value = cls.Split(':')[1].Trim().Trim('\'');
                metaClasses.Add(key, value);
            }
            metaData = new OnnxMetaData()
            {
                Task = customMetaData["task"],
                BatchSize = int.Parse(customMetaData["batch"]),
                Size = new System.Drawing.Size(int.Parse(size[1]), int.Parse(size[0])),
                Classes = metaClasses
            };
        }
        #endregion

        #region Methods
        protected abstract float[] PreProcess(Mat image);
        protected abstract List<float[]> Inference(float[] inputData);
        public abstract BaseResult Run(Mat image, float threshold);
        protected abstract BaseResult PostProcess(List<float[]> results, float threshold);
        private void InitSession()
        {
            if (device == "CPU")
            {
                options = new SessionOptions
                {
                    LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO
                };
                options.AppendExecutionProvider_CPU(0);
                session = new InferenceSession(onnxModel, options);
            }
            else if (device == "GPU.0")
            {
                options = new SessionOptions
                {
                    LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO
                };
                options.AppendExecutionProvider_CUDA(0);
                session = new InferenceSession(onnxModel, options);
            }
            else if (device == "GPU.1")
            {
                options = new SessionOptions
                {
                    LogSeverityLevel = OrtLoggingLevel.ORT_LOGGING_LEVEL_INFO
                };
                options.AppendExecutionProvider_CUDA(1);
                session = new InferenceSession(onnxModel, options);
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
        /// <summary>
        /// Finalizes an instance of the V8Base class.
        /// </summary>
        ~V8Base()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged resources used by the V8Base and optionally releases managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
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
            Session.Dispose();
            options.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Classes
        #endregion


    }
}
