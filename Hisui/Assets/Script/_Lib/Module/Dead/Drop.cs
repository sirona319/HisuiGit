using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] GameObject go;

    bool isDropEnd = false;

    private void Update()
    {
        if(!GetComponent<CharaBase>().isDead) return;
        if(isDropEnd) return;

        Instantiate(go, transform.position, Quaternion.identity);
        isDropEnd = true;

    }

}
