using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMgr : Singleton<SoundMgr>
{
    //public enum BGMType
    //{
    //    easy,
    //    normal,
    //    hard,
    //}

    [SerializeField] AudioMixer audioMixer;

    [SerializeField] float bgmVol=.03f;
    [SerializeField] AudioMixerGroup targetMixerGroup;
    [SerializeField]AudioClip[] clipList;
    [SerializeField] List<AudioSource> sourceLists=new ();

    [SerializeField] public AudioSource se;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        foreach (AudioClip clip in clipList)
        {

            var source = gameObject.AddComponent<AudioSource>();

            source.clip = clip;
            source.volume = 0;
            source.outputAudioMixerGroup = targetMixerGroup;
            source.playOnAwake = false;
            sourceLists.Add(source);
        }


        audioMixer = Resources.Load<AudioMixer>("AudioMixer");

        if (!audioMixer)
            audioMixer = Resources.Load<AudioMixer>("NewAudioMixer");
        //オーディオミキサーはResourcesフォルダに作成する
        //Debug.Log(audioMixer);

        if (!audioMixer)
            Debug.Log("オーディオミキサーが存在しない");
    }
    void Start()
    {




        //var m = PlayerPrefs.GetFloat("master", 0);
        ////masterSl.value = m;

        //SetMaster(m);

        //var b = PlayerPrefs.GetFloat("bgm", 0);
        //SetMaster(b);

        //var s = PlayerPrefs.GetFloat("se", 0);
        //SetMaster(s);

    }

    public void BgmChange(AudioClip clip)
    {
        const float OUTTIME = 0.3f;
        const float INTIME = 2f;
        //const float VOLUME = 0.03f;
        //Debug.Log(sourceLists[0].name);
        foreach (AudioSource sl in sourceLists)
        {
            sl.DOKill();
            if (sl.clip == clip)
            {
                sl.Play();
                sl.DOFade(bgmVol, INTIME);
                Debug.Log("testplayBGM");
            }
            else
            {
                if (sl.isPlaying)
                    sl.DOFade(0f, OUTTIME).OnComplete(() => sl.Stop());
                //sl.mute = true;
                //Debug.Log("test");
            }
            //Debug.Log("sss");
        }
       // Debug.Log(clip.name);
    }

    public void SetMaster(float value)
    {

        audioMixer.SetFloat("MasterVol", value);
        PlayerPrefs.SetFloat("master", value);
      //  PlayerPrefs.Save();
    }

    public void SetBgm(float value)
    {

        audioMixer.SetFloat("BgmVol", value);
        PlayerPrefs.SetFloat("bgm", value);
        //PlayerPrefs.Save();
    }

    public void SetSe(float value)
    {

        audioMixer.SetFloat("SeVol", value);
        PlayerPrefs.SetFloat("se", value);
        //PlayerPrefs.Save();
    }

    //public void BgmChange(BGMType type)
    //{
    //    //ボリュームを下げていって　切り替える





    //    //const float OUTTIME = 0.3f;
    //    //const float INTIME = 2f;
    //    //const float VOLUME = 0.1f;
    //    //if (type == BGMType.title)
    //    //{


    //    //   // titleBGM.DOFade(VOLUME, INTIME);
    //    //    //gameBGM.DOFade(0f, OUTTIME);
    //    //    //const float TARGETVOLUME = 0.04f;
    //    //    //StartCoroutine(SoundFadeOnCoroutine(TARGETVOLUME, aquaBGM));
    //    //    //StartCoroutine(SoundFadeOffCoroutine(groundBGM, 0.0001f));
    //    //}
    //    //else if (type == BGMType.game)
    //    //{
    //    //   // titleBGM.DOFade(0f, OUTTIME);
    //    //    //gameBGM.DOFade(VOLUME, INTIME);
    //    //    //StartCoroutine(SoundFadeOffCoroutine(aquaBGM));
    //    //    //const float TARGETVOLUME = 0.01f;
    //    //    //StartCoroutine(SoundFadeOnCoroutine(TARGETVOLUME, groundBGM, 0.0001f));
    //    //}
    //}

    //public IEnumerator SoundFadeOffCoroutine(AudioSource audio, float fadeSpeed = 0.001f)
    //{

    //    while (audio.volume > 0)
    //    {
    //        audio.volume -= fadeSpeed;
    //        yield return new WaitForSeconds(0.1f);
    //    }

    //}
}
