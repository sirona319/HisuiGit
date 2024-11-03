using UnityEngine;

public class PointCircleMove : BaseMove
{

    CircleMove circle;
    PointMove point;


    public override void Initialize()
    {
        base.Initialize();

        point =gameObject.AddComponent<PointMove>();
        circle = gameObject.AddComponent<CircleMove>();

        circle.Initialize();
        point.Initialize();
    }


    public override void MoveEnter()
    {

    }

    public override void MoveUpdate()
    {
        if (!point.IsMove)
        {
            circle.MoveUpdate();

            return;
        }

        point.MoveUpdate();

        if (!point.IsMove)
        {
            GetComponent<JerryScr>().IsAttack = true;
            //IsMove = point.IsMove;
            Destroy(point);
            //point.enabled = false;//ポイント移動を終了
            circle.MoveEnter();
        }
    }


    
}
