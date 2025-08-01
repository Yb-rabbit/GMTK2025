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
        //获取鼠标位置
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // 执行射线检测，获取所有命中的 UI
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        // 检查是否命中当前对象
        foreach (var result in results)
        {

            if (result.gameObject == gameObject) // 当前对象被命中
            {
                Onder = true;
                break;
            }
            else
                Onder = false;
        }
    }
    
  
}