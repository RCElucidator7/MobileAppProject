using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour {

	static Audio_Manager instance = null;

    //Keep the audio playing when navigating to a different scene
    private void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
}
