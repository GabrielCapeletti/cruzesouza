using UnityEngine;
using System.Collections;
using System;

public class ItemController : ObstacleController
{
    public GameObject transparent;
    public GameObject opaco;
    public Animator animator;
    private Material materialTransparent;

    protected override void Start()
    {
        base.Start();
        materialTransparent = this.transparent.GetComponent<MeshRenderer>().material;
    }

    public override void DeathAnimation()
    {
        base.DeathAnimation();

        opaco.SetActive(false);
        this.speed = 0;     

        StartCoroutine(DecreaseAlfa());       
      
        this.rigidBody.AddForce(new Vector3(0,1500,0));
        this.rigidBody.useGravity = true;
        this.animator.SetFloat("Speed", 5);
    }

    IEnumerator DecreaseAlfa()
    {
        for (float i = 1 ; i > 0 ; i -= 0.05f) {               
            Color oldColor = materialTransparent.color;
            materialTransparent.SetColor( "_Color" ,new Color(oldColor.r, oldColor.g, oldColor.b, i));
            yield return new WaitForSeconds(0.03f);
        }
        GameObject.Destroy(this.gameObject);
        yield return new WaitForSeconds(0f);        
    }
}
