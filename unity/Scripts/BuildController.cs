using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BuildController : MonoBehaviour
{

    [Header("Parameters")]
    public UINetworkRefresher net;

    [Header("Internal References")]
    public Transform targetPoint;
    public Camera mainCamera;
    public InputDeviceCharacteristics deviceCharacteristics;

    private InputDevice targetDevice;

    public bool isModelSelected;
    public UICell selected;
    public GameObject selectedPrefabModel;

    public static BuildController instance;

    public Transform offsetVector;
    public Transform cameraRotation;

    private void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        offsetVector.position = Vector3.zero;
        offsetVector.rotation = cameraRotation.rotation;
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
    void Update() {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float trigger) && trigger > 0.5) {
            if (isModelSelected) {
                Destroy(selectedPrefabModel);
                Instantiate(selected.model.model3D, selectedPrefabModel.transform.position, selectedPrefabModel.transform.rotation);
                selectedPrefabModel = null;
                selected.Deselect();
                offsetVector.position = Vector3.zero;
                offsetVector.rotation = cameraRotation.rotation;
            }
            //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit)) {
            //    if (hit.transform.gameObject.TryGetComponent<UICell>(out UICell uiCell)) {
            //        uiCell.Select();
            //        selected = uiCell;
            //        selectedPrefabModel = uiCell.model.model3D;
            //        isModelSelected = true;
            //    }
            //    selectable.moveAgent.SetDestination(hit.point);
            //    if (UnitTable.instance.selectedAttackUnits.Count > 1) {
            //        selectable.moveAgent.stoppingDistance = 1f;
            //    } else if (UnitTable.instance.selectedAttackUnits.Count > 5) {
            //        selectable.moveAgent.stoppingDistance = 2f;
            //    }
            //}
        }
        if (isModelSelected) {
            if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 vector)) {
                offsetVector.Translate(new Vector3(vector.x, 0, vector.y) * Time.deltaTime * 2, Space.Self);
                //offsetVector = offsetVector + new Vector3(vector.x, 0, vector.y) * Time.deltaTime * 2;
            }
            selectedPrefabModel.transform.position = targetPoint.position + offsetVector.position;
            offsetVector.rotation = cameraRotation.rotation;
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripButton) && gripButton > 0.5) {
            if (isModelSelected) {
                offsetVector.position = Vector3.zero;
                Destroy(selectedPrefabModel);
                //selectedPrefabModel = null;
                selected.Deselect();
                offsetVector.rotation = cameraRotation.rotation;
            }
        }
    }
}
