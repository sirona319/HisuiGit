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

        if (other.CompareTag("Enemy"))
        {
            var iDamage = other.transform.GetComponent<IDamage>();
            if (iDamage != null)
            {
                iDamage.Damage(1);
                //MyLib.DebugInfo(other.gameObject);
            }
            else
                //Debug.Log(other.tag + " " + other.gameObject.layer);

            //Debug.Log("攻撃が敵にHIT");
            return;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {
            //var iDamage = other.transform.GetComponent<IDamage>();
            //if (iDamage != null)
            //{
            //    iDamage.Damage(1, false);
            //    Debug.Log(other.tag + " " + other.gameObject.layer);
            //}
            //else
            //    Debug.Log(other.tag + " " + other.gameObject.layer);

            //Debug.Log("攻撃が敵にHIT");
            //return;
        }

    }

    //void OnBecameInvisible()
    //{
    //    Destroy(this.gameObject);
    //}
}
