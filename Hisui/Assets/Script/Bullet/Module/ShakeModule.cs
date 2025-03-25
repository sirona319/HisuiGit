using UnityEngine;

[DisallowMultipleComponent]
public sealed class ShakeModule : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        const float power = 0.03f;            //揺らす力
        const int frame = 25;            //揺らすタイミング
        StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime * frame, () =>
        {
            MyLib.DoShakeUpdate2D(power, transform);
        }));

    }
}
