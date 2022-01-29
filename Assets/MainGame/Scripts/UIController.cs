using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    [SerializeField] List<Transform> positions;
    [SerializeField] GameObject startingText;
    [SerializeField] GameObject IntroducingText;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject IntroducingParentPanel;
    [SerializeField] Animator panelAnimator;
    [SerializeField] Transform fadedImage;
    public int clickCount = 10;

    private void Start()
    {
        StartCoroutine(ShowAndHideStartingText());
    }
    public void PickRandomPosition()
    {
        clickCount--;
        if(clickCount > 0)
        {
            fadedImage.gameObject.SetActive(false);
            int rand = Random.Range(0, 5);
            for (int i = 0; i < positions.Count; i++)
            {
                fadedImage.position = positions[rand].position;
                fadedImage.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("You have Collected My Soul!");
            fadedImage.gameObject.SetActive(false);
            StartCoroutine(ReadyToStartText());
        }
    }
    IEnumerator ShowAndHideStartingText()
    {
        yield return new WaitForSeconds(2.0f);
        startingText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        startingText.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        fadedImage.gameObject.SetActive(true);

    }

    IEnumerator ReadyToStartText()
    {
        yield return new WaitForSeconds(1.0f);
        startingText.GetComponent<TextMeshProUGUI>().text = "YOU DID GREAT! \n HMM... I THINK I'M READY TO GO.";
        startingText.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        startingText.SetActive(false);
        panelAnimator.enabled = true;
        IntroducingParentPanel.SetActive(true);
        IntroducingText.SetActive(true);

        yield return new WaitForSeconds(8.5f);
        IntroducingParentPanel.SetActive(false);
        buttons.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
