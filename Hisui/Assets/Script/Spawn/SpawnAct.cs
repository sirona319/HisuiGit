using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnAct : MonoBehaviour
{
    [SerializeField] SpawnAct spawnAct=null;
    //bool isEnable = false;

    [SerializeField] float spawnTimer = 0f;

    public List<Transform> spawnObjs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //if(spawnAct==null)
        //    isEnable = true;
        //spawnObjs = transform.GetComponentsInChildren<Transform>().ToList();

        //transform.GetComponentsInChildren<Transform>().ToList().ForEach(x =>
        //{
        //    if (x.tag == "Enemy")
        //    {
        //        x.transform.gameObject.SetActive(false);
        //        spawnObjs.Add(x);
        //    }
        //    else
        //        spawnObjs.Remove(x);
        //    // Debug.Log(x.name);
        //});

        //gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnAct!=null)
         if (spawnAct.spawnObjs.Count>0) return;

        spawnTimer += Time.deltaTime;

        spawnObjs.ToList().ForEach(x =>
        {
            //if (x.tag == "Enemy")
            if (x.GetComponent<JerryFall>().SpawnTime < spawnTimer)
            {
                x.transform.gameObject.SetActive(true);
                spawnObjs.Remove(x);
            }
            // Debug.Log(x.name);
        });
    }
}
