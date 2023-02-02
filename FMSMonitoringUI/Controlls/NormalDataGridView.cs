/////////////////////////////////////////////////////////////////////////////
//***************************************************************************
//  Description	    : NormalDataGridView
//  Create Date	    : 
//  Author			: 
//  Remark			: 
//***************************************************************************
/////////////////////////////////////////////////////////////////////////////

#region [USing]	
using System;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using MonitoringUI.Common;
using Excel = Microsoft.Office.Interop.Excel;
#endregion

namespace MonitoringUI.Controlls
{
    public partial class NormalDataGridView : DataGridView
    {
        #region [Dll Import]
        const int IDC_ARROW = 32512;
        const int IDC_WAIT = 32514;
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        [DllImport("user32.dll")]
        static extern bool SetSystemCursor(IntPtr hCursor, uint cursorID);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        #endregion

        #region Properties 
        #region [CurrentCell Row Index] 
        [DisplayName("CurrentCell RowIndex"), Description("CurrentCell RowIndex"), Category("CurrentCell RowIndex Setting")]
        public int CurrRow
        {
            get
            {
                return CurrentCell.RowIndex;
            }
        }
        #endregion

        #region [CurrentCell Column Index] 
        [DisplayName("CurrentCell Column Index"), Description("CurrentCell Column Index"), Category("CurrentCell Column Index Setting")]
        public int CurrCol
        {
            get
            {
                return CurrentCell.ColumnIndex;
            }
        }
        #endregion

        int HeaderColumnCount;
        #region [CurrentCell Column Index] 
        [DisplayName("CurrentCell Column Index"), Description("CurrentCell Column Index"), Category("CurrentCell Column Index Setting")]
        public int HeaderColumnRowCount
        {
            get
            {
                return HeaderColumnCount;
            }
            set
            {
                HeaderColumnCount = value;
            }
        }
        #endregion
        #endregion

        #region [Constructor]
        public NormalDataGridView()
        {
            InitializeComponent();
        }

        public NormalDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region [Grid Init, Cell Type]
        #region [Init]
        /// <summary>
        /// ScrollBars, DataGridViewSelectionMode, MultiSelect
        /// </summary>
        /// <param name="scroll"></param>
        /// <param name="cellMode"></param>
        /// <param name="bMulti"></param>
        public void Init(ScrollBars scroll, DataGridViewSelectionMode cellMode, bool bMulti, bool bHeaderMulti = false)
        {
            //Data 바인딩 초기화
            if (DataSource != null)
            {
                if (DataSource.GetType() == typeof(DataTable))
                {
                    DataTable dt = DataSource as DataTable;
                    dt.Clear();
                }
            }
            else
            {
                //Clear
                Rows.Clear();
            }

            Columns.Clear();

            AllowUserToAddRows = false;//Auto Rows ADD !=  FLAG
            ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            RowHeadersWidth = 50;
            RowHeadersDefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter };

            ColumnHeadersDefaultCellStyle.BackColor = BackColor;
            ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Comic Sans Serif", 10);
            //ScrollBars
            ScrollBars = scroll;
            //SelectionMode Set
            SelectionMode = cellMode;
            MultiSelect = bMulti;
            DataError += new DataGridViewDataErrorEventHandler(gridViewComboBox_DataError);
            RowTemplate.Height = 22;
            //2019 03 15 LSY
            //김태훈, Number With. 3자리
            this.RowHeadersWidth = 65;
            //this.RowHeadersWidth = 100;

            // Header Multi Init
            if (bHeaderMulti) InitMulti();
        }
        #endregion

