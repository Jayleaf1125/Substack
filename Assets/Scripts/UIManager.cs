using System.Collections;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text pickupText;
    [SerializeField] private TMP_Text pickupSuccessText;
    [SerializeField] private TMP_Text doorSuccessText;
    [SerializeField] private TMP_Text doorFailedText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pickupSuccessText.gameObject.SetActive(false);
        doorSuccessText.gameObject.SetActive(false);
        doorFailedText.gameObject.SetActive(false);
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
        GameObject text = pickupSuccessText.gameObject;

        pickupSuccessText.text = $"{itemName} has been added to inventory";
        text.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }

    public IEnumerator DoorSuccessVanishText()
    {
        GameObject text = doorSuccessText.gameObject;

        pickupSuccessText.text = $"Door Unlocked";
        text.SetActive(true);

        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }

    public IEnumerator DoorFailVanishText(string itemName)
    {
        GameObject text = doorFailedText.gameObject;

        pickupSuccessText.text = $"Requires {itemName}";
        text.SetActive(true);

        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
