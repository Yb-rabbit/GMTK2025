using System;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yumihoshi.Managers;

public class hp : MonoBehaviour
{
    [SerializeField] private float _hp = 100f;
    public BindableProperty<float> HP = new();
    bool wudi = false;
    public float wudiTim = 0.5f;
    float time;
    public camShark camshark;
    public Animator anim,anim1;
    public float PingZhang;
    float ShenYu;

    private void Awake()
    {
        HP.Value = _hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = wudiTim;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PingZhang);
        if (transform.position.y < -20)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            // ���¼��ص�ǰ����
            SceneManager.LoadScene(currentScene.name);
        }
        if (HP.Value < 0)
        {
            anim.SetBool("die", true);
            anim1.SetBool("die", true);
        }
        else
        {
            if(Input.GetMouseButtonDown(1))
            {
               // InventoryManager.Instance.SendCommand
            }
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
    public void GetAtted(float shanghai)//�ܵ��˺�
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
                HP.Value += ShenYu;
                wudi = true;
                time = wudiTim;
                anim.Play("hurt");
                anim1.Play("hurt");
                gameObject.tag = "Untagged";
            }
            
        }
    }
}
