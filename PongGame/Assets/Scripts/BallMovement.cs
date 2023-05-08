using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D rb_Ball;

    [SerializeField] private float right = 4f;
    [SerializeField] private float left = -4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            rb_Ball.velocity = new Vector2(left, 0);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            Debug.Log("ball hit ;)");
        }
        
    }
}
