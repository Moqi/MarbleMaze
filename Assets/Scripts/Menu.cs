using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{
	public string animationOverName;
	public string animationOutName;
	public string levelName;
	
	private bool isMusic = true;
	
	private TextMesh t;
	
	private Animation a;
	
	private bool _isLockedOver;
	private bool _isLockedOut;
	
	public GameObject musicOn;
	public GameObject musicOff;
	
	//private bool _isLocked;
	private bool _isMouseOut;
	
	
	private void Start()
	{
		a = (Animation)gameObject.GetComponent(typeof(Animation));			
		
		//musicOn = GameObject.FindWithTag("MusicOn");
		//musicOff = GameObject.FindWithTag("MusicOff");	
		
		//Debug.Log ("musicOn: " + musicOn);
		//Debug.Log ("musicOff: " + musicOff);		
		
		
		if(musicOn && musicOff)
		{
		
			if(this.name == musicOff.name)
				musicOn.SetActive(false);
			else if (this.name == musicOn.name)
				musicOff.SetActive(false);
		}
	}

	private void OnMouseEnter()
	{
		_isMouseOut = false;		
		
		if(!_isLockedOut)
		{
			var unlockOverEvent = new AnimationEvent();		
			unlockOverEvent.functionName = "UnLockOverAnimation";
			unlockOverEvent.time = 0.5f;		
			
			a[animationOverName].clip.AddEvent(unlockOverEvent);				
			a.Play(animationOverName);
			
			_isLockedOver = true;
			
			if(!Music.IsMute)
				audio.Play();		
		}
	}

	private void UnLockOverAnimation()
	{
		_isLockedOver = false;
		
		if(_isMouseOut)
				OnMouseExit();
	}	
	
	private void UnLockOutAnimation()
	{
		_isLockedOut = false;
		
		if(!_isMouseOut)
			OnMouseEnter();
	}	
		
	private void OnMouseExit()
	{		
		_isMouseOut = true;
				
		if(!_isLockedOver)
		{
			var unlockOutEvent = new AnimationEvent();		
			unlockOutEvent.functionName = "UnLockOutAnimation";
			unlockOutEvent.time = 0.5f;		
	
			a[animationOutName].clip.AddEvent(unlockOutEvent);		

			a.Play(animationOutName);
			
			_isLockedOut = true;
				
			if(!Music.IsMute)
				audio.Stop();
		}
	}
	
	private void OnMouseDown()
	{
		if(levelName == "-1")
		{
			Application.OpenURL("http://www.opreagames.com");
		}
		else if(levelName == "-2")
		{	
			//TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
									
			if(Music.IsMute)			
			{
				//t.text = "MUSIC OFF";
				musicOff.SetActive(true);
				musicOn.SetActive(false);

				Music.IsMute = false;
			}
			else
			{
				musicOff.SetActive(false);
				musicOn.SetActive(true);			
				//t.text = "MUSIC ON";
				Music.IsMute = true;
			}
			//OnMouseExit();
			Music.SwitchMute(Music.IsMute);
		}
		else
		{
			Debug.Log("mouse click");
			Application.LoadLevel(levelName);
		}
	}
}
