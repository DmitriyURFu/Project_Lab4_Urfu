using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MeasuringAmplifier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI OutputDisplayVoltage;
    [SerializeField] private MicrowaveGenerator MicrowaveGenerator;
    [SerializeField] private PyramidalHorn PyramidalHorn;
    [SerializeField] private TextMeshProUGUI DisplayMultiplaySignal;
    [SerializeField] private Slider SliderMultiplaySignal;
    [SerializeField] private Toggle ToggleIsActive;
    [SerializeField] private Slider SliderZeroLevel;
    [SerializeField] private Toggle isReverseMode;
    [SerializeField] private Toggle isZeroLevelOn;

    private const float MaxVoltage = 100f;
    private const float MinVoltage = 4f;

    private float Voltage = 0f;
    private float ZeroLevel = 0f;
    private float DividerSignal = 1f;

    private void Update()
    {
        if (ToggleIsActive.isOn)
        {
            if (isZeroLevelOn.isOn)
                ZeroLevel = SliderZeroLevel.value;
            DividerSignal = Mathf.Pow(10, SliderMultiplaySignal.value);
            DisplayMultiplaySignal.text = "x" + DividerSignal.ToString();
        }

        if (MicrowaveGenerator.ToggleIsActive.isOn && ToggleIsActive.isOn)
        {
            CalculateVoltage();
            OutputDisplayVoltage.text = (Voltage * (1/DividerSignal) * Mathf.Pow(10, MicrowaveGenerator.OutputPower / 10) * 1000).ToString() + " Â";
        }

        if (!ToggleIsActive.isOn)
        {
            DisplayMultiplaySignal.text = "";
            DividerSignal = 1f;
            OutputDisplayVoltage.text = "";
            Voltage = 0;
        }

        if (!MicrowaveGenerator.ToggleIsActive.isOn)
        {
            OutputDisplayVoltage.text = "";
            Voltage = 0;
        }
    }

    private void CalculateVoltage()
    {
        var effectiveAnglePolarization = 0f;
        if (isReverseMode.isOn)
            effectiveAnglePolarization = 2f * MicrowaveGenerator.AnglePolarization;
        else
            effectiveAnglePolarization = MicrowaveGenerator.AnglePolarization;
        Voltage = MaxVoltage * Mathf.Pow(Mathf.Sin(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - effectiveAnglePolarization)), 2) +
                  MinVoltage * Mathf.Pow(Mathf.Cos(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - effectiveAnglePolarization)), 2) - ZeroLevel;
    }
}
