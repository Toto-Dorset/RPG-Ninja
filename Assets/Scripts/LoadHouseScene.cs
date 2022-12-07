using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHouseScene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.name == "Player")
        {
            SceneManager.LoadScene("House_1");
        }
    }
}
