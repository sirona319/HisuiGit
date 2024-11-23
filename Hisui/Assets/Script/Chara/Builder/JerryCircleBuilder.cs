using UniRx;
using UnityEngine;
using System;

public class JerryCircleBuilder : BaseBuilder
{

    public override void Build(EnemyData eData, Transform s, Transform[] movePoint, PoolManager pool)
    {
        var loadObj = (GameObject)Resources.Load("prefab/Enemy/Jerry/NormalJerry");
        var enemy = Instantiate(loadObj, s.position, Quaternion.identity);
        var eBase = enemy.GetComponent<EnemyBase>();

        eBase.AtkInterval = eData.AtkIntervalMax;
        eBase.Hp = eData.HpMax;
        //eBase.movePointsDatas = movePoint;//nullになる場合？

        //MagazineInit(eData, pool, enemy);

        MoveInit(eData, movePoint, enemy);

        eBase.enemyData = eData;
    }

    //void MagazineInit(EnemyData eData, PoolManager pool, GameObject enemy)
    //{
    //    var eBase = enemy.GetComponent<EnemyBase>();

    //    //baseMagazine初期化　　攻撃クラスに持っていく？
    //    for (int i = 0; i < (int)eData.attackType.Length; i++)
    //    {
    //        Type typeClass = Type.GetType(eData.attackType[i].ToString());

    //        if (typeClass != null)
    //            eBase.baseMagazine.Add((BaseMagazine)enemy.AddComponent(typeClass));
    //    }

    //    foreach (var magazine in eBase.baseMagazine)
    //    {
    //        //magazine.BulletLoad("prefab/EBulletNormalEX");
    //        magazine.Initialize();
    //        magazine.BulletLoad("prefab/Bullet/JerryBullet");
    //        magazine.SetPool(pool);

    //        //ターゲットがある場合
    //        var iTarget = magazine as ITarget;
    //        if (iTarget != null)
    //            iTarget.Target = GameObject.FindGameObjectWithTag("Player").transform;
    //    }
    //}

    void MoveInit(EnemyData eData, Transform[] movePoint, GameObject enemy)
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





            var pCircleMove = move as PointCircleMove;

            //pMove.IsPointMoveEnd.Skip(1).Subscribe(count => Debug.Log(count));
            //関数がここで一度呼び出されるpMove.IsPointMoveEnd.Skip(1)初回をスキップする
            pCircleMove.IsPointMoveEnd.Skip(1).Subscribe(pointBool => enemy.GetComponent<EnemyBase>().SetEndMoveKeep());

            pCircleMove.TargetSet(movePoint);
            pCircleMove.SetMoveEndLength(eData.PointEndLength);

            pCircleMove.speed = eData.Speed;
        }

    }


}
