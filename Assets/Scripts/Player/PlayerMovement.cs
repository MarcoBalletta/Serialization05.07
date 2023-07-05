using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ISaveableComponent
{

    private PlayerInputs _inputs;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _inputs = GetComponent<PlayerInputs>();
        _inputs.onMove += HandleTranslation;
        _inputs.onRotate += HandleRotation;
    }

    private void HandleTranslation(float value)
    {
        transform.Translate(_movementSpeed * transform.forward * Time.deltaTime * value);
    }

    private void HandleRotation(float value)
    {
        transform.Rotate(_rotationSpeed * transform.up * Time.deltaTime * value);
    }

    public GameData Save(GameData data)
    {
        if(data is PlayerData)
        {
            var dataTemp = data as PlayerData;
            dataTemp.name = gameObject.name;
            dataTemp.position = transform.position;
            dataTemp.rotation = transform.rotation;
            return dataTemp;
        }
        return data;
    }

    public GameData Load(GameData data)
    {
        if(data is PlayerData)
        {
            var dataTemp = data as PlayerData;
            gameObject.name = dataTemp.name;
            transform.position = dataTemp.position;
            transform.rotation = dataTemp.rotation;
            return dataTemp;
        }
        return data;
    }
}
