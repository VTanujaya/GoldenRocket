using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    private float speed = 10;
    private float leftBound = -12;
    private control control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Player").GetComponent<control>();
    }

    // Update is called once per frame
    void Update()
    {
        bool gameOver = control.gameOver;
        if (gameOver == false)
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
