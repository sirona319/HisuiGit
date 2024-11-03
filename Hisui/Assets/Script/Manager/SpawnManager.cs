using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public EnemySpawnWave[] enemySpawns;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}





    public void ResetSpawns()
    {
        Debug.Log("敵のスポーンのリセット");

        foreach(var s in enemySpawns)
        {
            s.ResetEnemySpawn();
        }
    }
}
