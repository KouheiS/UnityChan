using UnityEngine;
using System.Collections;

public class CameraScripts : MonoBehaviour {

	public GameObject unitychan;

	public void setPosition(){
		transform.rotation = Quaternion.Euler(16.11519f, 179.2496f, 0f);
		transform.position = new Vector3 (this.unitychan.transform.localPosition.x, this.unitychan.transform.localPosition.y + 1.5f, this.unitychan.transform.localPosition.z + 3f);
	}
}