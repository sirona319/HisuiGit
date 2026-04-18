using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour
{

    [SerializeField] float rotSpeed = 5f;


    [SerializeField] List<Transform> moveTrans;

    float endLength = 0.5f;
    //[SerializeField] List<float> endLength;
    [SerializeField][Range(1f, 20f)] float speed = 1f;

    [SerializeField] bool isLoop = false;
    [SerializeField] bool isEnd = false;
    int targetNo = 0;

    void Start()
    {

        moveTrans = TargetSet.I.SetPointArray(moveTrans, gameObject);
    }

    void FixedUpdate()
    {
        PointUpdate();

        //前方向が右方向なので、transform.rightを使用
        transform.position += transform.right * (speed * Time.fixedDeltaTime);

    }

    void PointUpdate()
    {
        if (isEnd) return;

        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < endLength)
        {
            targetNo++;
            if (targetNo > moveTrans.Count - 1)
            {
                isEnd = true;

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;
            }

        }


        // var vel = (moveTrans[targetNo].position - transform.position);
        // Quaternion targetRot = Quaternion.LookRotation(vel)* Quaternion.Euler(0, -90, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);
        transform.rotation = MyLib.TargetRotationSprite3D(moveTrans[targetNo].position, transform, rotSpeed);

    }

}
