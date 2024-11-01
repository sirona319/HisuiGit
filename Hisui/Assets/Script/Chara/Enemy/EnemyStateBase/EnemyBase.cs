using UnityEngine;
using System;
using static EnemyData;
using System.Collections.Generic;


public class EnemyBase : MonoBehaviour
{
    #region �X�e�[�g�R���g���[���[
    [SerializeField] protected StateControllerBase stateController = default;

    public int GetState()
    {
        return stateController.CurrentState;
    }
    #endregion

    //protected int hpPoint;

    [NonSerialized] public bool IsDead = false;
    [NonSerialized] public bool IsDamage = false;
    [NonSerialized] public bool IsAttack = false;
    [NonSerialized] public bool IsMove = true;


    [NonSerialized] public EnemyData enemyData;//�X�N���v�^���I�u�W�F�N�g�@���X�g
    [NonSerialized] public string findName;


    List<BaseMagazine> baseMagazine=new ();
    [NonSerialized] public List<BaseMove> baseMove = new ();


    //�Ăяo����ŃL���X�g���Ďg�p����
    public BaseMove MoveTypeSelect(MoveType mt)
    {
        foreach (var move in baseMove)
        {

            if (move.GetType().FullName == mt.ToString())
                return move;
        }


        return null;
    }


    public void AttackMagazineUpdate(AttackType atkType)
    {

        foreach (var magazine in baseMagazine)
            if (magazine.GetType().FullName == atkType.ToString())
                magazine.MagazineUpdate();
        
    }
    public void AttackMagazineUpdateAll()
    {
        foreach (var magazine in baseMagazine)
            magazine.MagazineUpdate();
    }


    protected virtual void StartInit()
    {
        //�X�N���v�^���I�u�W�F�N�g�̃f�[�^���擾
        enemyData = EnemyManager.I.GetEnemyData(findName);

        //enemyData��null�`�F�b�N
        if (enemyData == null)
            throw new System.Exception(findName + "�@Data null");


        if((int)enemyData.attackType.Length<=0)
            throw new System.Exception(findName + "�@�X�N���v�^���I�u�W�F�N�gattackType�@��");

        if ((int)enemyData.moveType.Length <= 0)
            throw new System.Exception(findName + "�X�N���v�^���I�u�W�F�N�g�@moveType ��");
    }
    protected virtual void Init()
    {

        //baseMagazine������
        for (int i = 0; i < (int)enemyData.attackType.Length; i++)
        {
            Type typeClass = Type.GetType(enemyData.attackType[i].ToString());

            if (typeClass != null)
                baseMagazine.Add((BaseMagazine)gameObject.AddComponent(typeClass));

        }

        foreach (var magazine in baseMagazine)
            magazine.Initialize();


        //baseMove������
        for (int i = 0; i < (int)enemyData.moveType.Length; i++)
        {
            Type typeClass = Type.GetType(enemyData.moveType[i].ToString());

            if (typeClass != null)
                baseMove.Add((BaseMove)gameObject.AddComponent(typeClass));

        }

        foreach (var move in baseMove)
            move.Initialize();


        //�X�e�[�^�X�̏�����
        enemyData.Hp = enemyData.HpMax;

    }

    #region �A�j���[�V�����C�x���g

    //public void OnEnemyAttack()
    //{

    //    Debug.Log("OnEnemyAttack");
    //    //�U���R���W������L���ɂ���
    //    //HitCol.enabled = true;

    //}

    //public void OffEnemyAttack()
    //{
    //    Debug.Log("OffEnemyAttack");

    //    //HitCol.enabled = false;

    //}
    #endregion

    public virtual void EnemyDamage(int damage)
    {

        if (IsDead) return;


        Debug.Log(gameObject.name + "�ւ̃_���[�W" + damage.ToString());
        enemyData.Hp -= damage;        //HP��������

        IsDamage = true;

        if (enemyData.Hp <= 0)
            IsDead = true;
    }



    public int ReturnStateTypeDamage()
    {
        const int DAMAGESTATE = 1;
        return DAMAGESTATE;
    }

    //public int ReturnStateMoveType(int stateType)
    //{

    //    return stateType;
    //}

    public int ReturnStateMoveType(int stateType)
    {
        if (IsAttack)
            return (int)JerryCtr.State.Jerry_Attack;

        else if (IsMove)
            return (int)JerryCtr.State.Jerry_Move;


        //if (enemyData.moveType == EnemyData.MoveType.random)
        //    return (int)JerryCtr.State.Jerry_Move;

        //if (enemyData.moveType == EnemyData.MoveType.random)
        //    return (int)BaseJerryCtr.State.BaseJerry_Move;
        //else if (enemyData.moveType == EnemyData.MoveType.point)
        //    return (int)BaseJerryCtr.State.BaseJerry_MovePoint;
        //else if (enemyData.moveType == EnemyData.MoveType.circle)
        //    return (int)BaseJerryCtr.State.BaseJerry_MoveCircle;

        return stateType;
    }

}
