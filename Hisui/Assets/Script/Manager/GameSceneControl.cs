using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneControl : Singleton<GameSceneControl>
{
    public int enemyAllCount;

    //[SerializeField] Fade fade;
    void Start()
    {
        //GManager.I.FadeOut();

        var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
        fade.FadeOut(1f);

        //すでにSceneに配置している敵の数を追加
        enemyAllCount += MyLib.EnemyNum();

        SoundManager.I.BgmChange(SoundManager.BGMType.game);

        //カーソルをオフにする
        CursolManager.I.SetCursol(false);
        
        //Cursor.visible = false;
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
        Cursor.lockState = CursorLockMode.Locked;
#endif
    }


    public void UpdateEnemyCount()
    {
        enemyAllCount--;
        if (enemyAllCount <= 0)
        {
            //GameObject.Find("CLEARTEXT").GetComponent<DOFade>().ShowWindow();

            //StartCoroutine(SoundManager.I.SoundFadeOffCoroutine(GetComponent<AudioSource>(), 0.00001f));
            
            //GManager.I.SceneChangeTimerSet(GManager.SceneNameType.Title.ToString());


        }
    }
}
