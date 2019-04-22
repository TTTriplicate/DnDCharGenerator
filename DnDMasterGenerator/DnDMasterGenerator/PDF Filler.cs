﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace DnDClassesTest
{
    class PDF_Filler
    {
        public PDF_Filler()
        {
            buildPDF();
        }

        public void buildPDF()
        {
            string nameOfFile = "";
            string pdfTemplate = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs\TWC-DnD-5E-Character-Sheet-v1.3");
            string newFile = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs\" + nameOfFile + ".pdf");

            PdfReader reader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(reader, new FileStream(newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;

            pdfFormFields.SetField("f1_91(0)", "blah");
        }
    }
}