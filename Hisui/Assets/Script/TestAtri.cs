using UnityEngine;
using UnityEngine.Events;

public class test : MonoBehaviour
{
    public UnityEvent OnDead;

    public void Dead()
    {
        OnDead?.Invoke();
    }
}