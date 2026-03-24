/*
 The MIT License (MIT)

Copyright (c) 2013 yamamura tatsuhiko

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class FadeScene : MonoBehaviour
{

    #region Fade

    IFade fade;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Init();
        fade.Range = cutoutRange;
        //Debug.Log("FadeScene Start");





        //プレイヤー座標を受け取る？
        //FadeOut(1f);

    }

    float cutoutRange;

    void Init()
    {
        fade = GetComponent<IFade>();
    }

    void OnValidate()
    {
        Init();
        fade.Range = cutoutRange;
    }

    IEnumerator FadeoutCoroutine(float time, System.Action action)
    {
        float endTime = Time.timeSinceLevelLoad + time * (cutoutRange);

        var endFrame = new WaitForEndOfFrame();

        while (Time.timeSinceLevelLoad <= endTime)
        {
            cutoutRange = (endTime - Time.timeSinceLevelLoad) / time;
            fade.Range = cutoutRange;
            yield return endFrame;
        }
        cutoutRange = 0;
        fade.Range = cutoutRange;

        action?.Invoke();
    }

    IEnumerator FadeinCoroutine(float time, System.Action action)
    {
        float endTime = Time.timeSinceLevelLoad + time * (1 - cutoutRange);

        var endFrame = new WaitForEndOfFrame();

        while (Time.timeSinceLevelLoad <= endTime)
        {
            cutoutRange = 1 - ((endTime - Time.timeSinceLevelLoad) / time);
            fade.Range = cutoutRange;
            yield return endFrame;
        }
        cutoutRange = 1;
        fade.Range = cutoutRange;

        action?.Invoke();
    }

    public Coroutine FadeOut(float time, System.Action action)
    {
        StopAllCoroutines();
        return StartCoroutine(FadeoutCoroutine(time, action));
    }

    public Coroutine FadeOut(float time)
    {
        return FadeOut(time, null);
    }

    public Coroutine FadeIn(float time, System.Action action)
    {
        StopAllCoroutines();
        return StartCoroutine(FadeinCoroutine(time, action));
    }

    public Coroutine FadeIn(float time)
    {
        return FadeIn(time, null);
    }

    #endregion

    #region SceneFade


    //bool isSceneChange = true;

    float sceneChangeTime = 0;
    public void SceneFade(string name, float startTime = 0f,float endTime = 0f)
    {
        if (sceneChangeTime>0) return;
        //isSceneChange = false;

        sceneChangeTime = endTime;
                //次の遷移を可能にする
                //StartCoroutine(MyLib.DelayCoroutine(endTime, () =>
                //{
                //    isSceneChange = true;
                //    Debug.Log("isSceneChange ");
                //}));

        //コルーチンの起動　フェード
        StartCoroutine(MyLib.DelayCoroutine(startTime, () =>
        {
            FadeIn(1f, () => { 
                SceneManager.LoadScene(name);
                //SceneManager.LoadScene("TestAdd", LoadSceneMode.Additive);
                //SceneManager.LoadScene("TestDoor",LoadSceneMode.Additive);
                //isSceneChange = true;

            });
           // Debug.Log("FadeInScene CALL  ");
        }));



    }

    private void Update()
    {
        if (sceneChangeTime <= 0) return;
        sceneChangeTime -= Time.deltaTime;
        if (sceneChangeTime <= 0)
        {
            Debug.Log("SceneChangeTime <= 0");
            //sceneChangeTime = 0;
            //isSceneChange = true;
        }
    }

    //void SceneFlg(float t)
    //{
    //    //次の遷移を可能にする
    //    StartCoroutine(DCoroutine(t, () =>
    //    {
    //        isSceneChange = true;
    //        Debug.Log("isSceneChange ");
    //    }));
    //}

    //IEnumerator DCoroutine(float seconds, Action action)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    action?.Invoke();
    //}

    //フェードのみしてプレイヤーの座標を変更する関数作成
    public void PlayerMoveTarget(Vector3 target,float changeTime, float endTime = 0f)
    {
        if (sceneChangeTime > 0) return;
        //isSceneChange = false;

        sceneChangeTime = endTime;

        //StartCoroutine(MyLib.DelayCoroutine(0.3f, () =>
        //{
        //GameObject.FindGameObjectWithTag("Player").transform.position = target;
        FadeIn(0, () =>
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = target;
            //Camera.main.GetComponent<CameraControl>().ChangePlayerPos();

            FadeOut(changeTime);
        });

    }

    #endregion


}
