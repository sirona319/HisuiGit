using Cysharp.Threading.Tasks;
using UnityEngine;
using static UnityEditor.ObjectChangeEventStream;

public class EnemySpawnWave : MonoBehaviour
{
    public enum LoadState
    {
        NormalJerry,
        FiveJerry,
        CircleJerry,
        CircleOneJerry,

        FloatVectorJerryUp,
        FloatVectorJerryDown,
        FloatVectorJerryUpMini,
        FloatVectorJerryDownMini,
        CircleMoveJerry,

        DirectionMoveJerry,
        //PlayerFallJerry,

    }

    //[SerializeField] JerryBuilder jerryBuilder;

    public SpawnWaveData[] spawnData;

    //[SerializeField] PoolManager poolManager;

    //ボスかどうか
    ////この敵たちが倒されたら　範囲外に出たら破棄する？　スポーンする　登録方法を考える
    //public GameObject[] triggerEnemys; 

    int CountIndex = 0;
    public void UpdateCount()
    {
        spawnData[CountIndex].enemyCount--;

        if(spawnData[CountIndex].enemyCount<=0)
        {
            CountIndex++;
            if (CountIndex == spawnData.Length)
                return;

            EnemysWaveStart(CountIndex);

        }
    }


    //インデックス使用　関数
    //アップキャスト
    void Start()
    {
        //for (int i = 0; i < spawnData.Length; i++)
            EnemysWaveStart(0);

    }

    void EnemysWaveStart(int idx)
    {
        //if (idx > 0)
        //{
        //    CountSpawnAsyncWave(idx).Forget();
        //    return;
        //}

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
                (spawnData[No].spawnTime[spawnData[No].enemyCount] /** spawnData[No].enemyCount + 1*/,//float型　生成時間

                spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

                //spawnData[No].spawns[spawnData[No].enemyCount],
                spawnData[No].spawnLocations[spawnData[No].enemyCount],//生成座標
                spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
                ).Forget();

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
                break;

        }

    }

    //public async UniTask CountSpawnAsyncWave(int No)
    //{
    //    await UniTask.WaitUntil(() => spawnData[No - 1].enemyCount <= 0);

    //    SpawnWave(No);
    //    CountIndex++;
    //}


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

        //string eName = loadState.ToString();
        //Type typeClass = Type.GetType(eName+"Factory");
        //var bFac = typeClass.ConvertTo<BaseJerryEnemyFactory>();


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

        if(eData.builderType == EnemyData.BuilderType.JERRY)
        {
            //jerryBuilder.Build(eData, spawnTrans, movePoint);
        }


    }

}
