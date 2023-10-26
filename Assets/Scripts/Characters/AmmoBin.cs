using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBin : Collectible
{
    protected override bool CheckCollect(Collider col)
    {
        bool x = col.CompareTag("Player");
        if (!x) return false;
        Debug.Log("picking up");
        GM.GainAmmo();
        Debug.Log("picked up");
        return true;
    }
}
