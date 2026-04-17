using System.Collections;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public enum ObjLoadState
    {
        NULLPumpkin,

    }

    public ObjSpawnData[] spawnData;
    //ボスかどうか
    //
    ////この敵たちが倒されたら　範囲外に出たら破棄する？　スポーンする　登録方法を考える

    //int CountIndex = 0;
    //public void UpdateCount()
    //{
    //    spawnData[CountIndex].enemyCount--;
    //}

    //インデックス使用　関数
    //アップキャスト
    void Start()
    {
        for (int i = 0; i < spawnData.Length; i++)
            SpawnObj(i);

        //SpawnStart(i);

    }

    void SpawnStart(int idx)
    {
        //if (idx > 0)
        //{
        //    CountSpawnAsyncWave(idx).Forget();
        //    return;
        //}

        SpawnObj(idx);
    }

    void SpawnObj(int No)
    {

        //1回目以降
        while (true)
        {

            StartCoroutine(DelaySpawnWave
            (spawnData[No].spawnTime[spawnData[No].Count] * spawnData[No].Count + 1,//float型

            spawnData[No].ObjState[spawnData[No].Count],//ステート

            transform.position//spawnData[No].spawnLocations[spawnData[No].Count].position//生成座標
            ));

            spawnData[No].Count++;
            if (spawnData[No].Count >= spawnData[No].ObjState.Length)
                break;

        }

    }

    //void Update()
    //{
       
    //}

    //public void ResetEnemySpawn()
    //{
    //    //spawnData[0].enemyCount = 0;
    //    //colTrigger.isActiveTrigger = false;
    //}

    public IEnumerator DelaySpawnWave(float seconds, GameObject loadObj, Vector3 spawnPos)
    {

        yield return new WaitForSeconds(seconds);

        //オブジェクトマネージャーに変更する？
        //var eData = EnemyMgr.I.GetEnemyData(loadState.ToString());

        Instantiate(loadObj, spawnPos, transform.rotation);

    }
}
