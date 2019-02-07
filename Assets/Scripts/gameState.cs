using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour{

    public  Text txt_GameOver;
    public  Text txt_GO_Info;
    public Button btn_Play;
    public Button btn_HTP;
    public Button btn_Settings;
    public Image img_background;
    public Button btn_restart;
    public Button btn_settingsp;
    public Button btn_pause;
    public Button btn_left;
    public Button btn_right;
    public Button btn_jump;
    public Canvas canvas_gameOver;

    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    public void GameOver()
    {
        canvas_gameOver.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void RestartfromDeath()
    {
        canvas_gameOver.gameObject.SetActive(false);
        SceneManager.LoadScene("scene1");
        Time.timeScale=1;
    }
    public void Restart()
    {
        Time.timeScale = 1;
        btn_settingsp.gameObject.SetActive(false);
        btn_restart.gameObject.SetActive(false);
        btn_pause.gameObject.SetActive(true);
        
    }
    public void Play()
    {
        img_background.gameObject.SetActive(false);
        btn_HTP.gameObject.SetActive(false);
        btn_Play.gameObject.SetActive(false);
        btn_Settings.gameObject.SetActive(false);
        btn_pause.gameObject.SetActive(true);
        btn_left.gameObject.SetActive(true);
        btn_right.gameObject.SetActive(true);
        btn_jump.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        btn_settingsp.gameObject.SetActive(true);
        btn_restart.gameObject.SetActive(true);
        btn_pause.gameObject.SetActive(false);

    }
}
