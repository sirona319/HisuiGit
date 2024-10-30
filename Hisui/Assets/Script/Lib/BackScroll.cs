using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�w�i�X�N���[��

public class BackScroll : MonoBehaviour
{
    private Renderer rend;

    [SerializeField]
    private float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(Time.time * m_speed, 1);
        Vector2 offset = new Vector2(x, 0);

        rend.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
