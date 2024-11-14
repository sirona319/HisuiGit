using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{

    public PoolManager PoolManager { get; set; }

    const float DESTIME = 7f;

    public void StartDestroyTimer(float time= DESTIME)
    {
        StartCoroutine(DestroyTimer(time));
    }

    IEnumerator DestroyTimer(float time)
    {
        yield return new WaitForSeconds(time);

        if (PoolManager != null)
        {
            PoolManager.ReleaseGameObject(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}