using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevels : MonoBehaviour
{
    public GameObject[] levels;
    private float[] spacing = { 20f, 40f, 20f, 50f, 40f};
    private float[] width = { 46.28f, 42.648f, 230f, 67.165f, 65.1659f };
    private float z = 0;
    private float prev = 0;
    // Start is called before the first frame update
    void Start()
    {
        Generates();
    }
    public void Generate(int index)
    {
        GameObject level = Instantiate(levels[index]);
        z += prev + spacing[index];
        level.transform.position = new Vector3(0f, 0f, z);
        prev = width[index];
    }
    public void Generates()
    {
        for (int i = 0; i <= 10; i++)
        {
            int j = Random.Range(0, 4);
            Generate(j);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
