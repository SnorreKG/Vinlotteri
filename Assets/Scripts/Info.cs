using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public ParticleSystem confetti_1;
    public ParticleSystem confetti_2;

    public GameObject resultCamera;
    public GameObject startCamera;

    public GameObject trapDoor;
    public GameObject trapDoorButton;
    public GameObject ballDetectorStart;

    private int number_win;

    private bool roundComplete;

    private float autoStartTimerFloat;
    public float timeForAutoStart = 15f;

    public GameObject NextRoundLoadingBar;
    public RectTransform LoadingBarFilledTexture;
    private bool LoadLoadingBar;


    private List<int> numbers = new List<int>();
    private List<int> win_numbers = new List<int>();

    public List<GameObject> balls_1to9 = new List<GameObject>();
    public List<Transform> ballSpawnPoint = new List<Transform>();

    public Text[] numberText = new Text[4];

    void Start()
    {
        SwitchToIntroCamera();

        roundComplete = false;
        trapDoor.SetActive(true);
        trapDoorButton.SetActive(true);

        NextRoundLoadingBar.SetActive(false);
        LoadLoadingBar = false;
    }

   
    void Update()
    {
        for (int i = 0; i < numberText.Length; i++)
        {
            if (i < numbers.Count)
            {
                numberText[i].text = numbers[i].ToString();
            }
            else
            {
                numberText[i].text = "-";
            }
        }

        if (numbers.Count == 4 && !roundComplete)
        {
            RoundComplete();
        }

        AutoStartTimer();
        if (LoadLoadingBar)
            LoadNextRoundLoadingBar();
    }
    
    public void GetNumber(int _number)
    {
        if (numbers.Count < 4)
        {
            numbers.Add(_number);
            
        }
        
    }

    public void StartRound()
    {
        string _lowRanNumberString = PlayerPrefs.GetString("HNS");
        string _highRanNumberString = PlayerPrefs.GetString("LNS");

        int _lowRanNumberInt = int.Parse(_lowRanNumberString);
        int _highRanNumberInt = int.Parse(_highRanNumberString);

        number_win = Random.Range(_lowRanNumberInt, _highRanNumberInt);

        SwitchToResultCamera();
        SpawnSpheres();
         
    }

    private void SpawnSpheres()
    {
        string _winNumbers = number_win.ToString();
        
        for (int i = 0; i < _winNumbers.Length; i++)
        {
            char _winNumberChar = _winNumbers[i];
            string _winNumberStringDigit = _winNumberChar.ToString();
            int _currentWinDigit = int.Parse(_winNumberStringDigit);
            if (_winNumbers.Length < 4)
            {
                int _0sToAdd = 4 - _winNumbers.Length;
                for (int h = 0; h < _0sToAdd; h++)
                {
                    win_numbers.Add(0);
                }
            }
            win_numbers.Add(_currentWinDigit);

        }

        for (int i = 0; i < win_numbers.Count; i++)
        {
            Instantiate(balls_1to9[win_numbers[i]], ballSpawnPoint[i]);
        }
    }

    private void RoundComplete()
    {
        roundComplete = true;
        autoStartTimerFloat = timeForAutoStart;

        confetti_1.Play();
        confetti_2.Play();

        confetti_1.gameObject.GetComponent<AudioSource>().Play();
        confetti_2.gameObject.GetComponent<AudioSource>().Play();

    }

    private void AutoStartTimer()
    {
        if (roundComplete)
        {
            LoadLoadingBar = true;
            if (autoStartTimerFloat <= 0f)
            {
                RestartRound();
            }
            else
            {
                autoStartTimerFloat -= Time.deltaTime;
            }
        }
    }

    private void RestartRound()
    {
        gameObject.GetComponent<SwitchScene>().SwitchToGameScene();
    }

    private void LoadNextRoundLoadingBar()
    {
        NextRoundLoadingBar.SetActive(true);


        LoadingBarFilledTexture.sizeDelta = new Vector2(autoStartTimerFloat * 10, LoadingBarFilledTexture.sizeDelta.y);
    }

    public void StartButtonClick()
    {
        trapDoor.SetActive(false);
        trapDoorButton.SetActive(false);
    }

    public void SwitchToIntroCamera()
    {
        resultCamera.SetActive(false);
        startCamera.SetActive(true);

    }

    public void SwitchToResultCamera()
    {
        resultCamera.SetActive(true);
        startCamera.SetActive(false);
    }
}
