using UnityEngine;

namespace Core
{
	[RequireComponent (typeof(Rigidbody2D))]
	[RequireComponent (typeof(Collider2D))]
	public class BasePhysicCharacter : MonoBehaviour
	{
		protected Rigidbody2D RigidBody;
		protected Collider2D Collider;

		public virtual void Awake ()
		{
			this.RigidBody = this.GetComponent<Rigidbody2D> ();
			this.Collider = this.GetComponent<Collider2D> ();
		}

	}

}
