//using UnityEngine;

//public class EnNormalMagazine : BaseJerryMag
//{

//    float intervalTime = 1f;
//    [SerializeField] float intervalTimeMax = 1f;

//    [SerializeField] GameObject bullet;

//    Transform target;

//    [SerializeField] AudioClip seGo;

//    void Start()
//    {
//        if(target==null)
//            target = GameObject.FindWithTag("Player").transform;
//    }    

//    void Update()
//    {
//        if (target == null) return;

//        intervalTime -= Time.deltaTime;
//        if (intervalTime <= 0)
//        {
//            intervalTime = intervalTimeMax;

//            MyLib.MyPlayOneSound(seGo, GetComponent<AudioSource>());//水滴

//            Shot();
//        }


//    }

//    void Shot()
//    {

//        Vector2 direction = target.position - transform.position;
//        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

//        BulletAtk(pAngle, transform.position, transform.rotation, bullet); //Target渡す

//    }

//}
