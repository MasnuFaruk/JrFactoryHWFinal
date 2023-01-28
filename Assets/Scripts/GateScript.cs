using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateScript : MonoBehaviour
{
    [Header("Gate Type")]
    [SerializeField] bool isMultiplier;
    [SerializeField] bool isAdditive;

    [Header("Values")]
    [SerializeField] int multiplyValue;
    [SerializeField] int additiveValue;

    [Header("UI Elements")]
    [SerializeField] TMP_Text text;
    private void Awake()
    {
        text.text = "";
    }
    private void Start()
    {
       
        if (isAdditive)
        {
            text.text += "+" + additiveValue;
        }
        if (isMultiplier)
        {
            
            text.text += "X"+multiplyValue;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isAdditive)
            {
                other.GetComponent<PlayerPower>().AddPower(additiveValue);
                
            }
            if (isMultiplier)
            {
                other.GetComponent<PlayerPower>().MultiplyPower(multiplyValue);
            }
            Destroy(transform.parent.gameObject);
        }
    }



}
