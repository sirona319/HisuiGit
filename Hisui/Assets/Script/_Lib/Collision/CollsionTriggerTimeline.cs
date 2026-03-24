using UnityEngine;

public class TimelineCollsionTrigger : MonoBehaviour
{
    //タイムライン再生用の関数
    public void SetTimeline(bool act)
    {
        if (transform.parent.GetComponent<TimelineControl>() == null) return;

        transform.parent.GetComponent<TimelineControl>().isPlayTrigger = act;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag(TagName.Player)/*|| other.transform.CompareTag("PlayerAI")*/)
    //    {

    //        SetTimeline(true);


    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.transform.CompareTag(TagName.Player) /*|| other.transform.CompareTag("PlayerAI")*/)
    //    {
    //        SetTimeline(false);
    //    }

    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {

            SetTimeline(true);

        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
        {
            SetTimeline(false);
        }

    }
}
