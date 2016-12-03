using UnityEngine;
using System.Collections;
using Core;

public abstract class ObstacleController : MonoBehaviour {

    protected float speed;    
    protected Rigidbody rigidBody;

    public virtual void DeathAnimation()
    {        
        this.GetComponent<Collider>().enabled = false;        
    }

    protected virtual void Start()
    {        
        this.rigidBody = this.GetComponent<Rigidbody>();
        this.speed = Singleton<GameManager>.Instance.speed;
    }

    void FixedUpdate () {
        this.transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == TagMap.PATH_END)
        {
            GameObject.Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == TagMap.PATH_END)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
