using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;
using Yumihoshi.Managers;
using Yumihoshi.MVC.Models.Inventory;
using Yumihoshi.SO.Item.Weapon;

public class WuQiCao : MonoBehaviour
{
    string id;
    string mormal;//记录上一个id
    public GameObject[] wuqi;
    int i;//i为要更换的武器的编号
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        id = InventoryManager.Instance.GetModel<InventoryModel>().Weapon?.Value.itemId;
        if(mormal!=id)//武器不同，换武器
        {
            mormal = id;
            switch (id)
            {
                case "001":
                    i = 0;
                    break;
                case "002":
                    i = 1; break;
                case "003":
                    i = 2; break;
                case "004":
                    i = 3; break;

            }
            // 销毁所有现有子物体
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            // 或者在编辑器中使用立即销毁
            // while (transform.childCount > 0)
            // {
            //     DestroyImmediate(transform.GetChild(0).gameObject);
            // }

            // 创建新的子物体D
            if (wuqi[i] != null)
            {
                GameObject newChild = Instantiate(wuqi[i], transform);
                newChild.transform.localPosition = Vector3.zero; // 与父物体坐标相同
                newChild.transform.localRotation = Quaternion.identity;
                newChild.transform.localScale = Vector3.one;
            }
        }
        
    }
}
