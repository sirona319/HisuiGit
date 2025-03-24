using UnityEngine;

public class CircleOneMagazine : BaseMagazine
{
    float shotAngle = 0;

    //Transform targetTrans;

    //const float BULLETTIMEMAX = 4f;
    //public float shotTime = 0;

    [SerializeField] CreateBullet createBullet;

    //public BulletTarget bulletTarget;
    //逆回り作る
    public override void Initialize()
    {

    }

    public override void MagazineEnter()
    {
        shotAngle = 0;

        CircleOneShot();
    }

    public override void MagazineUpdate()
    {

    }

    void CircleOneShot()
    {

        const int bulletNum = 35;
        for(int i=0;i<= bulletNum; i++)
        {
            shotAngle += 10;

            createBullet.BulletAtk(shotAngle, transform.position, transform.rotation);

        }

    }
}
