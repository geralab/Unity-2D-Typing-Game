using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
    public AudioClip[] theSongs;
	public int songNumber;
	private double timeToNextSong;
	public float songVolume;
	public GameObject theSource;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
	
		songNumber = -1;
		audio = gameObject.GetComponent<AudioSource>();
		songVolume = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		;
		audio = gameObject.GetComponent<AudioSource>();
		if(songNumber < theSongs.Length){
		
			if(!audio.isPlaying){
				songNumber++;
				audio.clip = theSongs[songNumber];
				audio.volume= songVolume;
				audio.Play();

				
			}
			
		}else{
			songNumber = -1;
		}
	}
	}

