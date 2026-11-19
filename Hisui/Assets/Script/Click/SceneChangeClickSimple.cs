using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeClickSimple : MonoBehaviour, IPointerClickHandler
{
    //Imageコンポーネントが重なると反応しない
    [SerializeField] EnumSceneName.SceneNameType sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(gameObject.name + "Click"+ sceneName.ToString());

        GameObject.FindGameObjectWithTag("Fade").GetComponent<FadeScene>().SceneFade(sceneName.ToString());
        Time.timeScale = 1.0f;
        //bc.SetActive(false);
    }

}

