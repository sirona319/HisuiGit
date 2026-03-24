using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jerry_Dead : StateChildBase
{
    //const float DEADTIME = 0.1f;

    ParticleSystem deadParticle;//パーティクル
    AudioSource deadSound;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        deadParticle = (ParticleSystem)Resources.Load("prefab/Particle/Flash_star_ellow_green").GetComponent<ParticleSystem>();
        //deadParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/Flash_star_ellow_green");
        deadSound = (AudioSource)Resources.Load("prefab/Sound/JerryDestroySound").GetComponent<AudioSource>();
        //deadSound = MyLib.GetComponentLoad<AudioSource>("prefab/Sound/JerryDestroySound");
    }

    public override void OnEnter()
    {
        stateTime = 0f;


        Instantiate(deadParticle, transform.position, Quaternion.identity);

        //var destroySound = transform.Find("JerryDestroySound").GetComponent<AudioSource>();
        //destroySound.volume = 1f;
        //destroySound.Play();

        //
        //var seGo = Instantiate(deadSound, transform.position, Quaternion.identity);
        //seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録
        if(GetComponent<CreateDeadSound>() != null)
            GetComponent<CreateDeadSound>().Create(deadSound);


        GameObject spawn = GameObject.Find("WaveSpawnPrefab");
        spawn.GetComponent<EnemySpawnWavePrefab>().UpdateCount();

        if (EnumSceneName.SceneNameType.GameScene.ToString().Contains(SceneManager.GetActiveScene().name))
            GameSceneControl.I.UpdateEnemyCount();

        //サウンドがならない　原因
        //gameObject.SetActive(false);
        Destroy(this.gameObject);

        //StartCoroutine(MyLib.DelayCoroutine(DEADTIME, () =>
        //{
        //    GameObject spawn = GameObject.Find("WaveSpawn");
        //    spawn.GetComponent<EnemySpawnWave>().UpdateCount();

        //    if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
        //        GameSceneControl.I.UpdateEnemyCount();

        //    gameObject.SetActive(false);
        //    //Destroy(gameObject);

        //}));

        //クリアチェック　スコア加算　
        //if (SceneManager.GetActiveScene().name.Contains(GManager.SceneNameType.NormalScene.ToString()))
        //{
        //    //GameSceneControl.I.UpdateEnemyCount();
        //}

    }

    public override void OnExit()
    {

    }

    public override sealed int StateUpdate()
    {
        stateTime += Time.deltaTime;

        //if (stateTime > DEADTIME)
        //{
        //    Instantiate(deadParticle, transform.position, Quaternion.identity);

        //    gameObject.SetActive(false);
        //}


        return (int)StateType;

    }

    //public override void OnEnter()
    //{
    //    //var anim = gameObject.GetComponent<Animator>();
    //    //anim.SetBool("DamageB", false);
    //    //anim.SetTrigger("DeadT");

    //    base.OnEnter();
    //}
}
