using UnityEngine;
using System;
using UnityEngine.UI;


//AI
public class BaseHP : MonoBehaviour
{

    #region HP
    [SerializeField][Range(0,20)] protected int maxHP = 10;

    public int HP { get; private set; }
    //public int MaxHP => maxHP;

    //private bool IsDead => HP <= 0;
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
        if (GetComponent<CharaBase>().IsDead || damage <= 0) return;

        HP = Mathf.Max(0, HP - damage);//大きいほうを選択


        OnHPChanged?.Invoke(HP);//?は関数が登録されているかの確認　　登録時だけ呼び出し

        if (HP <= 0)
            GetComponent<CharaBase>().Dead();
        
    }

    // 回復
    public virtual void Heal(int heal)
    {
        if (GetComponent<CharaBase>().IsDead || heal <= 0) return;

        HP = Mathf.Min(maxHP, HP + heal);//小さいほうを選択

        OnHPChanged?.Invoke(HP);
    }

    // 死亡時の処理
    //protected virtual void Dead()
    //{
    //    Destroy(gameObject);
    //}
    #endregion











    #region DMG

    /// <summary>
    /// UI処理
    /// </summary>
    /// 
    [SerializeField] AudioClip clip;
    BaseDmg dmg;
    [SerializeField] Image[] lifeImage;

    void Start()
    {
        for (int i = 0; i < lifeImage.Length; i++)
        {
            lifeImage[i].enabled = i < HP;//iがHPより小さいときはenabledをtrueにしている
        }

        OnHPChanged += DamageLife;

        dmg = GetComponent<BaseDmg>();
    }

    //HPのダメージ表現
    public void DamageLife(int hp)
    {
        const float volume = 0.3f;

        MyLib.MyPlayOneSound(clip, GetComponent<AudioSource>(), volume);


        for (int i = hp; i < lifeImage.Length; i++)
        {
            if (lifeImage[i] == null) continue;


            const float POW = 5f;
            StartCoroutine(MyLib.DoShake(dmg.dmgTime, POW, lifeImage[i].transform));

        }

        StartCoroutine(MyLib.DelayCoroutine(dmg.dmgTime, () =>
        {
            DamageUpdate(hp);
        }));

    }


    void DamageUpdate(int hp)
    {
        for (int i = 0; i < lifeImage.Length; i++)
        {
            if (lifeImage[i] == null) continue;

            lifeImage[i].enabled = i < hp;
        }

    }

    #endregion

}
