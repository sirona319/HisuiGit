using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightCtr2D : MonoBehaviour
{
    [SerializeField] Light[] lights2D;

    //[SerializeField] float targetValMax = 2f;
    [SerializeField] float changeSpeed = 0f;

    bool isLight = false;
    float diff = 0f;
    float targetVal = 0f;


    void Update()
    {
        if (!isLight) return;

        foreach (var l in lights2D)
        {
            l.intensity += diff * changeSpeed;

        }

        if(math.distance(lights2D[0].intensity, targetVal)<0.01f)
        {
            foreach (var l in lights2D)
            {
                l.intensity = targetVal;
            }
            isLight = false;

        }

    }

    public void LightIntentisySet(float val)
    {
        targetVal = val;
        isLight = true;

        var lightVal = lights2D[0].intensity;

        diff = (targetVal- lightVal);

    }

}
