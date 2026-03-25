using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class JumpMoveDO : BaseMove
{
    [SerializeField] float randMin = 0.1f;
    [SerializeField] float randMax = 0.5f;
    public override void Initialize()
    {
        base.Initialize();
    }

    public override void MoveEnter()
    {

        this.transform.DOJump
            (new Vector3(transform.position.x, transform.position.y, 0f),
            jumpPower: 1f + Random.Range(randMin, randMax), numJumps: 1, duration: 1f + Random.Range(randMin, randMax))
            .SetLoops(-1, LoopType.Yoyo);

        //this.transform.DOJump
        //    (new Vector3(rb2.position.x, rb2.position.y, 0f), jumpPower: 1f, numJumps: 1, duration: 1f)
        //    .SetLoops(-1, LoopType.Yoyo);
    }

    public override void MoveUpdate()
    {

        
    }

    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
        Debug.Log(this.GetType().FullName + "Destroy");
    }

}

