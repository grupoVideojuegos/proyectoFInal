using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField]int numMuertes = 0;
    [SerializeField] TextMeshProUGUI deaths;


    /*
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }*/
    // Start is called before the first frame update
    void Start()
    {
        deaths.text = numMuertes.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addDeath()
    {
        numMuertes++;
        deaths.text = numMuertes.ToString();
    }
}
