using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // config parameters
    [SerializeField] public float movementSpeed = 5;
    [SerializeField] private Animator animator;
    private int speed = 1;

    // cached variables
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter;
    bool isMovingLeft = false;
    bool isMovingRight = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moveLimiter = 0.7f;
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", horizontal);
        if(horizontal > 0 || horizontal < 0)
        {
            animator.SetFloat("Speed", speed);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

    }

    private void FixedUpdate()
    {   
        if(horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        body.velocity = new Vector2(horizontal * movementSpeed, vertical * movementSpeed);
    }
}
