using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PickupCarrot : MonoBehaviour
{
    public Text countText;

    private int count;

    // Use this for initialization
    void Start()
    {
        count = 0;
        SetCountText(count);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            count = count + 1;
            SetCountText(count);
        }
    }

    void SetCountText(int num)
    {
        countText.text = "X " + num.ToString();
    }
}
