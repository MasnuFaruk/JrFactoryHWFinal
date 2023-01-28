using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPower : MonoBehaviour
{
    [Header("PlayerPower")]
    [SerializeField] int powerValue = 1;

    [Header("UI Elements")]
    [SerializeField] TMP_Text powerText;
    [SerializeField] GameObject lostText; 

    

    [Header("Prefabs")]
    [SerializeField] GameObject playerBodyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        lostText.SetActive(false);
        powerText.text = powerValue.ToString();
        CreateNewBodies(powerValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPower(int increaseValue)
    {
        CreateNewBodies(increaseValue);
        powerValue += increaseValue;
        powerText.text = powerValue.ToString();
    }
    public void MultiplyPower(int multiplyValue)
    {
        CreateNewBodies((multiplyValue * powerValue) - powerValue);
        powerValue *= multiplyValue;
        powerText.text = powerValue.ToString();
    }
    private void CreateNewBodies(int bodyCount)
    {
        for (int i = 0; i< bodyCount; i++)
        {
            Instantiate(playerBodyPrefab, transform.position+RandomizePosition(), Quaternion.identity, transform);
        } 
    }
    public void BodyKilled()
    {
        powerValue--;
        powerText.text = powerValue.ToString();
        if(powerValue<=0)
        {
            GameOver();
        }
    }
    private Vector3 RandomizePosition()
    {
        return new Vector3(Random.Range(-0.8f, 0.8f), 0f, Random.Range(-0.5f, 0.5f));
    }

    private void GameOver()
    {
        GetComponent<PlayerMovement>().GamerOver();
        lostText.SetActive(true);
    }

    
}
