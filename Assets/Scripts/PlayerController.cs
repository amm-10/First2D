using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
enum State
{
    Idle,
    Move,
    Attack

}

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private float playerSpeed = 8f;
    private float jumpForce = 500f;
    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isMoving = false;
    private GameObject sword;
    private State curState = State.Idle;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sword = transform.Find("Sword").gameObject; // 오브젝트 찾아오기. 성능이 좋을까..?
    }

    void Update()
    {
        // ---------------------
        //         �̵�
        // ---------------------

        isMoving = false;  

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector2(-1, 0) * playerSpeed * Time.deltaTime);
            isMoving = true;
            transform.localScale = new Vector2(-1, 1);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector2(1, 0) * playerSpeed * Time.deltaTime);
            isMoving = true;
            transform.localScale = new Vector3(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < 2)
        {
            jumpCount++;

            playerRigidbody.velocity = Vector2.zero;

            playerRigidbody.AddForce(new Vector2(0, jumpForce));
        }
        else if (Input.GetKeyUp(KeyCode.W) && playerRigidbody.velocity.y > 0)
        {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Run", curState == State.Move);


        //---------------------
        //        공격
        //---------------------

        // 여기 어째야하지
        if(Input.GetKeyDown(KeyCode.Space))
        {
            sword.GetComponent<SwordAttack>().Attack();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}