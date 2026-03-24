using UnityEngine;
//using UnityEngine.InputSystem; ProjectSetting→Player→OtherSettings→ActiveInputHandlingをInputSystemPackageにする必要がある
public class MouseControl : MonoBehaviour
{
    public GameObject selectObj;

    const int LEFT = 0;
    const int RIGHT = 1;

    [SerializeField] float XLIMIT = 8.5f;
  //  [SerializeField] float YLIMIT = 0f;
    [SerializeField] float ZLIMIT = 8.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void Update()
    {

        SetlectObjMove();
        if (Input.GetMouseButtonDown(LEFT))
        {
            //MyLib.DebugRayViewCameraZ();

            selectObj = MyLib.DebugRayViewCameraPosZ();

            if(selectObj!= null )
            if(selectObj.isStatic)
            {
                selectObj = null;
            }
        }

       
    }

    void SetlectObjMove()
    {
        if (!Input.GetMouseButton(LEFT)) return;
        if (selectObj == null) return;

        const float SPEED = 0.4f;



        //selectObj.transform.position=
        selectObj.transform.position += Camera.main.transform.right * Input.GetAxis("Mouse X") * SPEED +
            Camera.main.transform.up * Input.GetAxis("Mouse Y") * SPEED;

        selectObj.transform.position = MoveLimit(selectObj.transform.position);
    }

    Vector3 MoveLimit(Vector3 pos)
    {

        //Vector3 resultPos = pos;
        pos.x = Mathf.Clamp(pos.x, -XLIMIT, XLIMIT);
        pos.z = Mathf.Clamp(pos.z, -ZLIMIT, ZLIMIT);

        return pos;
    }
}
