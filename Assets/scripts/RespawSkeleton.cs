using UnityEngine;
using System.Collections;

public class RespawSkeleton : MonoBehaviour {

	public GameObject objeto;
	public float tempoRespawn = 0f;
	private float tempoCorrido = 0f;
	//vidaUnidade
	private int vidaAtual;

	
	// Use this for initialization
	void Start () {
		vidaAtual = 100;
		for (int i=1; i <= 5; i++) {
			Instantiate(objeto, transform.position, objeto.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		tempoCorrido += Time.deltaTime;
		if (tempoCorrido >= tempoRespawn) {
			Instantiate(objeto, transform.position, objeto.transform.rotation);
			tempoCorrido = 0f;
		}
	}
	
	public void PerdeVida(int dano) {
		vidaAtual -= dano;
		
		if (vidaAtual <= 0) {
			Destroy(gameObject);
		} 

	}

}
