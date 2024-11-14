using UniRx;
using UnityEngine;

public interface IPointMove
{
    //Transform[] tArray;
    //ReactiveProperty<bool>  IsPointMoveEnd { get; set; }
    void TargetSet(Transform[] t);

    bool GetMoveEnd();

    void SetMoveEndLength(float len);
    //{
    //    tArray = t;

    //    if (targets.Length <= 0)
    //        throw new System.Exception(transform.name + "PointMoveムーブポイント未設定");
    //}

}
