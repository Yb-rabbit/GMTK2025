using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WuQi : MonoBehaviour
{
    public int i;//表示武器的类别
    Animator anim;
    public GameObject buffet;//子弹
    Vector3 target;//子弹打向的目标
    public GameObject FaSheDian;//子弹发射点
    public float startRoate, finishRoate,normalRoate;//武器攻击初始旋转值
    float z;
    bool attackk;
    public GameObject ShangHaiKuang;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (Input.GetMouseButtonDown(0)&&!attackk)
        {         
            z = startRoate;
            attackk = true;
            //ShangHaiKuang.SetActive(true);
        }
        if(!attackk)
        {
            if(z>finishRoate)
            {
                z-=30*Time.deltaTime;
            }
            else
            {
                z = normalRoate;
                attackk = false;
              //  ShangHaiKuang.SetActive(false);
            }
        }
    }
    void attack()
    {
       
    }
}
