using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using Assessments.Mapping.Models.Species;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class ExportHelper
    {
        public static MemoryStream GenerateSpeciesAssessment2021Export(IEnumerable<SpeciesAssessment2021Export> assessments)
        {
            MemoryStream memoryStream;
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("Vurderinger");
                
                worksheet.Cell(1, 1).InsertTable(assessments);

                var exportColumns = typeof(SpeciesAssessment2021Export).GetProperties().Select(p => new
                {
                    p.GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>().Single().DisplayName, 
                    p.GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>().Single().Description
                }).ToList(); 

                var firstRow = worksheet.FirstRow();
                var columnNumber = 1;

                foreach (var column in exportColumns)
                {
                    firstRow.Cell(columnNumber).Value = column.DisplayName;		
                    columnNumber++;
                }

                worksheet.SheetView.FreezeRows(1);
                worksheet.Columns().AdjustToContents();

                var table = new DataTable("Feltnavn og beskrivelser");
                table.Columns.Add("Feltnavn");
                table.Columns.Add("Beskrivelse");

                foreach (var element in exportColumns)
                    table.Rows.Add(element.DisplayName, element.Description);

                workbook.Worksheets.Add(table);

                workbook.Worksheet(2).SheetView.FreezeRows(1);
                workbook.Worksheet(2).Columns().AdjustToContents();

                memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }
}
