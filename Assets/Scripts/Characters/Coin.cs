using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectible
{
    protected override bool CheckCollect(Collider col)
    {
        bool x = col.CompareTag("Bullet");
        if (!x) return false;
        GM.AddScore();
        Destroy(col.gameObject);

        return true;
    }

}
