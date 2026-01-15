using UnityEngine;
using UnityEngine.UI;

public class HidingWires : MonoBehaviour
{
    [SerializeField] Toggle ToggleReverse;
    [SerializeField] MeshRenderer WireMicrowaveGeneratorToSircle;
    [SerializeField] MeshRenderer WireMeasuringAmplifierToPyramid;
    [SerializeField] MeshRenderer WireMicrowaveGeneratorToPyramid;
    [SerializeField] MeshRenderer WireMeasuringAmplifierToSircle;
    
    private void Update()
    {
        if (ToggleReverse.isOn)
        {
            WireMicrowaveGeneratorToSircle.enabled = false;
            WireMeasuringAmplifierToPyramid.enabled = false;
            WireMicrowaveGeneratorToPyramid.enabled = true;
            WireMeasuringAmplifierToSircle.enabled = true;
        }
        else
        {
            WireMicrowaveGeneratorToSircle.enabled = true;
            WireMeasuringAmplifierToPyramid.enabled = true;
            WireMicrowaveGeneratorToPyramid.enabled = false;
            WireMeasuringAmplifierToSircle.enabled = false;
        }
    }
}
