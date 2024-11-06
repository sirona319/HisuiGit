using UnityEngine;

public abstract class BaseMagazine : MonoBehaviour
{
    //enum BulletType
    //{
    //    normal,
    //    num,
    //}


    protected Bullet bulletObj;

    //protected float bulletSpeed = 0.02f;

    //public float bulletInterval = 0f;

    public float bulletShotTime = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //void Start()
    //{
    //    bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/EBulletNormalEX");

    //    var player = GameObject.FindGameObjectWithTag("Player");
    //    targetTrans = player.transform;
    //}

    public virtual void BulletLoad(string name)
    {
        bulletObj = MyLib.GetComponentLoad<Bullet>(name);
    }
    public abstract void Initialize();
    //{
        //bulletObj = MyLib.GetComponentLoad<Bullet>("prefab/EBulletNormalEX");
    //}

    public abstract void MagazineEnter();

    // Update is called once per frame
    public abstract void MagazineUpdate();



    


    
}
