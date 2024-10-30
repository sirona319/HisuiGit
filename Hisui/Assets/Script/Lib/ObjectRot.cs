using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRot : MonoBehaviour
{
    [SerializeField] bool x = false;
    [SerializeField] bool y = false;
    [SerializeField] bool z = false;

    [SerializeField] float SPEED=30;
    //[SerializeField] float d=0;
    // Start is called before the first frame update
    //void Start()
    //{
    //    //const float ROTVALUE = 360f;
    //    //const float duration = 1f;
    //    //StartCoroutine(MyLib.LoopDelayCoroutine(1f, () =>
    //    //{
    //    //    this.transform.DORotate(Vector3.up * ROTVALUE, duration, RotateMode.LocalAxisAdd);
    //    //}));

    //}

    // Update is called once per frame
    void Update()
    {
        float ROTVALUE = SPEED;
        float duration = 1f;
       // StartCoroutine(MyLib.LoopDelayCoroutine(1f, () =>
       // {
       if(y)
            this.transform.DORotate(Vector3.up * ROTVALUE, duration, RotateMode.LocalAxisAdd);
        else if (x)
            this.transform.DORotate(Vector3.right * ROTVALUE, duration, RotateMode.LocalAxisAdd);
        else if (z)
            this.transform.DORotate(Vector3.forward * ROTVALUE, duration, RotateMode.LocalAxisAdd);
        //}));

        //const float ROLLSPEED = 7f;
        //var rot = Quaternion.AngleAxis(ROLLSPEED, Vector3.right);

        //transform.rotation = transform.rotation * rot;
    }
}
