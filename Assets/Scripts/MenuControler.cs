using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; //libreria para cambio de scene
public class MenuControler : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI highScoreText;
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore"); //este es el complemento de setint
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        SceneManager.LoadScene("Game");//cambio de scene
    }

    public void quitGame()
    {
        Application.Quit();//instruccion para cerrar la aplicacion
    }
}
