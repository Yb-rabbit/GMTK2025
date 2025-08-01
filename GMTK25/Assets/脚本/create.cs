using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    public float speed = 4;
    public Transform target;
    public Transform Left, Right, Up, Down,LeftUp,LeftDown,RightUp,RightDown;
    Vector3 direction;
    Vector3 targetPos;
    public Canvas canvas;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.D)|| Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = new Vector3(0, 0, 0);
            anim.SetBool("move", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("move", true);
            /* if(Input.GetKey (KeyCode.S))
                direction=(LeftDown.position-transform.position).normalized;
             else if(Input.GetKey (KeyCode.W))
                  direction=(LeftUp.position-transform.position).normalized;
              else*/
            direction = (Left.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
       
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("move", true);
            /*if (Input.GetKey(KeyCode.S))
               direction = (RightDown.position - transform.position).normalized;
            else if (Input.GetKey(KeyCode.W))
                direction = (RightUp.position - transform.position).normalized;
             else*/
            direction = (Right.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        
       if (Input.GetKey(KeyCode.S)&&!Input.GetKey(KeyCode.A)&&!Input.GetKey (KeyCode.D))
        {
            anim.SetBool("move", true);
            direction = (Down.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            anim.SetBool("move", true);
            direction = (Up.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
        /* //±³°ü¹¦ÄÜ
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            canvas.enabled=!canvas.enabled;
        }*/
       
    }
}
