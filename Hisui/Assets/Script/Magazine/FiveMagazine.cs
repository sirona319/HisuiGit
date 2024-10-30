using UnityEngine;

public class FiveMagazine : BaseMagazine
{
    Transform targetTrans;
    const float ONEWEYLENGTH = 15f;
    const float TWOWEYLENGTH = 30f;

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


        FiveShot();


        bulletInterval = MAXBULLETINTERVAL;
    }

    void FiveShot()
    {

        //float pAngle = Mathf.Atan2(direction.x, direction.y);


        ////////////////Playerë_Ç¢Å@íe
        //var bulletPos = transform.position;
        // ëŒè€ï®Ç÷ÇÃÉxÉNÉgÉãÇéZèo
        //Vector3 toDirection = targetTrans.position - transform.position;

        // ëŒè€ï®Ç÷âÒì]Ç∑ÇÈ
        //var bulletRot = Quaternion.FromToRotation(Vector3.up, toDirection);


        //var ebullet = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);
        //ebullet.GetComponent<Bullet>().angle = playerAngle;


        Vector2 direction = targetTrans.position - transform.position;
        float playerAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        AngleShot(playerAngle, 0);

        AngleShot(playerAngle,ONEWEYLENGTH);
        AngleShot(playerAngle,TWOWEYLENGTH);
        AngleShot(playerAngle,-ONEWEYLENGTH);
        AngleShot(playerAngle,-TWOWEYLENGTH);


        //var tarRot = Quaternion.AngleAxis(-ONEWEYLENGTH, -Vector3.forward) * bulletRot;
        //ebullet = Instantiate(bulletObj.gameObject, bulletPos, tarRot);
        //ebullet.GetComponent<Bullet>().angle = pAngle + ONEWEYLENGTH;


        //tarRot = Quaternion.AngleAxis(-ONEWEYLENGTH, -Vector3.forward) * bulletRot;
        //ebullet = Instantiate(bulletObj.gameObject, bulletPos, tarRot);
        //ebullet.GetComponent<Bullet>().angle = pAngle + TWOWEYLENGTH;

        //tarRot = Quaternion.AngleAxis(ONEWEYLENGTH, -Vector3.forward) * bulletRot;
        //ebullet = Instantiate(bulletObj.gameObject, bulletPos, tarRot);
        //ebullet.GetComponent<Bullet>().angle = pAngle - ONEWEYLENGTH;

        //tarRot = Quaternion.AngleAxis(ONEWEYLENGTH, -Vector3.forward) * bulletRot;
        //ebullet = Instantiate(bulletObj.gameObject, bulletPos, tarRot);
        //ebullet.GetComponent<Bullet>().angle = pAngle - TWOWEYLENGTH;
    }

    void AngleShot(float targetAngle, float angleValue)
    {


        //var tarRot = Quaternion.AngleAxis(shotAngle, -Vector3.forward) * firstBulletRot;


        var ebullet = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);


        ebullet.GetComponent<Bullet>().angle = targetAngle + angleValue;
    }

}
