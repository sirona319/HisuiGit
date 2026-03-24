using UnityEngine;

//親のisDeadがtrueになったら自分を消す
public class DeadParent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponentInParent<CharaBase>().isDead) return;

        Destroy(gameObject);
    }
}
