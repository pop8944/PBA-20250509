using IFOnnxRuntime;
using IFOnnxRuntime.Models;
using System;
using System.Windows.Forms;

namespace FrameworkOnnxTest
{
    public partial class IFOnnxRuntimeControl : UserControl
    {
        EYED eyeD = new EYED();

        public EYED EyeD { get => eyeD; set => eyeD = value; }
        private int nSelectedIndex = 0;
        public IFOnnxRuntimeControl()
        {
            InitializeComponent();
        }

        private void BtnModelAdd_Click(object sender, EventArgs e)
        {
            if (float.TryParse(TbNmsThreshold.Text, out float nmsThreshold))
            {
                OnnxInfo onnxInfo = new OnnxInfo()
                {
                    Device = CbDevice.Text,
                    NmsThreshold = nmsThreshold,
                    OnnxName = TbName.Text,
                    OnnxPath = TbPath.Text
                };
                OnnxValidationResult onnxValidationResult = onnxInfo.ValidateOnnx();
                if (onnxValidationResult.IsValid)
                {
                    eyeD.AddModel(onnxInfo);
                    RefreshModelList();
                }
            }
            else
            {
                // nmsThreshold parse 실패
            }
        }

        private void BtnModelRemove_Click(object sender, EventArgs e)
        {
            var ddd = DgvModel.Rows[nSelectedIndex].Cells[1].Value.ToString().Trim();
            eyeD.RemoveModel(DgvModel.Rows[nSelectedIndex].Cells[1].Value.ToString().Trim());
            RefreshModelList();
        }

        private void BtnLoadPath_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                //dlg.InitialDirectory = "C:\\Users\\pec\\Yun\\yolov8\\runs\\detect\\PBA\\Fuse_line\\240411_1733_Fuse_line_index0_imgsz128_batch8_flipUDLR0.5_hsvSV0.1\\weights";
                InitialDirectory = "C:\\Users\\pec\\Yun\\yolov8\\runs\\detect\\PBA\\Soldering\\240520_1645_PBA_Soldering_noAug_imgsz320_epoch300_batch4\\weights",
                Title = "Select inference model file.",
                Filter = "Model file(*.onnx)|*.onnx;"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                TbPath.Text = dlg.FileName;
                
            }
        }

        private void IFOnnxRuntimeControl_Load(object sender, EventArgs e)
        {
            //eyeD.Models = Glo
            RefreshModelList();
        }
        private void RefreshModelList()
        {
            DgvModel.Rows.Clear();
            int index = 0;
            foreach (V8Base model in eyeD.Models)
            {
                DgvModel.Rows.Add(new object[] { index, model.OnnxName });
                index++;
            }
        }

        private void DgvModel_SelectIndexChange(object sender, int index)
        {
            nSelectedIndex = index;
        }
    }
}
