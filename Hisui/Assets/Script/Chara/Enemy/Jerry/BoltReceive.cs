using DigitalRuby.LightningBolt;
using UnityEngine;

public class BoltReceive : MonoBehaviour
{

    public LightningBoltScript bltR;

    private void OnDisable()
    {
        if (bltR != null)
            Destroy(bltR.gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
