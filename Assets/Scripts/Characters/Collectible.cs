using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] private Player GM;
    [SerializeField] private MagTracker Mag;
    [SerializeField] private GameObject MagPrefab;
    [SerializeField] private Rigidbody CoinPrefab;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && this.CompareTag("coin"))
        {

            GM.AddScore();
            // Destroy the collectible
            Destroy(gameObject);
            // Spawn a new collectible at a random position
            SpawnNewCoin();
            IncreaseSize(transform);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && gameObject.CompareTag("AmmoBox"))
        {
            SpawnNewAmmo();
            Mag.GrabAmmo();
            Destroy(gameObject);
        }
    }
    private void SpawnNewCoin()
    {
        float Random_x = Random.Range(-5, 5);
        float Random_z = Random.Range(-5, 5);
        Vector3 newPosition = new Vector3(Random_x, 0, Random_z);
        Instantiate(CoinPrefab, newPosition, Quaternion.identity);
    }
    private void SpawnNewAmmo()
    {
        float Random_x = Random.Range(-5, 5);
        float Random_z = Random.Range(-5, 5);
        Vector3 newPosition = new Vector3(Random_x, 0, Random_z);
        Instantiate(MagPrefab, newPosition, Quaternion.identity); // Spawn the object as a regidbody
    }

    private static void IncreaseSize(Component component)
    {
        component.transform.localScale += new Vector3(1, 1, 1);
    }
}
