using TMPro;
using UnityEngine;

public class MeasuringAmplifier : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI OutputDisplayVoltage;
    [SerializeField] private MicrowaveGenerator MicrowaveGenerator;
    [SerializeField] private PyramidalHorn PyramidalHorn;
    [SerializeField] private TMP_InputField DisplayMultiplaySignal;

    private const float MaxVoltage = 100f;

    private float Voltage = 0f;
    private float MultiplierSignal = 1f;
    private bool isActive = true;

    private void Update()
    {
        if (isActive)
        {
            CalculateVoltage();
            if (float.TryParse(DisplayMultiplaySignal.text, out float ParseMultiplierSignal))
            {
                MultiplierSignal = ParseMultiplierSignal;
                OutputDisplayVoltage.text = (Voltage * MultiplierSignal * Mathf.Pow(10, MicrowaveGenerator.OutputPower / 10)).ToString();
            }
        }

        else
        {
            Voltage = 0;
        }
    }

    private void CalculateVoltage()
    {
        Voltage = MaxVoltage * Mathf.Pow(Mathf.Cos(Mathf.Deg2Rad * (PyramidalHorn.AngleRotate - MicrowaveGenerator.AnglePolarization)), 2);
    }
}
