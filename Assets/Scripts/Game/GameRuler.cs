using UnityEngine;
using UnityEngine.Events;

public class GameRuler : MonoBehaviour
{
    [SerializeField] private Arrow arrow1;
    [SerializeField] private Roulette roulette;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private ScoreCounter scoreCounterBid;
    [SerializeField] private int userNumber = 0;


    public UnityEvent setUserNumberEvent;
    public UnityEvent arrowCoincidedEvent;
    public UnityEvent arrowNotCoincidedEvent;

    public void SetUserNumber(int value)
    {
        setUserNumberEvent?.Invoke();
        userNumber = value;
    }

    private void OnEnable()
    {
        roulette.endRotateEvent?.AddListener(GetResults);
    }

    private void OnDisable()
    {
        roulette.endRotateEvent.RemoveListener(GetResults);
    }

    public void GetResults()
    {
        if (arrow1.collidedObject.ID % 2 == 0)
        {
            scoreCounter.Add(scoreCounterBid.Score);
            arrowCoincidedEvent?.Invoke();
        }
        else
        {
            scoreCounter.TakeAway(scoreCounterBid.Score);
            arrowNotCoincidedEvent?.Invoke();
        }
    }

}
