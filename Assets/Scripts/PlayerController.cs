using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public string nextLevel;
	
	private bool onBox = false;

	private void FixedUpdate()
	{
		if (!onBox)
		{
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical   = Input.GetAxis ("Vertical");
			
			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); 
			rigidbody.velocity = movement * speed;			
		}
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Box")
		{
			onBox = true;
			rigidbody.position = other.rigidbody.position;
			Debug.Log("NEXT LEVEL");
			Vector3 movement = new Vector3(0f,0f,0f);
			rigidbody.velocity = movement;
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			rigidbody.constraints = RigidbodyConstraints.FreezePosition;
			
			Application.LoadLevel(nextLevel);
		}
	}
}
