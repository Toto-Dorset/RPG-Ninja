using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChicken : MonoBehaviour
{
    Vector2 right = new Vector2(5,0);
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
