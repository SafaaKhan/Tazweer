using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Tazweer.Controllers
{
    public class PintImageFromPDFController : Controller
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment;
        public PintImageFromPDFController(Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public FileResult Index(string fileName)
        {
            //fileName = "Saudi_Passport_2022.jpg";
            string wwwPath = this.Environment.WebRootPath;
            string contentPath = this.Environment.ContentRootPath;

            string path = Path.Combine(this.Environment.WebRootPath, "Images");

            using (MemoryStream stream = new System.IO.MemoryStream())
            {
                //This code is responsible for initialize the PDF document object.
                using (Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();

                    //This code is responsible for to add the Image file to the PDF document object.
                    iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Path.Combine(path, fileName));
                    pdfDoc.Add(img);
                    pdfDoc.Close();

                    //This code is responsible for download the PDF file.
                    return File(stream.ToArray(), "application/pdf", "CoreProgramm_Image_PDF_Converter.pdf");
                }
            }
        }
    }
}
