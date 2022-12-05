using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageHealth : MonoBehaviour
{
    public TextMeshPro textMesh;
    public float timeToDisplay = 0.5f;
    public float floatSpeed;
    public Vector3 floatDirection = new Vector3(0,1,0);
    RectTransform rectTransform;
    float timeElapsed = 0.0f;
    private void Start() {
        textMesh = GetComponent<TextMeshPro>();
        rectTransform = GetComponent<RectTransform>();
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.position += floatDirection * floatSpeed * Time.deltaTime;

        if(timeElapsed > timeToDisplay)
        {
            Destroy(gameObject);
        }
    }
}
