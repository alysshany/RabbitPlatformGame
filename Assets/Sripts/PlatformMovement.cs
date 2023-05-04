using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ways;
    private int currentWay = 0;

    [SerializeField]
    private float speed = 2f;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(ways[currentWay].transform.position, transform.position) < .1f)
        {
            currentWay++;
            if (currentWay >= ways.Length)
            {
                currentWay = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, ways[currentWay].transform.position, Time.deltaTime * speed);
    }

}
