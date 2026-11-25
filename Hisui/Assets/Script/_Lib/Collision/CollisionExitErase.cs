using NaughtyAttributes;
using UnityEngine;

public class CollisionExitErase : MonoBehaviour
{
    [Layer]
    public int[] m_PoollayerIndex;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) return;

        var ene = other.GetComponent<EnemyBase>();
        if (ene != null)
        {
            ene.isAreaOut = true;
            Debug.Log("EnemyBase.isAreaOut = true;");
            return;
        }


        //プール　　バレット
        foreach(var poolLayer in m_PoollayerIndex)
        {

            if(other.gameObject.layer== poolLayer)
            {
                other.GetComponent<ReleaseDestroyer>().PoolDestroy();
                Debug.Log("pool");
                return;
            }    

        }

        Destroy(other.gameObject);

    }


}
