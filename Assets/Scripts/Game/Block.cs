using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
    [SerializeField] private bool isDroped = false;
    [SerializeField] private bool isFirst;
    [SerializeField] private bool isLanded;

    private OffsetManager _offsetManager;
    private GameManager _gameManager;
    private Spawner _spawner;
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private List<float> rotations = new List<float>() { 0, 0, 0, 45, 90, 90, 90 };
    private void Awake()
    {
        
        _transform = GetComponent<Transform>();
        _gameManager = FindObjectOfType<GameManager>();
        _spawner = FindObjectOfType<Spawner>();
        _offsetManager = FindObjectOfType<OffsetManager>();
        _rigidbody = GetComponent<Rigidbody2D>();
        if(isLanded == false)
        {
            _rigidbody.gravityScale = 0;
            float rotation = rotations[Random.Range(0, rotations.Count)];
            _transform.Rotate(new Vector3(0, 0, rotation));
        }
        
    }
    private void OnMouseDrag()
    {
        if (isDroped == false)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 desiredPosition = mousePosition;
            if (desiredPosition.y < _gameManager.score + 5)
                desiredPosition.y = _gameManager.score + 5;
            _rigidbody.position = desiredPosition;
        }

    }

    private void OnMouseUp()
    {
        if (isDroped == false)
        {
            _rigidbody.gravityScale = 1;
        }
        isDroped = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Block" && isLanded == false)
        {
            isLanded = true;
            _spawner.isDroped = true;
            _gameManager.score = _rigidbody.position.y;
            _gameManager.TextsUpdate();
            _offsetManager.OffsetChange();
        }
        if (collision.transform.tag == "Land" && isFirst == false)
            _gameManager.GameOver();
                    
    }


}
