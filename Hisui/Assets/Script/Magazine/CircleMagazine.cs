using UnityEditor.EditorTools;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CircleMagazine : BaseMagazine
{

    float timeCount = 0;
    float shotAngle = 0;

    const float BULLETTIMEMAX = 4f;

    //逆回り作る
    public override void Initialize()
    {
        shotTime = BULLETTIMEMAX;
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

        const int angleChangeVal = 10;
        const float shotTiming = 0.1f;
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
