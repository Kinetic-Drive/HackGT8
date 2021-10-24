using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class SelectInterfaceController : MonoBehaviour
{
    [Header("Parameters")]
    public float scrollSensitivity = 1f;
    public float maxScrollVelocity = 5f;
    [Header("Internal References")]
    public ScrollRect scrollRect;
    public Transform itemContent;
    private float horizontalNormPosition;
    private float verticalNormPosition;

    private InputDevice targetDevice;
    private float scrollVelocity;
    public InputDeviceCharacteristics deviceCharacteristics;

    
    // Start is called before the first frame update
    void Start()
    {
        horizontalNormPosition = scrollRect.horizontalNormalizedPosition;
        verticalNormPosition = scrollRect.verticalNormalizedPosition;

        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(deviceCharacteristics, inputDevices);

        //Debug.Log("devices: " + inputDevices.Count);
        if (inputDevices.Count > 0) {
            targetDevice = inputDevices[0];
        } else {
            Debug.LogWarning("Controller not found!");
            targetDevice = inputDevices[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 vector)) {
            if (Mathf.Abs(vector.y) > 0.2) {
                if (true) {
                    scrollVelocity += scrollSensitivity * vector.y;
                }
            } else {
                if (Mathf.Abs(scrollVelocity) < 30) {
                    scrollVelocity = 0;
                } else {
                    scrollVelocity -= Mathf.Sign(scrollVelocity) * 20;
                }
            }
        } else {
            if (Mathf.Abs(scrollVelocity) < 30) {
                scrollVelocity = 0;
            } else {
                scrollVelocity -= Mathf.Sign(scrollVelocity) * 20;
            }
        }
        //Debug.Log("scroll velocity: " + scrollVelocity);

        //Debug.Log("real velocity: " + scrollRect.velocity);
        //Debug.Log("vertical PosSTR: " + (float) (scrollRect.verticalNormalizedPosition + scrollVelocity * Time.deltaTime));
        scrollRect.velocity = new Vector2(0f, scrollVelocity);
        //Debug.Log("real velocity2: " + scrollRect.velocity);
        //scrollRect.verticalNormalizedPosition = (float) Mathf.Clamp(scrollRect.verticalNormalizedPosition, 0, 1);
        //Debug.Log("vertical Pos2: " + scrollRect.verticalNormalizedPosition);
        Canvas.ForceUpdateCanvases();
    }
}
