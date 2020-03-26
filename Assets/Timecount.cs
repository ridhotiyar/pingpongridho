using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int counter = 30;
    public Text timerText;
    void Start()
    {
        timerText.text = counter.ToString();
        StartCoroutine(countdown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator countdown()
    {
        while(counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter --;
            timerText.text = counter.ToString();
        }

        timerText.text = "Game Over!";
        
    }
}
