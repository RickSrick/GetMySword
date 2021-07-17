using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject[] interfaces;
    private void hideAllInterfaces(){ foreach (GameObject g in interfaces) { g.SetActive(false); } }
    public void OpenAnInterface(int index){
        hideAllInterfaces();
        interfaces[index].SetActive(true);
    }
    public void setPause(int value){
        Time.timeScale = value; 
    }
    public void Quit() { Application.Quit(); }
}