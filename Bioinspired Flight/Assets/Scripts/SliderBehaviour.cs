using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour, IEndDragHandler
{

    public Slider slider;
    public float defaultValue;
    public void OnEndDrag(PointerEventData data) {
        slider.value = defaultValue;
    }

}