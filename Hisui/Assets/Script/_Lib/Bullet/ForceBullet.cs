using UnityEngine;

//弾のほうへ付けるスクリプト
public class ForceBullet : BaseBullet
{
    //[SerializeField] Vector3 force;
    [SerializeField] Vector3 tForceX;
    [SerializeField] Vector3 tForceXInv;
    Rigidbody2D rb;


    //  1
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    //  2
    private void OnEnable()
    {
        //プレイヤーのフリップの方向で反対へ　X方向　プレイヤーのtargetを取得する　座標 Start
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p.GetComponent<SpriteRenderer>().flipX)
            rb.AddForce(tForceX, ForceMode2D.Impulse);
        else
            rb.AddForce(tForceXInv, ForceMode2D.Impulse);


        //没　毎回切り替わる
        //////////var p = tForce.position;
        //////////p.x *= -1;
        //////////tForce.position = p;
    }
    //  3
    void Start()
    {
        //rb=GetComponent<Rigidbody2D>();

        //rb.AddForce(force, ForceMode2D.Impulse);

        //Debug.Log("force");
    }


    //private void Update()
    //{
    //    BulletUpdate();
    //}

    public override void BulletInit()
    {
        //Vector3 velocity = Vector3.zero;
        //// X方向の移動量を設定する
        //velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        //// Y方向の移動量を設定する
        //velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        //// 弾の向きを設定する
        //float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        //transform.rotation = Quaternion.Euler(0, 0, zAngle);


        //rb.AddForce(force,ForceMode2D.Impulse);

        //Debug.Log("force");
    }

    public override void BulletUpdate()
    {
        //Vector3 force = new Vector3(0.0f, 0.0f, 1.0f);    // 力を設定
        //rb.AddForce(force);  // 力を加える

        // 毎フレーム、弾を移動させる
        //transform.position += transform.up * speed * Time.deltaTime;//前方方向に進む（回転によって進行方向が変化する）
    }
}
