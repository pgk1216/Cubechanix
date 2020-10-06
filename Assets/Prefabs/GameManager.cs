using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public PlayerMovement movement;

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

    public void GameOver()
    {
        if(!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        movement.flashCoolDown = 0f;
        movement.flashIsOnCD = false;

        movement.jumpCoolDown = 0f;
        movement.jumpIsOnCD = false;
    }
}
