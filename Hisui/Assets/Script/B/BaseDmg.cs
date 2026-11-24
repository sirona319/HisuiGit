using UnityEngine;

public class BaseDmg : MonoBehaviour, IDamage
{
    [SerializeField] float dmgTimeMax = 1f;
    [SerializeField] ParticleSystem dmgPt;

    public float dmgTime;

    public bool IsDamage => dmgTime > 0;

    BaseHP hp;
    BlinkSpriteMod blink;

    void Awake()
    {
        hp = GetComponent<BaseHP>();
        blink = GetComponent<BlinkSpriteMod>();
    }

    void Update()
    {
        if (dmgTime > 0)
            dmgTime -= Time.deltaTime;

        blink.enabled = IsDamage;
    }

    public virtual void Damage(int damage)
    {
        if (GetComponent<CharaBase>().IsDead || IsDamage)return;

        // ダメージ時間設定
        dmgTime = dmgTimeMax;

        // パーティクル
        if (dmgPt != null)
            Instantiate(dmgPt, transform.position, Quaternion.identity);

        // HP減少
        hp.Damage(damage);

        // 死亡判定
        //if (hp.HP <= 0)
        //   chara.Dead();
    }
}