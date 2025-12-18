using TMPro;
using UnityEngine;

public class PowerSupply : MonoBehaviour
{
    [SerializeField] private TMP_InputField DisplayAmperage;

    [Range(0.0f, 0.6f)] private float Amperage = 0f; // сила тока (I)
    private float StrengthMagneticField = 0f; // напряженность магнитного поля (H0)
    private bool isActive = true; // флаг включения прибора
    public float MagnetizationFerrite = 0f; // намагниченность феррита (M0)

    private const float MagnetizationFerriteSaturation = 50000f;
    private const float StrengthMagneticFieldSaturation = 2000f;
    private const float CountTurns = 1500f; //количество витков (n)
    private const float LengthCoil = 0.14f; // длина катушки (L)
    private const float DiameterCoil = 0.03f; // диаметр катушки (D)

    private void Update()
    {
        if (isActive)
        {
            if (float.TryParse(DisplayAmperage.text, out float ParseAmperage))
                Amperage = ParseAmperage;
            CalculateStrengthMagneticField();
            CalculateMagnetizationFerrite();
        }
        else
        {
            Amperage = 0f;
            StrengthMagneticField = 0f;
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
