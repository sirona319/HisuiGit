using UnityEngine;

public class ShakeBullet : BaseBullet
{

    private void Start()
    {
        gameObject.AddComponent<ShakeModule>();
    }


    private void Update()
    {
        BulletUpdate();
    }


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


    }


    void InitShake()
    {
        const float power = 0.03f;            //揺らす力
        const int frame = 25;            //揺らすタイミング
        StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime * frame, () =>
        {
            MyLib.DoShakeUpdate2D(power, transform);
        }));

    }



    public override void BulletUpdate()
    {
        // 毎フレーム、弾を移動させる
      //  transform.position += velocity * Time.deltaTime;
    }

}
