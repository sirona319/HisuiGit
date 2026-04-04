using UnityEngine;

public class CircleOneMagazine : BaseMagazine
{
    float shotAngle = 0;

    //Transform targetTrans;

    //const float BULLETTIMEMAX = 4f;
    //public float shotTime = 0;

    //CreateBullet createBullet;

    //public BulletTarget bulletTarget;

    private void Start()
    {
        shotAngle = 0;

        CircleOneShot();
    }

    private void Update()
    {
        
    }
    //逆回り作る
    public override void Initialize()
    {
        //createBullet = GetComponent<CreateBullet>();
    }

    public override void MagazineEnter()
    {


        CircleOneShot();
    }

    public override void MagazineUpdate()
    {

    }

    void CircleOneShot()
    {
        shotAngle = 0;
        const int bulletNum = 35;
        for(int i=0;i<= bulletNum; i++)
        {
            shotAngle += 10;

            BulletAtk(shotAngle, transform.position, transform.rotation);

        }

    }
}
