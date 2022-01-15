using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public float converter;
    public float money = 0f;

    public Text tScore;
    private void Start() {
        money = PlayerPrefs.GetFloat("moneySaveShop");
    }
    private void Update()
    {
        if (converter >= 10)
        {
            money += 1;
            converter -= 10;
        }
        tScore.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void Save(){
        PlayerPrefs.SetFloat("moneySave", money);
        PlayerPrefs.Save();
    }

    private void OnDisable() {
        Save();
    }
}
