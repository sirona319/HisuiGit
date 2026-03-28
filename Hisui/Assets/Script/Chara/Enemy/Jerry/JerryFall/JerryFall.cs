using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class JerryFall : EnemyBase,IDamage
{
    public float SpawnTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.GetComponentInParent<SpawnAct>().spawnObjs.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        EreaOut();
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        var dmgParticle = Resources.Load("prefab/Particle/DamagePt").GetComponent<ParticleSystem>();
        //ダメージパーティクル表示
        Instantiate(dmgParticle, transform.position, Quaternion.identity);

        Hp -= damage;        //HP減少処理

        if (Hp <= 0)
        {
            isDead = true;

            //メッシュ　当たり判定　非表示　
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SoundMove>().SoundFadeStop();
            GetComponent<SoundCreateDead>().SoundPlay();
            GetComponent<TimeDestroy>().enabled = true;
            GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);
            //Destroy(gameObject);
        }


    }

    void EreaOut()
    {
        if (!isEreaOut) return;
        isDead = true;
        GetComponent<SoundCreateDead>().enabled = false;


        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SoundMove>().SoundFadeStop();
        GetComponent<TimeDestroy>().enabled = true;
        GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);
        // Destroy(gameObject);
    }

}
