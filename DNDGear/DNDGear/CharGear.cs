using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDGear
{
    class CharGear
    {
        public List<Gear> allGear = new List<Gear>();
        public string classType; // stores what type of class/profession the character is
        public string backgroundType; //stores what type of background
        public int numChoices = 0; //how many different times the user will have to choose something, aka the number of combo boxes needed)
        public int gp; //(how much gold)
        public List<List<Gear>> options = new List<List<Gear>>();
        public int dexMod;
        public int reformat = 0;

        public const int startSimpleMelee = 0;
        public const int startSimpleRanged = 11;
        public const int startMartialMelee = 15;
        public const int startMeleeRanged = 33;
        public const int startArmor = 38;
        public const int startDruidicFocus = 43;
        public const int startArcaneFocus = 47;
        public const int startHolySymbol = 52;
        public const int startPacks = 55;
        public const int startArtisans = 61;
        public const int startInstruments = 78;
        public const int endInstruments = 88;

        public CharGear(string classType, string backgroundType, int dexMod)
        {
            this.classType = classType;
            this.backgroundType = backgroundType;
            this.dexMod = dexMod;
            populateGear();
            popOptions();
        }
        
        //output 
        /**
         * Mutator method to populate a List<Gear> with all possible choices of gear
         * All gear is hardcoded in, even though this is a horrible horrible idea
         */
        public void populateGear()
        {
            //0-10 Simple Melee Weapons
            allGear.Add(new Weapon("Club", 4, 1));
            allGear.Add(new Weapon("Dagger", 4, true));
            allGear.Add(new Weapon("Greatclub", 8, false, true));
            allGear.Add(new Weapon("Handaxe", 6, 1));
            allGear.Add(new Weapon("Javelin", 6, 1));
            allGear.Add(new Weapon("Light hammer", 4, 1)); //5
            allGear.Add(new Weapon("Mace", 6, 1));
            allGear.Add(new Weapon("Quarterstaff", 6, false, false, true));
            allGear.Add(new Weapon("Sickle", 4, 1));
            allGear.Add(new Weapon("Spear", 6, false, false, true)); 
            allGear.Add(new Weapon("Unarmed strike", 1, 1)); //10
            //11-14 Simple Ranged Weapons
            allGear.Add(new Weapon("Crossbow, light", 8, false, true, false, true));
            allGear.Add(new Weapon("Dart", 4, true));
            allGear.Add(new Weapon("Shortbow", 6, false, true));
            allGear.Add(new Weapon("Sling", 4, 1));
            //15-32 Martial Melee Weapons
            allGear.Add(new Weapon("Battleax", 8, false, false, true)); //15
            allGear.Add(new Weapon("Flail", 8, 1));
            allGear.Add(new Weapon("Glaive", 10, false, true, false, false, true));
            allGear.Add(new Weapon("Greatax", 12, false, true, false, false, true));
            allGear.Add(new Weapon("Greatsword", 6, 2)); 
            allGear.Add(new Weapon("Halberd", 10, false, true, false, false, true)); //20
            allGear.Add(new Weapon("Lance", 12, false, false, false, false, true));
            allGear.Add(new Weapon("Longsword", 8, false, false, true));
            allGear.Add(new Weapon("Maul", 6, false, true, false, false, true, false, 2));
            allGear.Add(new Weapon("Morningstar", 8, 1)); 
            allGear.Add(new Weapon("Pike", 10, false, true, false, false, true));//25
            allGear.Add(new Weapon("Rapier", 8, true));
            allGear.Add(new Weapon("Scimitar", 6, true));
            allGear.Add(new Weapon("Shortsword", 6, true));
            allGear.Add(new Weapon("Trident", 6, false, false, true)); 
            allGear.Add(new Weapon("War pick", 8, 1)); //30
            allGear.Add(new Weapon("Warhammer", 8, false, false, true));
            allGear.Add(new Weapon("Whip", 4, true));
            //33-37 Martial Ranged Weapons
            allGear.Add(new Weapon("Blowgun", 1, false, false, false, true));
            allGear.Add(new Weapon("Crossbow, hand", 6, false, false, false, true)); 
            allGear.Add(new Weapon("Crossbow, heavy", 10, false, true, false, true, true)); //35
            allGear.Add(new Weapon("Longbow", 8, false, true, false, false, true));
            allGear.Add(new Weapon("Net", 0, false, false, false, false, false, true));
            //38-42 Armor
            allGear.Add(new Armor("Leather Armor", 11, dexMod));
            allGear.Add(new Armor("Chain shirt", 13, dexMod, 2)); 
            allGear.Add(new Armor("Scale mail", 14, dexMod, 2, true)); //40
            allGear.Add(new Armor("Chain mail", 16, 0, true));
            allGear.Add(new Armor("Shield", 2));
            //43-115 Equipment
            //43-46 Druidic focus
            allGear.Add(new Equipment("Sprig of mistletoe"));
            allGear.Add(new Equipment("Totem"));
            allGear.Add(new Equipment("Wooden staff")); //45 
            allGear.Add(new Equipment("Yew wand")); 
            //47-51 Arcane Focus
            allGear.Add(new Equipment("Crystal"));
            allGear.Add(new Equipment("Orb"));
            allGear.Add(new Equipment("Rod"));
            allGear.Add(new Equipment("Staff")); //50
            allGear.Add(new Equipment("Wand")); 
            //52-54 Holy symbol
            allGear.Add(new Equipment("Amulet"));
            allGear.Add(new Equipment("Emblem"));
            allGear.Add(new Equipment("Reliquary"));
            //55-60 Packs
            allGear.Add(new Equipment("Diplomat's Pack")); //55
            allGear.Add(new Equipment("Dungeoneer's Pack")); 
            allGear.Add(new Equipment("Entertainer's Pack"));
            allGear.Add(new Equipment("Explorer's Pack"));
            allGear.Add(new Equipment("Priest's Pack"));
            allGear.Add(new Equipment("Scholar's Pack")); //60
            //61-77 Artisan's Tools
            allGear.Add(new Equipment("Alchemist's supplies")); 
            allGear.Add(new Equipment("Brewer's supplies"));
            allGear.Add(new Equipment("Calligrapher's supplies")); 
            allGear.Add(new Equipment("Carpenter's tools")); 
            allGear.Add(new Equipment("Cartographer's tools")); //65
            allGear.Add(new Equipment("Cobbler's tools")); 
            allGear.Add(new Equipment("Cook's utensils"));
            allGear.Add(new Equipment("Glassblower's tools")); 
            allGear.Add(new Equipment("Jeweler's tools")); 
            allGear.Add(new Equipment("Leatherworker's tools"));  //70
            allGear.Add(new Equipment("Mason's tools")); 
            allGear.Add(new Equipment("Painter's supplies"));
            allGear.Add(new Equipment("Potter's tools")); 
            allGear.Add(new Equipment("Smith's tools")); 
            allGear.Add(new Equipment("Tinker's tools")); //75
            allGear.Add(new Equipment("Weaver's tools")); 
            allGear.Add(new Equipment("Woodcarver's tools"));
            //78-87 Musical instruments
            allGear.Add(new Equipment("Bagpipes"));
            allGear.Add(new Equipment("Drum")); 
            allGear.Add(new Equipment("Dulcimer")); //80
            allGear.Add(new Equipment("Flute")); 
            allGear.Add(new Equipment("Lute"));
            allGear.Add(new Equipment("Lyre"));
            allGear.Add(new Equipment("Horn")); 
            allGear.Add(new Equipment("Pan flute")); //85
            allGear.Add(new Equipment("Shawm")); 
            allGear.Add(new Equipment("Viol")); 
            //other equipment
            allGear.Add(new Equipment("Arrows (x20)"));
            allGear.Add(new Equipment("Crossbow Bolts (x20)")); 
            allGear.Add(new Equipment("Prayer book"));
            allGear.Add(new Equipment("Prayer wheel"));
            allGear.Add(new Equipment("Stoppered bottles filled with colored liquid (x10)")); 
            allGear.Add(new Equipment("Weighted dice")); 
            allGear.Add(new Equipment("Deck of marked cards"));
            allGear.Add(new Equipment("Signet ring of an imaginary duke"));
            allGear.Add(new Equipment("Love letter"));
            allGear.Add(new Equipment("Lock of hair"));
            allGear.Add(new Equipment("Trinket")); 
            allGear.Add(new Equipment("Disguise kit"));
            allGear.Add(new Equipment("Forgery kit"));
            allGear.Add(new Equipment("Bone dice"));
            allGear.Add(new Equipment("Playing card set")); 

        }

        public void popOptions()
        {
            int i;
            List<Gear> option1a = new List<Gear>();
            List<Gear> option2a = new List<Gear>();
            List<Gear> option3a = new List<Gear>();
            List<Gear> option4a = new List<Gear>();
            List<Gear> option1b = new List<Gear>();
            List<Gear> option2b = new List<Gear>();
            List<Gear> option3b = new List<Gear>();

            if (classType == "Barbarian")
            {
                reformat = 1;
                numChoices = 2;
                option2a.Add(allGear[getIndex("Greatax")]);  //Greatax or any martial melee weapon
                for (i = 16; i < 34; i++)
                {
                    if (i != 19)
                        option2a.Add(allGear[i]);
                }
                option1a.Add(new Weapon("Handaxes (x2)", 6, 1)); //Two handaxes or any simple weapon
                for (i = 0; i < 16; i++)
                {
                    if (i != 3)
                    {
                        option1a.Add(allGear[i]);
                    }
                }
            }
            else if (classType == "Bard")
            {
                numChoices = 3;
                option1a.Add(allGear[27]); //Rapier
                option1a.Add(allGear[23]); //Longsword
                for (i = 0; i < 16; i++)
                {
                    option1a.Add(allGear[i]); //Any simple weapon
                }
                //diplomats pack or entertainer's pack
                //lute or musical instrument
            }
            else if (classType == "Cleric")
            {
                reformat = 1;
                numChoices = 4;
                //mace or warhammer (if proficient)
                //scale mail or leather armor or chainmail (if proficient)
                //light crossbow and 20 bolts or any simple weapon
                //priest's pack or explorer's pack

            }
            else if (classType == "Druid")
            {
                numChoices = 2;
                //wood shield or any simple weapon
                //scimitar or any simple melee weapon
                option3a.Add(allGear[28]);
                for(i = 0; i < 11; i++)
                {
                    option3a.Add(allGear[i]);
                }
            }
            else if (classType == "Fighter")
            {
                reformat = 3;
                numChoices = 4;
                //chain mail or (leather and longbow and 20 arrows)
                //martial weapon and shield or two martial weapons
                //light crossbow and 20 bolt or two handaxes
                //dungeoneer's pack or an explorer's pack
                
            }
            else if (classType == "Monk")
            {
                numChoices = 2;
                //shortword or any simple weapon
                option1a.Add(allGear[29]);
                for(i = 0; i < 16; i++)
                {
                    option1a.Add(allGear[i]);
                }
                //dungeoneer's pack or explorer's pack
            }
            else if (classType == "Paladin")
            {
                reformat = 1;
                numChoices = 3;
                //a martial weapon and shield or two martial weapons
                //five javelins or any simple melee weapon
                option2a.Add(new Weapon("Javelins (x5)", 6, 1));
                for (i = 0; i < 11; i++)
                {
                    option2a.Add(allGear[i]);
                }
                //priest's pack or explorer's pack
            }
            else if (classType == "Ranger")
            {
                reformat = 1;
                numChoices = 3;
                //scale mail or leather armor
                //two shortwords or two simple melee weapons
                option1a.Add(new Weapon("Shortswords (x2)", 6, true));

                //dungeoneer's pack or an explorer's paack

            }
            else if (classType == "Rogue")
            {
                reformat = 1;
                numChoices = 3;
                //rapier or shortsword
                option2a.Add(allGear[27]);
                option2a.Add(allGear[29]);
                //short bow and 20 arrows or a shortsword
                //burglar's pack or a dungeoneer's pack or an explorer's pack
            }
            else if (classType == "Sorcerer")
            {
                numChoices = 3;
                reformat = 1;
                //light crossbow and 20 bolts or any simple weapon
                //component pouch or arcane focus
                //dungeoneer's pack or an explorer's pack
            }
            else if (classType == "Warlock")
            {
                reformat = 1;
                numChoices = 3;
                //light crossbow and 20 bolts or any simple weapon
                //component pouch or arcane focus
                //scholar's pack or dungeoneer's pack
            }
            else //Wizard
            {
                numChoices = 3;
                //quarterstaff or dagger
                option1a.Add(allGear[7]);
                option1a.Add(allGear[2]);
                //component pouch or arcane focus
                //scholar's pouch or explorer's pack
            }


            if (backgroundType == "Acolyte")
            {
                numChoices += 1;
                gp = 15;
                //prayer book or prayer wheel
                option1b.Add(allGear[101]);
                option1b.Add(allGear[102]);
            }
            else if (backgroundType == "Charlatan")
            {
                //Ten stoppered bottles filled with colored liquid, a set of weighted dice, a deck of marked cards, or a signet ring of an imaginary duke
                numChoices += 1;
                gp = 15;
                for (i = 105; i < 109; i++)
                {
                    option1b.Add(allGear[i]);
                }
            }
            else if (backgroundType == "Criminal")
            {
                gp = 15;
            }
            else if (backgroundType == "Entertainer")
            {
                numChoices += 2;
                gp = 15;
                for (i = 92; i < 102; i++) //Any musical instrument
                {
                    option1b.Add(allGear[i]);
                }

                for (i = 109; i < 111; i++) //Love letter, lock of hair, or trinket
                {
                    option2b.Add(allGear[i]);

                }

            }
            else if (backgroundType == "Folk Hero")
            {
                gp = 10;
                numChoices += 1;
                for (i = 92; i < 102; i++) //Any musical instrument
                {
                    option1b.Add(allGear[i]);
                }
            }
            else if (backgroundType == "Guild Artisan")
            {
                gp = 15;
                numChoices += 1;
                for (i = 71; i < 88; i++) //Any set of artisans tools
                {
                    option1b.Add(allGear[i]);
                }
            }
            else if (backgroundType == "Hermit")
            {
                gp = 5;
            }
            else if (backgroundType == "Noble")
            {
                gp = 25;
            }
            else if (backgroundType == "Outlander")
            {
                gp = 10;
            }
            else if (backgroundType == "Sage")
            {
                gp = 10;
            }
            else if (backgroundType == "Sailor")
            {
                gp = 10;
            }
            else if (backgroundType == "Soldier")
            {
                gp = 10;
                numChoices += 1;
                //bone dice or deck of cards
            }
            else //Urchin
            {
                gp = 10;
            }

            options.Add(option1a);
            options.Add(option2a);
            options.Add(option3a);
            options.Add(option4a);
            options.Add(option1b);
            options.Add(option2b);
            options.Add(option3b);

        }

        public List<List<Gear>> getOptions()
        {
            return options;
        }

        public List<List<string>> getStrings()
        {
            List<List<string>> choicesString = new List<List<string>>();
            List<Gear> temp = new List<Gear>();
            List<string> temp2 = new List<string>();
            for (int i = 0; i < numChoices; i++)
            {
                temp = options[i];
                
                for (int j = 0; j < temp.Count(); j++)
                {
                    temp2.Add(temp[j].toString());
                }
                choicesString.Add(temp2);

                
            }
            return choicesString;
        }

        public int getNumChoices()
        {
            return numChoices;
        }

        public int getReformat()
        {
            return reformat;
        }

        public int getIndex(string find)
        {
            for(int i = 0; i < allGear.Count(); i++)
            {
                if (allGear[i].getName() == find)
                {
                    return i;
                }
            }
            return -1;
        }
        
        //Character.Profession.ProfessionName()
    }
}
