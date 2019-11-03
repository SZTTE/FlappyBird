using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private TextMesh scoreText;
    private TextMesh bestText;
    private SpriteRenderer medalRenderer;
    public GameOverScript instance;
    private bool isWaitingForRolliNG = false;
    public Sprite whitegoldMedal;
    public Sprite goldMedal;
    public Sprite silverMedal;
    public Sprite bronzeMedal;
    public AudioClip huSound;
    private AudioSource _audioSource;

    public void PlayHu()//由 Animation Event 唤醒
    {
        _audioSource.PlayOneShot(huSound);
    }

    public void ScoreRoll()//由 Animation Event 唤醒
    {
        isWaitingForRolliNG = true;
    }


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<TextMesh>();
        bestText = GameObject.Find("Best").GetComponent<TextMesh>();
        medalRenderer = GameObject.Find("Over_Medal").GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();

        bestText.text = GameManager.highestScore.ToString();
    }

    // Update is called once per frame
    int scoreShowing = 0;
    void Update()
    {
        //实现奖牌变化
        int score = GameManager.Instance.score;
        if (score >= 40) medalRenderer.sprite = whitegoldMedal;
        else if (score >= 30) medalRenderer.sprite = goldMedal;
        else if (score >= 20) medalRenderer.sprite = silverMedal;
        else if (score >= 10) medalRenderer.sprite = bronzeMedal;
        else medalRenderer.sprite = null;


        //实现分数滚动
        if (isWaitingForRolliNG && scoreShowing != GameManager.Instance.score)
        {
            scoreShowing++;
            scoreText.text = scoreShowing.ToString();
        }

        if (isWaitingForRolliNG && scoreShowing == GameManager.Instance.score)
            bestText.text = GameManager.highestScore.ToString();

    }
}
