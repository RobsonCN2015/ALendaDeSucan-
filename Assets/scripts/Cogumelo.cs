using UnityEngine;
using System.Collections;

public class Cogumelo : MonoBehaviour {

	public float forcaPulo = 500f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D colisor) {
		colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
	}

}
