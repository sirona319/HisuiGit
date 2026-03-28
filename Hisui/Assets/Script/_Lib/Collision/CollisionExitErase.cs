using UnityEngine;

public class CollisionExitErase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerExit2D(Collider2D other)
    {
        var chara = other.GetComponent<EnemyBase>();
        if(chara!=null)
        {
            chara.isEreaOut = true;
            Debug.Log("chara.isEreaOut = true;");
            return;
        }

        //var chara = other.GetComponent<CharaBase>();
        //if (chara!=null)
        //{
        //    if(other.GetComponent<EnemyBase>())
        //    {
        //        //Destroy(other.gameObject);
        //        Debug.Log("Destroy(other.gameObject);");
        //    }

        //    //chara.isDead = true;
        //    //Debug.Log("chara.isDead = true;");
        //    return;
        //}

        Destroy(other.gameObject);
        Debug.Log("Destroy(other.gameObject);");

        //if (other.CompareTag("Enemy"))
        //{
        //var iDamage = other.transform.GetComponent<IDamage>();
        //if (iDamage != null)
        //{
        //    iDamage.Damage(1);
        //    //MyLib.DebugInfo(other.gameObject);
        //}
        //else
        //    //Debug.Log(other.tag + " " + other.gameObject.layer);

        ////Debug.Log("攻撃が敵にHIT");
        //return;
        //}

    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{

    //    if (other.CompareTag("Enemy"))
    //    {
    //        //var iDamage = other.transform.GetComponent<IDamage>();
    //        //if (iDamage != null)
    //        //{
    //        //    iDamage.Damage(1, false);
    //        //    Debug.Log(other.tag + " " + other.gameObject.layer);
    //        //}
    //        //else
    //        //    Debug.Log(other.tag + " " + other.gameObject.layer);

    //        //Debug.Log("攻撃が敵にHIT");
    //        //return;
    //    }

    //}

    //void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}
