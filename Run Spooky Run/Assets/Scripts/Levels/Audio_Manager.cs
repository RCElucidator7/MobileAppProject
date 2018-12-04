using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour {

	static Audio_Manager instance = null;

    private void Awake(){
        DontDestroyOnLoad(transform.gameObject);
    }
}
