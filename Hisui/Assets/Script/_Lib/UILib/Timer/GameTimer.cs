using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float m_fTimer;
    public float CurrentTime { get { return m_fTimer; } }

    private bool m_bActive = false;


    // Start is called before the first frame update
    void Start()
    {

        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_bActive)
        {
            m_fTimer += Time.deltaTime;
        }
    }

    public void OnStart()
    {
        m_bActive = true;
    }

    public void OnStop()
    {
        m_bActive = false;
    }

    public void OnReset()
    {
        m_fTimer = 0f;
        OnStop();
    }
}
