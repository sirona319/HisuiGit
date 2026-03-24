using UnityEngine;
using UnityEngine.Tilemaps;

public class DownGround : MonoBehaviour
{
    bool playerFall = false;

    [Tooltip("Sキー入力時 非アクティブ化する時間")]
    [HeaderAttribute("Sキー入力時 非アクティブ化する時間")]
    [SerializeField] float tileDisableTime = 0.3f;
    private void Update()
    {
        if (!playerFall) return;

        if(Input.GetKeyDown(KeyCode.S) && GetComponent<TilemapCollider2D>()!=null)
        {
            GetComponent<TilemapCollider2D>().enabled = false;

            StartCoroutine(MyLib.DelayCoroutine(tileDisableTime, () =>
            {
                GetComponent<TilemapCollider2D>().enabled = true;
            }));
        }

        if (Input.GetKeyDown(KeyCode.S) && GetComponents<BoxCollider2D>() != null)
        {
            foreach(var box in GetComponents<BoxCollider2D>())
            {
                box.enabled = false;
            }

            StartCoroutine(MyLib.DelayCoroutine(tileDisableTime, () =>
            {
                foreach (var box in GetComponents<BoxCollider2D>())
                {
                    box.enabled = true;
                }
            }));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            playerFall = true;
            //Debug.Log("DownGroundEnter");

        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player")/*|| other.transform.CompareTag("PlayerAI")*/)
        {
            playerFall = false;
            //Debug.Log("DownGroundExit");

        }

    }
}
