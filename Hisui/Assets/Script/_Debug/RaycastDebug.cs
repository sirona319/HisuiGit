using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


//AI
public class RaycastDebug : MonoBehaviour
{
    void Update()
    {

        //AI_RaycastTarget デバッグ用
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {

            //Mouse.current.position.ReadValue()
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Mouse.current.position.ReadValue();

            var results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(eventData, results);

            foreach (var result in results)
            {
                Debug.Log("Raycast: " + result.gameObject.name);
            }
        }
    }
}