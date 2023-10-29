using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OffsetManager : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _background;


    public void OffsetChange()
    {
        _camera.transform.position = new Vector3(_camera.transform.position.x, _camera.transform.position.y + _gameManager.score/6, _camera.transform.position.z);
        _background.transform.position = new Vector3(_background.transform.position.x, _background.transform.position.y + _gameManager.score/6);

    }
}
