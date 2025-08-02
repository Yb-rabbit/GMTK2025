using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WuQi : MonoBehaviour
{
    public GameObject idle, attack;
    public GameObject ShangHaiKuang;
    public GameObject KuangPos;
    public float PingZhang;
    GameObject cat;
    hp hp;
    private void Start()
    {
        cat = GameObject.Find("cat");
        hp=cat.GetComponent<hp>();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            idle.SetActive(false);
            attack.SetActive(true);
            hp.PingZhang = PingZhang;
        }
    }
    public void attStart()//¸øÓèÉËº¦¿ò
    {
        ShangHaiKuang.transform.position = KuangPos.transform.position;
    }
    public void attFinish()//¹¥»÷½áÊø
    {
         ShangHaiKuang.transform.position = new Vector3(9999, 9999, 9999);
        idle.SetActive(true);
        attack.SetActive(false);
        hp.PingZhang = 0;
    }
}
