using UnityEngine;

public class SetLinkObj : MonoBehaviour
{
    [SerializeField] GameObject linkObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (linkObj == null)
            linkObj = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (linkObj != null) return;
        Destroy(gameObject);
    }
}
