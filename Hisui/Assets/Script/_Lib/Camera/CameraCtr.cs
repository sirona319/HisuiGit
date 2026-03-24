using System.Linq;
using UnityEngine;

public class CameraCtr : MonoBehaviour
{

    [SerializeField]Camera[] camerasCtr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCamera(camerasCtr[0]);

        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCamera(camerasCtr[camerasCtr.Length-1]);

        }

    }

    void ChangeCamera(Camera camera)
    {
        camerasCtr.ToList().ForEach(x =>
        {
            x.tag = "Untagged";
            x.enabled = false;
        });
        camera.tag = "MainCamera";
        camera.enabled = true;
    }
}
