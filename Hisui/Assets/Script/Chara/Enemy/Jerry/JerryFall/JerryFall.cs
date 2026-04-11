using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class JerryFall : EnemyBase,IDamage
{
    //public float SpawnTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gameObject.GetComponentInParent<SpawnAct>().spawnObjs.Add(transform);
    }

    // Update is called once per frame
    void Update()
    {
        AreaOut();
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        var dmgParticle = Resources.Load("prefab/Particle/CFXR2 BloodJerry").GetComponent<ParticleSystem>();
        //ダメージパーティクル表示
        Instantiate(dmgParticle, transform.position, Quaternion.identity);

        Hp -= damage;        //HP減少処理

        if (Hp <= 0)
        {
            isDead = true;

            //メッシュ　当たり判定　非表示　
            //GetComponent<SpriteRenderer>().enabled = false;
            //GetComponent<BoxCollider2D>().enabled = false;
            //GetComponent<SoundMove>().SoundFadeStop();



            GetComponent<SoundCreateDead>().SoundPlay();
            //GetComponent<TimeDestroy>().enabled = true;
            //GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }


    }

    void AreaOut()
    {
        if (!isEreaOut) return;
        isDead = true;

        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
        //GetComponent<SoundMove>().SoundFadeStop();

        GetComponent<SoundCreateDead>().enabled = false;
        gameObject.SetActive(false);
        //GetComponent<TimeDestroy>().enabled = true;
        //GetComponent<TrailRenderer>().material.DOFade(endValue: 0, duration: 1f);
        //Destroy(gameObject);
    }

    private void OnDisable()
    {
        Debug.Log("JerryFall OnDisable");
        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SoundMove>().SoundFadeStop();
    }

}
