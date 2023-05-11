using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PortalWorking : MonoBehaviour
{
    public GameObject otherPortal;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (this.gameObject.CompareTag("ToLeftPortal"))
        {
            collider.gameObject.transform.position = new Vector2(otherPortal.transform.position.x - 0.55f, otherPortal.transform.position.y);
        }
        else if (this.gameObject.CompareTag("ToRightPortal"))
        {
            collider.gameObject.transform.position = new Vector2(otherPortal.transform.position.x + 0.55f, otherPortal.transform.position.y);
        }
    }
}
