using System.Runtime.CompilerServices;
using UniRx;
using UnityEngine;

//リセットできるようにする？　移動後停止してまた使えるようにするため
public class PointMove : BaseMove
{

    int targetNo = 0;
    public float endLength = 0.7f;

    public float speed = 10f;

    public Transform[] targets;

    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);

    bool isLoop = false;
    public void TargetSet(Transform[] t)
    {
        targets = t;

        if (targets.Length <= 0)
            throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    }

    public void SetMoveEndLength(float len)
    {
        endLength = len;
    }

    public override void Initialize(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (IsPointMoveEnd.Value) return;

        PointUpdate();


    }

    void PointUpdate()
    {
        float len = Vector3.Distance(transform.position, targets[targetNo].position);

        //重力テスト
        //if(len<2f&&speed>4f)
        //{
        //    speed *= (len * 0.4f);
        //}

        if (len < endLength)
        {

            targetNo++;
            if (targetNo > targets.Length - 1)
            {
                //if (!IsKeepMove)
                IsPointMoveEnd.Value = true;

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;
            }

        }

        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

        transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);

    }



}
