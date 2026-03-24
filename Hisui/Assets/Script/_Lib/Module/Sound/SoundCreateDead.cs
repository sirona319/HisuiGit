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


    public void Update()
    {
        if (IsSoundEnable) return;
        if (!GetComponent<CharaBase>().isDead) return ;
        IsSoundEnable = true;

        MyLib.MyPlayOneSound(path, 0.1f, gameObject);
        //StartCoroutine(DestroyFlagFalse());
        //var seGo = Instantiate(audioSe, transform.position, Quaternion.identity);
        //seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録
        //return IsSoundEnable;
    }

    //再生が終了したら破棄する
    IEnumerator DestroyFlagFalse()
    {
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == false);

        Destroy(gameObject);
    }
}
