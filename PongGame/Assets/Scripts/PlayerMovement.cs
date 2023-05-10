using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D box;
    public float direction = 0f; // 1 = up, -1 = down.
    public bool left_Player = true;

    [SerializeField] private float up = 5f;
    [SerializeField] private float down = -5f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        BoxCollider2D box = rb.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(left_Player == true)
        {
            if (Input.GetKey("w"))
            {
                direction = 1f;
                rb.velocity = new Vector2(0, up);
            }
            else if (Input.GetKeyUp("w"))
            {
                direction = 0f;
                rb.velocity = new Vector2(0, 0);
            }

            if (Input.GetKey("s"))
            {
                direction = -1f;
                rb.velocity = new Vector2(0, down);
            }
            else if (Input.GetKeyUp("s"))
            {
                direction = -0f;
                rb.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            if (Input.GetKey("up"))
            {
                direction = 1f;
                rb.velocity = new Vector2(0, up);
            }
            else if (Input.GetKeyUp("up"))
            {
                direction = 0f;
                rb.velocity = new Vector2(0, 0);
            }

            if (Input.GetKey("down"))
            {
                direction = -1f;
                rb.velocity = new Vector2(0, down);
            }
            else if (Input.GetKeyUp("down"))
            {
                direction = -0f;
                rb.velocity = new Vector2(0, 0);
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Walls"))
        {
            Debug.Log("Wall hit ;)");
        }
        
    }
}
