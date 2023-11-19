using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsMenu : MonoBehaviour
{
    //singletons
    public static AchievementsMenu instance;
    private void Awake() => instance = this;

    //make prefab ito list so that they can all be closed when menu closes
    public GameObject lockedPrefab;
    public GameObject panel;
    public GameObject ach1panel;
    public int ach1;

    private void Start()
    {
        ach1 = PlayerPrefs.GetInt("Achievement1");
        Debug.Log(ach1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc pressed");
            closePannel();
        }
        
    }

    public void openPannel() {


        if (panel != null) {
            panel.SetActive(true);
            Debug.Log(ach1);
            if (ach1 == 1)
            {
                //Debug.Log(ach1);
                lockedPrefab.SetActive(false);
            }
            
        }   
    }

    public void closePannel() {
        panel.SetActive(false);
        //ach1panel.SetActive(false);
        //lockedPrefab.SetActive(false);
    }
}
