using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerSupply : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DisplayAmperage;
    [SerializeField] private Slider SliderAmperage;
    [SerializeField] private Toggle ToggleIsActive;

    [Range(0.0f, 0.6f)] private float Amperage = 0f; // сила тока (I)
    private float StrengthMagneticField = 0f; // напряженность магнитного поля (H0)
    public float MagnetizationFerrite = 0f; // намагниченность феррита (M0)

    private const float MagnetizationFerriteSaturation = 50000f;
    private const float StrengthMagneticFieldSaturation = 2000f;
    private const float CountTurns = 1500f; //количество витков (n)
    private const float LengthCoil = 0.14f; // длина катушки (L)
    private const float DiameterCoil = 0.03f; // диаметр катушки (D)

    private void Update()
    {
        if (ToggleIsActive.isOn)
        {
            Amperage = SliderAmperage.value;
            DisplayAmperage.text = Amperage.ToString() + " А";
            CalculateStrengthMagneticField();
            CalculateMagnetizationFerrite();
        }
        else
        {
            DisplayAmperage.text = "";
            Amperage = 0f;
            CalculateStrengthMagneticField();
            CalculateMagnetizationFerrite();
        }
    }
    private void CalculateStrengthMagneticField()
    {
        StrengthMagneticField = (CountTurns * Amperage) / (Mathf.Sqrt(Mathf.Pow(LengthCoil, 2) + Mathf.Pow(DiameterCoil, 2)));
    }

    private void CalculateMagnetizationFerrite()
    {
        MagnetizationFerrite = MagnetizationFerriteSaturation * (1 - Mathf.Exp(-1 * StrengthMagneticField / StrengthMagneticFieldSaturation));
    }
}
