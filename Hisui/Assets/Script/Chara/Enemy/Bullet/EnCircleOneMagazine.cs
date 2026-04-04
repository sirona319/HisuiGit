using UnityEngine;

public class EnCircleOneMagazine : BaseMagazine
{

    float intervalTime = 1f;
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform target;

    [SerializeField] string soundPath = "Sound/SE/JerryShot";

    float shotAngle = 0;

    void Start()
    {

    }


    public void Update()
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
        const int bulletNum = 35;
        for (int i = 0; i <= bulletNum; i++)
        {
            shotAngle += 10;

            BulletAtk(shotAngle, transform.position, transform.rotation, bullet);

        }

    }

    public override void MagazineUpdate()
    {
        throw new System.NotImplementedException();
    }
}
