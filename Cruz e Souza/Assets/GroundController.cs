using UnityEngine;
using System.Collections;
using Core;

public class GroundController : MonoBehaviour {

    public Texture normalGround;
    public Texture poemGround;

    public Material groundMaterial;
    private bool noChange = false;

    private GameManager manager;

    void Start()
    {
        manager = Singleton<GameManager>.Instance;
    }

    void Update()
    {
        if (manager.poemMode)
        {
            PoemMode();
        }
        else 
        {
            NormalMode();
        }
    }
	
	public void NormalMode()
    {
        groundMaterial.SetTexture("_MainTex",normalGround);
    }

    public void PoemMode()
    {
        groundMaterial.SetTexture("_MainTex", poemGround);
    }
}
