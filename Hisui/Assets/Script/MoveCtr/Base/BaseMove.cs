using System;
using System.Collections;
using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{


    protected Rigidbody2D m_rb;
    void SetRb2D(Rigidbody2D rb2)
    {
        m_rb = rb2;
    }

    public bool IsKeepMove = false;//“®‚«‘±‚¯‚éˆÚ“®

    //public void SetRb(Rigidbody2D rb)
    //{
    //    m_rb = rb;
    //}
    //public bool IsMove = true;

    //public Transform[] targets;

    public virtual void Initialize(Rigidbody2D rb)
    {
        m_rb = rb;
        //base.Initialize();

    }

    public abstract void MoveEnter();
    //public virtual void MoveExit()
    //{

    //}


    public abstract void MoveUpdate();


    //public IEnumerator ExCoroutine(float seconds, Action action)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    action?.Invoke();
    //}
}
