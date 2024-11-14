using UnityEngine;
using System;
using static EnemyData;
using System.Collections.Generic;

public class JerryNormalFactory : BaseJerryEnemyFactory
{
    public override EnemyBase Load(Transform s)
    {
        return MyLib.InstantiateGetComponentLoad<EnemyBase>("prefab/Enemy/NormalJerry", s);
    }


    public override EnemyData SetData()
    {
        string eName = EnemySpawnWave.LoadState.NormalJerry.ToString();
        eData = EnemyManager.I.GetEnemyData(eName);
        return eData;
    }


    public override string SetName()
    {
        return eData.Id;
    }

    public override int SetMaxHp()
    {
        return eData.HpMax;
    }

    public override List<BaseMove> SetMove(Transform[] t)
    {
        List<BaseMove> baseMove=new();
        //baseMove初期化　移動クラスに持っていく？
        //for (int i = 0; i < (int)eData.moveType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(eData.moveType[i].ToString());

        //    if (typeClass != null)
        //        baseMove.Add((BaseMove)gameObject.AddComponent(typeClass));

        //}

        //foreach (var move in baseMove)
        //{
        //    //if (enemyData.IsMovePointSet)
        //    //    move.targets = movePointsDatas;

        //    move.Initialize();
        //}
        PointMove point=new PointMove();

        point.Initialize(GetComponent<Rigidbody2D>());

        point.TargetSet(t);

        baseMove.Add(point);

        return baseMove;
    }

    //public override Transform[] SetPoint()
    //{
    //    return null;
    //}
    public override List<BaseMagazine> SetMagazine()
    {
        List<BaseMagazine> baseMagazine = new();

        NormalMagazine normal=new();
        normal.Initialize();
        normal.BulletLoad("prefab/Bullet/JerryBullet");

        baseMagazine.Add(normal);
        return baseMagazine;
    }

}
