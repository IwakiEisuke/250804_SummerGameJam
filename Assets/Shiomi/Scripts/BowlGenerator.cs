using DG.Tweening;
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
    
    private int _indexCounter = 0;
    private int _currentBowlCount = 0;
    private int _rowIndex = 0;
    private int _lineIndex = 0;
    private bool _isRight = true;

    private void Start()
    {
        _currentBowlCount += _firstBowlIntervalCount[_indexCounter];
    }

    public void GenerateBowl()
    {
        if (_indexCounter >= _bowlObjects.Length)
            return;

        //ボールをカウント
        int currentBowlCount = _bowlCounter.bowlCount;

        if(currentBowlCount == _currentBowlCount)
        {

            if(_isRight)
            {
                Instantiate(_bowlObjects[_indexCounter], 
                    new Vector3(_firstRightPos.position.x + _widthInterval * _rowIndex, _firstRightPos.position.y, 
                    _firstRightPos.position.z + _verticalInterval *_lineIndex), Quaternion.identity);

                _isRight = false;
                Debug.Log("お椀生成");
            }
            else
            {
                Instantiate(_bowlObjects[_indexCounter],
                    new Vector3(_firstLeftPos.position.x - _widthInterval * _rowIndex, _firstLeftPos.position.y,
                    _firstLeftPos.position.z + _verticalInterval * _lineIndex), Quaternion.identity);

                _rowIndex ++;
                _isRight = true;

                if (_rowIndex >= 3)
                {
                    _lineIndex++;
                    _indexCounter++;
                    _rowIndex = 0;
                }

                Debug.Log("お椀生成");
            }

            _currentBowlCount += _firstBowlIntervalCount[_indexCounter];
        }
    }
}