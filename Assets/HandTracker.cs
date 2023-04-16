using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracker : MonoBehaviour
{
    public UDPReceive receiver;

    public GameObject[] handPoints;

    public bool flatHand = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = receiver.data;

        data = data.Remove(0,1);
        data = data.Remove(data.Length-1, 1);
        //print(data);
        string[] points = data.Split(",");

        if (!flatHand) {
            for (int i = 0; i < 21; i++) {
                float x = 5-float.Parse(points[i*3]) / 70;
                float y = float.Parse(points[i*3 + 1]) / 70;
                float z = float.Parse(points[i*3 + 2]) / 70;
            
                handPoints[i].transform.position = new Vector3(x,y,z);
            }
        } else {
            for (int i = 0; i < 21; i++) {
                float x = 5-float.Parse(points[i*3]) / 70;
                //float y = float.Parse(points[i*3 + 1]) / 70;
                float z = float.Parse(points[i*3 + 2]) / 70;
            
                handPoints[i].transform.localPosition = new Vector2(x,z);
            }
        }

        
    }
}
