using UnityEngine;

//https://note.com/yumenotsugumi/n/n01b3bb50aa63

public class Bullet : MonoBehaviour
{
    public float angle; // �p�x
    [SerializeField] float speed; // ���x
    Vector3 velocity; // �ړ���

    int damage = 1;

    void Start()
    {

        // X�����̈ړ��ʂ�ݒ肷��
        velocity.x = speed * Mathf.Cos(angle * Mathf.Deg2Rad);

        // Y�����̈ړ��ʂ�ݒ肷��
        velocity.y = speed * Mathf.Sin(angle * Mathf.Deg2Rad);


        // �e�̌�����ݒ肷��
        float zAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        // 5�b��ɍ폜
        //Destroy(gameObject, 5.0f);
    }
    void Update()
    {
        //rigidbody�@����

        // ���t���[���A�e���ړ�������
        transform.position += velocity * Time.deltaTime;
    }


    // �p�x�Ƒ��x��ݒ肷��֐�
    public void Init(float input_angle, float input_speed)
    {
        angle = input_angle;
        speed = input_speed;
    }



    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            //�v���C���[�ւ̃_���[�W����
            other.transform.GetComponent<PlayerScr2D>().PlayerDamage(damage);

           // Debug.Log("�U����Player��HIT");

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

            //Debug.Log("�G���A�O����");

            this.gameObject.SetActive(false);

            Destroy(this.gameObject);
            return;
        }

    }
}
