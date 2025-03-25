using UnityEngine;

public class CircleMagazine : BaseMagazine
{
    [SerializeField] int angleChangeVal = 10;
    [SerializeField] float shotTiming = 0.1f;

    float timeCount = 0;
    float shotAngle = 0;

    //const float BULLETTIMEMAX = 4f;

    //public float shotTime = 0;

    CreateBullet createBullet;

    //public BulletTarget bulletTarget;
    //逆回り作る
    public override void Initialize()
    {
        createBullet = GetComponent<CreateBullet>();
        //shotTime = BULLETTIMEMAX;
    }

    public override void MagazineEnter()
    {
        shotAngle = 0;
    }

    public override void MagazineUpdate()
    {
        CircleShot();
    }

    void CircleShot()
    {
        // 前フレームからの時間の差を加算
        timeCount += Time.deltaTime;


        // 0.1秒を超えているか
        if (timeCount > shotTiming)
        {
            timeCount = 0; // 再発射のために時間をリセット

            shotAngle += angleChangeVal;

            //撃ち初めの角度の設定　向き
            Vector2 direction =(transform.position+Vector3.up) - transform.position;
            float tAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

            createBullet.BulletAtk(tAngle + shotAngle,transform.position,transform.rotation);

        }
    }

}
