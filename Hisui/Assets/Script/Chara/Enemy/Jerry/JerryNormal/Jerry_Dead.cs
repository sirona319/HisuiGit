using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jerry_Dead : StateChildBase
{
    const float DEADTIME = 0.1f;

    private ParticleSystem deadParticle;//パーティクル

    //        fireParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/MyCFXR4 Sun")

    //private TresureBox tresureBox;//宝箱

    //void Start()
    //{
    //    tresureBox = MyLib.GetComponentLoad<TresureBox>("prefab/Item/MyChest_0002");

    //    deadParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/MyCFXR Explosion Smoke 2 Solo (HDR)");
    //}

    public override void Initialize(int stateNo)
    {
        base.Initialize(stateNo);

        //tresureBox = MyLib.GetComponentLoad<TresureBox>("prefab/Item/MyChest_0002");

        deadParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/Flash_star_ellow_green");
    }

    public override void OnEnter()
    {
        stateTime = 0f;

        Instantiate(deadParticle, transform.position, Quaternion.identity);

        StartCoroutine(MyLib.DelayCoroutine(DEADTIME, () =>
        {

            if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
                GameSceneControl.I.UpdateEnemyCount();

            gameObject.SetActive(false);
            //Destroy(gameObject);

        }));

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
