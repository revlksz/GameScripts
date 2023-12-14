using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float obstacleSpeed;
    public VariableHandlerObject variableHandler;

    private Vector3 _dynamicSpeed;
    private float _speedMultiplier;
    private const float DestructionCoordinate = -12f;
    private float _spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        _speedMultiplier = _speedMultiplier = variableHandler.SpeedMultiplier.multiplierValue;
        StartCoroutine(UpdateSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            //_dynamicSpeed = Vector3.left  * (_speedMultiplier * obstacleSpeed);
            transform.Translate(_dynamicSpeed * Time.deltaTime);
        }
        
        if (transform.position.x < DestructionCoordinate)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator UpdateSpeed()
    {

        while (true)
        {
            _speedMultiplier = _speedMultiplier = variableHandler.SpeedMultiplier.multiplierValue;
            _dynamicSpeed = Vector3.left  * (_speedMultiplier * obstacleSpeed);
            yield return new WaitForSeconds(_spawnDelay/_speedMultiplier);
        }
        
    }
}
    