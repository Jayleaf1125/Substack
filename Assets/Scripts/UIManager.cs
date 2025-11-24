using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pickupText;
    [SerializeField] private TMP_Text pickupSuccesText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupSuccesText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsPickupTextActive(bool val) => pickupText.gameObject.SetActive(val);

    public void DisplayPickupSuccess(string itemName)
    {
        StartCoroutine(PickupSuccessVanishText(itemName));
    }

    public IEnumerator PickupSuccessVanishText(string itemName)
    {
        GameObject text = pickupSuccesText.gameObject;

        pickupSuccesText.text = $"{itemName} has been added to inventory";
        text.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
