using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int value;
    public bool isFaceUp = false;
    private Image cardImage;
    public TextMeshProUGUI cardText;
    private Vector3 initialPosition;
    private bool allowDrag = false;

    private void OnEnable()
    {
        cardImage = GetComponent<Image>();
        cardText.text = value.ToString();
        
    }

    public void ToggleFaceUp()
    {
        isFaceUp = !isFaceUp;
        if (isFaceUp)
        {
            cardImage.color = Color.white;
            cardText.enabled = true;
            allowDrag = true;
        }
        else
        {
            cardImage.color = Color.gray;
            cardText.enabled = false;
            allowDrag = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.position.y > initialPosition.y + 200) {
            transform.position = GameStateManager.playPilePos;
        } else
        {
            transform.position = initialPosition;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPosition = transform.position;
    }
}
