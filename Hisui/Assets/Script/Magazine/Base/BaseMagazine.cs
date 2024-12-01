using Cysharp.Threading.Tasks.Triggers;
using System;
using UnityEngine;
using UnityEngine.Audio;
using static EnemyData;

public abstract class BaseMagazine : MonoBehaviour
{
    //全てがクラス名ではない　AddComponent際にパラメータ変更して扱う
    public enum MagazineType
    {
        TargetMagazine,
        FiveMagazine,
        CircleOneMagazine,

        CircleMagazineR,
        CircleMagazineL,

        TwoCarveMagazine,
        //CircleInverseMagazine,

        //NearMagazine,

        //NumAttackType,
    }

    public enum MagazineClassName
    {
        CircleMagazine,
    }

    public float shotTime = 0;

    //protected PoolManager poolManager;
    //float desTime = 5f;

    //public string bulletPath;
    //public BulletType[] bulletTypeMagazine;

    public CreateBullet createBullet;
    //GameObject bulletObj;

    //[SerializeField] float bulletSpeed = 5f;
    //[SerializeField] float changeAngleVal=15f;
    //[SerializeField] float rotSpeed = 1f;


    //public virtual void SetBulletTypes(BulletType[] bulletTypes)
    //{
    //    bulletTypeMagazine = bulletTypes;
    //}
    //public virtual void LoadBullet(string bulletPath)
    //{
    //    createBullet.Load(bulletPath);
    //}

    //public virtual void SetPool(PoolManager pool)
    //{
    //    createBullet.poolManager = pool;
    //    //desTime = time;
    //}
    protected AudioResource arSe;
    public void SetLoadSe(AudioResource se)
    {
        arSe = se;
    }

    public abstract void Initialize();

    public abstract void MagazineEnter();

    public abstract void MagazineUpdate();

    //バレットタイプを上書き　引数追加
    //protected BaseBullet createBullet.BulletAtk(float angle)
    //{

    //    var bullet = poolManager.GetGameObject(bulletObj, transform.position, transform.rotation);

    //    var bBullet = bullet.GetComponent<BaseBullet>();
    //    bBullet.angle = angle;

    //    bBullet.BulletInit();



    //    var destroyer = bullet.GetComponent<Destroyer>();
    //    destroyer.pool = poolManager;//キャラの種類ごとに分けるために引き渡し
    //    destroyer.IsRelease = false;//二重リリース回避用フラグ

    //    if (destroyer != null)
    //        destroyer.StartDestroyTimer(desTime);


    //    return createBullet.BulletCreateInit(bBullet);
    //}


}
