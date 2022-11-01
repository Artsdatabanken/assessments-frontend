using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using Assessments.Frontend.Web.Infrastructure.Services;
using Assessments.Mapping.AlienSpecies;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.RedlistSpecies;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class ExportHelper
    {
        public static MemoryStream GenerateSpeciesAssessment2021Export(IEnumerable<SpeciesAssessment2021Export> assessments,  IEnumerable<ExpertCommitteeMember> expertCommitteeMembers, string displayUrl)
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

                worksheet.Columns().Width = 28;

                var table = new DataTable("Feltnavn og beskrivelser");
                table.Columns.Add("Feltnavn");
                table.Columns.Add("Beskrivelse");

                foreach (var element in exportColumns)
                    table.Rows.Add(element.DisplayName, element.Description);

                workbook.Worksheets.Add(table);
                workbook.Worksheet(2).Columns().AdjustToContents();
                
                var expertCommitteeWorksheet = workbook.AddWorksheet("Ekspertkomitéer");
                expertCommitteeWorksheet.Cell(1, 1).InsertTable(expertCommitteeMembers
                    .OrderBy(x => x.ExpertCommittee).ThenBy(x => x.LastName).Select(x => new
                {
                    Ekspertkomité = x.ExpertCommittee,
                    Navn = x.Name,
                    Institusjon = x.Institution
                }).ToList());

                workbook.Worksheet(3).Columns().AdjustToContents();

                var citeAsWorksheet = workbook.AddWorksheet("Siteres som");
                var referringUrl = new Uri(displayUrl);
                citeAsWorksheet.Cell(1, 1).Value = $"Artsdatabanken (2021, 24. november). Norsk rødliste for arter 2021. Utvalg {referringUrl}. {referringUrl.GetLeftPart(UriPartial.Path)}";

                foreach (var workbookWorksheet in workbook.Worksheets)
                    workbookWorksheet.SheetView.FreezeRows(1);

                memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        public static MemoryStream GenerateAlienSpeciesAssessment2023Export(IEnumerable<AlienSpeciesAssessment2023Export> assessments,  string displayUrl)
        {
            MemoryStream memoryStream;
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet("Vurderinger");
                worksheet.Cell(1, 1).InsertTable(assessments);

                var exportColumns = typeof(AlienSpeciesAssessment2023Export).GetProperties().Select(p => new
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

                worksheet.Columns().Width = 28;

                var table = new DataTable("Feltnavn og beskrivelser");
                table.Columns.Add("Feltnavn");
                table.Columns.Add("Beskrivelse");

                foreach (var element in exportColumns)
                    table.Rows.Add(element.DisplayName, element.Description);

                workbook.Worksheets.Add(table);
                workbook.Worksheet(2).Columns().AdjustToContents();

                var citeAsWorksheet = workbook.AddWorksheet("Siteres som");
                var referringUrl = new Uri(displayUrl);
                citeAsWorksheet.Cell(1, 1).Value = $"Artsdatabanken (2023). Fremmedartslista 2023. Utvalg {referringUrl}. {referringUrl.GetLeftPart(UriPartial.Path)}";

                foreach (var workbookWorksheet in workbook.Worksheets)
                    workbookWorksheet.SheetView.FreezeRows(1);

                memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }
}
