using System.Collections;
using UnityEngine;

public class SoundCreateDead : MonoBehaviour
{
    //public AudioSource deadSound;

    bool IsSoundEnable = false;

    [SerializeField] string path;

    //AudioSource audioSe;

    //[SerializeField] AudioResource audioSe;

    //private void Start()
    //{
    //    //audioSe= MyLib.GetComponentLoad<AudioSource>("Prefab/Sound/DestroySound");
    //}


    void Update()
    {

        //SoundPlay();
        //StartCoroutine(DestroyFlagFalse());
        //var seGo = Instantiate(audioSe, transform.position, Quaternion.identity);
        //seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録
        //return IsSoundEnable;
    }

    public void SoundPlay()
    {
        if (IsSoundEnable) return;
        if (!GetComponent<CharaBase>().isDead) return;

        Debug.Log("SoundCreateDead");
        var se = GameObject.FindWithTag("SoundMgr").GetComponent<SoundMgr>().se.GetComponent<AudioSource>();
        MyLib.MyPlayOneSound(path, 1f, se);
        IsSoundEnable = true;


    }

    //再生が終了したら破棄する
    IEnumerator DestroyFlagFalse()
    {
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == false);

        Destroy(gameObject);
    }
}
