using UnityEngine;
using UnityEngine.UI;

public class Controller_Hud : MonoBehaviour
{
    public float maxTimeUntilLose;
    public static float timeUntilLose;
    public static bool gameOver = false;
    public Text distanceText;
    public Text gameOverText;
    public Text bestTimeText;
    public static float distance = 0;

    public static float bestSavedDistance;


    void Start()
    {
        BarraDeProgreso.cont = 100;
        timeUntilLose = maxTimeUntilLose;
        gameOver = false;
        distance = 0;
        distanceText.text = distance.ToString();
        gameOverText.gameObject.SetActive(false);
        bestTimeText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver) //Si perdio el player entonces mostrar resultados de partida
        {
            Time.timeScale = 0;
            gameOverText.text = "Game Over \n Total Distance: " + distance.ToString("0.00");
            bestTimeText.text = "Best Score " + AlmacenarDatos.puntuacion.ToString("0.00");
            gameOverText.gameObject.SetActive(true);
            bestTimeText.gameObject.SetActive(true);
        }
        else //Si no, seguir contando puntos para arriba
        {
            distance += Time.deltaTime;
            distanceText.text = distance.ToString("f0");
        }
    }
}
