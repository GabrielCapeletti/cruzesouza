using UnityEngine;
using System.Collections;
using Core;

[RequireComponent(typeof(Rigidbody))]
public class TileController : MonoBehaviour {

    public bool noLenght;

    private float speed;
    private float halfObjectLenght;
    private float objectLenght;

    private bool active = true;
    private Rigidbody rigidBody;

	void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
        objectLenght = GetComponent<BoxCollider>().size.z;
        this.halfObjectLenght = objectLenght / 2;
        speed = Singleton<GameManager>.Instance.speed;
    }

    public float GetLenght()
    {
        if (noLenght)
        {
            return 0;
        }
        return objectLenght;
    }
    public float GetHalfLenght()
    {
        return halfObjectLenght;
    }

	void FixedUpdate () {
        if (active)
        {
            move();
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == TagMap.PATH_END)
        {
            Singleton<TreadmillController>.Instance.ResetTile(this);
        }
    }
    public void Deactivate()
    {
        active = false;
    }

    public void Activate()
    {
        active = true;
    }

    private void move()
    {        
        rigidBody.MovePosition(transform.position  -transform.forward *speed* Time.deltaTime);
    }
}
