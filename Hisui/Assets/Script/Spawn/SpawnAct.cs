using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnAct : MonoBehaviour
{
    [SerializeField] SpawnAct spawnAct = null;

    [SerializeField] float spawnTimer = 0f;

    public List<Transform> spawnObjs;

   // [SerializeField] bool isEnable = true;

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
       // if (!isEnable) return;

        //if(spawnAct!=null)
        // if (spawnAct.spawnGos.Count > 0) return;

        spawnTimer += Time.deltaTime;

        spawnObjs.ToList().ForEach(x =>
        {
            //if (x.tag == "Enemy")
            if (x.GetComponent<EnemyBase>().SpawnTime < spawnTimer)
            {
                x.transform.gameObject.SetActive(true);
                spawnObjs.Remove(x);
                x.parent= null;
            }
            // Debug.Log(x.name);
        });

        if (spawnObjs.Count == 0)
        {
            if (spawnAct != null)
            {
                //GameObjectを保持　全て死亡したら　アクティブ
                //spawnAct.gameObject.SetActive(true);
            }
            //isEnable = false;
            Destroy(gameObject);
        }
    }


    //シグナルで呼び出す関数
    //public void TimerStart()
    //{
    //    isEnable = true;
    //}
}
