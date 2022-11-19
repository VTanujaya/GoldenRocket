using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject obst;
    private Vector3 spawnPos = new Vector3(35, 0, 0);
    private float startDelay = 2;

    private control control;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnObst", startDelay, repeatRate);
        control = GameObject.Find("Player").GetComponent<control>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void spawnObst()
    {
        if (control.gameOver == false)
        {
            Instantiate(obst, spawnPos, obst.transform.rotation);
        }
    }
}
