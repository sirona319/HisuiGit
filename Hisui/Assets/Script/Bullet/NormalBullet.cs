using UnityEngine;

public class NormalBullet : BaseBullet
{



    private void Update()
    {
        //transform.position +=(Vector3)velocity * speed * Time.deltaTime;

        //transform.rotation =
        //       MyLib.TargetRotation2DZOnlyLerp(transform.up, transform, ref velocity, speed, 1f);




        //transform.position +=  velocity * 4f * Time.deltaTime;
        BulletUpdate();
    }

    public override void BulletInit()
    {
        //return;

        Vector3 velocity = Vector3.zero;
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // 弾の向きを設定する
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);
    }

    public override void BulletUpdate()
    {
        // 毎フレーム、弾を移動させる
        //transform.position += (Vector3)velocity * Time.deltaTime;

        transform.position += transform.up * speed * Time.deltaTime;
    }



}
