using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBin : Collectible
{
    protected override bool CheckCollect(Collider col)
    {
        bool x = col.CompareTag("Player"); // Checks if it was hit by a player
        if (!x) return false; // No if it was not a player
        GM.GainAmmo(); // Adds extra ammo
        return true; //returns a true if it was hit by a player
    }
}
