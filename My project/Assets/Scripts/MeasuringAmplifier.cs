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

    private const float MaxVoltage = 100f;
    private const float MinVoltage = 4f;

    private float Voltage = 0f;
    private float ZeroLevel = 0f;
    private float MultiplierSignal = 1f;

    private void Update()
    {
        if (ToggleIsActive.isOn)
        {
            ZeroLevel = SliderZeroLevel.value;
            MultiplierSignal = Mathf.Pow(10, SliderMultiplaySignal.value);
            DisplayMultiplaySignal.text = "Множитель сигнала: x" + MultiplierSignal.ToString();
        }

        if (MicrowaveGenerator.ToggleIsActive.isOn && ToggleIsActive.isOn)
        {
            CalculateVoltage();
            OutputDisplayVoltage.text = (Voltage * (1/MultiplierSignal) * Mathf.Pow(10, MicrowaveGenerator.OutputPower / 10) * 1000).ToString() + " В";
        }

        if (!ToggleIsActive.isOn)
        {
            DisplayMultiplaySignal.text = "Множитель сигнала: ";
            MultiplierSignal = 1f;
            OutputDisplayVoltage.text = "0 В";
            Voltage = 0;
        }

        if (!MicrowaveGenerator.ToggleIsActive.isOn)
        {
            OutputDisplayVoltage.text = "0 В";
            Voltage = 0;
        }
    }

    private void CalculateVoltage()
    {
        Voltage = MaxVoltage * Mathf.Pow(Mathf.Sin(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - MicrowaveGenerator.AnglePolarization)), 2) +
                  MinVoltage * Mathf.Pow(Mathf.Cos(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - MicrowaveGenerator.AnglePolarization)), 2) - ZeroLevel;
    }
}
