using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

	public Text text;

	private int[] playersDamage;
	private string[] playersNumber;
	int aux;
	string auxNome;
	// Use this for initialization
	void Start () {
		playersNumber = new string[4];
		playersNumber[0] = "Player1";
		playersNumber[1] = "Player2";
		playersNumber[2] = "Player3";
		playersNumber[3] = "Player4";

		playersDamage = new int[4];
		playersDamage[0] = PlayerPrefs.GetInt("Player1");
		playersDamage[1] = PlayerPrefs.GetInt("Player2");
		playersDamage[2] = PlayerPrefs.GetInt("Player3");
		playersDamage[3] = PlayerPrefs.GetInt("Player4");

		for(int i=0; i<4; i++){
			for(int j=i+1; j<4; j++){
				if(playersDamage[i]<playersDamage[j]){
					aux = playersDamage[i];
					playersDamage[i] = playersDamage[j];
					playersDamage[j] = aux;
					auxNome = playersNumber[i];
					playersNumber[i] = playersNumber[j];
					playersNumber[j] = auxNome;
				}
			}
		}

		Debug.Log("Cheguei aqui");
		text.text = "Ranking\n\n\nVENCEDOR -> ";

		for(int i=0; i<4; i++){
			text.text += i+1 + "º - " + playersNumber[i] + " ";
			text.text += "Dano - " + playersDamage[i] + "\n\n";
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
