using System.Net;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    public enum BulletType
    {
        NormalBullet,
        ForceBullet,


        ShakeModule,
        //CarveModule,//パラメータ設定できるようにしたい曲がる量　敵ごとに

        CarveModuleL,
        CarveModuleR,
        //分裂団
        //遅延弾
        //拡大弾
        //

        RotModule,

    }

    public enum ModuleClassName
    {
        CarveModule,//パラメータ設定できるようにしたい曲がる量　敵ごとに
    }

    //public float angle; // 角度
    //[SerializeField]public float speed; // 速度
    //public Vector2 velocity; // 移動量

    public abstract void BulletInit();

    public abstract void BulletUpdate();

    //PoolMangagerで使用するときangleの再設定時　角度を変更させる
    //public abstract void SetBullet();
}
