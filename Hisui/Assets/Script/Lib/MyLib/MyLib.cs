using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using Random = UnityEngine.Random;

//utility
public static class MyLib
{
    #region　便利な関数まとめ

    #region  sin移動

    //上下　浮遊のような動き
    public static void LoopMotionSinWait(Transform t,float addX,float addY)
    {
        float sin = Mathf.Sin(Time.time);
        t.position = new Vector3(t.position.x + (sin * addX), t.position.y+(sin * addY), 0);
    }

    //Vector3で移動方向　周期的なカーブ移動
    public static void LoopMotionSinVector(Transform t, Vector3 addVec/*float addX, float addY*/, Vector3 v)
    {
        float sin = Mathf.Sin(Time.time);
        t.position = new Vector3(t.position.x + (sin * addVec.x), t.position.y + (sin * addVec.y), 0);

        var tp = t.position;
        tp += v;
        t.position = tp;

    }

    #endregion

    #region　トリガー　判定


    public static void SetClickTrigger(EventTrigger.Entry clickEvent, EventTrigger trigger, Action action)
    {
        clickEvent.callback.AddListener((eventData) => { action(); });

        trigger.triggers.Add(clickEvent);
    }



    #endregion

    #region 揺れ

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

    //使い方　持続的に揺らすときなどに　Start関数などでループコルーチンを登録
    //const float power = 0.03f;
    //const int frame = 25;
    //StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime* frame, () =>
    //    {
    //    MyLib.DoShakeUpdate2D(power, transform);
    //}));
    public static void DoShakeUpdate2D(float magnitude, Transform trans)
    {

        var pos = trans.localPosition;


        var x = pos.x + Random.Range(-1f, 1f) * magnitude;
        var y = pos.y + Random.Range(-1f, 1f) * magnitude;

        trans.localPosition = new Vector3(x, y, 0f);


    }

    #endregion

    #region 回転

    public static Quaternion TargetRotation(Transform target, Transform myTrans, float interpolant, Vector3 axis)
    {
        //方向を向く回転の処理
        var dir = target.position - myTrans.position;

        var lookAtRotation = Quaternion.LookRotation(dir, axis);

        return Quaternion.Lerp(myTrans.rotation, lookAtRotation, Time.deltaTime * interpolant);

    }

    public static Quaternion TargetRotation(Vector3 targetPos, Transform myTrans, float interpolant,Vector3 axis)
    {
        //方向を向く回転の処理
        var dir = targetPos - myTrans.position;

        var lookAtRotation = Quaternion.LookRotation(dir, axis);

        return Quaternion.Lerp(myTrans.rotation, lookAtRotation, Time.deltaTime * interpolant);

    }

    public static Quaternion TargetRotation2D(Vector3 targetPos, Transform myTrans, float interpolant = 5f)
    {
        //const float INTERPOLANT = 5f;

        Vector2 dir = targetPos - myTrans.position;

        var targetRotation = Quaternion.LookRotation(dir, Vector3.right);
        //Quaternion targetRotation = Quaternion.FromToRotation(Vector3.forward, targetDirection.normalized);

        return Quaternion.Lerp(myTrans.rotation, targetRotation, interpolant * Time.deltaTime);
    }

    public static float GetTargetAngle(Vector3 targetPos, Transform myTrans)
    {
        Vector2 direction = targetPos - myTrans.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        return angle;
    }

    public static Vector2 SetVelocityAngle2D(float angle, float speed)
    {
        Vector2 velocity = Vector2.zero;
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        return velocity;
    }


    //Vector3用　引数
    public static Vector2 SetVelocityAngle2D(Vector3 velocity, float angle, float speed)
    {
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        return velocity;
    }

    public static Quaternion TargetRotation2DZOnlyLerp(Transform myTrans,Vector2 velocity, float rotSpeed)
    {

        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;        // 弾の向きを設定する

        return Quaternion.Lerp(myTrans.rotation, Quaternion.Euler(0, 0, zAngle), rotSpeed * Time.deltaTime);
    }

    //public static Quaternion TargetRotation2DOnlyLerpZ
    //    (Transform myTrans,Vector3 targetPos, ref Vector2 velocity,float speed, float rotSpeed)
    //{
    //    Vector2 direction = targetPos - myTrans.position;
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する


    //    // X方向の移動量を設定する
    //    velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

    //    // Y方向の移動量を設定する
    //    velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


    //    float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;        // 弾の向きを設定する

    //    return Quaternion.Lerp(myTrans.rotation, Quaternion.Euler(0, 0, zAngle), rotSpeed * Time.deltaTime);
    //}

    #endregion

    #region　エネミー

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

    /// 一番近い敵を返す
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

    #endregion

    #region　コルーチン


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
    /// 一定時間後に処理を定期的に呼び出すコルーチン
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
    /// <returns></returns>
    public static IEnumerator LoopDelayCoroutineIf(float seconds,bool IfBreak,Action action)
    {
        while (true)
        {

            yield return new WaitForSeconds(seconds);
            action?.Invoke();

            //yield return new WaitWhile(() => IfBreak);
            //break;


        }

    }


    /// <summary>
    /// 条件がtrueなら呼び出すコルーチン
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
    /// <returns></returns>
    //public static IEnumerator BoolDelayCoroutine(float seconds, Action action)
    //{

    //        //yield return new WaitUntil(条件);trueなら
    //        //yield return new WaitWhile(条件);falseなら

    //        //action?.Invoke();
    //}

    #endregion

    #region　ロード　インスタンス生成


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

    #endregion

    #region　サウンド


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


    #endregion
}