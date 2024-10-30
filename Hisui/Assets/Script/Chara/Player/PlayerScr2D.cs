using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class PlayerScr2D : MonoBehaviour
{
    [SerializeField] bool IsDebugNoLife = false;

    #region　入力
    [SerializeField] float SPEED = 3f;   //移動速度
    const float ROTSPEED = 3f;

    Rigidbody m_rb;      //剛体
    Vector3 m_moveDirection;
    Vector3 m_targetDirection;

    public bool IsDash { get; private set; } = false;

    #endregion

    //#region ボックスコライダー
    //private BoxCollider m_boxColider;
    //private Vector3 m_boxStartCenter;
    //private Vector3 m_boxStartSize;

    //private Vector3 m_boxWaterSize = new (0.8f, 0.5f, 1.5f);
    //private Vector3 m_boxWaterCenter = new (0, 0.25f, 0);
    //#endregion


    #region ロックオン
    //[NonSerialized]public EnemyBase m_rockOnEnemy;
    //private bool m_isEnemyRock = false;
    #endregion

    #region　ダメージ

    public bool m_isDamage = false;
    #endregion


    #region HP
    //private const int MAXHP = 3;
    //private int m_hp = MAXHP;
    bool m_isDead = false;

    //[SerializeField]private SkinnedMeshRenderer[] m_hpSkin;
    #endregion

    //private ParticleSystem bubbleParticle;//泡パーティクル

    Bullet bulletObj;//パーティクル
                     //[SerializeField] private float bSPEED = 0.02f;

    //public Transform front;


    public ReactiveProperty<Vector3> prePosDiff;    //using UniRx必要

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();

        bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/PBulletNormal");

        prePosDiff.Value = Vector3.zero;
    }

    void Update()
    {
        if (m_isDead) return;

        //デバッグダメージ
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bulletPos = transform.position;

            //front.position==transform.up
            // 対象物へのベクトルを算出
            Vector3 toDirection = transform.up - bulletPos;
            // 対象物へ回転する
            var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);

            //生成
            var pbullet = Instantiate(bulletObj.gameObject, bulletPos, bulletRot);
            var bulletComp = pbullet.GetComponent<Bullet>();

            //transform.up==pForward.normalized
            //var pForward = front.position - transform.position;


            //bulletComp.Initialize(transform.up, bSPEED);

        }


        //点滅処理
        //if (m_isDamage)
        // skin.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        MoveControl();     //移動用関数

        //RotationControl(); //旋回用関数

        // RockOnControl();   //ロックオン処理

        //Camera.main.transform.position = new Vector3(m_rb.position.x, m_rb.position.y + 2, m_rb.position.z - 2);

    }

    //void FixedUpdate()
    //{
    //    //　キャラクターを移動させる処理
    //    //m_rb.MovePosition(m_rb.position + m_velocity * Time.fixedDeltaTime);
    //}

    void MoveControl()
    {
        var prePos = m_rb.position;
        //m_input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));

        //進行方向計算
        //キーボード入力を取得
        float v;
        float h;
#if UNITY_IOS
//対象プラットフォームがiOSの時だけコンパイルされる	
#elif UNITY_ANDROID
        //v = m_variableJoystick.Vertical;
        //h = m_variableJoystick.Horizontal;
        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
        {
            //v = m_variableJoystick.Vertical;
            //h = m_variableJoystick.Horizontal;

            //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
            Vector3 forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            //if(m_isWater)Sword
            //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

            Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

            //var targetDirection = Vector3.zero;
            //カメラの方向を考慮したキャラの進行方向を計算
            m_targetDirection = m_variableJoystick.Horizontal * right + m_variableJoystick.Vertical * forward;
            //m_input = new Vector3(m_variableJoystick.Horizontal, 0f, m_variableJoystick.Vertical);//対象プラットフォームがAndroidの時だけコンパイルされる
        }
        SPEED = 4f;
#else
        v = Input.GetAxisRaw("Vertical");         //InputManagerの↑↓の入力
        h = Input.GetAxisRaw("Horizontal");       //InputManagerの←→の入力 

        //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
        Vector3 forward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 1, 0)).normalized;
        //if(m_isWater)Sword
        //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

        Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

        //var targetDirection = Vector3.zero;
        //カメラの方向を考慮したキャラの進行方向を計算
        m_targetDirection = h * right + v * forward;
#endif

        //移動のベクトルを計算
        m_moveDirection = m_targetDirection * SPEED;

        //2D処理
        //m_moveDirection.y = m_moveDirection.z;
        //m_moveDirection.z = 0;
        //

        m_rb.MovePosition(m_rb.position + m_moveDirection * Time.deltaTime);

        //1f前の座標との差を保存
        prePosDiff.Value = m_rb.position-prePos;
    }

    void RotationControl()
    {
        Vector3 rotateDirection = m_moveDirection;

        //それなりに移動方向が変化する場合のみ移動方向を変える
        if (rotateDirection.sqrMagnitude > 0.01)
        {
            //緩やかに移動方向を変える
            float step = ROTSPEED * Time.deltaTime;
            Vector3 newDir = Vector3.Slerp(transform.forward, rotateDirection, step);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

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
