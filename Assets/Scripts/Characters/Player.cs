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

    private int Score = 0;
    private Vector3 moveDir;
    void Start()
    {
        InputManager.Init(myPlayer:this);
        InputManager.GameMode();
        txt.text = "Your Score is = 0";
    }
    public void AddScore()
    {
        Score++;

        txt.text = "Your Score is = "+Score.ToString();
    }

    void Update()
    {
        transform.position += speed * Time.deltaTime * moveDir;

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
    }
    public void SetMovementDirection(Vector3 newDirection)
    {
        moveDir = newDirection;
    }
}
