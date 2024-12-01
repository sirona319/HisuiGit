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
    #region //

    //BaseJerryEnemyFactory _factory = null;

    ////Transform startT;
    //Transform[] targetPosArray;

    ////public JerryBuilder(BaseJerryEnemyFactory factory)
    ////{
    ////    _factory = factory;
    ////}

    //public void Init(BaseJerryEnemyFactory factory)
    //{
    //    _factory = factory;

    //}

    //public void InitData(Transform[] point)
    //{
    //    targetPosArray = point;
    //}

    //var enemy = _factory.Load(s);

    //enemy.enemyData = _factory.SetData();

    //enemy.baseMagazine = _factory.SetMagazine();

    //enemy.baseMove = _factory.SetMove(targetPosArray);

    ////foreach (var move in enemy.baseMove)
    ////   move.SetRb(enemy.GetComponent<Rigidbody2D>());

    //enemy.Hp = _factory.SetMaxHp();

    #endregion

    //float speed = 7;

    [SerializeField] GameObject jerryGo;//= "prefab/Enemy/Jerry/NormalJerry";

    //[SerializeField] string trailSePath = "prefab/Sound/JerryTrailSe";
    [SerializeField] GameObject trailSe;


    [SerializeField] GameObject bulletGo;//= "prefab/Bullet/JerryBullet";
    //[SerializeField] string bulletSePath = "Sound/Se/JerryShot";
    [SerializeField] AudioResource bulletSe;

    //[SerializeField] AudioResource ar;
    // [SerializeField] AudioSource ass;
    //[SerializeField] AudioClip ac;

    public override void Build(EnemyData eData, Transform s, Transform[] movePoint)
    {
        //"prefab/Bullet/JerryBullet"
        //var loadObj = (GameObject)Resources.Load(jerryPath);
        var enemy = Instantiate(jerryGo, s.position, s.rotation);

        ////トレイルse用オブジェクト生成
        trailSe = (GameObject)Resources.Load("prefab/Sound/JerryTrailSe");
        trailSe.transform.position = s.position;

        //var seObj = Instantiate(se, se.transform.position, Quaternion.identity, enemy.transform);
        //trailSe = seObj.GetComponent<AudioSource>();

        var eBase = enemy.GetComponent<EnemyBase>();
        const float randAtkRange = 0.5f;
        float randAtkVal = UnityEngine.Random.Range(-randAtkRange, randAtkRange);
        eBase.AtkInterval = eData.AtkIntervalMax+ randAtkVal;

        eBase.Hp = eData.HpMax;

        GetComponent<CreateMagazine>().SetBullet(bulletGo, bulletSe);//SeとPrefab設定
        GetComponent<CreateMagazine>().MagazineCreateInit
            (eData.magazineType,eData.bulletType, enemy,eData.bulletTarget);


        SelectCreateMove(eData.moveType[0], movePoint, enemy);


        //GetComponent<CreateMove>().SetTraileSe(trailSe);
        //GetComponent<CreateMove>().MoveCreateInit(eData, movePoint, enemy);


        eBase.enemyData = eData;
    }


    void SelectCreateMove(MoveType moveType, Transform[] movePoint, GameObject go)
    {
        //var eBase = go.GetComponent<EnemyBase>();

        var createMove=GetComponent<CreateMove>();

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

            case MoveType.FloatVectorMove:
                createMove.InitFunc(MoveType.FloatVectorMove, go);

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go);
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
