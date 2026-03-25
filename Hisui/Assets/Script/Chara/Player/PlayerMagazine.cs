using UnityEngine;
using static TargetSet;

[DisallowMultipleComponent]
public class PlayerMagazine : BaseMagazine
{

    float intervalTime = 0f;
    [SerializeField]float intervalTimeMax = 1f;
    [SerializeField] GameObject pNormal;

    void Start()
    {
        intervalTime = intervalTimeMax;
    }

    public override void MagazineUpdate()
    {

        intervalTime -= Time.deltaTime;
        if (Input.GetKey(KeyCode.F)&&intervalTime<=0)
        {
            intervalTime = intervalTimeMax;
            NormalShot();

            MyLib.MyPlayOneSound("Sound/SE/PlayerNormalShot", gameObject.GetComponent<AudioSource>());
        }
    }

    void NormalShot()
    {

        Vector2 direction = (transform.position + Vector3.right) - transform.position;
        float pAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//ターゲットへの角度を取得する

        GetComponent<CreateBullet>().BulletAtk(pAngle, transform.position, transform.rotation, pNormal); //Target渡す
    }
}
