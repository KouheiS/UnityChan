using UnityEngine;
using System.Collections;

public class BoxDestroy : MonoBehaviour {
	void OnTriggerEnter (Collider col){
		Destroy (gameObject, 1.0f);
	}
}
