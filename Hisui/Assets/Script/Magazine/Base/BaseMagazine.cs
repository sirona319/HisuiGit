using Cysharp.Threading.Tasks.Triggers;
using System;
using UnityEngine;
using static EnemyData;

public abstract class BaseMagazine : MonoBehaviour
{

    //protected BaseBullet bulletObj;
    protected PoolManager poolManager;
    float desTime = 5f;

    public float shotTime = 0;

    public BulletType[] bulletTypeMagazine;

    public string bulletPath;

    [SerializeField] float changeAngleVal=15f;
    [SerializeField] float rotSpeed = 1f;
    [SerializeField] float bulletSpeed = 5f;

    public virtual void SetBulletTypes(BulletType[] bulletTypes)
    {
        bulletTypeMagazine = bulletTypes;
    }

    public virtual void SetPool(PoolManager pool,float time = 5f)
    {
        poolManager = pool;
        desTime = time;
    }
    public abstract void Initialize();

    public abstract void MagazineEnter();

    public abstract void MagazineUpdate();


    //Transform 引数　オーバーロード
    //バレットタイプを上書き　引数追加
    protected BaseBullet BulletAtk(float angle)
    {
        var loadObj = (GameObject)Resources.Load(bulletPath);
        var bullet = poolManager.GetGameObject(loadObj, transform.position, transform.rotation);

        var bBullet = bullet.GetComponent<BaseBullet>();
        bBullet.angle = angle;

        bBullet.BulletInit();


        //バレットタイプを追加
        for (int i = 0; i < (int)bulletTypeMagazine.Length; i++)
        {
            Type typeClass = Type.GetType(bulletTypeMagazine[i].ToString());

            if (typeClass != null)
                bBullet.gameObject.AddComponent(typeClass);


        }

        //弾の速度を設定
        bBullet.GetComponent<NormalBullet>().speed = bulletSpeed;

        var cMod = bBullet.GetComponent<CarveModule>();
        if (cMod != null)
        {
            cMod.angleVal = changeAngleVal;
            cMod.rotSpeed = rotSpeed;
            //cMod.speed = bulletSpeed;
            //var carveITarget = cMod as ITarget;
            //carveITarget.Target = pTrans;
        }



        var destroyer = bullet.GetComponent<Destroyer>();
        destroyer.pool = poolManager;//キャラの種類ごとに分けるために引き渡し
        destroyer.IsRelease = false;//二重リリース回避用フラグ

        if (destroyer != null)
            destroyer.StartDestroyTimer(desTime);


        return bBullet;
    }


}
