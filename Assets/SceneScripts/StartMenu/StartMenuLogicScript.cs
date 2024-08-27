using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuLogicScript : MonoBehaviour
{
    public GameManager gameManager;
    public Button ContinueButton;
    public Button StartButton;
    public Button QuitButton;

    private void Start()
    {
        GameData gamedata = Savesystem.loadGameData();
        gameManager = gamedata.loadDataToGameManager(gameManager);
        ContinueButton.onClick.AddListener(LoadScene);
        StartButton.onClick.AddListener(StartNewScene);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void StartNewScene()
    {
        Logger.DevTest("To do: new game");
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(gameManager.lastSceneName);
        try
        {
            SceneManager.LoadScene(gameManager.lastSceneName);
        }


        catch
        {
            //SceneManager.LoadScene("Essensraum");
        }

    }
}
