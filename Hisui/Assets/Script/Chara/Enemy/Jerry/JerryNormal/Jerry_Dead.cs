using UnityEngine;
using UnityEngine.SceneManagement;

public class Jerry_Dead : StateChildBase
{
    const float DEADTIME = 0.1f;

    private ParticleSystem deadParticle;//パーティクル
    AudioSource deadSound;

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        deadParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/Flash_star_ellow_green");

        deadSound = MyLib.GetComponentLoad<AudioSource>("prefab/Sound/JerryDestroy");
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        //var audioSource = gameObject.GetComponent<AudioSource>();
        ////audioSource.pitch = -1f;
        //var sound = (AudioClip)Resources.Load("Sound/SE/JerryDestroy");
        //audioSource.PlayOneShot(sound);

       


        //var dSe = MyLib.MyPlayOneSound("Sound/SE/JerryDestroy", gameObject);
        var seGo = Instantiate(deadSound, transform.position, Quaternion.identity);

        seGo.GetComponent<FlagDestroy>().StartDestroyFlg();

;


        //StartCoroutine(MyLib.DelayCoroutineIf(deadSound.isPlaying, () =>
        //{
        //    Debug.Log("しょうきょ");
        //    Destroy(seGo);
        //}));

        Instantiate(deadParticle, transform.position, Quaternion.identity);

        GameObject spawn = GameObject.Find("WaveSpawn");
        spawn.GetComponent<EnemySpawnWave>().UpdateCount();

        if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
            GameSceneControl.I.UpdateEnemyCount();

        gameObject.SetActive(false);

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
