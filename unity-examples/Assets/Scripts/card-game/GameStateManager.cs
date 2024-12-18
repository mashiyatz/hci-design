using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public int numberPlayers = 4;
    public GameObject cardPrefab;
    public Transform playerParent;
    // public List<int> deck;
    public int startHandCount;
    public static Vector3 playPilePos;
    public Transform playPile;

    void Start()
    {
        if (numberPlayers < 2) numberPlayers = 2;

        for (int i = 0;  i < numberPlayers; i++)
        {
            playerParent.GetChild(i).gameObject.SetActive(true);
        }

        DealHand(true);
        // deck = new List<int>(); 
        playPilePos = playPile.position;
    }

    void Update()
    {
        
    }

    void ShuffleDeck()
    {
        // algorithm for shuffling deck on command 
    }

    void DealHand(bool init = false)
    {
        // algorithm for dealing hand in beginning
        if (init)
        {
            for (int i = 0; i < numberPlayers; i++)
            {
                int cardsInHand = 0;
                PlayerControl player = playerParent.GetChild(i).GetComponent<PlayerControl>();
                while (cardsInHand < startHandCount)
                {
                    GameObject cardObject = Instantiate(cardPrefab, player.hand);
                    if (player.isPlayer)
                    {
                        Card card = cardObject.GetComponent<Card>();
                        card.ToggleFaceUp();
                    }
                    cardsInHand++;
                    // select a value 

                }
            }
        }
    }
}
