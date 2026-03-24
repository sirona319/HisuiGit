//using System.Linq;
using System.Linq;

public class EnemyManager : Singleton<EnemyManager>
{
    EnemySetting enemySetting;

    //public EnemyBase aa;
    //private async UniTask UniStart()
    //{
    //    //enemySetting = await Addressables.
    //     //      LoadAssetAsync<EnemySetting>("Assets/EnemySetting.asset");

    //    //スライムのデータを取得
    //    //var slimeData = enemySetting.DataList.
    //    //                FirstOrDefault(enemy => enemy.Id == "JerryNormal");
    //    //Debug.Log($"ID：{slimeData.Id}");


        
    //}

    void Start()
    {
        //await UniStart();

    }

    public EnemyData GetEnemyData(string name)
    {
        //enemySetting = Resources.Load<EnemySetting>("EnemySetting");

        //enemyDataのnullチェック
        if (enemySetting == null)
            throw new System.Exception("enemySetting　Data null");

        var data = enemySetting.DataList.
              FirstOrDefault(enemy => enemy.Id == name);

        return data;
    }

    //public PoolManager GetPool()
    //{
    //    //PoolManager a = new();
    //    //enemySetting.PoolManager = a;

    //    //return enemySetting.PoolManager;
    //}
}
