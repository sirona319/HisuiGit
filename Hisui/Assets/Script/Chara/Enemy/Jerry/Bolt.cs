using DigitalRuby.LightningBolt;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] LightningBoltScript blt;

    [SerializeField] GameObject bady;

    LightningBoltScript bltIt;

    private void OnEnable()
    {
        blt.StartObject = transform.gameObject;
        blt.EndObject = bady;

        bltIt=Instantiate(blt, transform.position, Quaternion.identity);
        bady.GetComponent<BoltReceive>().bltR = bltIt;
    }

    private void OnDisable()
    {
        if (bltIt.gameObject != null)
            bltIt.gameObject.SetActive(false);
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
