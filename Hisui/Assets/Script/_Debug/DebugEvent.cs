using UnityEngine;
using UnityEngine.Events;

public class DebugEvent : MonoBehaviour
{

    public UnityEvent[] OnDebug;


    //スクリプトが非アクティブでも実行される
    void Awake()
    {
        //Debug.Log(gameObject.name + "Awake");
        foreach (var debugEvent in OnDebug)
        {
            debugEvent?.Invoke();
        }

    }

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    foreach (var debugEvent in OnDebug)
    //    {
    //        debugEvent?.Invoke();
    //    }

    //}

}
