using UnityEngine;
//using DG.Tweening;
using DG.Tweening;

public class TitleControl : Singleton<TitleControl>
{
    //[SerializeField] Fade fade;

    public Transform R;
    public Transform L;
    public Transform M;

    //public TextMeshProUGUI credit;
    //public TextMeshProUGUI creditJelly;

    //Vector3 rMove = new Vector3(50f, 140f, -30f);

    [SerializeField] MeshRenderer selectMesh;
    [SerializeField] Transform selectTrans;

    [SerializeField] DOFadeUGUI[] fades;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        if(GManager.I.IsSceneChange)
        {
            var fade = GameObject.Find("FadeCanvas").GetComponent<Fade>();
            fade.FadeOut(1f);
        }



        selectMesh.enabled = false;
        L.transform.DOLocalMove(new Vector3(-10, 80,20), 1f).SetEase(Ease.OutCubic);
        R.transform.DOLocalMove(new Vector3(10, 80, 0), 1f).SetEase(Ease.OutCubic);
        M.transform.DOLocalMove(new Vector3(0, 90, -20), 4f).SetEase(Ease.OutCubic);

        var startCameraPos = Camera.main.transform.position;
        var startCameraRot = Camera.main.transform.rotation;

        const float chageCameraTime = 8f;
        TitleViewCameraControl(startCameraPos, startCameraRot, chageCameraTime);
        StartCoroutine(MyLib.LoopDelayCoroutine(chageCameraTime * 3, () =>
        {
            TitleViewCameraControl(startCameraPos, startCameraRot, chageCameraTime);
        }));

        //const float volume = 0.04f;
        //var audioStartSource = this.GetComponent<AudioSource>();
        //var sound = (AudioClip)Resources.Load("SE/" + "剣で打ち合う2");
        //audioStartSource.PlayOneShot(sound, volume);


        StartCoroutine(MyLib.DelayCoroutine(4.5f, () =>
        {
            selectMesh.enabled = true;
        }));


        //カーソルをオンにする
        CursolManager.I.SetCursol(true);

        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;


#if UNITY_ANDROID
        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
        {
            GoogleAds.I.RequestBanner();
            GoogleAds.I.LoadInterstitialAd();
            GoogleAds.I.InterstitialShowAd();
            GoogleAds.I.LoadRewardedAd();
            GoogleAds.I.ShowRewardedAd();
            //mobileCanvas.GetComponent<Canvas>().enabled = true;
        }
        else
        {
            //mobileCanvas.GetComponent<Canvas>().enabled = false;
        }


#endif
    }

    void TitleViewCameraControl(Vector3 initPos,Quaternion initRot, float changeTime)
    {

        //camera2.depth = -1;           
        Camera.main.transform.SetPositionAndRotation(initPos, initRot);


        Camera.main.transform.DOLocalMove(new Vector3
            (Camera.main.transform.position.x + 10, Camera.main.transform.position.y, Camera.main.transform.position.z), changeTime)
            .SetEase(Ease.InOutSine);

        ///////ここから次のカメラ
        StartCoroutine(MyLib.DelayCoroutine(changeTime, () =>
        {
            //Camera.main.transform.position = new Vector3(0, 25, 45);

            //CameraのdepthはPriorityのこと
            //カメラの切り替え 2

            //camera2.depth = 1;
            var camera2 = GameObject.Find("Camera2").GetComponent<Camera>();        //カメラ切り替え 2
            Camera.main.transform.position = camera2.transform.position;
            Camera.main.transform.localEulerAngles = camera2.transform.localEulerAngles;

            Camera.main.transform.DOLocalMove(new Vector3
            (Camera.main.transform.position.x, Camera.main.transform.position.y - 10, Camera.main.transform.position.z), changeTime)
            .SetEase(Ease.InOutSine);


            ///////ここから次のカメラ
            StartCoroutine(MyLib.DelayCoroutine(changeTime, () =>
            {
                var camera3 = GameObject.Find("Camera3").GetComponent<Camera>();        //カメラ切り替え 3
                Camera.main.transform.position = camera3.transform.position;
                Camera.main.transform.localEulerAngles = camera3.transform.localEulerAngles;

                Camera.main.transform.DORotate(new Vector3
                (Camera.main.transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y - 150, Camera.main.transform.localEulerAngles.z), changeTime)
                .SetEase(Ease.InOutSine);
            }));

        }));
        
    }

    public void MoveSelectObject()
    {
        StartCoroutine(MyLib.LoopDelayCoroutine(0.02f, () =>
        {
            selectTrans.localPosition = new Vector3(
                selectTrans.localPosition.x + 30f, selectTrans.localPosition.y, selectTrans.localPosition.z);


        }));


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& !selectMesh.enabled)
        {
            L.transform.DOComplete();
            R.transform.DOComplete();
            M.transform.DOComplete();

            selectMesh.enabled = true;

            foreach(DOFadeUGUI fade in fades)
            {
                fade.Skip();
            }
        }

        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.Confined;
        //デバッグダメージ
        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    Camera.main.transform.position = new Vector3(0, 25, 45);
        //}

    }

    public void SoundFadeOff()
    {
        //StartCoroutine(SoundManager.I.SoundFadeOffCoroutine(audioSouceWave,0.00001f));
       // StartCoroutine(SoundManager.I.SoundFadeOffCoroutine(audioSouceBird, 0.00001f));
    }


    //private IEnumerator WaveSoundLoopFunc()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(5f);

    //        const float volume = 1f;
    //        var sound = (AudioClip)Resources.Load("SE/" + "ヒヨドリの鳴き声3");
    //        audioSouceWave.PlayOneShot(sound, volume);
    //    }
    //}
}
