using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PointMoveJerry : BaseMove
{
    Rigidbody2D rb2;
    const float rotSpeed = 5f;


    [SerializeField] List<Transform> moveTrans;
    [SerializeField] List<float> endLength;
    [SerializeField][Range(1f, 20f)] float speed = 1f;

    [SerializeField] bool isLoop = false;

    int targetNo = 0;

    [SerializeField] BaseMove changeMove;
    [SerializeField] BaseMagazine[] changeMags;//

    [SerializeField] MonoBehaviour[] changeComps;//


    //public event Action<BaseMove> OnMoveChange;
    //public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
       // moveTrans = moveTrans;
        //moveTrans = TargetSet.I.SetPointArray(moveTrans,gameObject);

        GetComponent<SoundMove>().SoundPlay();

        //foreach (var mt in moveTrans)
        //{
        //    moveVector.Add(mt.position);
        //    Destroy(mt.gameObject);
        //}

    }

    private void FixedUpdate()
    {
        PointUpdate();

        transform.rotation = MyLib.GetAngleRotationFunc2D(moveTrans[targetNo].position, transform, rotSpeed);

        rb2.MovePosition(rb2.position + (Vector2)transform.up * (speed * Time.fixedDeltaTime));

    }

    void PointUpdate()
    {
        float len = Vector2.Distance(rb2.position, moveTrans[targetNo].position);
        if (len >= endLength[targetNo]) return;
        

        targetNo++;
        if (targetNo > moveTrans.Count - 1)
        {

            if (changeMove)
            {
                Debug.Log("PointMoveJerryからFloatMoveJerryに移行");
                //GetComponent<SoundMove>().SoundFadeStop();
                changeMove.enabled = true;

                changeComps.ToList().ForEach(x => x.enabled = !x.enabled);
                changeMags.ToList().ForEach(x => x.enabled=!x.enabled);

                GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);
                this.enabled = false;

            }

            if (isLoop)
                targetNo = 0;
            else
                targetNo--;
        }
 

    }


}
