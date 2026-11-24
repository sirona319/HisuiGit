using System;
using UnityEngine;

public class CharaBase : MonoBehaviour
{

    public bool IsDead { get; private set; } = false;

    public virtual void Dead()
    {
        if (IsDead) return;
        OnDead?.Invoke();
        IsDead = true;
        Debug.Log("deaddddd");
    }

    public event Action OnDead;
}
