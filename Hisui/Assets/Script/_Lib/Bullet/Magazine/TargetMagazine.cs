using UnityEngine;

public class TargetMagazine : BaseMagazine
{
    //Vector3 tPos;

    float intervalTime = 0f; //ExitでintervalTimeMaxにする？
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform target;
    void Start()
    {

    }

    public override void MagazineEnter()
    {

    }

    public override void MagazineUpdate()
    {
        //Debug.Log("f");
        intervalTime -= Time.deltaTime;
        if (intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;

            Shot();
        }
    }

    void Shot()
    {
        Debug.Log("Shot");
        Vector2 direction = target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        BulletAtk(pAngle, transform.position, transform.rotation, bullet); //Target渡す
    }


    //public Transform Target { get; set; }

    //CreateBullet createBullet;
    ////逆回り作る
    //public override void Initialize()
    //{
    //    createBullet = GetComponent<CreateBullet>();
    //}
    //public override void MagazineEnter()
    //{
    //    //if (targetTrans == null) return;
    //    NormalShot();
    //    //MyLib.MyPlayOneSound(arSe, gameObject.GetComponent<AudioSource>());//発射時の音声
    //}
    //public override void MagazineUpdate()
    //{

    //}

    //void NormalShot()
    //{

    //    Vector2 direction = Target.position - transform.position;
    //    float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

    //    createBullet.BulletAtk(pAngle, transform.position, transform.rotation); //Target渡す
    //}

}


