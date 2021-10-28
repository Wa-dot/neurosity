using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimantScript : MonoBehaviour
{
    public GameObject[] aimantsneg;
    public float tesla = 10;
    public float maxDistance = 10;
    private float actualDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aimantsneg = GameObject.FindGameObjectsWithTag("Aimantneg");
        foreach(GameObject aimantneg in aimantsneg)
        {
            actualDistance = Vector3.Distance(aimantneg.transform.position, transform.position);
            if(actualDistance<= maxDistance)
            {
                aimantneg.GetComponent<Rigidbody>().AddForce((transform.position- aimantneg.transform.position) *tesla*Time.smoothDeltaTime);
            }
        }
    }
}
