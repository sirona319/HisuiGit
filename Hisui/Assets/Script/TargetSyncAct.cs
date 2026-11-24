using Unity.VisualScripting;
using UnityEngine;


//同期　オブジェクトの有効　無効

public class TargetSyncActChild : MonoBehaviour
{

    [SerializeField] GameObject go;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (go == null) return;

        if (go.activeInHierarchy)
        {
            foreach (Transform child in transform.GetComponentsInChildren<Transform>())
            {
                if (child == transform) continue;

                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform.GetComponentsInChildren<Transform>())
            {
                if (child == transform) continue;

                child.gameObject.SetActive(false);
            }
        }

    }
}
