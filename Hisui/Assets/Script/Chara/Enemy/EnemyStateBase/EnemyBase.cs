using UnityEngine;
using System;
using static EnemyData;
using System.Collections.Generic;
using Unity.VisualScripting;



public class EnemyBase : MonoBehaviour
{
    #region ステートコントローラー
    [SerializeField] protected StateControllerBase stateController = default;

    public int GetState()
    {
        return stateController.CurrentState;
    }
    #endregion

    [NonSerialized] public Vector3 basePosition = Vector3.zero;


    protected int hpPoint;

    [NonSerialized] public bool IsDead = false;
    [NonSerialized] public bool IsDamage = false;
    [NonSerialized] public bool IsAttack = true;
    [NonSerialized] public bool IsMove = true;

    //[NonSerialized] public float moveRandXZ = 3;



    //public Transform[] movePoints;
    //[NonSerialized] public int firstTargetPoints = 0;

    //[SerializeField] protected EnemyDamageUI enemyDamageUI;

    [NonSerialized] public EnemyData enemyData;//スクリプタルオブジェクト　リスト
    [NonSerialized] public string findName;

    //List<int> Values 
    List<BaseMagazine> baseMagazine=new List<BaseMagazine>();

    List<BaseMove> baseMove = new List<BaseMove>();


    //new ()はnew Dictionary<int, BaseMagazine>()とおんなじ
    ////BaseMagazine[]　だとpublicにしないとエラーになるDictionaryならいける？
    //Dictionary<int, BaseMagazine> baseMagazine = new ();


    //呼び出し先でキャストして使用する
    public BaseMagazine AttackMagazineSelect(AttackType atkType)
    {
        foreach (var magazine in baseMagazine)
        {

            if (magazine.GetType().FullName == atkType.ToString())
                return magazine;
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

    public void MoveUpdateAll()
    {
        foreach (var move in baseMove)
            move.MoveUpdate();
    }



    //private async UniTask uStart()
    //{

    //    var BaseJerrySetting = await Addressables.LoadAssetAsync<EnemySetting>("Assets/EnemySetting.asset");

    //    enemyData = BaseJerrySetting.DataList.FirstOrDefault(enemy => enemy.Id == this.gameObject.name);

    //    Debug.Log($"ID：{enemyData.Id}");
    //    Debug.Log($"Hp：{enemyData.HpMax}");
    //    Debug.Log($"速度：{enemyData.Speed}");
    //    Debug.Log($"攻撃タイプ：{enemyData.attackType}");
    //    Debug.Log($"移動タイプ：{enemyData.moveType}");
    //    Debug.Log($"攻撃間隔：{enemyData.AtkInterval}");


    //    //GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.five
    //}

    //private async void Start()
    //{
    //    await UniStart();
    //}

    protected virtual void Init()
    {
        //await uStart();
        //BaseJerrySetting = await Addressables.LoadAssetAsync<EnemySetting>("Assets/EnemySetting.asset");


        //スクリプタルオブジェクトのデータを取得
        enemyData = EnemyManager.I.GetEnemyData(findName);


        //BaseJerrySetting = Resources.Load<EnemySetting>("EnemySetting");
        //enemyData = BaseJerrySetting.DataList.FirstOrDefault(enemy => enemy.Id == findName);

        if (enemyData==null)
            throw new System.Exception(findName+"　Data null");


        for (int i = 0; i < (int)enemyData.attackType.Length; i++)
        {
            Type typeClass = Type.GetType(enemyData.attackType[i].ToString());

            if (typeClass != null)
            {
                //baseMagazine[i] = (BaseMagazine)gameObject.AddComponent(typeClass);

                //baseMagazine[i].Initialize();


                baseMagazine.Add((BaseMagazine)gameObject.AddComponent(typeClass));

                //baseMagazine[i].Initialize();

            }

        }

        foreach (var magazine in baseMagazine)
            magazine.Initialize();
        

        //string magazineClassName = enemyData.attackType.ToString();
        //Type typeClass = Type.GetType(magazineClassName);

        //baseMagazine = (BaseMagazine)gameObject.AddComponent(typeClass);

        //baseMagazine.Initialize();






        //Debug.Log(enemyData);

        enemyData.Hp = enemyData.HpMax;

    }

    #region アニメーションイベント

    public void OnEnemyAttack()
    {

        Debug.Log("OnEnemyAttack");
        //攻撃コリジョンを有効にする
        //HitCol.enabled = true;

    }

    public void OffEnemyAttack()
    {
        Debug.Log("OffEnemyAttack");

        //HitCol.enabled = false;

    }
    #endregion

    public virtual void EnemyDamage(int damage)
    {
        //Destroy(this.gameObject);

        if (IsDead) return;
        //if (!m_animator.GetBool("Damage")) return;

        //IsDamage = true;
        //IsDead = true;

        //Destroy(this.gameObject);

        //return;


        //if(enemyDamageUI!=null)
        //enemyDamageUI.DamegeView(damage);

        Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
        enemyData.Hp -= damage;        //HP減少処理

        IsDamage = true;

        if (enemyData.Hp <= 0)
            IsDead = true;
    }



    public int ReturnStateTypeDamage()
    {
        const int DAMAGE = 2;
        return DAMAGE;
    }
    public int ReturnStateMoveType(int stateType)
    {
        //if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.random)
        //    return (int)SlimeCtr.State.Slime_Move;
        //else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.point)
        //    return (int)SlimeCtr.State.Slime_MovePoint;
        //else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.circle)
        //    return (int)SlimeCtr.State.Slime_MoveCircle;

        return stateType;
    }

    //public int ReturnStateDamage(int stateType)
    //{
    //    if (GetComponent<BaseJerryScr>().IsDamage)
    //    {
    //        const int DAMAGE = 2;
    //        return DAMAGE;
    //    }

    //    if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.random)
    //        return (int)SlimeCtr.State.Slime_Move;
    //    else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.point)
    //        return (int)SlimeCtr.State.Slime_MovePoint;
    //    else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.circle)
    //        return (int)SlimeCtr.State.Slime_MoveCircle;

    //    return stateType;
    //}

    //public int ReturnStateMoveTypeFind(int stateType)
    //{
    //    if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.random)
    //        return (int)SlimeCtr.State.Slime_Move;
    //    else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.point && GetComponent<EnemyBase>().movePoints.Length == 0)
    //        return stateType;
    //    else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.point)
    //        return (int)SlimeCtr.State.Slime_MovePoint;
    //    else if (GetComponent<EnemyBase>().enemyData.moveType == EnemyData.MoveType.circle)
    //        return (int)SlimeCtr.State.Slime_MoveCircle;

    //    return stateType;
    //}


    //public int ReturnStateMoveTypeAttack(int stateType)
    //{
    //    if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.circle)
    //        return (int)SlimeCtr.State.Slime_AttackCircle;
    //    else if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.five)
    //        return (int)SlimeCtr.State.Slime_AttackFive;
    //    else if (GetComponent<EnemyBase>().enemyData.attackType == EnemyData.AttackType.normal)
    //        return (int)SlimeCtr.State.Slime_Attack;

    //    return stateType;
    //}


}
