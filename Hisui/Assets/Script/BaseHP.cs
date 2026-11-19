
using UnityEngine;
using System;


//AI
public class BaseHP : MonoBehaviour
{
    [SerializeField] protected int maxHP = 10;

    public int HP { get; private set; }
    //public int MaxHP => maxHP;

    public bool IsDead => HP <= 0;
    //public bool IsHpMax => HP >= maxHP;

    public event Action<int> OnHPChanged;
    public event Action OnDead;


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
            OnDead?.Invoke();
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
}
