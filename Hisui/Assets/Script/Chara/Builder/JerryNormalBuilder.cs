using System;
using UnityEngine;
using UniRx;

public class JerryNormalBuilder : BaseBuilder
{

    //[SerializeField] MagazineCreate mgCreate;
    #region //

    //BaseJerryEnemyFactory _factory = null;

    ////Transform startT;
    //Transform[] targetPosArray;

    ////public JerryBuilder(BaseJerryEnemyFactory factory)
    ////{
    ////    _factory = factory;
    ////}

    //public void Init(BaseJerryEnemyFactory factory)
    //{
    //    _factory = factory;

    //}

    //public void InitData(Transform[] point)
    //{
    //    targetPosArray = point;
    //}

    //var enemy = _factory.Load(s);

    //enemy.enemyData = _factory.SetData();

    //enemy.baseMagazine = _factory.SetMagazine();

    //enemy.baseMove = _factory.SetMove(targetPosArray);

    ////foreach (var move in enemy.baseMove)
    ////   move.SetRb(enemy.GetComponent<Rigidbody2D>());

    //enemy.Hp = _factory.SetMaxHp();

    #endregion

    public override void Build(EnemyData eData,Transform s, Transform[] movePoint,PoolManager pool)
    {
        //"prefab/Bullet/JerryBullet"
        var loadObj=(GameObject)Resources.Load("prefab/Enemy/Jerry/NormalJerry");
        var enemy = Instantiate(loadObj, s.position, Quaternion.identity);
        var eBase = enemy.GetComponent<EnemyBase>();

        eBase.AtkInterval = eData.AtkIntervalMax;
        eBase.Hp = eData.HpMax;
        //eBase.movePointsDatas = movePoint;//nullになる場合？


        GetComponent<MagazineCreate>().MagazineCreateInit(eData, pool, enemy);
        //MagazineCreate(eData, pool, enemy);

        MoveCreate(eData, movePoint, enemy);
        

        eBase.enemyData = eData;
    }

    void MagazineCreate(EnemyData eData,PoolManager pool,GameObject enemy)
    {
        var eBase = enemy.GetComponent<EnemyBase>();

        //baseMagazine初期化　　攻撃クラスに持っていく？
        for (int i = 0; i < (int)eData.attackType.Length; i++)
        {
            Type typeClass = Type.GetType(eData.attackType[i].ToString());

            if (typeClass != null)
                eBase.baseMagazine.Add((BaseMagazine)enemy.AddComponent(typeClass));
        }

        //////////////////

        //magazine.attackType
        foreach (var magazine in eBase.baseMagazine)
        {
            //magazine.BulletLoad("prefab/EBulletNormalEX");
            magazine.Initialize();
            
            //magazine.BulletLoad("prefab/Bullet/JerryBullet");
            magazine.SetPool(pool);

            var iTarget = magazine as ITarget;
            if (iTarget != null)
                iTarget.Target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void MoveCreate(EnemyData eData, Transform[] movePoint, GameObject enemy)
    {

        var eBase = enemy.GetComponent<EnemyBase>();

        //baseMove初期化　移動クラスに持っていく？
        for (int i = 0; i < (int)eData.moveType.Length; i++)
        {
            Type typeClass = Type.GetType(eData.moveType[i].ToString());

            if (typeClass != null)
            {
                eBase.baseMove.Add((BaseMove)enemy.AddComponent(typeClass));
            }

        }




        foreach (var move in eBase.baseMove)
        {
            //初期化
            move.Initialize(enemy.GetComponent<Rigidbody2D>());






            var pMove = move as PointFloatMove;

            //pMove.IsPointMoveEnd.Skip(1).Subscribe(count => Debug.Log(count));
            //関数がここで一度呼び出されるpMove.IsPointMoveEnd.Skip(1)初回をスキップする
            pMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool =>
            {
                enemy.GetComponent<EnemyBase>().SetEndMoveKeep();
                enemy.GetComponent<JerryScr>().SetEndTrail();
            }
            );

            pMove.TargetSet(movePoint);

            pMove.speed = eData.Speed;
            //pMove.SetMoveEndLength(eData.PointEndLength);
        }



        //}

        //別クラスでフロートムーブ設定をする




    }
}
