using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sefate.Incubator.WorkItem.DAL;
using Sefate.Incubator.WorkItem.InterventionReport;

namespace LLDIncubation.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]

        public void InsertTemplate()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Thapelo\Documents\Visual Studio 2015\Projects\IncubatorRequirements.DALL\LLDIncubation.Test\InterventionsReport.docx");

            IncubatorWorkitemEntitiesManager context = new IncubatorWorkitemEntitiesManager();
            context.AddReportTemplate("Intervention Report", 0.1, bytes);
        }

        [TestMethod]
        public void GenerateInterventionReport()
        {
            DocumentManager manager = new DocumentManager();

            var byteContent = manager.GenerateInterventionReport(new Sefate.Incubator.WorkItem.InterventionReport.InterventionReport());
            var tempFile = Path.GetTempFileName() + ".docx";
            Debug.WriteLine("Writing file to: " + tempFile);
            File.WriteAllBytes(tempFile, byteContent);
        }
    }
}
