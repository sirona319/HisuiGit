using UnityEngine;
using UnityEngine.Pool;



//プールマネージャーは敵と味方攻撃判定　ごとに分けて所持する　Player Enemyで二つ　基本
public class PoolControl : MonoBehaviour
{
    private ObjectPool<GameObject> pool;

    public GameObject Prefab { get; private set; }

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(OnCreatePooledObject, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject);
    }

    GameObject OnCreatePooledObject()
    {
        return Instantiate(Prefab);
    }

    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    void OnDestroyPooledObject(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject GetGameObject(GameObject prefab,Vector3 position,Quaternion rotation)
    {
        Prefab= prefab;
        GameObject obj=pool.Get();
        Transform tf = obj.transform;
        tf.position=position;
        tf.rotation=rotation;

        return obj;
    }

    public void ReleaseGameObject(GameObject obj)
    {
        
        pool.Release(obj);
    }
}
