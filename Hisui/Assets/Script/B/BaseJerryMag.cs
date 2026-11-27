using NaughtyAttributes;
using UnityEngine;

public class BaseJerryMag : BaseMagazine
{

    [SerializeField] protected PoolControl poolCtr;

    // [Tag]
    // [SerializeField] private string poolTag;

    private void Start()
    {
        //poolCtr = GameObject.Find("JerryPool").GetComponent<PoolControl>();
        //enabled = false;
        Debug.Log("GetPOOL");
    }

    protected override GameObject BulletAtk(float angle, Vector3 pos, Quaternion rot, GameObject charaBullet = null)
    {

        if (charaBullet == null) return null;

        charaBullet.transform.position = pos;
        charaBullet.transform.rotation = rot;
        //var bullet = Instantiate(charaBullet);

        var bullet = poolCtr.GetGameObject(charaBullet, pos, rot);//Instantiate(charaBullet);


        // 自分のプールを登録する
        var release = bullet.GetComponent<ReleaseDestroyer>();
        release.pool = poolCtr;
        // if (bullet.GetComponent<NormalBullet>() != null)
        // {
        var normalBullet = bullet.GetComponent<NormalBullet>();
        normalBullet.SetSpeed(bulletSpeed);
        normalBullet.angle = angle;
        normalBullet.BulletInit();
        // }

        return bullet;
    }
}
