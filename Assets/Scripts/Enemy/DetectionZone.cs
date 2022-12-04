using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public string tagPlayer = "Player";
    public List<Collider2D> detectedObjs = new List<Collider2D>();
    public Collider2D coll;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == tagPlayer)
        {
            detectedObjs.Add(other);
        }
        
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == tagPlayer)
        {
            detectedObjs.Remove(other);
        }
    }
}
