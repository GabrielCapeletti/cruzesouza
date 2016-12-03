using UnityEngine;
using System.Collections;

public class PortalController : MonoBehaviour {

    public GameObject arco;
    private Material[] material;
    private float alfa = 1;
    void Start() {
        material = new Material[arco.GetComponent<MeshRenderer>().materials.Length];
        for (int i = 0; i < material.Length; i++) { 
            material[i] = arco.GetComponent<MeshRenderer>().materials[i];
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.z > 15)
        {
            if (alfa < 1) {
                alfa = 1;
                for (int i = 0; i < material.Length; i++)
                {
                    material[i].color = new Color(material[i].color.r, material[i].color.g, material[i].color.b, alfa);
                }
            }            
        }
        else
        {           
            alfa = this.transform.position.z/15;
            alfa = alfa < 0 ? 0 : alfa;

            for (int i = 0; i < material.Length; i++)
            {
                material[i].color = new Color(material[i].color.r, material[i].color.g, material[i].color.b, alfa);
            }
           
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == TagMap.ENEMY)
        {
            GameObject.Destroy(coll.gameObject);
        }
        if (coll.tag.Substring(0, 4) == "Item")
        {
            GameObject.Destroy(coll.gameObject);
        }
    }
}
