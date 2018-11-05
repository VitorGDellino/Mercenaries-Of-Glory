using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CharSelectionMenu : MonoBehaviour{

    public CharSelectionMenuInput input;

    public int chosen = -1;

    public GameObject panelMain;
	public GameObject panelControls;
	public GameObject panelCredits;
	public GameObject panelSettings;
	public GameObject panelCharacterSelection;

    public GameObject playerPanelWa;
    public GameObject playerPanelWi;
    public GameObject playerPanelR;
    public GameObject pressStartPanel;
    private bool pressed;
    private bool ready;

    void Update() {
        if(input.GetStart()){
            if(!ready){
                PressStart();
            }else{
                BeginGame();
            }
            
        }

        if(input.GetBack()){
            Back();
        }

        if(input.GetRight()){
            if(!ready){
                Next();
            }
        }

        if(input.GetLeft()){
            if(!ready){
                Prev();
            }

        }  
    }

    public void showMain (){
		panelMain.SetActive (true);
		panelControls.SetActive (false);
		panelCredits.SetActive (false);
		panelSettings.SetActive (false);
		panelCharacterSelection.SetActive (false);
	}

    private void BeginGame(){
        for(int i = 0; i < 4; i++){
            if(MainMenuController.instance.status[i] == 1){
                return;
            }
        }

        SceneManager.LoadScene("BossLairFinal");
    }

    private void Back(){
        if(pressed){
            if(ready){
                ready = false;
                if(playerPanelWa.activeSelf){
                    playerPanelWa.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = "Press Start";
                }else if(playerPanelWi.activeSelf){
                    playerPanelWi.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = "Press Start";
                }else if(playerPanelR.activeSelf){
                    playerPanelR.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = "Press Start";
                }
                chosen = -1;
                MainMenuController.instance.classesChosen[input.player] = chosen; 
                MainMenuController.instance.status[input.player] = 1;
            }else{
                MainMenuController.instance.status[input.player] = 0;
                pressed = false;
                playerPanelWa.SetActive(false);
                playerPanelWi.SetActive(false);
                playerPanelR.SetActive(false);
                pressStartPanel.SetActive(true);
            }
            
        }else{
            showMain();
        }
    }

    private void PressStart(){
        if(!pressed){
            pressed = true;
            playerPanelWa.SetActive(true);
            pressStartPanel.SetActive(false);
            MainMenuController.instance.status[input.player] = 1;
        }else{
            if(playerPanelWa.activeSelf){
                playerPanelWa.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = "READY";
                chosen = 0;
            }else if(playerPanelWi.activeSelf){
                playerPanelWi.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = "READY";
                chosen = 1;
            }else if(playerPanelR.activeSelf){
                playerPanelR.GetComponent<Transform>().GetChild(6).GetComponent<Text>().text = "READY";
                chosen = 2;
            } 

            MainMenuController.instance.classesChosen[input.player] = chosen;
            MainMenuController.instance.status[input.player] = 2;
            ready = true; 
        }
    }

    private void Next(){
        if(pressed){
            if(playerPanelWa.activeSelf){
                playerPanelWa.SetActive(false);
                playerPanelWi.SetActive(true);
            }else if(playerPanelWi.activeSelf){
                playerPanelWi.SetActive(false);
                playerPanelR.SetActive(true);
            }else if(playerPanelR.activeSelf){
                playerPanelR.SetActive(false);
                playerPanelWa.SetActive(true);
            }
        }
    }

    private void Prev(){
        if(pressed){
            if(playerPanelWa.activeSelf){
                playerPanelWa.SetActive(false);
                playerPanelR.SetActive(true);
            }else if(playerPanelWi.activeSelf){
                playerPanelWi.SetActive(false);
                playerPanelWa.SetActive(true);
            }else if(playerPanelR.activeSelf){
                playerPanelR.SetActive(false);
                playerPanelWi.SetActive(true);
            }
        }
    }
}