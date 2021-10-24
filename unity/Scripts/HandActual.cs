using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class HandActual : MonoBehaviour
{
    private InputDevice targetDevice;
    private GameObject spawnedModel;

    public GameObject handPrefab;
    public InputDeviceCharacteristics controllerCharacteristics;

    private Animator animator;
    void Start()
    {
        List<InputDevice> inputDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, inputDevices);

        Debug.Log("devices: " + inputDevices.Count);
        if (inputDevices.Count > 0) {
            targetDevice = inputDevices[0];
            spawnedModel = Instantiate(handPrefab, transform);
        } else {
            Debug.LogWarning("Controller not found!");
            targetDevice = inputDevices[0];
            Instantiate(handPrefab, transform);
        }

        animator = spawnedModel.GetComponent<Animator>();
    }

    void Update() {
        UpdateAnimation();
    }


    private void UpdateAnimation() {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float trigger)) {
            animator.SetFloat("Trigger", trigger);
        } else {
            animator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float grip)) {
            animator.SetFloat("Grip", grip);
        } else {
            animator.SetFloat("Grip", 0);
        }
    }
}
