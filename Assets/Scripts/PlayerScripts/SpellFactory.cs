using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class SpellFactory //: MonoBehaviour
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

    public static Spell GetSpell(Spell oldSpell, Orb orb)
    {
        switch (oldSpell.GetType().ToString())
        {
            case "NullSpell":
                switch (orb.orbType)
                {
                    case OrbType.Projectile:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        return new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                    case OrbType.Spray:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        return new SpraySpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                    case OrbType.Laser:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        return new LaserSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            case "ProjectileSpell":
                switch (orb.orbType)
                {
                    case OrbType.Projectile:
                        oldSpell.PrimaryOrbs.Add(orb); //should orb list of spell be readonly?
                        return new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                    case OrbType.Spray:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        return new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                    case OrbType.Laser:
                        oldSpell.SecondaryOrbs.Add(orb); //should orb list of spell be readonly?
                        return new ProjectileSpell(oldSpell.PrimaryOrbs, oldSpell.SecondaryOrbs);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
        }
    }
}
