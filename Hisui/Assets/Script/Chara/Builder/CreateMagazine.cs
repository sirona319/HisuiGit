using System;
using UnityEngine;
using static BaseBullet;
using static BaseMagazine;
using static EnemyData;

public class CreateMagazine : MonoBehaviour
{
    public void MagazineCreateInit(MagazineType[] mType,BulletType[] bType,GameObject go)
    {
        
        var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？

        if (mType.Length <= 0)
            Debug.Log("マガジンタイプが設定されていない");

        //baseMagazine初期化
        for (int i = 0; i < (int)mType.Length; i++)
        {
            Type typeClass = Type.GetType(mType[i].ToString());

            if (typeClass != null)
                eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(typeClass));
        }


        var pTrans= GameObject.FindGameObjectWithTag("Player").transform;

        foreach (var magazine in eBase.baseMagazine)
        {
            magazine.Initialize();

            if(magazine.createBullet==null)
            magazine.createBullet = GetComponent<CreateBullet>();

            magazine.createBullet.LoadPath("prefab/Bullet/JerryBullet");
            magazine.createBullet.SetBulletType(bType);


            //ターゲットを設定プレイヤー　エネミー用？
            var iTarget = magazine as ITarget;
            if (iTarget != null)
                iTarget.Target = pTrans;
        }
        
    }


}
