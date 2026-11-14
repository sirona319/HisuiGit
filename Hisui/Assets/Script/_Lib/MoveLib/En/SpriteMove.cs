using System.Collections.Generic;
using UnityEngine;

public class SpriteMove : MonoBehaviour
{

    [SerializeField] float rotSpeed = 5f;


    [SerializeField] List<Transform> moveTrans;
    [SerializeField] List<Vector3> moveVector;
    float endLength = 0.5f;
    //[SerializeField] List<float> endLength;
    [SerializeField][Range(1f, 20f)] float speed = 1f;

    [SerializeField] bool isLoop = false;
    [SerializeField] bool isEnd = false;
    int targetNo = 0;

    void Start()
    {
        transform.DetachChildren();

        foreach (var mt in moveTrans)
        {
            moveVector.Add(mt.position);
            Destroy(mt.gameObject);
        }


        //moveTrans = TargetSet.I.SetPointArray(moveTrans, gameObject);
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

        float len = Vector3.Distance(transform.position, moveVector[targetNo]);
        if (len < endLength)
        {
            targetNo++;
            if (targetNo > moveVector.Count - 1)
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
        transform.rotation = MyLib.TargetRotationSprite3D(moveVector[targetNo], transform, rotSpeed);

    }

}
