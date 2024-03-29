﻿using FMSMonitoringUI.Controlls.WindowsForms;
using Google.Protobuf.WellKnownTypes;
using MonitoringUI.Controlls;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static MonitoringUI.Controlls.NormalDataGridView;

namespace FMSMonitoringUI.Controlls
{
    public partial class CtrlDataGridView : UserControl
    {
        public delegate void MouseCellClickEventHandler(int col, int row, object value);
        public event MouseCellClickEventHandler MouseCellClick_Evnet = null;

        public delegate void MouseCellDoubleClickEventHandler(int col, int row, object value);
        public event MouseCellDoubleClickEventHandler MouseCellDoubleClick_Evnet = null;

        public List<int> _CellMerge = new List<int>();
        public List<string> _CellMergeText = new List<string>();

        private int _StartColIdx = 0;
        private int _MergeColCount = 0;

        private int _columnIndex = -1;
        public int ColumnCount
        {
            get { return dataGridView1.ColumnCount; }
            set
            {
                if (_columnIndex != value)
                {
                    _columnIndex = value;
                    dataGridView1.ColumnCount = _columnIndex;
                }
            }
        }
        private int _rowCount = -1;
        public int RowCount
        {
            get { return dataGridView1.RowCount; }
            set
            {
                if (_rowCount != value)
                {
                    _rowCount = value;
                    dataGridView1.RowCount = _rowCount;
                }

            }
        }

