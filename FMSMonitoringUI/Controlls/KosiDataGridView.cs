using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitoringUI.Controlls
{
    public partial class KosiDataGridView : DataGridView
    {
        public KosiDataGridView()
        {
            InitializeComponent();
        }

        public KosiDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private void dataGridViewMerge(int columnIndex, int columnCount, string strMergedTitle, PaintEventArgs e)
        {
            Rectangle r1 = this.GetCellDisplayRectangle(columnIndex, -1, true);
            int iWidth = 0;
            for (int i = 1; i < columnCount; i++)
            {
                iWidth += this.GetCellDisplayRectangle(columnIndex + i, -1, true).Width;
            }
            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + iWidth;
            r1.Height = r1.Height / 2 - 2;

            e.Graphics.FillRectangle(new SolidBrush(this.ColumnHeadersDefaultCellStyle.BackColor), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(strMergedTitle,
            this.ColumnHeadersDefaultCellStyle.Font,
            new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor),
            r1,
            format);
        }


        private void KosiDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;
            rtHeader.Height = this.ColumnHeadersHeight / 2;
            this.Invalidate(rtHeader);
        }

        private void KosiDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.DisplayRectangle;
            rtHeader.Height = this.ColumnHeadersHeight / 2;
            this.Invalidate(rtHeader);
        }

        private void KosiDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }

        public void KosiDataGridViewMerge(int columnIndex, int columnCount, string strMergedTitle, PaintEventArgs e)
        {
            Rectangle r1 = this.GetCellDisplayRectangle(columnIndex, -1, true);
            int iWidth = 0;

            //Count
            for (int i = 1; i < columnCount; i++)
            {
                iWidth += this.GetCellDisplayRectangle(columnIndex + i, -1, true).Width;
            }

            r1.X += 1;
            r1.Y += 1;
            r1.Width = r1.Width + iWidth;
            r1.Height = r1.Height / 2 - 2;

            e.Graphics.FillRectangle(new SolidBrush(this.ColumnHeadersDefaultCellStyle.BackColor), r1);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(strMergedTitle,
            this.ColumnHeadersDefaultCellStyle.Font,
            new SolidBrush(this.ColumnHeadersDefaultCellStyle.ForeColor),
            r1,
            format);
        }
    }
}
