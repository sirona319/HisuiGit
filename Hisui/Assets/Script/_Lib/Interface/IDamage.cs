using UnityEngine;

//ダメージ関数を持つスクリプト
public interface IDamage
{
    public bool IsDamage { get; set; }

    public bool Damage(int damage);

    //public virtual void Damage(int damage,bool sound) { }
}
