using UnityEngine;

//[System.Serializable]
//public class SpawnWaveData
//{
//    public string DataName = "WAVE";

//    public int enemyCount = 0;

//    public float[] spawnTime; //敵の生成タイム設定できるようにする

//    //この敵たちが倒されたら　範囲外に出たら破棄する？　スポーンする　登録方法を考える
//    //public GameObject[] triggerEnemys;

//    public EnemySpawnWave.LoadState[] LoadObj;
//    //public GameObject[] spawns; //敵　生成位置

//    public Transform[] spawnLocations;//敵の移動範囲　位置

//    //public float SPWNTIME = 2f; //敵の生成タイム設定できるようにする

//    public ChildTrans[] movePointsSet;

//}

[System.Serializable]
public class SpawnWaveDataPrefab
{
    public string DataName = "WAVE";

    public int enemyCount = 0;

    public float[] spawnTime; //敵の生成タイム設定できるようにする


    public GameObject[] LoadState;

    public Transform[] spawnLocations;//敵の移動範囲　位置

    public ChildTrans[] movePointsSet;

}

[System.Serializable]
public class ObjSpawnData
{
    public string DataName = "ObjSpwan";

    public int Count = 0;

    public float[] spawnTime; //生成タイム設定できるようにする

    public GameObject[] ObjState;

    public Transform[] spawnLocations;//敵の移動範囲　位置
}

//シリアライズされた子要素クラス
[System.Serializable]
public class ChildTrans
{
    public Transform[] childArray;
}
