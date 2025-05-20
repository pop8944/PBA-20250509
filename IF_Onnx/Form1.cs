using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpenCvSharp;
using OpenVinoSharp.Extensions.result;
using IFOnnxRuntime.DTOs;
using IFOnnxRuntime.Models;
using Sunny.UI;
using System.IO;
namespace IFOnnxRuntime
{
    public partial class Form1 : Form
    {
        EYED eyeD = new EYED();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                //dlg.InitialDirectory = "C:\\Users\\pec\\Yun\\yolov8\\runs\\detect\\PBA\\Fuse_line\\240411_1733_Fuse_line_index0_imgsz128_batch8_flipUDLR0.5_hsvSV0.1\\weights";
                InitialDirectory = "C:\\Users\\pec\\Yun\\yolov8\\runs\\detect\\PBA\\Soldering\\240520_1645_PBA_Soldering_noAug_imgsz320_epoch300_batch4\\weights",
                Title = "Select inference model file.",
                Filter = "Model file(*.pdmodel,*.onnx,*.xml,*.engine)|*.pdmodel;*.onnx;*.xml;*.engine"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LblModel.Text = dlg.SafeFileName;
                eyeD.ClearModel();
                OnnxInfo onnxInfo = new OnnxInfo()
                {
                    OnnxName = "Test",
                    OnnxPath = dlg.FileName,
                    Device = "CPU",
                    //DetectThreshold = 0.5F,
                    NmsThreshold = 0.5F
                };
                eyeD.AddModel(onnxInfo);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                //dlg.InitialDirectory = "J:\\SwIF\\NAS_Yun\\datasets\\datasets\\PBA\\Fuse_index0\\fuse_line_detect\\Fuse_index0_2\\copy완료";
                InitialDirectory = "D\\Yun\\Project\\EYE-D",
                Title = "Select the test input file.",
                Filter = "Input file(*.png,*.jpg,*.jepg,*.mp4,*.mov)|*.png;*.jpg;*.jepg;*.mp4;*.mov"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LblImage.Text = dlg.FileName;
                PbOrigin.Image = new Bitmap(LblImage.Text);
                PbResult.Image = null;
            }

            //Mat img = Cv2.ImRead(imagePath);
            //Mat re_img = image_predict(img);
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            List<BaseResultDTO> results = eyeD.RunModel(onnxName: "Test", LblImage.Text, 0.5F);
            Bitmap resultImage = (Bitmap)PbOrigin.Image.Clone();
            foreach (BaseResultDTO result in results)
            {
                if (result is DetectionResultDTO detResult)
                {
                    using (Pen pen = new Pen(Color.Red, 1))
                    using (Graphics g = Graphics.FromImage(resultImage))
                    {
                        g.DrawRectangle(pen, new Rectangle(detResult.Box.X, detResult.Box.Y, detResult.Box.Width, detResult.Box.Height));
                    }
                }
            }
            PbResult.Image = resultImage;
        }

        private void BtnSaveRecipe_Click(object sender, EventArgs e)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(eyeD.Models[0]);
            //eyeD.Models[].OnnxInfomation
            File.WriteAllText("C:\\aaaaa\\test.json", jsonString);
            //string dd = ifOnnxRuntimeControl1.TbName.Text;
        }
    }
}
