using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public abstract class Spell
{
    public List<Orb> PrimaryOrbs; //should be made readonly?
    public List<Orb> SecondaryOrbs; //should be made readonly?
    private Vector3 _spawnPoint;

    public Spell()
    {
        
    }
    
    public Spell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs)
    {
        PrimaryOrbs = primaryOrbs;
        SecondaryOrbs = secondaryOrbs;
    }

    public abstract void Cast();
}

public class NullSpell : Spell
{
    public NullSpell()
    {
        
    }

    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}

public class ProjectileSpell : Spell
{
    public ProjectileSpell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs) : base(primaryOrbs, secondaryOrbs)
    {
        
    }

    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}

public class SpraySpell : Spell
{
    public SpraySpell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs) : base(primaryOrbs, secondaryOrbs)
    {
        
    }
    
    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}

public class LaserSpell : Spell
{
    public LaserSpell(List<Orb> primaryOrbs, List<Orb> secondaryOrbs) : base(primaryOrbs, secondaryOrbs)
    {
        
    }
    
    public override void Cast()
    {
        throw new System.NotImplementedException();
    }
}