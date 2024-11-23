using UnityEngine;

public class TwoMagazine : BaseMagazine,ITarget
{
    public Transform Target { get; set; }
    const float ONEWEYLENGTH = 7f;
    const float TWOWEYLENGTH = 30f;

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

        //BulletAtk(angle + 0);
        var rBullet = BulletAtk(angle + ONEWEYLENGTH);
        //BulletAtk(angle + TWOWEYLENGTH);
        var lBullet = BulletAtk(angle + -ONEWEYLENGTH);///バレットタイプを上書き　引数追加

        lBullet.GetComponent<CarveModule>().angleVal = -40f;
        rBullet.GetComponent<CarveModule>().angleVal = 40f;



        //BulletAtk(angle + -TWOWEYLENGTH);


        //AngleShot(playerAngle, 0);

        //AngleShot(playerAngle,ONEWEYLENGTH);
        //AngleShot(playerAngle,TWOWEYLENGTH);
        //AngleShot(playerAngle,-ONEWEYLENGTH);
        //AngleShot(playerAngle,-TWOWEYLENGTH);

    }
}
