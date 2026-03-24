
using UnityEngine;

public class NotifyDead : MonoBehaviour
{
    public GameObject spawnObj;

    public float spawntime;

    //public float spawnTime = 0f;

    private void OnDestroy()
    {
        //オブジェクトが死んだら再生成させる　継承させる？　時間差付ける？
        //spawnObj.GetComponent<EnemySpawnPrefabRepeat>().SpawnWaveTime(0);
    }
}

