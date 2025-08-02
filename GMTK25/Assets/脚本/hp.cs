using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hp : MonoBehaviour
{
    public float HP = 5;
    bool wudi = false;
    public float wudiTim = 0.5f;
    float time;
    public camShark camshark;
    public Animator anim,anim1;
    public float PingZhang;
    float ShenYu;
    // Start is called before the first frame update
    void Start()
    {
        time = wudiTim;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PingZhang);
        if(transform.position.y<-20)
            SceneManager.LoadScene(3);
        if (HP < 0)
        {
            anim.SetBool("die", true);
            anim1.SetBool("die", true);
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
            ShenYu = PingZhang - shanghai;
            PingZhang = ShenYu;
            if (PingZhang < 0)
                PingZhang = 0;
            if(ShenYu<0)
            {
                HP += ShenYu;
                wudi = true;
                time = wudiTim;
                anim.Play("hurt");
                anim1.Play("hurt");
                gameObject.tag = "Untagged";
            }
            
        }
    }
}
