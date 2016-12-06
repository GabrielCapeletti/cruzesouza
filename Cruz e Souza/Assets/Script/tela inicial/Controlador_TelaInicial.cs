using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Controlador_TelaInicial :  MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
//	PointerEventData pe = new PointerEventData(EventSystem.current);

	public AudioSource source;
	public AudioClip som_hover_bt;
	Vector3 normal = new Vector3(1,1,1);
	Vector3 hover = new Vector3(1.5f,1,1);
	public string bt;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		if (isOver) {
			
			transform.localScale = hover;
		} else {
			transform.localScale = normal;
		}

	}

	public bool isOver = false;

	public void OnPointerEnter(PointerEventData eventData)
	{
		source.PlayOneShot (som_hover_bt, 1);
		Debug.Log("Mouse enter");
		isOver = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("Mouse exit");
		isOver = false;
	}

	public void mudaTela(){
		if (bt == "jogar") {
			Application.LoadLevel (2);
		}
		if (bt == "pat") {
			Application.LoadLevel (0);
		}
		if (bt == "cred") {
			Application.LoadLevel (0);
		}
		if (bt == "sair") {
			//SAIR DO JOGO
		}
	}
}
