using DG.Tweening;
using UnityEngine;

public class SoundMove : MonoBehaviour
{

    [SerializeField] GameObject SeGo;

     GameObject seGo;


    bool isPlaying = false;

    public void SoundPlay()
    {
        if (isPlaying) return;
        if (GetComponent<CharaBase>().IsDead) return;
        seGo = Instantiate(SeGo, transform.position, Quaternion.identity);
        seGo.GetComponent<AudioSource>().Play();

        isPlaying = true;
    }

    void OnDisable()
    {
        Debug.Log("SoundFadeStop");

        if (!isPlaying) return;

        const float fadeSpeed = 1f;
        seGo.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

        seGo.GetComponent<TimeDestroy>().SetTime();
        isPlaying = false;

        Debug.Log("SoundFadeStopEnd");
    }

    //public void SoundFadeStop()
    //{
    //    Debug.Log("SoundFadeStop");

    //    if (!isPlaying) return;
    //    //if (!GetComponent<CharaBase>().isDead) return;

    //    const float fadeSpeed = 1f;
    //    seObj.GetComponent<AudioSource>().DOFade(0, fadeSpeed);

    //    seObj.GetComponent<TimeDestroy>().SetTime();
    //    isPlaying = false;

    //    Debug.Log("SoundFadeStopEnd");
    //}
}
