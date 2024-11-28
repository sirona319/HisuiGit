using DG.Tweening;
using System;
using UnityEngine;
using static BaseBullet;
using static BaseMagazine;
using static EnemyData;

public class CreateMagazine : MonoBehaviour
{

    string bulletPath;
    

    string bulletSePath;

    public void SetBulletPath(string bullet, string se)
    {
        bulletPath = bullet;

        bulletSePath= se;
    }

    public void MagazineCreateInit(MagazineType[] mType,BulletType[] bType,GameObject go)
    {
        
        var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？

        if (mType.Length <= 0)
            Debug.Log("マガジンタイプが設定されていない");

        //baseMagazine初期化
        for (int i = 0; i < (int)mType.Length; i++)
        {
            AddSetParamComponent(mType[i], go);
            

            //    Type typeClass = Type.GetType(mType[i].ToString());

            //if (typeClass != null)
            //    eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(typeClass));
        }


        var pTrans= GameObject.FindGameObjectWithTag("Player").transform;

        foreach (var magazine in eBase.baseMagazine)
        {
            magazine.Initialize();

            //if(magazine.createBullet==null)
            magazine.createBullet = GetComponent<CreateBullet>();

            magazine.createBullet.LoadPath(bulletPath);
            magazine.createBullet.SetBulletType(bType);
            magazine.SetLoadSePath(bulletSePath);

            //ターゲットを設定プレイヤー　エネミー用？
            var iTarget = magazine as ITarget;
            if (iTarget != null)
                iTarget.Target = pTrans;
        }
        
    }

    void AddSetParamComponent(MagazineType magazineType, GameObject go)
    {

        var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？
        //左　カーブ弾の作成
        if (magazineType == MagazineType.CircleMagazineL)
        {

            Type carveClass = Type.GetType(MagazineClassName.CircleMagazine.ToString());
            if (eBase.gameObject.GetComponent(carveClass) == null)
                eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(carveClass));

            const int cirvleVal = 10;
            go.GetComponent<CircleMagazine>().angleChangeVal = -cirvleVal;
            //go.GetComponent<CarveModule>().InitParam(carveVal, rotVal);
            return;
        }

        //左　カーブ弾の作成
        if (magazineType == MagazineType.CircleMagazineR)
        {

            Type carveClass = Type.GetType(MagazineClassName.CircleMagazine.ToString());
            if (go.gameObject.GetComponent(carveClass) == null)
                eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(carveClass));


            const int cirvleVal = 10;
            go.GetComponent<CircleMagazine>().angleChangeVal = cirvleVal;
            //go.GetComponent<CarveModule>().InitParam(carveVal, rotVal);
            return;
        }


        Type typeClass = Type.GetType(magazineType.ToString());

        if (typeClass != null)
            eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(typeClass));
    }

}
