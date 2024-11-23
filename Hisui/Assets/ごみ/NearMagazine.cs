using UnityEngine;

public class NearMagazine : BaseMagazine,ITarget
{
    public Transform Target { get; set; }

    public override void Initialize()
    {
        //bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/Bullet/JerryOutBullet");
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
        //前方方向 　プレイヤーの中間のベクトルが必要？

        Vector2 direction = Target.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        BulletAtk(pAngle);
    }

}
