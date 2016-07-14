using UnityEngine;
using System.Collections;

public class BOSS : MonoBehaviour {
	public float velocidade;
	public bool direcao;
	public float duracaoDirecao;
	private float tempoNaDirecao;
	private Animator animator;
	public GameObject player;
	// Use this for initialization
	void Start () {
		animator = gameObject.transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		var distancia = (player.transform.position.x - transform.position.x);
		if (distancia > 0) {
			transform.eulerAngles = new Vector2(0, 0);
		} else {
			transform.eulerAngles = new Vector2(0, 180);
		}
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);

		if (distancia > 10){
			animator.SetBool("Atack", true);
		}
	}
}
