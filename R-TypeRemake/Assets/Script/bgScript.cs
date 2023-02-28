using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-2 * Time.deltaTime, 0);

        if(transform.position.x < -17.8)
        {
            transform.position = new Vector2(17.8f, transform.position.y);
        }
    }
}
