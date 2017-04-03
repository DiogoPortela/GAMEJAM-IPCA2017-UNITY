using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float Speed;
    public float JumpingForce;
    public enum player { One, Two };
    public player Player;
    public bool isFalling;
    public bool isJumping;
    public bool isKid;
    public BoxCollider2D thisCollider;
    public BoxCollider2D floorCollider;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private Vector2 DeltaSpeed;

    private Vector2 adultSize, kidSize;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        DeltaSpeed = Vector2.zero;
        if(rigidBody.velocity == Vector2.zero)
        {
            animator.SetInteger("MovingDirection", 0);
        }
        if (rigidBody.velocity.y < 0)
        {
            isJumping = false;
            isFalling = true;
            animator.SetBool("isFalling", true);
            animator.SetBool("isJumping", false);
        }

        if (Player == player.One)
        {
            if (Input.GetAxis("HorizontalP1") != 0 && rigidBody.velocity.magnitude < 500)
            {
                DeltaSpeed += new Vector2(Input.GetAxis("HorizontalP1") * Speed * Time.deltaTime, 0);
                animator.SetInteger("MovingDirection", (int)DeltaSpeed.normalized.x);
            }
            if (Input.GetKey(KeyCode.UpArrow) && !isFalling && !isJumping)
            {
                DeltaSpeed += new Vector2(0, JumpingForce);
                isJumping = true;
                animator.SetBool("isJumping", true);
            }
            if(Input.GetKeyDown(KeyCode.Keypad0))
            {
                isKid = !isKid;
                animator.SetBool("isKid", isKid);

            }
        }   //PLAYER ONE
        else
        {
            if (Input.GetAxis("HorizontalP2") != 0 && rigidBody.velocity.magnitude < 500)
            {
                DeltaSpeed += new Vector2(Input.GetAxis("HorizontalP2") * Speed * Time.deltaTime, 0);
                animator.SetInteger("MovingDirection", (int)DeltaSpeed.normalized.x);
            }
            if (Input.GetKey(KeyCode.UpArrow) && !isFalling && !isJumping)
            {
                DeltaSpeed += new Vector2(0, JumpingForce);
                isJumping = true;
                animator.SetBool("isJumping", true);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                isKid = !isKid;
                animator.SetBool("isKid", isKid);

            }
        }                        //PLAYER TWO
        rigidBody.AddForce(DeltaSpeed, ForceMode2D.Impulse);

    }
    //TESTS IF THERE IS SOMETHING BELLOW THE PLAYER
    private void OnTriggerStay2D(Collider2D collision)
    {
        isFalling = false;
        animator.SetBool("isFalling", false);
    }
}
