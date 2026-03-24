using UnityEngine;

//https://www.youtube.com/watch?v=0LC5BgwPKOc&ab_channel=AMAGAMI%2F%E3%82%A2%E3%83%9E%E3%82%AC%E3%83%9F%E3%83%8A%E3%82%B2%E3%83%BC%E3%83%A0%E3%82%B9
public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    protected virtual bool DestroyTargetGameObject => true;

    //protected bool isDontDestroyOnLoad = true;

    public static T I { get; private set; } = null;

    /// <summary>
    /// Singleton‚ª—LŒø‚©
    /// </summary>
    public static bool IsValid()=>I!=null;

    private void Awake()
    {
        if(I==null)
        {
            I = this as T;
           // I.Init();

            //if(isDontDestroyOnLoad)
            //DontDestroyOnLoad(this.gameObject);
            return;
        }
        if(DestroyTargetGameObject)
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    //protected virtual void Init()
    //{

    //}

    private void OnDestroy()
    {
        if (I == this)
        {
            I = null;
        }
       // OnRelease();
    }

    //protected virtual void OnRelease()
    //{

    //}
}
