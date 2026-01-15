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
            OutputDisplayVoltage.text = Voltage.ToString("F2") + " Â";
        }

        if (MicrowaveGenerator.ToggleIsActive.isOn && ToggleIsActive.isOn)
        {
            CalculateVoltage();
            float displayedVoltage = Voltage * (1f / DividerSignal) * Mathf.Pow(10f, MicrowaveGenerator.OutputPower / 10f) * 1000f;
            if (displayedVoltage > 100f)
                OutputDisplayVoltage.text = "OVER";
            else
                OutputDisplayVoltage.text = displayedVoltage.ToString("F2") + " Â";

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
            Voltage = 0;
        }
    }

    private void CalculateVoltage()
    {
        if (float.IsNaN(MicrowaveGenerator.AnglePolarization))
            MicrowaveGenerator.AnglePolarization = 0f;
        var effectiveAnglePolarization = 0f;
        if (isReverseMode.isOn)
            effectiveAnglePolarization = 2f * MicrowaveGenerator.AnglePolarization;
        else
            effectiveAnglePolarization = MicrowaveGenerator.AnglePolarization;
        Voltage = MaxVoltage * Mathf.Pow(Mathf.Sin(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - effectiveAnglePolarization)), 2) +
                  MinVoltage * Mathf.Pow(Mathf.Cos(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - effectiveAnglePolarization)), 2) - ZeroLevel;
    }
}
