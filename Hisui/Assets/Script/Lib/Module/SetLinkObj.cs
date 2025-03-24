using UnityEngine;

public class SetLinkObj : MonoBehaviour
{
    public GameObject linkObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (linkObj == null)
            Destroy(gameObject);
    }
}
