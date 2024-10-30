using UnityEngine;

public class CircleMagazine : BaseMagazine
{

    float timeCount = 0;
    float shotAngle = 0;

    Transform targetTrans;

    const float SHOTTIME = 3f;

    const float MAXBULLETINTERVAL = SHOTTIME+1f;


    public override void Initialize()
    {
        base.Initialize();

        var player = GameObject.FindGameObjectWithTag("Player");
        targetTrans = player.transform;

        bulletInterval = MAXBULLETINTERVAL;
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

        // 0.1秒を超えているか
        if (timeCount > 0.1f)
        {
            timeCount = 0; // 再発射のために時間をリセット

            shotAngle += 10;

            // GameObjectを新たに生成する
            // 第一引数：生成するGameObject
            // 第二引数：生成する座標
            // 第三引数：生成する角度
            // 戻り値：生成したGameObject
            var createObject = Instantiate(bulletObj.gameObject, transform.position, Quaternion.identity);

            // 生成したGameObjectに設定されている、Bulletスクリプトを取得する
            Bullet bulletScript = createObject.GetComponent<Bullet>();

            // BulletスクリプトのInitを呼び出す
            bulletScript.Init(shotAngle, 3);
        }
    }
}
