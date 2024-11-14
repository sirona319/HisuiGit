using System.Collections.Generic;
using UnityEngine;

public class JerryFiveFactory : BaseJerryEnemyFactory
{
    public override EnemyBase Load(Transform s)
    {
        return MyLib.InstantiateGetComponentLoad<EnemyBase>("prefab/Enemy/FiveJerry", s);
    }


    public override EnemyData SetData()
    {
        string eName = EnemySpawnWave.LoadState.FiveJerry.ToString();
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
        List<BaseMove> baseMove = new();

        PointMove point = new PointMove();
        point.Initialize(GetComponent<Rigidbody2D>());
        point.TargetSet(t);

        baseMove.Add(point);

        return baseMove;
    }

    public override List<BaseMagazine> SetMagazine()
    {
        List<BaseMagazine> baseMagazine = new();

        FiveMagazine five = new();
        five.Initialize();
        five.BulletLoad("prefab/Bullet/JerryBullet");

        baseMagazine.Add(five);
        return baseMagazine;
    }
}
