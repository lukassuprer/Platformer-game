using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public float score = 0f;
    public float converter;
    public float money;
    private ShopManager shopManager;
    public Text tScore;
    private void Start() {
        //money = PlayerPrefs.GetFloat("SaveShop");
        //Debug.Log(money);
    }
    private void Update()
    {
        if (converter >= 10)
        { 
            ScoreSave.money += 1;
            converter -= 10;
            Save();
        }
        tScore.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void Save(){
        PlayerPrefs.SetFloat("moneySaveShop", money);
        PlayerPrefs.Save();
    }
}
