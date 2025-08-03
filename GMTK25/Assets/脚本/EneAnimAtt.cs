using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneAnimAtt : MonoBehaviour
{
    eneAtt att;
    public GameObject father;
    bool only = true;
    float time = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        att=father.GetComponent<eneAtt>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!only)
        {
            time-=Time.deltaTime;
            if (time < 0)
                only = true;
        }
    }
    public void Att()
    {
        if (only)
        {
            time = 0.7f;
            only = false;
            att.Attack();
        }
       
    }
    public void die()
    {
        Destroy(father.gameObject);
    }
}
