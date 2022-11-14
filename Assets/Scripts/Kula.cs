using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kula : MonoBehaviour
{
    public Camera camera;
    public float speed;
    public bool jump = false;
    public FixedJoystick joystick;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        SetCamera();
        Move();
    }
    private void Move()
    {
        if (joystick.Vertical != 0)
        {
            this.GetComponent<Rigidbody>().AddTorque(joystick.Vertical*speed, 0f, 0f);
            
        }
        if (joystick.Horizontal != 0)
        {
            this.GetComponent<Rigidbody>().AddTorque(0f, 0f, joystick.Horizontal * -speed);
        }

    }
    public void Jumping(){
        if(jump == false)StartCoroutine(Jump());
    }
    private IEnumerator Jump()
    {
        if(jump == false)
        {
            this.GetComponent<Rigidbody>().AddForce(0f, 500f, 0f);
            jump = true;
            yield return new WaitForSeconds(1);
        }
        if(jump == true)
        {
            jump = false;
            yield return new WaitForSeconds(1);
        }
    }
    public void SetCamera()
    {
        Camera main = camera;
        main.transform.position = this.transform.position + new Vector3(-0f, 3.47f, -3.47f);
    }
    
}
