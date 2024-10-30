using System.Runtime.InteropServices;
using UnityEngine;


//https://gomafrontier.com/unity/1585
public class CameraControl : MonoBehaviour
{
    private Transform pTrans;
    //public GameObject mainCamera;
    private const float rotate_speed = 2f;

    //private const int ROTATE_BUTTON = 1;
    private const float ANGLE_LIMIT_UP = 75f;//75
    private const float ANGLE_LIMIT_DOWN = -75f;//75
#if UNITY_ANDROID
    [SerializeField] private VariableJoystick m_variableJoystickCamera;
#endif
    //[DllImport("user32.dll")]
    //public static extern bool SetCursorPos(int x, int y);
    void Start()
    {
        //mainCamera = Camera.main.gameObject;
        pTrans = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //プレイヤーが死んでたら無効
        //if (pTrans.GetComponent<HPUIControl>().GetHp() <= 0)
          //  return;
#if UNITY_ANDROID
#else
        if (Input.GetMouseButton(0)) return;//左クリック中
        if (Input.GetMouseButton(1)) return;//右クリック中

#endif



        //SetCursorPos(1920 / 2, 1080 / 2);
        //const int WHEEL = 2;
        //if(Input.GetMouseButtonDown(WHEEL))
        //{
        //    Debug.Log("カメラリセット");

        //    //武器を前方向へ回転させる
        //    var eDir = Camera.main.transform.forward * 100 - transform.position;

        //    var elookAtRotation = Quaternion.LookRotation(eDir, Vector3.up);

        //    transform.rotation = Quaternion.Lerp(transform.rotation, elookAtRotation, Time.deltaTime * 100f);
        //}

        transform.position = pTrans.position;

        RotateCmaeraAngle();

        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }

    private void RotateCmaeraAngle()
    {
        Vector3 angle;
#if UNITY_ANDROID

        if (UnityEngine.Device.SystemInfo.operatingSystem.Contains("Android"))
        {
            angle = new Vector3(
                m_variableJoystickCamera.Horizontal * rotate_speed,
                -m_variableJoystickCamera.Vertical * rotate_speed,
                0
            );
        }
        else
        {
            angle = new Vector3(
                Input.GetAxis("Mouse X") * rotate_speed,
                Input.GetAxis("Mouse Y") * rotate_speed,
                0
            );
        }

#elif UNITY_EDITOR_WIN
        angle = new Vector3(
            Input.GetAxis("Mouse X") * rotate_speed,
            Input.GetAxis("Mouse Y") * rotate_speed,
            0
        );

#endif

        transform.eulerAngles += new Vector3(-angle.y, angle.x,0f);
    }
}
