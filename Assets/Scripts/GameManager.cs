using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Choice Display Images")]
    public Image imgYou;
    public Image imgCom;

    [Header("Sprites (1=Rock, 2=Paper, 3=Scissors)")]
    public Sprite rockSprite;  
    public Sprite paperSprite;   
    public Sprite scissorSprite; 

    [Header("UI Texts")]
    public TMP_Text txtResult;
    public TMP_Text txtScoreYou;
    public TMP_Text txtScoreCom;

    private int scoreYou = 0;
    private int scoreCom = 0;

    public void OnButtonClick(GameObject buttonObject)
    {
        int you = int.Parse(buttonObject.name.Substring(0, 1));

        // Computer random choice (1, 2, or 3)[cite: 33]
        int com = Random.Range(1, 4);

        UpdateChoiceImage(imgYou, you);
        UpdateChoiceImage(imgCom, com);
        CheckResult(you, com);
    }

    private void UpdateChoiceImage(Image targetImage, int choice)
    {
        targetImage.rectTransform.localRotation = Quaternion.Euler(0, 0, 90);

        if (choice == 1) targetImage.sprite = rockSprite;
        else if (choice == 2) targetImage.sprite = paperSprite;
        else if (choice == 3) targetImage.sprite = scissorSprite;
    }

    private void CheckResult(int you, int com)
    {
        int k = you - com; 

        if (k == 0)
        {
            txtResult.text = "It's a Tie!";
        }
        else if (k == 1 || k == -2)
        {
            txtResult.text = "You Win!";
            scoreYou++;
            txtScoreYou.text = scoreYou.ToString();
        }
        else
        {
            txtResult.text = "Computer Wins!";
            scoreCom++;
            txtScoreCom.text = scoreCom.ToString();
        }
    }
}