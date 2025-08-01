using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    public float HP = 5;
    bool wudi = false;
    public float wudiTim = 0.5f;
    float time;
    public camShark camshark;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        time = wudiTim;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP < 0)
        {
            anim.SetBool("die", true);
        }
        if (wudi)
        {
            time-=Time.deltaTime;
            if(time < 0)
            {
                time = wudiTim;
                wudi = false;
                gameObject.tag = "Player";
            }
        }
    }
    public void GetAtted(float shanghai)//ÊÜµ½ÉËº¦
    {
        if (gameObject.tag =="Player")
        {
            camshark.StartZhen();
            HP -= shanghai;
            wudi = true;
            time = wudiTim;
            anim.Play("hurt");
            gameObject.tag = "Untagged";
        }
    }
}
