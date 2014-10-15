using UnityEngine;
using System.Collections;

public class CloseInstructions : MonoBehaviour 
{
	public int level;

	private void OnMouseDown()
	{
		Debug.Log ("click");
		Application.LoadLevel(level);
	}
}
