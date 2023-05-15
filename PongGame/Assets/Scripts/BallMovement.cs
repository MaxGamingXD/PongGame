using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public Rigidbody2D rb_Ball;
    public BallMovement bounce;

    Vector2 original_Pos;


    [SerializeField] private float right = 5f;
    [SerializeField] private float left = -5f;
    [SerializeField] private float timer = 2f;
    private float original_Timer;
    
    //Floats for straight influenced hits//
    /* private float straight_right = 7;
    private float straight_left = -7; */

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb_Ball = GetComponent<Rigidbody2D>();
        BallMovement bounce = GetComponent<BallMovement>();

        original_Pos = rb_Ball.position;
        original_Timer = timer;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Space))
        {
            rb_Ball.velocity = new Vector2(left, 0);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            PlayerMovement pm = col.gameObject.GetComponent<PlayerMovement>();
            if(pm.left_Player == true)
            {
                if(pm.direction == 1) // UP Right
                {
                    rb_Ball.velocity = new Vector2(right, right);
                }
                else if (pm.direction == -1) // Down Right
                {
                    rb_Ball.velocity = new Vector2(right, left);
                }
                /*else // Right
                {
                    rb_Ball.AddForce(transform.forward * straight_right);
                }*/
                
            }
            else
            {
                if (pm.direction == 1) // UP Left
                {
                    rb_Ball.velocity = new Vector2(left, right);
                }
                else if (pm.direction == -1) // Down Left
                {
                    rb_Ball.velocity = new Vector2(left, left);
                }
                /*else // Left
                {
                    rb_Ball.AddForce(transform.forward * straight_left);
                }*/
            }
           
            Debug.Log("ball hit ;)");
        }
        else if (col.gameObject.CompareTag("Point_Walls"))
        {
            // Stops ball movement when touched the left and right side walls, resets position, and sends the ball to the 
            LeftandRightScore pm = col.gameObject.GetComponent<LeftandRightScore>();
            if(pm.Is_Left == true)
            {
                gameObject.transform.position = original_Pos;
                rb_Ball.velocity = Vector2.zero;
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    rb_Ball.isKinematic = false;
                    rb_Ball.velocity = new Vector2(right, 0);
                    timer = original_Timer;
                    Debug.Log("Point Left");
                }
            }
            else
            {
                gameObject.transform.position = original_Pos;
                rb_Ball.velocity = Vector2.zero;
                timer -= Time.deltaTime;
                if (timer < 0)
                {
                    rb_Ball.isKinematic = false;
                    rb_Ball.velocity = new Vector2(left, 0);
                    timer = original_Timer;
                    Debug.Log("Point Right");
                }
            }

        }

    }
    
    
}
