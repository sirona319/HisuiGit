/*

using DG.Tweening;
using UnityEngine;


public class CameraSample : MonoBehaviour
{

    public bool isEventCamera=false;
    //Transform eventCameraTarget;
    Vector3 eventTargetPos = Vector3.zero;
    float cameraDuration = 1f;

    public Transform cameraTarget; // Z -10
    [SerializeField] float cameraSpd = 0.08f;
    //[SerializeField] float cameraSize = 5f;
    void Start()
    {
        if (cameraTarget == null)
        {
            //cameraTarget= GameObject.FindGameObjectWithTag(TagName.Player).transform.Find("CameraTarget").transform;
            //var pos = transform.position;
            //pos.z = -10f;
            //transform.position = pos;
            return;
        }


        var t = transform.position;
        t.x = cameraTarget.position.x;
        t.y = cameraTarget.position.y;
        transform.position = t;

        //Camera.main.orthographicSize = cameraSize;

    }

    void Update()
    {
        CameraEventUpdate();
    }

    private void FixedUpdate()
    {
        CameraTarget2DUpdate();

    }

    void CameraTarget2DUpdate()
    {
        if (isEventCamera) return;

        if(cameraTarget==null)return;

        transform.position = Vector3.Lerp(transform.position, cameraTarget.transform.position, cameraSpd * Time.deltaTime);

    }

    
    void CameraEventUpdate()
    {
        if (!isEventCamera) return;

        const float cameraTargetLen = 0.01f;
        if (Vector3.Distance(eventTargetPos, transform.position) < cameraTargetLen)
            return;
        
        //tween = 
            transform.DOMove(eventTargetPos, cameraDuration).SetEase(Ease.OutSine);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targetPos"></param>位置
    /// <param name="dur"></param>速度
    public void CameraEventTrigger(Vector3 targetPos,float dur)
    {
        isEventCamera = true;
        eventTargetPos = targetPos;
        cameraDuration = dur;
    }

    public void CameraEventTriggerOff()
    {
        isEventCamera = false;
    }

    public void ChangePlayerPos()
    {
        transform.position = cameraTarget.transform.position;
    }

    //private void OnDisable()
    //{
    //    // Tween破棄
    //    if (DOTween.instance != null)
    //    {
    //        tween?.Kill();
    //    }
    //}
}
 */