using UnityEngine;
using System.Collections;

public class Emmitter : MonoBehaviour {

	public float EmmittTimeSpan;
	public GameObject EmmittTarget;
	private bool isEmmitt = false;
	public float lifeTime = 2f;
	public Vector3 emmittedScale = new Vector3(0.3f, 0.3f, 0.3f);

	void OnEnable(){
		this.isEmmitt = true;
		StartCoroutine(this.Emmitt());
	}
	void OnDisable(){
		this.isEmmitt = false;
	}

	IEnumerator Emmitt(){
		yield return null;
		while( this.isEmmitt ){
			yield return new WaitForSeconds(this.EmmittTimeSpan);
			var a = Instantiate(EmmittTarget) as GameObject;
			a.transform.position = this.transform.position;
			a.transform.localScale = this.emmittedScale;
			Destroy(a, this.lifeTime);
			var r = a.GetComponent<Rigidbody>();
			r.AddForce(Vector3.up * Random.Range(1,10) );
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
