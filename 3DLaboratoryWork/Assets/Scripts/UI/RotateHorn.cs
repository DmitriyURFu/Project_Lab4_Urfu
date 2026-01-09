using UnityEngine;
using UnityEngine.UI;

public class RotateHorn : MonoBehaviour
{
    [SerializeField] GameObject RotateObject;
    [SerializeField] Slider Slider;

    private void Update()
    {
        if (RotateObject.name == "Рупор")
            RotateObject.transform.rotation = Quaternion.Euler(Slider.value, 0, 0);
        else
            RotateObject.transform.rotation = Quaternion.Euler(Slider.value, -90, 90);

    }
}
