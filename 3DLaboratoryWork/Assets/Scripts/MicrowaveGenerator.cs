using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MicrowaveGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DisplayFrequency;
    [SerializeField] private TextMeshProUGUI DisplayOutputPower;
    [SerializeField] private PowerSupply PowerSupply;
    [SerializeField] private Slider SliderFrequency;
    [SerializeField] private Slider SliderOutputPower;
    [SerializeField] public Toggle ToggleIsActive;

    private float Frequency = 0f; // частота магнитного пол€ (f)
    public float OutputPower = 0f; // выходна€ мощность в дЅ
    private float WaveNumber = 0f; // волновое число (B0)
    public float AnglePolarization = 0f; // угол пол€ризации (O)

    private const float RadiusFerriteRod = 0.003f; // радиус ферритового стержн€ (b)
    private const float RadiusWaveguide = 0.0105f; // радиус волновода (a)
    private const float GyromagneticElectronRatio = 35000f; // гиромагнитное отношение электрона (y)
    private const float LengthFerriteRod = 0.1f; // длина ферритового стержн€ (l)
    private const float SpeedOfLight = 300000000f; // скорость света в вакууме (c)

    private void Update()
    {
        if (ToggleIsActive.isOn)
        {
            Frequency = SliderFrequency.value * 1e6f;
            DisplayFrequency.text = SliderFrequency.value.ToString() + " ћ√ц";
            OutputPower = SliderOutputPower.value * -1;
            DisplayOutputPower.text = OutputPower.ToString() + " дЅ";
            CalculateWaveNumber();
            CalculateAnglePolarization();
        }
        else
        {
            DisplayFrequency.text = "";
            DisplayOutputPower.text = "";
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
        AnglePolarization = 1000  * 1.05f * WaveNumber
                                  * Mathf.Pow(RadiusFerriteRod / RadiusWaveguide, 2)
                                  * (1 / Frequency)
                                  * GyromagneticElectronRatio
                                  * PowerSupply.MagnetizationFerrite
                                  * LengthFerriteRod;
    }
}
