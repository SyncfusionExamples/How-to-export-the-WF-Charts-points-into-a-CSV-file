using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Chart;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GettingStarted_Chart
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Panel panel = new Panel();

            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.SuspendLayout();
            panel.SuspendLayout();
            // 
            // chartControl1
            // 
            this.chartControl1.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Transparent);
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.DataSourceName = "[none]";
            this.chartControl1.IsWindowLess = false;            
            this.chartControl1.TabIndex = 0;            
            this.chartControl1.Skins = Skins.Metro;

            //
            // PrimaryXAxis
            //
            this.chartControl1.PrimaryXAxis.ValueType = ChartValueType.Category;
            this.chartControl1.PrimaryXAxis.TitleColor = System.Drawing.SystemColors.ControlText;
           
            BindingList<SalesData> dataSource = new BindingList<SalesData>();
            dataSource.Add(new SalesData("1999", 3));
            dataSource.Add(new SalesData("2000", 7));
            dataSource.Add(new SalesData("2001", 12));
            dataSource.Add(new SalesData("2002", 18));
            dataSource.Add(new SalesData("2003", 22));
            dataSource.Add(new SalesData("2004", 30));
            dataSource.Add(new SalesData("2005", 40));
            dataSource.Add(new SalesData("2006", 50));
            dataSource.Add(new SalesData("2007", 65));
            dataSource.Add(new SalesData("2008", 75));

            CategoryAxisDataBindModel dataSeriesModel = new CategoryAxisDataBindModel(dataSource);
            dataSeriesModel.CategoryName = "Year";
            dataSeriesModel.YNames = new string[] { "Sales" };

            ChartSeries chartSeries = new ChartSeries("Sales");
            chartSeries.CategoryModel = dataSeriesModel;
            chartSeries.Style.DisplayText = true;
            chartSeries.Style.TextOrientation = ChartTextOrientation.Up;

            this.chartControl1.Legend.Visible = true;
            this.chartControl1.LegendAlignment = ChartAlignment.Center;
            this.chartControl1.Legend.Position = ChartDock.Top;
            this.chartControl1.LegendsPlacement = ChartPlacement.Outside;
            this.chartControl1.Series.Add(chartSeries);

            this.chartControl1.ShowToolTips = true;
            this.chartControl1.Tooltip.BackgroundColor = new BrushInfo(Color.White);
            this.chartControl1.Tooltip.BorderStyle = BorderStyle.FixedSingle;
            this.chartControl1.Tooltip.Font = new Font("Segoe UI", 10);
            chartSeries.PointsToolTipFormat = "{2}";

            this.chartControl1.Size = new System.Drawing.Size(1500, 450);
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 577);

            foreach (ChartSeries series in this.chartControl1.Series)
            {
                string seriesName = series.Name;
                int pointCount = series.Points.Count;
                string seriesType = series.Type.ToString();

                for (int p = 0; p < pointCount; p++)
                {
                    ChartPoint point = series.Points[p];
                    string yValuesCSV = String.Empty;
                    int count = point.YValues.Length;

                    for (int i = 0; i < count; i++)
                    {
                        yValuesCSV += point.YValues[i];
                        if (i != count - 1)
                            yValuesCSV += comma;
                    }
                    csvLine = seriesName + "-" + seriesType + comma + point.Category + comma + yValuesCSV;
                    csvContent += csvLine + "\r\n";
                }
            }
            // Using stream writer class the chart points are exported. Create an instance of the stream writer class.
            System.IO.StreamWriter file = new System.IO.StreamWriter("chartdata.csv");
            // Write the datapoints into the file.
            file.WriteLine(csvContent);
            file.Close();

            panel.AutoSize = true;
            panel.Controls.Add(chartControl1);

            this.Controls.Add(panel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
        }

        #endregion

        private Syncfusion.Windows.Forms.Chart.ChartControl chartControl1;
        private string comma =",";
        private string csvLine;
        private string csvContent;
    }
}

