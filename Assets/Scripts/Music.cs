using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour 
{
	public string musicSourceTag;
	public static bool IsMute { get; set; }
	
	private static string _musicSourceTag;
	
	private void Awake()
	{
		_musicSourceTag = musicSourceTag;
		SwitchMute(IsMute);
	}
	
	public static void SwitchMute(bool isMute)
	{
	
		if( isMute)
			GameObject.FindWithTag(_musicSourceTag).audio.Stop();
		else
			GameObject.FindWithTag(_musicSourceTag).audio.Play();
	}
}
