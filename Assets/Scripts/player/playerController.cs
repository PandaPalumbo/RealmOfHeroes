using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController: MonoBehaviour
{
    public int id;
    public bool canIMove;
    public bool inCombat;
    private Vector3 pos;
    private int OOCSpeed;

    public Rigidbody2D rigidbody2D;
    public Animator animator;
    Vector2 movment;
    
    public void Start()
    {
        OOCSpeed = 5;
        canIMove = false;
    }

    private void Update()
    {
        OutOfCombatMovementAnimation();
    }

    private void FixedUpdate()
    {
        OutOfCombatMovement();   
    }

    private void OutOfCombatMovementAnimation()
    {
        if (!inCombat)
        {
            movment.x = Input.GetAxisRaw("Horizontal");
            movment.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movment.x);
            animator.SetFloat("Vertical", movment.y);
            animator.SetFloat("Speed", movment.sqrMagnitude);
        }
    }

    private void OutOfCombatMovement()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + movment * OOCSpeed * Time.fixedDeltaTime);
    }
}
