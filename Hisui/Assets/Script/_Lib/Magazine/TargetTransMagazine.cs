using UnityEngine;
using static TargetSet;

public class TargetTransMagazine : BaseMagazine
{
    //[SerializeField] float shotTime = 0;

    CreateBullet createBullet;

    //TargetSet targetSet;
    //[SerializeField] Target targetType;
    Vector3 tPos;
    //[SerializeField] AudioSource arSe;

    float intervalTime = 1f;
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform targetTrans;
    void Start()
    {

        createBullet = GetComponent<CreateBullet>();
        //var targetSet = GetComponent<TargetSet>();
        //targetSet.Init();
        tPos = GetComponent<TargetSet>().GetTargetTrans(targetTrans).position;
        //target = transform.Find("Target").transform;
        //shotTime = 1f;
    }

    public override void MagazineEnter()
    {

    }
    public override void MagazineUpdate()
    {
        intervalTime -= Time.deltaTime;
        if (intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;

            MyLib.MyPlayOneSound("Sound/SE/JerryShot", gameObject.GetComponent<AudioSource>());//水滴
            Shot();
        }


    }

    void Shot()
    {

        Vector2 direction = tPos - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        if(createBullet == null)
            Debug.Log("createBullet null");

        if(bullet == null)
            Debug.Log("bullet null");

        createBullet.BulletAtk(pAngle, transform.position, transform.rotation, bullet); //Target渡す
    }


    //public override void MagazineEnter()
    //{
    //    //if (targetTrans == null) return;
    //    NormalShot();
    //    MyLib.MyPlayOneSound(arSe, gameObject.GetComponent<AudioSource>());//水滴
    //}
    //public override void MagazineUpdate()
    //{
    //    //shotTime-=Time.deltaTime;

    //}

    //void NormalShot()
    //{

    //    Vector2 direction = Target.position - transform.position;
    //    float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

    //    createBullet.BulletAtk(pAngle, transform.position, transform.rotation); //Target渡す
    //}

}


