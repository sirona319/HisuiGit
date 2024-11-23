using UniRx;
using UnityEngine;

public interface IPointMove
{
    void TargetSet(Transform[] t);

    bool GetMoveEnd();

    void SetMoveEndLength(float len);

}
