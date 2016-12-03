using UnityEngine;
using System.Collections;

public class Control_cena : MonoBehaviour {


	public void mudaFase(string nome){
		Application.LoadLevel (nome);
	}
}
