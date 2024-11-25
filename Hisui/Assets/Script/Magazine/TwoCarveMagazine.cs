using UnityEngine;
using static BaseBullet;

public class TwoCarveMagazine : BaseMagazine,ITarget
{
    public Transform Target { get; set; }
    const float ONEWEYLENGTH = 7f;
    //const float TWOWEYLENGTH = 30f;

    public override void Initialize()
    {

        //var player = GameObject.FindGameObjectWithTag("Player");
        //targetTrans = player.transform;

        //bulletInterval = MAXBULLETINTERVAL;
    }

    public override void MagazineEnter()
    {
        //if (targetTrans == null) return;
        TwoShot();
    }
    public override void MagazineUpdate()
    {

    }

    void TwoShot()
    {

        Vector2 direction = Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //createBullet.BulletAtk(angle + 0);
        var rBullet = createBullet.BulletAtk(angle + ONEWEYLENGTH, transform.position, transform.rotation);
        //createBullet.BulletAtk(angle + TWOWEYLENGTH);
        var lBullet = createBullet.BulletAtk(angle - ONEWEYLENGTH, transform.position, transform.rotation);

        createBullet.AddBulletType(rBullet, BulletType.CarveModule);
        createBullet.AddBulletType(lBullet, BulletType.CarveModule);

        const float rotVal = 2f;
        const float carveVal = 10f;
        rBullet.GetComponent<CarveModule>().InitParam(-carveVal, rotVal);
        lBullet.GetComponent<CarveModule>().InitParam(carveVal, rotVal);



        //createBullet.BulletAtk(angle + -TWOWEYLENGTH);


        //AngleShot(playerAngle, 0);

        //AngleShot(playerAngle,ONEWEYLENGTH);
        //AngleShot(playerAngle,TWOWEYLENGTH);
        //AngleShot(playerAngle,-ONEWEYLENGTH);
        //AngleShot(playerAngle,-TWOWEYLENGTH);

    }
}
