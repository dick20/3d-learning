using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        this.transform.RotateAround(this.transform.position, Vector3.up, 2);
    }
}
