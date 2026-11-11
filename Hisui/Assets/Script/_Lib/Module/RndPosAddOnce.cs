using UnityEngine;

public class RndPosAddOnce : MonoBehaviour
{

    [SerializeField] float spawnRndRangeMax = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 t = transform.position;
        transform.position = new Vector3
            (Random.Range(t.x + -spawnRndRangeMax, t.x + spawnRndRangeMax),
            Random.Range(t.y + -spawnRndRangeMax, t.y + spawnRndRangeMax),
            Random.Range(t.z + -spawnRndRangeMax, t.z + spawnRndRangeMax));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
