using UnityEngine;
using System.Collections;
using WebSocketSharp;
using UnityEngine.UI;
public class client : MonoBehaviour
{
    WebSocket ws;
    public Text text;
    private string message = "Sending message...\nAnswer :"; 
    private string answer; 
    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Message Received from " + ((WebSocket)sender).Url + ", Data : " + e.Data);
            if (e.Data == "NG_accepted") PlayerMotor.wsG = true;
            answer = e.Data;
            
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
            answer = message + answer;
            StartCoroutine(Wait());
        }
        
        if (Input.GetKeyDown(KeyCode.B))
        {
            ws.Send("bye");
            answer = message + answer;
            StartCoroutine(Wait());
        }
        
        
        
    }
    IEnumerator Wait()
    {

        
        text.text = answer;
        yield return new WaitForSeconds(4);
        text.text = "waiting...";
    }
}