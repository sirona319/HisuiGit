using UnityEngine;

public class ShakeOnceModule : MonoBehaviour
{

    [SerializeField] bool awakeShake;
    //揺らす長さ
    [SerializeField] float shakeLength = 0.15f;
    //揺らす力
    [SerializeField] float power = 0.3f;

    float time = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;

        if (time > shakeLength)
            enabled = false;
    }

    void OnEnable()
    {
        //if (!awakeShake) return;
        //const float power = 3f;            //揺らす力
        ////const int frame = 25;            //揺らすタイミング
        //StartCoroutine(MyLib.DelayCoroutine(0, () =>
        //{
        //    MyLib.DoShakeUpdate2D(power, transform);
        //}));

        //https://baba-s.hatenablog.com/entry/2018/03/14/170400



        StartCoroutine(MyLib.DoShake(shakeLength, power, transform));

    }

    //public void EventShake()
    //{
    //    //揺らす長さ
    //    const float shakeLength = 0.15f;
    //    //揺らす力
    //    const float power = 0.3f;

    //    StartCoroutine(MyLib.DoShake(shakeLength, power, transform));
    //}
}
