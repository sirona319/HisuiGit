//using Cinemachine;
//using GoogleMobileAds.Api;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

//https://docs.unity3d.com/ja/2018.4/Manual/PlatformDependentCompilation.html

//ParticlePackはTextMeshProのマテリアルも入っているため使用　アセット

//[DefaultExecutionOrder(-1)]
public class GManager : Singleton<GManager>
{
    public enum SceneNameType
    {
        TitleScene,
        GameScene,

    }

    public bool IsSceneName(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }

    public bool IsSceneChange { get; private set; } = false;

    //[SerializeField] bool debugHD = false;

    // 直前のディスプレイ向き
    DeviceOrientation PrevOrientation;

    public int resoType = 0; //解像度　2まで　３つ
    //public int resoHeigh = 1080;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        //1280　720 
        //1920 1080
        //Screen.SetResolution(1920,1080, false);
        //800 450

#if UNITY_ANDROID
        Debug.Log($"実行しているデバイス : {UnityEngine.Device.SystemInfo.deviceModel}");
        Debug.Log($"実行しているOS : {UnityEngine.Device.SystemInfo.operatingSystem}");


        //広告所の初期化
        GoogleAds.I.StartInit();

        if (SceneManager.GetActiveScene().name == SceneNameType.TitleScene.ToString())
            GoogleAds.I.RequestBanner(AdPosition.Top);


        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
        {
            //Screen.SetResolution(1920/2, 1080/2, false);//960 540
            //Screen.SetResolution(800, 450, false);

        }
        else
        {
            //if(debugHD)
            //    Screen.SetResolution(1920, 1080, false);
            ////else
            //Screen.SetResolution(1920 / 2, 1080 / 2, false);



        }

        //SetOrientation();
#endif


    }

#if UNITY_ANDROID


    DeviceOrientation GetOrientation()
    {
        DeviceOrientation result = Input.deviceOrientation;

        // Unkownならピクセル数から判断
        //if (result == DeviceOrientation.Unknown)
        //{

        //    //恐らく　Screen.SetResolutionを使用すると変更される
        //    if (Screen.width < Screen.height)
        //    {
        //        result = DeviceOrientation.Portrait;
        //    }
        //    else
        //    {
        //        result = DeviceOrientation.LandscapeLeft;
        //    }
        //}

        if (Screen.width < Screen.height)
        {
            result = DeviceOrientation.Portrait;
        }
        else
        {
            result = DeviceOrientation.LandscapeLeft;
        }
        return result;
    }

    public void SetOrientation()
    {
        var ori = GetOrientation();

        if (ori == DeviceOrientation.FaceUp || ori == DeviceOrientation.FaceDown)
            return;

        if (ori == DeviceOrientation.Portrait || ori == DeviceOrientation.PortraitUpsideDown)
        {
            if(resoType==0)
            Screen.SetResolution(540,960, false);//960 540
            else if (resoType == 1)
                Screen.SetResolution(720, 1280, false);//960 540
            else if (resoType == 2)
                Screen.SetResolution(1080, 1920, false);//960 540
                                                                  //Screen.SetResolution(540, 960, false);//960 540
            Debug.Log("縦に変更");

            //GameObject.Find("UICanvas").GetComponent<CanvasScaler>().referenceResolution = new Vector2(1080, 1920);

            //GameObject.Find("MobileCanvas").GetComponent<CanvasScaler>().referenceResolution = new Vector2(1080, 1920);

            if (SceneManager.GetActiveScene().name == SceneNameType.NormalScene.ToString())
            {
                GameObject.Find("CMVirtualNormal").GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 100;

                //if(GameObject.Find("CMVirtual (1)")==null)
                //GameObject.Find("DebugText").GetComponent<TextMeshProUGUI>().text += "CMVirtual (1)取得失敗";


                var rt = GameObject.Find("UIPanel").GetComponent<RectTransform>();
                //if (rt == null)
                //    GameObject.Find("DebugText").GetComponent<TextMeshProUGUI>().text += "UIPanel取得失敗";

                rt.localScale = Vector3.one * 2;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 920);
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1800);

                var mrt = GameObject.Find("MobilePanel").GetComponent<RectTransform>();

                mrt.localScale = Vector3.one * 1.5f;
                mrt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1500);
                mrt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 2500);
            }
            else if (SceneManager.GetActiveScene().name == SceneNameType.TitleScene.ToString())
            {
                var rt = GameObject.Find("TitleUIPanel").GetComponent<RectTransform>();

                rt.localScale = Vector3.one * 2;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1280);
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1920);

            }


        }
        else            //横方向
        {
            if (resoType == 0)
                Screen.SetResolution(960,540, false);//960 540
            else if (resoType == 1)
                Screen.SetResolution(1280, 720,  false);//960 540
            else if (resoType == 2)
                Screen.SetResolution(1920, 1080,  false);//960 540
            //Screen.SetResolution(960, 540, false);//960 540
            if (SceneManager.GetActiveScene().name == SceneNameType.NormalScene.ToString())
            {
                Debug.Log("よこに変更");

                //RectTrans.rect.Set(0, 0, 0, 0);

                GameObject.Find("CMVirtualNormal").GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 60;
                //GameObject.Find("UICanvas").GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);

                //GameObject.Find("MobileCanvas").GetComponent<CanvasScaler>().referenceResolution = new Vector2(1920, 1080);



                var rt = GameObject.Find("UIPanel").GetComponent<RectTransform>();
                rt.localScale = Vector3.one;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1920);
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1080);

                var mrt = GameObject.Find("MobilePanel").GetComponent<RectTransform>();
                mrt.localScale = Vector3.one;
                mrt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1920);
                mrt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1080);
                //rt.sizeDelta = new Vector2(0, 0);

            }
            else if (SceneManager.GetActiveScene().name == SceneNameType.TitleScene.ToString())
            {
                var rt = GameObject.Find("TitleUIPanel").GetComponent<RectTransform>();


                rt.localScale = Vector3.one;
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1920);
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 872);
            }
        }
    }

    void Update()
    {
        DeviceOrientation currentOrientation = GetOrientation();
        if (PrevOrientation != currentOrientation)
        {
            // 画面の向きが変わった場合の処理
            SetOrientation();
            

            PrevOrientation = currentOrientation;
        }
    }

