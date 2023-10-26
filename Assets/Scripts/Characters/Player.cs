using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;
using UnityEngine.UI;
using static Cinemachine.CinemachineOrbitalTransposer;

public class Player : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private float speed;
    [SerializeField, Range(1,35)] private float MouseSensX;
    [SerializeField, Range(1,35)] private float MouseSensY;
    [SerializeField, Range(0, 180)] private float MinViewAngle;
    [SerializeField, Range(0, 180)] private float MaxViewAngle;
    [SerializeField] private Transform LookAtPoint;
    [SerializeField] private Rigidbody BulletPrefab;
    [SerializeField] private float BulletForce;

    private Vector2 CurrentRotation;
    private int Score = 0;
    private Vector3 moveDir;

    [Header("Mag")]
    [SerializeField] MagTracker mag;

    void Start()
    {
        InputManager.Init(myPlayer: this);
        InputManager.GameMode();

        txt.text = "Your Score is = 0";
        txt.color = Color.blue;
        txt.fontSize = 25;
    }
    void Update()
    {
        transform.position += transform.rotation * (speed * Time.deltaTime * moveDir);
        /*
        if (Input.GetMouseButtonDown(0)) // left mouse button detect
        {
            transform.localScale += new Vector3(1, 1, 1);
        }
        else if (Input.GetMouseButtonDown(1)) // right mouse button detect
        {
            transform.localScale -= new Vector3(1, 1, 1);
        }
        else if (Input.GetMouseButtonDown(2)) // middle mouse button detect
        {
            transform.localScale = new(1, 1, 1);
        }
        */

    }
    public void AddScore()
    {
        Score++;

        txt.text = $"Your Score is = {Score}";
        
        if (Score > 25)
        {
            txt.fontSize = Score;
        }
    }
    public void SetMovementDirection(Vector3 newDirection)
    {
        moveDir = newDirection;
    }
    internal void SetLookDirection(Vector2 readValue)
    {
        CurrentRotation.x += readValue.x * Time.deltaTime * MouseSensX;
        CurrentRotation.y += readValue.y * Time.deltaTime * MouseSensY;

        transform.rotation = Quaternion.AngleAxis(CurrentRotation.x, Vector3.up);

        CurrentRotation.y = Mathf.Clamp(CurrentRotation.y, MinViewAngle, MaxViewAngle);

        LookAtPoint.localRotation = Quaternion.AngleAxis(CurrentRotation.y, Vector3.right);

    }
    internal void Shoot()
    {
        if (mag.CanShoot()) // Checks if there is enough ammo to shoot in the magazine in a true or false
        {
            Rigidbody CurrentProjectile = Instantiate(BulletPrefab, transform.position, Quaternion.identity); // Spawn the object as a regidbody
            CurrentProjectile.AddForce(LookAtPoint.forward * BulletForce, ForceMode.Impulse); // Add Instant force in the look at direction of the player
            Destroy(CurrentProjectile.gameObject, 2); // Destroy after 2 seconds
            mag.RemoveBullet(); // Removes a bullet from magazine
        }
    }
    public void Reload() // Reloads when "R" is pressed
    {
        if (mag.Holding > 0 && mag.Inclip != 30) // Checks if current magazine if full and if there is more than 0 extra bullets
        {
            int removed = 30 - mag.Inclip; // Calculates how many bullets are need to fill magazine
            if (mag.Holding >= 30) // Checks if you have a fulls mags worth of extra ammo
            {
                mag.Inclip = 30; // Refills magazine
                mag.Holding -= removed; // Reduces used ammo from extra ammo
            }
            else // If you have less then a full magazine
            {
                mag.Inclip = mag.Holding; // Fill magazine with all available ammo
                mag.Holding = 0; // Show that there is no extra ammo
            }
        }
    }
    public void GainAmmo() // Gets extra ammo
    {
        mag.Holding += 30; // Adds 30 extra ammo
    }
}
