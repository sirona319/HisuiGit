using DG.Tweening;
using UnityEngine;

public class DOJumpDirMove2D : BaseMove
{
    [SerializeField] float addH = 0f;
    [SerializeField] float addV = 0f;

    [SerializeField] int jumpCount = 1;
    [SerializeField] float dur = 1;
    [SerializeField] float power = 1;

    [SerializeField] bool Local = false;

    public override void Initialize()
    {

    }

    public override void MoveEnter()
    {
        //var rand = Random.Range(0.1f, 0.5f);
        //-2.44 -2.173412

        if(Local)
        {
            this.transform.DOLocalJump
                (new Vector3(transform.position.x + addH, transform.position.y + addV, 0f),
                jumpPower: power, numJumps: jumpCount, duration: dur);
        }
        else
        {
            this.transform.DOJump
                (new Vector3(transform.position.x + addH, transform.position.y + addV, 0f),
                jumpPower: power, numJumps: jumpCount, duration: dur);
        }

        //addH += addH;
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
