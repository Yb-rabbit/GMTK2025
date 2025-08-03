using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneAnimAtt : MonoBehaviour
{
    eneAtt att;
    public GameObject father;
    bool only = true;
    // Start is called before the first frame update
    void Start()
    {
        att=father.GetComponent<eneAtt>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Att()
    {
        if (only)
        {
            only = false;
            att.Attack();
        }
       
    }
    public void die()
    {
        Destroy(father.gameObject);
    }
}
