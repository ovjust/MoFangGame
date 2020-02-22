using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    int screenWidth;
    int screenHeight;
    float buttonWidth=0.6f;
    float buttonHeight=0.2f;
    float buttonDistance=0.05f;

    public int fontSize = 25;
    // Use this for initialization
    void Start () {
        screenWidth = UnityEngine.Screen.width;
        screenHeight = UnityEngine.Screen.height;

        fontSize = Convert.ToInt32(screenWidth / 1000f * 20);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    bool firstFontSize = true;
    void OnGUI()
    {
        if (firstFontSize)
        {
            firstFontSize = false;
            print("GUI.skin.button.fontSize" + GUI.skin.button.fontSize);
            GUI.skin.button.fontSize = fontSize;
        }

        if (GUI.Button(new Rect(screenWidth*(0.5f-buttonWidth/2f),screenHeight*(1-buttonHeight*4-buttonDistance*3)/2, buttonWidth*screenWidth, buttonHeight*screenHeight), "三阶魔方"))
        {
           // Application.LoadLevel("MoFang2");//切换到场景Scene_2
            SceneManager.LoadScene("MoFang3");
        }

        if (GUI.Button(new Rect(screenWidth * (0.5f - buttonWidth / 2f), screenHeight * ((1 - buttonHeight * 4 - buttonDistance * 3) / 2+buttonHeight+buttonDistance), buttonWidth * screenWidth, buttonHeight * screenHeight), "二阶魔方"))
        {
            // Application.LoadLevel("MoFang2");//切换到场景Scene_2
            SceneManager.LoadScene("MoFang2");
        }

        if (GUI.Button(new Rect(screenWidth * (0.5f - buttonWidth / 2f), screenHeight * ((1 - buttonHeight * 4 - buttonDistance * 3) / 2 + buttonHeight*2 + buttonDistance*2), buttonWidth * screenWidth, buttonHeight * screenHeight), "二阶分离"))
        {
            // Application.LoadLevel("MoFang2");//切换到场景Scene_2
            SceneManager.LoadScene("MoFang2C");
        }

        if (GUI.Button(new Rect(screenWidth * (0.5f - buttonWidth / 2f), screenHeight * ((1 - buttonHeight * 4 - buttonDistance * 3) / 2 + buttonHeight * 3 + buttonDistance *3), buttonWidth * screenWidth, buttonHeight * screenHeight), "退出游戏"))
        {
            // Application.LoadLevel("MoFang2");//切换到场景Scene_2
            Application.Quit();
        }

        
    }
    }
