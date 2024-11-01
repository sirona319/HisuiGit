using System.Collections;
using UnityEngine;

public class EnemySpawnErea : MonoBehaviour
{
    //ボスかどうか
    //

    [SerializeField] GameObject[] spawns; //敵　生成位置

    [SerializeField] GameObject[] spawnLocations;//敵の移動範囲　位置

    int enemyCount = 0;

    [SerializeField] float SPWNTIME = 2f;　//敵の生成タイム設定できるようにする？Playerがエリアに入ってから

    //ParticleSystem spawnParticle;//パーティクル

    //[SerializeField] bool playerLengeSpawn = false;
    [SerializeField] CollisionTrigger colTrigger;


    // Start is called before the first frame update
    void Start()
    {
        //spawnParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyCFXR Magic Poof");

        if (spawns.Length != spawnLocations.Length)
        {

            throw new System.Exception("生成する敵の移動基点座標が全て指定されていない");
            //Debug.Log("生成する敵の移動基点座標が全て指定されていない");
        }


        //if (spawns == null) return;

        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.enemyAllCount += spawns.Length;


        if (!colTrigger.isActiveTrigger) return;

        //if (spawns.Length> 0)
        //{
        while (true)
        {
            // 生成ディレイコルーチンの起動
            StartCoroutine(DelaySpawnCoroutine
                (SPWNTIME * enemyCount + 1, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

            enemyCount++;
            if (enemyCount >= spawns.Length)
                break;

        }

        //}

    }

    void Update()
    {
        if (!colTrigger.isActiveTrigger) return;
        //if (other.transform.CompareTag("Player"))
        //{

        //if (enemyCount >= spawns.Length)
        //  return;

        while (true)
        {
            if (enemyCount >= spawns.Length)
                break;
            // 生成ディレイコルーチンの起動
            StartCoroutine(DelaySpawnCoroutine
                (SPWNTIME * enemyCount + 1, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

            enemyCount++;


        }

        //}

    }

    public void ResetEnemySpawn()
    {
        enemyCount = 0;
        colTrigger.isActiveTrigger = false;
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

    public IEnumerator DelaySpawnCoroutine(float seconds, GameObject obj, Vector3 bPos)
    {
        yield return new WaitForSeconds(seconds);
        //Instantiate(spawnParticle, transform.position, Quaternion.identity);//パーティクル
        //Instantiate(obj, transform.position, Quaternion.identity);

        var enemy = Instantiate(obj, transform.position, Quaternion.identity);
        //enemy.GetComponent<EnemyBase>().basePosition = bPos;

    }

}
