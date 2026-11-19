using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class JerryBoss : EnemyBase, IDamage
{

    ParticleSystem dmgPt;

    public float dmgTimeMax = 1f;
    public float dmgTime = 0;
    public bool IsDamage => dmgTime > 0;
    void Start()
    {

        dmgPt = Resources.Load("prefab/Particle/CFXR2 BloodJerry").GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {

        if (IsDamage)
            GetComponent<BlinkSpriteMod>().enabled = true;
        else
            GetComponent<BlinkSpriteMod>().enabled = false;

        if (dmgTime > 0)
            dmgTime -= Time.deltaTime;

        AreaOut();
    }

    public void Damage(int damage)
    {
        if (isDead) return;
        if (IsDamage) return;
        if (GetComponent<BaseHP>().IsDead) return;

        //ダメージパーティクル表示
        Instantiate(dmgPt, transform.position, Quaternion.identity);

        GetComponent<BaseHP>().Damage(damage);//HP減少処理

        if (GetComponent<BaseHP>().HP <= 0)
        {
            isDead = true;

            gameObject.SetActive(false);

        }


    }

    void AreaOut()
    {
        if (!isAreaOut) return;
        isDead = true;

        GetComponent<SoundCreateDead>().enabled = false;
        gameObject.SetActive(false);

    }

}
