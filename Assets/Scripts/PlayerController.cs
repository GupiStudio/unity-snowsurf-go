using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _torqueAmount = 1f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float boostHp = 10f;

    bool canMove = true;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        surfaceEffector2D.speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
    
    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {

            if (boostHp >= 0)
            {
                surfaceEffector2D.speed = boostSpeed;
                boostHp -= 1 * Time.deltaTime;

                Debug.Log("Boost HP: " + boostHp);
            }
        }
        else
            surfaceEffector2D.speed = baseSpeed;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            rb2d.AddTorque(_torqueAmount);
        else if (Input.GetKey(KeyCode.RightArrow))
            rb2d.AddTorque(-_torqueAmount);
    }
}
