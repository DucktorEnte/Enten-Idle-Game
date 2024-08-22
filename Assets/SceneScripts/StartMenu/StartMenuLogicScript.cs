using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuLogicScript : MonoBehaviour
{
    public GameManager gameManager;
    public Button ContinueButton;

    private void Start()
    {
        GameData gamedata=Savesystem.loadGameData();
        gameManager = gamedata.loadDataToGameManager(gameManager);
        ContinueButton.onClick.AddListener(loadScene);
    }

    private void loadScene()
    {
        SceneManager.LoadScene(gameManager.lastSceneName);
        try
        {
            SceneManager.LoadScene(gameManager.lastSceneName);
        }


        catch {
            //SceneManager.LoadScene("Essensraum");
        }

    }
}
