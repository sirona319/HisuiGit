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
    List<Vector3> moveVector = new();

    [SerializeField] float endLength=.1f;
    [SerializeField][Range(1f, 20f)] float speed = 1f;

    [SerializeField] bool isLoop = false;

    int targetNo = 0;

    [SerializeField] BaseMove changeMove;
    [SerializeField] BaseMagazine[] changeMags;
    [SerializeField] MonoBehaviour[] changeComps;


    //public event Action<BaseMove> OnMoveChange;
    //public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？


    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();


        GetComponent<SoundMove>().SoundPlay();


        foreach (var mt in moveTrans)
        {
            moveVector.Add(mt.position);
            Destroy(mt.gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (PointUpdate()) return;

        transform.rotation = MyLib.GetAngleRotationFunc2D(moveVector[targetNo], transform, rotSpeed);

        rb2.MovePosition(rb2.position + (Vector2)transform.up * (speed * Time.fixedDeltaTime));

    }

    bool PointUpdate()
    {
        float len = Vector2.Distance(rb2.position, moveVector[targetNo]);
        if (len >= endLength) return false;
        

        targetNo++;
        if (targetNo >= moveVector.Count)
        {
            if (changeMove != null)
            {
                ChangeMove();
                return true;
            }

            if (isLoop)
                targetNo = 0;
            else
                targetNo = moveVector.Count - 1;
        }

        return false;
    }


    void ChangeMove()
    {
        
        Debug.Log("FloatMoveJerryに移行");

        changeMove.enabled = true;

        changeComps.ToList().ForEach(x => x.enabled = !x.enabled);

        if (changeMags != null)
            changeMags.ToList().ForEach(x => x.enabled = !x.enabled);

        GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);
        this.enabled = false;


        
    }

}
