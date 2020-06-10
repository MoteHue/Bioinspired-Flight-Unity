using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour, IEndDragHandler
{

    public Slider slider; 

    public void OnEndDrag(PointerEventData data) {
        slider.value = -1f;
    }

}