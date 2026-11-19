using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SceneChangeClickEvent : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] GameObject startEvent;
    [SerializeField] List<DOFadeText> startFade;

    [SerializeField] List<DOFadeText> endFades;

    [SerializeField] BackScroll backsc;

    public UnityEvent OnStart;

    bool IsAct = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (IsAct) return;

        if (startFade[0].enabled)
        {
            startFade.ToList().ForEach(x => { x.Skip(); });

            //isSkip = true;
            return;
        }

        Debug.Log(gameObject.name + "Click");

        endFades.ToList().ForEach(x => { x.ShowWindow(); });

        IsAct = true;

    }

    private void Update()
    {
        if (endFades[0].enabled) return;

        //startEvent.SetActive(true);
        //backsc.enabled = true;
        OnStart?.Invoke();


        startFade.ToList().ForEach(x => { x.enabled = false; });

        Debug.Log(gameObject.name + "IsShowEnd");
        enabled = false;
    }

}


