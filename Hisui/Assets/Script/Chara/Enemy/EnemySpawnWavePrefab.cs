using Cysharp.Threading.Tasks;
using UnityEngine;
using static EnemySpawnWave;

public class EnemySpawnWavePrefab : MonoBehaviour
{
    [SerializeField] JerryBuilder jerryBuilder;

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


        var eData = EnemyManager.I.GetEnemyData(loadState.ToString());

        if (eData.builderType == EnemyData.BuilderType.JERRY)
        {
            jerryBuilder.Build(eData, spawnTrans, movePoint);
        }


    }
}
