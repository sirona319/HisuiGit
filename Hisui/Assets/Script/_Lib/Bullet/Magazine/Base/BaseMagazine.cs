using UnityEngine;

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

    //[SerializeField]protected AudioSource arSe;
    //public void SetLoadSe(AudioSource se)
    //{
    //    arSe = se;
    //}

    public virtual void Initialize() { }

    public virtual void MagazineEnter() { }

    public abstract void MagazineUpdate();

    //public void TargetSet(Transform t, BulletTarget bulletTarget)
    //{
    //    if (t == null) return;

    //    //一番近いエネミーなど？　遠い敵　レーザー武器用など（Player）
    //    //Instanteiateで生成することで子階層から外す　座標ずれを防ぐため
    //    switch (bulletTarget)
    //    {
    //        case BulletTarget.Player:
    //            t = GameObject.FindWithTag("Player").transform;
    //            break;
    //        //case BulletTarget.LeftMiddle://固定
    //        //    //it.Target = leftMiddle;
    //        //    t = GameObject.Find("LeftMiddle").transform;
    //        //    break;
    //        case BulletTarget.Up:
    //            var up = transform.Find("Target").gameObject.transform;
    //            up.position += Vector3.up;
    //            t = up;
    //            break;
    //        case BulletTarget.Right:
    //            var right = transform.Find("Target").gameObject.transform;
    //            right.position += Vector3.right;
    //            t = right;
    //            break;
    //        case BulletTarget.Left:
    //            var left = transform.Find("Target").gameObject.transform;
    //            left.position += Vector3.left;
    //            t = left;
    //            break;
    //        case BulletTarget.Down:
    //            var down = transform.Find("Target").gameObject.transform;
    //            down.position += Vector3.down;
    //            t = down;
    //            break;
    //        case BulletTarget.Target:
    //            t = transform.Find("Target").transform;
    //            break;
    //        case BulletTarget.TargetVec://固定
    //            var pos = transform.Find("TargetVec").transform.position;
    //            var go = (GameObject)Resources.Load("prefab/Bullet/TargetVecObject");
    //            var obj = Instantiate(go, pos, transform.rotation);
    //            t = obj.transform;
    //            obj.GetComponent<SetLinkObj>().linkObj = gameObject;
    //            break;
    //        default:
    //            Debug.Log("ターゲット未設定");
    //            break;
    //    }

    //}


    [SerializeField] protected float bulletSpeed = 5f;

    [SerializeField] PoolControl poolCtr;
    public GameObject BulletAtk(float angle, Vector3 pos, Quaternion rot, GameObject charaBullet = null)
    {

        if (charaBullet == null)
        {
            Debug.Log("charaBullet NULL");
            return null;


        }

        charaBullet.transform.position = pos;
        charaBullet.transform.rotation = rot;
        var bullet = Instantiate(charaBullet);


        if (bullet.GetComponent<NormalBullet>() != null)
        {
            var normalBullet = bullet.GetComponent<NormalBullet>();
            normalBullet.SetSpeed(bulletSpeed);
            normalBullet.angle = angle;
            normalBullet.BulletInit();
        }

        return bullet;
    }
}
