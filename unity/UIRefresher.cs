using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRefresher : MonoBehaviour
{
    private List<UICell> recommendedCells;
    private List<UICell> uiCells;

    public float updateFrequency;
    private float updateCounter;

    private void Awake() {
        updateCounter = 1.5f;
    }

    private void Start() {
        uiCells = new List<UICell>(gameObject.GetComponentsInChildren<UICell>());
        for (int i = 0; i < uiCells.Count; i++) {
            uiCells[i].SetNewModel(LocalModelDB.instance.models[i % LocalModelDB.instance.models.Count]);
        }
    }

    public void setModel(int cellNumber, Model model) {  //redundant
        uiCells[cellNumber].SetNewModel(model);
    }

    private void Update() {
        //updateCounter -= Time.deltaTime;
        //if (updateCounter <= 0) {
        //    foreach(UICell uiCell in uiCells) {
        //        uiCell.SetNewModel(LocalModelDB.instance.getRandomModel());
        //    }
        //    updateCounter = 1 / updateFrequency;
        //}
    }
}
