using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Menu : MonoBehaviour
{
    private Button adventureBtn;
    private Button optionsBtn;
    private Button quitBtn;
    private Button facileBtn;
    private Button normalBtn;
    private Button difficultBtn;
    private Button hardcorebtn;
    private Button backBtn;
    private Button scoresBtn;
    private Slider volumeSld;
    private Dropdown inputDropdown;
    private AudioSource audioSource;
    private GameObject optionsMenu;
    private GameObject mainMenu;
    private GameObject scoresMenu;
    private GameObject difficultMenu;
    private List<GameObject> panels;
    //private Manager manager;
    private const string path = "/scores.json";
    // Start is called before the first frame update
    void Start()
    {
        adventureBtn = GameObject.Find("/Canvas/Menu/Aventure").GetComponent<Button>();
        optionsBtn = GameObject.Find("/Canvas/Menu/Options").GetComponent<Button>();
        quitBtn = GameObject.Find("/Canvas/Menu/Quitter").GetComponent<Button>();
        facileBtn = GameObject.Find("/Canvas/Difficulté/Facile").GetComponent<Button>();
        normalBtn = GameObject.Find("/Canvas/Difficulté/Normal").GetComponent<Button>();
        difficultBtn = GameObject.Find("/Canvas/Difficulté/Difficile").GetComponent<Button>();
        hardcorebtn = GameObject.Find("/Canvas/Difficulté/Hardcore").GetComponent<Button>();
        backBtn = GameObject.Find("/Canvas/Difficulté/Retour").GetComponent<Button>();
        volumeSld = GameObject.Find("/Canvas/Options/volume slider").GetComponent<Slider>();
        inputDropdown = GameObject.Find("/Canvas/Options/Clavier").GetComponent<Dropdown>();
        //this.manager = GameObject.Find("Manager").GetComponent<Manager>();
        scoresBtn = GameObject.Find("/Canvas/Menu/Scores").GetComponent<Button>();
        optionsMenu = GameObject.Find("/Canvas/Options");
        scoresMenu = GameObject.Find("/Canvas/Scores");
        mainMenu = GameObject.Find("/Canvas/Menu");
        difficultMenu = GameObject.Find("/Canvas/Difficulté");
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        panels = new List<GameObject>
        {
            optionsMenu,
            mainMenu,
            difficultMenu,
            scoresMenu
        };
        adventureBtn.onClick.AddListener(() => DisplayPanel("Difficulté"));
        optionsBtn.onClick.AddListener(() => DisplayPanel("Options"));
        scoresBtn.onClick.AddListener(() => DisplayPanel("Scores"));
        quitBtn.onClick.AddListener(() => QuitGame());
        facileBtn.onClick.AddListener(() => LoadLevel(1));
        normalBtn.onClick.AddListener(() => LoadLevel(2));
        difficultBtn.onClick.AddListener(() => LoadLevel(3));
        hardcorebtn.onClick.AddListener(() => LoadLevel(4));
        backBtn.onClick.AddListener(() => DisplayPanel("Menu"));
        volumeSld.value = 0.5f;
        audioSource.volume = 0.5f;
        volumeSld.onValueChanged.AddListener(delegate { OnVolumeChange(); });
        DisplayPanel("Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnVolumeChange()
    {
        audioSource.volume = volumeSld.value;
    }

    void LoadLevel(int level)
    {

        SceneManager.LoadScene("Level1");
        //this.manager.StartGame(level);
    }
    void DisplayPanel(string panelName)
    {
        foreach (var item in panels)
        {
            if (item.name == panelName)
            {
                item.SetActive(true);
                if (item.name != "Menu")
                {
                    backBtn = GameObject.Find(item.name + "/Retour").GetComponent<Button>();
                    backBtn.onClick.AddListener(() => DisplayPanel("Menu"));
                }
            }
            else
            {
                item.SetActive(false);
            }
        }
    }
    void QuitGame()
    {
        Application.Quit();
    }

    void WriteScores()
    {
        TextMeshProUGUI scoreTop1 = GameObject.Find("/Canvas/Scores/Top1/Score top1").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI scoreTop2 = GameObject.Find("/Canvas/Scores/Top2/Score top2").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI scoreTop3 = GameObject.Find("/Canvas/Scores/Top3/Score top3").GetComponent<TextMeshProUGUI>();

        scoreTop1.text = JsonUtility.FromJson<PlayerController>(path)._score.ToString();
        scoreTop2.text = JsonUtility.FromJson<PlayerController>(path)._score.ToString();
        scoreTop3.text = JsonUtility.FromJson<PlayerController>(path)._score.ToString();
    }
}

internal class ArrayList<T>
{
}