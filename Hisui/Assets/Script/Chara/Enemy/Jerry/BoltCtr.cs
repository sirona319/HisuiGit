using DigitalRuby.LightningBolt;
using UnityEngine;


//AI
//https://taira-komori.net/quick/quick.cgi?mode=find&word=%93d%8BC   音声　電気
public class BoltCtr : MonoBehaviour
{

    LightningBoltScript blt;

    private BoxCollider2D col;

    [SerializeField] float thickness = 0.5f;// ColliderのサイズY

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();

        blt = GetComponent<LightningBoltScript>();
    }

    void Update()
    {

        Vector2 start = blt.StartObject.transform.position;
        Vector2 end = blt.EndObject.transform.position;

        Vector2 direction = end - start;

        // 2点間の距離
        float distance = direction.magnitude;

        // 中心位置
        transform.position = (start + end) / 2f;

        // 回転角
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // Colliderのサイズ
        col.size = new Vector2(distance, thickness);
        col.offset = Vector2.zero;
    }


}
