using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool GOexists = true;
    private GameObject coin;

    private void Start()
    {
        coin = gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GOexists = false;
            if (GOexists == false)
            {
                float Random_x = Random.Range(-3,3);
                float Random_z = Random.Range(-3, 3);
                Instantiate(coin, new Vector3(Random_x, 0, Random_z), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
