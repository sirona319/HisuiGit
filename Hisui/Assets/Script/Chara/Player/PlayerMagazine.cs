using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class PlayerMagazine : BaseMagazine
{
    float intervalTime = 0f;
    [SerializeField]float intervalTimeMax = 1f;
    //[SerializeField] GameObject pNormal;
    [SerializeField] AudioClip clip;

    void Start()
    {
        intervalTime = intervalTimeMax;
    }

    public override void MagazineUpdate()
    {

        intervalTime -= Time.deltaTime;
#if ENABLE_INPUT_SYSTEM
        // New input system backends are enabled.
        if(intervalTime <= 0)

        if (Keyboard.current.fKey.isPressed || Mouse.current.leftButton.isPressed)
        {
            intervalTime = intervalTimeMax;
            NormalShot();

            MyLib.MyPlayOneSound(clip,GetComponent<AudioSource>());
        }
#endif

#if ENABLE_LEGACY_INPUT_MANAGER
    // Old input backends are enabled.
        if (Input.GetKey(KeyCode.F) && intervalTime <= 0)
        {
            intervalTime = intervalTimeMax;
            NormalShot();

            MyLib.MyPlayOneSound("Sound/SE/PlayerNormalShot", gameObject.GetComponent<AudioSource>());
        }
#endif

    }

    void NormalShot()
    {

        Vector2 direction = (transform.position + Vector3.right) - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        BulletAtk(pAngle, transform.position, transform.rotation, poolCtr.Prefab); //Target渡す
    }


    [SerializeField] PoolControl poolCtr;

    protected override GameObject BulletAtk(float angle, Vector3 pos, Quaternion rot, GameObject charaBullet = null)
    {

        if (charaBullet == null) return null;

        charaBullet.transform.position = pos;
        charaBullet.transform.rotation = rot;
        //var bullet = Instantiate(charaBullet);

        var bullet = poolCtr.GetGameObject(charaBullet,pos,rot);//Instantiate(charaBullet);


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
