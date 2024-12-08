using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject AsteroideFuego;
    public GameObject AsteroideToxico;
    public GameObject Boss;
    public float asteroidSpawnTime =0.5f;
    public Player player;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI scoreText;

    int score = 0;
    void Start()
    {
        StartCoroutine(spawnAsteroids());//llamar la cortina
        StartCoroutine(spawnAsteroideFuego());
        StartCoroutine(spawnAsteroideToxico());
        SpawnBoss();
    }
    IEnumerator spawnAsteroids() //cortina
    {
        while (true)
        {
            yield return new WaitForSeconds(asteroidSpawnTime); //Crea el codigo que este debajo de el despues de "n" segundos
            //Aqui creamos el asteroide
            if(asteroidSpawnTime > 0.2f)
            {
                asteroidSpawnTime -= 0.05f;
            }
            Instantiate(asteroid);//  Instantiate: Para duplicar un objeto en particular
        }

    }
    IEnumerator spawnAsteroideFuego() 
    {
        while (true)
        {
            yield return new WaitForSeconds(asteroidSpawnTime);
            if (asteroidSpawnTime > 0.2f)
            {
                asteroidSpawnTime -= 0.05f;
            }
            Instantiate(AsteroideFuego);
        }
    }
    IEnumerator spawnAsteroideToxico()
    {
        while (true)
        {
            yield return new WaitForSeconds(asteroidSpawnTime);
            if (asteroidSpawnTime > 0.2f)
            {
                asteroidSpawnTime -= 0.05f;
            }
            Instantiate(AsteroideToxico);
        }
    }
    public void SpawnBoss()
    {
        Instantiate(Boss);
    }

    void Update()
    {
        hpText.text = "HP: " + player.hp;
    }

    public void lose()
    {
        Debug.Log("Perdiste mi chava, ahora debes a coopel");
        loseText.enabled = true;
        int highScore = PlayerPrefs.GetInt("HighScore");
        if(score > highScore)
        {
         PlayerPrefs.SetInt("HighScore", score); //en´primer vallor, entre las comillas es para ponerle un nombre, los set es igual a la variable que vas a poner
        }
        
        StartCoroutine(LoseRoutine());
    }
    
    IEnumerator LoseRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("MainMenu");
    }
    public void incrementScore(int val)
    {
        score += val;
        scoreText.text = "Asesinatos: " + score;
    }
}
