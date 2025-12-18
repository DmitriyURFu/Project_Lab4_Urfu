using UnityEngine;
using TMPro;

public class MicrowaveGenerator : MonoBehaviour
{
    [SerializeField] private TMP_InputField DisplayFrequency;
    [SerializeField] private TMP_InputField DisplayOutputPower;
    [SerializeField] private PowerSupply PowerSupply;

    private float Frequency = 0f; // частота магнитного пол€ (f)
    public float OutputPower = 0f; // выходна€ мощность в дЅ
    private bool isActive = true; // флаг включени€ прибора
    private float WaveNumber = 0f; // волновое число (B0)
    public float AnglePolarization = 0f; // угол пол€ризации (O)

    private const float RadiusFerriteRod = 0.003f; // радиус ферритового стержн€ (b)
    private const float RadiusWaveguide = 0.0105f; // радиус волновода (a)
    private const float GyromagneticElectronRatio = 35000f; // гиромагнитное отношение электрона (y)
    private const float LengthFerriteRod = 0.1f; // длина ферритового стержн€ (l)
    private const float SpeedOfLight = 300000000f; // скорость света в вакууме (c)

    private void Update()
    {
        if (isActive)
        {
            if (float.TryParse(DisplayFrequency.text, out float ParseFrequency))
                Frequency = ParseFrequency * 1e9f;
            if (float.TryParse(DisplayOutputPower.text, out float ParseOutputPower))
                OutputPower = ParseOutputPower;
            if (Frequency != 0)
            {
                CalculateWaveNumber();
                CalculateAnglePolarization();
            }
        }
        else
        {
            Frequency = 0f;
            OutputPower = 0f;
            WaveNumber = 0f;
            AnglePolarization = 0f;
        }
    }

    private void CalculateWaveNumber()
    {
        var lengthWave = CalculateLengthWave();
        WaveNumber = (2 * Mathf.PI / lengthWave) * Mathf.Sqrt( 1 - Mathf.Pow(lengthWave / (3.41f * RadiusWaveguide),2));
    }

    private float CalculateLengthWave()
    {
        return SpeedOfLight / Frequency;
    }

    private void CalculateAnglePolarization()
    {
        AnglePolarization = 1.05f * WaveNumber
                                  * Mathf.Pow(RadiusFerriteRod / RadiusWaveguide, 2)
                                  * (1 / Frequency)
                                  * GyromagneticElectronRatio
                                  * PowerSupply.MagnetizationFerrite
                                  * LengthFerriteRod;
    }
}
