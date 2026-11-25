using NaughtyAttributes;
using UnityEngine;

public class ReleaseDestroyer : MonoBehaviour
{

    public PoolControl pool { get; set; }

    //const float DESTIME = 7f;

    public bool IsRelease = false;

    public void PoolDestroy()
    {
        if (pool != null)
        {
            //if (IsRelease)
            //{
            //    //Debug.Log("二重リリース回避");
            //    return;
            //}

            //IsRelease = true;
            pool.ReleaseGameObject(gameObject);
            return;

        }
        else
        {

            Destroy(gameObject);
            return;
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] int damageVal = 1;

    [SerializeField] bool hitDead = true;

    [Tag]
    [SerializeField] string[] tagNames;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //AI
        foreach (var tagName in tagNames)
        {
            if (!other.CompareTag(tagName))
                continue;

            var iDamage = other.GetComponent<IDamage>();

            if (iDamage == null)
                break;

            iDamage.Damage(damageVal);

            if (hitDead)
                gameObject.SetActive(false);

            break;
        }

    }


    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.transform.CompareTag(TagName.Enemy))
    //    {
    //        var iDamage = other.transform.GetComponent<IDamage>();
    //        if (iDamage != null)
    //        {
    //            MyLib.DebugInfo(other.gameObject);
    //            iDamage.Damage(1);

    //        }
    //        else
    //            Debug.Log("ダメージインターフェイスが無いよ！！"+TagName.Enemy);

    //            //Debug.Log("攻撃が敵にHIT");
    //        PoolDestroy();
    //        return;
    //    }

    //    if (other.CompareTag(TagName.EnemyBoss))
    //    {
    //        var iDamage = other.GetComponent<IDamage>();
    //        if (iDamage != null)
    //            iDamage.Damage(1);
    //        else
    //            Debug.Log("ダメージインターフェイスが無いよ！！EnemyBoss"+TagName.EnemyBoss);

    //        //Debug.Log("攻撃が敵にHITBOSS");
    //        PoolDestroy();
    //        return;
    //    }

    //}

    ////private void OnCollisionEnter2D(Collision2D other)
    ////{

    ////    if (other.gameObject.CompareTag(TagName.Enemy))
    ////    {
    ////        var iDamage = other.gameObject.GetComponent<IDamage>();
    ////        if (iDamage != null)
    ////            iDamage.Damage(1);
    ////        else
    ////            Debug.Log("ダメージインターフェイスが無いよ！！" + TagName.Enemy);

    ////        //Debug.Log("攻撃が敵にHIT");
    ////        PoolDestroy();
    ////        return;
    ////    }

    ////    if (other.gameObject.CompareTag(TagName.EnemyBoss))
    ////    {
    ////        var iDamage = other.gameObject.GetComponent<IDamage>();
    ////        if (iDamage != null)
    ////            iDamage.Damage(1);
    ////        else
    ////            Debug.Log("ダメージインターフェイスが無いよ！！EnemyBoss" + TagName.EnemyBoss);

    ////        //Debug.Log("攻撃が敵にHITBOSS");
    ////        PoolDestroy();
    ////        return;
    ////    }

    ////}

    //private void OnTriggerExit2D(Collider2D other)
    //{

    //    if (other.CompareTag(TagName.ExitErea))
    //    {
    //        PoolDestroy();
    //        return;
    //    }

    //}
}