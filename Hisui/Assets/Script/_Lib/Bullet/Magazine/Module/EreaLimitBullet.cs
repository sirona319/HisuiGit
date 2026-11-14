using UnityEngine;

//ターゲットが近くに来たら撃つ
public class EreaLimitBullet : MonoBehaviour
{
    [SerializeField] float debuglen = 0;

    [SerializeField] Transform target;

    float targetLen = 0;

    [SerializeField] float limitLen = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // targetSet = GetComponent<TargetSet>();
       // target = targetSet.SetVec(target);
    }

    // Update is called once per frame
    void Update()
    {

        targetLen = Vector2.Distance(transform.position, target.position);
        debuglen = targetLen;
        if (targetLen < limitLen)
        {
            GetComponent<BaseMagazine>().enabled = true;
        }
        else
        {
            GetComponent<BaseMagazine>().enabled = false;

        }

    }
}
