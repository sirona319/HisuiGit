using NaughtyAttributes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using UnityEngine;

public class DamageChara : MonoBehaviour
{
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
