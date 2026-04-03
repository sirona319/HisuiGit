using UnityEngine;

public class NormalMagazine : BaseMagazine
{
    //Vector3 target;

    float intervalTime = 1f;
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform target;

    [SerializeField] string soundPath = "Sound/SE/JerryShot";

    //[SerializeField] float bulletSpeed = 5f;

    //[SerializeField] PoolControl poolCtr;
    void Start()
    {

        //target = TargetSet.I.GetTargetTrans(targetTrans, gameObject).position;

    }


    public void Update()
    {
        if (target == null) return;

        intervalTime -= Time.deltaTime;
        if (intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;

            MyLib.MyPlayOneSound(soundPath, gameObject.GetComponent<AudioSource>());//水滴
            Shot();
        }


    }

    void Shot()
    {

        Vector2 direction = target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        var eBullet = Instantiate(bullet, transform.position, transform.rotation);


        var normalBullet = eBullet.GetComponent<NormalBullet>();
        normalBullet.SetSpeed(bulletSpeed);
        normalBullet.angle = pAngle;
        normalBullet.BulletInit();

    }

    public override void MagazineUpdate()
    {
        throw new System.NotImplementedException();
    }
}
