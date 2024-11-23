using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleScr : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;

    private Vector3 targetPos;

    private const float speed=3f;
    private const float interpolant=2f;

    private Rigidbody rb;

    bool isMove=false;
    // Start is called before the first frame update tttあああててaa
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        startPos = transform.position;
        var savePos=transform.position;
        savePos.x += 30.0f;
        endPos = savePos;

        targetPos = endPos;
    }

    // Update is called once per frame
    void Update()
    {
        //左右に移動する処理　回転補正付き





        //回転
        var dir = targetPos - transform.position;

        var lookAtRotation = Quaternion.LookRotation(dir, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotation, Time.deltaTime * interpolant);


        Vector3 movement = speed * Time.deltaTime * transform.forward;
        rb.MovePosition(rb.position + movement);

        float len = Vector3.Distance(transform.position, targetPos);

        if (len<1f)
        {
            if (!isMove)
            {
                isMove = !isMove;
                targetPos = startPos;
            }
            else
            {
                isMove = !isMove;
                targetPos = endPos;
            }

        }

    }
}
