using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.Audio;
using static BaseBullet;
using static BaseMagazine;
using static EnemyData;
using static UnityEngine.GraphicsBuffer;

public class CreateMagazine : MonoBehaviour
{

    GameObject bulletGo;


    AudioResource bulletSe;

    [SerializeField] Transform leftMiddle;
    [SerializeField] Transform target;

    public void SetBullet(GameObject bullet, AudioResource se)
    {
        bulletGo = bullet;

        bulletSe = se;
    }

    public void MagazineCreateInit
        (MagazineType[] mType,BulletType[] bType,GameObject go, BulletTarget bulletTarget)
    {
        
        var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？

        if (mType.Length <= 0)
            Debug.Log("マガジンタイプが設定されていない");

        //baseMagazine初期化
        for (int i = 0; i < (int)mType.Length; i++)
        {
            AddSetParamComponent(mType[i], go);
        }



        //ななめ
        foreach (var magazine in eBase.baseMagazine)
        {
            magazine.Initialize();

            magazine.createBullet = GetComponent<CreateBullet>();

            magazine.createBullet.LoadPath(bulletGo);
            magazine.createBullet.SetBulletType(bType);
            magazine.SetLoadSe(bulletSe);

            //ターゲットを設定プレイヤー　エネミー用？
            var t=magazine as ITarget;
            TargetSet(t,bulletTarget,go);
        }
        
    }

    void AddSetParamComponent(MagazineType magazineType, GameObject go)
    {

        var eBase = go.GetComponent<EnemyBase>();//CharaBaseにする　最終的に？
        //左　カーブ弾の作成
        if (magazineType == MagazineType.CircleMagazineL)
        {
            Type carveClass = Type.GetType(MagazineClassName.CircleMagazine.ToString());
            if (go.gameObject.GetComponent(carveClass) == null)
                eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(carveClass));

            const int cirvleVal = 10;
            go.GetComponent<CircleMagazine>().angleChangeVal = -cirvleVal;

            return;
        }
        //左　カーブ弾の作成
        else if (magazineType == MagazineType.CircleMagazineR)
        {
            Type carveClass = Type.GetType(MagazineClassName.CircleMagazine.ToString());
            if (go.gameObject.GetComponent(carveClass) == null)
                eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(carveClass));

            const int cirvleVal = 10;
            go.GetComponent<CircleMagazine>().angleChangeVal = cirvleVal;

            return;
        }


        Type typeClass = Type.GetType(magazineType.ToString());

        if (typeClass != null)
            eBase.baseMagazine.Add((BaseMagazine)go.AddComponent(typeClass));
    }


    void TargetSet(ITarget it, BulletTarget bulletTarget,GameObject go)
    {
        if (it == null) return;

        switch(bulletTarget)
        {
            case BulletTarget.Player:
                it.Target = GameObject.FindGameObjectWithTag("Player").transform;
                break;
            case BulletTarget.LeftMiddle:
                it.Target = leftMiddle;
                break;
            case BulletTarget.Up:
                it.Target = go.transform.Find("Up").gameObject.transform;
                break;
            case BulletTarget.Right:
                it.Target = go.transform.Find("Right").gameObject.transform;
                break;
            case BulletTarget.Left:
                it.Target = go.transform.Find("Left").gameObject.transform;
                break;
            case BulletTarget.Down:
                it.Target = go.transform.Find("Down").gameObject.transform;
                break;
            default:
                Debug.Log("TargetDEFAULT");
                break;
        }

    }

}
