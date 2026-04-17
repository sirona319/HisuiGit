using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnWavePrefab : BaseSpawn
{
    //[SerializeField] JerryBuilder jerryBuilder;
    //[SerializeField] GameObject trailSe;


    [SerializeField] SpawnWaveDataPrefab[] spawnData;

    [SerializeField] GameObject saveGo;

    EnemyMgr EnemyM;
    //int CountIndex = 0;

    //public void UpdateCount()
    //{
    //    spawnData[CountIndex].enemyCount--;

    //    if (spawnData[CountIndex].enemyCount <= 0)
    //    {
    //        CountIndex++;
    //        if (CountIndex == spawnData.Length)
    //            return;

    //        SpawnWave(CountIndex);

    //    }
    //}

    void Start()
    {
        EnemyM = GameObject.FindGameObjectWithTag("EnemyM").GetComponent<EnemyMgr>();


        Spawn(0);
    }

    //void EnemysWaveStart(int idx)
    //{
    //    SpawnWave(idx);
    //}
    public void Spawn(int No)
    {
        EnemyM.CountUp(spawnData[No].LoadState.Length);

        StartCoroutine(DelaySpawnWave(
            spawnData[No].spawnTime[spawnData[No].enemyCount], /** spawnData[No].enemyCount + 1*///float型　生成時間

            spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

            spawnData[No].spawnLocations[spawnData[No].enemyCount]//生成座標
                                                                  //spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
            ));
    }

    void SpawnWave(int No)
    {

        //if (GameMgr.I.IsSceneName(GameMgr.SceneNameType.GameScene.ToString()))
        EnemyM.CountUp(spawnData[No].LoadState.Length);

        //1回目以降
        while (true)
        {
            StartCoroutine(DelaySpawnWave(
                spawnData[No].spawnTime[spawnData[No].enemyCount], /** spawnData[No].enemyCount + 1*///float型　生成時間

                spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

                spawnData[No].spawnLocations[spawnData[No].enemyCount]//生成座標
                                                                      //spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
                ));
            //DelaySpawnAsyncWave
            //    (spawnData[No].spawnTime[spawnData[No].enemyCount] /** spawnData[No].enemyCount + 1*/,//float型　生成時間

            //    spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類


            //    spawnData[No].spawnLocations[spawnData[No].enemyCount],//生成座標
            //    spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
            //    ).Forget();

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
                break;

        }

    }


    public IEnumerator DelaySpawnWave(float seconds, GameObject loadState, Transform spawnTrans/*, Transform[] movePoint*/)
    {
        yield return new WaitForSeconds(seconds);

        saveGo = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);


        //obj.GetComponent<EnemyBase>().Init();
        //bMove.Initialize();

        //SelectCreateMoveJerry(obj.GetComponent<EnemyBase>().baseMove[0].GetType().FullName, movePoint, obj);
        //SelectCreateMoveJerry(obj.GetComponent<EnemyBase>().move, obj);
    }

    public void DeadCheck()
    {
        //if (SceneManager.GetActiveScene().name.Contains("boss"))
        //{
        //    if (saveGo.CompareTag(TagName.EnemyBoss))
        //    {
        //        //敵全部を破棄　生成
        //        EnemyM.EnemyClearAll();
        //        //EnemyMgr.I.EnemyClearAll();
        //        Spawn(0);
        //        return;
        //    }
        //}

        //if(saveGo == null) return;
        if (!saveGo.GetComponent<CharaBase>().isDead) return;

        //破棄と生成
        Destroy(saveGo);
        Spawn(0);

    }

    public override void DeadNotice()
    {
        //Debug.Log();
        //Debug.Log("0");
        if (!saveGo.GetComponent<CharaBase>().isDead) return;

        //破棄と生成
        Destroy(saveGo);
        Spawn(0);
    }

    //public bool DeadCheck()
    //{
    //    if (saveGo.GetComponent<EnemyBase>().isDead)
    //        return true;

    //    return false;
    //}


    //public async UniTask DelaySpawnAsyncWave(float seconds, GameObject loadState, Transform spawnTrans, Transform[] movePoint)
    //{
    //    await UniTask.WaitForSeconds(seconds);

    //    var obj = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);


    //    SelectCreateMoveJerry(obj.GetComponent<EnemyBase>().baseMove[0].GetType().FullName, movePoint, obj);

    //}

    //ムーブ設定
    //void SelectCreateMoveJerry(BaseMove moveType, GameObject go)
    //{
    //    switch (moveType)
    //    {
    //        case PlayerAttackPointMove:

    //            //go.GetComponent<PlayerAttackPointMove>().Initialize();

    //           // go.GetComponent<PlayerAttackPointMove>().point.movePointSet(movePoint);

    //            go.GetComponent<PlayerAttackPointMove>().playerAttack.TargetSet(GameObject.FindGameObjectWithTag(TagName.Player).transform);

    //            break;


    //        default:
    //            //go.GetComponent<EnemyBase>().baseMove[0].Initialize();

    //            //Debug.Log("MoveTypeDEFAULT");
    //            break;
    //    }

    //}

}
