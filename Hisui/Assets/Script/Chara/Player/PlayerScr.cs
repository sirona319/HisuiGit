using System;
using UnityEngine;

public class PlayerScr : MonoBehaviour
{
    #region　入力
    [SerializeField]float SPEED = 3f;   //移動速度
    const float ROTSPEED = 3f;
    //private const float DASHTIMEMAX = 0.7f;//ダッシュ時間
    //private const float DASHSPEED = 12f;//ダッシュ速度

    //private Vector3 m_input;    //入力値
    private Rigidbody m_rb;      //剛体
    private Vector3 m_moveDirection;
    private Vector3 m_targetDirection;

    //private bool m_isJump = false;
    //private bool m_isWater = false;
    //private bool m_isGround = false;
    public bool IsDash { get; private set; } = false;

    //private const float DRAGVALUE = 3.0f;
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
    //[SerializeField] private SkinnedMeshRenderer skin;

    //private const float duration = 0.2f;

    //private Color32 startColor = new (255, 255, 255, 255);

    //private Color32 endColor = new (255, 255, 255, 64);

    [NonSerialized]public bool m_isDamage = false;
    #endregion

#if UNITY_ANDROID

    #region モバイル
    [SerializeField] private VariableJoystick m_variableJoystick;
    #endregion
#endif

    #region HP
    //private const int MAXHP = 3;
    //private int m_hp = MAXHP;
    private bool m_isDead = false;

    //[SerializeField]private SkinnedMeshRenderer[] m_hpSkin;
    #endregion

    //private ParticleSystem bubbleParticle;//泡パーティクル

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        //m_variableJoystick = GameObject.Find("MyVariable Joystick").GetComponent<VariableJoystick>();
        //m_boxColider= GetComponent<BoxCollider>();
        //m_boxStartCenter=GetComponent<BoxCollider>().center;
        // m_boxStartSize = GetComponent<BoxCollider>().size;


        //Camera.main.GetComponent<CameraScr>().target = this.gameObject.transform;

        //bubbleParticle = MyLib.GetComponentLoad<ParticleSystem>("prefab/BubbleParticle");

    }

    void Update()
    {
        if (m_isDead) return;

        //デバッグダメージ
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    PlayerDamage(1);
        //}

        //点滅処理
        //if (m_isDamage)
       // skin.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        MoveControl();     //移動用関数

        RotationControl(); //旋回用関数

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

        //SPEED = 3f;
        ////水中ダッシュ
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    //Dash();
        //    SPEED = 4f;
        //}

        //カメラの正面方向ベクトルからY成分を除き、正規化してキャラが走る方向を取得
        Vector3 forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 0)).normalized;
        //if(m_isWater)Sword
        //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

        Vector3 right = Camera.main.transform.right; //カメラの右方向を取得

        //var targetDirection = Vector3.zero;
        //カメラの方向を考慮したキャラの進行方向を計算
        m_targetDirection = h * right + v * forward;
#endif




        //if (IsDash)
        //{
        //    //パーティクル
        //    //Instantiate(bubbleParticle.gameObject, transform.position, Quaternion.identity);

        //    const float ROLLSPEED = 15f;
        //    var rot = Quaternion.AngleAxis(ROLLSPEED, Vector3.forward);

        //    transform.rotation = transform.rotation * rot;

        //}



        //移動のベクトルを計算
        m_moveDirection = m_targetDirection * SPEED;

        m_rb.MovePosition(m_rb.position + m_moveDirection * Time.deltaTime);

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
        //回避の実行中なら無効またはダメージ中なら無効　無敵

        if (m_isDead) return;
        if (m_isDamage) return;
        //if (m_isDash) return;　ダッシュ時無敵



        #region カメラシェイク
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        //揺らす長さ
        const float shakeLength= 0.3f;
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
        audioSource.PlayOneShot(soundAtk,volumeAtk);
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
