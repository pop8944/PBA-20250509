using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public partial class FormPopUp_Settings_Part : Form
    {
        private List<Json_Part> Parts = new List<Json_Part>();

        private string mstr_PartsJsonPath = $"{Global.m_MainPJTRoot}\\Parts\\Parts.json";
        
        private int mI_SelectIndex = 0;

        public enum PopupResult
        {
            CloseY
        }

        public FormPopUp_Settings_Part()
        {
            InitializeComponent();
        }

        private void FormPopUp_Settings_Part_Load(object sender, EventArgs e)
        {
            InitPartList();

            InitStyle();
        }

        private void InitPartList()
        {
            if (File.Exists(mstr_PartsJsonPath))
            {
                // 파일에서 JSON 데이터 읽기
                string jsonText = File.ReadAllText(mstr_PartsJsonPath);

                if (jsonText == "")
                    return;

                // JSON 문자열을 List<T>로 파싱
                Parts = JsonConvert.DeserializeObject<List<Json_Part>>(jsonText);

                for (int i = 0; i < Parts.Count; i++)
                {
                    gridPart.Rows.Add(Parts[i].NO, Parts[i].PartName);
                }
            }
        }

        private void InitStyle()
        {
            DataGridViewCellStyle headerCellStyle = new DataGridViewCellStyle();
            headerCellStyle.Font = new Font("Arial", 20, FontStyle.Bold); // 폰트 크기 16, Bold 설정
            headerCellStyle.BackColor = Color.FromArgb(41, 46, 66);
            headerCellStyle.ForeColor = Color.White;
            foreach (DataGridViewColumn column in gridPart.Columns)
            {
                column.HeaderCell.Style = headerCellStyle;
            }

            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Font = new Font("Arial", 20); // 폰트 크기 14로 설정
            cellStyle.ForeColor = Color.White;
            cellStyle.BackColor = Color.FromArgb(41, 46, 66);
            gridPart.DefaultCellStyle = cellStyle;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            bool bol_ChkOverlap = true;

            for (int i = 0; i < gridPart.RowCount; i++)
            {
                if (gridPart.Rows[i].Cells[1].Value.ToString() == tbPartName.Text)
                {
                    IF_Util.ShowMessageBox("Overlap", $"[FAILED] => 해당 PartName이 이미 등록되었습니다.");
                    bol_ChkOverlap = false;
                    break;
                }
            }

            if (!bol_ChkOverlap)
                return;

            Parts.Add(new Json_Part()
            {
                NO = gridPart.RowCount.ToString(),
                PartName = tbPartName.Text
            });

            string S = JsonConvert.SerializeObject(Parts, Formatting.Indented);
            System.IO.File.WriteAllText(mstr_PartsJsonPath, S);

            gridPart.Rows.Add(gridPart.RowCount, tbPartName.Text);

            gridPart.Rows[gridPart.RowCount - 1].Selected = true;
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (mI_SelectIndex >= 0 && mI_SelectIndex < Parts.Count)
            {
                Parts[mI_SelectIndex].PartName = tbPartName.Text;
                gridPart.Rows[mI_SelectIndex].Cells[1].Value = tbPartName.Text;

                string S = JsonConvert.SerializeObject(Parts, Formatting.Indented);
                System.IO.File.WriteAllText(mstr_PartsJsonPath, S);
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (mI_SelectIndex >= 0 && mI_SelectIndex <= Parts.Count)
            {
                if (Parts.Count == 1)
                {
                    Parts.RemoveAt(0);
                    gridPart.Rows.RemoveAt(0);
                }
                else
                {
                    Parts.RemoveAt(mI_SelectIndex);
                    gridPart.Rows.RemoveAt(mI_SelectIndex);
                }

                string S = JsonConvert.SerializeObject(Parts, Formatting.Indented);
                System.IO.File.WriteAllText(mstr_PartsJsonPath, S);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Global.Instance.FrmVision.InitPartList();
            Close();            
        }

        private void gridPart_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPart.RowCount < 0)
                return;

            DataGridViewRow selectedRow = gridPart.SelectedRows[0];
            mI_SelectIndex = int.Parse(selectedRow.Cells[0].Value.ToString());
            tbPartName.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void FormPopUp_Settings_Part_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.Instance.EventPartChangeEnd?.Invoke(this, EventArgs.Empty);
        }
    }
}