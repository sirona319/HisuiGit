using UnityEngine;

//[DisallowMultipleComponent]
public sealed class ShakeLoopModule : MonoBehaviour
{
    [SerializeField] float zPos = 0f;
    [SerializeField] float power = 1f;
    [SerializeField] float timeMax = 1f;
    float time = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = timeMax;
    }
    //12 limix
    //6 limity
    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            return;
        }

        MyLib.DoShakeUpdate2D(power, transform, zPos);
        time = timeMax;
    }



    //[SerializeField] float zPos = 0f;
    //[SerializeField] float power = 0.03f;
    //[SerializeField] int frame = 25;
    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //private void OnEnable()
    //{
    //    //const float power = 0.03f;            //揺らす力
    //    //const int frame = 25;            //揺らすタイミング
    //    StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime * frame, () =>
    //    {
    //        MyLib.DoShakeUpdate2D(power, transform,zPos);
    //    }));

    //}
}
