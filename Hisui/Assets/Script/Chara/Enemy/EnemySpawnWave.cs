using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnemySpawnWave: MonoBehaviour
{
    public SpawnWaveData[] spawnData;

    //ボスかどうか
    //
    ////この敵たちが倒されたら　範囲外に出たら破棄する？　スポーンする　登録方法を考える
    //public GameObject[] triggerEnemys; 

    //public GameObject[] spawns; //敵　生成位置

    //public GameObject[] spawnLocations;//敵の移動範囲　位置

    const float SPWNTIME = 1f; //敵の生成タイム設定できるようにする
                               //public ChildTrans[] movePointsSet;

    //public int enemyCount = 0;

    //ParticleSystem spawnParticle;//パーティクル

    //[SerializeField] bool playerLengeSpawn = false;
    //[SerializeField] CollisionTrigger colTrigger;

    //int enemyCount = 0;

    int CountIndex = 0;
    public void UpdateCount()
    {
        spawnData[CountIndex].enemyCount--;
    }


    //インデックス使用　関数
    //アップキャスト
    void Start()
    {
        for(int i=0; i < spawnData.Length;i++)
        EnemysWaveStart(i);

        //spawnParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyCFXR Magic Poof");

        //if (spawnData[0].spawns.Length != spawnData[0].spawnLocations.Length)
        //{

        //    throw new System.Exception("生成する敵の移動基点座標が全て指定されていない");
        //    //Debug.Log("生成する敵の移動基点座標が全て指定されていない");
        //}


        ////if (spawns == null) return;

        //if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
        //    GameSceneControl.I.enemyAllCount += spawnData[0].spawns.Length;


        ////if (spawnData[0].triggerEnemys.Length <= 0)
        ////{
        ////    var enemy = Instantiate(spawns[enemyCount], transform.position, Quaternion.identity);
        ////    //enemy.GetComponent<EnemyBase>().basePosition = spawnLocations[enemyCount].transform.position;

        ////    return;
        ////}
        ////Instantiate(spawnData[0].spawns[enemyCount], transform.position, Quaternion.identity);

        ////if (!colTrigger.isActiveTrigger) return;

        //////if (spawns.Length> 0)
        //// //{

        ////1回目はenemyCountは0から始まる
        //while (true)
        //{
        //    DelaySpawnAsyncWave
        //        (SPWNTIME* spawnData[0].enemyCount +1,
        //        spawnData[0].spawns[spawnData[0].enemyCount],
        //        //spawnData[0].spawnLocations[enemyCount].
        //        //transform.position,
        //        spawnData[0].movePointsSet[spawnData[0].enemyCount].childArray
        //        ).Forget();

        //    // 生成ディレイコルーチンの起動
        //    //StartCoroutine(DelaySpawnCoroutineWave
        //    //   (SPWNTIME * enemyCount + 1, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

        //    spawnData[0].enemyCount++;
        //    if (spawnData[0].enemyCount >= spawnData[0].spawns.Length)
        //        break;

        //}

        ////}

    }

    void EnemysWaveStart(int idx)
    {
        if(idx>0)
        {
            CountSpawnAsyncWave(idx).Forget();
            return;
        }

        SpawnWave(idx);
    }

    void SpawnWave(int No)
    {
        if (spawnData[No].spawns.Length != spawnData[No].spawnLocations.Length)
        {

            throw new System.Exception("生成する敵の移動基点座標が全て指定されていない");
            //Debug.Log("生成する敵の移動基点座標が全て指定されていない");
        }

        //if(spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray==null)
        //{
        //    throw new System.Exception("移動先が指定されていない");
        //}


        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.enemyAllCount += spawnData[No].spawns.Length;



        //1回目以降
        while (true)
        {
            DelaySpawnAsyncWave
                (SPWNTIME * spawnData[No].enemyCount + 1,
                spawnData[No].spawns[spawnData[No].enemyCount],
                spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray
                ).Forget();

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].spawns.Length)
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!playerLengeSpawn) return;
    //    if (other.transform.CompareTag("Player"))
    //    {
    //        while (true)
    //        {
    //            // 生成ディレイコルーチンの起動
    //            StartCoroutine(DelaySpawnCoroutine
    //                (SPWNTIME * enemyCount + 1, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

    //            enemyCount++;
    //            if (enemyCount >= spawns.Length)
    //                break;

    //        }

    //    }

    //}

    public async UniTask DelaySpawnAsyncWave(float seconds, GameObject obj,Transform[] movePoint)
    {


        await UniTask.WaitForSeconds(seconds);
        //Instantiate(spawnParticle, transform.position, Quaternion.identity);//パーティクル
        //Instantiate(obj, transform.position, Quaternion.identity);
        GameObject enemy;
        //if (obj.name.Contains("MoveCircle"))
        //{
        //    var playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        //    enemy = Instantiate(obj, transform.position, Quaternion.identity, playerTrans);
        //}

        //else
        //var playerTrans = GameObject.FindGameObjectWithTag("Player").transform;



        enemy = Instantiate(obj, transform.position, Quaternion.identity);




        //enemy.GetComponent<EnemyBase>().basePosition = bPos;

        enemy.GetComponent<EnemyBase>().findName = obj.name;

        enemy.GetComponent<EnemyBase>().movePointsDatas = movePoint;

    }

    //public IEnumerator DelaySpawnCoroutineWave(float seconds, GameObject obj, Vector3 bPos)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    //Instantiate(spawnParticle, transform.position, Quaternion.identity);//パーティクル
    //    //Instantiate(obj, transform.position, Quaternion.identity);

    //    var enemy = Instantiate(obj, transform.position, Quaternion.identity);
    //    enemy.GetComponent<EnemyBase>().basePosition = bPos;

    //    enemy.GetComponent<EnemyBase>().findName = obj.name;

    //}
}
