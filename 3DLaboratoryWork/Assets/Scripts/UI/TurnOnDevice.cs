using UnityEngine;
using UnityEngine.UI;

public class TurnOnDevice : MonoBehaviour
{
    [SerializeField] private Renderer lampRenderer;
    [SerializeField] private Toggle toggleDevice;
    [SerializeField] private Material materialOn;
    [SerializeField] private Material materialOff;

    private void Update()
    {
        if (toggleDevice.isOn)
            lampRenderer.material = materialOn;
        else
            lampRenderer.material = materialOff;
    }
}
