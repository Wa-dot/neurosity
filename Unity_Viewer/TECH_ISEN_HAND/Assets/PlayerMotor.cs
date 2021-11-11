using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMotor : MonoBehaviour
{
    private float rotX;
    private float rotY;
    private float rotZ;
    public float sensibility = 5f;

    //mon rigidbody
    Rigidbody rb;
    public float Thrust = 20f;
    private bool isAttracttoG = true;
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = isAttracttoG;
    }

    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(transform.forward * Input.GetAxis("Vertical")*Thrust);
        
        transform.Translate(0,0, Input.GetAxis("Vertical") * Time.deltaTime * Thrust);
        Rotate(sensibility);
        
        if (transform.position.y < -1)
        {
            transform.position= new Vector3(0, 1, 0);
            
            transform.rotation= new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetButtonDown("Jump")){
            isAttracttoG = !isAttracttoG;
            rb.useGravity = isAttracttoG;

        }
        
    }

    void Rotate(float s)
    {
        rotX += Input.GetAxis("Mouse X") * s;
        rotY -= Input.GetAxis("Mouse Y") * s;
        rotZ -= Input.GetAxis("Horizontal") * s;
        transform.rotation = Quaternion.Euler(rotY, rotX, rotZ);
        
        
    }
    
}
