using System.Collections;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public float deadTime = 0.3f;

    [SerializeField]bool isStart = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!isStart) return;
        StartCoroutine(DestroyTimer(deadTime));
    }

    public void SetTime()
    {
        StartCoroutine(DestroyTimer(deadTime));
    }

    IEnumerator DestroyTimer(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("TimeDestroy:" + gameObject.name);

        //Instantiate(GameObject.FindGameObjectWithTag("ParticleMgr").GetComponent<ParticleMgr>().deadPt,
        //  transform.position,
        //  Quaternion.identity);

        ////崖から石がパラパラ落ちる2
        //MyLib.MyPlayOneSound("SE/崖から石がパラパラ落ちる2", 0.3f, GameObject.FindGameObjectWithTag("SoundM").GetComponent<SoundManager>().se.gameObject);


        Destroy(gameObject);
    }
}
