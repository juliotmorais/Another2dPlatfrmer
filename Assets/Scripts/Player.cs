using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody2D myRigidBody2D;
    [SerializeField] float jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] bool canDoubleJump;
    private Animator anim;
    private SpriteRenderer mySpriteRenderer;
    public float knockBackLength;
    public float knockBackForce;
    private float knockBackCounter;
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (knockBackCounter <= 0)
        {
            //movement
            myRigidBody2D.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), myRigidBody2D.velocity.y);

            //grounded and jumping
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
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

            //flipping sprite around
            if (myRigidBody2D.velocity.x < 0)
            {
                mySpriteRenderer.flipX = true;
            }
            else if (myRigidBody2D.velocity.x > 0)
            {
                mySpriteRenderer.flipX = false;
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
            if (!mySpriteRenderer.flipX)
            {
                myRigidBody2D.velocity = new Vector2(-knockBackForce,myRigidBody2D.velocity.y);
            }
            else
            {
                myRigidBody2D.velocity = new Vector2(knockBackForce, myRigidBody2D.velocity.y);
            }
        }


       
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("moveSpeed", Mathf.Abs(myRigidBody2D.velocity.x));

        
    }
    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        myRigidBody2D.velocity = new Vector2(0f,knockBackForce);
    }
}
