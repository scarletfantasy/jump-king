using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, 0.8f*player.transform.position.y+2, 1);
    }
}
