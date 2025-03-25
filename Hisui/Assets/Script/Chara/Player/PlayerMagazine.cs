using UnityEngine;
using static TargetSet;

[DisallowMultipleComponent]
public class PlayerMagazine : BaseMagazine
{
    //public float shotTime = 0;

    CreateBullet createBullet;
    //[SerializeField] Target targetType;
    TargetSet targetSet;
    Transform target;

    float intervalTime = 1f;
    [SerializeField]float intervalTimeMax = 1f;

    void Start()
    {
        createBullet = GetComponent<CreateBullet>();
        targetSet = GetComponent<TargetSet>();
        //targetSet.Init();
        target = targetSet.Set(TargetName.Bullet);
        //target = transform.Find("Target").transform;
        //shotTime = 1f;
        intervalTime = intervalTimeMax;
    }


    public override void MagazineEnter()
    {
        //if (targetTrans == null) return;
        //NormalShot();
        //MyLib.MyPlayOneSound(arSe, gameObject.GetComponent<AudioSource>());//水滴
    }
    public override void MagazineUpdate()
    {

        intervalTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.F)&&intervalTime<=0)
        {
            intervalTime = intervalTimeMax;
            //nMag.targetPos = (transform.position + Vector3.up) - transform.position;
            NormalShot();

            //ビーム砲チャージ
            MyLib.MyPlayOneSound("Sound/SE/PlayerNormalShot", gameObject.GetComponent<AudioSource>());
        }
    }

    void NormalShot()
    {

        Vector2 direction = target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        createBullet.BulletAtk(pAngle, transform.position, transform.rotation); //Target渡す
    }
}
