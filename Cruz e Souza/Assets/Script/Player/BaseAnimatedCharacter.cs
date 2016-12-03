using UnityEngine;
using System.Collections;

namespace Core
{
	public class BaseAnimatedCharacter : BasePhysicCharacter
	{
		protected Animator animator;

		public override void Awake ()
		{
			base.Awake ();
			this.animator = this.GetComponentInChildren<Animator> ();
		}
	}
}
