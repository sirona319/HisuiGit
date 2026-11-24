using UnityEngine;

public class JerryFall : EnemyBase, IDamage
{
    [SerializeField] ParticleSystem dmgPt;
    SoundCreateDead sd;

    int Hp = 1;

    void Awake()
    {
        sd = GetComponent<SoundCreateDead>();

    }

    // Update is called once per frame
    void Update()
    {
        AreaOut();
    }

    public void Damage(int damage)
    {
        if (IsDead) return;

        //ダメージパーティクル表示
        Instantiate(dmgPt, transform.position, Quaternion.identity);

        Hp -= damage;        //HP減少処理

        if (Hp <= 0)
        {
            Dead();
        }


    }

    void AreaOut()
    {
        if (!isAreaOut) return;

        sd.enabled = false;
        Dead();
    }

}
