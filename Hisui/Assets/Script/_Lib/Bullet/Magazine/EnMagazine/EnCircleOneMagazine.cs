using UnityEngine;
using UnityEngine.Audio;

public class EnCircleOneMagazine : BaseMagazine
{
    [SerializeField] AudioClip clip;
    AudioSource audioSource;

    float intervalTime = 1f;
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform target;

    [SerializeField] int bulletNum = 35;

    float shotAngle = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (target == null) return;

        intervalTime -= Time.deltaTime;

        if (intervalTime > 0) return;

        MyLib.MyPlayOneSound(clip, audioSource); // 水滴
        CircleOneShot();

        intervalTime = intervalTimeMax;


    }

    void CircleOneShot()
    {
        shotAngle = 0;
        for (int i = 0; i <= bulletNum; i++)
        {
            shotAngle += 10;

            BulletAtk(shotAngle, transform.position, transform.rotation, bullet);

        }

    }

}
