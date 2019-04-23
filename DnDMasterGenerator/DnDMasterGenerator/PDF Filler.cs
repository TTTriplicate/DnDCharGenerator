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

namespace DnDClassesTest
{
    class PDF_Filler
    {
        protected DnDCharacter DisplayChar { get; set; }

        public PDF_Filler(DnDCharacter newChar)
        {
            string nameOfFile = newChar._name;
            string PDFFolder = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs");
            string pdfTemplate = PDFFolder + @"\TWC-DnD-5E-Character-Sheet-v1.3.pdf";
            string newFile = PDFFolder + @"\" + nameOfFile + ".pdf";

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;

            pdfFormFields.SetField("PersonalityTraits ", newChar.CharBackground.getPersonality());
            pdfFormFields.SetField("CharacterName", newChar._name);
            pdfFormFields.SetField("ClassLevel", newChar._class.ProfessionName() + " " + newChar._level.ToString());
            pdfFormFields.SetField("HPMax", newChar._HP.ToString());
            pdfFormFields.SetField("Background", newChar.CharBackground.getBackground());
            pdfFormFields.SetField("Ideals", newChar.CharBackground.getIdeal());
            pdfFormFields.SetField("Bonds", newChar.CharBackground.getBond());
            pdfFormFields.SetField("Flaws", newChar.CharBackground.getFlaw());
            pdfFormFields.SetField("Race ", newChar.CharRace.getRace());
            pdfFormFields.SetField("PlayerName", newChar._playerName);

            pdfStamper.FormFlattening = false;
            pdfStamper.Close();
        }
    }
}
