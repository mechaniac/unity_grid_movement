using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MyGridNS;
using System;

public class BattleSystem : MonoBehaviour
{
    [SerializeField]
    MyGrid myGrid;
    float lastTime;
    MyInputActions myInputActions;
    Vector2 moveInput;
    public BATTLESTATE battleState;

    FactionType currentPlayer;
    Unit currentUnit;

    int playerIndex = 0;
    int enemyIndex = 0;

    private void Awake()
    {

        myInputActions = new MyInputActions();

        myInputActions.playerMap.MoveButton.performed += ctx => OnMoveButtonPress();
        myInputActions.playerMap.NextUnit.performed += ctx => OnNextUnitPress();
        myInputActions.playerMap.PreviousUnit.performed += ctx => OnPreviousUnitPress();
    }
    void Start()
    {
        battleState = BATTLESTATE.START;
        StartCoroutine(InitializeGame());
    }
    private void Update()
    {
        if (battleState == BATTLESTATE.PLAYERTURN)
        {
            PlayerMoveCursor();
        }

    }

    private void OnEnable()
    {
        myInputActions.Enable();
    }
    private void OnDisable()
    {
        myInputActions.Disable();
    }

    //-------------------METHODS-------------------

    IEnumerator InitializeGame()
    {
        myGrid.InitiializeGame();
        yield return new WaitForSeconds(1f); //wait for 1 Second, then proceed
        currentUnit = myGrid.units[0][0];
        PlayerTurn();
    }

    void PlayerTurn()
    {
        battleState = BATTLESTATE.PLAYERTURN;
        currentPlayer = FactionType.Player;
        myGrid.DisplayMove(currentUnit);
    }

    void EnemyTurn()
    {
        battleState = BATTLESTATE.ENEMYTURN;
        currentPlayer = FactionType.Enemy;
        currentUnit = myGrid.units[1][0];
        myGrid.DisplayMove(currentUnit);
        Debug.Log("todo: implement AI");
    }
    

    private void OnPreviousUnitPress()
    {
        
        playerIndex--;
        if (playerIndex < 0) playerIndex = myGrid.units[0].Count - 1;
        Debug.Log($"playerindex = {playerIndex}");
        myGrid.DisplayMove(myGrid.units[0][playerIndex]);

    }


    private void OnNextUnitPress()
    {
        playerIndex++;
        if (playerIndex >= myGrid.units[0].Count) playerIndex = 0;
        //Debug.Log($"playerindex = {playerIndex}");
        myGrid.DisplayMove(myGrid.units[0][playerIndex]);
    }

    private void OnMoveButtonPress()
    {
        if (battleState == BATTLESTATE.PLAYERTURN)
        {
            foreach (var cell in myGrid.myGridTraversal.currentAvailableMoves)
            {
                if (Vector3.Equals(cell.position, myGrid.myGridInterface.GetCursorPosition()))
                {
                    if(cell.occupantType != null)
                    {
                        if(cell.faction == FactionType.Player)
                        {
                            Debug.Log("Cannot attack own faction");
                            return;
                        }
                        Attack(currentUnit, cell.occupant);
                        EnemyTurn();
                        return;
                    }
                    myGrid.units[0][0].MoveTo(myGrid.myGridInterface.GetCursorPosition());
                    EnemyTurn();
                }
            }
        }
    }

    private void Attack(Unit a, Unit b)
    {
        if(b == null)
        {
            Debug.Log("attacking null");
            return;
        }
        b.currentHealth--;
        if(b.currentHealth >= 1)
        {
            StartCoroutine(b.ColorFlash(Color.red));
        }
        
        if(b.currentHealth <= 0)
        {
            myGrid.RemoveUnit(b);
        }

    }


    void PlayerMoveCursor()//positions Cursor via Vector2 input
    {
        float margin = .4f;
        float timeBetweenRegisters = .3f;

        var moveDirection = myInputActions.playerMap.MoveCursor.ReadValue<Vector2>();

        float x = moveDirection.x;
        float y = moveDirection.y;


        if (lastTime + timeBetweenRegisters >= Time.time) return;
        if (Mathf.Abs(x) < margin && Mathf.Abs(y) < margin) return;
        lastTime = Time.time;
        float xOut = 0f;
        float yOut = 0f;

        if (x > margin)
        { xOut = 1; } //RIGHT
        if (x < -margin)
        { xOut = -1; } //LEFT
        if (y > margin)
        { yOut = 1; } //UP
        if (y < -margin)
        { yOut = -1; } //DOWN

        var mOut = new Vector3(xOut, 0, yOut);
        myGrid.myGridInterface.OffsetCursor(mOut);

    }






}

public enum BATTLESTATE
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}
