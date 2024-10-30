using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public static class MyLib
{
    #region�@�֗��Ȋ֐��܂Ƃ�

    public static void SetClickTrigger(EventTrigger.Entry clickEvent, EventTrigger trigger, Action action)
    {
        clickEvent.callback.AddListener((eventData) => { action(); });

        trigger.triggers.Add(clickEvent);
    }

    //public static void Shake(float duration, float magnitude)
    //{
    //    StartCoroutine(DoShake(duration, magnitude));
    //}

    //�I�u�W�F�N�g��h�炵�g����
    /*StartCoroutine(MyLib.DoShake(0.25f, 0.1f, transform));*/
    public static IEnumerator DoShake(float duration, float magnitude, Transform trans)
    {
        var pos = trans.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var z = pos.z + Random.Range(-1f, 1f) * magnitude;

            //�J������h�炷�ۂȂǁ@y���W��ύX����悤�ɂ����肷�錻�ݕύX���Ă��Ȃ�
            trans.localPosition = new Vector3(x, pos.y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        trans.localPosition = pos;
    }

    public static Quaternion TargetRotation(Transform target, Transform myTrans, float interpolant)
    {
        //������������]�̏���
        var dir = target.position - myTrans.position;

        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

        return Quaternion.Lerp(myTrans.rotation, lookAtRotation, Time.deltaTime * interpolant);

    }

    public static Quaternion TargetRotation(Vector3 targetPos, Transform myTrans, float interpolant)
    {
        //������������]�̏���
        var dir = targetPos - myTrans.position;

        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

        return Quaternion.Lerp(myTrans.rotation, lookAtRotation, Time.deltaTime * interpolant);

    }


    /// <summary>
    /// ���C���J�������烌�C���΂��Ċm�F
    /// �f���Ă��邩�̊m�F
    /// �ǂ��������������true��Ԃ��֐�
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool FrontCameraDrawObject(Transform target)
    {

        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 targetDir = target.position - cameraPos;
        //���C�̕`��
        Debug.DrawRay(cameraPos, targetDir * 100f, Color.red);

        //�J���������ǂ����𔻒�
        var vp = Camera.main.WorldToViewportPoint(target.position);
        bool isActive = vp.x >= -0.5f && vp.x <= 1.5f && vp.y >= -0.5f && vp.y <= 1.5f && vp.z >= -0.5f;
        if (!isActive)
            return isActive;


        var ray = new Ray(cameraPos, targetDir);
        //���C�̒���
        float rayDistance = 100f;
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("Block"))
                isActive = false;

        }

        return isActive;

    }

    /// <summary>
    ///�@�G�̐���Ԃ�
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int EnemyNum()
    {
        var Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length == 0)
            return 0;

        return Enemys.Length;

    }

    /// <summary>
    /// ��ԋ߂��G�̍��W���擾
    /// </summary>
    /// <param name="pos">�v���C���[�Ȃǂ̃I�u�W�F�N�g���W</param>
    /// <returns>��ԋ߂��G�̍��W</returns>
    public static Vector3 EnemysNearVec(Vector3 pos)
    {
        var Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length == 0)
            return Vector3.zero;

        Vector3 nearVec = Enemys[0].transform.position;
        float nearLen = Vector3.Distance(pos, nearVec);
        foreach (GameObject enemy in Enemys)
        {
            float enemyLen = Vector3.Distance(pos, enemy.transform.position);
            if (enemyLen <= nearLen)
            {
                nearVec = enemy.transform.position;
                nearLen = enemyLen;//�����̍X�V
            }
        }

        return nearVec;
    }

    public static EnemyBase EnemysNearScr(Vector3 pos)
    {
        var Enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (Enemys.Length == 0)
            return null;

        Vector3 nearVec = Enemys[0].transform.position;
        float nearLen = Vector3.Distance(pos, nearVec);
        EnemyBase saveEnemy = null;
        foreach (GameObject enemy in Enemys)
        {
            var baseEnemy = enemy.GetComponent<EnemyBase>();
            //�G������ł����疳���@
            //if (baseEnemy.GetState() == (int)EnemyStateController.EnemyStateType.EnemyStateChild_Dead)
            //{
                //baseEnemy.rockImage.enabled = false;
               // continue;
           // }

            float enemyLen = Vector3.Distance(pos, baseEnemy.transform.position);
            if (enemyLen <= nearLen)
            {
                //nearVec = baseEnemy.transform.position;

                nearLen = enemyLen;//�����̍X�V

                saveEnemy = baseEnemy;//�������߂��G�̕ۑ�
            }
        }

        return saveEnemy;
    }

    /// <summary>
    /// ��莞�Ԍ�ɏ������Ăяo���R���[�`��
    /// </summary>
    /// <param name="seconds">�b</param>
    /// <param name="action">�֐����̏���</param>
    /// <returns></returns>
    public static IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

    /// <summary>
    /// ��莞�Ԍ�ɏ��������I�ɌĂяo���R���[�`��
    /// </summary>
    /// <param name="seconds">�b</param>
    /// <param name="action">�֐����̏���</param>
    /// <returns></returns>
    public static IEnumerator LoopDelayCoroutine(float seconds, Action action)
    {
        while(true)
        {
            yield return new WaitForSeconds(seconds);
            action?.Invoke();
        }

    }

    /// <summary>
    /// �C���X�^���X�𐶐����Ďw���Component���擾����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="original"></param>
    /// <returns></returns>
    public static T InstantiateGetComponent<T>(GameObject original)
        where T : Component
    {
        var go = UnityEngine.Object.Instantiate(original);
        return go.GetComponent<T>();
    }

    public static T GetComponentLoad<T>(string name)
        where T : Component
    {
        var go = (GameObject)Resources.Load(name);
        return go.GetComponent<T>();
    }

    public static T InstantiateGetComponentLoad<T>(string name, Transform trans)
        where T : Component
    {
        var go = (GameObject)Resources.Load(name);

        return UnityEngine.Object.Instantiate(go, trans).GetComponent<T>(); ;
    }



    /// <summary>
    /// �{�����[����������
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    /// <param name="obj"></param>
    public static void MyPlayOneSound(string name, float volume, GameObject obj)
    {
        var audioSource = obj.GetComponent<AudioSource>();
        var sound = (AudioClip)Resources.Load(name);
        audioSource.PlayOneShot(sound, volume);
    }

    /// <summary>
    /// �{�����[�������Ȃ�
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public static void MyPlayOneSound(string name, GameObject obj)
    {
        var audioSource = obj.GetComponent<AudioSource>();
        var sound = (AudioClip)Resources.Load(name);
        audioSource.PlayOneShot(sound);
    }

    /// <summary>
    /// �T�E���h���d�����Ȃ��悤��
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public static void MyPlayOneSoundSingle(string name, GameObject obj)
    {
        var audioSource = obj.GetComponent<AudioSource>();
        var sound = (AudioClip)Resources.Load(name);

        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(sound);
    }

    #endregion
}
