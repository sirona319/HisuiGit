using UnityEngine;
using UnityEngine.EventSystems;

public class EscClickEvent : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] GameObject bc;

    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 1.0f;
        bc.SetActive(false);
    }


}
