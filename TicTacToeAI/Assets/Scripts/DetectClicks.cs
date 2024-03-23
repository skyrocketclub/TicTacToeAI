using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectClicks : MonoBehaviour
{
    public GameObject xPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Quaternion desiredRotation = Quaternion.Euler(90f, 0f, 0f);
            Instantiate(xPrefab, transform.position, desiredRotation);
        }
    }
}
