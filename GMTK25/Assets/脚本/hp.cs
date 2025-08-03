using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Models.Inventory;

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
    string id;
    float max;
    int curStack;
    float FreshTime;//持续回血时间
    // Start is called before the first frame update
    void Start()
    {
        time = wudiTim;
        max = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP > max)
            HP = max;
        Debug.Log(HP);
        if(FreshTime > 0)
        {
            FreshTime-=Time.deltaTime;
            HP += 5 * Time.deltaTime;
        }
        Debug.Log(PingZhang);
        if (transform.position.y < -20)
        {
            Scene currentScene = SceneManager.GetActiveScene();

            // 重新加载当前场景
            SceneManager.LoadScene(currentScene.name);
        }
        if (HP < 0)
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
                if(curStack>-1)
                {
                    switch (id)
                    {
                        case "301":
                            HP += 50;
                            break;
                        case "302":
                            FreshTime = 12f;
                            break;

                    }
                    model.ItemInHand.Value.currentStackCount--;
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
    public void GetAtted(float shanghai)//受到伤害
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
