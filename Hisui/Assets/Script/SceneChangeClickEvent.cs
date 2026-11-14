using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class SceneChangeClickEvent : MonoBehaviour, IPointerClickHandler//,IPointerEnterHandler, IPointerExitHandler
{
    //public bool isEnable = false;
    //[SerializeField] EnumSceneName.SceneNameType sceneName;
    [SerializeField] GameObject go;


    //[SerializeField] DOFadeText startFade;
    [SerializeField] List<DOFadeText> startFade;

    //[SerializeField] DOFadeText endFade;
    [SerializeField] List<DOFadeText> endFades;
    //[SerializeField]Image image;

    //bool isSkip = false;

    [SerializeField] BackScroll backsc;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (startFade[0].enabled)
        {
            startFade.ToList().ForEach(x => { x.Skip(); });

            //isSkip = true;
            return;
        }

        Debug.Log(gameObject.name + "Click");


        //var selectObj = MyLib.DebugRayViewCameraPosZ();


        endFades.ToList().ForEach(x => { x.ShowWindow(); });



        //MyCoroutine();
    }

    private void Update()
    {
        if (endFades[0].enabled) return;
        
            go.SetActive(true);

            Debug.Log(gameObject.name + "IsShowEnd");

            //GameObject.FindWithTag("MoveErea").ToList().ForEach(x => { x.SetActive(false); });

            backsc.enabled = true;
            startFade.ToList().ForEach(x => { x.enabled = false; });
        enabled = false;
    }

    //IEnumerator MyCoroutine()
    //{
    //    yield return new WaitUntil(() => endFade.enabled);



    //    go.SetActive(true);

    //    Debug.Log(gameObject.name + "IsShowEnd");

    //    //GameObject.FindWithTag("MoveErea").ToList().ForEach(x => { x.SetActive(false); });

    //    backsc.enabled = true;
    //    startFade.ToList().ForEach(x => { x.enabled = false; });
    //    Debug.Log("条件成立！");
    //}

    //public void test()
    //{
    //    var selectObj = MyLib.DebugRayViewCameraPosZ();
    //    go.SetActive(true);
    //}

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


