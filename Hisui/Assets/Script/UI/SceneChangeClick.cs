using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneChangeClick : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler, IPointerExitHandler
{
    //public bool isEnable = false;
    [SerializeField]EnumSceneName.SceneNameType sceneName;

    [SerializeField]Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "Click");

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().SceneFade(sceneName.ToString());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(gameObject.name+"Enter");
        image.enabled = true;
       // isEnable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "Exit");
        image.enabled = false;
        //isEnable = false;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
