using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SceneChangeClick : MonoBehaviour, IPointerClickHandler//,IPointerEnterHandler, IPointerExitHandler
{
    //public bool isEnable = false;
    [SerializeField]EnumSceneName.SceneNameType sceneName;

    //[SerializeField]Image image;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "Click");

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().SceneFade(sceneName.ToString());
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    Debug.Log(gameObject.name+"Enter");

    //    if(image != null)
    //    image.enabled = true;
    //   // isEnable = true;
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    Debug.Log(gameObject.name + "Exit");

    //    if (image != null)false;false

    //        image.enabled = false;    false;
    //    //isEnable = false;

    //};false;false;

}

