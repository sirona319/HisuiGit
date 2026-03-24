using UnityEngine;

public class EnemyMgr : Singleton<EnemyMgr>
{
    //private void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    [SerializeField] int enemyAllCount;


    //[SerializeField] GameObject startEvent;
    public void CountUp(int count)
    {
        enemyAllCount += count;
    }

    public void UpdateEnemyCount()
    {
        enemyAllCount--;
        if (enemyAllCount <= 0)
        {
            //GameObject.Find("CLEARTEXT").GetComponent<DOFade>().ShowWindow();

            //StartCoroutine(SoundManager.I.SoundFadeOffCoroutine(GetComponent<AudioSource>(), 0.00001f));

            //GameMgr.I.SceneChangeTimerSet(GameMgr.SceneNameType.Title.ToString());


        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //if (saveGo.CompareTag(TagName.EnemyBoss))
    //    //{
    //    //    //敵全部を破棄　生成？
    //    //    //破棄と生成
    //    //    Destroy(saveGo);
    //    //    Spawn(0);

    //    //}
    //}

    public void EnemyClearAll()
    {
        var enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var e in enemys)
        {
            Destroy(e);
        }

        var enemysB = GameObject.FindGameObjectsWithTag("BossPumpkin");

        foreach (var e in enemysB)
        {
            Destroy(e);
        }
    }
}
