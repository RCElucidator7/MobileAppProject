using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    private GameObject player;
    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag ("Player");
	}

	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        //Follows the player model as it moves
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
