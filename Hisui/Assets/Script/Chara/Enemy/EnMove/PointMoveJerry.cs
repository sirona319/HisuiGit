using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveJerry : BaseMove
{

    [SerializeField] bool isTrailLoop = false;
    const float rotSpeed = 5f;


    [SerializeField] List<Transform> moveTrans;

    [SerializeField] List<float> endLength;
    [SerializeField][Range(1f, 20f)] float speed = 1f;

    [SerializeField] bool isLoop = false;
    //public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？

    int targetNo = 0;
    Rigidbody2D rb2;


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();

        moveTrans = TargetSet.I.SetPointArray(moveTrans,gameObject);

        GetComponent<SoundMove>().SoundPlay();

    }

    private void FixedUpdate()
    {
        PointUpdate();

        rb2.MovePosition(rb2.position + (Vector2)transform.up * (speed * Time.fixedDeltaTime));

    }

    void PointUpdate()
    {
        float len = Vector2.Distance(rb2.position, moveTrans[targetNo].position);
        if (len < endLength[targetNo])
        {

            targetNo++;
            if (targetNo > moveTrans.Count - 1)
            {

                if (GetComponent<EnFloatMove>() != null)
                {
                    Debug.Log("PointMoveJerryからFloatMoveJerryに移行");
                    GetComponent<SoundMove>().SoundFadeStop();
                    GetComponent<EnFloatMove>().enabled = true;
                    GetComponent<BaseMagazine>().enabled = true;
                    this.enabled = false;
                }

                if (!isTrailLoop)
                    GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;
            }

        }


        transform.rotation = MyLib.GetAngleRotationFunc2D(moveTrans[targetNo].position, transform, rotSpeed);

    }


}
