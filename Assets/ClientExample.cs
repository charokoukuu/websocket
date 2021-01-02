using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using UnityEngine.UI;

public class ClientExample : MonoBehaviour
{
    public GameObject X;
    public GameObject Y;
    public GameObject cam;
    float rotax, rotay;
    WebSocket ws;

        int i = 0;
    void Start()
    {

        ws = new WebSocket("ws://192.168.0.129:3000/");


        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("WebSocket Message Type: " + ", Data: " + e.Data);
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
        };

        ws.Connect();

    }

    void Update()
    {

        rotax = (cam.transform.rotation.y * 10) + 6;
        rotay= ((cam.transform.rotation.x * 10) + 6)*-1 + 12;
        X.GetComponent<Text>().text = "X: " + rotax.ToString("F2");
        Y.GetComponent<Text>().text = "Y: " + rotay.ToString("F2");

        ws.Send( rotax+ "," +rotay );


    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }
}
