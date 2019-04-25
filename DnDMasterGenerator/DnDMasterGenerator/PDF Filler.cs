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
            //string[] checkBoxTrueFalse = pdfFormFields.GetAppearanceStates("Check Box 11");
            int indexOne = -1, indexTwo = -1, count = 0;

            for (count = 0; count < 17; count++)
            {
                if (indexOne == -1)
                {
                    if (newChar.CharBackground.SkillProf[count] == true)
                        indexOne = count;
                }
                else if (indexTwo == -1 && indexOne != count)
                {
                    if (newChar.CharBackground.SkillProf[count] == true)
                        indexTwo = count;
                }
            }

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
            pdfFormFields.SetField("GP", newChar.gold.ToString());
            pdfFormFields.SetField("Alignment", newChar.CharRace.getAlignment());
            pdfFormFields.SetField("ProfBonus", newChar.ProficiencyBonus().ToString());
            pdfFormFields.SetField("STRmod", newChar._abilities[0].ToString());
            pdfFormFields.SetField("STR", newChar.AbilityModifiers()[0].ToString());
            pdfFormFields.SetField("DEXmod ", newChar._abilities[1].ToString());
            pdfFormFields.SetField("DEX", newChar.AbilityModifiers()[1].ToString());
            pdfFormFields.SetField("CONmod", newChar._abilities[2].ToString());
            pdfFormFields.SetField("CON", newChar.AbilityModifiers()[2].ToString());
            pdfFormFields.SetField("INTmod", newChar._abilities[3].ToString());
            pdfFormFields.SetField("INT", newChar.AbilityModifiers()[3].ToString());
            pdfFormFields.SetField("WISmod", newChar._abilities[4].ToString());
            pdfFormFields.SetField("WIS", newChar.AbilityModifiers()[4].ToString());
            pdfFormFields.SetField("CHamod", newChar._abilities[5].ToString());
            pdfFormFields.SetField("CHA", newChar.AbilityModifiers()[5].ToString());
            pdfFormFields.SetField("Age", newChar.CharBackground.getAge());
            pdfFormFields.SetField("CharacterName 2", newChar._name);
            pdfFormFields.SetField("Height", newChar.CharBackground.getHeight());
            pdfFormFields.SetField("Weight", newChar.CharBackground.getWeight());
            pdfFormFields.SetField("Eyes", newChar.CharBackground.getEyes());
            pdfFormFields.SetField("Skin", newChar.CharBackground.getSkin());
            pdfFormFields.SetField("Hair", newChar.CharBackground.getHair());
            //MessageBox.Show((indexOne + 23).ToString() + "blah1 " + (indexTwo + 23).ToString() + "blah2");

            //bool set = pdfFormFields.SetFieldProperty("Check Box 11", "textsize", 10.0f, null);
            //MessageBox.Show(GetCheckBoxExportValue(pdfFormFields, "Check Box 27_Yes "));
            //pdfFormFields.SetField("Check Box 23", "Yes");
            //pdfFormFields.SetField(("Check Box 27_Yes"), "FillText156" );

            pdfFormFields.SetField("Check Box " + (indexOne + 23), "Yes");
            pdfFormFields.SetField("Check Box " + (indexTwo + 23), "Yes");

            //pdfFormFields.SetField("Equipment", "Test test test");
            string stringInventory = "";
            for (int i = 0; i < newChar.getInventoryString().Count(); i++)
            {
                stringInventory += (newChar.getInventoryString()[i]) + "\n";
            }
            pdfFormFields.SetField("Equipment", stringInventory);

            pdfStamper.FormFlattening = false;
            pdfStamper.Close();
        }
    }
}
