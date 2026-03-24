//using UnityEngine;


/*


//https://gomafrontier.com/unity/1585
public class CameraSanmple2 : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    //public GameObject mainCamera;
    float rotate_speed = 2f;

    const int ROTATE_BUTTON = 1;
    const float ANGLE_LIMIT_UP = 75f;
    const float ANGLE_LIMIT_DOWN = -75f;


    [SerializeField] private VariableJoystick m_variableJoystickCamera;
    void Start()
    {
        //mainCamera = Camera.main.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        //lockOnTargetDetector = player.GetComponentInChildren<LockOnTargetDetector>();
    }

    void Update()
    {


        transform.position = player.transform.position;



        //if (Input.GetKeyDown(KeyCode.R))
        //{

        //        var target = player.GetComponent<PlayerScr>().m_rockOnEnemy.gameObject;

        //    //if (target != null)
        //    //{
        //    //    lockOnTarget = target;
        //    //}
        //    //else
        //    //{
        //    //    lockOnTarget = null;
        //    //}
        //}

        if (player.GetComponent<PlayerScr>().m_rockOnEnemy != null)
        {
            lockOnTargetObject(player.GetComponent<PlayerScr>().m_rockOnEnemy.gameObject);
        }
        else
        {
            //if (Input.GetMouseButton(ROTATE_BUTTON))
            //{
            rotateCmaeraAngle();
            // }
        }


        //rotateCmaeraAngle();

        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;

        var saveClamoEuler = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, saveClamoEuler, 1f);

        transform.eulerAngles = saveClamoEuler;
    }

    private void lockOnTargetObject(GameObject target)
    {
        //transform.LookAt(target.transform, Vector3.up);

        var eDir = target.transform.position - transform.position;

        var elookAtRotation = Quaternion.LookRotation(eDir, Vector3.up);

        const float INTERPOLANT = 5f;
        transform.rotation = Quaternion.Lerp(transform.rotation, elookAtRotation, Time.deltaTime * INTERPOLANT);
    }

    private void rotateCmaeraAngle()
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
        //m_variableJoystick.gameObject.SetActive(true);
#elif UNITY_EDITOR_WIN
        angle = new Vector3(
            Input.GetAxis("Mouse X") * rotate_speed,
            Input.GetAxis("Mouse Y") * rotate_speed,
            0
        );

        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(angle.y, angle.x), 1f);
#else

#endif
        angle = new Vector3(
            Input.GetAxis("Mouse X") * rotate_speed,
            Input.GetAxis("Mouse Y") * rotate_speed,
            0
        );
        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }
}


 */