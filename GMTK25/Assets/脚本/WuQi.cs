using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WuQi : MonoBehaviour
{
    public int i;//��ʾ���������
    Animator anim;
    public GameObject buffet;//�ӵ�
    Vector3 target;//�ӵ������Ŀ��
    public GameObject FaSheDian;//�ӵ������
    public float startRoate, finishRoate,normalRoate;//����������ʼ��תֵ
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
