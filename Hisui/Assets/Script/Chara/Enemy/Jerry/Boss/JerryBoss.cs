using UnityEngine;

public class JerryBoss : EnemyBase
{
    void Start()
    {
        GetComponent<CharaBase>().OnDead+= Dead;
    }

    void Update()
    {
        AreaOut();
    }

    public void Dead()
    {
        //if (isDead) return;

        isDead = true;
        gameObject.SetActive(false);
    }

    void AreaOut()
    {
        if (!isAreaOut) return;

        isDead = true;

        GetComponent<SoundCreateDead>().enabled = false;
        gameObject.SetActive(false);
    }
}