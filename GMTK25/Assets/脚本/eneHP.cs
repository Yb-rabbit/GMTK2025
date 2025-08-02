using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneHP : MonoBehaviour
{
    public float hp;
    public Animator anim1, anim2;
    camShark camshark;
    // Start is called before the first frame update
    void Start()
    {
        camshark=GameObject.Find("camera").GetComponent<camShark>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            anim1.SetBool("die", true);
            anim2.SetBool("die", true);
        }
    }
   public  void hurt(float shanghai)
    {
        camshark.StartZhen();
        hp -= shanghai;
    }
}
