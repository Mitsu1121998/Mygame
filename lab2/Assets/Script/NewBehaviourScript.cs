using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float playerSpeed = 1;
    public float playerJump = 1;
    private float hDir;
    private float vDir;
    private Rigidbody2D rb;
    private bool jump = false;
    private bool ground = false;
    public Animator animator;
    float someScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        someScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed",Mathf.Abs(hDir));
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && ground)
        {
            jump = true;
            animator.SetBool("jump", true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hDir * playerSpeed, rb.velocity.y);
        if (hDir == 1)
        {
            transform.localScale = new Vector2(someScale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-someScale, transform.localScale.y);
        } 
        
        
        if (jump)
        {
            rb.AddForce(Vector2.up * playerJump, ForceMode2D.Impulse);
            jump = false;
            ground = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "ground")
        {
            ground = true;
            animator.SetBool("jump", false);
        }
    }

}

