using UnityEngine;

public class NormalMagazine : BaseMagazine
{

    Transform targetTrans;

    const float MAXBULLETINTERVAL = 1f;

    public override void Initialize()
    {
        base.Initialize();

        var player = GameObject.FindGameObjectWithTag("Player");
        targetTrans = player.transform;



        bulletInterval = MAXBULLETINTERVAL;
    }

    public override void MagazineUpdate()
    {
        bulletInterval -= Time.deltaTime;

        if (bulletInterval > 0f)
            return;


        NormalShot();


        bulletInterval = MAXBULLETINTERVAL;

    }

    void NormalShot()
    {
        //var bulletPos = transform.position;
        // 対象物へのベクトルを算出
        //Vector3 toDirection = targetTrans.position - transform.position;


        // 対象物へ回転する
        //var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);


        var ebullet = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);

        Vector2 direction = targetTrans.position - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var bulletComp = ebullet.GetComponent<Bullet>();
        bulletComp.angle = pAngle;
    }

    public void ChangeShotNum()
    {
        Debug.Log("弾の発射数を変更");
    }



}


