using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using static UnityEngine.GraphicsBuffer;
using static BaseBullet;

public class PlayerScr2D : MonoBehaviour
{
    //デバッグ用
    [SerializeField] bool IsDebugNoLife = false;

    #region　入力
    Rigidbody2D m_rb;                    //剛体
    [SerializeField] float SPEED = 3f;   //移動速度
    [SerializeField] Vector2 movement;
    #endregion


    bool m_isDamage = false;
    bool m_isDead = false;


    //バレット
    //Bullet bulletObj;
    //[SerializeField] PoolManager poolManager;
    [SerializeField] float bulletDeadTime = 3f;
    [SerializeField] TargetMagazine nMag;
    [SerializeField] Transform front;           //弾の発射方向
    //

    const string pBulletPath = "prefab/Bullet/PBulletNormal";
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        //bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/Bullet/PBulletNormal");

        nMag.createBullet = GetComponent<CreateBullet>();
        nMag.createBullet.LoadPath(pBulletPath);
        //nMag.createBullet.BulletAtk()

        //nMag.createBullet.AddBulletType(BulletType.NormalBullet);
        nMag.Initialize();
        nMag.Target = front;
        //nMag.SetPool(poolManager);


        //nMag.targetT = (transform.position + Vector3.up);
        //nMag.targetPos = (transform.position + Vector3.right);
    }

    void Update()
    {
        if (m_isDead) return;

        //デバッグダメージ
        if (Input.GetKeyDown(KeyCode.F))
        {
            //nMag.targetPos = (transform.position + Vector3.up) - transform.position;
           nMag.MagazineEnter();
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
        var mPos = MoveLimit(m_rb.position + movement * SPEED * Time.fixedDeltaTime);

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

//        //var prePos = m_rb.position;
//        //m_input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));

//        //進行方向計算
//        //キーボード入力を取得
//        float v;
//        float h;
//#if UNITY_IOS
////対象プラットフォームがiOSの時だけコンパイルされる	
//#elif UNITY_ANDROID
//        //v = m_variableJoystick.Vertical;
//        //h = m_variableJoystick.Horizontal;
//        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
//        {
//            //v = m_variableJoystick.Vertical;
//            //h = m_variableJoystick.Horizontal;

//            //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
//            Vector3 forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
//            //if(m_isWater)Sword
//            //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

//            Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

//            //var targetDirection = Vector3.zero;
//            //カメラの方向を考慮したキャラの進行方向を計算
//            m_targetDirection = m_variableJoystick.Horizontal * right + m_variableJoystick.Vertical * forward;
//            //m_input = new Vector3(m_variableJoystick.Horizontal, 0f, m_variableJoystick.Vertical);//対象プラットフォームがAndroidの時だけコンパイルされる
//        }
//        SPEED = 4f;
//#else
//        v = Input.GetAxisRaw("Vertical");         //InputManagerの↑↓の入力
//        h = Input.GetAxisRaw("Horizontal");       //InputManagerの←→の入力 

//        //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
//        Vector3 forward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 1, 0)).normalized;
//        //if(m_isWater)Sword
//        //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

//        Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

//        //var targetDirection = Vector3.zero;
//        //カメラの方向を考慮したキャラの進行方向を計算
//        m_targetDirection = h * right + v * forward;
//#endif

//        //移動のベクトルを計算
//        m_moveDirection = m_targetDirection * SPEED;

//        //2D処理
//        //m_moveDirection.y = m_moveDirection.z;
//        //m_moveDirection.z = 0;
//        //
//        Vector2 movement2D = m_moveDirection;

//        var resultPos = MoveLimit(m_rb.position + movement2D * Time.deltaTime);

//        transform.position = resultPos;
//        //m_rb.MovePosition(resultPos);

//        //1f前の座標との差を保存
//        //prePosDiff.Value = m_moveDirection * Time.deltaTime;
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
        return;


        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        //揺らす長さ
        const float shakeLength = 0.3f;
        //揺らす力
        const float power = 0.3f;

        StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion

        //HP減少処理
        var hpUI = GetComponent<HPUIControl>();
        var hpValue = hpUI.GetHp() - damage;
        hpUI.SetHp(hpValue);
        //m_hp -= damage;
        m_isDamage = true;

        const float volumeAtk = 0.1f;
        var audioSource = this.GetComponent<AudioSource>();
        var soundAtk = (AudioClip)Resources.Load("SE/" + "小パンチ");
        audioSource.PlayOneShot(soundAtk, volumeAtk);
        //  m_hpSkin[m_hp].enabled = false;        //HPUIの非表示

        const float DAMAGETIME = 1.5f;
        StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
        {
            // DAMAGETIME秒後にここの処理が実行される
            //skin.material.color = startColor;
            m_isDamage = false;
            if (hpUI.GetHp() <= 0)
            {
                m_isDead = true;
                // skin.enabled = false;


                //循環参照してしまっている？
                //死亡処理
                Debug.Log("死んだよタイトル遷移するよ！");
                GameObject.Find("GAMEOVERTEXT").GetComponent<DOFade>().ShowWindow();
                //死亡UI表示
                //GameObject.Find("DeadText").GetComponent<DOFade>().ShowWindow();

                //エクストラモードの場合ランキング表示
                //クリアチェック　スコア加算　エクストラシーン
                if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
                {
                    //クリア失敗なのでfalse
                    //  ExtraControl.I.ShowRanking(false);
                    GManager.I.SceneChangeTimerSet(GManager.SceneNameType.TitleScene.ToString());

                }
                else
                {
                    //タイトルシーン遷移
                    GManager.I.SceneChangeTimerSet(GManager.SceneNameType.TitleScene.ToString());
                }

            }

        }));

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
