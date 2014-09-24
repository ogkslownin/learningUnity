using UnityEngine;
using System.Collections;

public class PhysXFreeFallController : MonoBehaviour {

	public GameObject resetTarget;
	private Vector3 targetDefaultPosition;
	void Awake(){
		if(this.resetTarget != null){
			this.targetDefaultPosition = this.resetTarget.transform.localPosition;
		}
	}

	void OnEnable(){
		this.resetTarget.transform.localPosition = this.targetDefaultPosition;
		this.resetTarget.GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
