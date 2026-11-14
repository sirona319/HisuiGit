using UnityEngine;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour
{

    SoundManager sm;

    [SerializeField] Slider masterSl;
    [SerializeField] Slider bgmSl;
    [SerializeField] Slider seSl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>();
        //sm.BgmChange(sceneBgm);

        var m=PlayerPrefs.GetFloat("master", 0);
        masterSl.value = m;

        sm.SetMaster(m);

        var b = PlayerPrefs.GetFloat("bgm", 0);
        bgmSl.value = b;

        sm.SetBgm(b);

        var s = PlayerPrefs.GetFloat("se", 0);
        seSl.value = s;

        sm.SetSe(s);

    }

    public void Master(float val)
    {

        sm.SetMaster(val);
       // PlayerPrefs.SetFloat("master", val);
        //PlayerPrefs.Save();
    }

    public void Bgm(float val)
    {
        sm.SetBgm(val);
       // PlayerPrefs.SetFloat("bgm", val);
       // PlayerPrefs.Save();
    }

    public void Se(float val)
    {
        sm.SetSe(val);
        //PlayerPrefs.SetFloat("se", val);
       // PlayerPrefs.Save();
    }


    public void Reset()
    {
        //var m = PlayerPrefs.GetFloat("master", 0);
        masterSl.value = 0;

        sm.SetMaster(0);

        //var b = PlayerPrefs.GetFloat("bgm", 0);
        bgmSl.value = 0;

        sm.SetBgm(0);

       // var s = PlayerPrefs.GetFloat("se", 0);
        seSl.value = 0;

        sm.SetSe(0);
    }

}
