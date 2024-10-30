using UnityEngine;
using UnityEngine.AddressableAssets;
//using System.Linq;
using Cysharp.Threading.Tasks;
using System.Linq;

public class EnemyManager : Singleton<EnemyManager>
{
    EnemySetting enemySetting;

    private async UniTask UniStart()
    {
        enemySetting = await Addressables.
               LoadAssetAsync<EnemySetting>("Assets/EnemySetting.asset");

        //�X���C���̃f�[�^���擾
        //var slimeData = enemySetting.DataList.
        //                FirstOrDefault(enemy => enemy.Id == "JerryNormal");
        //Debug.Log($"ID�F{slimeData.Id}");

    }

    private async void Start()
    {
        await UniStart();
    }

    public EnemyData GetEnemyData(string name)
    {
        var data = enemySetting.DataList.
              FirstOrDefault(enemy => enemy.Id == name);

        return data;
    }
}
