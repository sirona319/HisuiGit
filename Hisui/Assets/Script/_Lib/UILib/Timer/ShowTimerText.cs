using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTimerText : MonoBehaviour
{
    private TextMeshProUGUI m_txtTimer;
    private GameTimer m_gameTimer;
    // Start is called before the first frame update
    void Start()
    {
        m_txtTimer = GetComponent<TextMeshProUGUI>();
        m_gameTimer= gameObject.GetComponent<GameTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_txtTimer.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
            (int)m_gameTimer.CurrentTime / 60,
            (int)m_gameTimer.CurrentTime % 60,
            (int)(m_gameTimer.CurrentTime * 100) % 60);
    }
}
