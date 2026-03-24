using DG.Tweening;
using UnityEngine;

public class RotModule : MonoBehaviour
{
    [SerializeField] bool x = false;
    [SerializeField] bool y = false;
    [SerializeField] bool z = false;

    [SerializeField] public float speed=0;

    [SerializeField] Transform target = null;
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
        TargetRotIf();

        //float ROTVALUE = speed;
        // StartCoroutine(MyLib.LoopDelayCoroutine(1f, () =>
        // {


        //if (TargetRotIf())
        //    return;
        //float duration = 1f;

        //if (y)
        //    this.transform.DORotate(Vector3.up * speed, duration, RotateMode.LocalAxisAdd);
        //else if (x)
        //    this.transform.DORotate(Vector3.right * speed, duration, RotateMode.LocalAxisAdd);
        //else if (z)
        //    this.transform.DORotate(Vector3.forward * speed, duration, RotateMode.LocalAxisAdd);


        //}));

        //const float ROLLSPEED = 7f;
        //var rot = Quaternion.AngleAxis(ROLLSPEED, Vector3.right);

        //transform.rotation = transform.rotation * rot;
    }

    void TargetRotIf()
    {
        if (target == null) target = this.transform;

        //float ROTVALUE = SPEED;
        float duration = 1f;
        // StartCoroutine(MyLib.LoopDelayCoroutine(1f, () =>
        // {
        if (y)
            target.DORotate(Vector3.up * speed, duration, RotateMode.LocalAxisAdd);
        else if (x)
            target.DORotate(Vector3.right * speed, duration, RotateMode.LocalAxisAdd);
        else if (z)
            target.DORotate(Vector3.forward * speed, duration, RotateMode.LocalAxisAdd);

        //return true;

    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        //DOTween.KillAll();
        Debug.Log("RotModule Destroy");
    }
}
