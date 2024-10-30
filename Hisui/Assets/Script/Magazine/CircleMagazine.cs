using UnityEngine;

public class CircleMagazine : BaseMagazine
{

    float timeCount = 0;
    float shotAngle = 0;

    Transform targetTrans;

    const float SHOTTIME = 3f;

    const float MAXBULLETINTERVAL = SHOTTIME+1f;


    public override void Initialize()
    {
        base.Initialize();

        var player = GameObject.FindGameObjectWithTag("Player");
        targetTrans = player.transform;

        bulletInterval = MAXBULLETINTERVAL;
    }

    public override void MagazineUpdate()
    {
        //bulletInterval -= Time.deltaTime;


        //if (bulletInterval > SHOTTIME)
        //    return;

        CircleShot();

        //if(bulletInterval <= 0)
        //bulletInterval = MAXBULLETINTERVAL;
    }



    void CircleShot()
    {
        // �O�t���[������̎��Ԃ̍������Z
        timeCount += Time.deltaTime;

        // 0.1�b�𒴂��Ă��邩
        if (timeCount > 0.1f)
        {
            timeCount = 0; // �Ĕ��˂̂��߂Ɏ��Ԃ����Z�b�g

            shotAngle += 10;

            // GameObject��V���ɐ�������
            // �������F��������GameObject
            // �������F����������W
            // ��O�����F��������p�x
            // �߂�l�F��������GameObject
            var createObject = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);

            // ��������GameObject�ɐݒ肳��Ă���ABullet�X�N���v�g���擾����
            Bullet bulletScript = createObject.GetComponent<Bullet>();

            // Bullet�X�N���v�g��Init���Ăяo��
            bulletScript.Init(shotAngle, 3);
        }
    }
}
