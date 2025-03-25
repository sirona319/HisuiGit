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

    //public Rigidbody2D rb;

    public bool IsDead { get; private set;} =false;

    public bool IsDamage { get; set; } = false;

    public bool IsAttack  = false;

    public bool IsMove  = true;


    //public EnemyData enemyData;//スクリプタルオブジェクト　リスト中身


    //public List<BaseMagazine> baseMagazine=new ();
    public BaseMagazine atkMagazine = null;
    //public List<BaseMove> baseMove = new ();
    public BaseMove move = null;
    public BaseMove atkMove = null;

    public int Hp = 0;
    //[SerializeField] public float AtkIntervalMax;
    //[SerializeField] public float AtkInterval;


    ParticleSystem dmgParticle;//ダメージパーティクル


    /// <summary>
    /// 呼び出し先でキャストして使用する
    /// </summary>
    /// <param name="mt"></param>
    /// <returns>BaseMove</returns>
    //public BaseMove MoveTypeSelect(MoveType mt)
    //{
    //    foreach (var move in baseMove)
    //    {

    //        if (move.GetType().FullName == mt.ToString())
    //            return move;
    //    }


    //    return null;
    //}


    //public void AttackMagazineUpdate(AttackType atkType)
    //{

    //    foreach (var magazine in baseMagazine)
    //        if (magazine.GetType().FullName == atkType.ToString())
    //            magazine.MagazineUpdate();

    //}
    //public void AttackMagazineUpdateAll()
    //{
    //    foreach (var magazine in baseMagazine)
    //        magazine.MagazineUpdate();
    //}

    //protected virtual void EnemyDataInit()
    //{
    //    //スクリプタルオブジェクトのデータを取得
    //    enemyData = EnemyManager.I.GetEnemyData(findName);

    //    //enemyDataのnullチェック
    //    if (enemyData == null)
    //        throw new System.Exception(findName + "　Data null");


    //    if ((int)enemyData.attackType.Length <= 0)
    //        throw new System.Exception(findName + "　スクリプタルオブジェクトattackType　空");

    //    if ((int)enemyData.moveType.Length <= 0)
    //        throw new System.Exception(findName + "スクリプタルオブジェクト　moveType 空");
    //}

    public virtual void Init()
    {
        dmgParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/Particle/DamagePt");

        //move = GetComponent<EnemyBase>().move;


        if (atkMagazine != null)
            atkMagazine.Initialize();

        if (atkMove != null)
            atkMove.Initialize();

        if (move != null)
            move.Initialize();
    }

    //public virtual void PrefabInit()
    //{
    //    ////baseMagazine初期化　　攻撃クラスに持っていく？
    //    //for (int i = 0; i < (int)enemyData.attackType.Length; i++)
    //    //{
    //    //    Type typeClass = Type.GetType(enemyData.attackType[i].ToString());

    //    //    if (typeClass != null)
    //    //        baseMagazine.Add((BaseMagazine)gameObject.AddComponent(typeClass));

    //    //}

    //    foreach (var magazine in baseMagazine)
    //    {
    //        //magazine.BulletLoad("prefab/EBulletNormalEX");
    //        magazine.Initialize();

    //    }

    //    ////baseMove初期化　移動クラスに持っていく？
    //    //for (int i = 0; i < (int)enemyData.moveType.Length; i++)
    //    //{
    //    //    Type typeClass = Type.GetType(enemyData.moveType[i].ToString());



    //    //    if (typeClass != null)
    //    //    {
    //    //        baseMove.Add((BaseMove)gameObject.AddComponent(typeClass));
    //    //    }

    //    //    //baseMove.Add((BaseMove)gameObject.GetComponent(typeClass));
    //    //}

    //    //foreach (var move in baseMove)
    //    //{
    //    //    //初期化
    //    //    move.Initialize(GetComponent<Rigidbody2D>());

    //    //}


    //    //ステータスの初期化
    //    //Hp = enemyData.HpMax;

    //    //enemyData.movePointsSet = movePointsInit;
    //}

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

        //Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        Hp -= damage;        //HP減少処理

        IsDamage = true;

        if (Hp <= 0)
        {
            IsDead = true;
            return;
        }

        //ダメージパーティクル表示
        Instantiate(dmgParticle, transform.position, Quaternion.identity);
    }



    public bool ReturnStateTypeDead()
    {
        //const int DEAD = 2;
        if (IsDead)return true;

        //const int DAMAGESTATE = 1;
        //return DAMAGESTATE;
        return false;

    }

    public void SetEndMoveKeep()
    {
        //if (!moveEnd) return;
        IsAttack = true;

        IsMove = true;

    }

    public void SetIsAttack()
    {
        IsAttack = true;
    }
    public void MoveEnd()
    {
        IsMove = false;
    }
    //private void OnTriggerExit(Collider other)
    //{

    //    if (other.CompareTag("ExitErea"))
    //    {

    //        //Debug.Log("エリア外消去");

    //        this.gameObject.SetActive(false);

    //        Destroy(this.gameObject);
    //        return;
    //    }

    //}

    //public int ReturnStateMoveType(int stateType)
    //{
    //    if (IsAttack)
    //        return (int)JerryCtr.State.Jerry_Attack;

    //    else if (IsMove)
    //        return (int)JerryCtr.State.Jerry_Move;


    //    //if (enemyData.moveType == EnemyData.MoveType.random)
    //    //    return (int)JerryCtr.State.Jerry_Move;

    //    //if (enemyData.moveType == EnemyData.MoveType.random)
    //    //    return (int)BaseJerryCtr.State.BaseJerry_Move;
    //    //else if (enemyData.moveType == EnemyData.MoveType.point)
    //    //    return (int)BaseJerryCtr.State.BaseJerry_MovePoint;
    //    //else if (enemyData.moveType == EnemyData.MoveType.circle)
    //    //    return (int)BaseJerryCtr.State.BaseJerry_MoveCircle;

    //    return stateType;
    //}

}
