using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxtime;
    Animator animator;
    float jumptime ;
    bool onground;
    int stay;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumptime = 0;
        onground = false;
        stay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((rb.velocity.x==0.0f)&&(rb.velocity.y==0.0f))
        {
            onground = true;
        }
        jump();
    }
    void jump()
    {
        if(onground)
        {
          
            if (Input.GetButton("Jump"))
            {
                if (jumptime < maxtime)
                {
                    jumptime += Time.deltaTime * 10.0f;
                }
                else
                {
                    rb.velocity = new Vector2(direction, jumptime);
                    jumptime = 0;
                    direction = 0;
                    onground = false;
                    animator.SetBool("jump", true);
                }
                float tmp = Input.GetAxisRaw("Horizontal");
                if (tmp != 0)
                {
                    direction = tmp > 0 ? 5 : -5;
                }
            }
            else if(jumptime>0)
            {        
                rb.velocity = new Vector2(direction, jumptime);
                jumptime = 0;
                direction = 0;
                onground = false;
                animator.SetBool("jump", true);
            }
            else
            {
                rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            }
        }
        
        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Debug.Log(collision.contacts[0].normal);
            Debug.Log(collision.relativeVelocity);
            if (collision.contacts[0].normal.y>0.9)
            {
                onground = true;
                animator.SetBool("jump", false);
                Debug.Log("onground");
            }
            else if (collision.contacts[0].normal.y <-0.9)
            {
                rb.velocity = new Vector2(-1*collision.relativeVelocity.x, collision.relativeVelocity.y );
                Debug.Log("underground");
            }
            else
            {
                rb.velocity = new Vector2(collision.relativeVelocity.x *0.5f, collision.relativeVelocity.y*-1);
                Debug.Log("else");
            }


        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].normal.y > 0.8)
        {
            onground = true;

            
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
           
            if(onground)
            {
                
                    Debug.Log(collision.relativeVelocity);
                    onground = false;

                    Debug.Log("notonground");
                
                
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("gold"))
        {
            gamemanager.getcoin();
            Destroy(collision.gameObject);
            Debug.Log("success");
        }
    }
}
