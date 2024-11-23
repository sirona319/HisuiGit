using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[DisallowMultipleComponent]
public class CarveModule : MonoBehaviour
{
    public float speed = 4f;


    public float angleVal = 0f;

    public float rotSpeed = 1f;
    //public Transform Target { get; set; }

    //public Vector3 velocity = Vector3.up;

    [SerializeField] float DebugEulerZ=0f;
    [SerializeField] float DebugEulerSetZ = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //velocity = GetComponent<BaseBullet>().velocity;

        //Vector2 direction = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // X方向の移動量を設定する
        //velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        //velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // 弾の向きを設定する
        //float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        //transform.rotation = Quaternion.Euler(0, 0, zAngle);

        //GetComponent<BaseBullet>().velocity = velocity;

        //Carve();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += velocity * Time.deltaTime;
    }

    private void OnEnable()
    {

        Carve();

    }
    //角度の進行方向の取得　失敗　GetComponentせずに汎用的に敵の移動などで使えるようにしたい
    //Vector2 direction = GameObject.FindGameObjectWithTag("Player").transform.position- transform.position;
    //Vector2 direction = (transform.position + Vector3.up) - transform.position;
    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //var angle = Mathf.Atan2(velocity.normalized.y, velocity.normalized.x) * Mathf.Rad2Deg;
    void Carve()
    {

        //StartCoroutine(MyLib.DelayCoroutine(Time.deltaTime*30, () =>
        //{
        //    var angle = GetComponent<BaseBullet>().angle;
        //    angle += angleVal;

        //    Vector3 velocity = Vector3.up;
        //    // X方向の移動量を設定する
        //    velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        //    // Y方向の移動量を設定する
        //    velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);



        //    // 弾の向きを設定する
        //    float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        //    //DebugEulerSetZ = zAngle;
        //    //DebugEulerZ = transform.rotation.eulerAngles.z;


        //    transform.rotation = Quaternion.Euler(0, 0, zAngle);

        //    GetComponent<BaseBullet>().velocity = velocity;


        //}));





        StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime, () =>
        {
            var angle = GetComponent<BaseBullet>().angle;
            angle += angleVal;



            //通常の前方移動に変更？

            Vector3 velocity = Vector3.up;
            // X方向の移動量を設定する
            velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

            // Y方向の移動量を設定する
            velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);






            // 弾の向きを設定する
            float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            DebugEulerSetZ = zAngle;
            


            //var saveZRot = transform.rotation;
            //saveZRot = Quaternion.Euler(0, 0, zAngle);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, zAngle), rotSpeed * Time.deltaTime);
            DebugEulerZ = transform.rotation.eulerAngles.z;
            //GetComponent<BaseBullet>().velocity = velocity;


        }));
    }
}
