using DG.Tweening;
using UnityEngine;

public class SoundMove : MonoBehaviour
{

    //自動停止
    //GameObject parentGo;

    GameObject seObj;

    [SerializeField] string path;

    bool isPlaying = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SoundFadeStop();
    }

    public void SoundPlay()
    {
        if (isPlaying) return;
        if (GetComponent<CharaBase>().isDead) return;
        var se = GameObject.FindWithTag("SoundMgr").GetComponent<SoundMgr>().se;
        var moveSe = (GameObject)Resources.Load(path);//Prefab/Sound/JerryTrailSe
        seObj = Instantiate(moveSe, transform.position, Quaternion.identity);
        seObj.GetComponent<AudioSource>().Play();

        isPlaying = true;
    }

    public void SoundFadeStop()
    {
        Debug.Log("SoundFadeStop");

        if (!isPlaying) return;
        //if (!GetComponent<CharaBase>().isDead) return;

        const float fadeSpeed = 1f;
        seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

        seObj.GetComponent<TimeDestroy>().SetTime();
        isPlaying = false;

        Debug.Log("SoundFadeStopEnd");
    }
}
