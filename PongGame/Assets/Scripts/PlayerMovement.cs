using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField] private float up = 4f;
    [SerializeField] private float down = -4f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            rb.velocity = new Vector2(0, up);
        }
        else if (Input.GetKeyUp("w"))
        {
            rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetKey("s"))
        {
            rb.velocity = new Vector2(0, down);
        }
        else if (Input.GetKeyUp("s"))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}
