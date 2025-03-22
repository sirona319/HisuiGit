using DG.Tweening;
using UniRx;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PointFloatMove : BaseMove, ITargets
{
    int targetNo = 0;
    float endLength = 0.7f;

    [SerializeField] float speed = 4f;
    const float rotSpeed = 5f;

    public Transform[] targets { get; set; }

    //[SerializeField] float floatSpeed = 0.005f;

    bool isLoop = false;
    public ReactiveProperty<bool> IsPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe

    Rigidbody2D rb2;
    //float sinTime = 0;
    public void TargetSet(Transform[] t)
    {
        targets = t;

        if (targets.Length <= 0)
            throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    }

    //public void SetMoveEndLength(float len)
    //{
    //    endLength = len;
    //}

    //AudioSource se;
    //AudioResource ar;
    public override void Initialize()
    {
        //m_rb = rb;

        //IsKeepMove = true;

    }

    [SerializeField] GameObject trailSe;
    public override void MoveEnter()
    {
        //トレイルサウンド用
        var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
        seObj.GetComponent<AudioSource>().Play();

        //var pFloatMove = GetComponent<PointFloatMove>();
        IsPointMoveEnd.Skip(1).Subscribe(pointBool =>
        {
            const float fadeSpeed = 1f;//1秒で止まる
            seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

            GetComponent<EnemyBase>().SetEndMoveKeep();
            GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

        });
    }

    public override void MoveUpdate()
    {
        if (IsPointMoveEnd.Value)
        {
            //sinTime += Time.deltaTime;
            ////エネミーにトレイルレンダーがついている場合持続する
            //MyLib.LoopMotionSinWait(sinTime,transform, 0, floatSpeed);


            ////ワールド座標　上方向を向かせる
            ////float targetAngle = MyLib.GetTargetAngle((transform.position + Vector3.up), transform);

            ////var velocity = MyLib.SetVelocityAngle2D(targetAngle);

            //transform.rotation = MyLib.GetAngleRotationFuncs((transform.position + Vector3.up), transform, rotSpeed);
            //MyLib.TargetRotation2DZOnlyLerp(transform, velocity, rotSpeed);


            //return;
        }
        else
        {
            PointUpdate();
        }


        rb2.MovePosition(rb2.position + (Vector2)transform.up * speed * Time.deltaTime);

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

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("ExitErea"))
        {
            if (gameObject.tag == "Enemy")
            {
                gameObject.GetComponent<CreateDeadSound>().IsSoundEnable = false;
                gameObject.transform.GetComponent<EnemyBase>().EnemyDamage(10);
                return;
            }

        }

    }
}
