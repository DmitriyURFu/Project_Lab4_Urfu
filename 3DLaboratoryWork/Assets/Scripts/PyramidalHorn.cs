using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PyramidalHorn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DisplayAngleRotate;
    [SerializeField] private Slider SliderAngleRotate;

    public float AngleRotate = 0f; // угол поворота пирамидальной рупорной антенны

    private void Update()
    {
        AngleRotate = SliderAngleRotate.value;
        DisplayAngleRotate.text = AngleRotate.ToString() + '°';
    }
}
