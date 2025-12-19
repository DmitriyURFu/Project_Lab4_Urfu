using UnityEngine;
using UnityEngine.UI;

public class StepSlider : MonoBehaviour
{
    [SerializeField] private float step;
    [SerializeField] private Slider slider;

    void Start()
    {
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        float steppedValue = Mathf.Round(value / step) * step;
        if (slider.value != steppedValue)
            slider.value = steppedValue;
    }
}
