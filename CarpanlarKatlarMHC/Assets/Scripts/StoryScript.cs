using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

	public Text storyText;
	public string[] story;
	int i = 0;

	// Use this for initialization
	void Start () {
		storyText.text = story [i];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void nextStory(){
		i++;
		if (i < story.Length) {
			storyText.text = story [i];
		}
        else
        {
            SceneManager.LoadScene("Scene3");
        }
			
	}


}
