using System.Linq;
using UnityEngine;

public class DamageChara : MonoBehaviour
{
    [SerializeField] int damageVal = 1;

    [SerializeField] string[] tagNames;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        var iDamage = other.GetComponent<IDamage>();

        tagNames.ToList().ForEach(tagName =>
        {
            if (other.CompareTag(tagName))
             {
                 if (iDamage != null)
                 {
                     iDamage.Damage(damageVal);
                 }
             }
        });

        //if (iDamage != null)
        //{
        //    iDamage.Damage(damageVal);

        //    //isActiveTrigger = true;
        //    // SetTimeline(true);
        //    //Debug.Log(other.name);
        //}

    }

    //public IDamage damage;
    //public bool isActiveTrigger = false;

    //タイムライン再生用の関数
    //public void SetTimeline(bool act)
    //{
    //    if (transform.parent.GetComponent<TimelineControl>() == null)return;

    //    transform.parent.GetComponent<TimelineControl>().isPlayTrigger = act;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag(TagName.Player)/*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        var iDamage = other.transform.GetComponent<IDamage>();
    //        if (iDamage != null)
    //            iDamage.Damage(1);
    //        //isActiveTrigger = true;
    //        // SetTimeline(true);
    //        Debug.Log(other.name);

    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.CompareTag(TagName.Player) /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        //isActiveTrigger = false;
    //       /// SetTimeline(false);
    //    }

    //}

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.transform.CompareTag(TagName.Player) /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        //isActiveTrigger = false;
    //        // SetTimeline(false);
    //        Debug.Log(other.name);
    //    }

    //}
}
