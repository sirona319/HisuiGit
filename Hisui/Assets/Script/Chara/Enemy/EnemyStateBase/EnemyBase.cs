using UnityEngine;
using System;
using static EnemyData;
using System.Collections.Generic;


public class EnemyBase : MonoBehaviour
{
    #region ステートコントローラー
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


    [NonSerialized] public EnemyData enemyData;//スクリプタルオブジェクト　リスト
    [NonSerialized] public string findName;


    List<BaseMagazine> baseMagazine=new ();
    [NonSerialized] public List<BaseMove> baseMove = new ();


    //呼び出し先でキャストして使用する
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
        //スクリプタルオブジェクトのデータを取得
        enemyData = EnemyManager.I.GetEnemyData(findName);

        //enemyDataのnullチェック
        if (enemyData == null)
            throw new System.Exception(findName + "　Data null");


        if((int)enemyData.attackType.Length<=0)
            throw new System.Exception(findName + "　スクリプタルオブジェクトattackType　空");

        if ((int)enemyData.moveType.Length <= 0)
            throw new System.Exception(findName + "スクリプタルオブジェクト　moveType 空");
    }
    protected virtual void Init()
    {

        //baseMagazine初期化
        for (int i = 0; i < (int)enemyData.attackType.Length; i++)
        {
            Type typeClass = Type.GetType(enemyData.attackType[i].ToString());

            if (typeClass != null)
                baseMagazine.Add((BaseMagazine)gameObject.AddComponent(typeClass));

        }

        foreach (var magazine in baseMagazine)
            magazine.Initialize();


        //baseMove初期化
        for (int i = 0; i < (int)enemyData.moveType.Length; i++)
        {
            Type typeClass = Type.GetType(enemyData.moveType[i].ToString());

            if (typeClass != null)
                baseMove.Add((BaseMove)gameObject.AddComponent(typeClass));

        }

        foreach (var move in baseMove)
            move.Initialize();


        //ステータスの初期化
        enemyData.Hp = enemyData.HpMax;

    }

    #region アニメーションイベント

    //public void OnEnemyAttack()
    //{

    //    Debug.Log("OnEnemyAttack");
    //    //攻撃コリジョンを有効にする
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


        Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        enemyData.Hp -= damage;        //HP減少処理

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
