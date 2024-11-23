using UnityEngine;

public class ShakeCarveBullet : BaseBullet
{

    private void Update()
    {
        BulletUpdate();
    }

    //[SerializeField] bool IsTargetOutBullet = false;
    public override void BulletInit()
    {

        Vector3 velocity = Vector3.zero;
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // 弾の向きを設定する
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        InitOut();
    }

    void InitOut()
    {

        StartCoroutine(MyLib.DelayCoroutine(Time.deltaTime * 30, () =>
        {
            angle += 15f;

            Vector3 velocity = Vector3.zero;
            // X方向の移動量を設定する
            velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

            // Y方向の移動量を設定する
            velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


            // 弾の向きを設定する
            float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            transform.rotation = Quaternion.Euler(0, 0, zAngle);

        }));



        //StartCoroutine(MyLib.DelayCoroutine(Time.deltaTime * 15, () =>
        //{
        //    angle += 15f;
        //    BulletInit();

        //}));



        //StartCoroutine(MyLib.DelayCoroutine(Time.deltaTime * 20, () =>
        //{
        //    angle += 20f;
        //    BulletInit();

        //}));
        
    }

    public override void BulletUpdate()
    {
        // 毎フレーム、弾を移動させる
        //transform.position += velocity * Time.deltaTime;
    }

}
