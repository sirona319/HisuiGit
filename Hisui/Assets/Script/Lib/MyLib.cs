using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public static class MyLib
{
    #region　便利な関数まとめ

    public static void SetClickTrigger(EventTrigger.Entry clickEvent, EventTrigger trigger, Action action)
    {
        clickEvent.callback.AddListener((eventData) => { action(); });

        trigger.triggers.Add(clickEvent);
    }

    //public static void Shake(float duration, float magnitude)
    //{
    //    StartCoroutine(DoShake(duration, magnitude));
    //}

    //オブジェクトを揺らし使い方
    /*StartCoroutine(MyLib.DoShake(0.25f, 0.1f, transform));*/
    public static IEnumerator DoShake(float duration, float magnitude, Transform trans)
    {
        var pos = trans.localPosition;

        var elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitude;
            var z = pos.z + Random.Range(-1f, 1f) * magnitude;

            //カメラを揺らす際など　y座標を変更するようにしたりする現在変更していない
            trans.localPosition = new Vector3(x, pos.y, z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        trans.localPosition = pos;
    }

    public static Quaternion TargetRotation(Transform target, Transform myTrans, float interpolant)
    {
        //方向を向く回転の処理
        var dir = target.position - myTrans.position;

        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

        return Quaternion.Lerp(myTrans.rotation, lookAtRotation, Time.deltaTime * interpolant);

    }

    public static Quaternion TargetRotation(Vector3 targetPos, Transform myTrans, float interpolant)
    {
        //方向を向く回転の処理
        var dir = targetPos - myTrans.position;

        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

        return Quaternion.Lerp(myTrans.rotation, lookAtRotation, Time.deltaTime * interpolant);

    }


    /// <summary>
    /// メインカメラからレイを飛ばして確認
    /// 映っているかの確認
    /// どちらも成功したらtrueを返す関数
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool FrontCameraDrawObject(Transform target)
    {

        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 targetDir = target.position - cameraPos;
        //レイの描画
        Debug.DrawRay(cameraPos, targetDir * 100f, Color.red);

        //カメラ内かどうかを判定
        var vp = Camera.main.WorldToViewportPoint(target.position);
        bool isActive = vp.x >= -0.5f && vp.x <= 1.5f && vp.y >= -0.5f && vp.y <= 1.5f && vp.z >= -0.5f;
        if (!isActive)
            return isActive;


        var ray = new Ray(cameraPos, targetDir);
        //レイの長さ
        float rayDistance = 100f;
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("Block"))
                isActive = false;

        }

        return isActive;

    }

    /// <summary>
    ///　敵の数を返す
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
    /// 一番近い敵の座標を取得
    /// </summary>
    /// <param name="pos">プレイヤーなどのオブジェクト座標</param>
    /// <returns>一番近い敵の座標</returns>
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
                nearLen = enemyLen;//距離の更新
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
            //敵が死んでいたら無効　
            //if (baseEnemy.GetState() == (int)EnemyStateController.EnemyStateType.EnemyStateChild_Dead)
            //{
                //baseEnemy.rockImage.enabled = false;
               // continue;
           // }

            float enemyLen = Vector3.Distance(pos, baseEnemy.transform.position);
            if (enemyLen <= nearLen)
            {
                //nearVec = baseEnemy.transform.position;

                nearLen = enemyLen;//距離の更新

                saveEnemy = baseEnemy;//距離が近い敵の保存
            }
        }

        return saveEnemy;
    }

    /// <summary>
    /// 一定時間後に処理を呼び出すコルーチン
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
    /// <returns></returns>
    public static IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

    /// <summary>
    /// 一定時間後に処理を定期的に呼び出すコルーチン
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
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
    /// インスタンスを生成して指定のComponentを取得する
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
    /// ボリューム調整あり
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
    /// ボリューム調整なし
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
    /// サウンドが重複しないように
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
