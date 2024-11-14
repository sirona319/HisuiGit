using UnityEditor.EditorTools;
using UnityEngine;

public class CircleMagazine : BaseMagazine
{

    float timeCount = 0;
    float shotAngle = 0;

    //Transform targetTrans;

    //const float SHOTTIME = 3f;

    const float BULLETTIMEMAX = 4f;

    //逆回り作る
    public override void Initialize()
    {
        //base.Initialize();

        ///var player = GameObject.FindGameObjectWithTag("Player");
       // targetTrans = player.transform;

        //bulletInterval = 0;

        shotTime = BULLETTIMEMAX;
    }

    public override void MagazineEnter()
    {
        shotAngle = 0;
    }

    public override void MagazineUpdate()
    {
        //bulletInterval -= Time.deltaTime;


        //if (bulletInterval > SHOTTIME)
        //    return;

        CircleShot();

        //if(bulletInterval <= 0)
        //bulletInterval = MAXBULLETINTERVAL;
    }



    void CircleShot()
    {
        // 前フレームからの時間の差を加算
        timeCount += Time.deltaTime;

        const int angleChangeVal = 10;
        const float shotTiming = 0.1f;
        // 0.1秒を超えているか
        if (timeCount > shotTiming)
        {
            timeCount = 0; // 再発射のために時間をリセット

            shotAngle += angleChangeVal;

            BulletAtk(shotAngle);

            // GameObjectを新たに生成する
            // 第一引数：生成するGameObject
            // 第二引数：生成する座標
            // 第三引数：生成する角度
            // 戻り値：生成したGameObject
            //var createObject = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);

            // 生成したGameObjectに設定されている、Bulletスクリプトを取得する
            //Bullet bulletScript = createObject.GetComponent<Bullet>();

            // BulletスクリプトのInitを呼び出す
            //bulletScript.Init(shotAngle, 3);
        }
    }

    //void BulletAtk(float angle)
    //{

    //    var bullet = poolManager.GetGameObject(bulletObj.gameObject, transform.position, transform.rotation);
    //    bullet.GetComponent<Bullet>().Init(angle, 3);

    //    var destroyer = bullet.GetComponent<Destroyer>();
    //    destroyer.PoolManager = poolManager;

    //    if (destroyer != null)
    //        destroyer.StartDestroyTimer(3);


    //}
}
