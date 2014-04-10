using UnityEngine;
using System.Collections;

public class UnityChanScripts : MonoBehaviour {
	
	public Animator anim;
	public float speed = 5.0f;
	public GameObject camera;
	public GameObject Box;
	private bool flag = true;

	// Update is called once per frame
	void Update () {
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);

		if (!(state.IsName ("Base Layer.DAMAGED01") ||
		      state.IsName ("Base Layer.LOSE00") ||
		      state.IsName ("Base Layer.WIN00") ||
		      state.IsName ("Base Layer.WAIT01"))) {
						transform.position += new Vector3 (0, 0, this.speed * Time.deltaTime);
				}
		anim.SetBool ("jump", Input.GetKeyDown (KeyCode.UpArrow));
		anim.SetBool ("slide", Input.GetKeyDown (KeyCode.DownArrow));
	}
	
	void OnTriggerEnter ( Collider col )
	{
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);

		if (col.CompareTag ("Finish")) {
			anim.SetBool ("finish", true);
			CameraScripts cs = camera.GetComponent<CameraScripts>();
			if(cs!=null){
				cs.setPosition();
			} else {
				Debug.LogWarning("set Script A!");
			}
		} else if (state.IsName("Base Layer.RUN00_F") ||
		    (state.IsName("Base Layer.UMATOBI00") && col.CompareTag("Higher")) ||
		    (state.IsName("Base Layer.SLIDE00") && col.CompareTag("Lower"))) {
			//BoxDestroy bd = Box.GetComponent<BoxDestroy>();
			//bd.destroy();
			anim.SetBool ("dead", true);
		}
	}

	void OnGUI()
	{
		AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo (0);
		if (state.IsName("Base Layer.LOSE00")) {
			if ( GUI.Button(new Rect(250,30,200,80), "Again?") ) {
				Application.LoadLevel(0);
			}
		}

		if (state.IsName("Base Layer.WIN00")) {
			if ( GUI.Button(new Rect(30,200,200,80), "Play!!") ) {
				Application.LoadLevel(0);
			}
		}
	}

}



















