using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;

namespace ExemploPDFSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document();
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);

            double a4Width = 595.276;
            double a4Height = 841.8898;

           

            try
            {
                document.Info.Title = "";
                document.Info.Subject = "";
                document.Info.Author = "";
                document.DefaultPageSetup.Orientation = Orientation.Portrait;
                document.DefaultPageSetup.PageWidth = a4Width;
                document.DefaultPageSetup.PageHeight = a4Height;
                document.DefaultPageSetup.HeaderDistance = Unit.FromCentimeter(0.5);

                document.AddSection();

                document.LastSection.AddParagraph("Teste do PDF");

                renderer.Document = document;
                renderer.RenderDocument();
                
                var filename = "teste.pdf";

                renderer.PdfDocument.Save(filename);
                
                Process.Start(filename);
                
                //MemoryStream stream = new MemoryStream();
                //renderer.PdfDocument.Save(stream, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //byte[] pdf = stream.ToArray();
            //return new FileContentResult(pdf, "application/pdf");
        }
    }
}
