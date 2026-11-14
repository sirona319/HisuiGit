using UnityEngine;
using static BaseBullet;

public class TwoCarveMagazine : BaseMagazine
{
    public Transform Target { get; set; }
    const float ONEWEYLENGTH = 7f;
    //const float TWOWEYLENGTH = 30f;

    //CreateBullet createBullet;
    //逆回り作る
    public override void Initialize()
    {
      //  createBullet = GetComponent<CreateBullet>();
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
        var rBullet = BulletAtk(angle + ONEWEYLENGTH, transform.position, transform.rotation);
        //BulletAtk(angle + TWOWEYLENGTH);
        var lBullet = BulletAtk(angle - ONEWEYLENGTH, transform.position, transform.rotation);


        //バレットのタイプを上書き　他のモジュールは入る　消す仕様にする後々？？
        //AddBulletType(rBullet.GetComponent<BaseBullet>(), ModuleClassName.CarveModule.ToString());
        //AddBulletType(lBullet.GetComponent<BaseBullet>(), ModuleClassName.CarveModule.ToString());

        //const float carveVal = 10f;
        //rBullet.GetComponent<CarveModule>().SetAngle(-carveVal);
        //lBullet.GetComponent<CarveModule>().SetAngle(carveVal);



        //BulletAtk(angle + -TWOWEYLENGTH);


        //AngleShot(playerAngle, 0);

        //AngleShot(playerAngle,ONEWEYLENGTH);
        //AngleShot(playerAngle,TWOWEYLENGTH);
        //AngleShot(playerAngle,-ONEWEYLENGTH);
        //AngleShot(playerAngle,-TWOWEYLENGTH);

    }
}
