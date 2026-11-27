using Coffee.UIEffects;
using UnityEngine;

public class EnemyBase : CharaBase
{

    public bool isAreaOut = false;

    [SerializeField] AudioClip dead;
    AudioSource audioSe;
    private void Awake()
    {
        audioSe = GameObject.FindWithTag("SoundM").GetComponent<SoundManager>().se;
    }
    public override void Dead()
    {
        base.Dead();
        gameObject.SetActive(false);

        MyLib.MyPlayOneSound(dead, audioSe, 0.1f);
        Debug.Log("DEADJERRY");
    }

}
