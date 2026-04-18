using UnityEngine;

public class EnCircleOneMagazine : BaseMagazine
{

    float intervalTime = 1f;
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform target;

    [SerializeField] string soundPath = "Sound/SE/JerryShot";

    [SerializeField] int bulletNum = 35;

    float shotAngle = 0;


    void Update()
    {
        if (target == null) return;

        intervalTime -= Time.deltaTime;
        if (intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;

            MyLib.MyPlayOneSound(soundPath, gameObject.GetComponent<AudioSource>());//水滴
            CircleOneShot();
        }


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
