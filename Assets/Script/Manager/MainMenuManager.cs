using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    //[SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _bestScoreText;


    private void Awake() 
    {
        _bestScoreText.text = GameManager.Instance.HighScore.ToString();

        if(!GameManager.Instance.IsInitialized)
        {
           //_scoreText.gameObject.SetActive(false);
            _bestScoreText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;    

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _bestScoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        int HighScore = GameManager.Instance.HighScore;

        if(HighScore < currentScore)
        {
            _bestScoreText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            //_bestScoreText.gameObject.SetActive(false);
        }

        float speed =  1 / _animationTime;
        float timeElapsed = 0f;

        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _bestScoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        _bestScoreText.text = tempScore.ToString();
    }

    [SerializeField] private AudioClip _clickClip;

    public void ClickedPlay()
    {
        SoundManager.Instance.PlaySound(_clickClip);
        GameManager.Instance.GoToGameplay();
        Debug.Log("Clicked");
    }
}
