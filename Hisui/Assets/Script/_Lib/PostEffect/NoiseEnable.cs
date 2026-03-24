using UnityEngine;


//GlitchEffectRandomTiming Shader
public class NoiseEnable : MonoBehaviour
{
    Material defaultMat;
    [SerializeField] Material m;
    [SerializeField] SpriteRenderer spriteR;
    [SerializeField] float blocksize=24f;
    [SerializeField] float amount=0.3f; //ずれる方向
    [SerializeField] float frequency=0.7f;
    [SerializeField] float duration=0.8f;

    float dirChangeTime = 0f;

    private void OnEnable()
    {
        
        defaultMat = spriteR.material;
        spriteR.material= m;
        //値の変更には_が必須
        spriteR.material.SetFloat("_BlockSize", blocksize);
        spriteR.material.SetFloat("_GlitchAmount", amount);
        spriteR.material.SetFloat("_GlitchFrequency", frequency);
        spriteR.material.SetFloat("_GlitchDuration", duration);

    }

    private void Update()
    {
        dirChangeTime += Time.deltaTime;

        if(dirChangeTime > 3)
        {
            var am = spriteR.material.GetFloat("_GlitchAmount") *- 1;
            spriteR.material.SetFloat("_GlitchAmount", am);
            dirChangeTime = 0;
        }


    }

    private void OnDisable()
    {

        spriteR.material = defaultMat;

    }
}
