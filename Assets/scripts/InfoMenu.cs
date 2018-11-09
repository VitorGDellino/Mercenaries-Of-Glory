using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfoMenu : MonoBehaviour{
    public x360_GamePadMenu inputMenu;

    public GameObject panelInfo;
	public GameObject panelBoss;
	public GameObject panelChar;
    public GameObject panelCharWa;
    public GameObject panelCharWi;
    public GameObject panelCharR;
	public GameObject panelGoal;
    public GameObject panelMain;
    

    void Start(){
        inputMenu = this.GetComponent<x360_GamePadMenu>();
    }

    void Update(){
        /*if(inputMenu.GetLeft()){
            this.Prev();
        }*/
        
        if(inputMenu.GetRight()){
            this.Next();
        }

        if(inputMenu.GetBack()){
            this.Back();
        }
        
    }
    private void Next(){
        if(panelInfo.activeSelf){
            panelInfo.SetActive(false);
            panelGoal.SetActive(true);
        }else if(panelGoal.activeSelf){
            panelGoal.SetActive(false);
            panelChar.SetActive(true);
        }else if(panelChar.activeSelf){
            panelChar.SetActive(false);
            panelCharWa.SetActive(true);
        }else if(panelCharWa.activeSelf){
            panelCharWa.SetActive(false);
            panelCharWi.SetActive(true);
        }else if(panelCharWi.activeSelf){
            panelCharWi.SetActive(false);
            panelCharR.SetActive(true);
        }else if(panelCharR.activeSelf){
            panelCharR.SetActive(false);
            panelBoss.SetActive(true);
        }else if(panelBoss.activeSelf){
            panelBoss.SetActive(false);
            panelInfo.SetActive(true);
        }
    }

    /* private void Prev(){
         if(panelInfo.activeSelf){
            panelInfo.SetActive(false);
            panelBoss.SetActive(true);
        }else if(panelGoal.activeSelf){
            panelGoal.SetActive(false);
            panelInfo.SetActive(true);
        }else if(panelChar.activeSelf){
            panelChar.SetActive(false);
            panelGoal.SetActive(true);
        }else if(panelCharWa.activeSelf){
            panelCharWa.SetActive(false);
            panelChar.SetActive(true);
        }else if(panelCharWi.activeSelf){
            panelCharWi.SetActive(false);
            panelCharWa.SetActive(true);
        }else if(panelCharR.activeSelf){
            panelCharR.SetActive(false);
            panelCharWi.SetActive(true);
        }else if(panelBoss.activeSelf){
            panelBoss.SetActive(false);
            panelCharR.SetActive(true);
        }
    }*/


	private void Back (){
            panelInfo.SetActive (false);
            panelGoal.SetActive (false);
            panelChar.SetActive (false);
            panelCharWa.SetActive(false);
            panelCharWi.SetActive(false);
            panelCharR.SetActive(false);
            panelBoss.SetActive (false);
            panelMain.SetActive(true);
        
	}

}