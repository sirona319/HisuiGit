using DG.Tweening;
using System;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using static BaseMove;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.ParticleSystem;

public sealed class JerryBuilder : BaseBuilder
{

    [SerializeField] GameObject jerryGo;


    [SerializeField] GameObject trailSe;

    public GameObject GetTrailSe
    {
        get { return trailSe; }
    }

    [SerializeField] GameObject bulletGo;

    [SerializeField] AudioResource bulletSe;

    [SerializeField] CreateDeadSound createSound;


    public override void Build(EnemyData eData, Transform s, Transform[] movePoint)
    {

        var enemy = Instantiate(jerryGo, s.position, s.rotation);

        //死亡時のオブジェクトコンポーネント
        enemy.AddComponent<CreateDeadSound>();

        ////トレイルse用オブジェクト生成
        //trailSe = (GameObject)Resources.Load("prefab/Sound/JerryTrailSe");
        trailSe.transform.position = s.position;

        //ステータスの設定
        var eBase = enemy.GetComponent<EnemyBase>();
        const float randAtkRange = 0.5f;
        float randAtkVal = UnityEngine.Random.Range(-randAtkRange, randAtkRange);
        eBase.AtkInterval = eData.AtkIntervalMax+ randAtkVal;　　//初回攻撃の設定できる？
        eBase.AtkIntervalMax = eData.AtkIntervalMax;
        eBase.Hp = eData.HpMax;
        //

        //マガジン設定
        GetComponent<CreateMagazine>().SetBullet(bulletGo, bulletSe);//SeとPrefab設定
        GetComponent<CreateMagazine>().MagazineCreateInit
            (eData.magazineType,eData.bulletType, enemy,eData.bulletTarget);

        //ムーブ設定
        SelectCreateMove(eData.moveType[0], movePoint, enemy);





        //eBase.enemyData = eData;
    }


    void SelectCreateMove(MoveType moveType, Transform[] movePoint, GameObject go)
    {

        var createMove=GetComponent<CreateMove>();

        const float sinVal = 0.04f;
        const float sinValMini = 0.02f;
        //switch文へ
        switch(moveType)
        {
            case MoveType.CarveMoveL:
                createMove.InitFunc(MoveClassName.CarveMove, go);

                go.GetComponent<CarveMove>().SetCarveVal(15f);

                createMove.CreateCarveMove(go.GetComponent<CarveMove>(), movePoint[0].position, go);
                break;

            case MoveType.CarveMoveR:
                createMove.InitFunc(MoveClassName.CarveMove, go);

                go.GetComponent<CarveMove>().SetCarveVal(-15f);

                createMove.CreateCarveMove(go.GetComponent<CarveMove>(), movePoint[0].position, go);
                break;

            case MoveType.PointFloatMove:
                createMove.InitFunc(MoveType.PointFloatMove, go);

                //トレイルサウンド用
                var seObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, go.transform);
                seObj.GetComponent<AudioSource>().Play();

                var pFloatMove = go.GetComponent<PointFloatMove>();
                pFloatMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool =>
                {
                    const float fadeSpeed = 1f;//1秒で止まる
                    seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);
                    //const float fadeSpeed = 0.001f;
                    //StartCoroutine(MyLib.SoundFadeOffCoroutine(seObj.GetComponent<AudioSource>(), fadeSpeed));
                });
                //

                createMove.CreatePointFloatMove(pFloatMove, movePoint, go);
                break;

            case MoveType.FloatVectorMoveUp:
                createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = Time.deltaTime;

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinVal);
                break;

            case MoveType.FloatVectorMoveDown:
                createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = -Time.deltaTime;


                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinVal);
                break;

            case MoveType.FloatVectorMoveUpMini:
                createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = Time.deltaTime;

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinValMini);
                break;

            case MoveType.FloatVectorMoveDownMini:
                createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = -Time.deltaTime;

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinValMini);
                break;

            case MoveType.DirectionMove:
                createMove.InitFunc(MoveType.DirectionMove, go);

                const float randSpdRange = 0.8f;
                float randSpdVal = UnityEngine.Random.Range(0, randSpdRange);
                go.GetComponent<DirectionMove>().speed += randSpdVal;

                go.GetComponent<DirectionMove>().TargetSet(movePoint[0].position);


                //go.transform.rotation = Quaternion.FromToRotation(Vector3.up, movePoint[0].position);


                break;

            case MoveType.PointCircleMove:
                createMove.InitFunc(MoveType.PointCircleMove, go);

                //トレイルサウンド用
                var seCircleObj = Instantiate(trailSe, trailSe.transform.position, Quaternion.identity, go.transform);
                seCircleObj.GetComponent<AudioSource>().Play();

                var pCircleMove = go.GetComponent<PointCircleMove>();
                pCircleMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool =>
                {
                    const float fadeSpeed = 1f;//1秒で止まる
                    seCircleObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

                });
                //

                createMove.CreatePointCircleMove(pCircleMove, movePoint, go);
                break;

            default:
                Debug.Log("MoveTypeDEFAULT");
                break;
        }

    }

}
