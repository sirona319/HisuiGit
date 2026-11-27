using UnityEngine;

public class JerryBoss : EnemyBase
{

    void Update()
    {
        AreaOut();
    }

    void AreaOut()
    {
        if (!isAreaOut) return;
        Dead();

    }
}