using UnityEngine;
using System;
using UnityEngine.UI;


//AI
public class BaseHP : MonoBehaviour
{
    [SerializeField][Range(0,20)] protected int maxHP = 10;

    public int HP { get; private set; }
    //public int MaxHP => maxHP;

    public bool IsDead => HP <= 0;
    //public bool IsHpMax => HP >= maxHP;

    public event Action<int> OnHPChanged;
    //public event Action OnDead;


    protected virtual void Awake()
    {
        HP = maxHP;
        OnHPChanged?.Invoke(HP);
    }

    // ダメージ
    public virtual void Damage(int damage)
    {
        if (IsDead || damage <= 0) return;

        HP = Mathf.Max(0, HP - damage);//大きいほうを選択


        OnHPChanged?.Invoke(damage);//?は関数が登録されているかの確認　　登録時だけ呼び出し

        if (IsDead)
        {
            GetComponent<CharaBase>().OnDead?.Invoke();
            Debug.Log("OnDead");
            //OnDead?.Invoke();
            //Dead();
        }
    }

    // 回復
    public virtual void Heal(int heal)
    {
        if (IsDead || heal <= 0) return;

        HP = Mathf.Min(maxHP, HP + heal);//小さいほうを選択

        OnHPChanged?.Invoke(HP);
    }

    // 死亡時の処理
    //protected virtual void Dead()
    //{
    //    Destroy(gameObject);
    //}













    /// <summary>
    /// UI処理
    /// </summary>

    [SerializeField] Image[] lifeImage;

    BaseDmg dmg;

    void Start()
    {
        for (int i = 0; i < lifeImage.Length; i++)
        {
            lifeImage[i].enabled = i < HP;//iがHPより小さいときはenabledをtrueにしている AI
        }

        OnHPChanged += DamageLife;

        dmg = GetComponent<BaseDmg>();
    }

    //HPのダメージ表現
    public void DamageLife(int damage)
    {

        int saveValue = damage;
        const float volume = 0.3f;
        MyLib.MyPlaySound("Sound/SE/damaged1", volume, gameObject);
        // bossDamage.dmgTime = bossDamage.dmgTimeMax;

        for (int i = HP; i >= 0 && damage > 0; i--, damage--)
        {
            if (i >= lifeImage.Length || lifeImage[i] == null)
                continue;


            const float POW = 5f;
            StartCoroutine(MyLib.DoShake(dmg.dmgTime, POW, lifeImage[i].transform));

        }

        //成功
        StartCoroutine(MyLib.DelayCoroutine(dmg.dmgTime, () =>
        {
            DamageUpdate(saveValue);
        }));

    }


    void DamageUpdate(int damage)
    {
        for (int i = HP; i >= 0 && damage > 0; i--, damage--)
        {
            if (i >= lifeImage.Length || lifeImage[i] == null)
                continue;

            lifeImage[i].enabled = false;
        }

    }
}
