using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MonitoringUI.Controlls.NormalDataGridView;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlDataGridView : UserControl
    {
        public CtrlDataGridView()
        {
            InitializeComponent();
        }

        public void SetGridViewStyles()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(27, 27, 27);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.BackgroundColor = Color.FromArgb(27, 27, 27);

            // Column Header 생상
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Column 높이조절 안됨
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Column 열 채우기
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        
            // Row RowHeader Visible 
            dataGridView1.RowHeadersVisible = false;

            // 읽기 전용
            dataGridView1.ReadOnly= true;

            // 셀의 테두리 스타일
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // 선택된 Cell의 색상
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(27, 27, 27);
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            for (int nCol = 0; nCol < dataGridView1.ColumnCount; nCol++)
            {
                for (int nRow = 0; nRow < dataGridView1.RowCount; nRow++)
                {
                    dataGridView1[nCol, nRow].Style.ForeColor = Color.White;
                    dataGridView1[nCol, nRow].Style.BackColor = Color.FromArgb(27, 27, 27);

                    // Column 열 조정 안됨
                    dataGridView1.Rows[nRow].Resizable = DataGridViewTriState.False;
                }

                // Column 열 조정 안됨
                dataGridView1.Columns[nCol].Resizable = DataGridViewTriState.False;
                dataGridView1.Columns[nCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
                        
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        #region [AddHighHeader List]
        /// <summary>
        /// List<String> To AddHighHeader Input
        /// </summary>
        /// <param name="lstData"></param>
        public void AddColumnHeaderList(List<string> lstData)
        {
            //Init
            int nMax = lstData.Count;
            dataGridView1.ColumnCount = nMax;

            for (int nCol = 0; nCol < nMax; nCol++)
            {
                dataGridView1.Columns[nCol].HeaderText= lstData[nCol];

                // Text 정렬
                dataGridView1.Columns[nCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Sort 막음
                dataGridView1.Columns[nCol].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void AddRowsHeaderList(List<string> lstData)
        {
            int nMax = lstData.Count;
            dataGridView1.RowCount = nMax;

            for (int nRow = 0; nRow < nMax; nRow++)
            {
                dataGridView1[0, nRow].Value = lstData[nRow];
                if (lstData[nRow].ToString() == "" )
                {
                    dataGridView1.Rows[nRow].Tag = true;
                }
                else
                {
                    dataGridView1.Rows[nRow].Tag = false;
                }
            }
        }
        #endregion
        

        public void ColumnHeadersHeight(int colHigh)
        {
            dataGridView1.ColumnHeadersHeight = colHigh;
        }

        /// <summary>
        /// SetGridViewStyles()호출 이후 Width값이 변경 됨.
        /// </summary>
        public void ColumnHeadersWidth(int col, int colWidth)
        {
            dataGridView1.Columns[col].Width = colWidth;
        }

        public void RowsHeight(int rowHigh)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Height = rowHigh;
            }
        }

        public void AddRowCount(int nRows)
        {
            dataGridView1.RowCount = nRows;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(27, 27, 27);
                
            }
        }

        public void SetValue(int col, int row, string value)
        {
            dataGridView1[col, row].Value = value;
        }

        public void SetReworkTray(int col, int row, string rework_flag)
        {
            if (rework_flag == "Y")
            {
                SetStyleBackColor(col, row, Color.LightSkyBlue);
                SetStyleForeColor(col, row, Color.Black);
            }
            else
            {
                SetStyleBackColor(col, row, dataGridView1.BackgroundColor);
                SetStyleForeColor(col, row, Color.White);
            }
        }

        public void SetStyleBackColor(int col, int row, Color backcolor)
        {
            dataGridView1[col, row].Style.BackColor = backcolor;
        }

        public void SetStyleForeColor(int col, int row, Color forecolor)
        {
            dataGridView1[col, row].Style.ForeColor = forecolor;
        }



        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            int col = e.ColumnIndex;
            int row = e.RowIndex;

            // Data Cell만 클릭하도록 하기 위해 추가
            if ((row >= 0 && col > 0) ||
                (row >= 0 && bool.Parse(dataGridView1.Rows[row].Tag.ToString())))
            {
                MessageBox.Show($"TrayInfoView DoubleClick TrayID = {dataGridView1[col, row].Value}");
            }
        }
    }
}
