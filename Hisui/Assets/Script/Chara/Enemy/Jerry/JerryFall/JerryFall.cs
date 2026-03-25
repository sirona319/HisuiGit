using Unity.VisualScripting;
using UnityEngine;

public class JerryFall : CharaBase,IDamage
{
    public int Hp = 0;

    //public bool IsDamage { get; set; }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public virtual void EnemyDamage(int damage)
    //{
    //    if (GetComponent<CharaBase>().isDead) return;

    //    //Debug.Log(gameObject.name + "へのダメージ" + damage.ToString());
    //    Hp -= damage;        //HP減少処理

    //    //IsDamage = true;

    //    if (Hp <= 0)
    //    {
    //        GetComponent<CharaBase>().isDead = true;
    //        return;
    //    }

    //    var dmgParticle = Resources.Load("prefab/Particle/DamagePt").GetComponent<ParticleSystem>();
    //    //ダメージパーティクル表示
    //    Instantiate(dmgParticle, transform.position, Quaternion.identity);
    //}

    public void Damage(int damage)
    {
        if (GetComponent<CharaBase>().isDead) return;

        Hp -= damage;        //HP減少処理

        if (Hp <= 0)
        {
            GetComponent<CharaBase>().isDead = true;
        }

        var dmgParticle = Resources.Load("prefab/Particle/DamagePt").GetComponent<ParticleSystem>();
        //ダメージパーティクル表示
        Instantiate(dmgParticle, transform.position, Quaternion.identity);
    }
}
