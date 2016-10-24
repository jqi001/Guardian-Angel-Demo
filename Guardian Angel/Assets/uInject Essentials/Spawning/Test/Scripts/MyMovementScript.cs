using UnityEngine;

namespace Spawning.Test
{
	[RequireComponent(typeof(Rigidbody))]
	public class MyMovementScript : MonoBehaviour
	{
		private new Rigidbody rigidbody;

		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		private void ResetState()
		{
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;
			ResetPhysics();
			Debug.Log("State Resetted");
		}

		private void ResetPhysics()
		{
			rigidbody.isKinematic = true;
			rigidbody.isKinematic = false;
		}
	}
}