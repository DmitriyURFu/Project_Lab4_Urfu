using TMPro;
using UnityEngine;

public class PyramidalHorn : MonoBehaviour
{
    [SerializeField] private TMP_InputField DisplayAngleRotate;

    public float AngleRotate = 0f; // угол поворота пирамидальной рупорной антенны

    private void Update()
    {
        if (float.TryParse(DisplayAngleRotate.text, out float ParseAngleRotate))
        {
            AngleRotate = ParseAngleRotate;
        }
        else
        {
            AngleRotate = 0f;
        }
    }
}
