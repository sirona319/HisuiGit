using UnityEngine;

public class DropRandom : MonoBehaviour
{
    [SerializeField] GameObject go;

    bool isDropEnd = false;

    //確率変数など
    [SerializeField] int randNo = 1;

    private void Update()
    {
        if (!GetComponent<CharaBase>().isDead) return;
        if (isDropEnd) return;
        isDropEnd = true;

        var randHit = Random.Range(0, randNo + 1);
        if (randHit <= 0) return;
        //Debug.Log(randHit);

        Instantiate(go, transform.position, Quaternion.identity);

    }
}
