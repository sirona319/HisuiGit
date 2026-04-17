using UnityEngine;

public class EnNormalMagazine : BaseMagazine
{

    float intervalTime = 1f;
    [SerializeField] float intervalTimeMax = 1f;

    [SerializeField] GameObject bullet;

    [SerializeField] Transform target;

    [SerializeField] string soundPath = "Sound/SE/JerryShot";

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

            if(GetComponent<AudioSource>() != null)
            MyLib.MyPlayOneSound(soundPath, gameObject.GetComponent<AudioSource>());//水滴
            Shot();
        }


    }

    void Shot()
    {

        Vector2 direction = target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        BulletAtk(pAngle, transform.position, transform.rotation, bullet); //Target渡す

    }

    public override void MagazineUpdate()
    {
        throw new System.NotImplementedException();
    }
}
