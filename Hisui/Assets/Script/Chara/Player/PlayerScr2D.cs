using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class PlayerScr2D : MonoBehaviour
{
    [SerializeField] bool IsDebugNoLife = false;

    #region�@����
    [SerializeField] float SPEED = 3f;   //�ړ����x
    const float ROTSPEED = 3f;

    Rigidbody m_rb;      //����
    Vector3 m_moveDirection;
    Vector3 m_targetDirection;

    public bool IsDash { get; private set; } = false;

    #endregion

    //#region �{�b�N�X�R���C�_�[
    //private BoxCollider m_boxColider;
    //private Vector3 m_boxStartCenter;
    //private Vector3 m_boxStartSize;

    //private Vector3 m_boxWaterSize = new (0.8f, 0.5f, 1.5f);
    //private Vector3 m_boxWaterCenter = new (0, 0.25f, 0);
    //#endregion


    #region ���b�N�I��
    //[NonSerialized]public EnemyBase m_rockOnEnemy;
    //private bool m_isEnemyRock = false;
    #endregion

    #region�@�_���[�W

    public bool m_isDamage = false;
    #endregion


    #region HP
    //private const int MAXHP = 3;
    //private int m_hp = MAXHP;
    bool m_isDead = false;

    //[SerializeField]private SkinnedMeshRenderer[] m_hpSkin;
    #endregion

    //private ParticleSystem bubbleParticle;//�A�p�[�e�B�N��

    Bullet bulletObj;//�p�[�e�B�N��
                     //[SerializeField] private float bSPEED = 0.02f;

    //public Transform front;


    public ReactiveProperty<Vector3> prePosDiff;    //using UniRx�K�v

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();

        bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/PBulletNormal");

        prePosDiff.Value = Vector3.zero;
    }

    void Update()
    {
        if (m_isDead) return;

        //�f�o�b�O�_���[�W
        if (Input.GetKeyDown(KeyCode.F))
        {
            var bulletPos = transform.position;

            //front.position==transform.up
            // �Ώە��ւ̃x�N�g�����Z�o
            Vector3 toDirection = transform.up - bulletPos;
            // �Ώە��։�]����
            var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);

            //����
            var pbullet = Instantiate(bulletObj.gameObject, bulletPos, bulletRot);
            var bulletComp = pbullet.GetComponent<Bullet>();

            //transform.up==pForward.normalized
            //var pForward = front.position - transform.position;


            //bulletComp.Initialize(transform.up, bSPEED);

        }


        //�_�ŏ���
        //if (m_isDamage)
        // skin.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));

        MoveControl();     //�ړ��p�֐�

        //RotationControl(); //����p�֐�

        // RockOnControl();   //���b�N�I������

        //Camera.main.transform.position = new Vector3(m_rb.position.x, m_rb.position.y + 2, m_rb.position.z - 2);

    }

    //void FixedUpdate()
    //{
    //    //�@�L�����N�^�[���ړ������鏈��
    //    //m_rb.MovePosition(m_rb.position + m_velocity * Time.fixedDeltaTime);
    //}

    void MoveControl()
    {
        var prePos = m_rb.position;
        //m_input = new Vector3(UnityEngine.Input.GetAxis("Horizontal"), 0f, UnityEngine.Input.GetAxis("Vertical"));

        //�i�s�����v�Z
        //�L�[�{�[�h���͂��擾
        float v;
        float h;
#if UNITY_IOS
//�Ώۃv���b�g�t�H�[����iOS�̎������R���p�C�������	
#elif UNITY_ANDROID
        //v = m_variableJoystick.Vertical;
        //h = m_variableJoystick.Horizontal;
        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
        {
            //v = m_variableJoystick.Vertical;
            //h = m_variableJoystick.Horizontal;

            //�J�����̐��ʕ����x�N�g������Y�����������A���K�����ăL����������������擾
            Vector3 forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            //if(m_isWater)Sword
            //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

            Vector3 right = Camera.main.transform.right; //�J�����̉E�������擾

            //var targetDirection = Vector3.zero;
            //�J�����̕������l�������L�����̐i�s�������v�Z
            m_targetDirection = m_variableJoystick.Horizontal * right + m_variableJoystick.Vertical * forward;
            //m_input = new Vector3(m_variableJoystick.Horizontal, 0f, m_variableJoystick.Vertical);//�Ώۃv���b�g�t�H�[����Android�̎������R���p�C�������
        }
        SPEED = 4f;
#else
        v = Input.GetAxisRaw("Vertical");         //InputManager�́����̓���
        h = Input.GetAxisRaw("Horizontal");       //InputManager�́����̓��� 

        //�J�����̐��ʕ����x�N�g������Y�����������A���K�����ăL����������������擾
        Vector3 forward = Vector3.Scale(Camera.main.transform.up, new Vector3(1, 1, 0)).normalized;
        //if(m_isWater)Sword
        //   forward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 1, 1)).normalized;

        Vector3 right = Camera.main.transform.right; //�J�����̉E�������擾

        //var targetDirection = Vector3.zero;
        //�J�����̕������l�������L�����̐i�s�������v�Z
        m_targetDirection = h * right + v * forward;
#endif

        //�ړ��̃x�N�g�����v�Z
        m_moveDirection = m_targetDirection * SPEED;

        //2D����
        //m_moveDirection.y = m_moveDirection.z;
        //m_moveDirection.z = 0;
        //

        m_rb.MovePosition(m_rb.position + m_moveDirection * Time.deltaTime);

        //1f�O�̍��W�Ƃ̍���ۑ�
        prePosDiff.Value = m_rb.position-prePos;
    }

    void RotationControl()
    {
        Vector3 rotateDirection = m_moveDirection;

        //����Ȃ�Ɉړ��������ω�����ꍇ�݈̂ړ�������ς���
        if (rotateDirection.sqrMagnitude > 0.01)
        {
            //�ɂ₩�Ɉړ�������ς���
            float step = ROTSPEED * Time.deltaTime;
            Vector3 newDir = Vector3.Slerp(transform.forward, rotateDirection, step);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
    }

    public void PlayerDamage(int damage)
    {
        if (IsDebugNoLife) return;

        //����̎��s���Ȃ疳���܂��̓_���[�W���Ȃ疳���@���G

        if (m_isDead) return;
        if (m_isDamage) return;
        //if (m_isDash) return;�@�_�b�V�������G


        Destroy(this.gameObject);
        return;


        #region �J�����V�F�C�N
        //https://baba-s.hatenablog.com/entry/2018/03/14/170400

        //�h�炷����
        const float shakeLength = 0.3f;
        //�h�炷��
        const float power = 0.3f;

        StartCoroutine(MyLib.DoShake(shakeLength, power, transform));


        #endregion

        //HP��������
        var hpUI = GetComponent<HPUIControl>();
        var hpValue = hpUI.GetHp() - damage;
        hpUI.SetHp(hpValue);
        //m_hp -= damage;
        m_isDamage = true;

        const float volumeAtk = 0.1f;
        var audioSource = this.GetComponent<AudioSource>();
        var soundAtk = (AudioClip)Resources.Load("SE/" + "���p���`");
        audioSource.PlayOneShot(soundAtk, volumeAtk);
        //  m_hpSkin[m_hp].enabled = false;        //HPUI�̔�\��

        const float DAMAGETIME = 1.5f;
        StartCoroutine(MyLib.DelayCoroutine(DAMAGETIME, () =>
        {
            // DAMAGETIME�b��ɂ����̏��������s�����
            //skin.material.color = startColor;
            m_isDamage = false;
            if (hpUI.GetHp() <= 0)
            {
                m_isDead = true;
                // skin.enabled = false;
                //���S����
                Debug.Log("���񂾂�^�C�g���J�ڂ����I");
                GameObject.Find("GAMEOVERTEXT").GetComponent<DOFade>().ShowWindow();
                //���SUI�\��
                //GameObject.Find("DeadText").GetComponent<DOFade>().ShowWindow();

                //�G�N�X�g�����[�h�̏ꍇ�����L���O�\��
                //�N���A�`�F�b�N�@�X�R�A���Z�@�G�N�X�g���V�[��
                if (GManager.I.IsSceneName(GManager.SceneNameType.GameScene.ToString()))
                {
                    //�N���A���s�Ȃ̂�false
                    //  ExtraControl.I.ShowRanking(false);
                    GManager.I.SceneChangeTimerSet(GManager.SceneNameType.TitleScene.ToString());

                }
                else
                {
                    //�^�C�g���V�[���J��
                    GManager.I.SceneChangeTimerSet(GManager.SceneNameType.TitleScene.ToString());
                }

            }

        }));

    }



    #region�@���̊֘A
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
