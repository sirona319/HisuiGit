using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DebugEvent : MonoBehaviour
{

    public UnityEvent OnDebug;

    public GameObject SWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnDebug?.Invoke();

        SWave.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
