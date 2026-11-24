using UnityEngine;

public class JerryBoss : EnemyBase
{

    SoundCreateDead sd;
    void Awake()
    {
        sd = GetComponent<SoundCreateDead>();
    }

    void Update()
    {
        AreaOut();
    }

    void AreaOut()
    {
        if (!isAreaOut) return;
        sd.enabled = false;
        Dead();

    }
}