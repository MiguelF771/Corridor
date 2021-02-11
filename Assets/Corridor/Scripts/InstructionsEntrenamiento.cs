using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionsEntrenamiento : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject[] images;

    private void OnEnable()
    {
        StartCoroutine(StartPhase());
    }

    IEnumerator StartPhase()
    {
        text.text = Instructions.instance.GetInstruction(7);
        yield return new WaitForSeconds(1.5f);
        text.text = Instructions.instance.GetInstruction(8);
        images[0].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        images[0].SetActive(false);
        text.text = Instructions.instance.GetInstruction(9);
        images[1].SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
