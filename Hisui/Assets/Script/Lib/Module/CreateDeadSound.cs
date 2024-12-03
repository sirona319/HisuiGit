using UnityEngine;

public class CreateDeadSound : MonoBehaviour
{
    //public AudioSource deadSound;

    public bool IsSoundEnable = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //deadSound = MyLib.GetComponentLoad<AudioSource>("prefab/Sound/JerryDestroySound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(AudioSource audioSource)
    {
        if (!IsSoundEnable) return;
        var seGo = Instantiate(audioSource, transform.position, Quaternion.identity);
        seGo.GetComponent<SoundEndDestroy>().StartDestroyFlg();//削除登録
    }
}
