using UnityEngine;
using static EnemySpawnWave;

public abstract class BaseBuilder:MonoBehaviour
{
    //public abstract void Init(BaseEnemyFactory factory);

    public abstract void Build(EnemyData eData,Transform s, Transform[] movePoint, PoolManager pool);

}
