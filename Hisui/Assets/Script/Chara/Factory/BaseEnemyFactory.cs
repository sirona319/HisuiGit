using System.Collections.Generic;
using UnityEngine;
using static EnemySpawnWave;

public abstract class BaseEnemyFactory : MonoBehaviour
{
    public EnemyData eData;
    public abstract EnemyBase Load(Transform spawn);
}

public abstract class BaseJerryEnemyFactory : BaseEnemyFactory
{

    // LoadState factoryState;
    //protected JerryScr enemy;

    //GameObject enemy;
    //EnemyData eData;

    //public void SelectFactory(LoadState state)
    //{
    //    //if (state == LoadState.PointJerry)
    //    //{
    //    //    //string eName = loadState.ToString();
    //    //    Type typeClass = Type.GetType(state.ToString());
    //    //    var eObj = typeClass.ConvertTo<JerryPointFactory>();
    //    //}
    //}

    public abstract override EnemyBase Load(Transform s);

    public abstract EnemyData SetData();

    public abstract string SetName();

    public abstract int SetMaxHp();

    //public abstract Transform[] SetPoint();

    public abstract List<BaseMove> SetMove(Transform[] t);

    public abstract List<BaseMagazine> SetMagazine();

}
