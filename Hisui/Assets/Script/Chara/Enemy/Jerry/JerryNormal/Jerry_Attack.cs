using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Jerry_Attack : StateChildBase
{
    //Vector3 offsetPositoin = new(0, 0.5f, 0);

    //Launcherクラスを持つ

    //BaseMagazine bulletObj;

    //Transform targetTrans;

    //const float bulletSpeed = 0.02f;

    //float ATKSTATETIME = 0.0f;


    //public int DebugCount = 0;
    //public int DebugICount = 0;
    //Animator m_anim;

    //void Start()
    //{
    //    m_anim = gameObject.GetComponent<Animator>();
    //}
    public override void Initialize(int stateType)
    {
        //Debug.Log("InitDebugCount"+DebugICount++);


        base.Initialize(stateType);

        //m_anim = gameObject.GetComponent<Animator>();

        //bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/EBulletNormalEX");

        //var player = GameObject.FindGameObjectWithTag("Player");
        //targetTrans = player.transform;
    }

    public override void OnEnter()
    {

        //Debug.Log("DebugCount"+DebugCount++);

        stateTime = 0f;



        //if (GameObject.FindGameObjectWithTag("Player") == null)
        //    return;


        //Debug.Log("攻撃開始");
        //const float volume = 0.1f;
        //MyLib.MyPlayOneSound("SE/Enemy/スライムの攻撃", volume, this.gameObject);

        //m_anim.SetTrigger("AttackT");




        ////////////////Player狙い　弾
        //var bulletPos = transform.position;
        //// 対象物へのベクトルを算出
        //Vector3 toDirection = targetTrans.position - bulletPos;
        //// 対象物へ回転する
        //var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);

        
        //var ebullet = Instantiate(bulletObj.gameObject, bulletPos, bulletRot);

        //Vector2 direction = targetTrans.position - transform.position;
        //float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //var bulletComp = ebullet.GetComponent<Bullet>();
        //bulletComp.angle = pAngle;
        ///////////////////

        //var pDir = targetTrans.position - transform.position;
        //bulletComp.Initialize(pDir.normalized, bulletSpeed);

        /////////////

    }

    public override void OnExit()
    {
       // Debug.Log("攻撃終了");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (GetComponent<JerryScr>().IsDamage)
            return GetComponent<JerryScr>().ReturnStateTypeDamage();







        ///使えるやつ

        //GetComponent<JerryScr>().AttackMagazineUpdate(EnemyData.AttackType.NormalMagazine);


        //foreach (var magazine in GetComponent<JerryScr>().baseMagazine)
        //{
        //    if (Type.GetType(GetComponent<JerryScr>().enemyData.attackType.ToString()).FullName 
        //        == GetComponent<JerryScr>().enemyData.attackType.ToString())
        //    {
        //        var normalMagazine = (NormalMagazine)magazine;
        //        normalMagazine.ChangeShotNum();
        //    }
        //}

        //var normalMagazine = 
        //    GetComponent<JerryScr>().AttackMagazineSelect(EnemyData.AttackType.NormalMagazine) as NormalMagazine;
        //normalMagazine.ChangeShotNum();

        GetComponent<JerryScr>().AttackMagazineUpdateAll();


        //ATKSTATETIME = GetComponent<JerryScr>().baseMagazine.bulletInterval;


        //if (m_anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack02")
        //    return (int)SlimeCtr.State.Slime_Move;
        //Attack02

        //const float ATKSTATETIME = 0.0f;
        if (stateTime > GetComponent<JerryScr>().enemyData.AtkInterval)
        {


            //if(GetComponent<EnemyBase>().isAttackLoop)
            //{
            //stateTime = 0;
            //OnEnter();
            //return StateType;
            // }


            return GetComponent<EnemyBase>().ReturnStateMoveType(StateType);
        }

        return StateType;
    }

}
