using UnityEngine;

public class CircleOneMagazine : BaseMagazine
{
    float shotAngle = 0;

    //Transform targetTrans;

    const float BULLETTIMEMAX = 4f;

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

        const int bNum = 35;
        for(int i=0;i<= bNum; i++)
        {
            shotAngle += 10;

            createBullet.BulletAtk(shotAngle, transform.position, transform.rotation);

        }

    }
}
