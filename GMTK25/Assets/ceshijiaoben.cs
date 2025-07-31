using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceshijiaoben : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity=new Vector3(-4,rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(4, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyDown(KeyCode.K))
            rb.velocity = new Vector3(rb.velocity.x,6, rb.velocity.z);
        if (Input.GetKey(KeyCode.S))
        { 
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -4);
            Debug.Log("1");
        }
        if (Input.GetKey(KeyCode.W))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 4);
        if (Input.GetKeyUp(KeyCode.S)|| Input.GetKeyUp(KeyCode.W))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
    }
}
