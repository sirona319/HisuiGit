using System;
using UnityEngine;

public class PlayerDmg : BaseDmg
{
    public bool DBGNODMG = false;
    public void SetDebugDMG(bool value)
    {
        DBGNODMG = value;
    }

    public override void Damage(int damage)
    {
        if (DBGNODMG) return;
        base.Damage(damage);
    }
}
