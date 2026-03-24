using UnityEngine;

public class LayersRay: MonoBehaviour
{
    [SerializeField]public LayerMask targetLayer;

    public static GameObject DebugRayViewWithMask(LayerMask mask, bool debugDraw = true)
    {
        float distance = 1000f;
        float duration = 50f;

        Camera mainCam = Camera.main;
        if (mainCam == null) return null;

        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (debugDraw)
        {
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);
        }

        // 第4引数に直接 LayerMask を渡すだけ！
        if (Physics.Raycast(ray, out RaycastHit hit, distance, mask))
        {
            if (debugDraw) Debug.Log($"Hit: {hit.collider.gameObject.name} (Layer: {LayerMask.LayerToName(hit.collider.gameObject.layer)})");
            return hit.collider.gameObject;
        }

        return null;
    }
}
