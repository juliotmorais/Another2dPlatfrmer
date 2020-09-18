using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D myRigidBody2D;
    public float jumpForce;
    public bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;
    public bool canDoubleJump; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody2D.velocity = new Vector2(moveSpeed*Input.GetAxis("Horizontal"), myRigidBody2D.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,.2f,whatIsGround);

        if (isGrounded)
        {
            canDoubleJump = true;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                //canDoubleJump = true;
                myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, jumpForce);
            }
            else
            {
                if (canDoubleJump)
                {
                    myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
    }
}