        #region Properties
        Color _tagColor = Color.FromArgb(27,27,27);
        [DisplayName("BackColor"), Description("Back Color"), Category("DataGridView Setting")]
        public Color TagColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                _tagColor = value;
                this.BackColor = _tagColor;
            }
        }
        #endregion
        public CtrlDataGridView()
        {
            InitializeComponent();

            InitDataGridView();
        }

        private void InitDataGridView()
        {
            dataGridView1.Paint += dataGridView_Paint;

            dataGridView1.RowHeadersVisible = false;
            //dataGridView1.BackgroundColor = Color.FromArgb(27, 27, 27);
        }

        public void SetGridViewStyles()
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = _tagColor;  // Color.FromArgb(46, 46, 46); //Color.FromArgb(27, 27, 27);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.BackgroundColor = _tagColor;  //Color.FromArgb(46, 46, 46);

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
            dataGridView1.ReadOnly = true;

            // 셀의 테두리 스타일
            dataGridView1.BorderStyle = BorderStyle.FixedSingle;
            //dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            //dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            // 선택된 Cell의 색상
            dataGridView1.DefaultCellStyle.SelectionBackColor = _tagColor;  //Color.FromArgb(27, 27, 27);
            //dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            for (int nCol = 0; nCol < dataGridView1.ColumnCount; nCol++)
            {
                for (int nRow = 0; nRow < dataGridView1.RowCount; nRow++)
                {
                    dataGridView1[nCol, nRow].Style.ForeColor = Color.White;
                    dataGridView1[nCol, nRow].Style.BackColor = _tagColor;  // Color.FromArgb(46, 46, 46);

                    // Column 열 조정 안됨
                    dataGridView1.Rows[nRow].Resizable = DataGridViewTriState.False;                    
                }

                // Column 열 조정 안됨
                dataGridView1.Columns[nCol].Resizable = DataGridViewTriState.False;
                //dataGridView1.Columns[nCol].MinimumWidth = 5;
                dataGridView1.Columns[nCol].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                // 여러줄 입력
                dataGridView1.Columns[nCol].DefaultCellStyle.WrapMode= DataGridViewTriState.True;
            }
                        
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();
        }

        /// <summary>
        /// 데이터 그리드 뷰 페인트시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void dataGridView_Paint(object sender, PaintEventArgs e)
        {
            if (_CellMerge.Count == 0)
            {
                return;
            }
            
            Rectangle cellRectangle;

            for (int i = 0; i < _CellMerge.Count* 2;)
            {
                int nextCellWidth = 0;
                int rowIndex = _CellMerge[i / 2];
                    
                cellRectangle = this.dataGridView1.GetCellDisplayRectangle(_StartColIdx, rowIndex, true);

                for (int col = 1; col < _MergeColCount; col++)
                {
                    nextCellWidth += this.dataGridView1.GetCellDisplayRectangle(_StartColIdx + col, rowIndex, true).Width;
                }

                cellRectangle.X += 1;
                cellRectangle.Y += 1;

                cellRectangle.Width = cellRectangle.Width + nextCellWidth - 2;
                cellRectangle.Height = cellRectangle.Height - 2;

                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), cellRectangle);

                StringFormat stringFormat = new StringFormat();

                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;

                e.Graphics.DrawString
                (
                    _CellMergeText[i/2],
                    this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),
                    cellRectangle,
                    stringFormat
                );

                i += 2;
            }
        }

        #region [OnPaint]
        /// <summary>
        /// Column 설정이 끝난 후 OnPaint 실행됨
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            dataGridView_Paint(null, e);
        }
        #endregion

        #region [AddHighHeader List]
        /// <summary>
        /// List<String> To AddHighHeader Input
        /// </summary>
        /// <param name="lstData"></param>
        public void AddColumnHeaderList(List<string> lstData, bool sortMode=false)
        {
            //Init
            int nMax = lstData.Count;
            //dataGridView1.ColumnCount = nMax;
            ColumnCount = nMax;

            for (int nCol = 0; nCol < nMax; nCol++)
            {
                dataGridView1.Columns[nCol].HeaderText= lstData[nCol];

                // Text 정렬
                dataGridView1.Columns[nCol].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Sort 막음
                if (sortMode == false)
                    dataGridView1.Columns[nCol].SortMode = DataGridViewColumnSortMode.NotSortable;
                else
                    dataGridView1.Columns[nCol].SortMode = DataGridViewColumnSortMode.Automatic;

            }
        }
        public void AddRowsHeaderList(List<string> lstData)
        {
            int nMax = lstData.Count;

            if (nMax == 0)
            {
                dataGridView1.Rows.Clear();
                //dataGridView1.Refresh();
                return;
            }
            dataGridView1.RowCount = nMax;

            for (int nRow = 0; nRow < nMax; nRow++)
            {
                dataGridView1[0, nRow].Value = lstData[nRow];

                // Data Cell만 클릭하도록 하기 위해 추가(중간 Row에 Value가 아닌 Name이 있는 경우)
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

        #region DataGridView Cell Count
        //public void ColumnCount(int nColumn)
        //{
        //    dataGridView1.ColumnCount = nColumn;
        //}
        //public void RowCount(int nColumn)
        //{
        //    dataGridView1.RowCount = nColumn;
        //}
        #endregion

        /// <summary>
        /// Merge할 Row No
        /// </summary>
        /// <param name="lstData"></param>
        public void ColumnMergeList(List<int> lstData, List<string> lstText, int startColIdx=0, int mergeColCnt=2 )
        {
            _StartColIdx = startColIdx;
            _MergeColCount = mergeColCnt;
            _CellMerge = lstData;
            _CellMergeText = lstText;
        }
        

        public void ColumnHeadersHeight(int colHigh)
        {
            dataGridView1.ColumnHeadersHeight = colHigh;
        }

        public void ColumnHeadersVisible(bool visible)
        {
            dataGridView1.ColumnHeadersVisible = visible;
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

        public void RowsVisible(int row, bool visible)
        {
            dataGridView1.Rows[row].Visible = visible;
        }

        public void SetAutoSizeMode(DataGridViewAutoSizeColumnMode mode)
        {
            for (int nCol = 0; nCol < dataGridView1.ColumnCount; nCol++)
            {
                dataGridView1.Columns[nCol].AutoSizeMode = mode;
            }
        }

        public void AddRowCount(int nRows)
        {
            dataGridView1.RowCount = nRows;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //dataGridView1.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(27, 27, 27);
                
            }
        }

        public void DataSource(DataTable dtData)
        {
            dataGridView1.DataSource = dtData;
        }

        public void SetValue(int col, int row, object value)
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

        public void SetStyleButton(int col, int row, string text)
        {
            dataGridView1[col, row] = new DataGridViewButtonCell();
            dataGridView1[col, row].Value = text;
            dataGridView1[col, row].Style.BackColor = Color.Black;

            //DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            //{
            //    buttons.HeaderText = "Sales";
            //    buttons.Text = "Sales";
            //    buttons.UseColumnTextForButtonValue = true;
            //    buttons.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.AllCells;
            //    buttons.FlatStyle = FlatStyle.Standard;
            //    buttons.CellTemplate.Style.BackColor = Color.Red;
            //    buttons.DisplayIndex = 0;
            //}

            //dataGridView1.Columns.Add(buttons);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            int col = e.ColumnIndex;
            int row = e.RowIndex;

            try
            {
                // Data Cell만 클릭하도록 하기 위해 추가
                if ((row >= 0 && col > 0) ||
                    (row >= 0 && dataGridView1.Rows[row].Tag != null && Convert.ToBoolean(dataGridView1.Rows[row].Tag.ToString())))
                {
                    if (dataGridView1[col, row].Value != null)
                    {
                        if (this.MouseCellClick_Evnet != null)
                            MouseCellClick_Evnet(col, row, dataGridView1[col, row].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### Get DataGridView Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                throw;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentCell = null;
            dataGridView1.ClearSelection();

            int col = e.ColumnIndex;
            int row = e.RowIndex;

            try
            {
                // Data Cell만 클릭하도록 하기 위해 추가
                if ((row >= 0 && col > 0) ||
                    (row >= 0 && dataGridView1.ColumnCount == 1) ||
                    (row >= 0 && dataGridView1.Rows[row].Tag != null && Convert.ToBoolean(dataGridView1.Rows[row].Tag.ToString())))
                {
                    if (dataGridView1[col, row].Value != null)
                    {
                        if (this.MouseCellDoubleClick_Evnet != null)
                            MouseCellDoubleClick_Evnet(col, row, dataGridView1[col, row].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(string.Format("### Get DataGridView Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
                throw;
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Refresh();
        }
    }
}
