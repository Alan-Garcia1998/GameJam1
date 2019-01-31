using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlls : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private float spin = 1;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        // transform.Rotate(new Vector3(40, 0, 0));

    }



    // Update is called once per frame
    void Update()
    {
        /*
         if (Input.GetKey("e"))
         {
             transform.Rotate(new Vector3(0, 0 + spin, 0 ));

         }
         if (Input.GetKey("q"))
         {
             transform.Rotate(new Vector3(0, 0 - spin, 0));
         }
         */
    }
}