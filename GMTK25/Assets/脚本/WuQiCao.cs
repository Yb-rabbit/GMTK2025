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
    string mormal;//��¼��һ��id
    public GameObject[] wuqi;
    int i;//iΪҪ�����������ı��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InventoryManager.Instance.GetModel<InventoryModel>().Weapon.Value == null) return;
        id = InventoryManager.Instance.GetModel<InventoryModel>().Weapon.Value.itemId;
        if(mormal!=id)//������ͬ��������
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
            // ������������������
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            // �����ڱ༭����ʹ����������
            // while (transform.childCount > 0)
            // {
            //     DestroyImmediate(transform.GetChild(0).gameObject);
            // }

            // �����µ�������D
            if (wuqi[i] != null)
            {
                GameObject newChild = Instantiate(wuqi[i], transform);
                newChild.transform.localPosition = Vector3.zero; // �븸����������ͬ
                newChild.transform.localRotation = Quaternion.identity;
                newChild.transform.localScale = Vector3.one;
            }
        }
        
    }
}
