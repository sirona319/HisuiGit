using UnityEngine;

//https://note.com/yumenotsugumi/n/n01b3bb50aa63

public class Bullet : MonoBehaviour
{
    public float angle; // 角度
    [SerializeField] float speed; // 速度
    Vector3 velocity; // 移動量

    int damage = 1;

    void Start()
    {

        // X方向の移動量を設定する
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y方向の移動量を設定する
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // 弾の向きを設定する
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        // 5秒後に削除
        //Destroy(gameObject, 5.0f);
    }
    void Update()
    {
        //rigidbody　無し

        // 毎フレーム、弾を移動させる
        transform.position += velocity * Time.deltaTime;
    }


    // 角度と速度を設定する関数
    public void Init(float input_angle, float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            //プレイヤーへのダメージ処理
            other.transform.GetComponent<PlayerScr2D>().PlayerDamage(damage);

           // Debug.Log("攻撃がPlayerにHIT");

            Destroy(this.gameObject);
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyBase>().EnemyDamage(1);


            Destroy(this.gameObject);
            return;
        }


    }



    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("ExitErea"))
        {

            //Debug.Log("エリア外消去");

            this.gameObject.SetActive(false);

            Destroy(this.gameObject);
            return;
        }

    }
}
