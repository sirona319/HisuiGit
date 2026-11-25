using UnityEngine;

public abstract class BaseMagazine : MonoBehaviour
{

    public enum MagazineType
    {
        TargetMagazine,
        FiveMagazine,
        CircleOneMagazine,

        CircleMagazineR,
        CircleMagazineL,

        TwoCarveMagazine,

        //NearMagazine,

        //NumAttackType,
    }

    public enum MagazineClassName
    {
        CircleMagazine,
    }

    //public float shotTime = 0;

    //public CreateBullet createBullet;

    //public BulletTarget bulletTarget;

    //[SerializeField]protected AudioResource arSe;
    //public void SetLoadSe(AudioResource se)
    //{
    //    arSe = se;
    //}

    public virtual void Initialize() { }

    public virtual void MagazineEnter() { }

    public virtual void MagazineUpdate() { }

    //public void TargetSet(ITarget it, BulletTarget bulletTarget, GameObject go)
    //{
    //    if (it == null) return;

    //    switch (bulletTarget)
    //    {
    //        case BulletTarget.Player:
    //            it.Target = GameObject.FindGameObjectWithTag(TagName.Player).transform;
    //            break;
    //        case BulletTarget.LeftMiddle:
    //            //it.Target = leftMiddle;
    //            it.Target= GameObject.Find("LeftMiddle").transform;
    //            break;
    //        case BulletTarget.Up:
    //            it.Target = go.transform.Find("Up").gameObject.transform;
    //            break;
    //        case BulletTarget.Right:
    //            it.Target = go.transform.Find("Right").gameObject.transform;
    //            break;
    //        case BulletTarget.Left:
    //            it.Target = go.transform.Find("Left").gameObject.transform;
    //            break;
    //        case BulletTarget.Down:
    //            it.Target = go.transform.Find("Down").gameObject.transform;
    //            break;
    //        case BulletTarget.Target://子階層のtargetオブジェクトを参照
    //            it.Target = go.transform.Find("target").gameObject.transform;
    //            break;
    //        case BulletTarget.None:
    //            break;
    //        default:
    //            Debug.Log("TargetDEFAULT");
    //            break;
    //    }

    //}

    [SerializeField] protected float bulletSpeed = 5f;

    ////[SerializeField] PoolControl poolCtr;
    //PoolType poolType = PoolType.Enemy;
    //public enum PoolType
    //{
    //    Player,
    //    Enemy,
    //}

    protected virtual GameObject BulletAtk(float angle, Vector3 pos, Quaternion rot, GameObject charaBullet = null)
    {

        if (charaBullet == null) return null;

        charaBullet.transform.position = pos;
        charaBullet.transform.rotation = rot;
        var bullet = Instantiate(charaBullet);

        // var bullet = poolCtr.GetGameObject(charaBullet,pos,rot);//Instantiate(charaBullet);


        // 自分のプールを登録する
        //var release = bullet.GetComponent<ReleaseDestroyer>();
        //release.pool = poolCtr;
        // if (bullet.GetComponent<NormalBullet>() != null)
        // {
        var normalBullet = bullet.GetComponent<NormalBullet>();
            normalBullet.SetSpeed(bulletSpeed);
            normalBullet.angle = angle;
            normalBullet.BulletInit();
       // }

        return bullet;
    }
}
