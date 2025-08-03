using System;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Models.Inventory;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class hp : MonoBehaviour
{
    [SerializeField] private float _hp = 100f;
    public BindableProperty<float> HP = new();

    bool wudi = false;
    public float wudiTim = 0.5f;
    float time;
    public camShark camshark;
    public Animator anim, anim1;
    public float PingZhang;
    float ShenYu;
    string id;
    float max;
    int curStack;
    float FreshTime;//³ÖÐø»ØÑªÊ±¼ä
    public UnityEvent OnReload { get; private set; } =new();
   // float FreshTime;//ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ÑªÊ±ï¿½ï¿½

    private void Awake()
    {
        HP.Value = _hp;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = wudiTim;
        max = HP.Value;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP.Value > max)
            HP.Value = max;
        Debug.Log(HP);
        if(FreshTime > 0)
        {
            FreshTime-=Time.deltaTime;
            HP.Value += 5 * Time.deltaTime;
        }
        Debug.Log(PingZhang);
        if (transform.position.y < -20)
        {
            OnReload.Invoke();
            Scene currentScene = SceneManager.GetActiveScene();

            // ï¿½ï¿½ï¿½Â¼ï¿½ï¿½Øµï¿½Ç°ï¿½ï¿½ï¿½ï¿½
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
                var model=InventoryManager.Instance.GetModel<InventoryModel>();
                if (model.ItemInHand.Value != null)
                {
                    id = model.ItemInHand.Value.itemId;
                    curStack = model.ItemInHand.Value.currentStackCount;
                    Debug.Log("id=" + id);
                    Debug.Log("cur=" + curStack);
                }
                if(curStack>0)
                {
                    switch (id)
                    {
                        case "301":
                            HP.Value += 50;
                            break;
                        case "302":
                            FreshTime = 12f;
                            break;

                    }
                    model.ItemInHand.Value.DecreaseStack();
                }
                

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
    public void GetAtted(float shanghai)//ï¿½Üµï¿½ï¿½Ëºï¿½
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
