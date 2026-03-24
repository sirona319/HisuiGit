using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSwordRot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        const float ROLLSPEED = 7f;
        var rot = Quaternion.AngleAxis(ROLLSPEED, Vector3.right);

        transform.rotation = transform.rotation * rot;
    }
}
