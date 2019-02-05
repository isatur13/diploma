using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameState : MonoBehaviour{

    public Text txt_GameOver;
    public Text txt_GO_Info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void GameOver()
    {
        txt_GameOver.gameObject.SetActive(true);
        txt_GO_Info.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Restart()
    {
        txt_GameOver.gameObject.SetActive(false);
        txt_GO_Info.gameObject.SetActive(false);
        SceneManager.LoadScene("scene1");
        Time.timeScale=1;
    }
}
