using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;

    public float moveSpeed = 1f;
    public float jumpHight = 3f;
    public float maxVelocity = 10f;

    [Header("KeyCode Inputs")]
    public KeyCode right;
    public KeyCode left;
    public KeyCode up;

    public Transform groundCheckGo;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerMove();
        GroundCheck();
    }
    private void PlayerMove()
    {
        //Moves player right, swaps facing direction
        if (Input.GetKey(right))
        {
            playerRb.velocity = new Vector2(moveSpeed, playerRb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        //Moves player left, swaps facing direction
        else if (Input.GetKey(left)) 
        {
            playerRb.velocity = new Vector2(-moveSpeed, playerRb.velocity.y);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else //Keeps momentum downwards
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        //Jump function
        if (Input.GetKey(up) && GroundCheck())
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpHight);
        }
    }
    private bool GroundCheck()
    {
        if(Physics2D.Linecast(transform.position, groundCheckGo.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
