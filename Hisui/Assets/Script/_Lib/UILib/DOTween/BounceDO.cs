using DG.Tweening;
using UnityEngine;

public class BounceDO : MonoBehaviour
{
    RectTransform rectTrans;

    [SerializeField] float duration = 0.4f;
    [SerializeField] float moveY = 20f;
    //[SerializeField] int loopTime = -1;

    void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        StartNewRecordAnim();
    }

    void StartNewRecordAnim()
    {
        rectTrans.DOLocalMoveY(moveY, duration)
        .SetRelative(true)
        .SetEase(Ease.OutQuad)
        .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        Debug.Log(this.GetType().FullName + "Destroy");
    }
}
