using Cysharp.Threading.Tasks;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class EnemySpawnWave : MonoBehaviour
{
    //ボスかどうか
    //

    [SerializeField] GameObject[] triggerEnemys; //この敵たちが倒されたら　スポーンする　登録方法を考える

    [SerializeField] GameObject[] spawns; //敵　生成位置

    [SerializeField] GameObject[] spawnLocations;//敵の移動範囲　位置

    int enemyCount = 0;

    [SerializeField] float SPWNTIME = 2f;　//敵の生成タイム設定できるようにする

    //ParticleSystem spawnParticle;//パーティクル

    //[SerializeField] bool playerLengeSpawn = false;
    //[SerializeField] CollisionTrigger colTrigger;


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


        if(triggerEnemys==null)
        {
            var enemy = Instantiate(spawns[enemyCount], transform.position, Quaternion.identity);
            //enemy.GetComponent<EnemyBase>().basePosition = spawnLocations[enemyCount].transform.position;

            return;
        }


        //if (!colTrigger.isActiveTrigger) return;

        //if (spawns.Length> 0)
        //{
        while (true)
        {
            DelaySpawnAsyncWave
                (SPWNTIME * enemyCount + 1, spawns[enemyCount], spawnLocations[enemyCount].transform.position).Forget();

            // 生成ディレイコルーチンの起動
            //StartCoroutine(DelaySpawnCoroutineWave
            //   (SPWNTIME * enemyCount + 1, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

            enemyCount++;
            if (enemyCount >= spawns.Length)
                break;

        }

        //}

    }

    void Update()
    {
        bool isEnemyAllLost = false;
        foreach (GameObject enemy in triggerEnemys)
        {
            isEnemyAllLost=enemy.activeInHierarchy;
        }

        if (!isEnemyAllLost)
            return;

        //if (!colTrigger.isActiveTrigger) return;
        //if (other.transform.CompareTag("Player"))
        //{

        //if (enemyCount >= spawns.Length)
        //  return;

        //時間を間隔を開けて生成する？
        while (true)
        {
            if (enemyCount >= spawns.Length)
                break;

            DelaySpawnAsyncWave
                (SPWNTIME, spawns[enemyCount], spawnLocations[enemyCount].transform.position).Forget();


            // 生成ディレイコルーチンの起動
            //StartCoroutine(DelaySpawnCoroutineWave
            //    (SPWNTIME /** enemyCount + 1*/, spawns[enemyCount], spawnLocations[enemyCount].transform.position));

            enemyCount++;


        }

        //}

    }

    public void ResetEnemySpawn()
    {
        enemyCount = 0;
        //colTrigger.isActiveTrigger = false;
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

    public async UniTask DelaySpawnAsyncWave(float seconds, GameObject obj, Vector3 bPos)
    {
        await UniTask.WaitForSeconds(seconds);
        //Instantiate(spawnParticle, transform.position, Quaternion.identity);//パーティクル
        //Instantiate(obj, transform.position, Quaternion.identity);
        GameObject enemy;
        //if (obj.name.Contains("MoveCircle"))
        //{
        //    var playerTrans = GameObject.FindGameObjectWithTag("Player").transform;

        //    enemy = Instantiate(obj, transform.position, Quaternion.identity, playerTrans);
        //}

        //else
        //var playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = Instantiate(obj, transform.position, Quaternion.identity);


        //enemy.GetComponent<EnemyBase>().basePosition = bPos;

        enemy.GetComponent<EnemyBase>().findName = obj.name;

    }

    //public IEnumerator DelaySpawnCoroutineWave(float seconds, GameObject obj, Vector3 bPos)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    //Instantiate(spawnParticle, transform.position, Quaternion.identity);//パーティクル
    //    //Instantiate(obj, transform.position, Quaternion.identity);

    //    var enemy = Instantiate(obj, transform.position, Quaternion.identity);
    //    enemy.GetComponent<EnemyBase>().basePosition = bPos;

    //    enemy.GetComponent<EnemyBase>().findName = obj.name;

    //}
}
