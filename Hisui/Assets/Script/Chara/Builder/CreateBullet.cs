using System;
using UnityEditor.EditorTools;
using UnityEngine;
using static BaseBullet;

public class CreateBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;


    //[SerializeField] float carveAngleVal = 15f;
    //[SerializeField] float carveRotSpeed = 1f;

    //public EnemyData eData;

    [SerializeField]BulletType[] bulletType;

    GameObject bulletObj;
    [SerializeField]PoolManager poolManager;


    public void LoadPath(string bulletPath)
    {
        bulletObj=(GameObject)Resources.Load(bulletPath);
    }

    public void SetBulletType(BulletType[] bulletTypes)
    {
        bulletType = bulletTypes;
    }

    public void AddBulletType(BaseBullet bullet, string bulletTypeName)
    {
        //for (int i = 0; i < (int)bulletType.Length; i++)
        //{
        Type typeClass = Type.GetType(bulletTypeName);

        if (typeClass != null && bullet.gameObject.GetComponent(typeClass) == null)
            bullet.gameObject.AddComponent(typeClass);


        //}
    }

    public BaseBullet BulletAtk(float angle,Vector3 pos,Quaternion rot)
    {

        var bullet = poolManager.GetGameObject(bulletObj, pos, rot);

        if (bulletType.Length <= 0)
        {
            //throw new System.Exception("バレットが指定されていない");
            //Debug.Log("バレットタイプが無し");
            return null;
        }


        //バレットタイプを追加
        for (int i = 0; i < (int)bulletType.Length; i++)
        {
            //Type typeClass = Type.GetType(bulletType[i].ToString());

            AddSetParamComponent(bulletType[i], bullet);

            //if (typeClass != null && bullet.gameObject.GetComponent(typeClass) == null)
            //   bullet.gameObject.AddComponent(typeClass);

        }


        bullet.GetComponent<NormalBullet>().speed = bulletSpeed;
        bullet.GetComponent<NormalBullet>().angle = angle;
        bullet.GetComponent<NormalBullet>().BulletInit();
        //CreateCarve(bBullet.GetComponent<CarveModule>());

        //CreateShake();


        var destroyer = bullet.GetComponent<Destroyer>();
        destroyer.pool = poolManager;//キャラの種類ごとに分けるために引き渡し
        destroyer.IsRelease = false;//二重リリース回避用フラグ

        //if (destroyer != null)
           // destroyer.StartDestroyTimer(5);


        return bullet.GetComponent<NormalBullet>();
    }

    void AddSetParamComponent(BulletType bulletType,GameObject bullet)
    {

        //左　カーブ弾の作成
        if (bulletType==BulletType.CarveModuleL)
        {

            Type carveClass = Type.GetType(ModuleClassName.CarveModule.ToString());
            if (bullet.gameObject.GetComponent(carveClass) == null)
                bullet.gameObject.AddComponent(carveClass);

            const float carveVal = 15f;
            const float rotVal = 2f;
            bullet.GetComponent<CarveModule>().InitParam(carveVal, rotVal);
            return;
        }

        //右　カーブ弾の作成
        if (bulletType == BulletType.CarveModuleR)
        {
            Type carveClass = Type.GetType(ModuleClassName.CarveModule.ToString());
            if (bullet.gameObject.GetComponent(carveClass) == null)
                bullet.gameObject.AddComponent(carveClass);

            const float carveVal = 15f;
            const float rotVal = 2f;
            bullet.GetComponent<CarveModule>().InitParam(-carveVal, rotVal);
            return;
        }

        Type typeClass = Type.GetType(bulletType.ToString());

        if (typeClass != null && bullet.gameObject.GetComponent(typeClass) == null)
           bullet.gameObject.AddComponent(typeClass);

    }



    //BaseBullet BulletCreateType(GameObject bBullet)
    //{
    //    //if(bulletType.Length<=0)
    //    //{
    //    //    //throw new System.Exception("バレットが指定されていない");
    //    //    //Debug.Log("バレットタイプが無し");
    //    //    return null;
    //    //}
    //    ////バレットタイプを追加
    //    //for (int i = 0; i < (int)bulletType.Length; i++)
    //    //{
    //    //    Type typeClass = Type.GetType(bulletType[i].ToString());

    //    //    if (typeClass != null&&bBullet.gameObject.GetComponent(typeClass)==null)
    //    //        bBullet.gameObject.AddComponent(typeClass);

    //    //}

    //    //bBullet.GetComponent<NormalBullet>().speed = bulletSpeed;
    //    //bBullet.GetComponent<NormalBullet>().angle = bulletSpeed;
    //    //bBullet.GetComponent<NormalBullet>().BulletInit();
    //    ////CreateCarve(bBullet.GetComponent<CarveModule>());

    //    ////CreateShake();

    //    //return bBullet.GetComponent<NormalBullet>();


    //}



    //void CreateCarve(CarveModule carve)
    //{
    //    if (carve == null) return;
    //    if (carve.IsParamSet) return;

    //    carve.InitParam(carveAngleVal, carveRotSpeed);

    //    //carve.angleVal = carveAngleVal;
    //    //carve.rotSpeed = carveRotSpeed;

    //}
}
