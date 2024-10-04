using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    //Points and Obstacles GO
    [SerializeField] private GameObject[] blueGo;
    [SerializeField] private GameObject[] redGo;
    
    //To instantiate Points and Obstacles
    [SerializeField] private float startWait;
    [SerializeField] private float spawnWait;
    
    //which Go to instantiate
    private GameObject _blue, _red;
    
    //spawn positions - randomly X position
    private readonly float[] _xPosition = new float[2] {.7f , 2f};
    public bool gameOverBool;

    private int _score;
    [SerializeField] private TextMeshProUGUI scoreText;

    //[SerializeField] private GameObject startGameCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    private void Start()
    {
        gameOverBool = true;
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
    }
    private void Update()
    {
    }

    IEnumerator SpawnObjects()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                /*RED*/
                //choosing X position
                float redXpos = _xPosition[Random.Range(0, _xPosition.Length)];
                
                //setting position
                Vector3 redPos = new Vector3(redXpos, 10, 0);
                
                //choosing between Points or Obstacles
                _red = redGo[Random.Range(0, redGo.Length)] as GameObject;
                
                //Instantiate now
                Instantiate(_red, redPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
                
                /*BLUE*/
                //choosing X position
                float blueXpos =- _xPosition[Random.Range(0, _xPosition.Length)];
                
                //setting position
                Vector3 bluePos = new Vector3(blueXpos, 10, 0);
                
                //choosing between Points or Obstacles
                _blue = blueGo[Random.Range(0, blueGo.Length)] as GameObject;
                
                //Instantiate now
                Instantiate(_blue, bluePos, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    public void StartGame()
    {
        gameOverBool = false;
        StartCoroutine(SpawnObjects());
        
    }
    public void GameOver()
    {
        gameOverBool = true;
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
    }

    public void AddScore()
    {
        _score += 1;
        scoreText.text = _score.ToString();
    }

    public void RestartGame()
    {
        gameOverBool = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
