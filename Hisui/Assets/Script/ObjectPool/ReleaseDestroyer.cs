using System.Collections;
using UnityEngine;

public class ReleaseDestroyer : MonoBehaviour
{

    public PoolControl pool { get; set; }

    const float DESTIME = 7f;

    public bool IsRelease = false;

    public void PoolDestroy()
    {
        //var pool = GetComponent<Destroyer>().PoolManager;
        if (pool != null)
        {
            if (IsRelease)
            {
                //Debug.Log("二重リリース回避");
                return;
            }

            IsRelease = true;
            pool.ReleaseGameObject(gameObject);
            return;
            //Debug.Log(gameObject.name+"POOLした");
        }
        else
        {
            //Debug.Log("Erea消去");
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            //プレイヤーへのダメージ処理
            other.transform.GetComponent<PlayerScr2D>().PlayerDamage(1);

            //Debug.Log("攻撃がPlayerにHIT");

            PoolDestroy();
            return;
        }

        if (other.CompareTag("Enemy"))
        {
            other.transform.GetComponent<EnemyBase>().EnemyDamage(1);

            //Debug.Log("攻撃が敵にHIT");
            PoolDestroy();
            return;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //return;

        if (other.CompareTag("ExitErea"))
        {
            PoolDestroy();
            return;
        }

    }
}