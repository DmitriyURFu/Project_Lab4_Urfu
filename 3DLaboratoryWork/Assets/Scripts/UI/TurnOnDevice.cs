using UnityEngine;
using UnityEngine.UI;

public class TurnOnDevice : MonoBehaviour
{
    [SerializeField] private Renderer lampRenderer;
    [SerializeField] private Toggle toggleDevice;
    [SerializeField] private Material materialOn;
    [SerializeField] private Material materialOff;
    [SerializeField] private Transform rotateObject;

    private void Update()
    {
        if (toggleDevice.isOn)
        {
            lampRenderer.material = materialOn;
            rotateObject.localRotation = Quaternion.Euler(-1.787f, 52.776f, -1.312f);
        }
        else
        {
            lampRenderer.material = materialOff;
            rotateObject.localRotation = Quaternion.Euler(1.565f, -4.118f, 0.216f);
        }
    }
}
