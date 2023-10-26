using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    protected override bool CheckCollect(Collider col)
    {
        bool x = col.CompareTag("Bullet"); // Checks if it was hit with a bullet
        if (!x) return false; // No if it was not a bullets
        GM.AddScore(); // Increases the Score if it was a bullets
        Destroy(col.gameObject); //Destroys the bullet

        return true; // Sends back a true if it was hit with a bullet
    }

}
