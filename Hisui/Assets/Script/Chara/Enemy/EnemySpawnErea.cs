using System.Collections;
using UnityEngine;

public class EnemySpawnErea : MonoBehaviour
{
    //�{�X���ǂ���
    //

    [SerializeField] GameObject[] spawns; //�G�@�����ʒu

    [SerializeField] GameObject[] spawnLocations;//�G�̈ړ��͈́@�ʒu

    int enemyCount = 0;

    [SerializeField] float SPWNTIME = 2f;�@//�G�̐����^�C���ݒ�ł���悤�ɂ���HPlayer���G���A�ɓ����Ă���

    //ParticleSystem spawnParticle;//�p�[�e�B�N��

    //[SerializeField] bool playerLengeSpawn = false;
    [SerializeField] CollisionTrigger colTrigger;


    // Start is called before the first frame update
    void Start()
    {
        //spawnParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyCFXR Magic Poof");

        if (spawns.Length != spawnLocations.Length)
        {

            throw new System.Exception("��������G�̈ړ���_���W���S�Ďw�肳��Ă��Ȃ�");
            //Debug.Log("��������G�̈ړ���_���W���S�Ďw�肳��Ă��Ȃ�");
        }


        //if (spawns == null) return;

        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.enemyAllCount += spawns.Length;


        if (!colTrigger.isActiveTrigger) return;

        //if (spawns.Length> 0)
        //{
        while (true)
        {
            // �����f�B���C�R���[�`���̋N��
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
            // �����f�B���C�R���[�`���̋N��
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
    //            // �����f�B���C�R���[�`���̋N��
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
        //Instantiate(spawnParticle, transform.position, Quaternion.identity);//�p�[�e�B�N��
        //Instantiate(obj, transform.position, Quaternion.identity);

        var enemy = Instantiate(obj, transform.position, Quaternion.identity);
        //enemy.GetComponent<EnemyBase>().basePosition = bPos;

    }

}
