using Novacode;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.RequirementsBuilder;
using Sefate.Incubator.WorkItem.Requrements.BLL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefate.Incubator.WorkItem.InterventionReport
{
    public class DocumentManager
    {
        private IncubatorWorkitemEntitiesManager incubatorWorkitemEntitiesManager { get; set; }


        public DocumentManager()
        {
            incubatorWorkitemEntitiesManager = new IncubatorWorkitemEntitiesManager();
        }
        public byte[] GenerateInterventionReport(InterventionReport client)
        {
            byte[] result = null;

            var t = incubatorWorkitemEntitiesManager.GetTemplate();
            RequirementManager requirementManager = new RequirementManager();

            if (t != null && t.TemplateContent != null)
            {

                var address1 = requirementManager.GetFieldValue("17", client.WorkItem.WorkItemID);
                var address2 = requirementManager.GetFieldValue("18", client.WorkItem.WorkItemID);
                var address3 = requirementManager.GetFieldValue("19", client.WorkItem.WorkItemID);
                var address4 = requirementManager.GetFieldValue("20", client.WorkItem.WorkItemID);

                var tel = requirementManager.GetFieldValue("6", client.WorkItem.WorkItemID);
                var directors = requirementManager.GetFieldValue("4", client.WorkItem.WorkItemID);

                using (DocX document = DocX.Load(new System.IO.MemoryStream(t.TemplateContent)))
                {
                    document.AddCustomProperty(new CustomProperty("ClientName",client.Client.ClientName));
                    document.AddCustomProperty(new CustomProperty("Telephone",tel));
                    document.AddCustomProperty(new CustomProperty("Address", address1 + Environment.NewLine + address2 + Environment.NewLine + address3 + Environment.NewLine + address4));
                    document.AddCustomProperty(new CustomProperty("Directors", directors));
                    document.InsertSectionPageBreak();
                    Paragraph intervention = document.InsertParagraph("Interventions");
                    Paragraph description = document.InsertParagraph("Based on the Deep Dive conducted on your business, we have identified the following areas of weakness as per the below table:");
                    intervention.FontSize(11);
                    intervention.Bold();
                    description.AppendLine();
                    intervention.AppendLine();
                    foreach(var group in client.FieldSetGroups)
                    {
                        var widths = new float[] { 400f, 100f, 150f, 200f, 450f };
                        var tbl = document.InsertTable(1, widths.Length);
                        tbl.SetWidths(widths);
                        var wholeWidth = document.PageWidth - document.MarginLeft - document.MarginRight;
                        tbl.AutoFit = AutoFit.Contents;
                        var r = tbl.Rows[0];
                        var cx = 0;

                        //r = tbl.InsertRow();
                        r.Cells[0].Paragraphs.First().Append("Issue and Implication").FontSize(11).Bold();

                        r.Cells[0].MarginBottom = 0;
                        r.Cells[0].MarginLeft = 0;
                        r.Cells[0].MarginRight = 0;
                        r.Cells[0].MarginTop = 0;

                        r.Cells[1].Paragraphs.First().Append("Priority").FontSize(11).Bold();

                        r.Cells[1].MarginBottom = 0;
                        r.Cells[1].MarginLeft = 0;
                        r.Cells[1].MarginRight = 0;
                        r.Cells[1].MarginTop = 0;

                        r.Cells[2].Paragraphs.First().Append("Mitigation").FontSize(11).Bold();

                        r.Cells[2].MarginBottom = 0;
                        r.Cells[2].MarginLeft = 0;
                        r.Cells[2].MarginRight = 0;
                        r.Cells[2].MarginTop = 0;

                        r.Cells[3].Paragraphs.First().Append("Deadline").FontSize(11).Bold();

                        r.Cells[3].MarginBottom = 0;
                        r.Cells[3].MarginLeft = 0;
                        r.Cells[3].MarginRight = 0;
                        r.Cells[3].MarginTop = 0;

                        r.Cells[4].Paragraphs.First().Append("Notes post IR Meeting").FontSize(11).Bold();

                        r.Cells[4].MarginBottom = 0;
                        r.Cells[4].MarginLeft = 0;
                        r.Cells[4].MarginRight = 0;
                        r.Cells[4].MarginTop = 0;
                        foreach (var fieldset in group.FieldSets)
                        {
                            if(fieldset.WorkItemFields!=null && fieldset.WorkItemFields.Any()&& !string.IsNullOrEmpty(fieldset.WorkItemFields.FirstOrDefault().FieldValue))
                            {
                                r = tbl.InsertRow();
                                cx = 0;
                                foreach (var cell in r.Cells)
                                {
                                    switch (cx)
                                    {
                                        case 0:
                                            var value = GetCellValue("170", fieldset);
                                            cell.Paragraphs.First().Append(value);
                                            break;
                                        case 1:
                                            var value1 = GetCellValue("171", fieldset);
                                            cell.Paragraphs.First().Append(value1);
                                            break;
                                        case 2:
                                            var value2 = GetCellValue("172", fieldset);
                                            cell.Paragraphs.First().Append(value2);
                                            break;
                                        case 3:
                                            var value3 = GetCellValue("173", fieldset);
                                            cell.Paragraphs.First().Append(value3);
                                            break;
                                        case 4:
                                            var value4 = GetCellValue("174", fieldset);
                                            cell.Paragraphs.First().Append(value4);
                                            break;
                                    }
                                    cell.MarginBottom = 0;
                                    cell.MarginLeft = 0;
                                    cell.MarginRight = 0;
                                    cell.MarginTop = 0;
                                    cx++;
                                }
                            }
                        }

                        Border BlankBorder = new Border(BorderStyle.Tcbs_single, BorderSize.four, 0, Color.Black);
                        tbl.SetBorder(TableBorderType.Bottom, BlankBorder);
                        tbl.SetBorder(TableBorderType.Left, BlankBorder);
                        tbl.SetBorder(TableBorderType.Right, BlankBorder);
                        tbl.SetBorder(TableBorderType.Top, BlankBorder);
                        tbl.SetBorder(TableBorderType.InsideV, BlankBorder);
                        tbl.SetBorder(TableBorderType.InsideH, BlankBorder);
                    }
                    MemoryStream ms = new MemoryStream();
                    document.SaveAs(ms);
                    result = ms.ToArray();
                }
            }
            return result;
        }

        private string GetCellValue(string code,FieldSet fieldset)
        {
            var fieldList = fieldset.WorkItemFields.Where(x => x.FieldCode == code);

            if(fieldList !=null&& fieldList.Any())
            {
                var field = fieldList.FirstOrDefault();
                var value = field == null ? "" : field.FieldValue;
                return value;
            }
            return string.Empty;
            //cell.Paragraphs.First().Append(value);
        }
    }
}

 