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
            string[] abils = { "ST Strength", "ST Dexterity", "ST Constitution", "ST Intelligence", "ST Wisdom", "ST Charisma" };
            //string[] skills = { "Athletics", "end", "end",  "end", "end", };
            string[] dex = { "0", "Acrobatics", "15", "SleightofHand", "16", "Stealth ", "3", "Athletics" };
            string[] intel = { "2", "Arcana", "5", "History ", "8" ,"Investigation ", "10" ,"Nature", "14" ,"Religion" };
            string[] wis = { "1" ,"Animal", "6","Insight", "9" ,"Medicine", "11" ,"Perception ", "17" ,"Survival" };
            string[] cha = { "4" ,"Deception ", "7", "Intimidation", "12", "Performance", "13" ,"Persuasion" };
            bool[] skillBoxes = new bool[18];
            string nameOfFile = newChar._name;
            string PDFFolder = Path.Combine(Environment.CurrentDirectory, @"..\..\PDFs");
            string pdfTemplate = PDFFolder + @"\TWC-DnD-5E-Character-Sheet-v1.3.pdf";
            string newFile = PDFFolder + @"\" + nameOfFile + ".pdf";

            PdfReader pdfReader = new PdfReader(pdfTemplate);
            PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(newFile, FileMode.Create));
            AcroFields pdfFormFields = pdfStamper.AcroFields;
            //string[] checkBoxTrueFalse = pdfFormFields.GetAppearanceStates("Check Box 11");
            int indexOne = -1, indexTwo = -1, count = 0;

            //for (count = 0; count < 17; count++)
            //{
            //    if (indexOne == -1)
            //    {
            //        if (newChar.CharBackground.SkillProf[count] == true)
            //            indexOne = count;
            //    }
            //    else if (indexTwo == -1 && indexOne != count)
            //    {
            //        if (newChar.CharBackground.SkillProf[count] == true)
            //            indexTwo = count;
            //    }
            //}

            foreach (bool i in newChar.CharBackground.SkillProf)
            {
                if (i == true && indexOne == -1)
                {
                    indexOne = count;
                }
                if (indexOne != -1 && i == true && indexOne != count)
                {
                    indexTwo = count;
                }
                count++;
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
            pdfFormFields.SetField("Initiative", newChar.AbilityModifiers()[1].ToString());
            pdfFormFields.SetField("Passive", newChar.AbilityModifiers()[4].ToString());
            pdfFormFields.SetField("AC", newChar.getAC().ToString());

            string save;
            if (newChar.SavingThrows[0])
                save = "Yes";
            else
                save = "No";
            pdfFormFields.SetField("Check Box 11", save);

            for (int i = 18, num = 1; i < 23; i++)
            {
                if (newChar.SavingThrows[num++])
                    save = "Yes";
                else
                    save = "No";
                pdfFormFields.SetField("Check Box " + i.ToString(), save);
            }

            //int[] abilfill = new int[12];

            count = 0;
            foreach (string i in abils)
            {
                if (newChar.SavingThrows[count])
                {
                    pdfFormFields.SetField(i, (newChar.AbilityModifiers()[count] + newChar.ProficiencyBonus()).ToString());
                }
                else
                    pdfFormFields.SetField(i, newChar.AbilityModifiers()[count].ToString());
                count++;
                //abilfill[i].ToString();
                //if (i % 2 == 1)
                //{
                //    if (newChar.SavingThrows[i / 2])
                //        panelSaves.Controls[i / 2].Text = (abilfill[i] + newChar.ProficiencyBonus()).ToString();
                //    else panelSaves.Controls[i / 2].Text = abilfill[i].ToString();
                //}
                //i++;
            }

            //count = 0;
            //foreach (bool i in newChar.SavingThrows)
            //{
            //    if (i == true)
            //        save = "Yes";
            //    else
            //        save = "No";
            //    pdfFormFields.SetField("Check Box " + (count + 17), save);
            //}

            //MessageBox.Show((indexOne + 23).ToString() + "blah1 " + (indexTwo + 23).ToString() + "blah2");

            //bool set = pdfFormFields.SetFieldProperty("Check Box 11", "textsize", 10.0f, null);
            //MessageBox.Show(GetCheckBoxExportValue(pdfFormFields, "Check Box 27_Yes "));
            //pdfFormFields.SetField("Check Box 23", "Yes");
            //pdfFormFields.SetField(("Check Box 27_Yes"), "FillText156" );
            //MessageBox.Show((indexOne + 23).ToString() + " " + (indexTwo + 23).ToString());
            pdfFormFields.SetField("Check Box " + (indexOne + 23), "Yes");
            pdfFormFields.SetField("Check Box " + (indexTwo + 23), "Yes");            
            skillBoxes[indexOne] = true;
            skillBoxes[indexTwo] = true;
            MessageBox.Show(indexOne.ToString() + " " + skillBoxes[indexOne].ToString());
            MessageBox.Show(indexTwo.ToString() + " " + skillBoxes[indexTwo].ToString());
            string indexNum = "0";
            foreach (string i in dex)
            {
                if (i.Length < 3)
                {
                    indexNum = i;
                }
                else if (i.Length > 3)
                {
                    if (i == "Athletics")
                    {
                        if (skillBoxes[int.Parse(indexNum)])
                        {
                            pdfFormFields.SetField(i, (newChar.AbilityModifiers()[0] + newChar.ProficiencyBonus()).ToString());
                            //MessageBox.Show("bingo");
                        }
                        else
                            pdfFormFields.SetField(i, newChar.AbilityModifiers()[0].ToString());
                    }
                    //MessageBox.Show((int.Parse(indexNum).ToString() + skillBoxes[int.Parse(indexNum)].ToString()));
                    else if (skillBoxes[int.Parse(indexNum)])
                    {
                        pdfFormFields.SetField(i, (newChar.AbilityModifiers()[1] + newChar.ProficiencyBonus()).ToString());
                        //MessageBox.Show("bingo");
                    }
                    else
                        pdfFormFields.SetField(i, newChar.AbilityModifiers()[1].ToString());
                }
                //indexNum = "0";
            }

            foreach (string i in intel)
            {
                if (i.Length < 3)
                {
                    indexNum = i;
                }
                else if (i.Length > 3)
                {
                    //MessageBox.Show((int.Parse(indexNum).ToString() + skillBoxes[int.Parse(indexNum)].ToString()));
                    if (skillBoxes[int.Parse(indexNum)])
                    {
                        pdfFormFields.SetField(i, (newChar.AbilityModifiers()[3] + newChar.ProficiencyBonus()).ToString());
                        //MessageBox.Show("bingo");
                    }
                    else
                        pdfFormFields.SetField(i, newChar.AbilityModifiers()[3].ToString());
                }
                //indexNum = "0";
            }

            foreach (string i in wis)
            {
                if (i.Length < 3)
                {
                    indexNum = i;
                }
                else if (i.Length > 3)
                {
                    //MessageBox.Show((int.Parse(indexNum).ToString() + skillBoxes[int.Parse(indexNum)].ToString()));
                    if (skillBoxes[int.Parse(indexNum)])
                    {
                        pdfFormFields.SetField(i, (newChar.AbilityModifiers()[4] + newChar.ProficiencyBonus()).ToString());
                        //MessageBox.Show("bingo");
                    }
                    else
                        pdfFormFields.SetField(i, newChar.AbilityModifiers()[4].ToString());
                }
                //indexNum = "0";
            }

            foreach (string i in cha)
            {
                if (i.Length < 3)
                {
                    indexNum = i;
                }
                else if (i.Length > 3)
                {
                    //MessageBox.Show((int.Parse(indexNum).ToString() + skillBoxes[int.Parse(indexNum)].ToString()));
                    if (skillBoxes[int.Parse(indexNum)])
                    {
                        pdfFormFields.SetField(i, (newChar.AbilityModifiers()[5] + newChar.ProficiencyBonus()).ToString());
                        //MessageBox.Show("bingo");
                    }
                    else
                        pdfFormFields.SetField(i, newChar.AbilityModifiers()[5].ToString());
                }
                //indexNum = "0";
            }

            //pdfFormFields.SetField("Equipment", "Test test test");
            string stringInventory = "";
            for (int i = 0; i < newChar.getInventoryString().Count(); i++)
            {
                stringInventory += (newChar.getInventoryString()[i]) + "\n";
            }
            pdfFormFields.SetField("Equipment", stringInventory);

            string languages = "";
            foreach (string i in newChar.CharRace.getLanguages())
            {
                if (languages != "")
                    languages += ", ";
                languages += i;
            }
            pdfFormFields.SetField("ProficienciesLang", languages);

            pdfStamper.FormFlattening = false;
            pdfStamper.Close();
        }
    }
}
