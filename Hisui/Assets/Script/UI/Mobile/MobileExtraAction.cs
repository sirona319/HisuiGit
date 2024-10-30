using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileExtraAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var trigger = GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry { eventID = EventTriggerType.PointerDown };
        var exit = new EventTrigger.Entry { eventID = EventTriggerType.PointerUp };

        var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScr>();
        //entry.callback.AddListener((eventData) => { player.MobileExtraControl(); });
        //exit.callback.AddListener((eventData) => { player.MobileExtraControl(); });

        trigger.triggers.Add(entry);
        trigger.triggers.Add(exit);
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //GetComponent<Selectable>().
    //}
}
