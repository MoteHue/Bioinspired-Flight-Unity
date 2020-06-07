using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{

    public PlayerController playerController;
    public Slider slider; 

    public void OnBeginDrag(PointerEventData data) {
        playerController.NotifySliderIsHeld();
    }

    public void OnEndDrag(PointerEventData data) {
        slider.value = 0f;
        playerController.NotifySliderReleased();
    }

}