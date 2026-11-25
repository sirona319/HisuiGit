using UnityEngine;


//同期　オブジェクトの有効　無効

public class TargetSyncActChild : MonoBehaviour
{

    [SerializeField] GameObject go;

    // Update is called once per frame
    void Update()
    {
        if (go == null) return;

        if (go.activeInHierarchy)
        {

            //GetComponentsInChildren<Transform>(true)
            //この true は、非アクティブ（Inactive）になっている子オブジェクトも検索対象に含めるか
            foreach (Transform child in transform.GetComponentsInChildren<Transform>(true))
            {
                if (child == transform) continue;

                child.gameObject.SetActive(true);
            }
        }
        else
        {
            foreach (Transform child in transform.GetComponentsInChildren<Transform>(true))
            {
                if (child == transform) continue;

                child.gameObject.SetActive(false);
            }
        }

    }
}
