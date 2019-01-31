using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    public Transform preFabToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                float xpos = transform.position.x + i * 5;
                float zpos = transform.position.z + j * 5;
                Object instanceObj = Instantiate(preFabToSpawn, new Vector3(7.0f, 0.85f, 100f), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}