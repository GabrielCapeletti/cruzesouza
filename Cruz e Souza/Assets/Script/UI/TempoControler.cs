using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempoControler : MonoBehaviour {


	public Sprite sp1_1;
	public Sprite sp1_2;
	public Sprite sp1_3;
	public Sprite sp2_1;
	public Sprite sp2_2;
	public Sprite sp2_3;
	public Sprite sp3_1;
	public Sprite sp3_2;
	public Sprite sp3_3;
	public Sprite sp4_1;
	public Sprite sp4_2;
	public Sprite sp4_3;
	public Sprite sp5_1;
	public Sprite sp5_2;
	public Sprite sp5_3;
	public Sprite sp6_1;
	public Sprite sp6_2;
	public Sprite sp6_3;
	public Sprite sp7_1;
	public Sprite sp7_2;
	public Sprite sp7_3;
	public Sprite sp8_1;
	public Sprite sp8_2;
	public Sprite sp8_3;
	public Sprite sp9_1;
	public Sprite sp9_2;
	public Sprite sp9_3;
	public Sprite sp10_1;
	public Sprite sp10_2;
	public Sprite sp10_3;
	public Sprite sp11_1;
	public Sprite sp11_2;
	public Sprite sp11_3;
	public Sprite sp12_1;
	public Sprite sp12_2;
	public Sprite sp12_3;

	public float tempoTotal;
	float tempoPorSp;
	float tempoAtual = 0;

	float dt_fogo;


	// Use this for initialization
	void Start () {
		
		dt_fogo = 0;
		tempoPorSp = tempoTotal / 12;
	}
	float velocidadeAnimFogo = 0.200f;
	// Update is called once per frame
	void Update () {
		dt_fogo += Time.deltaTime;
		tempoAtual += Time.deltaTime;

		int sp = (int)(tempoAtual / tempoPorSp);		
		switch(sp){
		case 0:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp1_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp1_2;
				} else {
					GetComponent<Image> ().sprite = sp1_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
						dt_fogo = 0;
				}
			}
			break;
		case 1:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp2_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp2_2;
				} else {
					GetComponent<Image> ().sprite = sp2_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}

			break;
		case 2:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp3_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp3_2;
				} else {
					GetComponent<Image> ().sprite = sp3_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 3:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp4_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp4_2;
				} else {
					GetComponent<Image> ().sprite = sp4_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 4:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp5_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp5_2;
				} else {
					GetComponent<Image> ().sprite = sp5_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 5:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp6_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp6_2;
				} else {
					GetComponent<Image> ().sprite = sp6_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 6:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp7_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp7_2;
				} else {
					GetComponent<Image> ().sprite = sp7_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 7:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp8_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp8_2;
				} else {
					GetComponent<Image> ().sprite = sp8_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 8:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp9_1;
		} else {
			if (dt_fogo < velocidadeAnimFogo * 2) {
				GetComponent<Image> ().sprite = sp9_2;
			} else {
				GetComponent<Image> ().sprite = sp9_3;
				if(dt_fogo > velocidadeAnimFogo * 4)
				dt_fogo = 0;
			}
		}
			break;
		case 9:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp10_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp10_2;
				} else {
					GetComponent<Image> ().sprite = sp10_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}

			break;
		case 10:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp11_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp11_2;
				} else {
					GetComponent<Image> ().sprite = sp11_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}
			break;
		case 11:
			if (dt_fogo < velocidadeAnimFogo) {
				GetComponent<Image> ().sprite = sp12_1;
			} else {
				if (dt_fogo < velocidadeAnimFogo * 2) {
					GetComponent<Image> ().sprite = sp12_2;
				} else {
					GetComponent<Image> ().sprite = sp12_3;
					if(dt_fogo > velocidadeAnimFogo * 4)
					dt_fogo = 0;
				}
			}

			break;
		default:


			break;
		}
	}

	public void JogarNovamente(){
		Application.LoadLevel (0);
	}

}
