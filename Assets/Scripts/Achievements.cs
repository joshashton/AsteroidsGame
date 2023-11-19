using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    //General variables
    public GameObject achNote;
    //public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;

    //achievement 1 specific
    public GameObject ach1Image;
    
    public static int ach1Count;
    public int ach1Trigger = 1000;
    public int ach1Code;


    // Update is called once per frame
    void Update()
    {

        //Debug.Log(ach1Count);
        ach1Code = PlayerPrefs.GetInt("Achievement1");
        if (ach1Count >= ach1Trigger && ach1Code != 1) {
            StartCoroutine(TriggerAch1());
        }


    }

    IEnumerator TriggerAch1()
    {
        achActive = true;
        ach1Code = 1;
        PlayerPrefs.SetInt("Achievement1", ach1Code);
        //achSound.Play();
        ach1Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Achievement Unlocked";
        achDesc.GetComponent<Text>().text = "Gained 1000 points";
        achNote.SetActive(true);
        yield return new WaitForSeconds(5);
        //resetting ui
        achNote.SetActive(false);
        //ach01Image.SetActive(false);
        //achTitle.GetComponent<Text>().text = "";
        //achDesc.GetComponent<Text>().text = "";
        //achActive = false;
    }
}
