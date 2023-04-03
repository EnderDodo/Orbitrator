using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SpellFactory //reminder: that class is not effective
{
    public static Spell GetSpell()
    {
        return new NullSpell();
    }

    /*public static Spell GetSpell(NullSpell oldSpell, ProjectileOrb newOrb)
    {
        oldSpell.orbs.Add(newOrb);
        return new ProjectileSpell(oldSpell.orbs);
    }*/

    /*public static Spell GetSpell(NullSpell oldSpell, SprayOrb newOrb)
    {
        oldSpell.orbs.Add(newOrb);
        return new SpraySpell(oldSpell.orbs);
    }
    
    public static Spell GetSpell(SpraySpell oldSpell, SprayOrb newOrb)
    {
        oldSpell.orbs.Add(newOrb);
        return new SpraySpell(oldSpell.orbs);
    }
    
    public static Spell GetSpell(SpraySpell oldSpell, ProjectileOrb newOrb)
    {
        oldSpell.orbs.Add(newOrb);
        return new ProjectileSpell(oldSpell.orbs);
    }
    
    public static Spell GetSpell(ProjectileSpell oldSpell, SprayOrb newOrb)
    {
        oldSpell.orbs.Add(newOrb);
        return new ProjectileSpell(oldSpell.orbs);
    }
    
    public static Spell GetSpell(ProjectileSpell oldSpell, ProjectileOrb newOrb)
    {
        oldSpell.orbs.Add(newOrb);
        return new ProjectileSpell(oldSpell.orbs);
    }*/

    //public static Spell GetSpell(List<Orb> orbsToCast)
    //{
        
        
        /*switch (oldSpell) //what if it will be useful.....
        {
            case NullSpell:
                switch (orb)
                {
                    case ProjectileOrb:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case SprayOrb:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new SpraySpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);                        break;
                        break;
                    case LaserOrb:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = LaserSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);                        break;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case ProjectileSpell:
                switch (orb)
                {
                    case ProjectileOrb:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case SprayOrb:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case LaserOrb:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case SpraySpell:
                switch (orb)
                {
                    case ProjectileOrb:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case SprayOrb:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new SpraySpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case LaserOrb:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new LaserSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case LaserSpell:
                switch (orb)
                {
                    case ProjectileOrb:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case SprayOrb:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new LaserSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    case LaserOrb:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        var spell = new LaserSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                return spell;
        }*/
    //}
}