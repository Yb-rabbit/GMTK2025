using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -speed);
            Debug.Log("1");
        }
        if (Input.GetKey(KeyCode.W))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
    }
}
