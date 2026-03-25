using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawnWavePrefab : MonoBehaviour
{
    [SerializeField] PoolControl poolMgr;

    public SpawnWaveDataPrefab[] spawnData;

    int CountIndex = 0;

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

        GameObject.FindWithTag("EnemyMgr").GetComponent<EnemyMgr>().CountUp(spawnData[No].LoadState.Length);

        while (true)
        {
            StartCoroutine(DelaySpawnWavePrefab(
                spawnData[No].spawnTime[spawnData[No].enemyCount], /** spawnData[No].enemyCount + 1*///float型　生成時間

                spawnData[No].LoadState[spawnData[No].enemyCount],//敵の種類

                spawnData[No].spawnLocations[spawnData[No].enemyCount]//生成座標
           
                ));

            spawnData[No].enemyCount++;
            if (spawnData[No].enemyCount >= spawnData[No].LoadState.Length)
                break;

        }

    }

    public IEnumerator DelaySpawnWavePrefab(float seconds, GameObject loadState, Transform spawnTrans)
    {
        yield return new WaitForSeconds(seconds);

        var obj = Instantiate(loadState, spawnTrans.position, spawnTrans.rotation);

        obj.GetComponent<EnemyBase>().Init();

    }

}
