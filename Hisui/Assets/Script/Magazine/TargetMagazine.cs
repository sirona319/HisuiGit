using UnityEngine;

public class TargetMagazine : BaseMagazine, ITarget
{

    public Transform Target { get; set; }

    public override void Initialize()
    {

        //var player = GameObject.FindGameObjectWithTag("Player");
        //targetTrans = player.transform;

    }

    public override void MagazineEnter()
    {
        //if (targetTrans == null) return;
        NormalShot();
    }


    public override void MagazineUpdate()
    {

    }

    void NormalShot()
    {

        Vector2 direction = Target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        createBullet.BulletAtk(pAngle, transform.position, transform.rotation); //Target渡す
    }

}


