using UnityEngine;

[DisallowMultipleComponent]
public class PlayerScr2D : CharaBase, IDamage
{
    //デバッグ用
    [SerializeField] bool IsDebugNoLife = false;

    #region　入力
    Rigidbody2D m_rb;                    //剛体
    [SerializeField] float speed = 3f;   //移動速度
    [SerializeField] Vector2 movement;
    #endregion


    bool m_isDamage = false;
    bool m_isDead = false;



    //Bullet bulletObj;
    //[SerializeField] PoolManager poolManager;
    //[SerializeField] float bulletDeadTime = 3f;
    #region バレット
    //[SerializeField] float bulletSpeed = 6f;
    [SerializeField] PlayerMagazine mag;
    //[SerializeField] Transform front;           //弾の発射方向


    //[SerializeField] GameObject pBullet;// = "prefab/Bullet/PBulletNormal";
    //[SerializeField] AudioResource pBulletSe; //="Sound/SE/PlayerNormalShot";
    #endregion


    [SerializeField] Warp warp;


    void Start()
    {


        m_rb = GetComponent<Rigidbody2D>();
        //bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/Bullet/PBulletNormal");

        //nMag.Initialize();
        //nMag.createBullet = GetComponent<CreateBullet>();
        //nMag.createBullet.LoadPath(pBullet);
        //nMag.createBullet.bulletSpeed = bulletSpeed;
        //nMag.SetLoadSe(pBulletSe);
        //nMag.Target = front;

        //nMag.TargetSet(nMag, nMag.bulletTarget);

        //nMag.createBullet.BulletAtk()

        //nMag.createBullet.AddBulletType(BulletType.NormalBullet);

        //nMag.SetPool(poolManager);


        //nMag.targetT = (transform.position + Vector3.up);
        //nMag.targetPos = (transform.position + Vector3.right);
    }

    void Update()
    {
        if (m_isDead) return;

        mag.MagazineUpdate();
        //攻撃
        //if (Input.GetKey(KeyCode.F))
        //{
        //    //nMag.targetPos = (transform.position + Vector3.up) - transform.position;
        //   nMag.MagazineEnter();

        //    //ビーム砲チャージ
        //    MyLib.MyPlayOneSound("Sound/SE/PlayerNormalShot", gameObject.GetComponent<AudioSource>());
        //}


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            warp.WarpStart();
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            warp.WarpEnd();
        }


        MoveControl();

    }

    //void createBullet.createBullet.BulletAtk()
    //{
    //    // 対象物へのベクトルを算出
    //    //Vector3 toDirection = transform.up - transform.position;
    //    // 対象物へ回転する
    //    //var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);

    //    //nMag.Initialize();
    //    //nMag.BulletLoad("prefab/Bullet/PBulletNormal");
    //    //nMag.targetPos = transform.up - transform.position;
    //    //nMag.SetPool(poolManager);

    //    //var bullet = poolManager.GetGameObject(bulletObj.gameObject, transform.position, transform.rotation);
    //    //bullet.GetComponent<Bullet>().speed = bulletSpeed;

    //    //var destroyer = bullet.GetComponent<Destroyer>();
    //    //destroyer.PoolManager = poolManager;



    //}

    void FixedUpdate()
    {
        var mPos = MoveLimit(m_rb.position + movement * speed * Time.fixedDeltaTime);

        // 物理計算による移動
//        if (Input.GetKey(KeyCode.W) ||
//Input.GetKey(KeyCode.A) ||
//Input.GetKey(KeyCode.S) ||
//Input.GetKey(KeyCode.D))
        m_rb.MovePosition(mPos);
        //transform.position=mPos;
    }

    void MoveControl()
    {
        if (Input.GetKey(KeyCode.W))
            movement.y = 1f;

        if (Input.GetKeyUp(KeyCode.W))
            movement.y = 0f;

        if (Input.GetKey(KeyCode.S))
            movement.y = -1f;

        if (Input.GetKeyUp(KeyCode.S))
            movement.y = 0f;


        if (Input.GetKey(KeyCode.A))
            movement.x = -1f;

        if (Input.GetKeyUp(KeyCode.A))
            movement.x = 0f;

        if (Input.GetKey(KeyCode.D))
            movement.x = 1f;

        if (Input.GetKeyUp(KeyCode.D))
            movement.x = 0f;

        movement = movement.normalized;

    }

    Vector3 MoveLimit(Vector3 pos)
    {

        const float XLIMIT = 8.5f;
        const float YLIMIT = 4.5f;
        //Vector3 resultPos = pos;
        pos.x = Mathf.Clamp(pos.x, -XLIMIT, XLIMIT);
        pos.y = Mathf.Clamp(pos.y, -YLIMIT, YLIMIT);

        return pos;
    }

    //void RotationControl()
    //{
    //    Vector3 rotateDirection = m_moveDirection;

    //    //それなりに移動方向が変化する場合のみ移動方向を変える
    //    if (rotateDirection.sqrMagnitude > 0.01)
    //    {
    //        //緩やかに移動方向を変える
    //        float step = ROTSPEED * Time.deltaTime;
    //        Vector3 newDir = Vector3.Slerp(transform.forward, rotateDirection, step);
    //        transform.rotation = Quaternion.LookRotation(newDir);
    //    }
    //}

    public void PlayerDamage(int damage)
    {
        if (IsDebugNoLife) return;

        //回避の実行中なら無効またはダメージ中なら無効　無敵

        if (m_isDead) return;
        if (m_isDamage) return;
        //if (m_isDash) return;　ダッシュ時無敵


        Destroy(this.gameObject);


    }

    public void Damage(int damage)
    {
        Destroy(this.gameObject);
        //throw new System.NotImplementedException();
    }



    #region　剛体関連
    //private void OnCollisionEnter(Collision collision)
    //{

    //}

    //private void OnTriggerEnter(Collider other)
    //{

    //}

    //private void OnTriggerStay(Collider other)
    //{
    //   // if (other.CompareTag("Water"))
    //    //{
    //        //m_animation.CrossFade(AnimState.runCustom.ToString());
    //        //m_rb.useGravity = false;
    //    //}
    //}

    //private void OnTriggerExit(Collider other)
    //{


    //}

    #endregion


}
