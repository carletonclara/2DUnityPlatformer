using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignMessage : MonoBehaviour
{
    private Text message;
    public GameObject signMessage; 

    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Sign"))
        {
            //SetText();
            signMessage.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void SetText()
    {
        message.text = "Hello, this is a test";
    }
}
