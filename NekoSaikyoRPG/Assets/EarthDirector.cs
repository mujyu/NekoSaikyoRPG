using UnityEngine;
using System.Collections;

public class EarthDirector : MonoBehaviour {
    float rotateSpeed = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 1);
        if (Input.GetMouseButtonUp(0))
        {
            rotateSpeed = 20;
        }
        transform.Rotate(0, 0, rotateSpeed);
        rotateSpeed *= 0.99f;
    }
}
