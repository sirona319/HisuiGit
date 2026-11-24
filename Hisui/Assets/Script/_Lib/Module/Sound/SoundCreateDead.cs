using System.Collections;
using UnityEngine;

public class SoundCreateDead : MonoBehaviour
{
    bool IsSoundEnable = false;

    [SerializeField] AudioClip clip;


    public void Update()
    {
        if (IsSoundEnable) return;
        if (!GetComponent<CharaBase>().IsDead) return;
        IsSoundEnable = true;

        MyLib.MyPlayOneSound(clip, GetComponent<AudioSource>(), 0.1f);

    }

    //再生が終了したら破棄する
    IEnumerator DestroyFlagFalse()
    {
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == false);

        Destroy(gameObject);
    }
}
