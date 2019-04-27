using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DnDClassesTest
{
    public class CharGear
    {
        public List<Gear> allGear = new List<Gear>(); //list of possible choices of gear
        public string classType; //What type of class/profession the character is
        public string backgroundType; //What type of background
        public int numChoices = 0; //how many different times the user will have to choose something, aka the number of combo boxes needed)
        public int gp; //how much gold, determined by background
        public List<List<Gear>> options = new List<List<Gear>>(); //A list containing lists of choices
        public int dexMod;
        public bool reformat = false;
        public List<Gear> inventory = new List<Gear>(); //List of inventory after choices are made
        public List<string> inventoryString = new List<string>(); //parallel list of inventory stored as strings
        public List<Gear> firstChoice = new List<Gear>();
        public int AC;

        //Index values used to more easily populate lists of choices
        public const int startSimpleMelee = 0;
        public const int startSimpleRanged = 11;
        public const int startMartialMelee = 15;
        public const int startMartialRanged = 33;
        public const int startArmor = 38;
        public const int startDruidicFocus = 43;
        public const int startArcaneFocus = 47;
        public const int startHolySymbol = 52;
        public const int startPacks = 55;
        public const int startArtisans = 61;
        public const int startInstruments = 78;
        public const int startFormat = 88;
        public const int endFormat = 91;

        public CharGear()
        {
        }

        public CharGear(string classType, string backgroundType, int dexMod)
        {
            this.classType = classType;
            this.backgroundType = backgroundType;
            this.dexMod = dexMod;
            populateGear();
            popOptions();

            GearForm f = new GearForm(this);
            //f.Show();

            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                //return f;
            }
        }

        /**
         * Mutator method to populate a List<Gear> with all possible choices of gear
         * All gear is hardcoded in, even though this is a horrible horrible idea
         */
        public void populateGear()
        {
            //0-10 Simple Melee Weapons
            allGear.Add(new Weapon("Club", 4, "melee", 1));
            allGear.Add(new Weapon("Dagger", 4, "melee", true));
            allGear.Add(new Weapon("Greatclub", 8, "melee", false, true));
            allGear.Add(new Weapon("Handaxe", 6, "melee", 1));
            allGear.Add(new Weapon("Javelin", 6, "ranged thrown", 1));
            allGear.Add(new Weapon("Light hammer", 4, "melee", 1)); //5
            allGear.Add(new Weapon("Mace", 6, "melee", 1));
            allGear.Add(new Weapon("Quarterstaff", 6, "melee", false, false, true));
            allGear.Add(new Weapon("Sickle", 4, "melee", 1));
            allGear.Add(new Weapon("Spear", 6, "ranged thrown", false, false, true));
            allGear.Add(new Weapon("Unarmed strike", 1, "melee", 1)); //10
            //11-14 Simple Ranged Weapons
            allGear.Add(new Weapon("Crossbow, light", 8, "ranged fired", false, true, false, true));
            allGear.Add(new Weapon("Dart", 4, "ranged thrown", true));
            allGear.Add(new Weapon("Shortbow", 6, "ranged fired", false, true));
            allGear.Add(new Weapon("Sling", 4, "ranged fired", 1));
            //15-32 Martial Melee Weapons
            allGear.Add(new Weapon("Battleax", 8, "melee", false, false, true)); //15
            allGear.Add(new Weapon("Flail", 8, "melee", 1));
            allGear.Add(new Weapon("Glaive", 10, "melee", false, true, false, false, true));
            allGear.Add(new Weapon("Greatax", 12, "melee", false, true, false, false, true));
            allGear.Add(new Weapon("Greatsword", 6, "melee", 2));
            allGear.Add(new Weapon("Halberd", 10, "melee", false, true, false, false, true)); //20
            allGear.Add(new Weapon("Lance", 12, "melee", false, false, false, false, true));
            allGear.Add(new Weapon("Longsword", 8, "melee", false, false, true));
            allGear.Add(new Weapon("Maul", 6, "melee", false, true, false, false, true, false, 2));
            allGear.Add(new Weapon("Morningstar", 8, "melee", 1));
            allGear.Add(new Weapon("Pike", 10, "melee", false, true, false, false, true));//25
            allGear.Add(new Weapon("Rapier", 8, "melee", true));
            allGear.Add(new Weapon("Scimitar", 6, "melee", true));
            allGear.Add(new Weapon("Shortsword", 6, "melee", true));
            allGear.Add(new Weapon("Trident", 6, "ranged thrown", false, false, true));
            allGear.Add(new Weapon("War pick", 8, "melee", 1)); //30
            allGear.Add(new Weapon("Warhammer", 8, "melee", false, false, true));
            allGear.Add(new Weapon("Whip", 4, "melee", true));
            //33-37 Martial Ranged Weapons
            allGear.Add(new Weapon("Blowgun", 1, "ranged fired", false, false, false, true));
            allGear.Add(new Weapon("Crossbow, hand", 6, "ranged fired", false, false, false, true));
            allGear.Add(new Weapon("Crossbow, heavy", 10, "ranged fired", false, true, false, true, true)); //35
            allGear.Add(new Weapon("Longbow", 8, "ranged fired", false, true, false, false, true));
            allGear.Add(new Weapon("Net", 0, "ranged thrown", false, false, false, false, false, true));
            //38-42 Armor
            allGear.Add(new Armor("Leather armor", 11, dexMod));
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
            //88-90 Formatting
            allGear.Add(new Weapon("Light Crossbow and 20 bolts", 8, "ranged fired", false, true, false, true));
            allGear.Add(new Weapon("Shortbow and 20 arrows", 6, "ranged fired", false, true));
            allGear.Add(new Equipment("Leather armor, longbow, and 20 arrows")); //90
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

        /**
         * Mutator method to pupulate List<List<Gear>> options based on the class and background as well as the default gear for each
         */
        public void popOptions()
        {
            int i;

            if (classType == "Barbarian")
            {
                inventory.Add(new Equipment("Explorer's Pack"));
                inventory.Add(new Weapon("Javelines (x4)", 6, "ranged thrown", 1));
                numChoices = 2;
                this.options.Add(new List<Gear>());
                firstChoice.Add(new Weapon("Handaxes (x2)", 6, "melee", 1));
                for (i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    if (i != getIndex("Handaxe"))
                    {
                        options[0].Add(allGear[i]);
                    }
                }

                this.options.Add(new List<Gear>());
                firstChoice.Add(allGear[getIndex("Greatax")]);
                for (i = startMartialMelee; i < startMartialRanged; i++)
                {
                    if (i != getIndex("Greatax"))
                        options[1].Add(allGear[i]);
                }
            }
            else if (classType == "Bard")
            {
                inventory.Add(allGear[getIndex("Leather armor")]);
                inventory.Add(allGear[getIndex("Dagger")]);

                numChoices = 3;
                this.options.Add(new List<Gear>());
                firstChoice.Add(null);
                options[0].Add(allGear[getIndex("Rapier")]); //Rapier
                options[0].Add(allGear[getIndex("Longsword")]); //Longsword
                for (i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    options[0].Add(allGear[i]); //Any simple weapon
                }

                this.options.Add(new List<Gear>());
                firstChoice.Add(null);
                options[1].Add(allGear[getIndex("Diplomat's Pack")]);//diplomats pack or entertainer's pack
                options[1].Add(allGear[getIndex("Entertainer's Pack")]);

                this.options.Add(new List<Gear>());
                firstChoice.Add(allGear[getIndex("Lute")]); //lute or musical instrument
                for (i = startInstruments; i < startFormat; i++)
                {
                    if (i != getIndex("Lute"))
                    {
                        options[2].Add(allGear[i]);
                    }
                }
            }
            else if (classType == "Cleric") //FIX_ME: get proficiencies from character class
            {
                inventory.Add(allGear[getIndex("Shield")]);
                numChoices = 4;
                this.options.Add(new List<Gear>()); //scale mail or leather armor or chainmail (if proficient)
                firstChoice.Add(null);
                
                //Cleric.Proficiencies(n);
                //bool[] proficiencies = Cleric.Proficiencies(leeroy._class._proPath);
                //Profession cleric =
                //if (DnDCharacter.getProPath() == 3 || DnDCharacter._class._proPath == 4 || DnDCharacter._class._proPath == 6)
                //{
                //    options[0].Add(allGear[getIndex("Chain mail")]);
                //}
                options[0].Add(allGear[getIndex("Scale mail")]);
                options[0].Add(allGear[getIndex("Leather armor")]);

                this.options.Add(new List<Gear>()); //mace or warhammer (if proficient)
                firstChoice.Add(null);
                options[1].Add(allGear[getIndex("Mace")]);
                //if (DnDCharacter._proPath == 4 || DnDCharacter._proPath == 6)
                //{
                //    options[1].Add(allGear[getIndex("Warhammer")]);
                //}

                this.options.Add(new List<Gear>()); //light crossbow and 20 bolts or any simple weapon
                firstChoice.Add(allGear[getIndex("Light Crossbow and 20 bolts")]);
                for (i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    options[2].Add(allGear[i]);
                }

                this.options.Add(new List<Gear>()); //priest's pack or explorer's pack
                firstChoice.Add(null);
                options[3].Add(new Equipment("Priest's Pack"));
                options[3].Add(new Equipment("Explorer's Pack"));

            }
            else if (classType == "Druid")
            {
                inventory.Add(allGear[getIndex("Leather armor")]);
                inventory.Add(allGear[getIndex("Explorer's Pack")]);

                numChoices = 3;
                this.options.Add(new List<Gear>());
                firstChoice.Add(allGear[getIndex("Shield")]); //wood shield or any simple weapon
                for (i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    options[0].Add(allGear[i]);
                }

                this.options.Add(new List<Gear>());
                firstChoice.Add(allGear[getIndex("Scimitar")]);//scimitar or any simple melee weapon
                for (i = startSimpleMelee; i < startSimpleRanged; i++)
                {
                    options[1].Add(allGear[i]);
                }

                this.options.Add(new List<Gear>()); //Druidic Focus
                firstChoice.Add(null);
                for (i = startDruidicFocus; i < startArcaneFocus; i++)
                {
                    options[2].Add(allGear[i]);
                }
            }
            else if (classType == "Fighter") 
            {
                reformat = true;
                numChoices = 4;

                this.options.Add(new List<Gear>()); //martial weapon and shield or two martial weapons
                firstChoice.Add(null);
                for(i = startMartialMelee; i < startArmor; i++)
                {
                    options[0].Add(allGear[i]);
                }

                this.options.Add(new List<Gear>()); //chain mail or (leather and longbow and 20 arrows)
                firstChoice.Add(null);
                options[1].Add(allGear[getIndex("Chain mail")]);
                options[1].Add(allGear[getIndex("Leather armor, longbow, and 20 arrows")]);

                this.options.Add(new List<Gear>()); //light crossbow and 20 bolt or two handaxes
                firstChoice.Add(null);
                options[2].Add(allGear[getIndex("Light Crossbow and 20 bolts")]);
                options[2].Add(new Weapon("Handaxes (x2)", 6, "melee", 1));

                this.options.Add(new List<Gear>()); //dungeoneer's pack or an explorer's pack
                firstChoice.Add(null);
                options[3].Add(allGear[getIndex("Dungeoneer's Pack")]);
                options[3].Add(allGear[getIndex("Explorer's Pack")]);

            }
            else if (classType == "Monk")
            {
                inventory.Add(new Weapon("Darts (x5)", 4, "thrown ranged", true));
                numChoices = 2;
                //shortword or any simple weapon
                this.options.Add(new List<Gear>());
                firstChoice.Add(allGear[getIndex("Shortsword")]);
                for (i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    options[0].Add(allGear[i]);
                }

                this.options.Add(new List<Gear>()); //dungeoneer's pack or an explorer's pack
                firstChoice.Add(null);
                options[1].Add(new Equipment("Dungeoneer's Pack"));
                options[1].Add(new Equipment("Explorer's Pack"));
            }
            else if (classType == "Paladin") 
            {
                inventory.Add(allGear[getIndex("Chain mail")]);
                numChoices = 3;
                this.options.Add(new List<Gear>()); //martial weapon and shield or two martial weapons
                firstChoice.Add(null);
                for (i = startMartialMelee; i < startArmor; i++)
                {
                    options[0].Add(allGear[i]);
                }
                this.options.Add(new List<Gear>());//five javelins or any simple melee weapon
                firstChoice.Add(new Weapon("Javelins (x5)", 6, "ranged thrown", 1));
                for (i = 0; i < 11; i++)
                {
                    options[1].Add(allGear[i]);
                }
                this.options.Add(new List<Gear>());//priest's pack or explorer's pack
                firstChoice.Add(null);
                options[2].Add(allGear[getIndex("Priest's Pack")]);
                options[2].Add(allGear[getIndex("Explorer's Pack")]);
            }
            else if (classType == "Ranger")
            {
                inventory.Add(allGear[getIndex("Longbow")]);
                inventory.Add(new Equipment("Arrows (x20"));
                numChoices = 3;
                reformat = true;
                this.options.Add(new List<Gear>());//two shortwords or two simple melee weapons
                firstChoice.Add(new Weapon("Shortswords (x2)", 6, "melee", true));
                for (i = startSimpleMelee; i < startSimpleRanged; i++)
                {
                    options[0].Add(allGear[i]);
                }
                this.options.Add(new List<Gear>());//scale mail or leather armor
                firstChoice.Add(null);
                options[1].Add(allGear[getIndex("Scale mail")]);
                options[1].Add(allGear[getIndex("Leather armor")]);

                this.options.Add(new List<Gear>()); //dungeoneer's pack or an explorer's pack
                firstChoice.Add(null);
                options[2].Add(allGear[getIndex("Dungeoneer's Pack")]);
                options[2].Add(allGear[getIndex("Explorer's Pack")]);

            }
            else if (classType == "Rogue")
            {
                inventory.Add(allGear[getIndex("Leather armor")]);
                inventory.Add(new Weapon("Daggers (x2)", 4, "melee", true));
                inventory.Add(new Equipment("Thieves' Tools"));
                numChoices = 3;
                this.options.Add(new List<Gear>());//rapier or shortsword
                firstChoice.Add(null);
                options[0].Add(allGear[getIndex("Rapier")]);
                options[0].Add(allGear[getIndex("Shortsword")]);
                this.options.Add(new List<Gear>());//short bow and 20 arrows or a shortsword
                firstChoice.Add(null);
                options[1].Add(allGear[getIndex("Shortbow")]);
                options[1].Add(allGear[getIndex("Shortsword")]);
                this.options.Add(new List<Gear>());//burglar's pack or a dungeoneer's pack or an explorer's pack
                firstChoice.Add(null);
                options[2].Add(new Equipment("Burglar's Pack"));
                options[2].Add(allGear[getIndex("Dungeoneer's Pack")]);
                options[2].Add(allGear[getIndex("Explorer's Pack")]);

            }
            else if (classType == "Sorcerer")
            {
                inventory.Add(new Weapon("Daggers (x2)", 4, "melee", true));
                numChoices = 3;
                this.options.Add(new List<Gear>());//light crossbow and 20 bolts or any simple weapon
                firstChoice.Add(new Equipment("Light Crossbow and 20 bolts"));
                for(i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    if (i != getIndex("Crossbow, light"))
                    {
                        options[0].Add(allGear[i]);
                    }
                }

                this.options.Add(new List<Gear>());//component pouch or arcane focus
                firstChoice.Add(new Equipment("Component Pouch"));
                for(i = startArcaneFocus; i < startHolySymbol; i++)
                {
                    options[1].Add(allGear[i]);
                }

                this.options.Add(new List<Gear>());//dungeoneer's pack or an explorer's pack
                firstChoice.Add(null);
                options[2].Add(allGear[getIndex("Dungeoneer's Pack")]);
                options[2].Add(allGear[getIndex("Explorer's Pack")]);
            }
            else if (classType == "Warlock")
            {
                inventory.Add(allGear[getIndex("Leather armor")]);
                inventory.Add(new Weapon("Daggers (x2)", 4, "melee", true));
                numChoices = 3;
                this.options.Add(new List<Gear>());//light crossbow and 20 bolts or any simple weapon
                firstChoice.Add(allGear[getIndex("Light Crossbow and 20 bolts")]);
                for (i = startSimpleMelee; i < startMartialMelee; i++)
                {
                    if (i != getIndex("Crossbow, light"))
                    {
                        options[0].Add(allGear[i]);
                    }
                }
                this.options.Add(new List<Gear>());//component pouch or arcane focus
                firstChoice.Add(new Equipment("Component Pouch"));
                for (i = startArcaneFocus; i < startHolySymbol; i++)
                {
                    options[1].Add(allGear[i]);
                }
                this.options.Add(new List<Gear>());//scholar's pack or dungeoneer's pack
                firstChoice.Add(null);
                options[2].Add(allGear[getIndex("Dungeoneer's Pack")]);
                options[2].Add(allGear[getIndex("Scholar's Pack")]);
            }
            else //Wizard
            {
                inventory.Add(new Equipment("Spell book"));
                numChoices = 3;
                this.options.Add(new List<Gear>());//quarterstaff or dagger
                firstChoice.Add(null);
                options[0].Add(allGear[getIndex("Quarterstaff")]);
                options[0].Add(allGear[getIndex("Dagger")]);
                this.options.Add(new List<Gear>());//component pouch or arcane focus
                firstChoice.Add(new Equipment("Component Pouch"));
                for (i = startArcaneFocus; i < startHolySymbol; i++)
                {
                    options[1].Add(allGear[i]);
                }
                this.options.Add(new List<Gear>()); //scholar's pouch or explorer's pack
                firstChoice.Add(null);
                options[2].Add(allGear[getIndex("Explorer's Pack")]);
                options[2].Add(allGear[getIndex("Scholar's Pack")]);
            }


            if (backgroundType == "Acolyte")
            {
                inventory.Add(new Equipment("Sticks of incense (x5)"));
                inventory.Add(new Equipment("Venstments"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 15;
                this.options.Add(new List<Gear>()); //prayer book or prayer wheel
                firstChoice.Add(null);
                options[numChoices].Add(new Equipment("Prayer book"));
                options[numChoices].Add(new Equipment("Prayer wheel"));
                numChoices++;
            }
            else if (backgroundType == "Charlatan")
            {
                inventory.Add(new Equipment("Clothes, fine"));
                inventory.Add(new Equipment("Disguise kit"));
                inventory.Add(new Equipment("Belt pouch"));
                this.options.Add(new List<Gear>());
                firstChoice.Add(null);
                for (i = startHolySymbol; i < startPacks; i++)//a holy symbol
                {
                    options[numChoices].Add(allGear[i]);
                }
                numChoices++;
                this.options.Add(new List<Gear>());//Ten stoppered bottles filled with colored liquid, a set of weighted dice, a deck of marked cards, or a signet ring of an imaginary duke
                firstChoice.Add(null);
                options[numChoices].Add(new Equipment("Ten stoppered bottles filled with colored liquid"));
                options[numChoices].Add(new Equipment("Set of weighted dice"));
                options[numChoices].Add(new Equipment("Deck of marked cards"));
                options[numChoices++].Add(new Equipment("Signet ring of an imaginary duke"));
                gp = 15;
            }
            else if (backgroundType == "Criminal")
            {
                inventory.Add(new Equipment("Crowbar"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Hood"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 15;
            }
            else if (backgroundType == "Entertainer")
            {
                inventory.Add(new Equipment("Costume"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 15;
                this.options.Add(new List<Gear>());
                firstChoice.Add(null);
                for (i = startInstruments; i < startFormat; i++) //Any musical instrument
                {
                    options[numChoices].Add(allGear[i]);
                }
                numChoices++;
                this.options.Add(new List<Gear>());//Love letter, lock of hair, or trinket
                firstChoice.Add(null);
                options[numChoices].Add(new Equipment("Love letter"));
                options[numChoices].Add(new Equipment("Lock of hair"));
                options[numChoices++].Add(new Equipment("Tricket"));
            }
            else if (backgroundType == "Folk Hero")
            {
                gp = 10;
                inventory.Add(new Equipment("Shovel"));
                inventory.Add(new Equipment("Iron pot"));
                inventory.Add(new Equipment("Common clothes"));
                inventory.Add(new Equipment("Belt pouch"));
                this.options.Add(new List<Gear>());
                firstChoice.Add(null);
                for (i = startInstruments; i < startFormat; i++) //Any musical instrument
                {
                    options[numChoices].Add(allGear[i]);
                }
                numChoices++;

                this.options.Add(new List<Gear>()); //Artistans tools
                firstChoice.Add(null);
                for (i = startArtisans; i < startInstruments; i++)
                {
                    options[numChoices].Add(allGear[i]);
                }
                numChoices++;
            }
            else if (backgroundType == "Guild Artisan")
            {
                inventory.Add(new Equipment("Letter of introduction from your guild"));
                inventory.Add(new Equipment("Clothes, traveler's"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 15;
                this.options.Add(new List<Gear>());
                firstChoice.Add(null);
                for (i = startArtisans; i < startInstruments; i++) //Any set of artisans tools
                {
                    options[numChoices].Add(allGear[i]);
                }
                numChoices++;
            }
            else if (backgroundType == "Hermit")
            {
                inventory.Add(new Equipment("A scroll case with notes from your studies or prayers"));
                inventory.Add(new Equipment("A winter blanket"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Herbalism kit"));
                gp = 5;
            }
            else if (backgroundType == "Noble")
            {
                inventory.Add(new Equipment("Clothes, fine"));
                inventory.Add(new Equipment("Signet ring"));
                inventory.Add(new Equipment("Scroll of predigree"));
                inventory.Add(new Equipment("Purse"));
                gp = 25;
            }
            else if (backgroundType == "Outlander")
            {
                inventory.Add(new Equipment("Staff"));
                inventory.Add(new Equipment("Hunting trap"));
                inventory.Add(new Equipment("Trophy from an animal you killed"));
                inventory.Add(new Equipment("Set of traveler's clothes"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 10;
            }
            else if (backgroundType == "Sage")
            {
                inventory.Add(new Equipment("Bottle of black ink"));
                inventory.Add(new Equipment("Quill"));
                inventory.Add(new Equipment("Small knife"));
                inventory.Add(new Equipment("A letter from a dead colleague posing a question you have not yet been able to answer"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 10;
            }
            else if (backgroundType == "Sailor")
            {
                inventory.Add(new Equipment("Belaying pin"));
                inventory.Add(new Equipment("Silk rope (50ft)"));
                inventory.Add(new Equipment("A lucky charm"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Belt pouch"));

                gp = 10;
            }
            else if (backgroundType == "Soldier")
            {
                inventory.Add(new Equipment("Insignia of rank"));
                inventory.Add(new Equipment("Trophy taken from a fallen enemy"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 10;

                this.options.Add(new List<Gear>()); //bone dice or deck of cards
                firstChoice.Add(null);
                options[numChoices].Add(new Equipment("Bone dice"));
                options[numChoices].Add(new Equipment("Deck of cards"));
                numChoices++;
            }
            else //Urchin
            {
                inventory.Add(new Equipment("Small knife"));
                inventory.Add(new Equipment("Map of the city you grew up in"));
                inventory.Add(new Equipment("Pet mouse"));
                inventory.Add(new Equipment("Token to remember your parents by"));
                inventory.Add(new Equipment("Clothes, common"));
                inventory.Add(new Equipment("Belt pouch"));
                gp = 10;
            }
        }
        /**
         * Getter method
         * @return options the List of options of gear
         */
        public List<List<Gear>> getOptions()
        {
            return options;
        }

        /**
         * Getter method to convert options into a List<List<string>>
         * @return choiceString, a string representation of options
         */
        public List<List<string>> getStrings()
        {
            List<List<string>> choicesString = new List<List<string>>();
            for (int i = 0; i < options.Count(); i++)
            {
                choicesString.Add(new List<string>());
                for (int j = 0; j < options[i].Count(); j++)
                {
                    choicesString[i].Add(options[i][j].toString());
                }
            }
            return choicesString;
        }

        /**
         * Getter method
         * @return the number of choices generated by the combinationg of class and background
         */
        public int getNumChoices()
        {
            return numChoices;
        }

        /**
         * Getter method
         * @return reformat the number of times an option needs to be reformatting
         */
        public bool getReformat()
        {
            return reformat;
        }

        /**
         * Getter method
         * @param find a string to be searched for in allGear
         * @return the index of find
         */
        public int getIndex(string find)
        {
            for (int i = 0; i < allGear.Count(); i++)
            {
                if (allGear[i].getName() == find)
                {
                    return i;
                }
            }
            return -1;
        }

        /**
         * Mutator method to reformat weird combo inventory items into their component parts
         * @param references end and endString, parallel lists containing the inventory post-choosing
         */
        public void formatting(ref List<Gear> end, ref List<string> endStrings)
        {
            int count = end.Count();
            for (int i = 0; i < count; i++)
            {
                for (int j = startFormat; j < endFormat; j++)
                {
                    if (end[i] == allGear[j])
                    {
                        if (j == startFormat)
                        {
                            end.Remove(allGear[j]);
                            endStrings.Remove(allGear[j].toString());
                            end.Add(allGear[getIndex("Crossbow, light")]);
                            end.Add(allGear[getIndex("Crossbow Bolts (x20)")]);
                            endStrings.Add(end[end.Count() - 2].toString());
                            endStrings.Add(end[end.Count() - 1].toString());
                        }

                        if (j == startFormat + 1)
                        {
                            end.Remove(allGear[j]);
                            endStrings.Remove(allGear[j].toString());
                            end.Add(allGear[getIndex("Shortbow")]);
                            end.Add(allGear[getIndex("Arrows (x20)")]);
                            endStrings.Add(end[end.Count() - 2].toString());
                            endStrings.Add(end[end.Count() - 1].toString());
                        }

                        if (j == startFormat + 2)
                        {
                            end.Remove(allGear[j]);
                            endStrings.Remove(allGear[j].toString());
                            end.Add(allGear[getIndex("Leather armor")]);
                            end.Add(allGear[getIndex("Longbow")]);
                            end.Add(allGear[getIndex("Arrows (x20)")]);
                            endStrings.Add(end[end.Count() - 3].toString());
                            endStrings.Add(end[end.Count() - 2].toString());
                            endStrings.Add(end[end.Count() - 1].toString());
                        }
                    }
                }
            }
        }

        /**
         * Getter method 
         * @return inventory the List<Gear> of inventory post-choosing
         */
        public List<Gear> getInventory()
        {
            return inventory;
        }

        /**
         * Setter method to set inventory
         * @param inventory the updated inventory
         */
        public void setInventory(List<Gear> inventory)
        {
            this.inventory = inventory;
        }

        /**
         * Setter method to set parallel List<string> inventoryString
         * @param inventoryString the updated inventoryString
         */
        public void setInventoryString(List<string> inventoryString)
        {
            this.inventoryString = inventoryString;
        }

        /**
         * Getter method to convert inventory into inventoryString
         * @return inventoryString the string representation of inventory
         */
        public List<string> convertInventoryString()
        {
            for (int i = 0; i < inventory.Count(); i++)
            {
                inventoryString.Add(inventory[i].toString());
            }
            return inventoryString;
        }

        public List<string> getInventoryString()
        {
            return inventoryString;
        }

        /**
         * Getter method
         * @return the current object
         */
        public CharGear getCharGear()
        {
            return this;
        }

        public List<Gear> getFirstChoice()
        {
            return firstChoice;
        }

        public int getGP()
        {
            return gp;
        }

        public int getAC()
        {
            for(int i = 0; i < inventory.Count; i++)
            {
                AC += inventory[i].calcAC();
            }
            if(AC == 0)
            {
                AC += 10;
            }
            return AC;
        }
    }
}
