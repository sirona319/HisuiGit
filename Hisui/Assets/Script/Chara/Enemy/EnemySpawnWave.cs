using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static BaseEnemyFactory;
using System;

public class EnemySpawnWave : MonoBehaviour
{
    public enum LoadState
    {
        NormalJerry,
        FiveJerry,
        CircleJerry,
        CircleOneJerry,


        CircleMoveJerry


    }

    public SpawnWaveData[] spawnData;

    //[SerializeField] PoolManager poolManager;

    //ボスかどうか
    ////この敵たちが倒されたら　範囲外に出たら破棄する？　スポーンする　登録方法を考える
    //public GameObject[] triggerEnemys; 

    int CountIndex = 0;
    public void UpdateCount()
    {
        spawnData[CountIndex].enemyCount--;
    }


    //インデックス使用　関数
    //アップキャスト
    void Start()
    {
        for (int i = 0; i < spawnData.Length; i++)
            EnemysWaveStart(i);

    }

    void EnemysWaveStart(int idx)
    {
        if (idx > 0)
        {
            CountSpawnAsyncWave(idx).Forget();
            return;
        }

        SpawnWave(idx);
    }

    void SpawnWave(int No)
    {
        //if (spawnData[No].spawns.Length != spawnData[No].spawnLocations.Length)
        //{

        //    throw new System.Exception("生成する敵の移動基点座標が全て指定されていない");
        //    //Debug.Log("生成する敵の移動基点座標が全て指定されていない");
        //}

        //if(spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray==null)
        //{
        //    throw new System.Exception("移動先が指定されていない");
        //}


        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.enemyAllCount += spawnData[No].LoadState.Length;



        //1回目以降
        while (true)
        {
            DelaySpawnAsyncWave
                (spawnData[No].spawnTime[spawnData[No].enemyCount] * spawnData[No].enemyCount + 1,//float型

                spawnData[No].LoadState[spawnData[No].enemyCount],//ステート

                //spawnData[No].spawns[spawnData[No].enemyCount],
                spawnData[No].spawnLocations[spawnData[No].enemyCount],//生成座標
                spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
                ).Forget();

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
                break;

        }

    }

    public async UniTask CountSpawnAsyncWave(int No)
    {
        await UniTask.WaitUntil(() => spawnData[No - 1].enemyCount <= 0);

        SpawnWave(No);
        CountIndex++;
    }


    void Update()
    {
        //bool isEnemyAllLost = false;
        //foreach (GameObject enemy in triggerEnemys)
        //{
        //    isEnemyAllLost=enemy.activeInHierarchy;
        //}

        //if (!isEnemyAllLost)
        //    return;

        ////if (!colTrigger.isActiveTrigger) return;
        ////if (other.transform.CompareTag("Player"))
        ////{

        ////if (enemyCount >= spawns.Length)
        ////  return;

        ////時間を間隔を開けて生成する？
        //while (true)
        //{
        //    if (enemyCount >= spawns.Length)
        //        break;

        //    DelaySpawnAsyncWave
        //        (SPWNTIME, spawns[enemyCount], spawnLocations[enemyCount].transform.position).Forget();


        //    // 生成ディレイコルーチンの起動
        //    //StartCoroutine(DelaySpawnCoroutineWave
        //    //    (SPWNTIME /** enemyCount + 1*/, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

        //    enemyCount++;


        //}

        //}

    }

    public void ResetEnemySpawn()
    {
        //spawnData[0].enemyCount = 0;



        //colTrigger.isActiveTrigger = false;
    }

    public async UniTask DelaySpawnAsyncWave(float seconds, LoadState loadState,Transform spawnTrans, Transform[] movePoint)
    {


        await UniTask.WaitForSeconds(seconds);

        //List<JerryBuilder>[] builders=new ();

        //JerryBuilder a=new(new JerryPointFactory());
        //JerryBuilder b=new(new JerryPointFactory()); ;

        // builders.AddRange(a);




        //string eName = loadState.ToString();
        //Type typeClass = Type.GetType(eName+"Factory");
        //var bFac = typeClass.ConvertTo<BaseJerryEnemyFactory>();

        //JerryBuilder builder=GetComponent<JerryBuilder>();
        //builder.Init(gameObject.GetComponent<JerryPointFactory>());

        //builder.InitData(movePoint);

        //builder.Build(spawnTrans);


        ////BaseEnemyFactory enemyFactory;
        //if(loadState==FactoryState.JerryPointFactory)
        //{
        //    eObj = (JerryPointFactory)eObj;
        //}
        ////JerryScr eBase = eObj.Load();
        ////JerryState.PointJerryFactory


        //Factory Builder
        /////////////////////
        var eData = EnemyManager.I.GetEnemyData(loadState.ToString());

        var bBuilder = eData.builder.GetComponent<BaseBuilder>();
        bBuilder.Build(eData, spawnTrans, movePoint, GetComponent<PoolManager>());


        //var enemy = Instantiate(eData.go, spawnTrans.position, Quaternion.identity);
        //var eBase = enemy.GetComponent<EnemyBase>();

        ////eBase.movePointsDatas = movePoint;//nullになる場合？
        //eBase.Hp = eData.HpMax;

        ////eBase.pool = poolManager;


        ////baseMagazine初期化　　攻撃クラスに持っていく？
        //for (int i = 0; i < (int)eData.attackType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(eData.attackType[i].ToString());

        //    if (typeClass != null)
        //        eBase.baseMagazine.Add((BaseMagazine)enemy.AddComponent(typeClass));

        //}

        //foreach (var magazine in eBase.baseMagazine)
        //{
        //    //magazine.BulletLoad("prefab/EBulletNormalEX");
        //    magazine.Initialize();
        //    magazine.BulletLoad("prefab/Bullet/JerryBullet");

        //    magazine.SetPool(poolManager);
        //}

        ////baseMove初期化　移動クラスに持っていく？
        //for (int i = 0; i < (int)eData.moveType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(eData.moveType[i].ToString());

        //    if (typeClass != null)
        //    {
        //        eBase.baseMove.Add((BaseMove)enemy.AddComponent(typeClass));
        //    }

        //}

        //foreach (var move in eBase.baseMove)
        //{
        //    //初期化
        //    move.Initialize(enemy.GetComponent<Rigidbody2D>());


        //    var movePointComp = move.GetComponent<IPointMove>();

        //    // の処理が必須
        //    if (movePointComp != null)
        //    {
        //        movePointComp.TargetSet(movePoint);
        //        movePointComp.SetMoveEndLength(eData.PointEndLength);
        //    }

        //}

        //eBase.enemyData = eData;
        //ステータスの初期化
        //Hp = eData.HpMax;
    }


    //public static JerryBuilder[] CreateLevel1EnemyBuilders()
    //{
    //    // Level1 は雑魚スケルトン3体
    //    return new JerryBuilder[]{
    //        JerryBuilder( new JerryPointFactory() );
    //    //JerryBuilder(new NormalSkeletonFactory());
    //    //JerryBuilder(new NormalSkeletonFactory());
    //}
}
