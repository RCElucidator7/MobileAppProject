using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Data_Management : MonoBehaviour {

	public static Data_Management dataManagement;
	public int highScore;

	void Awake () {
		if(dataManagement == null){
			DontDestroyOnLoad (gameObject);
			dataManagement = this;
		} else if (dataManagement != this){
			Destroy (gameObject);
		}
	}

	public void SaveData () {
		//Data is Saved
		BinaryFormatter BinForm = new BinaryFormatter(); //Creates Bin formatter
		FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat"); //Creates File
		gameData data = new gameData();
		data.highScore = highScore;
		BinForm.Serialize (file, data); //Serializes
		file.Close(); //Close File
	}

	public void LoadData () {
		//Data is Loaded
		if(File.Exists (Application.persistentDataPath + "/gameInfo.dat")){
			BinaryFormatter BinForm = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
			gameData data = (gameData)BinForm.Deserialize (file);
			file.Close();
			highScore = data.highScore;
		}
	}
}

[Serializable]
class gameData {
	public int highScore;
}
