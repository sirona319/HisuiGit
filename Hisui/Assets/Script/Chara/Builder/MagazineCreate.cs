using System;
using UnityEngine;
using static EnemyData;

public class MagazineCreate : MonoBehaviour
{
    public void MagazineCreateInit(EnemyData eData, PoolManager pool, GameObject go)
    {
        
        var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？

        //baseMagazine初期化　　攻撃クラスに持っていく？
        for (int i = 0; i < (int)eData.attackType.Length; i++)
        {
            Type typeClass = Type.GetType(eData.attackType[i].ToString());

            if (typeClass != null)
                eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(typeClass));
        }





        //foreach (var mg in eBase.baseMagazine)
        //{

        //    if (mg.GetType().FullName == AttackType.NearMagazine.ToString())
        //        Debug.Log("tes");
        //        //return mg;
        //}


        //////////////////
        var pTrans= GameObject.FindGameObjectWithTag("Player").transform;
        //magazine.attackType
        foreach (var magazine in eBase.baseMagazine)
        {
            //magazine.BulletLoad("prefab/EBulletNormalEX");
            magazine.Initialize();

            //var twoCarveMagazine = magazine as TwoCarveMagazine;  
            ////eData.bulletType.


            //var baseBullet = magazine.BulletLoad("prefab/Bullet/JerryBullet");

            magazine.SetBulletTypes(eData.bulletType);
            magazine.bulletPath = "prefab/Bullet/JerryBullet";
            //CarveModule
            //ShakeModule

            //              baseBullet.Add((BaseBullet)typeClass);// Shake Carve など




            //baseMagazine初期化　　攻撃クラスに持っていく？

            //
            //var shakeCarveBullet = baseBullet as ShakeCarveBulletR;
            //if (shakeCarveBullet != null)
            //{
            //    //shakeCarveBullet
            //}
            //var shakeCarveBullet = baseBullet as ShakeCarveBulletL;
            //if (shakeCarveBullet != null)
            //{
            //    //shakeCarveBullet
            //}

            magazine.SetPool(pool);

            var iTarget = magazine as ITarget;
            if (iTarget != null)
                iTarget.Target = pTrans;
        }
        
    }

    public void BulletCreateInit(EnemyData eData, GameObject go)
    {

        //var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？

        ////baseMagazine初期化　　攻撃クラスに持っていく？
        //for (int i = 0; i < (int)eData.attackType.Length; i++)
        //{
        //    Type typeClass = Type.GetType(eData.bulletType[i].ToString());

        //    if (typeClass != null)
        //        var aa = gameObject.Add((BaseBullet)go.AddComponent(typeClass));
        //}





        //foreach (var mg in eBase.baseMagazine)
        //{

        //    if (mg.GetType().FullName == AttackType.NearMagazine.ToString())
        //        Debug.Log("tes");
        //        //return mg;
        //}


        //////////////////

        ////magazine.attackType
        //foreach (var magazine in eBase.baseMagazine)
        //{
        //    //magazine.BulletLoad("prefab/EBulletNormalEX");
        //    magazine.Initialize();

        //    magazine.BulletLoad("prefab/Bullet/JerryOutBullet");
        //    magazine.SetPool(pool);

        //    var iTarget = magazine as ITarget;
        //    if (iTarget != null)
        //        iTarget.Target = GameObject.FindGameObjectWithTag("Player").transform;
        //}

    }
}
