using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DebugEvent : MonoBehaviour
{

    public UnityEvent OnDebug;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnDebug?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
