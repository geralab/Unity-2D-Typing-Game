using UnityEngine;
using System.Collections;

public class Reflex : MonoBehaviour {
	public int State {get;set;}
	public int Row {get;set;}
	public int Col {get;set;}
	public float nextIteration{get;set;}
	public float theDelay {get;set;}
	public string currentWord {get;set;}
	public int fontSize{get;set;}
	public AudioClip[] theSounds;
	public float theSoundDelay{get;set;}
	public float timeToNextSound{get;set;}
	public int previousSongNumber{get;set;}
	public bool theTest {get;set;}
	public AudioClip[] theSongs;
	public int songNumber;
	private double timeToNextSong;
	public float songVolume;
	public GameObject theSource;
	public AudioSource audio;
	public int Score{get;set;}
	public int ScoreValue{get;set;}
	public GUISkin guiSkin;
	public string [,] textForLevels  =
	{
		{"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z",
		"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z","End"}

	   ,{ "Live your life!", "Positive","Enjoy","Believe","Happy","Succeed","Laugh","Welcome",
	    "Rise","Greatness","Honesty","Live","Youth","Kindness","End"}
	   ,{   "Gangsta Love","Every time i come around","She always call in the middle of the night","she say my name loud","That's what i aim for",
			"Shawty love me now","run up on me like click clack","the floss the cream","End"}
	   ,{   "Super Bad",
			"I've got soul!",
        	"and i'm super bad",
			"up and down",
			"round and round","eeeeeeeh"
		,   "Hey!!!" ,
			"The Bridge!","End"}
	
	};
	
	public GameObject [] theString = new GameObject[10];
	public GameObject hello;
	public GameObject theText{get;set;}
	public GameObject userText{get;set;}
	public GameObject rightBound{get;set;}
	public GameObject leftBound{get;set;}
	public GameObject theCamera{get;set;}
	public int standardIncrement{get;set;}
	public int previousRow{get;set;}
	
	// Use this for initialization
	void Start () {
		songNumber = 0;
		audio = gameObject.GetComponent<AudioSource>();
		songVolume = 1.0f;
		State = 0;

		Row = 0;
		Col = 0;
		Score = 0;
		ScoreValue=30;
		fontSize = 40;
		timeToNextSound = 0;
		theSoundDelay = .2f;
		theText = GameObject.Find("theText");
		rightBound = GameObject.Find("rightBound");
		leftBound = GameObject.Find("leftBound");
		userText = GameObject.Find("userText");
		theCamera = GameObject.Find("Camera");
		nextIteration = 0;
		theDelay = 1f;
		theTest=true;
		standardIncrement=2;
		userText.GetComponent<TextMesh>().text="";
		//theText.transform.position = leftBound.transform.position;
		int tempX=95;
		int tempY=50;
		
		for(int i = 0; i < 10;i++)
		{
			theString[i]= (GameObject)GameObject.Instantiate(theText);
			theString[i].name = "string "+i.ToString();
			theString[i].GetComponent<TextMesh>().color = Color.green;
			theString[i].transform.position = new Vector3(theText.transform.position.x+tempX,
			theText.transform.position.y+tempY,theText.transform.position.z);
			theString[i].GetComponent<TextMesh>().text = "CLONES";
			theString[i].GetComponent<TextMesh>().fontSize=fontSize;
			theString[i].GetComponent<TextMesh>().color = Color.green;
			tempX-=95;
			tempY+=50;
		}
	}
	
