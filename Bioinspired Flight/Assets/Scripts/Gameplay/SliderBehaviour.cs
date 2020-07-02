using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour, IEndDragHandler
{

    Slider slider;
    public float defaultValue;

    private void Start() {
        slider = GetComponent<Slider>();
    }

    public void OnEndDrag(PointerEventData data) {
        slider.value = defaultValue;
    }

}