        #region [InitMulti]
        /// <summary>
        /// Header Multi Init
        /// </summary>
        private void InitMulti()
        {
            SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;

            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = true;
            AllowUserToResizeRows = false;

            //Event Handle
            ColumnWidthChanged += MultiHeaderGrid_ColumnWidthChanged;
            HorizontalScrollBar.Scroll += HorizontalScrollBar_Scroll;
            CellPainting += MultiHeaderGrid_CellPainting;
            ColumnHeaderMouseClick += MultiHeaderGrid_ColumnHeaderMouseClick;
            base.DoubleBuffered = true;

            fore = new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor);
        }
        #endregion

        #region [Grid View, Column Type]
        /// <summary>
        /// enSpreadColumnType, Column Width, DataPropertyName, ReadOnly, Visible, MaxLenght(TextBox), DataTable(ComboBox)
        /// </summary>
        /// <param name="ColumnType"></param>
        /// <param name="nColumnWidth"></param>
        /// <param name="strHeaderName"></param>
        /// <param name="bLock"></param>
        /// <param name="bVisible"></param>
        /// <param name="nMaxLenght"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool ColumnType(enSpreadColumnType ColumnType, DataGridViewContentAlignment Alignment,
            int nColumnWidth, string strHeaderName,
            bool bLock, bool bVisible, int nMaxLenght = 0, DataTable dt = null, DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable)
        {
            try
            {
                //Language, Header To Text
                string strHeaderText = LocalLanguage.GetItemString(strHeaderName);

                switch (ColumnType)
                {
                    // ComboBox
                    case enSpreadColumnType.ComboBox:
                        DataGridViewComboBoxColumn combobox = new DataGridViewComboBoxColumn();
                        {
                            combobox.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment, DataSourceNullValue = "", NullValue = "" };
                            combobox.DataPropertyName = strHeaderName;
                            combobox.HeaderText = strHeaderText;
                            //combobox.DropDownWidth = 160;
                            combobox.Width = nColumnWidth;
                            combobox.MaxDropDownItems = 8;
                            combobox.FlatStyle = FlatStyle.Flat;
                            combobox.DataSource = dt;
                            combobox.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;
                            combobox.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                            combobox.ReadOnly = bLock;
                            combobox.Visible = bVisible;
                            combobox.SortMode = sortMode;
                        }
                        this.Columns.Add(combobox);
                        break;
                    // Check Box
                    case enSpreadColumnType.CheckBox:
                        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
                        {
                            checkbox.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            checkbox.DataPropertyName = strHeaderName;
                            checkbox.HeaderText = strHeaderText;
                            //column.DropDownWidth = 160;
                            checkbox.Width = nColumnWidth;
                            //checkbox.FlatStyle = FlatStyle.Flat;
                            checkbox.FlatStyle = FlatStyle.Standard;
                            checkbox.ReadOnly = bLock;
                            checkbox.Visible = bVisible;
                            checkbox.SortMode = sortMode;
                        }
                        this.Columns.Add(checkbox);
                        break;
                    // Button
                    case enSpreadColumnType.Button:
                        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                        {
                            button.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            button.DataPropertyName = strHeaderName;
                            button.HeaderText = strHeaderText;
                            button.Width = nColumnWidth;
                            button.FlatStyle = FlatStyle.Standard;
                            button.ReadOnly = bLock;
                            button.Visible = bVisible;
                            button.SortMode = sortMode;
                        }
                        this.Columns.Add(button);
                        break;
                    // Multi Option
                    case enSpreadColumnType.MultiOption:
                        break;
                    // Number
                    case enSpreadColumnType.Number:
                        DataGridViewTextBoxColumn textboxNum = new DataGridViewTextBoxColumn();
                        {
                            textboxNum.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment};
                            textboxNum.DataPropertyName = strHeaderName;
                            textboxNum.HeaderText = strHeaderText;
                            textboxNum.Width = nColumnWidth;
                            textboxNum.MaxInputLength = nMaxLenght;
                            textboxNum.ReadOnly = bLock;
                            textboxNum.Visible = bVisible;
                            textboxNum.SortMode = DataGridViewColumnSortMode.Automatic;
                            textboxNum.SortMode = sortMode;
                        }

                        this.Columns.Add(textboxNum);

                        break;
                    // Text Box
                    case enSpreadColumnType.Text:
                        DataGridViewTextBoxColumn textbox = new DataGridViewTextBoxColumn();
                        {
                            textbox.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            textbox.DataPropertyName = strHeaderName;
                            textbox.HeaderText = strHeaderText;
                            textbox.Width = nColumnWidth;
                            textbox.MaxInputLength = nMaxLenght;
                            textbox.ReadOnly = bLock;
                            textbox.Visible = bVisible;
                            textbox.SortMode = DataGridViewColumnSortMode.Automatic;
                            textbox.SortMode = sortMode;
                        }
                        this.Columns.Add(textbox);
                        break;
                    // Mask
                    case enSpreadColumnType.Mask:
                        DataGridViewTextBoxColumn textboxMask = new DataGridViewTextBoxColumn();
                        {
                            textboxMask.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            textboxMask.DataPropertyName = strHeaderName;
                            textboxMask.HeaderText = strHeaderText;
                            textboxMask.Width = nColumnWidth;
                            textboxMask.MaxInputLength = nMaxLenght;
                            textboxMask.ReadOnly = bLock;
                            textboxMask.Visible = bVisible;
                            textboxMask.SortMode = DataGridViewColumnSortMode.Automatic;
                            textboxMask.SortMode = sortMode;

                            //Todo
                            
                        }
                        this.Columns.Add(textboxMask);
                        break;
                    // Color Picker
                    case enSpreadColumnType.ColorPicker:
                        break;
                    // Default Text Box
                    default:
                        break;
                }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Grid View Column Type Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }

        /// <summary>
        /// DataGrid에 PropertyName mapping할 경우 사용 (DataSource에 Binding할 경우 사용) 20.01.07 PYG
        /// </summary>
        /// <param name="ColumnType"></param>
        /// <param name="Alignment"></param>
        /// <param name="nColumnWidth"></param>
        /// <param name="strHeaderName"></param>
        /// <param name="bLock"></param>
        /// <param name="bVisible"></param>
        /// <param name="dataprop"></param>
        /// <param name="nMaxLenght"></param>
        /// <param name="dt"></param>
        /// <param name="sortMode"></param>
        /// <returns></returns>
        public bool ColumnType(enSpreadColumnType ColumnType, 
            DataGridViewContentAlignment Alignment,
            int nColumnWidth, 
            string strHeaderName,
            bool bLock, 
            bool bVisible,
            string dataprop,
            int nMaxLenght = 0, 
            DataTable dt = null, 
            DataGridViewColumnSortMode sortMode = DataGridViewColumnSortMode.NotSortable
            )
        {
            try
            {
                //Language, Header To Text
                string strHeaderText = LocalLanguage.GetItemString(strHeaderName);

                switch (ColumnType)
                {
                    // ComboBox
                    case enSpreadColumnType.ComboBox:
                        DataGridViewComboBoxColumn combobox = new DataGridViewComboBoxColumn();
                        {
                            combobox.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment, DataSourceNullValue = "", NullValue = "" };
                            combobox.DataPropertyName = dataprop;
                            combobox.HeaderText = strHeaderText;
                            //combobox.DropDownWidth = 160;
                            combobox.Width = nColumnWidth;
                            combobox.MaxDropDownItems = 8;
                            combobox.FlatStyle = FlatStyle.Flat;
                            combobox.DataSource = dt;
                            combobox.ValueMember = CDefine.DEF_GRIDVIEW_COMBOXID;
                            combobox.DisplayMember = CDefine.DEF_GRIDVIEW_COMBOXNAME;
                            combobox.ReadOnly = bLock;
                            combobox.Visible = bVisible;
                            combobox.SortMode = sortMode;
                        }
                        this.Columns.Add(combobox);
                        break;
                    // Check Box
                    case enSpreadColumnType.CheckBox:
                        DataGridViewCheckBoxColumn checkbox = new DataGridViewCheckBoxColumn();
                        {
                            checkbox.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            checkbox.DataPropertyName = dataprop;
                            checkbox.HeaderText = strHeaderText;
                            //column.DropDownWidth = 160;
                            checkbox.Width = nColumnWidth;
                            //checkbox.FlatStyle = FlatStyle.Flat;
                            checkbox.FlatStyle = FlatStyle.Standard;
                            checkbox.ReadOnly = bLock;
                            checkbox.Visible = bVisible;
                            checkbox.SortMode = sortMode;
                        }
                        this.Columns.Add(checkbox);
                        break;
                    // Button
                    case enSpreadColumnType.Button:
                        DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                        {
                            button.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            button.DataPropertyName = dataprop;
                            button.HeaderText = strHeaderText;
                            button.Width = nColumnWidth;
                            button.FlatStyle = FlatStyle.Standard;
                            button.ReadOnly = bLock;
                            button.Visible = bVisible;
                            button.SortMode = sortMode;
                        }
                        this.Columns.Add(button);
                        break;
                    // Multi Option
                    case enSpreadColumnType.MultiOption:
                        break;
                    // Number
                    case enSpreadColumnType.Number:
                        DataGridViewTextBoxColumn textboxNum = new DataGridViewTextBoxColumn();
                        {
                            textboxNum.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            textboxNum.DataPropertyName = dataprop;
                            textboxNum.HeaderText = strHeaderText;
                            textboxNum.Width = nColumnWidth;
                            textboxNum.MaxInputLength = nMaxLenght;
                            textboxNum.ReadOnly = bLock;
                            textboxNum.Visible = bVisible;
                            textboxNum.SortMode = DataGridViewColumnSortMode.Automatic;
                            textboxNum.SortMode = sortMode;
                        }

                        this.Columns.Add(textboxNum);

                        break;
                    // Text Box
                    case enSpreadColumnType.Text:
                        DataGridViewTextBoxColumn textbox = new DataGridViewTextBoxColumn();
                        {
                            textbox.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            textbox.DataPropertyName = dataprop;
                            textbox.HeaderText = strHeaderText;
                            textbox.Width = nColumnWidth;
                            textbox.MaxInputLength = nMaxLenght;
                            textbox.ReadOnly = bLock;
                            textbox.Visible = bVisible;
                            textbox.SortMode = DataGridViewColumnSortMode.Automatic;
                            textbox.SortMode = sortMode;
                        }
                        this.Columns.Add(textbox);
                        break;
                    // Mask
                    case enSpreadColumnType.Mask:
                        DataGridViewTextBoxColumn textboxMask = new DataGridViewTextBoxColumn();
                        {
                            textboxMask.DefaultCellStyle = new DataGridViewCellStyle() { Alignment = Alignment };
                            textboxMask.DataPropertyName = dataprop;
                            textboxMask.HeaderText = strHeaderText;
                            textboxMask.Width = nColumnWidth;
                            textboxMask.MaxInputLength = nMaxLenght;
                            textboxMask.ReadOnly = bLock;
                            textboxMask.Visible = bVisible;
                            textboxMask.SortMode = DataGridViewColumnSortMode.Automatic;
                            textboxMask.SortMode = sortMode;

                            //Todo

                        }
                        this.Columns.Add(textboxMask);
                        break;
                    // Color Picker
                    case enSpreadColumnType.ColorPicker:
                        break;
                    // Default Text Box
                    default:
                        break;
                }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Grid View Column Type Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion
            #endregion

            #region [Event}
            #region [Grid Change Event]
        public void Changed(int nCol = 0)
        {
            if (this.CurrRow < 0) return;

            //현재 작성 중인 내용 저장
            if (this.IsCurrentCellDirty) this.CommitEdit(DataGridViewDataErrorContexts.Commit);

            this[nCol, this.CurrRow].Value = "MODIFY";
        }
        #endregion

        #region [GridView ComboBox Selected Item Null Ref ERROR]
        void gridViewComboBox_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // (No need to write anything in here)

            //추가하지 않을 경우 ComboBox "" 추가시 ERROR 가 지속적으로 발생 프로그램실행 불가.
            //처리방법??
        }
        #endregion

        #region [Selected Range]
        private void SelectedRangeCell(ref int nStartRow, ref int nStartCol, ref int nEndRow, ref int nEndCol)
        {
            //Check
            if (RowCount < 0) return;
            if (ColumnCount < 0) return;

            //Selected Range
            for (int nRow = 0; nRow < RowCount; nRow++)
            {
                for (int nCol = 0; nCol < ColumnCount; nCol++)
                {
                    if (this[nCol, nRow].Selected == true)
                    {
                        if (nStartRow < 0) nStartRow = nRow;
                        if (nStartCol < 0) nStartCol = nCol;

                        nEndCol = nCol;
                        nEndRow = nRow;
                    }
                }
            }
        }
        #endregion

        #region [Paste Clipboard]
        private void PasteClipboard()
        {
            int nStartCol = -1;
            int nEndCol = -1;
            int nStartRow = -1;
            int nEndRow = -1;
            int nRowCnt = 0;
            int nColCnt = 0;

            DataObject dataObject = Clipboard.GetDataObject() as DataObject;
            //변환.
            if (dataObject.GetDataPresent(DataFormats.StringFormat) == false) return;
            //Range Cell Get
            SelectedRangeCell(ref nStartRow, ref nStartCol, ref nEndRow, ref nEndCol);

            //Check
            if (nStartRow < 0 && nStartCol < 0 && nEndRow < 0 && nEndCol < 0) return;

            try
            {
                //클립보드의 영역 X, Y 로 구성
                string[] XClipboardRows = System.Text.RegularExpressions.Regex.Split(dataObject.GetData(DataFormats.StringFormat).ToString(), @"[\r\n]+").ToArray();
                string[] strSplit = System.Text.RegularExpressions.Regex.Split(XClipboardRows[0], @"[\t]").ToArray();
                //End 설정
                nEndRow = XClipboardRows.Length > nEndRow? nEndRow + 1 : nStartRow + XClipboardRows.Length;
                nEndCol = strSplit.Length > nEndCol ? nEndCol : nStartCol + strSplit.Length;
                //Data Get Set
                for (int nRow = nStartRow; nRow < nEndRow; nRow++)
                {
                    strSplit = System.Text.RegularExpressions.Regex.Split(XClipboardRows[nRowCnt], @"[\t]").ToArray();

                    nColCnt = 0;
                    for (int nCol = nStartCol; nCol < nEndCol; nCol++)
                    {
                        SetCellData(nRow, nCol, strSplit[nColCnt]);
                        nColCnt++;
                    }
                    //Save Flag
                    if (highHeaders.Count > 0 && highHeaders[0].HeaderText.ToUpper() == "FLAG") this[0, nRow].Value = "MODIFY";
                    
                    nRowCnt++;
                }

                //현재 작성 중인 내용 저장
                if (this.IsCurrentCellDirty) this.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### GridList : Paste Clipboard, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion
        #endregion

        #region [Method]

        #region [Customer Row ADD, Header Number]
        /// <summary>
        /// Row ADD RowHeader Cell, Value Number
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int CustRowADDHeaderNumber(params object[] values)
        {
            try
            {
                int nRow = Rows.Add();
                int nMaxCnt = Columns.Count;
                if (values.Length != Columns.Count) throw new Exception(string.Format("Column Count : {0}, Values Count{1} : different.", Columns.Count.ToString(), values.Length.ToString()));

                for (int i = 0; i < nMaxCnt; i++)
                {
                    if (values[i] == null) continue;
                    if(values[i].ToString().Length > 0) this[i, nRow].Value = values[i];
                }

                HeaderCellNoumber(nRow);

                return nRow;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Grid Customer Row ADD, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return -1;
            }
        }
        #endregion

        #region [Customer Row ADD, Header Number]
        /// <summary>
        /// Row ADD RowHeader Cell, Value Number
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int CustRowADDHeaderNumber(List<string> values)
        {
            try
            {

                //20191115 KJY 빈값 만들기
                if(values == null)
                {
                    values = new List<string>();
                    for (int nCol = 0; nCol < Columns.Count; nCol++) values.Add("");
                }
                //값 보정, ADD 시 빈값을 넣는다.
                else if (values.Count > Columns.Count)
                {
                    throw new Exception(string.Format("Column Count : {0}, Values Count{1} : different.", Columns.Count.ToString(), values.Count.ToString()));
                }
                else
                {
                    for (int nCol = values.Count; nCol < Columns.Count; nCol++) values.Add("");
                } 

                int nRow = Rows.Add();
                int nCntMax = Columns.Count;
                for (int i = 0; i < nCntMax; i++)
                {
                    if (values[i] == null) continue;
                    if (values[i].ToString().Length > 0) this[i, nRow].Value = values[i];
                }

                HeaderCellNoumber(nRow);

                return nRow;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Grid Customer Row ADD, Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return -1;
            }
        }
        #endregion

        #region [Header Cell Noumber]
        /// <summary>
        /// Row Header Cell,Rowomber ADD
        /// </summary>
        /// <param name="nRow"></param>
        private void HeaderCellNoumber(int nRow)
        {
            //Rows[nRow].HeaderCell.Value = Rows.Count.ToString();
            Rows[nRow].HeaderCell.Value = $"{Rows.Count} "; // Rows.Count.ToString() + “ “
        }
        #endregion

        #region [Grid Get Data]
        /// <summary>
        /// Grid Cell Data Get. Data Type, String
        /// </summary>
        /// <param name="nRow"></param>
        /// <param name="nCol"></param>
        /// <returns></returns>
        public string GetCellData(int nRow, int nCol)
        {
            string strData = this[nCol, nRow].Value == null ? "" : this[nCol, nRow].Value.ToString();
            return strData;
        }
        #endregion

        #region [Grid Set Data]
        public void SetCellData(int nRow, int nCol, string strData)
        {
            this[nCol, nRow].Value = strData == null ? "" : strData;
        }
        #endregion

        #region [Back Color]
        #region [Grid Cell Row BackColor]
        public void GridCellRowBackColor(int nRow, System.Drawing.Color color)
        {
            Rows[nRow].DefaultCellStyle.BackColor = color;
        }
        #endregion

        #region [Grid Cell Row BackColor]
        public void GridCellColBackColor(int nCol, System.Drawing.Color color)
        {
            Columns[nCol].DefaultCellStyle.BackColor = color;
        }
        #endregion

        #region [Grid Cell Row BackColor]
        public void GridCellBackColor(int nRow, int nCol, System.Drawing.Color color)
        {
            this[nCol, nRow].Style.BackColor = color;
        }
        #endregion
        #endregion

        #region [Selected]
        public void Selected(DataGridViewSelectionMode toMode,int nRow = -1, int nCol = -1)
        {
            try
            {
                if (this.SelectionMode != toMode)
                    this.SelectionMode = toMode;

                switch (this.SelectionMode)
                {
                    case DataGridViewSelectionMode.CellSelect:
                        this.CurrentCell = this[nCol, nRow];
                        this[nCol, nRow].Selected = true;
                        break;
                    case DataGridViewSelectionMode.ColumnHeaderSelect:
                        break;
                    case DataGridViewSelectionMode.FullColumnSelect:
                        break;
                    case DataGridViewSelectionMode.FullRowSelect:
                        if (this.Rows[nRow].Cells[0].Visible == true)
                        {
                            this.CurrentCell = this.Rows[nRow].Cells[0];
                            this.Rows[nRow].Selected = true;
                        }
                        break;
                    case DataGridViewSelectionMode.RowHeaderSelect:
                        break;
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Row Selected Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Cell Modify To String]
        public void CellModifyToString(int nCol = 0, int nRow = -1)
        {
            try
            {
                //Cell Data Check To Commit
                if (IsCurrentCellDirty) CommitEdit(DataGridViewDataErrorContexts.Commit);
                //Row Check
                int nExectRow =  nRow >= 0 ? nRow : CurrRow;

                this[nCol, nExectRow].Value = "MODIFY";
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Cell Modify To String Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Row Delete]
        public void GridRowDelete(int nRow, int nCol)
        {
            try
            {
                // Spread Row Delete
                this[nCol, nRow].Value = "DELETE";
                //this.Rows[nRow].Height = 0;//보임..
                this.Rows[nRow].Visible = false;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Grid Row Delete Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [GridRowSelectionSetting]
        /// <summary>
        /// GridView "Cell" Selected, First Row, Last Row Return
        /// </summary>
        /// <param name="nFirstRow"></param>
        /// <param name="nLastRow"></param>
        public void GridRowSelectionSetting(ref int nFirstRow, ref int nLastRow)
        {
            try
            {
                bool bSelected = false;
                //Init
                nFirstRow = -1;
                nLastRow = -1;

                for (int nRow = 0; nRow < Rows.Count; nRow++)
                {
                    // Init Selected
                    bSelected = false;

                    for (int nCol = 0; nCol < Columns.Count; nCol++)
                    {
                        //Cell Selected Check Value "true" Insert
                        if (this[nCol, nRow].Selected == true)
                            bSelected = true;
                    }
                    //Selected Check.
                    if (bSelected == false) continue;
                    //First Row Insert
                    if (nFirstRow < 0) nFirstRow = nRow;
                    //Last Row Insert
                    nLastRow = nRow;
                }
                //For 문 보정 +1
                nLastRow++;
            }
            catch (Exception ex)
            {
                // Log 
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "spdList_ClipboardPasting Error Exception : " + ex.Message);

                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### GridView Selection Data Setting Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));
            }
        }
        #endregion

        #region [Set Grid Cell Data, Sring To Int, Sum]
        public bool SetCellSum(int nRow, int nCol, int nCellCnt)
        {
            string strTemp = null;
            int nCnt = 0;

            try
            {
                strTemp = GetCellData(nRow, nCol);

                if (strTemp.Length == 0) strTemp = "0";

                bool bResult = int.TryParse(strTemp, out nCnt);

                if (bResult)
                {
                    this[nCol, nRow].Value = nCnt + nCellCnt;

                    return true;
                }
            }
            catch (Exception ex)
            {
                // Log
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "String To Int ERROR : " + ex.Message);
            }
            return false;
        }
        #endregion

        #region [Execl Fonction, GridView Header Count 안됨.Multi 일 경우]

        #region [Kill Process By Main Window Hwnd ]
        /////////////////////////////////////////////////////////////////////
        //	Kill Process By Main Window Hwnd
        //===================================================================
        public static void KillProcessByMainWindowHwnd(int nhWnd)
        {
            uint processID;
            GetWindowThreadProcessId((IntPtr)nhWnd, out processID);
            if (processID >= 0) System.Diagnostics.Process.GetProcessById((int)processID).Kill();
        }
        #endregion

        #region [Spread To Export Excel]
        /// <summary>
        /// Excel Save. Confirm
        /// </summary>
        /// <param name="strTitle"></param>
        /// <returns></returns>
        public bool GridViewToExportExcel(string strTitle)
        {
            // Variable
            string strFilePath = null;

            try
            {
                // File Dialog 생성
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel 97-2003 Workbook(*.xls)|*.xls|Excel Workbook(*.xlsx)|*.xlsx";
                saveDlg.FilterIndex = 2;

                // Open Dialog
                if (saveDlg.ShowDialog() != DialogResult.OK)
                {
                    return true;
                }

                // Data Check
                if (saveDlg.FileName.Length < 1) return true;

                // Save Excel
                strFilePath = saveDlg.FileName;

                if (SpreadToSaveExcel(strFilePath, strTitle) != true)
                {
                    throw new Exception();
                }

                // 결과 Msg
                CMessage.MsgDataSave();

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Spread Export To Excel Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion

        #region [Spread To Export Excel]
        /// <summary>
        /// Excel Save. Confirm
        /// </summary>
        /// <param name="strTitle"></param>
        /// <returns></returns>
        public bool GridViewToExportExcel(DataTable dt, string strTitle)
        {
            // Variable
            string strFilePath = null;

            try
            {
                // File Dialog 생성
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel 97-2003 Workbook(*.xls)|*.xls|Excel Workbook(*.xlsx)|*.xlsx";
                saveDlg.FilterIndex = 2;

                // Open Dialog
                if (saveDlg.ShowDialog() != DialogResult.OK)
                {
                    return true;
                }

                // Data Check
                if (saveDlg.FileName.Length < 1) return true;

                // Save Excel
                strFilePath = saveDlg.FileName;

                if (SpreadToSaveExcel(dt, strFilePath, strTitle) != true)
                {
                    throw new Exception();
                }

                // 결과 Msg
                CMessage.MsgDataSave();

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Spread Export To Excel Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion

        #region [Spread To Save Excel]
        /////////////////////////////////////////////////////////////////////
        //	Spread To Save Excel
        //===================================================================
        private bool SpreadToSaveExcel(string strFilePath, string strTitle)
        {
            // Variable
            Excel.Application xlApp;
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorksheet;

            string[,] strData;
            long[,] lnColor;
            string strTemp = "";

            int nCol = 0;
            //int nRow				= 0;
            int nCols = 0;
            int nRows = 0;
            int nMaxHeaderCol = 0;
            int nMaxHeaderRow = 0;

            //int nCnt				= 0;
            int nLoop = 0;
            int nDataCnt = 0;
            int nTemp = 0;
            int nHwnd = 0;

            try
            {
                // Data Check
                if (this.Rows.Count < 1) return true;
                
                //// 모래시계 커서
                //IntPtr curWaitHandle = LoadCursor(IntPtr.Zero, IDC_WAIT);
                //SetSystemCursor(curWaitHandle, IDC_ARROW);

                //Excel 에 담을 변수 영역을 확보한다.
                //nMaxHeaderRow nMaxHeaderCol : Row, Column 의 Header 영역의 Count
                //nRows nCols : 각 Row, Column 의 Cell 영역의 Count
                // Get Max Rows
                nRows = GetMaxRowCount(ref nMaxHeaderRow);

                // Get Max Cols
                nCols = GetMaxColCount(ref nMaxHeaderCol);

                // Data, Color
                strData = new string[nRows, nCols];
                lnColor = new long[nRows, nCols];

                // Excel Instance Create
                object objMissingType = Type.Missing;
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Add(objMissingType);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add(objMissingType, objMissingType, objMissingType, objMissingType);
                nHwnd = xlApp.Hwnd;

                // Get Spread Head Data
                if (GetHeaderData(ref strData, ref lnColor) != true) throw new Exception();

                // Get Spread Cell Data
                if (GetCellData(ref strData, ref lnColor, nMaxHeaderRow, nMaxHeaderCol) != true) throw new Exception();

                // Init
                nDataCnt = 0;
                nTemp = 26;

                if (nCols < nTemp)
                {
                    nCol = nCols;
                    strTemp = ((char)(nCols % 26 == 0 ? 90 : (nCols % 26) + 65)).ToString();
                }
                else
                {
                    for (nLoop = nTemp; nLoop < 2700; nLoop = nLoop + nTemp)
                    {
                        nDataCnt++;

                        if (nCols < nLoop + nTemp)
                        {
                            nCol = nCols - (nTemp * nDataCnt);
                            strTemp = ((char)(65 + nDataCnt - 1)).ToString() +
                                      ((char)(nCols % 26 == 0 ? 65 : (nCols % 26) + 65)).ToString();
                            break;
                        }
                    }
                }

                // Init
                nDataCnt = 0;
                nTemp = 26;

                // Spread Data To Excel Save
                xlWorksheet.Range["B1:" + strTemp + nRows].set_Value(objMissingType, strData);

                // Excel 설정
                //xlWorksheet.Range["A:A"].ColumnWidth = 10;
                xlWorksheet.Columns.ColumnWidth = 2;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].Font.Bold = true;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].HorizontalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].VerticalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].Interior.Color = Color.FromArgb(196, 217, 221).ToArgb();
                xlWorksheet.Range["B1:" + strTemp + nRows].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].RowHeight = 20;
                xlWorksheet.Columns.AutoFit();

                // Title 설정
                xlWorksheet.Range["B1:" + strTemp + "2"].Insert();
                xlWorksheet.Range["B2:" + strTemp + "2"].Merge(objMissingType);
                xlWorksheet.Range["B2:" + strTemp + "2"].Font.Underline = true;
                xlWorksheet.Range["B2:" + strTemp + "2"].Font.Bold = true;
                xlWorksheet.Range["B2:" + strTemp + "2"].Font.Size = 14;
                xlWorksheet.Range["B2:" + strTemp + "2"].HorizontalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B2:" + strTemp + "2"].VerticalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B2:" + strTemp + "2"].set_Value(objMissingType, strTitle);
                xlWorksheet.Range["B2:" + strTemp + "2"].RowHeight = 30;
                xlWorksheet.Range["B2:" + strTemp + "2"].Borders.LineStyle = BorderStyle.FixedSingle;
                xlWorksheet.Range["B2:" + strTemp + "2"].Interior.Color = Color.FromArgb(192, 192, 192).ToArgb();

                // Worksheet 글꼴 설정
                //xlWorksheet.Columns.Font.Name = "굴림체";

                // 저 장
                xlWorkbook.SaveAs(strFilePath);

                // Excel Close
                xlWorkbook.Close(objMissingType, objMissingType, objMissingType);
                xlApp.Quit();
                KillProcessByMainWindowHwnd(nHwnd);

                //// 화살표 커서
                //IntPtr curArrowHandle = LoadCursor(IntPtr.Zero, IDC_ARROW);
                //SetSystemCursor(curArrowHandle, IDC_ARROW);

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Spread To Save Excel Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Excel Close
                KillProcessByMainWindowHwnd(nHwnd);

                //// 화살표 커서
                //IntPtr curArrowHandle = LoadCursor(IntPtr.Zero, IDC_ARROW);
                //SetSystemCursor(curArrowHandle, IDC_ARROW);

                // Return
                return false;
            }
        }
        #endregion

        #region [Spread To Save Excel]
        /////////////////////////////////////////////////////////////////////
        //	Spread To Save Excel
        //===================================================================
        private bool SpreadToSaveExcel(DataTable dt, string strFilePath, string strTitle)
        {
            // Variable
            Excel.Application xlApp;
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorksheet;

            string[,] strData;
            long[,] lnColor;
            string strTemp = "";

            int nCol = 0;
            //int nRow				= 0;
            int nCols = 0;
            int nRows = 0;
            int nMaxHeaderCol = 0;
            int nMaxHeaderRow = 0;

            //int nCnt				= 0;
            int nLoop = 0;
            int nDataCnt = 0;
            int nTemp = 0;
            int nHwnd = 0;

            try
            {
                // Data Check
                if (dt.Rows.Count < 1) return true;

                // 모래시계 커서
                //IntPtr curWaitHandle = LoadCursor(IntPtr.Zero, IDC_WAIT);
                //SetSystemCursor(curWaitHandle, IDC_ARROW);

                //Excel 에 담을 변수 영역을 확보한다.
                //nMaxHeaderRow nMaxHeaderCol : Row, Column 의 Header 영역의 Count
                //nRows nCols : 각 Row, Column 의 Cell 영역의 Count
                // Get Max Rows
                nRows = GetMaxRowCount(dt, ref nMaxHeaderRow);

                // Get Max Cols
                nCols = GetMaxColCount(ref nMaxHeaderCol);


                // Data, Color
                strData = new string[nRows, nCols];
                lnColor = new long[nRows, nCols];

                // Excel Instance Create
                object objMissingType = Type.Missing;
                xlApp = new Excel.Application();
                xlWorkbook = xlApp.Workbooks.Add(objMissingType);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.Add(objMissingType, objMissingType, objMissingType, objMissingType);
                nHwnd = xlApp.Hwnd;

                // Get Spread Head Data
                if (GetHeaderData(dt,ref strData, ref lnColor) != true) throw new Exception("GetHeaderData Error");

                // Get Spread Cell Data
                if (GetCellData(dt, ref strData, ref lnColor, nMaxHeaderRow, nMaxHeaderCol) != true) throw new Exception("GetCellData Error");

                // Init
                nDataCnt = 0;
                nTemp = 26;

                if (nCols < nTemp)
                {
                    nCol = nCols;
                    strTemp = ((char)(nCols % 26 == 0 ? 90 : (nCols % 26) + 65)).ToString();
                }
                else
                {
                    for (nLoop = nTemp; nLoop < 2700; nLoop = nLoop + nTemp)
                    {
                        nDataCnt++;

                        if (nCols < nLoop + nTemp)
                        {
                            nCol = nCols - (nTemp * nDataCnt);
                            strTemp = ((char)(65 + nDataCnt - 1)).ToString() +
                                      ((char)(nCols % 26 == 0 ? 65 : (nCols % 26) + 65)).ToString();
                            break;
                        }
                    }
                }

                // Init
                nDataCnt = 0;
                nTemp = 26;

                // Spread Data To Excel Save
                xlWorksheet.Range["B1:" + strTemp + nRows].set_Value(objMissingType, strData);

                // Excel 설정
                //xlWorksheet.Range["A:A"].ColumnWidth = 10;
                xlWorksheet.Columns.ColumnWidth = 2;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].Font.Bold = true;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].HorizontalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].VerticalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].Interior.Color = Color.FromArgb(196, 217, 221).ToArgb();
                xlWorksheet.Range["B1:" + strTemp + nRows].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range["B1:" + strTemp + nMaxHeaderRow].RowHeight = 20;
                xlWorksheet.Columns.AutoFit();

                // Title 설정
                xlWorksheet.Range["B1:" + strTemp + "2"].Insert();
                xlWorksheet.Range["B2:" + strTemp + "2"].Merge(objMissingType);
                xlWorksheet.Range["B2:" + strTemp + "2"].Font.Underline = true;
                xlWorksheet.Range["B2:" + strTemp + "2"].Font.Bold = true;
                xlWorksheet.Range["B2:" + strTemp + "2"].Font.Size = 14;
                xlWorksheet.Range["B2:" + strTemp + "2"].HorizontalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B2:" + strTemp + "2"].VerticalAlignment = Excel.Constants.xlCenter;
                xlWorksheet.Range["B2:" + strTemp + "2"].set_Value(objMissingType, strTitle);
                xlWorksheet.Range["B2:" + strTemp + "2"].RowHeight = 30;
                xlWorksheet.Range["B2:" + strTemp + "2"].Borders.LineStyle = BorderStyle.FixedSingle;
                xlWorksheet.Range["B2:" + strTemp + "2"].Interior.Color = Color.FromArgb(192, 192, 192).ToArgb();

                // Worksheet 글꼴 설정
                //xlWorksheet.Columns.Font.Name = "굴림체";

                // 저 장
                xlWorkbook.SaveAs(strFilePath);

                // Excel Close
                xlWorkbook.Close(objMissingType, objMissingType, objMissingType);
                xlApp.Quit();
                KillProcessByMainWindowHwnd(nHwnd);

                // 화살표 커서
                //IntPtr curArrowHandle = LoadCursor(IntPtr.Zero, IDC_ARROW);
                //SetSystemCursor(curArrowHandle, IDC_ARROW);

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Spread To Save Excel Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Excel Close
                KillProcessByMainWindowHwnd(nHwnd);

                // 화살표 커서
                IntPtr curArrowHandle = LoadCursor(IntPtr.Zero, IDC_ARROW);
                SetSystemCursor(curArrowHandle, IDC_ARROW);

                // Return
                return false;
            }
        }
        #endregion

        #region [Get Max Row Count]
        /////////////////////////////////////////////////////////////////////
        //	Get Max Row Count
        //===================================================================
        private int GetMaxRowCount(ref int nMaxHeaderRow)
        {
            // Variable	
            int nRows = 0;
            int nMaxRow = 0;

            try
            {
                //Header Row Count
                nMaxHeaderRow = HeaderColumnRowCount;

                for (int nRow = 0; nRow < this.Rows.Count; nRow++)
                {
                    if (this.Rows[nRow].Height != 0) nMaxRow++;
                }

                nRows = nMaxHeaderRow + nMaxRow;

                // Return
                return nRows;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Max RowCount Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return -1;
            }
        }
        #endregion

        #region [Get Max Row Count]
        /////////////////////////////////////////////////////////////////////
        //	Get Max Row Count
        //===================================================================
        private int GetMaxRowCount(DataTable dt, ref int nMaxHeaderRow)
        {
            // Variable	
            int nRows = 0;
            int nMaxRow = 0;

            try
            {
                //Header Row Count
                nMaxHeaderRow = HeaderColumnRowCount;

                nMaxRow = dt.Rows.Count;

                nRows = nMaxHeaderRow + nMaxRow;

                // Return
                return nRows;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Max RowCount Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return -1;
            }
        }
        #endregion

        #region [Get Max Col Count]
        /////////////////////////////////////////////////////////////////////
        //	Get Max Col Count
        //===================================================================
        private int GetMaxColCount(ref int nMaxHeaderCol)
        {
            // Variable	
            int nCols = 0;
            int nMaxCol = 0;

            try
            {
                //Column 의 Header Count
                //현재 멀티가필요없어서 고정해서 사용.(2019-01-04)
                //추후 필요할 경우 추가필요함.
                nMaxHeaderCol = 1;

                //nMaxHeaderCol = this.ColumnCount /10;

                for (int nCol = 0; nCol < this.ColumnCount; nCol++)
                {
                    if (this.Columns[nCol].Visible) nMaxCol++;
                }

                nCols = nMaxHeaderCol + nMaxCol;
                // Return
                return nCols;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Max Col Count Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return -1;
            }
        }
        #endregion

        #region [Get Header Data]
        /////////////////////////////////////////////////////////////////////
        //	Get Header Data
        //===================================================================
        private bool GetHeaderData(ref string[,] strData, ref long[,] lnColor)
        {
            try
            {
                int nMaxHeaRow = highHeaders.Max(t => t.StartRow) + 1;
                //Column Header Text
                int nIndex = 0;
                int nVisibleFalseCount = 0;
                foreach (var varData in highHeaders)
                {
                    if (Columns[varData.StartCol].Visible)
                    //if (nIndex >= Columns.Count)
                    //    break;
                    //if(Columns[nIndex].Visible)
                    {
                        nIndex++;
                        // 20190613 KJY - 중간에 false가 있으면 에러난다. 수정. - 아 모르겠다.. ---;;
                        //strData[varData.StartRow, varData.StartCol + 1] = varData.HeaderText;
                        strData[varData.StartRow, varData.StartCol + 1 - nVisibleFalseCount] = varData.HeaderText;
                        //strData[varData.StartRow, nIndex] = varData.HeaderText;
                    }
                    else
                        nVisibleFalseCount++;
                }

                //Row Number Setting
                for (int nRow = 0; nRow < Rows.Count; nRow++)
                {
                    strData[nRow + nMaxHeaRow, 0] = (nRow + 1).ToString();
                    lnColor[nRow + nMaxHeaRow, 0] = this.ColumnHeadersDefaultCellStyle.ForeColor.ToArgb();
                }

                //for (int nCol = 0; nCol < lnColor.; nCol++)
                //{ 
                //    for (int nRow = 0; nRow < nMaxHeaRow; nRow++)
                //    {
                //        lnColor[nRow, nCnt] = this.ColumnHeadersDefaultCellStyle.ForeColor.ToArgb();
                //        nCnt++;
                //    }
                // }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Header Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion

        #region [Get Header Data]
        /////////////////////////////////////////////////////////////////////
        //	Get Header Data
        //===================================================================
        private bool GetHeaderData(DataTable dt, ref string[,] strData, ref long[,] lnColor)
        {
            try
            {
                int nMaxHeaRow = highHeaders.Max(t => t.StartRow) + 1;
                //Column Header Text
                foreach (var varData in highHeaders)
                {
                    if (Columns[varData.StartCol].Visible)
                    {
                        strData[varData.StartRow, varData.StartCol + 1] = varData.HeaderText;
                    }
                }

                //Row Number Setting
                for (int nRow = 0; nRow < dt.Rows.Count; nRow++)
                {
                    strData[nRow + nMaxHeaRow, 0] = (nRow + 1).ToString();
                    lnColor[nRow + nMaxHeaRow, 0] = this.ColumnHeadersDefaultCellStyle.ForeColor.ToArgb();
                }

                //for (int nRow = 0; nRow < nMaxHeaRow; nRow++)
                //{
                //    nCnt = 0;
                //    for (int nCol = 0; nCol < highHeaders.Count; nCol++)
                //    {
                //        if (Columns[nCol].Visible)
                //        {
                //            lnColor[nRow, nCnt] = this.ColumnHeadersDefaultCellStyle.ForeColor.ToArgb();
                //            nCnt++;
                //        }
                //    }
                //}

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Header Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion

        #region [Get Cell Data]
        /////////////////////////////////////////////////////////////////////
        //	Get Cell Data
        //===================================================================
        private bool GetCellData(ref string[,] strData, ref long[,] lnColor,
                                 int nMaxHeaderRow, int nMaxHeaderCol)
        {
            // Variable
            int nRowCnt = 0;
            int nColCnt = 0;

            try
            {
                for (int nRow = 0; nRow < this.Rows.Count; nRow++)
                {
                    for (int nCol = 0; nCol < this.Columns.Count; nCol++)
                    {
                        if (Columns[nCol].Visible)
                        {
                            // Set Data 
                            strData[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] = (this.GetCellData(nRow, nCol)).ToString().Replace("\n", "");// strString.DataFromDescr(this[nCol, nRow].Text.ToString().Replace("\n", ""));

                            lnColor[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] = this[nCol,nRow].Style.BackColor.ToArgb();
                            if (lnColor[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] == 0)
                            {
                                lnColor[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] = Color.White.ToArgb();
                            }
                            nColCnt++;
                        }
                    }
                    nRowCnt++;
                    nColCnt = 0;
                }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Cell Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion

        #region [Get Cell Data]
        /////////////////////////////////////////////////////////////////////
        //	Get Cell Data
        //===================================================================
        private bool GetCellData(DataTable dt, ref string[,] strData, ref long[,] lnColor,
                                 int nMaxHeaderRow, int nMaxHeaderCol)
        {
            // Variable
            int nRowCnt = 0;
            int nColCnt = 0;
            
            try
            {
                for (int nRow = 0; nRow < dt.Rows.Count; nRow++)
                {
                    for (int nCol = 0; nCol < dt.Columns.Count; nCol++)
                    {
                        //20190706 KJY - 여기서 index넘어가서 자꾸 exception 발생해서 check 추가
                        if (Columns.Count <= nCol)
                            break;
                        if (Columns[nCol].Visible)
                        {
                            //System.Diagnostics.Debug.Print(string.Format("### row : {0} col : {1}", nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol));

                            // Set Data 
                            strData[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] = (dt.Rows[nRow][nCol]).ToString().Replace("\n", "");// strString.DataFromDescr(this[nCol, nRow].Text.ToString().Replace("\n", ""));

                            if (lnColor[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] == 0)
                            {
                                lnColor[nRowCnt + nMaxHeaderRow, nColCnt + nMaxHeaderCol] = Color.White.ToArgb();
                            }
                            nColCnt++;

                            
                        }
                    }
                    nRowCnt++;
                    nColCnt = 0;
                }

                // Return
                return true;
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### Get Cell Data Error Exception : {0}\r\n{1}", ex.GetType(), ex.Message));

                // Return
                return false;
            }
        }
        #endregion

        #endregion

        #region [ Header Multi ]

        List<ColumnHeaderCell> highHeaders = new List<ColumnHeaderCell>();
        Pen blackPen = new Pen(Color.Black);
        SolidBrush back = new SolidBrush(Color.White);
        SolidBrush fore;
        /// <summary>
        /// lastHeaderClickedIndex : User's Last Header Column Index
        /// </summary>
        int lastHeaderClickedIndex = 0;
        bool isControlPressed = false;
        bool isShiftPressed = false;

        #region [HighHeader, Header Class]
        /// <summary>
        /// 상위 헤더 클래스
        /// </summary>
        // /// 소스 공유 블로그
        // http://ehdrn.tistory.com/411
        // Row 부분 추가
        public class ColumnHeaderCell
        {
            int startCol;
            /// <summary>
            /// 시작 컬럼 위치
            /// </summary>
            internal int StartCol
            {
                get { return startCol; }
                set { this.startCol = value; }
            }

            int endCol;
            /// <summary>
            /// 종료 컬럼 위치
            /// </summary>
            internal int EndCol
            {
                get { return this.endCol; }
                set { this.endCol = value; }
            }

            int startRow;
            /// <summary>
            /// 시작 컬럼 위치
            /// </summary>
            internal int StartRow
            {
                get { return startRow; }
                set { this.startRow = value; }
            }

            int endRow;
            /// <summary>
            /// 종료 컬럼 위치
            /// </summary>
            internal int EndRow
            {
                get { return this.endRow; }
                set { this.endRow = value; }
            }

            internal string HeaderText { get; set; }
            internal string DataPropertyName { get; set; }

            /// <summary>
            /// 시작 컬럼과 종료 컬럼 사이의 값인지 확인.
            /// </summary>
            /// <param name="col"></param>
            /// <returns></returns>
            internal bool Contains(int col)
            {
                return this.startCol <= col && this.endCol >= col;
            }
        }
        #endregion
        #endregion

        #region [AddHighHeader]
        public void ClearHighHeader()
        {
            highHeaders.Clear();
        }
        #endregion

        #region [AddHighHeader List]
        /// <summary>
        /// List<String> To AddHighHeader Input
        /// </summary>
        /// <param name="lstData"></param>
        public void AddHighHeaderList(List<string> lstData)
        {
            //Init
            int nMax = lstData.Count;

            ClearHighHeader();

            for (int nCol = 0; nCol < nMax; nCol++)
            {
                AddHighHeader(nCol, nCol, 0, 0, lstData[nCol]);
            }
        }

        public void AddHighHeaderList(List<KeyValuePair<string, string>> lstData)
        {
            //Init
            int nMax = lstData.Count;

            ClearHighHeader();

            for (int nCol = 0; nCol < nMax; nCol++)
            {
                AddHighHeader(nCol, nCol, 0, 0, lstData[nCol].Key, lstData[nCol].Value);
            }

            
        }
        #endregion

        #region [AddHighHeader]
        public void AddHighHeader(int startCol, int endCol, int startRow, int endRow, string headertext)
        {
            //Language, Header To Text
            string strHeaderText = LocalLanguage.GetItemString(headertext);

            highHeaders.Add(new ColumnHeaderCell()
            {
                StartCol = startCol,
                EndCol = endCol,
                StartRow = startRow,
                EndRow = endRow,
                HeaderText = strHeaderText
            });
        }
        #endregion

        /// <summary>
        /// DataGrid에 PropertyName mapping할 경우 사용 (DataSource에 Binding할 경우 사용)  20.01.07 PYG
        /// </summary>
        /// <param name="startCol"></param>
        /// <param name="endCol"></param>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <param name="headertext">Display Name</param>
        /// <param name="dataPropertyName">Binding Name</param>
        #region [AddHighHeader]
        public void AddHighHeader(int startCol, int endCol, int startRow, int endRow, string headertext, string dataPropertyName)
        {
            //Language, Header To Text
            string strHeaderText = LocalLanguage.GetItemString(headertext);

            highHeaders.Add(new ColumnHeaderCell()
            {
                StartCol = startCol,
                EndCol = endCol,
                StartRow = startRow,
                EndRow = endRow,
                HeaderText = strHeaderText,
                DataPropertyName = dataPropertyName
            });
        }
        #endregion

        #region [OnPaint]
        /// <summary>
        /// Column 설정이 끝난 후 OnPaint 실행됨
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            int nMax = highHeaders.Count;

            base.OnPaint(e);

            //기존 Init
            this.fore = new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor);

            StringFormat format = new StringFormat(){
                Alignment = StringAlignment.Center
                , LineAlignment = StringAlignment.Center };

            int nCnt = 0;

            try
            {
                for (nCnt = 0; nCnt < nMax; nCnt++)
                {
                    //if (nCnt >= Columns.Count)
                    //    break;
                    if (this.Columns.Count <= highHeaders[nCnt].StartCol)
                        break;

                    if (this.Columns[highHeaders[nCnt].StartCol].Visible == false)
                    {
                        continue;
                    }

                    if(nCnt == nMax-1)
                    {
                        //
                    }

                    Rectangle rect = GetHeaderRectangle(highHeaders[nCnt].StartCol, highHeaders[nCnt].EndCol, highHeaders[nCnt].StartRow, highHeaders[nCnt].EndRow);
                    
                    //System.Diagnostics.Debug.Print("No:" + nCnt.ToString() + "::X = " + rect.X.ToString() + ", Y = " + rect.Y.ToString() + ", Height = " + rect.Height.ToString() + ", Width = " + rect.Width.ToString());

                    if (rect.Height <= 0 || rect.Width <= 0) continue;

                    e.Graphics.FillRectangle(back, rect);
                    e.Graphics.DrawRectangle(blackPen, rect);
                    e.Graphics.DrawString(highHeaders[nCnt].HeaderText,
                        this.ColumnHeadersDefaultCellStyle.Font,
                        fore,
                        rect,
                        format);
                }
            }
            catch (Exception ex)
            {
                // System Debug
                System.Diagnostics.Debug.Print(string.Format("### DataGridView OnPaint ERROR : {0}\r\n{1}", ex.GetType(), ex.Message));
                CLogger.WriteLog(enLogLevel.Error, DateTime.Now, this.ToString(), CDefine.m_strLoginID, "DataGridView OnPaint ERROR" + ex.Message);
            }
        }
        #endregion

        #region [Header Domain]
        /// <summary>
        /// Header의 영역을 가져옵니다.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private Rectangle GetHeaderRectangle(int col)
        {
            //int x = this.Left + this.RowHeadersWidth - this.HorizontalScrollBar.Value;
            int x = this.RowHeadersWidth - this.HorizontalScrollBar.Value;

            for (int i = 0; i < col; i++)
            {
                if(this.Columns[i].Visible) x += this.Columns[i].Width;
                //x += this.Columns[i].Width;
            }

            return new Rectangle(new Point(x, 1), this.Columns[col].HeaderCell.Size);
        }
        #endregion

        #region [Header Domain]
        /// <summary>
        /// Header의 영역을 가져옵니다.
        /// </summary>
        /// <param name="col"></param>
        /// <returns></returns>
        private Rectangle GetHeaderRectangle(int nStCol, int nEdCol, int nStRow, int nEdRow)
        {
            int nStartColumn = this.RowHeadersWidth - this.HorizontalScrollBar.Value;
            int nStartRow = 0;
            int nEndColumn = 0;
            int nEndRow = 0;
            int nSumCol = 0;

            for (int i = 0; i <= nEdCol; i++)
            {
                if (this.Columns[i].Visible)
                {
                    if (i < nStCol)
                    {
                        nStartColumn += Columns[i].Width;
                    }
                    else
                    {
                        nSumCol += Columns[i].Width;
                    }
                }
            }

            nEndColumn = nSumCol; // - nStartColumn;

            if (HeaderColumnRowCount < 1) HeaderColumnRowCount = 1;

            //Row Height
            for (int n = nStRow; n <= nEdRow; n++)
                nEndRow += (ColumnHeadersHeight / HeaderColumnRowCount);
            //Row Start Pos
            nStartRow = (ColumnHeadersHeight / HeaderColumnRowCount) * nStRow;

            //ScrollBar Pos 보정
            if (nStartColumn < RowHeadersWidth) nStartColumn = RowHeadersWidth;

            return new Rectangle(nStartColumn, nStartRow, nEndColumn, nEndRow);
        }
        #endregion

        #region [OnKeyDown]
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            this.isControlPressed = e.Control;
            this.isShiftPressed = e.Shift;

            if (e.Control && e.KeyCode == Keys.V)
            {
                PasteClipboard();
            }
        }
        #endregion

        #region [OnKeyUp]
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            this.isControlPressed = e.Control;
            this.isShiftPressed = e.Shift;
        }
        #endregion

        #region [MultiHeaderGrid_CellPainting]
        /// <summary>
        /// Cell을 그릴때 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MultiHeaderGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                bool isContains = false;

                int nMax = highHeaders.Count;

                for(int nCnt = 0; nCnt < nMax; nCnt++)
                { 
                    isContains = highHeaders[nCnt].Contains(e.ColumnIndex);
                    if (isContains == true)
                        break;
                }

                //보더 그리기
                Rectangle r = e.CellBounds;

                if (isContains)
                {
                    r.Height /= 2;
                    r.Y += r.Height;
                }
                r.X -= 1;
                r.Y -= 1;
                r.Height -= 1;

                e.PaintBackground(r, true);
                e.PaintContent(r);
                e.Graphics.DrawRectangle(blackPen, r);

                e.Handled = true;
            }
        }
        #endregion

        #region [CulumnWidthChanged]
        void MultiHeaderGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;
            rtHeader.Height = this.ColumnHeadersHeight / 2;
            this.Invalidate(rtHeader);
        }
        #endregion

        #region [HorizontalScrollBar Scroll]
        /// <summary>
        /// 가로 스크롤을 하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HorizontalScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;
            rtHeader.Height = this.ColumnHeadersHeight;
            this.Invalidate(rtHeader);
        }
        #endregion

        #region [MultiHeaderGrid_ColumnHeaderMouseClick]
        /// <summary>
        /// 컬럼헤더를 클릭하면 발생합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MultiHeaderGrid_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (isControlPressed == false)
                this.ClearSelection();

            int col = e.ColumnIndex;

            if (this.isShiftPressed)
            {
                int startCol = Math.Min(col, this.lastHeaderClickedIndex);
                int endCol = Math.Max(col, this.lastHeaderClickedIndex);

                for (int i = startCol; i <= endCol; i++)
                {
                    for (int j = 0; j < this.RowCount; j++)
                    {
                        this[i, j].Selected = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.RowCount; i++)
                {
                    this[col, i].Selected = true;
                }
            }

            if (this.isShiftPressed == false)
                this.lastHeaderClickedIndex = e.ColumnIndex;
        }
        #endregion

        #endregion
    }
}
