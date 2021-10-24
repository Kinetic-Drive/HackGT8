using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkInterfacing : MonoBehaviour
{
    //void Start() {
    //    StartCoroutine(PutRequest("http://10.0.0.249:3000/"));
    //}

    //IEnumerator PutRequest(string url) {
    //    byte[] dataToPut = System.Text.Encoding.UTF8.GetBytes("69");
    //    UnityWebRequest uwr = UnityWebRequest.Post(url, dataToPut);
    //    print("REQUST SENT -----------------------------------------------------------------------------------------------");
    //    yield return uwr.SendWebRequest();

    //    if (uwr.isNetworkError) {
    //        Debug.Log("Error While Sending: " + uwr.error);
    //    } else {
    //        Debug.Log("Received: " + uwr.downloadHandler.text);
    //    }
    //}

    void Start() {
        //StartCoroutine(GetRequest("http://10.0.0.249:3000/"));
        //StartCoroutine(PostRequest("http://10.0.0.249:3000/"));
    }

    IEnumerator PostRequest(string url) {
        WWWForm form = new WWWForm();
        form.AddField("string", "69");
        //form.AddField("Game Name", "Mario Kart");
        Debug.Log("sent");

        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError) {
            Debug.Log("Error While Sending: " + uwr.error);
        } else {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    IEnumerator GetRequest(string uri) {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError) {
            Debug.Log("Error While Sending: " + uwr.error);
        } else {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
}
