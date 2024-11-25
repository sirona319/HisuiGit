
/*
using System;
using UnityEngine;
using UniRx;


public class JerryFloatVectorBuilder : BaseBuilder
{
    public override void Build(EnemyData eData, Transform s, Transform[] movePoint, PoolManager pool)
    {
        var loadObj = (GameObject)Resources.Load("prefab/Enemy/Jerry/NormalJerry");
        var enemy = Instantiate(loadObj, s.position, Quaternion.identity);
        var eBase = enemy.GetComponent<EnemyBase>();

        eBase.AtkInterval = eData.AtkIntervalMax;
        eBase.Hp = eData.HpMax;
        eBase.enemyData = eData;

        eBase.SetIsAttack();

        MagazineInit(eData, pool, enemy);

        MoveInit(eData, movePoint[0].position, enemy);


    }

    void MagazineInit(EnemyData eData, PoolManager pool, GameObject enemy)
    {
        var eBase = enemy.GetComponent<EnemyBase>();

        //baseMagazine初期化　　攻撃クラスに持っていく？
        for (int i = 0; i < (int)eData.attackType.Length; i++)
        {
            Type typeClass = Type.GetType(eData.attackType[i].ToString());

            if (typeClass != null)
                eBase.baseMagazine.Add((BaseMagazine)enemy.AddComponent(typeClass));
        }

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

    void MoveInit(EnemyData eData, Vector3 movePos, GameObject go)
    {

        var eBase = go.GetComponent<EnemyBase>();

        //baseMove初期化　移動クラスに持っていく？
        for (int i = 0; i < (int)eData.moveType.Length; i++)
        {
            Type typeClass = Type.GetType(eData.moveType[i].ToString());

            if (typeClass != null)
            {
                eBase.baseMove.Add((BaseMove)go.AddComponent(typeClass));
            }

        }

        const float moveVal = 0.02f;
        const float sinVal = 0.04f;
        foreach (var move in eBase.baseMove)
        {
            //初期化
            move.Initialize(go.GetComponent<Rigidbody2D>());









            //////var test = go.transform;
            //////test.SetPositionAndRotation(go.transform.position, targetRotation);

            var fVecMove = move as FloatVectorMove;
            //movePoint　方向？
            var dir = movePos - go.transform.position;


            go.transform.rotation = Quaternion.FromToRotation(Vector3.up, dir.normalized);

            fVecMove.floatVector = dir.normalized* moveVal;

            fVecMove.addSinVec = go.transform.right * sinVal;
            //fVecMove.addVec

            //Transformのコピー　調べる

            //オブジェクト方向に向かせて　transform.rightで90度方向が取得できる

        }

    }
}
*/