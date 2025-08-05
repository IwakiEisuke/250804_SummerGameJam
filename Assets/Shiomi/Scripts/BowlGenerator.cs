using System.Runtime.CompilerServices;
using UnityEngine;

public class BowlGenerator : MonoBehaviour
{
    [SerializeField] private Transform _firstLeftPos;
    [SerializeField] private Transform _firstRightPos;
    [SerializeField] private float _widthInterval;
    [SerializeField] private float _verticalInterval;
    [SerializeField] private int[] _firstBowlIntervalCount;
    [SerializeField] private GameObject[] _bowlObjects;

    [SerializeField] private BowlCounter _bowlCounter;
    
    private int indexCounter = 0;
    private int _currentBowlCount = 0;


    public void GenerateBowl()
    {
        int currentBowlCount = _bowlCounter.bowlCount;
    }
}