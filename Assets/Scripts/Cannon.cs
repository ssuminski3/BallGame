using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cannon : MonoBehaviour
{
    private Kula ball;
    private bool loaded = false;
    public float x, y, z;
    private UnityEngine.Events.UnityAction cos;
    
   void OnTriggerEnter(Collider col)
    {
        if (col != null)
        {
            col.transform.position = this.transform.position;
            ball = col.GetComponent<Kula>();
            ball.SetCamera();
            ball.enabled = false;
            loaded = true;
            Button btn = GameObject.FindGameObjectWithTag("Button").GetComponent<Button>();
            cos = () => Shoot();
            btn.onClick.AddListener(cos);
        }
    }

    void Update()
    {
        Move();
    }
    private void Move()
    {
        FixedJoystick joystick = GameObject.FindGameObjectWithTag("GameController").GetComponent<FixedJoystick>();
        if (loaded && joystick.Horizontal != 0)
        {       
            this.transform.position += new Vector3(0.1f * joystick.Horizontal, 0f, 0f);
            ball.transform.position = this.transform.position;                      
        }
    }
    public void Shoot()
    {
        
        loaded = false;
        ball.enabled = true;
        ball.transform.position = this.transform.position + new Vector3(0f, 1f, 0f);
        ball.gameObject.GetComponent<Rigidbody>().AddForce(x, y, z);
        Button btn = GameObject.FindGameObjectWithTag("Button").GetComponent<Button>();
        btn.onClick.AddListener(() => ball.Jumping());
        btn.onClick.RemoveListener(cos);
        
    }
}
