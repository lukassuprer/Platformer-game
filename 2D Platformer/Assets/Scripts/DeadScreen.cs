using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadScreen : MonoBehaviour
{
    public GameObject restartButton;
    public GameObject mainMenu;
    public GameObject panel;
    private PlayerScript playerScript;

    private void Start()
    {
        playerScript = FindObjectOfType<PlayerScript>();
    }

    private void Update()
    {
        if (playerScript.isDead == true)
        {
            restartButton.SetActive(true);
            mainMenu.SetActive(true);
            panel.SetActive(true);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }
}