using DigitalRuby.LightningBolt;
using UnityEngine;

public class Bolt : MonoBehaviour
{

    [SerializeField] LightningBoltScript blt;

    [SerializeField] GameObject bady;


    LightningBoltScript bltIt;

    //bool isAct = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        blt.StartObject = transform.gameObject;
        blt.EndObject = bady;

        bltIt=Instantiate(blt, transform.position, Quaternion.identity);
        bady.GetComponent<BoltReceive>().bltR = bltIt;
        //isAct = true;
    }

    private void OnDisable()
    {
        if(bltIt.gameObject!=null)
        Destroy(bltIt.gameObject);
        //isAct = true;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (!isAct) return;
    //    //if(transform.gameObject==null||bady==null)
    //    //{
    //    //    bltGo.gameObject.SetActive(false);
    //    //    isAct = false;
    //    //}
    //    if (!transform.gameObject.activeInHierarchy|| !bady.gameObject.activeInHierarchy)
    //    {
    //        bltGo.gameObject.SetActive(false);
    //        isAct = false;
    //    }

    //}
}
