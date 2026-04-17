using System.Collections;
using System.Xml;
using UnityEngine;

public class EnemySpawnPrefabRepeat : BaseSpawn
{
    [SerializeField] GameObject loadObj;

    [SerializeField] float deadTime = 0f;
    float reSpawnTimer = 0f;


    //[SerializeField] SpawnWaveDataPrefab[] spawnData;


    void Start()
    {
        //最初のスポーン　エリアか時間で生成するようにする？
        //Spawn();
        reSpawnTimer = deadTime;
    }

    //public void SpawnWaveTime(int No)
    //{
    //    StartCoroutine(MyLib.DelayCoroutine(notifyTime, () =>
    //    {
    //        Spawn(No);
    //        Debug.Log(gameObject.name+"スポーン");
    //    }));

    //}

    private void Update()
    {
        reSpawnTimer-= Time.deltaTime;

        if(reSpawnTimer <= 0f)
        {
            var obj = Instantiate(loadObj, transform.position, transform.rotation);
            var timeDestroy = obj.AddComponent<TimeDestroy>();
            timeDestroy.deadTime = deadTime;
            reSpawnTimer = deadTime;
        }
    }



    //public override void Spawn(int No = 0)
    //{

    //    //if (GameMgr.I.IsSceneName(GameMgr.SceneNameType.GameScene.ToString()))
    //    GameSceneControl.I.CountUp(spawnData[No].LoadState.Length);

    //    //1回目以降
    //    //while (true)
    //    //{
    //    StartCoroutine(DelaySpawnWave(
    //        spawnData[No].spawnTime[spawnData[No].enemyCount], /** spawnData[No].enemyCount + 1*///float型　生成時間

    //        spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

    //        spawnData[No].spawnLocations[spawnData[No].enemyCount]//生成座標
    //                                                              //spawnData[No].movePointsSet[spawnData[No].enemyCount].childArray//目標座標
    //        ));


    //    // break;
    //    //spawnData[No].enemyCount++;
    //    //if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
    //    //    break;

    //    //}

    //}

    //public IEnumerator DelaySpawnWave(float seconds, GameObject loadState, Transform spawnTrans)
    //{
    //    yield return new WaitForSeconds(seconds);

    //    var obj = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);

    //    //var notify = obj.AddComponent<NotifyDead>();
    //    //notify.spawnObj = gameObject;
    //    var tDes = obj.AddComponent<TimeDestroy>();
    //    tDes.deadTime = objDeadTime;
    //    //reSpawnTimer = objDeadTime;
    //    //notify.spawnTime = notifyTime;
    //}


}
