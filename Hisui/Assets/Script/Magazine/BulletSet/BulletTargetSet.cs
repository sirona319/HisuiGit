using UnityEngine;
using static CreateBullet;

public class BulletTargetSet : MonoBehaviour
{
    public enum BulletTarget
    {
        Player,
        LeftMiddle,
        Up,
        Right,
        Left,
        Down,

        Target,
        TargetVec
        //斜め　四つ　
        //一番近いエネミーなど？　遠い敵　レーザー


    }

    //[SerializeField] Transform stayTarget;
    //[SerializeField] Vector3 DEBUGstayPos = Vector3.zero;

    [SerializeField] Transform playerTarget;

    [SerializeField] string targetName="Target";
    //[SerializeField] string targetVecName;

    private void Start()
    {
        //stayTarget = transform;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public Transform TargetSet(Transform t, BulletTarget bulletTarget)
    {
        //if (t == null) return null;

        //一番近いエネミーなど？　遠い敵　レーザー武器用など（Player）
        //Instanteiateで生成することで子階層から外す　座標ずれを防ぐため
        switch (bulletTarget)
        {
            case BulletTarget.Player:
                t = playerTarget;
                break;
            case BulletTarget.LeftMiddle://固定
                //it.Target = leftMiddle;
                t = GameObject.Find("LeftMiddle").transform;
                break;
            case BulletTarget.Up:
                t = transform.Find(targetName).gameObject.transform;
                t.position = transform.position + Vector3.up;
                break;
            case BulletTarget.Down:
                t = transform.Find(targetName).gameObject.transform;
                t.position = transform.position + Vector3.down;
                break;
            case BulletTarget.Right:
                t = transform.Find(targetName).gameObject.transform;
                t.position = transform.position + Vector3.right;
                break;
            case BulletTarget.Left:
                t = transform.Find(targetName).gameObject.transform;
                t.position = transform.position + Vector3.left;
                break;

            case BulletTarget.Target:
                t = transform.Find(targetName).transform;
                break;
            case BulletTarget.TargetVec://固定
                var go = (GameObject)Resources.Load("prefab/Bullet/TargetVecObject");
                var obj = Instantiate(go, transform.Find(targetName).transform.position, transform.rotation);

                obj.GetComponent<SetLinkObj>().linkObj = gameObject;
                t = obj.transform;
                break;
                //case BulletTarget.TargetVec://固定
                //    var child = transform.Find("TargetVec").transform;
                //    stayTarget = child;
                //    stayTarget.position = child.parent.TransformPoint(child.position);
                //    t = stayTarget.transform;

                //case BulletTarget.TargetVec://固定
                //    stayTarget = transform.Find("TargetVec").transform;
                //    t = stayTarget.transform;
                //break;
            default:
                Debug.Log("ターゲット未設定");
                break;
        }

        return t;

    }


}
