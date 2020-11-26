﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rigidbody;
    [SerializeField] private int moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal")* moveSpeed , Input.GetAxis("Vertical") * moveSpeed) ;
        


    }    
}
