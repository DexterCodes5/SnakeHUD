using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Leaderboard : MonoBehaviour
{
    static int currentScore = 0;


    public GameObject firstPlaceText;
    public GameObject secondPlaceText;
    public GameObject thirdPlaceText;
    public GameObject fourthPlaceText;
    public GameObject fifthPlaceText;
    public GameObject sixthPlaceText;
    public GameObject seventhPlaceText;
    public GameObject eigthPlaceText;
    public GameObject ninethPlaceText;
    public GameObject tenthPlaceText;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = AppleCounter.appleValue; 
        if (currentScore > SnakeUI.scores[9])
        {
            SnakeUI.scores[9] = currentScore;
            //firstPlaceText.GetComponent<Text>().text = "" + SnakeUI.scores[0];

            SnakeUI.lives = 3;
            AppleCounter.appleValue = 0;
        }
        /*
        else if (currentScore > SnakeUI.scores[1])
        {
            SnakeUI.scores[1] = currentScore;
            //secondPlaceText.GetComponent<Text>().text = "" + SnakeUI.scores[1];

            SnakeUI.lives = 3;
            AppleCounter.appleValue = 0;
        }
        */
        int oldValue = 0;

        for (int i = 0; i < SnakeUI.scores.Length; i++)
        {
            if (SnakeUI.scores[9] > SnakeUI.scores[8])
            {
                oldValue = SnakeUI.scores[8];
                SnakeUI.scores[8] = SnakeUI.scores[9];
                SnakeUI.scores[9] = oldValue;
            }
            if (SnakeUI.scores[8] > SnakeUI.scores[7])
            {
                oldValue = SnakeUI.scores[7];
                SnakeUI.scores[7] = SnakeUI.scores[8];
                SnakeUI.scores[8] = oldValue;
            }
            if (SnakeUI.scores[7] > SnakeUI.scores[6])
            {
                oldValue = SnakeUI.scores[6];
                SnakeUI.scores[6] = SnakeUI.scores[7];
                SnakeUI.scores[7] = oldValue;
            }
            if (SnakeUI.scores[6] > SnakeUI.scores[5])
            {
                oldValue = SnakeUI.scores[5];
                SnakeUI.scores[5] = SnakeUI.scores[6];
                SnakeUI.scores[6] = oldValue;
            }
            if (SnakeUI.scores[5] > SnakeUI.scores[4])
            {
                oldValue = SnakeUI.scores[4];
                SnakeUI.scores[4] = SnakeUI.scores[5];
                SnakeUI.scores[5] = oldValue;
            }
            if (SnakeUI.scores[4] > SnakeUI.scores[3])
            {
                oldValue = SnakeUI.scores[3];
                SnakeUI.scores[3] = SnakeUI.scores[4];
                SnakeUI.scores[4] = oldValue;
            }
            if (SnakeUI.scores[3] > SnakeUI.scores[2])
            {
                oldValue = SnakeUI.scores[2];
                SnakeUI.scores[2] = SnakeUI.scores[3];
                SnakeUI.scores[3] = oldValue;
            }
            if (SnakeUI.scores[2] > SnakeUI.scores[1])
            {
                oldValue = SnakeUI.scores[1];
                SnakeUI.scores[1] = SnakeUI.scores[2];
                SnakeUI.scores[2] = oldValue;
            }
            if (SnakeUI.scores[1] > SnakeUI.scores[0])
            {
                oldValue = SnakeUI.scores[0];
                SnakeUI.scores[0] = SnakeUI.scores[1];
                SnakeUI.scores[1] = oldValue;
            }
        }

        firstPlaceText.GetComponent<Text>().text = "1. " + SnakeUI.scores[0];
        secondPlaceText.GetComponent<Text>().text = "2. " + SnakeUI.scores[1];
        thirdPlaceText.GetComponent<Text>().text = "3. " + SnakeUI.scores[2];
        fourthPlaceText.GetComponent<Text>().text = "4. " + SnakeUI.scores[3];
        fifthPlaceText.GetComponent<Text>().text = "5. " + SnakeUI.scores[4];
        sixthPlaceText.GetComponent<Text>().text = "6. " + SnakeUI.scores[5];
        seventhPlaceText.GetComponent<Text>().text = "7. " + SnakeUI.scores[6];
        eigthPlaceText.GetComponent<Text>().text = "8. " + SnakeUI.scores[7];
        ninethPlaceText.GetComponent<Text>().text = "9. " + SnakeUI.scores[8];
        tenthPlaceText.GetComponent<Text>().text = "10. " + SnakeUI.scores[9];

        StartCoroutine(Restart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
