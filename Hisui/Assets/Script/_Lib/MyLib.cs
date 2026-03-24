using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;
using Transform = UnityEngine.Transform;

//utility
public static class MyLib
{

    #region　便利な関数まとめ

    #region デバッグ
    public static void DebugInfo(GameObject go)
    {
        Debug.Log(go.name + " " + go.tag + " " + go.layer + "\n" + go.GetType().FullName);
    }
    #endregion

    #region  sin移動

    //    if(sinType == SinType.Add)
    //    addSinTime = Time.deltaTime;
    //else if(sinType == SinType.Sub)
    //    addSinTime = -Time.deltaTime;

    //上下　浮遊のような動き
    public static void LoopMotionSinWait(float sinTime, Transform t, float addX, float addY)
    {
        //float sin = Mathf.Sin(Time.time);
        float sin = Mathf.Sin(sinTime);
        t.position = new Vector3(t.position.x + (sin * addX), t.position.y + (sin * addY), 0);
    }

    //Vector3で移動方向　周期的なカーブ移動
    public static void LoopMotionSinVector(float sinTime, Transform t, Vector3 addVec/*float addX, float addY*/, Vector3 v)
    {
        float sin = Mathf.Sin(sinTime);
        t.position = new Vector3(t.position.x + (sin * addVec.x), t.position.y + (sin * addVec.y), 0);

        var tp = t.position;
        tp += v;
        t.position = tp;

    }

    //public static void LoopMotionCosVector(Transform t, Vector3 addVec/*float addX, float addY*/, Vector3 v)
    //{
    //    float sin = Mathf.Cos(Time.time);
    //    t.position = new Vector3(t.position.x + (sin * addVec.x), t.position.y + (sin * addVec.y), 0);

    //    var tp = t.position;
    //    tp += v;
    //    t.position = tp;

    //}

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
    //https://baba-s.hatenablog.com/entry/2018/03/14/170400
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

    public static IEnumerator DoShake2D(float duration, float magnitudeX, float magnitudeY, Transform trans, float zPos = 0f)
    {
        Vector2 pos = trans.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            var x = pos.x + Random.Range(-1f, 1f) * magnitudeX;
            var y = pos.y + Random.Range(-1f, 1f) * magnitudeY;

            //カメラを揺らす際など　y座標を変更するようにしたりする現在変更していない
            trans.localPosition = new Vector3(x, pos.y, zPos);

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
    public static void DoShakeUpdate2D(float magnitude, Transform trans, float zPos = 0f)
    {

        var pos = trans.localPosition;


        var x = pos.x + Random.Range(-1f, 1f) * magnitude;
        var y = pos.y + Random.Range(-1f, 1f) * magnitude;

        trans.localPosition = new Vector3(x, y, zPos);


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

    public static Quaternion TargetRotation(Vector3 targetPos, Transform myTrans, float interpolant, Vector3 axis)
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

    public static Quaternion GetAngleRotationFuncs(Vector3 tPos, Transform myTrans, float rotSpeed)
    {
        float targetAngle = GetTargetAngle2D(tPos, myTrans);

        var velocity = SetVelocityAngle2D(targetAngle);

        return TargetRotation2DZOnlyLerp(myTrans, velocity, rotSpeed); ;
    }

    public static float GetTargetAngle2D(Vector3 targetPos, Transform myTrans)
    {
        Vector2 direction = targetPos - myTrans.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        return angle;
    }

    public static Vector2 SetVelocityAngle2D(float angle)
    {
        Vector2 velocity = Vector2.zero;
        // X方向の移動量を設定する
        velocity.x = Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = Mathf.Sin(angle * Mathf.Deg2Rad);

        return velocity;
    }


    //Vector3用　引数
    //public static Vector2 SetVelocityAngle2D(Vector3 velocity, float angle, float speed)
    //{
    //    // X方向の移動量を設定する
    //    velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

    //    // Y方向の移動量を設定する
    //    velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

    //    return velocity;
    //}

    public static Vector2 SetVelocityAngle2DSpeed(float angle, float speed)
    {
        Vector2 velocity = Vector2.zero;
        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);

        return velocity;
    }

    public static Quaternion TargetRotation2DZOnlyLerp(Transform myTrans, Vector2 velocity, float rotSpeed)
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

    #region 移動

    public static Vector3 KeepVecY(Vector3 vec, float val)
    {
        var Vec= vec;
        Vec.y = val;
        return vec = Vec;

    }

    //public static Vector3 TargetMoveNormalized(Vector3 target, Vector3 pos)
    //{
    //    Vector3 direction = target - pos;

    //    return direction.normalized;

    //}
    #endregion

    #region カメラ

    /// <summary>
    /// メインカメラからレイを飛ばして確認
    /// 映っているかの確認
    /// どちらも成功したらtrueを返す関数
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool FrontCameraDrawObject(Vector3 target)
    {

        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 targetDir = target - cameraPos;
        //レイの描画
        Debug.DrawRay(cameraPos, targetDir * 100f, Color.red);

        //カメラ内かどうかを判定
        var vp = Camera.main.WorldToViewportPoint(target);
        bool isActive = vp.x >= -0.5f && vp.x <= 1.5f && vp.y >= -0.5f && vp.y <= 1.5f && vp.z >= -0.5f;
        //bool isActive = vp.x >= -1.5f && vp.x <= 1.5f && vp.y >= -1.5f && vp.y <= 1.5f && vp.z >= -1.5f;
        if (isActive==false)
            return isActive;


        var ray = new Ray(cameraPos, targetDir);
        //レイの長さ
        float rayDistance = 100f;
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            //壁判定用
            //if (hit.collider.gameObject.CompareTag("Block"))
            //    isActive = false;

        }

        return isActive;
    }

