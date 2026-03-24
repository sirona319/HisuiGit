using UnityEngine;

//スプライトUnlit Shader
public class MosaicEnable : MonoBehaviour
{
    Material defaultMat;
    [SerializeField] Material m;
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] float resolution;

    [SerializeField] float changeSpeed=0.1f;
    [SerializeField] float changeMax=20;
    [SerializeField] float changeMin=10;
    bool changeFlg;

    private void OnEnable()
    {

        defaultMat = spriteR.material;

        //値の変更には_が必須
        m.SetFloat("_Resolution", 0);
        spriteR.material = m;

    }

    private void Update()
    {
        if (resolution > changeMax)
            changeFlg = true;

        if (resolution < changeMin)
            changeFlg = false;


        if(changeFlg)
            resolution -= changeSpeed;
        else
            resolution += changeSpeed;

        //GetComponent<SpriteRenderer>().material.SetFloat("Resolution", resolution);
        spriteR.material.SetFloat("_Resolution", resolution);
        //spriteR.material = m;

    }

    private void OnDisable()
    {

        spriteR.material = defaultMat;


    }
}
