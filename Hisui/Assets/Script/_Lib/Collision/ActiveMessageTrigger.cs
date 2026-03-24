using UnityEngine;

public class ActiveMessageTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            //isActiveTrigger = true;
            //Debug.Log(other.name);

            //Destroy(other.gameObject);
            //SetTimeline(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player") /*|| other.transform.CompareTag("PlayerAI")*/)
        {
            //isActiveTrigger = false;
            // SetTimeline(false);
            //Debug.Log(other.name);
        }

    }
}
