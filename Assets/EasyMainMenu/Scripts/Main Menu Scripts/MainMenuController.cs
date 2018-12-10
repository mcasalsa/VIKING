using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    Animator anim;

    public string newGameSceneName;
    public int quickSaveSlotID;

    [Header("Options Panel")]
    public GameObject MainOptionsPanel;
    public GameObject StartGameOptionsPanel;
    public GameObject GamePanel;
    public GameObject ControlsPanel;
    public GameObject GfxPanel;
    public GameObject LoadGamePanel;
    public GameObject _GameOptions;
    public GameObject OptionsSoundMenu;
    public GameObject Instructions;
    public AudioClip clickSound;
    // public AudioClip ambientSound;
    AudioSource audioSource;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Instructions.SetActive(false);
        _GameOptions.SetActive(false);
        OptionsSoundMenu.SetActive(false);
        //new key
        PlayerPrefs.SetInt("quickSaveSlot", quickSaveSlotID);
        
    }

    #region Open Different panels

    public void openOptions()
    {
        //enable respective panel
        _GameOptions.SetActive(false);
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);
        Instructions.SetActive(false);

        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }

    public void openStartGameOptions()
    {
        //enable respective panel
        _GameOptions.SetActive(false);
        MainOptionsPanel.SetActive(false);
        StartGameOptionsPanel.SetActive(true);
        Instructions.SetActive(false);
        //play anim for opening main options panel
        anim.Play("buttonTweenAnims_on");

        //play click sfx
        playClickSound();

        //enable BLUR
        //Camera.main.GetComponent<Animator>().Play("BlurOn");

    }

    public void openOptions_Game()
    {
        //enable respective panel
        _GameOptions.SetActive(false);
        GamePanel.SetActive(true);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);
        Instructions.SetActive(false);
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openInstructionss_Game()
    {
        //enable respective panel
        _GameOptions.SetActive(false);
        MainOptionsPanel.SetActive(true);
        StartGameOptionsPanel.SetActive(false);
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        //LoadGamePanel.SetActive(false);
        Instructions.SetActive(true);
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }


    public void openOptions_Controls()
    {
        _GameOptions.SetActive(false);
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(true);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(false);
        Instructions.SetActive(false);
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }
    public void openOptions_Gfx()
    {
        _GameOptions.SetActive(false);
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(true);
        LoadGamePanel.SetActive(false);
        Instructions.SetActive(false);
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void openContinue_Load()
    {
        _GameOptions.SetActive(false);
        //enable respective panel
        GamePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        GfxPanel.SetActive(false);
        LoadGamePanel.SetActive(true);
        Instructions.SetActive(false);
        //play anim for opening game options panel
        anim.Play("OptTweenAnim_on");

        //play click sfx
        playClickSound();

    }

    public void newGame()
    {
        if (!string.IsNullOrEmpty(newGameSceneName))
            SceneManager.LoadScene(newGameSceneName);
        else
            Debug.Log("Please write a scene name in the 'newGameSceneName' field of the Main Menu Script and don't forget to " +
                "add that scene in the Build Settings!");
    }

    public void MainMenu()
    {
        
            SceneManager.LoadScene("MainMenu");
        
    }
    #endregion

    #region Back Buttons

    public void back_options()
    {
        _GameOptions.SetActive(false);
        //simply play anim for CLOSING main options panel
        anim.Play("buttonTweenAnims_off");

        //disable BLUR
        // Camera.main.GetComponent<Animator>().Play("BlurOff");

        //play click sfx
        playClickSound();
    }

    public void back_options_panels()
    {
        _GameOptions.SetActive(false);
        OptionsSoundMenu.SetActive(false);
        //simply play anim for CLOSING main options panel
        anim.Play("OptTweenAnim_off");

        //play click sfx
        playClickSound();

    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Sounds
    public void playHoverClip()
    {

    }

    void playClickSound()
    {
        //AudioClip clipToPlay = menuTheme;
        //clipToPlay = menuTheme;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clickSound;
        audioSource.Play();
        // AudioClip clipToPlay;


        //clipToPlay = "menuTheme";
        //AudioManager.instance.PlayMusic(clickSound, 1);



        #endregion
    }
}
