using System;
using System.Collections;
using UnityEngine;

public class LineRenderModule : MonoBehaviour
{
    //public Transform start;
    [SerializeField] Transform[] targets;
    [SerializeField] GameObject lineRenderer;
    [SerializeField] Material mat;
    [SerializeField] float endLength = 0.3f;

    LineRenderer lineObj;

    bool isTimer = false;
    float offTiming = 0;
    float timer = 0;



    void Start()
    {
        //lineObj = Instantiate(lineRenderer.gameObject, transform.position, Quaternion.identity).GetComponent<LineRenderer>();
        //lineObj.GetComponent<LineRenderer>().enabled = false;


        LineCreate(transform);
        LineDraw();

        StartCoroutine(DelayOff(gameObject));


    }

    void Update()
    {
        if (!isTimer) return;

        timer += Time.deltaTime;

        if(timer>=offTiming)
        {
            lineObj.enabled = false;
            isTimer = false;
            //transform.gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    void SetOffTimer(float t)
    {
        isTimer = true;
        offTiming = t;
    }

    void LineCreate(Transform t)
    {
        lineObj = Instantiate(lineRenderer.gameObject, transform.position, Quaternion.identity, t).GetComponent<LineRenderer>();
        lineObj.enabled = false;
        if (mat == null) return;
            lineObj.material = mat;
    }

    void LineDraw()
    {
        lineObj.enabled = true;

        Vector3[] arrayPos = new Vector3[targets.Length];
        int i = 0;
        foreach (var t in targets)
        {
            arrayPos[i++] = t.position;
        }


        lineObj.positionCount = targets.Length;
        lineObj.SetPositions(arrayPos);

    }

    //private void OnDestroy()
    //{
    //    Destroy(gameObject);
    //}

    Vector3 GetLastPos()
    {
        return targets[targets.Length - 1].position;
    }

    IEnumerator DelayOff(GameObject go)
    {

        yield return new WaitUntil(() => Vector3.Distance(GetLastPos(), go.transform.position) <= endLength);//trueなら

        //this.GetComponent<LineRenderModule>().SetOffTimer(0f);
        gameObject.SetActive(false);
    }
}
