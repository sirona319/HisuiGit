using UnityEngine;


[System.Serializable]
public class SpawnWaveDataPrefab
{
    public string DataName = "WAVE";

    public int enemyCount = 0;

    public float[] spawnTime; //生成タイム

    public GameObject[] LoadState;

    public Transform[] spawnLocations;//生成位置


}

//シリアライズされた子要素クラス
//[System.Serializable]
//public class ChildTrans
//{
//    public Transform[] childArray;
//}
