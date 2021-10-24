using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalModelDB : MonoBehaviour
{
    [Header ("Local DB Input")]
    public List<string> names;
    public List<float> prices;
    public List<GameObject> prefabs;
    public List<int> ids;
    public List<Image> images;
    
    [HideInInspector]
    public List<Model> models;

    public static LocalModelDB instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        models = new List<Model>();
        for (int i = 0; i < names.Count; i++) {
            models.Add(new Model(names[i], prefabs[i], prices[i], ids[i], null));
        }
    }

    public Model getModelWithNumber(int i) {
        return models[i];
    }

    public Model getRandomModel() {
        //System.Random rand = new System.Random();
        return models[(int) Random.Range(0, models.Count - 0.1f)];
    }
}
