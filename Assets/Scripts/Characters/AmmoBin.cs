using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBin : Collectible
{
    protected override bool CheckCollect(Collider col)
    {
        bool x = col.CompareTag("Player");
        if (!x) return false;
        GM.GainAmmo(30);
        return true;
    }
}
