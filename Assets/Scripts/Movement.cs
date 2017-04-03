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
    public BoxCollider2D floorCollider;

    private Rigidbody2D rigidBody;
    private float initDrag;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        initDrag = rigidBody.drag;
    }

    // Update is called once per frame
    void Update()
    {
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
                this.rigidBody.AddForce(new Vector3(Input.GetAxis("HorizontalP1") * Speed * Time.deltaTime, 0, 0));
                //this.rigidBody.position += new Vector2(Input.GetAxis("HorizontalP1") * Speed * Time.deltaTime, 0);
                int aux = 0;
                if (Input.GetAxis("HorizontalP1") > 0)
                    aux = 1;
                else if (Input.GetAxis("HorizontalP1") < 0)
                    aux = -1;
                animator.SetInteger("MovingDirection", aux);
            }
            if (Input.GetKey(KeyCode.UpArrow) && !isFalling && !isJumping)
            {
                this.rigidBody.AddForce(new Vector3(0, JumpingForce, 0));
                isJumping = true;
                animator.SetBool("isJumping", true);
            }
        }
        else
        {
            if (Input.GetAxis("HorizontalP2") != 0 && rigidBody.velocity.magnitude < 500)
            {
                this.rigidBody.AddForce(new Vector3(Input.GetAxis("HorizontalP2") * Speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.W) && !isFalling && !isJumping)
            {
                this.rigidBody.AddForce(new Vector3(0, JumpingForce, 0));
                isJumping = true;
                animator.SetBool("isJumping", true);
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isFalling = false;
        animator.SetBool("isFalling", false);
    }
}
