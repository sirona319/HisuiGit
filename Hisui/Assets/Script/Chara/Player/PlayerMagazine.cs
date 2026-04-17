using UnityEngine;
using UnityEngine.InputSystem;
using static TargetSet;

[DisallowMultipleComponent]
public class PlayerMagazine : BaseMagazine
{

    float intervalTime = 0f;
    [SerializeField]float intervalTimeMax = 1f;
    [SerializeField] GameObject pNormal;

    //[SerializeField] CreateBullet createBullet;

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

            MyLib.MyPlayOneSound("Sound/SE/PlayerNormalShot", gameObject.GetComponent<AudioSource>());
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

        BulletAtk(pAngle, transform.position, transform.rotation, pNormal); //Target渡す
    }
}
