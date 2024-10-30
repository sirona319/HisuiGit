using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseJerry_Attack : StateChildBase
{
    //Vector3 offsetPositoin = new(0, 0.5f, 0);

    private Bullet bulletObj;

    Transform targetTrans;

    const float bulletSpeed = 0.02f;


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

        bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/EBulletNormalEX");

        var player = GameObject.FindGameObjectWithTag("Player");
        targetTrans = player.transform;
    }

    public override void OnEnter()
    {

        //Debug.Log("DebugCount"+DebugCount++);

        stateTime = 0f;

        //if (GameObject.FindGameObjectWithTag("Player") == null)
        //    return;


        //Debug.Log("çUåÇäJén");
        //const float volume = 0.1f;
        //MyLib.MyPlayOneSound("SE/Enemy/ÉXÉâÉCÉÄÇÃçUåÇ", volume, this.gameObject);

        //m_anim.SetTrigger("AttackT");




        ////////////////Playerë_Ç¢Å@íe
        var bulletPos = transform.position;
        // ëŒè€ï®Ç÷ÇÃÉxÉNÉgÉãÇéZèo
        Vector3 toDirection = targetTrans.position - bulletPos;
        // ëŒè€ï®Ç÷âÒì]Ç∑ÇÈ
        var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);

        
        var ebullet = Instantiate(bulletObj.gameObject, bulletPos, bulletRot);

        Vector2 direction = targetTrans.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var bulletComp = ebullet.GetComponent<Bullet>();
        bulletComp.angle = pAngle;

        //var pDir = targetTrans.position - transform.position;
        //bulletComp.Initialize(pDir.normalized, bulletSpeed);

        /////////////

    }

    public override void OnExit()
    {
       // Debug.Log("çUåÇèIóπ");
    }

    public override int StateUpdate()
    {

        stateTime += Time.deltaTime;

        if (GetComponent<BaseJerryScr>().IsDamage)
        {
            GetComponent<BaseJerryScr>().EnemyDamage(1);

            const int DAMAGE = 2;
            return DAMAGE;
        }

        //if (m_anim.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Attack02")
        //    return (int)SlimeCtr.State.Slime_Move;
        //Attack02

        const float ATKSTATETIME = 0.0f;
        if (stateTime > ATKSTATETIME)
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
