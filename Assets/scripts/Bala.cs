using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {
	private static int dano;
	public float velocidade;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 0.5f);
		transform.localScale = new Vector3 (-1, 1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * velocidade * Time.deltaTime);
	}


	void OnCollisionEnter2D(Collision2D colisor) {
		if (colisor.gameObject.tag.Equals("Inimigo")) {
			Destroy(colisor.gameObject);
		}

		if (colisor.gameObject.tag.Equals("Chefao")) {
			dano += 1;
			Destroy (gameObject);
			if(dano == 5){
				Destroy(colisor.gameObject);
			}
			Debug.Log(dano);
		}
	}
}
	