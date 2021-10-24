using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UINetworkRefresher : MonoBehaviour
{
    private List<UICell> recommendedCells;
    private List<UICell> uiCells;

    public float updateFrequency;
    private float updateCounter;

    private string getResponse;

    private void Awake() {
        updateCounter = 2f;
    }

    private void Start() {
        uiCells = new List<UICell>(gameObject.GetComponentsInChildren<UICell>());
        for (int i = 0; i < uiCells.Count; i++) {
            ///uiCells[i].SetNewModel(LocalModelDB.instance.models[i % LocalModelDB.instance.models.Count]);
        }
    }

    public void setModel(int cellNumber, Model model) {  //redundant
        uiCells[cellNumber].SetNewModel(model);
    }

    private void Update() {
        updateCounter -= Time.deltaTime;
        if (updateCounter <= 0) {
            StartCoroutine(GetRequest("http://10.0.0.249:3000/"));
            updateCounter = 1 / updateFrequency;
        }
    }

    public void UpdateNwt() {
        StartCoroutine(GetRequest("http://10.0.0.249:3000/"));
    }

    IEnumerator GetRequest(string uri) {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();
        Debug.Log("seeeeeeeeeeeeeeeeeeeeeeeeeeeeeeent");

        if (uwr.isNetworkError) {
            Debug.Log("Error While Sending: " + uwr.error);
        } else {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            getResponse = uwr.downloadHandler.text;
            string[] data = getResponse.Split(' ');
            //int[] indeces = System.ArraySelect(p => int.Parse(p)).ToArray();
            int[] myInts = System.Array.ConvertAll(data, s => int.Parse(s));
            for (int i = 0; i < uiCells.Count; i++) {
                uiCells[i].SetNewModel(LocalModelDB.instance.models[myInts[i]]);
            }
        }
    }
}
