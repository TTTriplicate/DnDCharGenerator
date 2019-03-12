using System;

public abstract class Profession
{
    //need here too for determining what players do or do not have from class
    protected int level;
    public int _level
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
        }
    }
    
    protected bool Caster;
    public bool _caster
    {
        get
        {
            return Caster;
        }
        set
        {
            Caster = value;
        }
    }
    protected  int HitDie;
    public int _hitDie
    {
        get
        {
            return HitDie;
        }
        set
        {
            HitDie = value;
        }
    }
    protected int ProPath;
    public int _proPath
    {
        get
        {
            return ProPath;
        }
        set
        {
            ProPath = value;
        }
    }
    public virtual bool[] ClassSkills;
    protected int NumProSkills;
    public int _numProSkills
    {
        get
        {
            return NumProSkills;
        }
        set
        {
            NumProSkills = value;
        }
    }

    public Profession()
	{

	}

    public Porfession(int level)
    {
        this._level = level;
        /*this._caster = cast;
        this._hitDie = die;
        need to be virtuals*/
    }

    protected virtual bool[] Unlocked()
    {
        //implemented in derived classes
    }



    public int ChoosePath(bool pathSwitch)//will have a bool to catch which path in interface
    {                                     //2 paths per class, so just needs bool not int
        return pathSwitch;
    }
    public virtual bool[] SavingThrows()
    {
        //derived classes have seperate instantiations
    }
    public void LevelUp()
    {
        ++this._level;

    }



    public virtual bool[] ClassFeatures
    {
        //derived classes have instantiations
        //seperate for leveling?
    }
    /* 
 *Belong in overall character class. 
*public int ProBonus()
 {
     return 2 + (level / 5);
 }

 public int AbilitiesBoost()
 {
     return 2 * (level / 5);
 }*/

}
