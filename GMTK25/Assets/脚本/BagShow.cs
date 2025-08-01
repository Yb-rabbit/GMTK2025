using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class BagShow : MonoBehaviour
{
    public Sprite[] sp;
    public string[] words;
    public string word;
    public Sprite spp;
    public int i = 0;
    Image image;
    public bool Onder;
    public BagShow father;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(father != null)
        {
            i=father.i;
        }
        image.sprite = sp[i];
        spp = sp[i];
        word = words[i];
        //��ȡ���λ��
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // ִ�����߼�⣬��ȡ�������е� UI
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // ����Ƿ����е�ǰ����
        foreach (var result in results)
        {

            if (result.gameObject == gameObject) // ��ǰ��������
            {
                Onder = true;
                break;
            }
            else
                Onder = false;
        }
    }
    
  
}