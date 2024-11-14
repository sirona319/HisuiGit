using UnityEngine;

public class CircleOneMagazine : BaseMagazine
{
 //   float timeCount = 0;
    float shotAngle = 0;

    Transform targetTrans;

    //const float SHOTTIME = 3f;

    const float BULLETTIMEMAX = 4f;

    //逆回り作る
    public override void Initialize()
    {
        //base.Initialize();

       // var player = GameObject.FindGameObjectWithTag("Player");
        //targetTrans = player.transform;

        //bulletInterval = 0;

       // bulletShotTime = BULLETTIMEMAX;
    }

    public override void MagazineEnter()
    {
        shotAngle = 0;

        CircleOneShot();
    }

    public override void MagazineUpdate()
    {
        //bulletInterval -= Time.deltaTime;


        //if (bulletInterval > SHOTTIME)
        //    return;



        //if(bulletInterval <= 0)
        //bulletInterval = MAXBULLETINTERVAL;
    }



    void CircleOneShot()
    {
        // 前フレームからの時間の差を加算
        //timeCount += Time.deltaTime;

        // 0.1秒を超えているか
        //if (timeCount > 0.1f)
        //{
        //timeCount = 0; // 再発射のために時間をリセット

        const int bNum = 35;
        //const float bSpeed = 3;
        for(int i=0;i<= bNum; i++)
        {

        
            shotAngle += 10;

            BulletAtk(shotAngle);

            //// GameObjectを新たに生成する
            //// 第一引数：生成するGameObject
            //// 第二引数：生成する座標
            //// 第三引数：生成する角度
            //// 戻り値：生成したGameObject
            //var createObject = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);

            //// 生成したGameObjectに設定されている、Bulletスクリプトを取得する
            //Bullet bulletScript = createObject.GetComponent<Bullet>();

            //// BulletスクリプトのInitを呼び出す
            //bulletScript.Init(shotAngle, bSpeed);
        }
        //}
    }
}
