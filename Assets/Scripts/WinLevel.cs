using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{
    public GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Chest"))
        {
            winScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
