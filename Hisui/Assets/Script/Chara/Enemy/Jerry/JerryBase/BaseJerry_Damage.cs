using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BaseJerry_Damage : StateChildBase
{
    const float DAMAGETIMEMAX = 0.4f;
    float damageTime = 0f;

    //Animator m_anim;

    //void Start()
    //{
    //    m_anim = gameObject.GetComponent<Animator>();
    //}

    public override void Initialize(int stateType)
    {
        base.Initialize(stateType);
        //m_anim = gameObject.GetComponent<Animator>();
    }
    public override void OnEnter()
    {
        damageTime = 0f;
        stateTime = 0f;
        //�I�u�W�F�N�g��h�炵�I��
        StartCoroutine(MyLib.DoShake(0.25f, 0.1f, transform));

        //����ł�����
        if (gameObject.GetComponent<EnemyBase>().IsDead) return;


        //if (GetComponent<EnemyBase>().HitCol.enabled)
        //{
        //    Debug.Log("�_���[�W�A�j���J�n�@�G�̍U�������؂�");
        //    GetComponent<EnemyBase>().HitCol.enabled = false;
        //}

        //if (!m_anim.GetBool("DamageB"))
         //   m_anim.SetBool("DamageB", true);

        damageTime = DAMAGETIMEMAX;
        //�R���[�`���̋N��
       // StartCoroutine(MyLib.DelayCoroutine(damageTime, () =>
        //{
           // m_anim.SetBool("DamageB", false);
       //}));

    }

    public override void OnExit()
    {
        gameObject.GetComponent<EnemyBase>().IsDamage = false;
        //gameObject.GetComponent<Animator>().SetBool("DamageB", false);
    }

    public override int StateUpdate()
    {
        stateTime += Time.deltaTime;

        if (gameObject.GetComponent<EnemyBase>().IsDead)
        {
            const int DEAD = 1;
            return DEAD;
        }

        if (stateTime >= damageTime)
        {

            return GetComponent<EnemyBase>().ReturnStateMoveType(StateType);
        }

        return StateType;
    }

}
