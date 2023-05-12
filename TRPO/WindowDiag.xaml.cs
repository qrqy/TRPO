using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using excel = Microsoft.Office.Interop.Excel;
using word = Microsoft.Office.Interop.Word;

namespace TRPO
{
    /// <summary>
    /// Логика взаимодействия для WindowDiag.xaml
    /// </summary>
    public partial class WindowDiag : System.Windows.Window
    {
        private SkladBDEntitie SkladBD = new SkladBDEntitie();
        public WindowDiag()
        {
            InitializeComponent();
            Aboba.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea("Main"));
            var aboba = new System.Windows.Forms.DataVisualization.Charting.Series("Номенлкатура") { IsValueShownAsLabel = true };
            Aboba.Series.Add(aboba);
            UpdateChart();
        }
        private void UpdateChart()
        {
            System.Windows.Forms.DataVisualization.Charting.Series series = Aboba.Series.FirstOrDefault();
            series.ChartType = SeriesChartType.Bar;
            series.Points.Clear();
            var cat = SkladBD.classification.ToList();
            foreach (var item in cat)
            {
                series.Points.AddXY(item.classification1, SkladBD.product.ToList().Where(x => x.classification_id == item.classification_id).Sum(x => x.price * x.count));
            }
        }

        private void ExcelButton_Click(object sender, RoutedEventArgs e)
        {
            var application = new Microsoft.Office.Interop.Excel.Application();
            application.SheetsInNewWorkbook = App.GetClassifications.Count();
            excel.Workbook workbook = application.Workbooks.Add(Type.Missing);
            excel.Worksheet worksheet = application.Worksheets.Item[1];
            worksheet.Name = "Отчет";
            
            for (int i = 1; i <= App.GetClassifications.Count(); i++)
            {
                //excel.Range objects = worksheet.Range(worksheet.Cells[1][1], worksheet.Cells[2][App.GetClassifications.Count()]);
                worksheet.Cells[i][1] = App.GetClassifications[i].classification1;
                worksheet.Cells[i][2] = App.GetProduct.Where(x => x.classification_id == App.GetClassifications[i].classification_id).Select(x=>x.count).Sum().ToString();
            }
            application.Visible = true;
        }

        private void WordButton_Click(object sender, RoutedEventArgs e)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            word.Document document = application.Documents.Add();
            foreach (var item in App.GetClassifications)
            {
                word.Paragraph clasParagraph = document.Paragraphs.Add();
                word.Range clasRange = clasParagraph.Range;
                clasRange.Text = item.classification1;
                clasRange.set_Style("Заголовок");
                clasRange.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                clasRange.InsertParagraphAfter();
                document.Paragraphs.Add();

                word.Paragraph tableParagraph = document.Paragraphs.Add();
                word.Range tableRange = tableParagraph.Range;
                word.Table clasTable = document.Tables.Add(tableRange, App.GetProduct.Where(x => x.classification_id == item.classification_id).Count() + 1, 2);
                clasTable.Borders.InsideLineStyle = clasTable.Borders.OutsideLineStyle = word.WdLineStyle.wdLineStyleSingle;
                clasTable.Range.Cells.VerticalAlignment = word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                word.Range cellRange = clasTable.Cell(1, 1).Range;
                cellRange.Text = "Номенклатура";
                cellRange = clasTable.Cell(1, 2).Range;
                cellRange.Text = "Кол-во";

                clasTable.Rows[1].Range.Font.Name = "Times New Roman";
                clasTable.Rows[1].Range.Font.Size = 14;
                clasTable.Rows[1].Range.Bold = 1;
                clasTable.Rows[1].Range.ParagraphFormat.Alignment = word.WdParagraphAlignment.wdAlignParagraphCenter;
                for (int i = 0; i < App.GetProduct.Where(x => x.classification_id == item.classification_id).Count(); i++)
                {
                    var current = App.GetProduct.Where(x => x.classification_id == item.classification_id).ToList()[i];
                    cellRange = clasTable.Cell(i + 2, 1).Range;
                    cellRange.Text = current.name;
                    cellRange.Font.Name = " Times New Roman ";
                    cellRange.Font.Size = 12;
                    cellRange = clasTable.Cell(i + 2, 2).Range;
                    cellRange.Text = current.count.ToString();
                    cellRange.Font.Name = " Times New Roman ";
                    cellRange.Font.Size = 12;
                }
                document.Paragraphs.Add();
            }
            application.Visible = true;
        }
    }
}
