using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class princess : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("player"))
        {
            canvas.SetActive(true);
        }
    }
}
