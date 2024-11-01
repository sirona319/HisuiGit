using UnityEngine;

public abstract class BaseMove : MonoBehaviour
{


    protected Rigidbody m_rb;

    public virtual void Initialize()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    public abstract void MoveEnter();

    public abstract void MoveUpdate();
}
