using UnityEngine;

public class CursolMgr : Singleton<CursolMgr>
{
    bool isCursol = false;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        //カーソルをロックしたままだとJoyStickの挙動がおかしくなる
        Cursor.lockState = CursorLockMode.Confined;
        var mobileCanvas = GameObject.Find("MobileCanvas");

        //Cursor.lockState = CursorLockMode.Confined;
        //https://kan-kikuchi.hatenablog.com/entry/UnityEngine_Device
        //スマホUIの表示　SetActiveにしてしまうと再取得ができないためenableを使用
        //Canvasの設定用
        //https://shibuya24.info/entry/unity-ui-canvas
        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
        {
            mobileCanvas.GetComponent<Canvas>().enabled = true;

            GoogleAds.I.RequestBanner();
            //GoogleAds.I.LoadInterstitialAd();
            //GoogleAds.I.InterstitialShowAd();


            //GoogleAds.I.LoadRewardedAd();
            //GoogleAds.I.ShowRewardedAd();
        }
        else
        {
            mobileCanvas.GetComponent<Canvas>().enabled = false;
        }
        //m_variableJoystick.gameObject.SetActive(true);
#elif UNITY_EDITOR_WIN
        //Cursor.lockState = CursorLockMode.Locked;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCursol) return;

        Cursor.visible = true;
        
    }

    public void SetCursol(bool flg)
    {
        if(flg)
        {
            Cursor.lockState = CursorLockMode.Confined;
            isCursol = true;
        }
        else
        {

            Cursor.visible = false;
            isCursol = false;
        }

    }
}
