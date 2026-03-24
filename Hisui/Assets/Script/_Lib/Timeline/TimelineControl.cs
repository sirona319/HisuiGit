using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
    //public CollisionTrigger colTriTimeline;

    //public bool isPlayerMoveStop = true;
    public bool isPlayTrigger = false;
    bool isPlay = false;
   // bool isEnd = false;
    //public void TimelineEnd()
    //{
    //   // isEnd = true;
    //    //var p = GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerScr2D>();
    //    //p.m_isLimitMove = false;
    //    //p.moveSpeed = p.MAXMOVESPEED;
    //}

    //SerializeField] public NarrationAsset na;

    //public TimelineAsset ta;

    PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = gameObject.GetComponent<PlayableDirector>();
        //IEnumerable <TrackAsset> tracks = ta.GetOutputTracks();
        //foreach (var track in tracks)
        //{
        //    Debug.Log(track.name);
        //    IEnumerable<TimelineClip> clips = track.GetClips();
        //    foreach (var clip in clips)
        //    {
        //        Debug.Log(clip.displayName);
        //        clip.timeScale = 5.0f;
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (isEnd) return;

        //範囲内に入ったらプレイヤーを止めて　メッセージ再生
        if (isPlayTrigger && !isPlay)
        {
            playableDirector.Play();
            isPlay = true;

            //GameObject.FindGameObjectWithTag(TagName.Player).GetComponent<PlayerMove>().MoveStop();
            //p.isLimitMove = true;
            //p.moveSpeed = 0f;
            //Debug.Log("メッセージ終了TimelineControl" + GetType().FullName);
            //Debug.Log("再生開始"+ GetType().FullName);
        }
        //if (gameObject.GetComponent<PlayableDirector>().state == PlayState.Paused)
        //    Debug.Log("tgaff");

        // Debug.Log(gameObject.GetComponent<PlayableDirector>().state==PlayState.Paused);


        if (!isPlay) return;

        const int LEFTMOUSE = 0;
        if (Input.GetMouseButtonDown(LEFTMOUSE))
            playableDirector.Resume();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Resume　再開
            playableDirector.Resume();

            //gameObject.GetComponent<PlayableDirector>().playableAsset.CreatePlayable();
            //    gameObject.GetComponent<PlayableDirector>().paused;
            // playable.GetGraph().GetRootPlayable(0).SetSpeed(1);
            //messageWait = false;

            //Debug.Log("SPACE成功");


            //playableDirector.playableGraph.GetRootPlayable(0).SetSpeed(1.0f);
            // Debug.Log("SPACE　再開 メッセージ送り");
        }
        //playableDirector.state

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    playableDirector.Play();
        //    // playable.GetGraph().GetRootPlayable(0).SetSpeed(1);
        //    //messageWait = false;

        //    //Debug.Log("SPACE成功");
        //}
        //if (Input.GetKeyDown(KeyCode.G))
        //{
        //    playableDirector.Stop();
        //    // playable.GetGraph().GetRootPlayable(0).SetSpeed(1);
        //    //messageWait = false;

        //    //Debug.Log("SPACE成功");
        //}

        
    }

    public void FlgReset()
    {
        isPlayTrigger = false;
        isPlay = false;
    }

    public void FlgActive()
    {
        isPlayTrigger = true;
    }
}
