using System.Collections;
using TMPro;
using UnityEngine;

public class InstructionsEntrenamiento : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterController player;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject[] images;
    [SerializeField]
    private Door principalDoor;
    private void OnEnable()
    {
        StartCoroutine(StartPhase());
        player.maxSpeedOnGround = 0;
    }
    private bool startCorridor = false;
    public void StartCorridor()
    {
        startCorridor = true;
    }
    public bool isMidle = false;

    public void Midle()
    {
        isMidle = true;
    }
    IEnumerator StartPhase()
    {
        images[2].SetActive(true);
        text.text = Instructions.instance.GetInstruction(7);
        yield return new WaitForSeconds(1.5f);

        //Detect Mouse move
        {
            text.text = Instructions.instance.GetInstruction(9);
            images[1].SetActive(true);
            yield return new WaitUntil(() =>
            {
                return Input.GetAxis("Mouse X") < -1 || Input.GetAxis("Mouse X") > 1;
            });
        }
        //Good job
        images[1].SetActive(false);
        text.text = Instructions.instance.GetInstruction(10);
        yield return new WaitForSeconds(1f);

        //Detect Key W press
        {
            text.text = Instructions.instance.GetInstruction(8);
            images[0].SetActive(true);
            yield return new WaitUntil(() =>
            {
                return Input.GetKeyDown(KeyCode.W);
            });
        }
        player.maxSpeedOnGround = 1.4f;

        yield return new WaitUntil(()=> {
            return isMidle;
        });
        //Good job
        images[0].SetActive(false);
        text.text = Instructions.instance.GetInstruction(10);
        yield return new WaitForSeconds(1.5f);

        images[2].SetActive(true);
        images[3].SetActive(true);
        text.text = Instructions.instance.GetInstruction(12);
        yield return new WaitForSeconds(3f);

        images[3].SetActive(false);
        images[2].SetActive(false);
        text.text = "";
        yield return new WaitUntil(() =>
        {
            return startCorridor;
        });

        images[2].SetActive(true);
        text.text = Instructions.instance.GetInstruction(13);
        player.maxSpeedOnGround = 0;
        yield return new WaitForSeconds(8f);
        text.text = Instructions.instance.GetInstruction(11);
        yield return new WaitForSeconds(5f);

        player.maxSpeedOnGround = 1.4f;
        principalDoor.OpenDoor();

        gameObject.SetActive(false);
    }
}
