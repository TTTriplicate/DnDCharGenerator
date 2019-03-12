using System;

public class Bard : Profession
{
    public override bool[] SavingThrows()
    {
        return new bool[6] { 0, 1, 0, 0, 0, 1 };
    }
    protected override bool[] ClassFeatures;
    public override bool[] _classFeatures
    {
        set
        {
            this.ClassFeatures = value;
        }
        get
        {
            return this.ClassFeatures;
        }

    }
    public override bool[] ClassSkills = new bool[18] { true };

    public Bard(int level) : base(level)
    {
        this._hitDie = 8;
        this._caster = true;
        this._numProSkills = 3;
        this.ClassFeatures = this.Unlocked();
    }

    protected override bool[] Unlocked()
    {
        bool[] unlocked = new bool[8] { false };
        unlocked[0] = true;
        if (this._level >= 2) unlocked[1] = true;
        if (this._level >= 3) unlocked[2] = true;
        if (this._level >= 5) unlocked[3] = true;
        if (this._level >= 6) unlocked[4] = true;
        if (this._level >= 10) unlocked[5] = true;
        if (this._level >= 14) unlocked[6] = true;
        if (this._level = 20) unlocked[7] = true;
        return unlocked;
    }

    /*need to fill with all the crunch
     * stats and description for class features
     * IOT read against ClassFeatures bool[]
     [0] = inspiration
     [1] = song of rest, jack of all trades
     [2] = expertise, class path feature 1
     [3] = font of inspiration
     [4] = countercharm, class path 2
     [5] = magical secrets
     [6] = class path 3
     [7] = superior inspiration
     most of this is just write to character sheet
     write from files at given indexes?*/
}