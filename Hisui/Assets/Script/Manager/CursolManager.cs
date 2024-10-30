using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursolManager : Singleton<CursolManager>
{
    bool isCursol = false;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (!isCursol) return;

        Cursor.visible = true;
        
    }

    public void SetCursol(bool flg)
    {
        if(flg)
        {
            Cursor.lockState = CursorLockMode.Confined;
            isCursol = true;
        }
        else
        {

            Cursor.visible = false;
            isCursol = false;
        }

    }
}
