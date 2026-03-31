using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using Image = UnityEngine.UI.Image;

public class NarrationBehaviour : PlayableBehaviour
{
    //
    //public GameObject narrationGameObject { get; set; }

    //[SerializeField]
    //public bool boolValue = false;

    //bool messageWait = false;

    //public Image textBackImage { get; set; }

    //bool pauseScheduled = true;

    //int testVal = 0;

    PlayableDirector director;


    bool clipStart = false;

    public bool isTextPause = true;

    public TMP_Text mTextUI { get; set; }
    public string inputText { get; set; }
    public float textSpd { get; set; }
    public bool textEndIcon { get; set; }
    public BlinkImageMod readImage { get; set; }=null;
    AudioSource textSe;

    //使えないStart関数
    void Start() { }

    public override void OnPlayableCreate(Playable playable)
    {
        director = (playable.GetGraph().GetResolver() as PlayableDirector);

        var textBackImage = GameObject.Find("TextPanel").gameObject.GetComponent<Image>();
        mTextUI = textBackImage.transform.Find("TalkText").GetComponent<TMP_Text>();

        textSe = textBackImage.GetComponent<AudioSource>();
        readImage = textBackImage.transform.Find("ReadImage").GetComponent<BlinkImageMod>();

        //if (readImage==null)
        //{
        //    readImage.enabled=false;
        //    readImage.GetComponent<Image>().enabled = false;
        //    return;
        //} 
        //    readImage.enabled = true;
        //Debug.Log("        } \r\n            readImage.enabled = true;");
    }


    //Update Timeline再生中のみ
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if (mTextUI == null) return;
        //Debug.Log("PrepareFrame");

        //mTextUI.gameObject.transform.parent.gameObject.SetActive(true);
        //mTextUI.text = "PrepareFrame"+mTextUI.gameObject.name;

        mTextUI.text = inputText;// + mTextUI.gameObject.name;

        //タイムラインからメッセージ長さを取得
        var progress = (float)(playable.GetTime() / playable.GetDuration());
        var current = Mathf.Lerp(0f, mTextUI.text.Length, progress);
        var count = Mathf.CeilToInt(current* textSpd);

        mTextUI.maxVisibleCharacters = count;
        //base.PrepareFrame(playable, info);

        //if(messageWait &&Input.GetKeyDown(KeyCode.Space))
        //{
        //    playable.GetGraph().GetRootPlayable(0).SetSpeed(1);
        //    messageWait = false;

        //    Debug.Log("SPACE成功");
        //}

    }


    //int NumPlay = 0;
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

        base.OnBehaviourPlay(playable, info);
        // Debug.Log($"OnBehaviourPlay" + NumPlay++);

        textSe.Play();
        clipStart = true;

        if (readImage != null)
            readImage.enabled = true;
    }

    //int NumPause = 0;
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        //テキストの最後に止めない
        if(!isTextPause)
        {
            if (readImage != null)
                readImage.enabled = false;
            textSe.Stop();

            //director.Pause();

            clipStart = false;
            return;
        }

        if (clipStart)
        {
            //Debug.Log("OnBehaviourPause" + clipStart);
            if (readImage != null)
                readImage.enabled = false;

            textSe.Stop();

            director.Pause();
            //playable.GetGraph().GetRootPlayable(0).SetSpeed(0);
            //messageWait = true;
            clipStart = false;
        }

        //if (playable.GetPlayState() == PlayState.Paused)
        //{
        //   // Debug.Log("クリップ開始"+testVal);
        //    clipStart = true;
        //    testVal++;

        //}

        //base.OnBehaviourPause(playable, info);
        
        //Debug.Log($"OnBehaviourPause"+ NumPause++);
    }

    public override void OnGraphStart(Playable playable)
    {
        //base.OnGraphStart(playable);
        //Debug.Log("[CustomTimeline] Behaviour OnGraphStart");

        //Debug.Log("OnGraphStart");
    }

    public override void OnGraphStop(Playable playable)
    {
        // base.OnGraphStop(playable);
        //Debug.Log("[CustomTimeline] Behaviour OnGraphStop");

       // Debug.Log("OnGraphStop");
    }

    public override void OnPlayableDestroy(Playable playable)
    {
        //mTextUI.text = "";
        //textBackImage.enabled = false;



        //  base.OnPlayableDestroy(playable);
       // Debug.Log("[CustomTimeline] Behaviour OnPlayableDestroy"+ NumDes++);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        //base.ProcessFrame(playable, info, playerData);

        //if (messageWait && Input.GetKeyDown(KeyCode.Space))
        //{
        //    playable.GetGraph().GetRootPlayable(0).SetSpeed(1);
        //    messageWait = false;

        //    Debug.Log("SPACE成功");
        //}
    }
}
