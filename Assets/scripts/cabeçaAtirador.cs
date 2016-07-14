using UnityEngine;
using System.Collections;

public class cabeçaAtirador : MonoBehaviour {
	public float intervaloAtaque;
	private float contagemIntervalo;
	private bool atacou;
	public float distanciaAtaque;
	
	public GameObject ataque;
	public GameObject player;
	
	private Animator animator;

	void Start () {
		animator = gameObject.transform.GetComponent<Animator> ();
		transform.localScale = new Vector3 (-1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		var distancia = (player.transform.position.x - transform.position.x);
		if (distancia > 0) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}

		if (!atacou && Mathf.Abs(distancia) <= distanciaAtaque) {
			//animator.SetTrigger("atacou");
			Instantiate(ataque, transform.position, transform.rotation);
			atacou = true;
		}
		if (atacou) {
			contagemIntervalo += Time.deltaTime;
			if (contagemIntervalo >= intervaloAtaque) {
				atacou = false;
				contagemIntervalo = 0;
			}
		}
	}

	public void morreu(){
		Destroy(gameObject);
	}
}
