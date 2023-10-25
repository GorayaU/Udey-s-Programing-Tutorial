using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    internal void Switch()
    {
        if (gameObject.name == "VCam1")
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }


}
