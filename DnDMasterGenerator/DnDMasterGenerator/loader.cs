using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Windows.Forms;

namespace DnDClassesTest
{
    class loader
    {
        protected DnDCharacter DisplayChar { get; set; }

        public void loadFile(DnDCharacter newChar)
        {
            string nameOfFile = newChar._name;
            string PDFFolder = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs");
            string pdfTemplate = PDFFolder + @"\TWC-DnD-5E-Character-Sheet-v1.3.pdf";
            string newFile = PDFFolder + @"\" + nameOfFile + ".pdf";

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;
        }
    }
}
