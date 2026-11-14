using System;
using System.Collections;
using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{

    //public Rigidbody rb3;

    //public Rigidbody2D rb2;
    //public bool isMove = true;

    //public Vector3 GetRb()
    //{
    //    if (GetComponent<Rigidbody2D>() != null)
    //        return rb2;

    //    if (GetComponent<Rigidbody>() != null)
    //        return rb3;

    //    return null;
    //}

    //public void SetPos(Vector3 pos)
    //{
    //    if (GetComponent<Rigidbody2D>() != null)
    //    {
    //        rb2.position = pos;
    //        return;
    //    }

    //    if (GetComponent<Rigidbody>() != null)
    //    {
    //        rb3.position = pos;

    //        return;
    //    }

    //    transform.position=pos;
    //}

    public virtual void Initialize()
    {
        //if(GetComponent<Rigidbody2D>()!=null)
        //    rb2 = GetComponent<Rigidbody2D>();

        //if (GetComponent<Rigidbody>() != null)
        //    rb3 = GetComponent<Rigidbody>();
    }

    public virtual void MoveEnter() { }
    public virtual void MoveExit()
    {

    }


    public virtual void MoveUpdate() { }


    //public IEnumerator ExCoroutine(float seconds, Action action)
    //{
    //    yield return new WaitForSeconds(seconds);
    //    action?.Invoke();
    //}
}