#endif

    /// <summary>
    /// 遷移時間を指定して遷移させる関数
    /// </summary>
    /// <param name="name">遷移シーン</param>
    /// <param name="time">遷移開始時間</param>
    public void SceneChangeTimerSet(string name, float time = 3f)
    {
        if (IsSceneChange) return;
        IsSceneChange = true;


        const float fadePossibleTime = 2.0f;//次の遷移が可能になるまでの時間
        StartCoroutine(MyLib.DelayCoroutine(time + fadePossibleTime, () =>
        {
            IsSceneChange = false;
        }));


        //コルーチンの起動　フェード
        StartCoroutine(MyLib.DelayCoroutine(time, () =>
        {
            var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
            fade.FadeIn(1f, () => { SceneManager.LoadScene(name); });

        }));


        //SoundManager.I.BgmChange("Ground");
    }

    public void SceneChangeUseSoundTitle(string name, float time = 0.3f)
    {
        if (IsSceneChange) return;
        IsSceneChange = true;

        const float fadePossibleTime = 2.0f;//次の遷移が可能になるまでの時間
        StartCoroutine(MyLib.DelayCoroutine(fadePossibleTime, () =>
        {
            IsSceneChange = false;
        }));

        //決定音再生
        MyLib.MyPlayOneSound("SE/System/" + "剣で打ち合う2", TitleControl.I.gameObject);


        //コルーチンの起動　フェード
        StartCoroutine(MyLib.DelayCoroutine(time, () =>
        {
            var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
            fade.FadeIn(1f, () => { SceneManager.LoadScene(name); });

        }));

    }


    //フェードのみしてプレイヤーの座標を変更する関数作成

    public void PlayerMoveTarget(Vector3 target)
    {
        //StartCoroutine(MyLib.DelayCoroutine(0.3f, () =>
        //{
        //GameObject.FindGameObjectWithTag("Player").transform.position = target;
        var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
        fade.FadeIn(1f, () =>
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = target;

            fade.FadeOut(5f);
        });

        //}));

        //広告はさんだり？　フラグで管理など


        //StartCoroutine(MyLib.DelayCoroutine(1.3f, () =>
        //{
        //    var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
        //    fade.FadeOut(1f);

        //}));


    }

}
