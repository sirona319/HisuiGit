using System.Runtime.CompilerServices;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PointFloatMove : BaseMove
{
    int targetNo = 0;
    public float endLength = 0.7f;

    public float speed = 4f;

    public Transform[] targets;

    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);

    [SerializeField] float floatSpeed = 0.005f;

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

        IsKeepMove = true;
    }

    public override void MoveEnter()
    {


    }

    public override void MoveUpdate()
    {

        if (IsPointMoveEnd.Value)
        {
            //エネミーにトレイルレンダーがついている場合持続する
            MyLib.LoopMotionSinWait(transform, 0, floatSpeed);


            m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);


            /*targets[targetNo].position*/

            //Vector2 direction = (transform.position + Vector3.up) - transform.position;
            //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

            //// X方向の移動量を設定する
            //velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

            //// Y方向の移動量を設定する
            //velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


            //// 弾の向きを設定する
            //float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, zAngle), 5f * Time.deltaTime);


            //ワールド座標　上方向を向かせる
            float targetAngle = MyLib.GetTargetAngle((transform.position + Vector3.up), transform);

            velocity = MyLib.SetVelocityAngle2D(velocity, targetAngle, speed);

            transform.rotation =
                MyLib.TargetRotation2DZOnlyLerp(transform, velocity, rotSpeed);


            //transform.rotation = MyLib.TargetRotation2D((transform.position + Vector3.up), transform);

            //float targetAngle = MyLib.GetTargetAngle((transform.position + Vector3.up), transform);

            //velocity = MyLib.SetVelocityAngle2D(velocity, targetAngle, speed);






            //transform.rotation =
            //    MyLib.TargetRotation2DOnlyLerpZ(transform, (transform.position + Vector3.up),ref velocity,speed,rotSpeed);


            return;
        }

        PointUpdate();

    }

    const float rotSpeed = 5f;
    Vector2 velocity = Vector2.zero;
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


        //(Vector2)transform.up
        m_rb.MovePosition(m_rb.position + (Vector2)transform.up * speed * Time.deltaTime);


        //transform.rotation =
        //    MyLib.TargetRotation2DOnlyLerpZ(transform, targets[targetNo].position, ref velocity, speed, rotSpeed);

        float targetAngle = MyLib.GetTargetAngle(targets[targetNo].position, transform);

        velocity = MyLib.SetVelocityAngle2D(velocity, targetAngle, speed);

        transform.rotation =
            MyLib.TargetRotation2DZOnlyLerp(transform, velocity, rotSpeed);


        //Vector2 direction = targets[targetNo].position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        ////var angle = GetComponent<BaseBullet>().angle;
        ////angle += angleVal;


        //// X方向の移動量を設定する
        //velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        //// Y方向の移動量を設定する
        //velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        //// 弾の向きを設定する
        //float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        //transform.rotation = Quaternion.Euler(0, 0, zAngle);




        //transform.rotation = MyLib.TargetRotation2D(targets[targetNo].position, transform);
    }


}
