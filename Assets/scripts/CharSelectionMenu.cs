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

        if(input.GetSubmit()){
            if(pressed){
                selectChar();
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

        SceneManager.LoadScene("PrepareToBattle");
    }

    private void Back(){
        string name = "";
        if(pressed){
            if(ready){
                ready = false;
                if(playerPanelWa.activeSelf){
                   name = playerPanelWa.name;
                }else if(playerPanelWi.activeSelf){
                    name = playerPanelWi.name;
                }else if(playerPanelR.activeSelf){
                    name = playerPanelR.name;
                }

                var x = GameObject.Find(name);
                x.transform.GetChild(3).gameObject.SetActive(true);
                x.transform.GetChild(4).gameObject.SetActive(false);
                x.transform.GetChild(5).gameObject.SetActive(true);
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

    private void selectChar(){
        string name = "";
        if(playerPanelWa.activeSelf){
                name = playerPanelWa.name;
                chosen = 0;
            }else if(playerPanelWi.activeSelf){
                name = playerPanelWi.name;
                chosen = 1;
            }else if(playerPanelR.activeSelf){
                name = playerPanelR.name;
                chosen = 2;
            } 

            var x = GameObject.Find(name);
            x.transform.GetChild(3).gameObject.SetActive(false);
            x.transform.GetChild(4).gameObject.SetActive(true);
            x.transform.GetChild(5).gameObject.SetActive(false);

            MainMenuController.instance.classesChosen[input.player] = chosen;
            MainMenuController.instance.status[input.player] = 2;
            ready = true; 
    }
}