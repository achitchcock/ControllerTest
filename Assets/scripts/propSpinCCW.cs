using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class propSpinCCW : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up * 1640 * Time.deltaTime);
	}
}
