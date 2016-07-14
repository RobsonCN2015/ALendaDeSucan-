using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public float velocidade;
	public float forcaPulo;
	private bool estaNoChao;
	public Transform chaoVerificador;
	public Transform spritePlayer;
	private Animator animator;
	
	//Vida
	public GameObject vida;
	public int maxVida;
	private int vidaAtual;
	//Ataque
	public GameObject bala;
	
	//Tudo que ocorre quando o personagem e criado
	void Start () {
		animator = spritePlayer.GetComponent<Animator> ();
		//inverte o sprite
		transform.localScale = new Vector3 (-1, 1, 0);
		//Vida
		vidaAtual = maxVida;
		vida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
	}
	
	//Tudo que ocorre enquanto o personagem existe
	void Update () {
		Movimentacao();
		Ataque ();
	}
	
	//Responsavel pela movimentacao do personagem
	void Movimentacao() {
		
		//Seta no paramentro movimento, um valor 0 ou maior que 0. Ira ativar a condicao para mudar de animacao
		animator.SetFloat("movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));
		
		//Anda para a direita
		if (Input.GetAxisRaw("Horizontal") > 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}
		
		//Anda para a esquerda
		if (Input.GetAxisRaw("Horizontal") < 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}
		
		//Verifica se esta no chao
		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
		animator.SetBool ("chao", estaNoChao);
		
		//Responsavel pelo pulo
		if (Input.GetButtonDown("Jump") && estaNoChao) {
			GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
		}
	}
	
	public void PerdeVida(int dano) {
		vidaAtual -= dano;
		
		if (vidaAtual <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		} 
		
		if ((vidaAtual * 100 / maxVida) < 30) {
			vida.GetComponent<GUIText>().color = Color.red;
		}
		vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
	}
	public void RecuperaVida(int recupera) {
		vidaAtual += recupera;
		if (vidaAtual > maxVida) {
			vidaAtual = maxVida;
		}
		
		if ((vidaAtual * 100 / maxVida) >= 30) {
			vida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
		}
		
		vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
	}

	public void Ataque(){
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 posicaoBala = new Vector3 (transform.position.x + 0.3f, transform.position.y, 0);
			Instantiate(bala, posicaoBala, transform.rotation);

		}
	}
}
