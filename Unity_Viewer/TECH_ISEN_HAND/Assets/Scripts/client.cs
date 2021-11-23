using UnityEngine;
using WebSocketSharp;
public class client : MonoBehaviour
{
    WebSocket ws;
    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            if (e.Data == "NG_accepted") PlayerMotor.wsG = true;
        };
    }
    private void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetButtonDown("Jump"))
        {
            ws.Send("NG");
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            ws.Send("bye");
        }
    }
}