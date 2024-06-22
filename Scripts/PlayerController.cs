using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;

    [SerializeField] float torqueValue = 1.0f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    bool isMoving = true;
   
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        
        if (isMoving)
        {  
            RotatePlayer();
            RespondToBoost();
        }
        
    }

    public void DisableControls()
    {
         isMoving = false;
    }

    private void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            surfaceEffector2D.speed = boostSpeed;
            Debug.Log(surfaceEffector2D.speed);
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
            Debug.Log(surfaceEffector2D.speed);
            
        }
    }

    private void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueValue);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueValue);
        }
    }

    

}
