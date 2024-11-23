using UnityEngine;

public class FiveMagazine : BaseMagazine, ITarget
{
    public Transform Target { get; set; }
    const float ONEWEYLENGTH = 15f;
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
        FiveShot();
    }
    public override void MagazineUpdate()
    {

    }

    void FiveShot()
    {

        Vector2 direction = Target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        BulletAtk(angle + 0);
        BulletAtk(angle + ONEWEYLENGTH);
        BulletAtk(angle + TWOWEYLENGTH);
        BulletAtk(angle + -ONEWEYLENGTH);
        BulletAtk(angle + -TWOWEYLENGTH);


        //AngleShot(playerAngle, 0);

        //AngleShot(playerAngle,ONEWEYLENGTH);
        //AngleShot(playerAngle,TWOWEYLENGTH);
        //AngleShot(playerAngle,-ONEWEYLENGTH);
        //AngleShot(playerAngle,-TWOWEYLENGTH);

    }

}
