using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	private Transform player;
	private float menor = 99999;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 novaPosicao = new Vector3 (player.position.x, player.position.y + 1.19f, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.timeSinceLevelLoad);
	}
	
	// Update is called once per frame
	void Update () {

		if (player.position.y < 0) {
			Vector3 novaPosicao1 = new Vector3 (player.position.x, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, novaPosicao1, Time.timeSinceLevelLoad);

			if(menor > player.position.y){
				Vector3 novaPosicaoExecao = new Vector3 (player.position.x, player.position.y + 1.19f, transform.position.z);
				transform.position = Vector3.Lerp (transform.position, novaPosicaoExecao, Time.timeSinceLevelLoad);
				menor = player.position.y;
			}
		} else{
			Vector3 novaPosicao2 = new Vector3 (player.position.x, transform.position.y, transform.position.z);
			transform.position = Vector3.Lerp (transform.position, novaPosicao2, Time.timeSinceLevelLoad);

		}
	}
}

