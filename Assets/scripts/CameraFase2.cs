using UnityEngine;
using System.Collections;

public class CameraFase2 : MonoBehaviour {
	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		Vector3 novaPosicao = new Vector3 (player.position.x, player.position.y + 1.19f, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao, Time.timeSinceLevelLoad);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 novaPosicao1 = new Vector3 (player.position.x, player.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, novaPosicao1, Time.timeSinceLevelLoad);
	}
}
