using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Core;

public class TelaPretaController : MonoBehaviour {

    public Image image;
    public bool goBlack = false;
    public bool goTransparent = false;

    public float alfa = 0f;

    void Start () {
	    
	}	
	
	void Update () {
        if (goBlack)
        {
            alfa = Mathf.Lerp(alfa, 1, 0.1f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alfa);

            if (alfa >= 0.99f)
            {
                goBlack = false;
                Invoke("EndBlackScreen", 1f);
            }
        }
        if (goTransparent)
        {
            alfa = Mathf.Lerp(alfa, 0, 0.1f);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alfa);
        }
    }

    private void EndBlackScreen()
    {
        Singleton<GameManager>.Instance.HideScreen();
    }
}
