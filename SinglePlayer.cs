using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SinglePlayer
{
    //Player[] singlePlayers;
    public List<Player> singlePlayers;
    Player singlePlayer;
    Card[] cardsInPlay, cardsToPile;


    public SinglePlayer(Player singlePlayer, List<Player> singlePlayers)
    {
        this.singlePlayer = singlePlayer;
        this.singlePlayers = singlePlayers;

    }

    public double IAChooseCategory(Card cardInPlay, int category)
    {
        return cardInPlay.getProperties()[category];
    }

    public int PropertyToPlay()
    {
        int random;
        random = UnityEngine.Random.Range(0, 8);

        return random;
    }

    /*
    public bool IsAWinner(Player[] playersInPlay)
    {
        bool winner = false;
        
        if (playersInPlay[0].getNumberOfCards() == 40 || playersInPlay[1].getNumberOfCards() == 40 || playersInPlay[2].getNumberOfCards() == 40 || playersInPlay[3].getNumberOfCards() == 40)
        {
            winner = true;
        }
        else
        {
            winner = false;
        }

        return winner;
    }

    */

    public Player WhoIsLoser()
    {
        int i = 0;
        bool founded = false;
        Player playerLoser = null;

        //while (i < singlePlayers.Length && !founded)
        while (i < singlePlayers.Count && !founded)
        {
            if (singlePlayers[i].getNumberOfCards() == 0)
            {
                playerLoser = singlePlayers[i];
                founded = true;
            }
            i++;
        }

        return playerLoser;

    }
    public Player WhoIsWinner()
    {
        int i = 0;
        bool founded = false;
        Player playerWinner = null;

        while (i < singlePlayers.Count && !founded)
        {
            if (singlePlayers[i].getNumberOfCards() == 40)
            {
                playerWinner = singlePlayers[i];
                founded = true;
            }
            i++;
        }

        return playerWinner;

    }

    /*
    public Player RandomPlayer(Player[] playersInPlay)
    {
        int random;
        random = UnityEngine.Random.Range(0, playersInPlay.Length - 1);

        return playersInPlay[random];

    }
    */

    public Player NextTurn()
    {
        Player nextPlayer = null;
        int propertyInPlay;
        double bestValue = -99999;

        if (GameManager.instanceManager.playerInTurn.Equals(singlePlayer)) //(GameManager.instanceManager.mainPlayer)) //Si soy el jugador principal
        {
            int i = 0;
            int j = 0;
            propertyInPlay = GameManager.instanceManager.PropertyChoosed(); // Propiedad jugada en el turno por el jugador

            while (i < singlePlayers.Count)
            {
                cardsInPlay[i] = singlePlayers[i].getCardFromHand();
                GameManager.instanceManager.AddCardsToWin(cardsInPlay[i]);
                i++;
            }

            while (j < cardsInPlay.Length)
            {
                if (bestValue < cardsInPlay[j].getProperties()[propertyInPlay]) // Si el valor de la propiedad jugada es mayor a la anterior
                {
                    bestValue = cardsInPlay[j].getProperties()[propertyInPlay];
                    nextPlayer = singlePlayers[j]; // se devuelve el jugador con el atributo jugado más alto
                }
                else if (bestValue == cardsInPlay[j].getProperties()[propertyInPlay]) // Si dos propiedades comparten el mismo valor
                {
                    nextPlayer = null; // se devuelve null para saber que las cartas tienen que ser mandadas a la pila y jugar siguiente ronda
                }
                j++;
            }

        }
        else // Si juega la IA
        {
            int i = 0;
            int j = 0;
            propertyInPlay = PropertyToPlay(); // Propiedad jugada en el turno, al azar entre las 9 posibles

            while (i < singlePlayers.Count)
            {
                cardsInPlay[i] = singlePlayers[i].getCardFromHand();
                GameManager.instanceManager.AddCardsToWin(cardsInPlay[i]);
                i++;
            }

            while (j < cardsInPlay.Length)
            {
                if(bestValue < cardsInPlay[j].getProperties()[propertyInPlay]) // Si el valor de la propiedad jugada es mayor a la anterior
                {
                    bestValue = cardsInPlay[j].getProperties()[propertyInPlay];
                    nextPlayer = singlePlayers[j]; // se devuelve el jugador con el atributo jugado más alto
                }
                else if (bestValue == cardsInPlay[j].getProperties()[propertyInPlay]) // Si dos propiedades comparten el mismo valor
                {
                    nextPlayer = null; // se devuelve null para saber que las cartas tienen que ser mandadas a la pila y jugar siguiente ronda
                }
                j++;
            }

        }

        return nextPlayer;

    }

}
