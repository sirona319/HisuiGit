using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//https://kurokumasoft.com/2022/05/28/unity-shader-graph-dissolve-effect/
public sealed class DissolveEffect : MonoBehaviour
{
    [SerializeField] Renderer[] renderers = { };
    [SerializeField] float effectDuration = 1f;
    [SerializeField] Ease effectEase = Ease.Linear;
    [SerializeField] string progressParamName = "_Progress";

    List<Material> materials = new List<Material>();
    Sequence sequence;

    // Start is called before the first frame update
    void Start()
    {
        GetMaterials();

        DissoleveIn();
    }

    public void DissoleveIn()
    {
        sequence = DOTween.Sequence().SetLink(gameObject).SetEase(effectEase);

        foreach(Material m in materials)
        {
            m.SetFloat(progressParamName, 0);
            sequence.Join(m.DOFloat(1,progressParamName,effectDuration));
        }

        sequence.Play();
    }

    public void DissolveOut()
    {
        sequence = DOTween.Sequence().SetLink(gameObject).SetEase(effectEase);

        foreach (Material m in materials)
        {
            m.SetFloat(progressParamName, 1);
            sequence.Join(m.DOFloat(0, progressParamName, effectDuration));
        }

        sequence.Play();
    }

    void GetMaterials()
    {
        foreach(Renderer r in renderers)
        {
            foreach(Material m in r.materials)
            {
                materials.Add(m);
            }
        }
    }
}
