using UnityEngine;

public class BgmChange : MonoBehaviour
{
    [SerializeField] AudioClip sceneBgm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (sceneBgm == null) return;
        var sm = GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundMgr>();
        sm.BgmChange(sceneBgm);
    }

}
