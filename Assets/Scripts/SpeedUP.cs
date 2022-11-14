using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUP : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col != null && col.tag == "Player")
        {
            col.GetComponent<Rigidbody>().AddForce(x, y, z);
        }
    }
  
}
