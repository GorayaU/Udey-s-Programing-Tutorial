using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagTracker : MonoBehaviour
{
    [SerializeField] Text Magtxt;

    private int Holding;
    private int Increase;
    private int Inclip;
    private int InclipMax = 30;
    private bool Canfire;

    private void Start()
    {
        Inclip = 30;
        Holding = 120;
        Canfire = true;
    }
    private void Update()
    {
        Magtxt.text = $"{Inclip}/{Holding}";
        IncreaseMag();
        Debug.Log(Holding);
    }
    public void Reload()
    {
        if (Holding > 0 && Inclip != InclipMax)
        {
            while (Inclip != InclipMax)
            {
                Inclip++;
                Holding--;
            }
        }
    }
    public void RemoveBullet()
    {
        Inclip--;
    }
    public void GrabAmmo()
    {
        Increase = 30;
        Holding = 30;
    }
    private void IncreaseMag()
    {
        if (Increase >= 30)
        {
            Holding++;
            Increase--;
        }
    }
    public bool CanShoot()
    {
        if (Inclip >= 1)
        {
            Canfire = true;
        }
        else if (Inclip < 1)
        {
            Canfire = false;
        }
        return Canfire;
    }
}
