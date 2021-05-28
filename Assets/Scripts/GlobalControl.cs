using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    // Start is called before the first frame update
    public int height;
    public int weight;
    public string gender;
    public int age;
    public GameObject settingsObj;
    public GameObject menuObj;
    public GameObject homeObj;
    public GameObject navObj;
    public GameObject openWorkout;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void saveSettings(){
        //GameObject settingsObj = GameObject.Find("SetValues");
        height = settingsObj.GetComponent<ValueSetter>().height;
        weight = settingsObj.GetComponent<ValueSetter>().weight;
        settingsObj.SetActive(false);
        menuObj.SetActive(true);
    }
    public void openSettings(){
        //GameObject settingsObj = GameObject.Find("SetValues");
        menuObj.SetActive(false);
        settingsObj.SetActive(true);
    }

    public void openHome(){
        homeObj.SetActive(true);
    }

    public void startOpenWorkout(){
        homeObj.SetActive(false);
        openWorkout.SetActive(true);
        navObj.SetActive(true);
    }
    public void startSchedWorkout(){

    }

}
