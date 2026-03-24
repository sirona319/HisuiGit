using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    public bool isActiveTrigger = false;

    //タイムライン再生用の関数
    //public void SetTimeline(bool act)
    //{
    //    if (transform.parent.GetComponent<TimelineControl>() == null)return;

    //    transform.parent.GetComponent<TimelineControl>().isPlayTrigger = act;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            isActiveTrigger = true;
            // SetTimeline(true);
            Debug.Log(other.name);

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
        {
            isActiveTrigger = false;
           /// SetTimeline(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            isActiveTrigger = true;
            Debug.Log(other.name);

            //Destroy(other.gameObject);
            //SetTimeline(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
        {
            isActiveTrigger = false;
            // SetTimeline(false);
            Debug.Log(other.name);
        }

    }
}
