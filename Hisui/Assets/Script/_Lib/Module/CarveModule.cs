using UnityEngine;
using static UnityEngine.GraphicsBuffer;

//[DisallowMultipleComponent]
public sealed class CarveModule : MonoBehaviour
{
    //float speed = 1f;

    [SerializeField] float angleVal = 0f;

    [SerializeField] float rotSpeed = 2.8f;

    [SerializeField] float DebugEulerZ=0f;
    [SerializeField] float DebugEulerSetZ = 0f;

    [SerializeField] bool carveEnable = false;

    public void SetAngle(float a)
    {
        angleVal = a;
    }

    private void OnEnable()
    {
        carveEnable = true;
        //Carve();

    }

    private void OnDisable()
    {
        carveEnable = false;
    }

    private void Update()
    {
        if (!carveEnable) return;

        Vector2 direction = (transform.up + transform.position) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        //弾を曲げる量を設定
        // float angle = GetComponent<BaseBullet>().angle;
        angle += angleVal;


        Vector3 velocity = transform.up;
        // X方向の移動量を設定する
        velocity.x = Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = Mathf.Sin(angle * Mathf.Deg2Rad);



        // 弾の向きを設定する
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        DebugEulerSetZ = zAngle;//デバッグ用


        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, zAngle), rotSpeed * Time.deltaTime);
        DebugEulerZ = transform.rotation.eulerAngles.z;//デバッグ用　DebugEulerZ==DebugEulerSetZ
    }

    void Carve()
    {
        //Vector2 direction = transform.up - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        //StartCoroutine(MyLib.LoopDelayCoroutine(Time.deltaTime, () =>
        StartCoroutine(MyLib.LoopDelayCoroutine(0, () =>
        {
            Vector2 direction = (transform.up + transform.position) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

            //弾を曲げる量を設定
           // float angle = GetComponent<BaseBullet>().angle;
            angle += angleVal;


            Vector3 velocity = transform.up;
            // X方向の移動量を設定する
            velocity.x = Mathf.Cos(angle * Mathf.Deg2Rad);

            // Y方向の移動量を設定する
            velocity.y = Mathf.Sin(angle * Mathf.Deg2Rad);



            // 弾の向きを設定する
            float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
            DebugEulerSetZ = zAngle;//デバッグ用


            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, zAngle), rotSpeed * Time.deltaTime);
            DebugEulerZ = transform.rotation.eulerAngles.z;//デバッグ用　DebugEulerZ==DebugEulerSetZ

        }));
    }
}
