using Unity.VisualScripting;
using UnityEngine;

public class ParticleMgr : MonoBehaviour
{
    public GameObject deadPt;

    public GameObject atkPt;
    public GameObject atkFirePt;

    public GameObject healPt;

    public GameObject downPt;

    public GameObject buffPt;

    public GameObject debuffPt;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healPt = (GameObject)Resources.Load("prefab/Particle/CFXR3 Hit Light B (Air)");

        downPt = (GameObject)Resources.Load("prefab/Particle/CFXR2 Poison Cloud");
        
        deadPt = (GameObject)Resources.Load("prefab/Particle/CFXR Explosion 1");

        atkPt = (GameObject)Resources.Load("prefab/Particle/CFXR4 Sword Hit PLAIN (Cross)");

        buffPt = (GameObject)Resources.Load("prefab/Particle/CFXR Impact Glowing HDR (Blue)");

        debuffPt = (GameObject)Resources.Load("prefab/Particle/CFXR4 Bouncing Glows Bubble (Blue Purple)");

        atkFirePt = (GameObject)Resources.Load("prefab/Particle/CFXR3 Hit Fire B (Air)");

    }

}
