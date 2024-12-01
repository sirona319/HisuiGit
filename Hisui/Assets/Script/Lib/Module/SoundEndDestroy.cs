using System.Collections;
using UnityEngine;

public class SoundEndDestroy : MonoBehaviour
{
    [SerializeField, TooltipAttribute("Trueのとき実行するのかFalseの時か")]
    bool enableFlg;
    //[SerializeField] bool isSound;
    //[SerializeField]public bool setFlg;
    //bool timinFlg;
    //https://qiita.com/OKsaiyowa/items/d0f59ae0c97b29118a80
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if (isSound)
         //   timinFlg=GetComponent<AudioSource>().isPlaying;
    }

    public void StartDestroyFlg()
    {
        if(enableFlg)
        StartCoroutine(DestroyFlagTrue());
        else
            StartCoroutine(DestroyFlagFalse());
    }

    IEnumerator DestroyFlagTrue()
    {
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == true);

        Destroy(gameObject);
    }

    IEnumerator DestroyFlagFalse()
    {
        yield return new WaitUntil(() => GetComponent<AudioSource>().isPlaying == false);

        Destroy(gameObject);
    }
}
