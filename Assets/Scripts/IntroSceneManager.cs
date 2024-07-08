using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    [Header("===========Main Menu===========")]
    public GameObject MainMenuCanvas;
    public Button NewGameButton;
    public Button LevelSelectButton;
    public Button AboutButton;
    public Button EndGameButton;

    [Header("===========Sub Menu===========")]
    public GameObject SubMenuCanvas;
    public Button MainMenuButton;
    //Any shared UI elements on the sub menu

    [Header("===========Level Select Menu===========")]
    public GameObject LevelSelectCanvas;
    public string[] LevelNames;
    public Button LevelButtonPrefab;

    [Header("===========About Menu===========")]
    public GameObject AboutCanvas;
    public Button StartGameButton;

    [Header("===========Scene Names===========")]
    public string StartGameScene;
    public string NewGameScene;
    public string EndGameScene;

    private string levelName;
    // Start is called before the first frame update
    void Start()
    {
        //Set up the button listener
        NewGameButton.onClick.AddListener(StartNewGame);
        LevelSelectButton.onClick.AddListener(SelectLevel);
        AboutButton.onClick.AddListener(DisplayAboutInfo);
        MainMenuButton.onClick.AddListener(ShowMainMenu);
        EndGameButton.onClick.AddListener(EndGame);
        StartGameButton.onClick.AddListener(StartNewGame);
        //Set up the levels
        SetLevels();

        //Display proper menu
        ShowMainMenu();
    }
    void EndGame()
    {
        SceneManager.LoadScene(EndGameScene);
    }
    void StartNewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }
    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    void DisplayAboutInfo()
    {
        MainMenuCanvas.SetActive(false);
        LevelSelectCanvas.SetActive(false);

        AboutCanvas.SetActive(true);
        SubMenuCanvas.SetActive(true);
    }
    void ShowMainMenu()
    {
        SubMenuCanvas.SetActive(false);
        //AboutCanvas.SetActive(false);
        //LevelSelectCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
        Debug.Log("Main Menu button pressed");
    }
    void SelectLevel()
    {
        //Switch canvas
        MainMenuCanvas.SetActive(false);
        AboutCanvas.SetActive(false);
        LevelSelectCanvas.SetActive(true);
        SubMenuCanvas.SetActive(true);
    }
    void SetLevels()
    {
        //Set up the level buttons based on the level names
        for (int i = 0; i < LevelNames.Length; i++)
        {
            levelName = LevelNames[i];
            //Create a button from the button template LevelButtonPrefab
            Button levelButton = Instantiate(LevelButtonPrefab, Vector3.zero, Quaternion.identity);
            //Set up the button listener
            Button levelButtonScript = levelButton.GetComponent<Button>();
            levelButtonScript.onClick.RemoveAllListeners();
            levelButtonScript.onClick.AddListener(() => LoadLevel(levelName));

            //Give the button a unique name
            levelButton.name = levelName + "Button";

            // set the parent of the button as the LevelSelectCanvas so it will be dynamically arranged based on the defined layout
            levelButton.transform.SetParent(LevelSelectCanvas.transform, false);

            //Set the label of the button
            Text levelButtonLabel = levelButton.GetComponentInChildren<Text>();
            levelButtonLabel.text = levelName;

            // You can even set the button interactivity based on whether the level has been played thru or not
        }
    }
}