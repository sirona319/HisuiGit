using System;
using UnityEngine;
using static BaseBullet;

public class CreateBullet : MonoBehaviour
{
    //public enum BulletTarget
    //{
    //    Player,
    //    LeftMiddle,
    //    Up,
    //    Right,
    //    Left,
    //    Down,

    //    Target,
    //    None,
    //    //斜め　四つ　
    //    //一番近いエネミーなど？　遠い敵　レーザー


    //}
    //enum PoolType
    //{
    //    enemy,
    //    player,
    //}

    //[SerializeField] PoolType poolType;

    [SerializeField] float bulletSpeed = 5f;

    //[SerializeField] BulletType[] bulletType;

    //[SerializeField] GameObject bulletObj;
    [SerializeField] PoolControl poolCtr;

    private void Start()
    {
        //if (poolCtr != null) return;

        //if (PoolType.enemy == poolType)
        //{
        //    poolCtr = GameObject.Find("EnemyPoolMgr").GetComponent<PoolControl>();
        //}
        //else if (PoolType.player == poolType)
        //{
        //    poolCtr = GameObject.Find("Player").GetComponent<PoolControl>();

        //}
    }

    //public void LoadPath(GameObject bullet)
    //{
    //    bulletObj = bullet;
    //}

    //public void SetBulletType(BulletType[] bulletTypes)
    //{
    //    bulletType = bulletTypes;
    //}

    public void AddBulletType(BaseBullet bullet, string bulletTypeName)
    {
        Type typeClass = Type.GetType(bulletTypeName);

        if (typeClass != null && bullet.gameObject.GetComponent(typeClass) == null)
            bullet.gameObject.AddComponent(typeClass);

    }

    public GameObject BulletAtk(float angle,Vector3 pos,Quaternion rot, GameObject charaBullet=null)
    {
        Debug.Log("BulletAtk");

        if (charaBullet == null)
            return null;


        Debug.Log("BulletAtk");
        charaBullet.transform.position = pos;
        charaBullet.transform.rotation = rot;
        var bullet = Instantiate(charaBullet);

        //var bullet = poolCtr.GetGameObject(charaBullet, pos, rot);

        //if (bulletType.Length > 0)
        //{
        //    //return null;

        //    //バレットタイプを追加
        //    for (int i = 0; i < (int)bulletType.Length; i++)
        //    {

        //        AddSetParamComponent(bulletType[i], bullet);

        //    }

        //}


        if (bullet.GetComponent<NormalBullet>() != null)
        {
            var normalBullet = bullet.GetComponent<NormalBullet>();
            normalBullet.SetSpeed(bulletSpeed);
            normalBullet.angle = angle;
            normalBullet.BulletInit();
        }

        //if(bullet.GetComponent<ForceBullet>() != null)
        //{
        //    //bullet.GetComponent<ForceBullet>().speed = bulletSpeed;
        //    //bullet.GetComponent<ForceBullet>().angle = angle;
        //    bullet.GetComponent<ForceBullet>().BulletInit();
        //}


        //var destroyer = bullet.GetComponent<ReleaseDestroyer>();
        //destroyer.pool = poolCtr;//キャラの種類ごとに分けるために引き渡し
        //destroyer.IsRelease = false;//二重リリース回避用フラグ


        return bullet;
    }

    //public GameObject BulletAtkNotGravity(float angle, Vector3 pos, Quaternion rot,GameObject charaBullet)
    //{
    //    charaBullet.transform.position = pos;
    //    charaBullet.transform.rotation = rot;
    //    var bullet = Instantiate(charaBullet);

  
    //    //var bullet = poolCtr.GetGameObject(charaBullet, pos, rot);

    //    //bullet.GetComponent<Rigidbody2D>().gravityScale = 0f;

    //    if (bullet.GetComponent<NormalBullet>() != null)
    //    {
    //        var normalBullet = bullet.GetComponent<NormalBullet>();
    //        normalBullet.SetSpeed(bulletSpeed);
    //        normalBullet.angle = angle;
    //        normalBullet.BulletInit();
    //    }

    //    //var destroyer = bullet.GetComponent<ReleaseDestroyer>();
    //    //destroyer.pool = poolCtr;//キャラの種類ごとに分けるために引き渡し
    //    //destroyer.IsRelease = false;//二重リリース回避用フラグ


    //    return bullet;
    //}

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
