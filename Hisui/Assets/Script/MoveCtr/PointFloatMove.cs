using System.Runtime.CompilerServices;
using UniRx;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Audio;
using static UnityEngine.GraphicsBuffer;

public class PointFloatMove : BaseMove
{
    int targetNo = 0;
    public float endLength = 0.7f;

    public float speed = 4f;
    const float rotSpeed = 5f;

    public Transform[] targets;

    [SerializeField] float floatSpeed = 0.005f;

    bool isLoop = false;
    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe

    float sinTime = 0;
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

    //AudioSource se;
    //AudioResource ar;
    public override void Initialize(Rigidbody2D rb)
    {
        m_rb = rb;

        IsKeepMove = true;

    }

    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (IsPointMoveEnd.Value)
        {
            sinTime += Time.deltaTime;
            //エネミーにトレイルレンダーがついている場合持続する
            MyLib.LoopMotionSinWait(sinTime,transform, 0, floatSpeed);


            //ワールド座標　上方向を向かせる
            //float targetAngle = MyLib.GetTargetAngle((transform.position + Vector3.up), transform);

            //var velocity = MyLib.SetVelocityAngle2D(targetAngle);

            transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, rotSpeed);
            //MyLib.TargetRotation2DZOnlyLerp(transform, velocity, rotSpeed);


            //return;
        }
        else
        {
            PointUpdate();
        }


        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);

    }


    //Vector2 velocity = Vector2.zero;
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


        //m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);



        //float targetAngle = MyLib.GetTargetAngle(targets[targetNo].position, transform);

        //var velocity = MyLib.SetVelocityAngle2D(targetAngle);

        transform.rotation = MyLib.GetAngleRotationFuncs(targets[targetNo].position, transform, rotSpeed);
            //MyLib.TargetRotation2DZOnlyLerp(transform, velocity, rotSpeed);


    }


}
