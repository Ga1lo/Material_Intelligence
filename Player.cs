using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player
{
    private string playerName;
    private int nCards;
    private List<Card> hand;
    //public Card[] hand;


    public Player(string playerName, List<Card> hand)
    {
        this.playerName = playerName;
        this.hand = hand;
    }

    public string getName()
    {
        return playerName;
    }

    public int getNumberOfCards()
    {
        return hand.Count;
    }

    public void addCardToHand(Card card)
    {
        hand.Add(card);
    }

    public void addCardsToHand(List<Card> cards)
    {

    }

    public Card getCardToPlay()
    {
        return hand[0];
    }

    public Card getCardFromHand()
    {
        if(hand.Count > 0)
        {
            Card[] cardsInHand = hand.ToArray();
            Card cardInHand;
            cardInHand = cardsInHand[0];
            hand.Remove(cardInHand);

            return cardInHand;
        }
        else
        {
            //throw new System.Exception("There is no more cards in the hand.");
            return null;
        }

        
    }

}
