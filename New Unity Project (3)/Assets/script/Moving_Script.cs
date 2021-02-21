using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Script : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundPoint;
    public LayerMask whatisGround;
    private bool CandoubleJump;
    private Animator anim;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed*Input.GetAxis("Horizontal"), rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, whatisGround);
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                CandoubleJump = true;
            }
            else
            {
                if (CandoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    CandoubleJump = false;
                }
            }
            
        }
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        if (rb.velocity.x < 0.01)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0.01)
        {
            sr.flipX = false;
        }
    }
}