	// Update is called once per frame
	void Update () {
		switch(State)
			{
				case 0:
			audio = gameObject.GetComponent<AudioSource>();
			   
				
				if(!audio.isPlaying){
					audio.clip = theSongs[songNumber];
					audio.volume= songVolume;
					audio.Play();
				   previousSongNumber = songNumber;
					
					
				}else if(previousSongNumber != songNumber)
			    {
					audio.Stop();
				    audio = gameObject.GetComponent<AudioSource>();
					audio.clip = theSongs[songNumber];
					audio.volume= songVolume;
					audio.Play();
					previousSongNumber = songNumber;
			  }
				

				
						//nextIteration = Time.time + theDelay;
			
			//}
						
					  theText.GetComponent<TextMesh>().text = textForLevels[Row,Col];
						for(int i = 0; i < 10;i++)
					    {
						
						    theString[i].GetComponent<TextMesh>().text=textForLevels[Row,Col];
							theString[i].GetComponent<TextMesh>().fontSize=fontSize;
						if(theString[i].transform.position.x < leftBound.transform.position.x - theString[i].GetComponent<Renderer>().bounds.size.x)
						{
							    theString[i].transform.position = 
								new Vector3(rightBound.transform.position.x+theString[i].GetComponent<Renderer>().bounds.size.x,
								theString[i].transform.position.y,theString[i].transform.position.z);
							
							   
						}else {
					//if(Time.time > nextIteration){
							float tempX= theString[i].transform.position.x;
							tempX-=standardIncrement;
							theString[i].transform.position = new Vector3(tempX,
								theString[i].transform.position.y,theString[i].transform.position.z);
						//nextIteration = Time.time + theDelay;
					//}
							
						}
						}
						
						
						
								        theText.GetComponent<TextMesh>().fontSize= fontSize;
										theText.GetComponent<TextMesh>().color = Color.green;
									    Debug.Log(theText.GetComponent<Renderer>().bounds.size.x);//  Debug.Log(theText.GetComponent<Mesh>().bounds.size.x);
						if(theText.transform.position.x < leftBound.transform.position.x - theText.GetComponent<Renderer>().bounds.size.x)
						{
							    theText.transform.position = 
								new Vector3(rightBound.transform.position.x+theText.GetComponent<Renderer>().bounds.size.x,
								theText.transform.position.y,theText.transform.position.z);
							
							   
						}else {

							   float tempX= theText.transform.position.x;
							   tempX-=standardIncrement;
							   theText.transform.position = new Vector3(tempX,
							   theText.transform.position.y,theText.transform.position.z);
				
							
						}
			if(Input.GetKey(KeyCode.UpArrow)&&Col<= textForLevels.GetLength(1) - 1)
			{
				Col++;
			}
						if(!Input.GetKey(KeyCode.Return) && !Input.GetKeyDown(KeyCode.Return))
						{
							userText.GetComponent<TextMesh>().text += Input.inputString;
				userText.GetComponent<TextMesh>().fontSize= fontSize;
							userText.GetComponent<TextMesh>().color = Color.cyan;
						}
						
						if(Input.GetKey(KeyCode.Backspace)||Input.GetKey(KeyCode.Delete))
						{
							int length = (userText.GetComponent<TextMesh>().text).Length-2 ;
							userText.GetComponent<TextMesh>().text
								=(userText.GetComponent<TextMesh>().text).Substring(0,
									(length > 0)?length:0);
						
						}
						
						Debug.Log ((userText.GetComponent<TextMesh>().text).Length);
						if(userText == null)
						{
							userText = GameObject.Find("userText");
						}
						
						    currentWord = textForLevels[Row,Col];
							theTest=false;
						
						if(userText.GetComponent<TextMesh>().text==currentWord && (Input.GetKey(KeyCode.Return)||Input.GetKeyDown(KeyCode.Return)))
						{
				Score+=ScoreValue;
							theTest=true;
							userText.GetComponent<TextMesh>().text="";
				if(Time.time > timeToNextSound){
				AudioSource.PlayClipAtPoint(theSounds[0],gameObject.transform.position);
					timeToNextSound = Time.time + theSoundDelay;
					if(currentWord == "End")
					{
						songNumber++;
					}
				}
							
							
							
			}else if(!(userText.GetComponent<TextMesh>().text==currentWord) && (Input.GetKey(KeyCode.Return)||Input.GetKeyDown(KeyCode.Return)))
			{
				if(Time.time > timeToNextSound){
				AudioSource.PlayClipAtPoint(theSounds[1],gameObject.transform.position);
					timeToNextSound = Time.time + theSoundDelay;
				}
				
				
			}
						
						if(theTest){
											
											if(Row >= textForLevels.GetLength(0) - 1)
											{
												Row=0;
												
											    
											
											}else {
											if(Col>= textForLevels.GetLength(1) - 1)
												{
													
										
											        Col = 0;
													previousRow = Row;
											        Row++;
												}else{Col++;}
				
				}	
							}
			
			Debug.Log("The Row is: " + Row);
			Debug.Log("The Previous is: " + previousRow);
			//Debug.Log("Length R: " + textForLevels.GetLength(Row));
			//Debug.Log("Length C: " + textForLevels.GetLength(Col));
								break;
							case 1:
								break;
							case 3:
								break;
						}

		}
	
	
	
	void OnGUI () {
		GUIStyle boxStyle = new GUIStyle(GUI.skin.box);
		boxStyle.fontSize = 20;
		boxStyle.fontStyle = FontStyle.BoldAndItalic;
	
		GUI.skin = guiSkin;
		int bw = 15; // border width
		int numButtons = 2;
		int width = 200;
		
		// Make a background box
		GUI.TextArea(new Rect(10f, 10f, 200f, 20f), "SCORE: "+Score);
		

	}
	
	
	
}
