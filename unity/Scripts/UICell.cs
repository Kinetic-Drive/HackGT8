using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICell : MonoBehaviour
{
    public Text titleText;
    public Text priceText;
    public Image imageImg;
    public Image backgroundImg;
    public Model model;

    public Color origBackgroundColor;
    public Color colorOnSelect;

    private float counter;

    public void SetNewModel(Model model) {
        this.model = model;
        titleText.text = model.name;
        priceText.text = "$ " + model.price.ToString();
        if (model.image != null) {
            imageImg = model.image;
        }
    }

    public void Select() {
        Deselect();
        backgroundImg.color = colorOnSelect;
        BuildController.instance.selected = this;
        BuildController.instance.isModelSelected = true;
        BuildController.instance.selectedPrefabModel = Instantiate(model.model3D, BuildController.instance.targetPoint.position, model.model3D.transform.rotation);
    }

    public void Deselect() {
        if (BuildController.instance.selected != null) {
            //BuildController.instance.selected = null;
            BuildController.instance.isModelSelected = false;
            BuildController.instance.selected.backgroundImg.color = origBackgroundColor;
        }
    }

    //private void Update() {
    //    counter-= Time.deltaTime;
    //    if (counter <= 0) {
    //        counter = 2;
    //        Debug.Log(model.name + " " + model.model3D);
    //        Instantiate(model.model3D, BuildController.instance.targetPoint.position, Quaternion.identity);
    //    }
    //}

    //private void Start() {
    //    counter = 2;
    //}
}
