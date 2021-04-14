#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.WinForms.Controls;
using Syncfusion.WinForms.DataGrid.Styles;
using System.Windows.Forms;
using Syncfusion.WinForms.DataGrid.Enums;
using System.Drawing;
using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid.Events;
using Syncfusion.WinForms.DataGrid.Renderers;
using Syncfusion.WinForms.DataGrid.Helpers;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.GridCommon.ScrollAxis;
using Syncfusion.Windows.Forms.Helper;
using Syncfusion.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the Form.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            var data = new EmployeeDetails();
            sfDataGrid.DataSource = data.EmployeeInfoCollection;
            sfDataGrid.SelectionMode = GridSelectionMode.SingleDeselect;
            //Enable preview row for the SfDataGrid.
            sfDataGrid.ShowPreviewRow = true;
            sfDataGrid.PreviewRowMappingName = "FirstName";
            sfDataGrid.PreviewRowHeight = 114;
            sfDataGrid.ExpandAllPreviewRow();
            //PreviewRowExpander
            this.sfDataGrid.CellRenderers.Remove("PreviewRowExpander");
            this.sfDataGrid.CellRenderers.Add("PreviewRowExpander", new PreviewRowExpanderCellRendererExt());
            sfDataGrid.DrawPreviewRow += OnDrawPreviewRow;
        }

        #endregion 

        #region Method

        /// <summary>
        /// Draws the preview row.
        /// </summary>
        /// <param name="sender">The object of the sender.</param>
        /// <param name="e">An <see cref="DrawPreviewRowEventArgs"/> that contains the event data.</param>
        private void OnDrawPreviewRow(object sender, DrawPreviewRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Text))
            {
                var clipbounds = e.Graphics.ClipBounds;
                e.Graphics.SetClip(e.Bounds);

                var font = e.Style.Font.GetFont();
                var record = (e.Record as RecordEntry).Data as EmployeeInfo;
                var headerBrush = new SolidBrush(e.Style.TextColor);
                var subItemsFont = new Font("Segoe UI", 8f, FontStyle.Bold);
                var textBrush = new SolidBrush(e.Style.TextColor);

#if NETCORE
                var image = Image.FromFile("../../../Images/" + e.Text + ".png");
#else
                var image = Image.FromFile(@"..\..\Images\" + e.Text + ".png");
#endif
                var rect = new Rectangle(e.Bounds.X + 50, e.Bounds.Y + 12, 90, 90);
                e.Graphics.DrawImage(image, rect);

                int textWidth1 = (int)e.Graphics.MeasureString("First Name", e.Style.Font.GetFont()).Width + 5;
                int textWidth2 = (int)e.Graphics.MeasureString("Last Name", e.Style.Font.GetFont()).Width + 5;
                int textWidth3 = (int)e.Graphics.MeasureString("Title", e.Style.Font.GetFont()).Width + 5;
                int textWidth4 = (int)e.Graphics.MeasureString("Address", e.Style.Font.GetFont()).Width + 5;
                int textWidth5 = (int)e.Graphics.MeasureString("Postal Code", e.Style.Font.GetFont()).Width + 5;
                int textWidth6 = (int)e.Graphics.MeasureString("City", e.Style.Font.GetFont()).Width + 5;
                int textWidth7 = (int)e.Graphics.MeasureString("Phone", e.Style.Font.GetFont()).Width + 5;
                int textWidth8 = (int)e.Graphics.MeasureString("HireDate", e.Style.Font.GetFont()).Width + 5;

                e.Graphics.DrawString("First Name", subItemsFont, headerBrush, new PointF(rect.Right + 50, rect.Y + 7));
                e.Graphics.DrawString("Last Name", subItemsFont, headerBrush, new PointF(rect.Right + 50, rect.Y + 27));
                e.Graphics.DrawString("Title", subItemsFont, headerBrush, new PointF(rect.Right + 50, rect.Y + 47));
                e.Graphics.DrawString("Address", subItemsFont, headerBrush, new PointF(rect.Right + 50, rect.Y + 67));

                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 50 + textWidth1, rect.Y + 7));
                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 50 + textWidth2, rect.Y + 27));
                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 50 + textWidth3, rect.Y + 47));
                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 50 + textWidth4, rect.Y + 67));


                e.Graphics.DrawString(record.FirstName, font, textBrush, new PointF(rect.Right + textWidth1 + 60, rect.Y + 7));
                e.Graphics.DrawString(record.LastName.ToString(), font, textBrush, new PointF(rect.Right + textWidth2 + 60, rect.Y + 27));
                e.Graphics.DrawString(record.Title.ToString(), font, textBrush, new PointF(rect.Right + textWidth3 + 60, rect.Y + 47));
                e.Graphics.DrawString(record.Address, font, textBrush, new PointF(rect.Right + textWidth4 + 60, rect.Y + 67));

                e.Graphics.DrawString("\tPostal Code", subItemsFont, headerBrush, new PointF(rect.Right + 300, rect.Y + 7));
                e.Graphics.DrawString("\tCity", subItemsFont, headerBrush, new PointF(rect.Right + 300, rect.Y + 27));
                e.Graphics.DrawString("\tPhone", subItemsFont, headerBrush, new PointF(rect.Right + 300, rect.Y + 47));
                e.Graphics.DrawString("\tHire Date", subItemsFont, headerBrush, new PointF(rect.Right + 300, rect.Y + 67));

                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 340 + textWidth5, rect.Y + 7));
                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 340 + textWidth6, rect.Y + 27));
                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 340 + textWidth7, rect.Y + 47));
                e.Graphics.DrawString(":", subItemsFont, headerBrush, new PointF(rect.Right + 340 + textWidth8, rect.Y + 67));

                e.Graphics.DrawString(record.PostalCode, font, textBrush, new PointF(rect.Right + 350 + textWidth5, rect.Y + 7));
                e.Graphics.DrawString(record.City, font, textBrush, new PointF(rect.Right + 350 + textWidth6, rect.Y + 27));
                e.Graphics.DrawString(record.Phone, font, textBrush, new PointF(rect.Right + 350 + textWidth7, rect.Y + 47));
                e.Graphics.DrawString(record.HireDate.ToString(), font, textBrush, new PointF(rect.Right + 350 + textWidth8, rect.Y + 67));

                e.Graphics.DrawLine(new Pen(e.Style.Borders.Bottom.Color), new Point(e.Bounds.Left, e.Bounds.Bottom - 1), new Point(e.Bounds.Right, e.Bounds.Bottom - 1));
                e.Graphics.DrawLine(new Pen(e.Style.Borders.Right.Color), new Point(e.Bounds.Right - 1, e.Bounds.Top), new Point(e.Bounds.Right - 1, e.Bounds.Bottom - 1));
                e.Graphics.SetClip(clipbounds);
                e.Handled = true;
            }
        }

        #endregion
    }

    public class PreviewRowExpanderCellRendererExt : PreviewRowExpanderCellRenderer
    {
        private void PaintCellBackground(Graphics graphics, Rectangle cellRect, CellStyleInfo style, bool canApplyInterior)
        {
            if (canApplyInterior && style.HasInterior)
                Syncfusion.WinForms.Core.BrushPainter.FillRectangle(graphics, cellRect, style.Interior);
            else
            {
                Brush backColor = new SolidBrush(style.BackColor);
                graphics.FillRectangle(backColor, cellRect);
                Syncfusion.ComponentModel.DisposeHelper.Dispose(ref backColor);
            }
        }

        protected override void OnRender(Graphics paint, Rectangle cellRect, string cellValue, CellStyleInfo style, DataColumnBase column, RowColumnIndex rowColumnIndex)
        {
            // To draw background for the Expander cell.
            PaintCellBackground(paint, cellRect, style, true);
        }
    }
}
