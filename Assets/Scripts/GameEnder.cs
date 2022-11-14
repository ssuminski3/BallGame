using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Cube")
            SceneManager.LoadScene("SampleScene");
        else
            Destroy(other);
    }
    void OnCollisionEnter(Collision col)
    {
       SceneManager.LoadScene("SampleScene");
    }
}
