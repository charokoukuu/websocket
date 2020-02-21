using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using UnityEngine.UI;

public class ClientExample : MonoBehaviour
{
    public GameObject X;
    public GameObject Y;
    public GameObject Z;
    WebSocket ws;

        int i = 0;
    void Start()
    {
        ws = new WebSocket("ws://192.168.0.15:3000/");

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
        X.GetComponent<Text>().text = "X: " + Input.acceleration.x.ToString("F2");
        Y.GetComponent<Text>().text = "Y: " + Input.acceleration.y.ToString("F2");
        Z.GetComponent<Text>().text = "Z: " + Input.acceleration.z.ToString("F2");
        ws.Send(Input.acceleration.x.ToString("F2")+","+ Input.acceleration.y.ToString("F2"));


    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }
}