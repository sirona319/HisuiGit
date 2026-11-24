using System.Collections.Generic;
using UnityEngine;

public class PointM : BaseMove
{
    [SerializeField] protected List<Transform> moveTrans;
    [SerializeField] List<float> endLength;
    [SerializeField] float speed = 4f;
    //const float rotSpeed = 5f;

    [SerializeField] bool isLoop = false;

    protected int targetNo = 0;

   // Rigidbody2D rb2;

    Vector3 direction;
    void Start()
    {
      //  rb2 = GetComponent<Rigidbody2D>();
        //transform.DetachChildren();
        direction = (moveTrans[targetNo].position - transform.position).normalized;
    }

    void Update()
    {

        PointUpdate();
        //direction = (moveTrans[targetNo].position - transform.position).normalized;

    }


    //Vector2 velocity = Vector2.zero;
    void PointUpdate()
    {
        //rb2.position + (Vector2)transform.up * speed * Time.deltaTime

        transform.position += direction * speed * Time.deltaTime;

        float len = Vector3.Distance(transform.position, moveTrans[targetNo].position);
        if (len < endLength[targetNo])
        {

            targetNo++;
            if (targetNo > moveTrans.Count - 1)
            {

                //if (!IsKeepMove)
                //isPointMoveEnd.Value = true;
                Destroy(gameObject);
                //if (isLoop)
                //    targetNo = 0;
                //else
                //    targetNo--;
            }

        }

     //   transform.rotation = MyLib.GetAngleRotationFuncs(moveTrans[targetNo].position, transform, rotSpeed);

    }

}
