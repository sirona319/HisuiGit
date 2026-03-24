using UnityEngine;
using static BaseBullet;

public class TwoCarveMagazine : BaseMagazine
{
    public Transform Target { get; set; }
    const float ONEWEYLENGTH = 7f;
    //const float TWOWEYLENGTH = 30f;

    CreateBullet createBullet;

    public override void Initialize()
    {
        createBullet = GetComponent<CreateBullet>();
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


        //バレットのタイプを上書き　他のモジュールは入る　消す仕様にする後々？？
        createBullet.AddBulletType(rBullet, ModuleClassName.CarveModule.ToString());
        createBullet.AddBulletType(lBullet, ModuleClassName.CarveModule.ToString());

        const float carveVal = 10f;
        rBullet.GetComponent<CarveModule>().SetAngle(-carveVal);
        lBullet.GetComponent<CarveModule>().SetAngle(carveVal);



        //createBullet.BulletAtk(angle + -TWOWEYLENGTH);


        //AngleShot(playerAngle, 0);

        //AngleShot(playerAngle,ONEWEYLENGTH);
        //AngleShot(playerAngle,TWOWEYLENGTH);
        //AngleShot(playerAngle,-ONEWEYLENGTH);
        //AngleShot(playerAngle,-TWOWEYLENGTH);

    }
}
