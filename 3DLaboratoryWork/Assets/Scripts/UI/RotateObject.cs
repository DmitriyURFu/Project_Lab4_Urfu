using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    [SerializeField] Transform tRotateObject;
    [SerializeField] Slider Slider;

    private void Update()
    {
        switch (tRotateObject.name)
        {
            case "Рупор":
                tRotateObject.localRotation = Quaternion.Euler(0, 0, -1 * Slider.value);
                break;
            case "Ручка делителя напряжения":
                tRotateObject.localRotation = Quaternion.Euler(Slider.value * 30, 0, 0);
                break;
            case "Ручка силы тока":
                tRotateObject.localRotation = Quaternion.Euler(-0.968f, -78.955f, Slider.value * 150);
                break;
            case "Ручка установки нуля":
                tRotateObject.localRotation = Quaternion.Euler(0, 0, Slider.value * 25);
                break;
            default:
                tRotateObject.localRotation = Quaternion.Euler(0, 0, Slider.value);
                break;
        }
    }
}
