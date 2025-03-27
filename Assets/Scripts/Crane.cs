using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Crane : MonoBehaviour
{
    [SerializeField] private Follow cameraFollow;
    [Space]
    [SerializeField] private StackLevel currentLevel;
    [SerializeField] private GameObject baseBlock;
    [SerializeField] private Transform spawnPoint;
    [Space]
    [SerializeField] private TMP_InputField inputField;


    [SerializeField] private UnityEvent blockPlaced;

    private int stackPointer;

    private GameObject currentBlock;

    private Coroutine blockFallWait;

    // Start is called before the first frame update
    void Start()
    {
        stackPointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.instance.IsGameOver() || currentBlock == null) return;

        if (Input.GetMouseButtonDown(0))
        {
            Drop(currentBlock);
            if (stackPointer < currentLevel.GetBlockCount())
            {
                blockFallWait = StartCoroutine(WaitForBlockFall());
                if (stackPointer > 4) cameraFollow.Move();
            } else
            {
                Manager.instance.TriggerWinGame();
            }
        }
    }

    // This should be a separate class but I'm speedrunning this
    public void CheckAnswer()
    {
        if (inputField.text.Trim().ToUpper() == currentLevel.GetBlock(stackPointer).name)
        {
            NextBlock();
        }
        else
        {
            Manager.instance.TriggerLoseGame($"Correct answer was: {currentLevel.GetBlock(stackPointer).name}");
        }
    }

    public void CancelBlockFallWait()
    {
        if (blockFallWait != null) StopCoroutine(blockFallWait);
    }

    private void NextBlock()
    {
        currentBlock = NewBlock(currentLevel.GetBlock(stackPointer++));
    }

    private void Drop(GameObject block)
    {
        currentBlock = null;
        block.transform.SetParent(null);

        Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
        rb.simulated = true;
    }

    private GameObject NewBlock(Sprite sprite)
    {
        GameObject newBlock = Instantiate(baseBlock, spawnPoint.transform.position, Quaternion.identity, transform);
        newBlock.GetComponent<SpriteRenderer>().sprite = sprite;
        newBlock.name = sprite.name;

        return newBlock;
    }

    private IEnumerator WaitForBlockFall()
    {
        yield return new WaitForSeconds(3);
        blockPlaced.Invoke();
    }
}
