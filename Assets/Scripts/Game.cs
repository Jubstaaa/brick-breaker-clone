using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI guessedText;
    [SerializeField] TextMeshProUGUI guessedNumberText;
    [SerializeField] TMP_InputField guessInput;
    [SerializeField] Button guessButton;
    int  number;
     SceneCheck sceneCheck = new SceneCheck();

    void Start()

    {
        guessButton.interactable = false;
        StartGame();
    }

    public void StartGame()
    {
        number = Random.Range(0, 9999);
    }

    public void CheckGuessedNumber(string guessedNumber, TextMeshProUGUI textObject )
    {
        if (int.Parse(guessedNumber) < number)
        {
            textObject.text = "Increase ↑";
            textObject.color = Color.green;
            guessedText.text = guessInput.text;
            guessInput.text = "";
        }
        else if(int.Parse(guessedNumber)> number)
        {
            textObject.text = "Decrease ↓";
            textObject.color = Color.red;
            guessedText.text = guessInput.text;
            guessInput.text = "";
        }
        else if (int.Parse(guessedNumber) == number)
        {
            sceneCheck.NextScene();

        }
       
        guessInput.ActivateInputField();

    }

    public void Guess()
    {
   
         CheckGuessedNumber(guessInput.text, guessedNumberText);
       
    }

    public void CheckButtonDisabled()
    {

        if (string.IsNullOrEmpty(guessInput.text))
        {
            guessButton.interactable = false; 
        }
        else
        {
            guessButton.interactable = true;
        }
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Return) && guessButton.IsInteractable())
        {
            Guess();
        }
        

    }
}
