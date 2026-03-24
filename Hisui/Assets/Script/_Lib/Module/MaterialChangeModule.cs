using UnityEngine;

public class MaterialChangeModule : MonoBehaviour
{
    Material defaultMat;
    [SerializeField] Material m;
    [SerializeField] SpriteRenderer spriteR;


    private void OnEnable()
    {

        defaultMat = spriteR.material;
        spriteR.material = m;


    }

    private void OnDisable()
    {
        spriteR.material = defaultMat;

    }
}
