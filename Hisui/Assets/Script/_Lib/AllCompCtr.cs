using UnityEngine;

public class AllCompCtr : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AllCompOff();
        }
    }
    public void AllCompOff()
    {
        var allComp = GetComponentsInChildren<MonoBehaviour>();
        foreach (var comp in allComp)
        {
            comp.enabled = false;
        }

    }

    public void AllCompOn()
    {
        var allComp = GetComponentsInChildren<MonoBehaviour>();
        foreach (var comp in allComp)
        {
            comp.enabled = true;
        }

    }
}
