using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagTracker : MonoBehaviour
{
    [SerializeField] Text Magtxt;

    public int Holding;
    public int Inclip;

    private void Start()
    {
        Inclip = 30;
        Holding = 120;
    }
    private void Update()
    {
        Magtxt.text = $"{Inclip}/{Holding}";
    }

    public void RemoveBullet()
    {
        Inclip--;
    }
    public bool CanShoot()
    {
        if (Inclip >= 1)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
