using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagTracker : MonoBehaviour
{
    [SerializeField] Text Magtxt; // UI for the ammo

    public int Holding; // Extra ammo
    public int Inclip; // Ammo in magazine

    private void Start()
    {
        Inclip = 30; // Sets ammo in magazine to 30
        Holding = 120; // Sets extra ammo to 120
    }
    private void Update()
    {
        Magtxt.text = $"{Inclip}/{Holding}"; // Updates ammo UI
    }

    public void RemoveBullet() // Removes a bullet from magazine when called
    {
        Inclip--; // Lowers the bullets in the magazine by 1
    }
    public bool CanShoot() // Checks if there is enough bullets in the magazine to shoot
    {
        if (Inclip >= 1) // Checks if the magazine has 1 or more bullets
        {
            return true; // Allows you to fire
        }
        else 
        {
            return false; // Stops you from firing
        }
    }
}