    public static bool IsVisibleByCamera(Vector3 target)
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(target);
        // viewPosのx座標とy座標が0以上1以下かつzが0以上だったらみえる
        if (viewPos.x >= 0 && viewPos.x <= 1 &&
            viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z >= 0)
        {
            //Debug.Log("カメラ内");
            return true;
        }
        else
        {
           // Debug.Log("カメラ外");
            return false;
        }
    }

    public static void TargetCamera(GameObject target,Transform tr,float interpolant)
    {
        var eDir = target.transform.position - tr.position;

        var elookAtRotation = Quaternion.LookRotation(eDir, Vector3.up);

        //const float INTERPOLANT = 5f;補間関数
        tr.rotation = Quaternion.Lerp(tr.rotation, elookAtRotation, Time.deltaTime * interpolant);
    }

    #endregion

    #region　レイ


    //レイの表示Scene右上の球体Gizmob Onにする
    public static GameObject DebugRayViewCameraPosZ(bool DebugDraw = true)
    {
        float distance = 1000;   // 飛ばす&表示するRayの長さ
        float duration = 50; // 表示期間（秒）

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (DebugDraw)
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

        RaycastHit hit = new RaycastHit();
        GameObject hitObject = null;
        if (Physics.Raycast(ray, out hit, distance))
        {
            hitObject = hit.collider.gameObject;

            if (DebugDraw)
                Debug.Log(hitObject.name);

            return hitObject;
        }

        return hitObject;
    }

    //レイの表示Scene右上の球体Gizmob Onにする 座標を返す　オブジェクトがあたっていないときは飛ばした先の座標を返す
    public static Vector3 DebugRayViewCameraPosXZ(bool DebugDraw = true)
    {
        float distance = 1000;   // 飛ばす&表示するRayの長さ
        float duration = 50; // 表示期間（秒）

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (DebugDraw)
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

        RaycastHit hit = new RaycastHit();
        GameObject hitObject = null;
        if (Physics.Raycast(ray, out hit, distance))
        {
            hitObject = hit.collider.gameObject;

            if (DebugDraw)
                Debug.Log(hitObject.name);

            //return hitObject;
        }

        return new Vector3(hit.point.x, 0f, hit.point.z);
    }

    //特定のレイヤーのみ
    public static GameObject DebugRayViewCameraPosZLayer(string layerName = "", bool DebugDraw = true)
    {
        float distance = 1000f;
        float duration = 50f;

        Camera mainCam = Camera.main;
        if (mainCam == null) return null;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (DebugDraw)
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);
        }

        // レイヤーマスクの作成（引数が空なら全レイヤーを対象にする）
        int layerMask = string.IsNullOrEmpty(layerName) ? Physics.DefaultRaycastLayers : 1 << LayerMask.NameToLayer(layerName);

        // 引数に layerMask を追加
        if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
        {
            if (DebugDraw) Debug.Log($"Hit [{layerName}]: {hit.collider.gameObject.name}");
            return hit.collider.gameObject;
        }

        return null;
    }

    //(1 << LayerMask.NameToLayer("Enemy")) | (1 << LayerMask.NameToLayer("NPC"))
    public static GameObject DebugRayViewCameraPosZLayer(string layerName = "", string layerName2 = "", bool DebugDraw = true)
    {
        float distance = 1000f;
        float duration = 50f;

        Camera mainCam = Camera.main;
        if (mainCam == null) return null;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (DebugDraw)
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);
        }

        // レイヤーマスクの作成（引数が空なら全レイヤーを対象にする）
        int layerMask = string.IsNullOrEmpty(layerName) ? Physics.DefaultRaycastLayers : 1 << LayerMask.NameToLayer(layerName)|
            (1<<LayerMask.NameToLayer(layerName2));

        // 引数に layerMask を追加
        if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
        {
            if (DebugDraw) Debug.Log($"Hit [{layerName}]: {hit.collider.gameObject.name}");
            return hit.collider.gameObject;
        }

        return null;
    }

    //メインカメラのZ位置 cameraZ
    //public static GameObject DebugRayViewCameraZ(float cameraZ)
    //{
    //    Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZ));

    //    Vector3 targetDir = worldPos + new Vector3(0, 0, 100f);//(MousePos + Vector3.forward) - MousePos;

    //    //Debug.DrawRay(worldPos, targetDir * 100, Color.red, 100, false);        //レイの描画


    //    float distance = 1000;   // 飛ばす&表示するRayの長さ
    //    float duration = 50; // 表示期間（秒）

    //    Ray ray = Camera.main.ScreenPointToRay(worldPos);
    //    Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

    //    RaycastHit hit = new RaycastHit();
    //    if (Physics.Raycast(ray, out hit, distance))
    //    {
    //        GameObject hitObject = hit.collider.gameObject;
    //        Debug.Log(hitObject.name);

    //        return hitObject;
    //    }

    //    return null;
    //}

    #endregion

    #region　キャラ

    /// <summary>
    ///　敵の数を返す
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static int CharaNum(string tagName)
    {
        var Charas = GameObject.FindGameObjectsWithTag(tagName);
        if (Charas.Length == 0)
            return 0;

        return Charas.Length;

    }

    /// <summary>
    /// 一番近い敵の座標を取得
    /// </summary>
    /// <param name="pos">プレイヤーなどのオブジェクト座標</param>
    /// <returns>一番近い敵の座標を返す</returns>
    //public static Vector3 EnemysNearVec(Vector3 pos)
    //{
    //    var Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    //    if (Enemys.Length == 0)
    //        return Vector3.zero;

    //    Vector3 nearVec = Enemys[0].transform.position;
    //    float nearLen = Vector3.Distance(pos, nearVec);
    //    foreach (GameObject enemy in Enemys)
    //    {
    //        float enemyLen = Vector3.Distance(pos, enemy.transform.position);
    //        if (enemyLen <= nearLen)
    //        {
    //            nearVec = enemy.transform.position;
    //            nearLen = enemyLen;//距離の更新
    //        }
    //    }

    //    return nearVec;
    //}

    ///// 一番近い敵を返す
    //public static EnemyBase EnemysNearScr(Vector3 pos)
    //{
    //    var Enemys = GameObject.FindGameObjectsWithTag(TagName.Enemy);
    //    if (Enemys.Length == 0)
    //        return null;

    //    Vector3 nearVec = Enemys[0].transform.position;
    //    float nearLen = Vector3.Distance(pos, nearVec);
    //    EnemyBase saveEnemy = null;
    //    foreach (GameObject enemy in Enemys)
    //    {
    //        var baseEnemy = enemy.GetComponent<EnemyBase>();
    //        //敵が死んでいたら無効　
    //        //if (baseEnemy.GetState() == (int)EnemyStateController.EnemyStateType.EnemyStateChild_Dead)
    //        //{
    //            //baseEnemy.rockImage.enabled = false;
    //           // continue;
    //       // }

    //        float enemyLen = Vector3.Distance(pos, baseEnemy.transform.position);
    //        if (enemyLen <= nearLen)
    //        {
    //            //nearVec = baseEnemy.transform.position;

    //            nearLen = enemyLen;//距離の更新

    //            saveEnemy = baseEnemy;//距離が近い敵の保存
    //        }
    //    }

    //    return saveEnemy;
    //}

    /// 一番近いキャラオブジェクトを返す
    public static CharaBase CharaNearScr(Vector3 pos,string tagName)
    {
        var charas = GameObject.FindGameObjectsWithTag(tagName);
        if (charas.Length == 0)
            return null;

        Vector3 nearVec = charas[0].transform.position;
        float nearLen = Vector3.Distance(pos, nearVec);
        CharaBase saveChara = null;
        foreach (GameObject chara in charas)
        {
            var baseChara = chara.GetComponent<CharaBase>();

            float charaLen = Vector3.Distance(pos, baseChara.transform.position);
            if (charaLen <= nearLen)
            {

                nearLen = charaLen;//距離の更新

                saveChara = baseChara;//距離が近い敵の保存
            }
        }

        return saveChara;
    }

    #endregion

    #region　コルーチン


    /*            
    StartCoroutine(MyLib.DelayCoroutine(1.5f, () =>
    {
        GameObject.FindGameObjectWithTag("TurnMgr").GetComponent<TurnMgr>().ChangeEnemyTurn(true);
        isTurnChange = false;
    }));
     */


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
    /// 条件がtrueなら呼び出すコルーチン
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
    /// <returns></returns>
    //public static IEnumerator DelayCoroutineIfUntil(bool flg, Action action)
    //{

    //    yield return new WaitUntil(() => flg);//trueなら


    //    action?.Invoke();
    //}

    //public static IEnumerator DelayCoroutineIfWhile(bool IfBreak, Action action)
    //{

    //    yield return new WaitWhile(() => IfBreak);//While  falseで実行

    //    action?.Invoke();

    //    yield break;
    //}

    /// <summary>
    /// 一定時間後に処理を定期的に呼び出すコルーチン　存在する限りずっと
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
    /// 一定時間後に処理を定期的に呼び出すコルーチン　条件ででループ終了
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
    /// <returns></returns>
    public static IEnumerator LoopDelayCoroutineIf(bool IfBreak, Action action, float seconds=0, string debug ="クラス名など")
    {
        while (IfBreak)
        {
            //if (!IfBreak)
             //   break;

            yield return new WaitForSeconds(seconds);
            action?.Invoke();



        }

        Debug.Log(debug);

    }


    /// <summary>
    /// 条件がtrueなら呼び出すコルーチン
    /// </summary>
    /// <param name="seconds">秒</param>
    /// <param name="action">関数内の処理</param>
    /// <returns></returns>
    //public static IEnumerator BoolDelayCoroutine(bool flg, Action action, float seconds = 0f)
    //{
    //    yield return new WaitForSeconds(seconds);

    //    yield return new WaitUntil(() => flg);//trueなら通る
    //    //yield return new WaitWhile(()=>flg);falseなら

    //    //yield return new WaitForSeconds(seconds);

    //    action?.Invoke();
    //}



    #endregion

    #region　ロード　インスタンス生成


    /// <summary>
    /// インスタンスを生成して指定のComponentを取得する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="original"></param>
    /// <returns></returns>
    //public static T InstantiateGetComponent<T>(GameObject original)
    //    where T : Component
    //{
    //    var go = UnityEngine.Object.Instantiate(original);
    //    return go.GetComponent<T>();
    //}

    //public static T GetComponentLoad<T>(string name)
    //    where T : Component
    //{
    //    var go = (GameObject)Resources.Load(name);
    //    return go.GetComponent<T>();
    //}

    //public static T InstantiateGetComponentLoad<T>(string name, Transform trans)
    //    where T : Component
    //{
    //    var go = (GameObject)Resources.Load(name);

    //    return UnityEngine.Object.Instantiate(go, trans).GetComponent<T>(); ;
    //}

    #endregion

    #region　サウンド


    /// <summary>
    /// ボリューム調整あり
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    /// <param name="obj"></param>
    public static AudioSource MyPlayOneSound(string name, float volume, GameObject obj)
    {
        var audioSource = obj.GetComponent<AudioSource>();
        var sound = (AudioClip)Resources.Load(name);
        audioSource.PlayOneShot(sound, volume);

        return audioSource;
    }

    /// <summary>
    /// ボリューム調整あり
    /// </summary>
    /// <param name="name"></param>
    /// <param name="volume"></param>
    /// <param name="obj"></param>
    public static AudioSource MyPlaySound(string name, float volume, GameObject obj)
    {
        var audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = (AudioClip)Resources.Load(name);
        audioSource.Play();

        return audioSource;
    }

    /// <summary>
    /// ボリューム調整なし
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public static AudioSource MyPlayOneSound(string name, AudioSource audio)
    {
        var sound = (AudioClip)Resources.Load(name);
        audio.PlayOneShot(sound);

        return audio;
    }

    /// <summary>
    /// ボリューム調整なし
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public static AudioSource MyPlayOneSound(AudioClip clip, AudioSource audio)
    {
        audio.PlayOneShot(clip);

        return audio;
    }

    //Unity6のみ？AudioResource
    /// <summary>
    /// ボリューム調整なし
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public static AudioSource MyPlayOneSound(AudioResource ar, AudioSource audio)
    {
        audio.resource = ar;
        audio.Play();

        return audio;
    }

    /// <summary>
    /// ボリューム調整なし
    /// </summary>
    /// <param name="name"></param>
    ///// <param name="obj"></param>
    //public static AudioSource MyPlayOneSoundRandom(string name, AudioSource audio)
    //{
    //    var sound = (AudioSource)Resources.Load(name);
    //    audio.Play();

    //    return audio;
    //}

    /// <summary>
    /// サウンドが重複しないように
    /// </summary>
    /// <param name="name"></param>
    /// <param name="obj"></param>
    public static void MyPlayOneSoundSingle(string name,float volume, GameObject obj)
    {
        var audioSource = obj.GetComponent<AudioSource>();
        var sound = (AudioClip)Resources.Load(name);

        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(sound, volume);
    }

    public static IEnumerator SoundFadeOffCoroutine(AudioSource audio, float fadeSpeed)
    {
        Debug.Log("サウンドフェード登録");
        while (audio.volume >= 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            audio.volume -= fadeSpeed;
            if (audio.volume <= 0)
            {
                audio.Stop();
                break;
            }
              
        }

    }

    #endregion


    #endregion
}