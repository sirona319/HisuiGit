using System;
using UnityEditor.EditorTools;
using UnityEngine;
using static BaseBullet;

public class CreateBullet : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 5f;

    [SerializeField]BulletType[] bulletType;

    GameObject bulletObj;
    [SerializeField] PoolControl poolManager;


    public void LoadPath(GameObject bullet)
    {
        bulletObj = bullet;
    }

    public void SetBulletType(BulletType[] bulletTypes)
    {
        bulletType = bulletTypes;
    }

    public void AddBulletType(BaseBullet bullet, string bulletTypeName)
    {
        Type typeClass = Type.GetType(bulletTypeName);

        if (typeClass != null && bullet.gameObject.GetComponent(typeClass) == null)
            bullet.gameObject.AddComponent(typeClass);

    }

    public BaseBullet BulletAtk(float angle,Vector3 pos,Quaternion rot)
    {

        var bullet = poolManager.GetGameObject(bulletObj, pos, rot);

        if (bulletType.Length <= 0)
        {
            return null;
        }


        //バレットタイプを追加
        for (int i = 0; i < (int)bulletType.Length; i++)
        {

            AddSetParamComponent(bulletType[i], bullet);

        }


        bullet.GetComponent<NormalBullet>().speed = bulletSpeed;
        bullet.GetComponent<NormalBullet>().angle = angle;
        bullet.GetComponent<NormalBullet>().BulletInit();


        var destroyer = bullet.GetComponent<ReleaseDestroyer>();
        destroyer.pool = poolManager;//キャラの種類ごとに分けるために引き渡し
        destroyer.IsRelease = false;//二重リリース回避用フラグ


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
            bullet.GetComponent<CarveModule>().SetAngle(carveVal);
            return;
        }

        //右　カーブ弾の作成
        if (bulletType == BulletType.CarveModuleR)
        {
            Type carveClass = Type.GetType(ModuleClassName.CarveModule.ToString());
            if (bullet.gameObject.GetComponent(carveClass) == null)
                bullet.gameObject.AddComponent(carveClass);

            const float carveVal = 15f;
            bullet.GetComponent<CarveModule>().SetAngle(carveVal);
            return;
        }

        Type typeClass = Type.GetType(bulletType.ToString());

        if (typeClass != null && bullet.gameObject.GetComponent(typeClass) == null)
           bullet.gameObject.AddComponent(typeClass);

    }


}
