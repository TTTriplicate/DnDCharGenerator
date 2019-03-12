﻿using System;

public class DnDCharacter
{
    /*most of this will probably get set in a parameterized constructor
     * not sure yet how best to implement that.
     All part of the project later on*/
    protected int Level;
    //get and set
    protected int[] Abilities = new int[6] { 8 };
    //STR, DEX, CON, INT, WIS, CHA, in that order for all int[6]
    //get and set(RNG and point buy system in user interface)
    //default to all 8s for point buy start
    protected Profession CharClass;
    //get and set(Profession library, Chris)
    protected CharRace Race;
    //get and set(Race library, Dylan)
    protected Background background;
    //get and set(Background libraries, Jack)
    protected List<Items> Inventory;
    //add and remove methods? (Item library, Catherine)
    //equiped vs. carried?
    protected List<string> SkillList;
    //bool[]?
    //add methods from class and background, some user interaction to pick from list
    //skills on list get proficiency bonus
    protected bool[] SavingThrows = new bool[6];
    //mark which saves get proficiency bonus, get from CharClass
	public DnDCharacter()
	{
        /*will need a parameterized constructor
         * may call parameterized component constructors inside?
         * this might be a bit of a mess later on*/
	}
    public int ProficiencyBonus()
    {//passes the proficiency bonus to main function
        return 2 + (Level / 5);
    }
    public int[] AbilityModifiers(int[] Abilities)
    {//pass ability modifiers to main so they can be accessed there
        int[] modifiers = new int[6];
        for(int i = 0; i < 6; ++i)
        {
            if (Abilities[i] >= 10) modifiers[i] = (Abilities[i] - 10) / 2;
            else if (Abilities[i] < 10) modifiers[i] = Math.Min(((10 - Abilities) / -2), -1);
        }
        return modifiers;
    }
}
