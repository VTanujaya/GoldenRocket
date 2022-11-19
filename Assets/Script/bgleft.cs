using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgleft : MonoBehaviour
{
    private Vector3 start;
    private float speed = 5;
    private float repeatWidth;
    // Start is called before the first frame updates
    void Start()
    {
        start = transform.position; 
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < start.x - repeatWidth)
        {
            transform.position = start;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
