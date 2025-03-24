using DG.Tweening;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PointMove : BaseMove
{
    [SerializeField] Transform[] moveTrans;
    List<Vector3> moveVecs = new();

    int targetNo = 0;
    float endLength = 0.7f;

    [SerializeField] float speed = 4f;
    const float rotSpeed = 5f;

    bool isLoop = false;
    public ReactiveProperty<bool> isPointMoveEnd = new ReactiveProperty<bool>(false);//CreateMoveでSubscribe　エネミークラスなど？

    Rigidbody2D rb2;

    //GameObject trailSe;


    //public void TargetSet(Transform[] t)
    //{
    //    targets = t;

    //    if (targets.Length <= 0)
    //        throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    //}

    public override void Initialize()
    {
        rb2 = GetComponent<Rigidbody2D>();

        foreach (Transform t in moveTrans)
        {
            moveVecs.Add(t.position);
        }
    }

    public override void MoveEnter()
    {
        //このクラスを継承してPointMoveJerryなどに移行？＊＊＊

        //var trailSe = (GameObject)Resources.Load("Prefab/Sound/JerryTrailSe");
        ////トレイルサウンド用
        //var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, transform);
        //seObj.GetComponent<AudioSource>().Play();

        ////var pFloatMove = GetComponent<PointFloatMove>();
        //isPointMoveEnd.Skip(1).Subscribe(pointBool =>
        //{
        //    const float fadeSpeed = 1f;//1秒で止まる
        //    seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

        //    GetComponent<EnemyBase>().SetEndMoveKeep();
        //    GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);

        //});

        //****
    }

    public override void MoveUpdate()
    {
        if (isPointMoveEnd.Value)
        {
            //Debug.Log("ポイントムーブ終了　Subscribe");
            //ポイントムーブ終了　Subscribe
            //enabled = false;
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
        float len = Vector3.Distance(transform.position, moveVecs[targetNo]);
        if (len < endLength)
        {

            targetNo++;
            if (targetNo > moveVecs.Count - 1)
            {

                //if (!IsKeepMove)
                isPointMoveEnd.Value = true;

                if (isLoop)
                    targetNo = 0;
                else
                    targetNo--;
            }

        }

        transform.rotation = MyLib.GetAngleRotationFuncs(moveVecs[targetNo], transform, rotSpeed);

    }


    //移行する?s
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
