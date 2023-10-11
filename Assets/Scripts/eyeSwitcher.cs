using Unity.VisualScripting;
using UnityEngine;

public class eyeSwitcher : MonoBehaviour
{
    [SerializeField]
    [Range(0, 5)]
    private int defaultEye;
    private SpriteRenderer Render;
    [SerializeField] private Sprite[] eyeSprites;

    private void Awake()
    {
        Render = GetComponent<SpriteRenderer>();
        Render.sprite = eyeSprites[defaultEye];
    }

    private void ChangeEye(int eye)
    {
        Render.sprite = eyeSprites[eye];
    }
    private void DefaultEye()
    {
        Render.sprite = eyeSprites[defaultEye];
    }



    private void OnEnable()
    {
        EventManager.changeEye += ChangeEye;
        EventManager.defaultEye += DefaultEye;
    }

    private void OnDisable()
    {
        EventManager.changeEye -= ChangeEye;
        EventManager.defaultEye -= DefaultEye;
    }

}
