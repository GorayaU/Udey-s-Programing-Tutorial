using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private float speed;
    [SerializeField, Range(1,20)] private float MouseSensX;
    [SerializeField, Range(1,20)] private float MouseSensY;
    [SerializeField, Range(0, 180)] private float MinViewAngle;
    [SerializeField, Range(0, 180)] private float MaxViewAngle;
    [SerializeField] private Transform LookAtPoint;
    [SerializeField] private Rigidbody BulletPrefab;
    [SerializeField] private float BulletForce;

    private Vector2 CurrentRotation;
    private int Score = 0;
    private Vector3 moveDir;
    void Start()
    {
        InputManager.Init(myPlayer:this);
        InputManager.GameMode();
        txt.text = "Your Score is = 0";
        txt.color = Color.blue;
        txt.fontSize = 15;
    }
    public void AddScore()
    {
        Score++;

        txt.text = $"Your Score is = {Score}";
        
        if (Score > 15)
        {
            txt.fontSize = Score;
        }
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
        Rigidbody CurrentProjectile = Instantiate(BulletPrefab,transform.position, Quaternion.identity); // Spawn the object as a regidbody
        CurrentProjectile.AddForce(LookAtPoint.forward * BulletForce, ForceMode.Impulse); // Add Instant force in the look at direction of the player
        Destroy(CurrentProjectile.gameObject, 4); // Destroy after 4 seconds
    }
}
