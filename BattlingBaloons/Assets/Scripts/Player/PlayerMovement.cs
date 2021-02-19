using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    CharacterController2D controller;

    Player player;

    [SerializeField] float rotateSpeed;
    [SerializeField] float movementSpeed;
    float horizontalMove;
    float rotationChange;

    bool jump = false;

    private void Start()
    {
        controller = GetComponent<CharacterController2D>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        if(gameObject.CompareTag("Player 1"))
        {
            horizontalMove = Input.GetAxis("Player 1 Horizontal") * movementSpeed;
            rotationChange = Input.GetAxis("Player 1 Rotation") * rotateSpeed;

            if (Input.GetButtonDown("Player 1 Vertical"))
            {
                jump = true;
            }
        }else if (gameObject.CompareTag("Player 2"))
        {
            horizontalMove = Input.GetAxis("Player 2 Horizontal") * movementSpeed;
            rotationChange = Input.GetAxis("Player 2 Rotation") * rotateSpeed;

            if (Input.GetButtonDown("Player 2 Vertical"))
            {
                jump = true;
            }
        }
        
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.deltaTime, false, jump);
        if(player)
            controller.Rotate(rotationChange * Time.deltaTime, player.Gun.transform);

        jump = false;
    }
}
