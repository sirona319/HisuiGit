using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using UnityEngine;
using static BaseMove;
using static CreateBullet;
using static EnemySpawnWave;
using static UnityEngine.ParticleSystem;

public class EnemySpawnWavePrefab : MonoBehaviour
{
    [SerializeField] JerryBuilder jerryBuilder;

    public SpawnWaveDataPrefab[] spawnData;

    int CountIndex = 0;

    //[SerializeField] GameObject trailSe;
    public void UpdateCount()
    {
        spawnData[CountIndex].enemyCount--;

        if (spawnData[CountIndex].enemyCount <= 0)
        {
            CountIndex++;
            if (CountIndex == spawnData.Length)
                return;

            EnemysWaveStart(CountIndex);

        }
    }

    void Start()
    {
        EnemysWaveStart(0);

    }

    void EnemysWaveStart(int idx)
    {

        SpawnWave(idx);
    }

    void SpawnWave(int No)
    {

        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.enemyAllCount += spawnData[No].LoadState.Length;



        //1回目以降
        while (true)
        {
            DelaySpawnAsyncWave
                (spawnData[No].spawnTime[spawnData[No].enemyCount] /** spawnData[No].enemyCount + 1*/,//float型　生成時間

                spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類


                spawnData[No].spawnLocations[spawnData[No].enemyCount],//生成座標
                spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
                ).Forget();

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
                break;

        }

    }


    void Update()
    {
    }

    public void ResetEnemySpawn()
    {

    }

    public async UniTask DelaySpawnAsyncWave(float seconds, GameObject loadState, Transform spawnTrans, Transform[] movePoint)
    {
        await UniTask.WaitForSeconds(seconds);

        var obj = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);

        foreach (var m in obj.GetComponent<EnemyBase>().baseMove)
        {
            //var it = m as ITargets;
            //if (it != null)
            //{
            //    Debug.Log("成功　");
            //    it.targets = movePoint;
            //}
            m.Initialize(obj.GetComponent<Rigidbody2D>());
        }

        foreach (var mag in obj.GetComponent<EnemyBase>().baseMagazine)
        {
            //magazine.BulletLoad("prefab/EBulletNormalEX");
            mag.Initialize();

            
            //ターゲットを設定プレイヤー　エネミー用？
            var t = mag as ITarget;
            mag.TargetSet(t, mag.bulletTarget, obj);

        }

        //obj.GetComponent<EnemyBase>().PrefabInit();

        obj.GetComponent<CreateBullet>().poolManager = jerryBuilder.GetComponent<PoolControl>();
        //TargetSet(t, bulletTarget, go);
        //var eData = EnemyManager.I.GetEnemyData(loadState.ToString());

        //if (eData.builderType == EnemyData.BuilderType.JERRY)
        //{
        //    jerryBuilder.Build(eData, spawnTrans, movePoint);
        //}

        if (obj.name.Contains("Jerry"))
        {
            //Debug.Log(obj.GetComponent<EnemyBase>().baseMove[0].GetType().FullName);
            SelectCreateMoveJerry(obj.GetComponent<EnemyBase>().baseMove[0].GetType().FullName, movePoint, obj);
        }

    }

    //ムーブ設定
    void SelectCreateMoveJerry(string moveType, Transform[] movePoint, GameObject go)
    {

        var createMove = jerryBuilder.GetComponent<CreateMove>();

        const float sinVal = 0.04f;
        const float sinValMini = 0.02f;

        var trailSe=jerryBuilder.GetTrailSe;
        //switch文へ
        switch (moveType)
        {
            case "CarveMoveL":
                //createMove.InitFunc(MoveClassName.CarveMove, go);

                go.GetComponent<CarveMove>().SetCarveVal(15f);

                createMove.CreateCarveMove(go.GetComponent<CarveMove>(), movePoint[0].position, go);
                break;

            case "CarveMoveR":
                createMove.InitFunc(MoveClassName.CarveMove, go);

                go.GetComponent<CarveMove>().SetCarveVal(-15f);

                createMove.CreateCarveMove(go.GetComponent<CarveMove>(), movePoint[0].position, go);
                break;

            case "PointFloatMove":
                //createMove.InitFunc(MoveType.PointFloatMove, go);

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

            case "FloatVectorMoveUp":
                //createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = Time.deltaTime;

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinVal);
                break;

            case "FloatVectorMoveDown":
                //createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = -Time.deltaTime;


                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinVal);
                break;

            case "FloatVectorMoveUpMini":
                //createMove.InitFunc(MoveClassName.FloatVectorMove, go);
                //Debug.Log(MoveType.FloatVectorMoveUpMini.ToString());
                go.GetComponent<FloatVectorMove>().addSinTime = Time.deltaTime;

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinValMini);
                break;

            case "FloatVectorMoveDownMini":
                createMove.InitFunc(MoveClassName.FloatVectorMove, go);

                go.GetComponent<FloatVectorMove>().addSinTime = -Time.deltaTime;

                createMove.CreateFloatVectorMove(go.GetComponent<FloatVectorMove>(), movePoint[0].position, go, sinValMini);
                break;

            case "DirectionMove":
                //createMove.InitFunc(MoveType.DirectionMove, go);

                const float randSpdRange = 0.8f;
                float randSpdVal = UnityEngine.Random.Range(0, randSpdRange);
                go.GetComponent<DirectionMove>().speed += randSpdVal;

                go.GetComponent<DirectionMove>().TargetSet(movePoint[0].position);


                //go.transform.rotation = Quaternion.FromToRotation(Vector3.up, movePoint[0].position);


                break;

            case "PointCircleMove":
                //createMove.InitFunc(MoveType.PointCircleMove, go);

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
