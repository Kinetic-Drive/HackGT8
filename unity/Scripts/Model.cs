using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Model 
{
    public GameObject model3D;
    public int modelNum;
    public string name;
    public float price;
    public Image image;

    public Model(string name, GameObject model3D, float price, int modelNum, Image image) {
        this.model3D = model3D;
        this.modelNum = modelNum;
        this.price = price;
        this.name = name;
        this.image = image;
    }
}
