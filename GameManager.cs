using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instanceManager = null;

    public GameObject cardInPlay;
    //public Card cCarbon, cShell, cGlass, cLeather, cCork, cBone, cOak, cBamboo, cPaper, cPine, cDiamond, cBoron, cAlumina, cSilicon, cBorosilicate, cSoda, cBrick, cMarble, cSandstone, cConcrete, cPtfe, cPolyurethane, cBrubber, cPla, cAbs, cPolystyrene, cNrubber, cPp, cPvc, cPhenolic, cGold, cSilver, cTungsten, cTitanium, cNickel, cBronze, cCopper, cSteel, cMagnesium, cAluminium;
    //public List<GameObject> totalCards;
    //public List<Card> deck;
    //public ArrayList cards;
  
    public Deck deck;

    public List<Card> handPlayer1, handPlayer2, handPlayer3, handPlayer4, cardsInPlay, cardsToWin;

    public Card[] prueba1, prueba2, prueba3, prueba4;

    public Player mainPlayer, player1, player2, player3, player4, playerInTurn, playerInPlay, winnerPlayer;

    public Player[] players;

    public List<Player> playersInPlay;

    public SinglePlayer singlePlayer;




    // Start is called before the first frame update
    void Start()
    {
        
        
        //cardPlayer1.SetActive(false);
        //deck.Add(card1);

        deck = new Deck();
        /*
        for(int i = 0; i<40; i++)
        {
            Debug.Log("nombre de la 3 carta: {0}" + deck.deck[i].getCardName());
        }
        */
            
        

        handPlayer1 = new List<Card>();
        handPlayer2 = new List<Card>();
        handPlayer3 = new List<Card>();
        handPlayer4 = new List<Card>();

        Debug.Log("Numero de cartas en mano jugador 1 (antes de repartir): {0}" + handPlayer1.Count.ToString());


        deck.shuffle();
        for (int i = 0; i < 40; i++)
        {
            Debug.Log("Carta en posición " +i.ToString() + " mezclada: {0}" + deck.deck[i].getCardName());
        }

        while (!deck.isDeckEmpty())
        {
            handPlayer1.Add(deck.dealCards());
            handPlayer2.Add(deck.dealCards());
            handPlayer3.Add(deck.dealCards());
            handPlayer4.Add(deck.dealCards());
        }

        /*
        Debug.Log("Numero de cartas en mano jugador 1 (después de repartir): {0}" + handPlayer1.Count.ToString());
        Debug.Log("Numero de cartas en mano jugador 2 (después de repartir): {0}" + handPlayer2.Count.ToString());
        Debug.Log("Numero de cartas en mano jugador 3 (después de repartir): {0}" + handPlayer3.Count.ToString());
        Debug.Log("Numero de cartas en mano jugador 4 (después de repartir): {0}" + handPlayer4.Count.ToString());

        prueba1 = handPlayer1.ToArray();
        prueba2 = handPlayer2.ToArray();
        prueba3 = handPlayer3.ToArray();
        prueba4 = handPlayer4.ToArray();

        for (int i = 0; i < 10; i++)
        {
            Debug.Log("carta " +i.ToString() + " jugador 1 (después de repartir): { 0} " + prueba1[i].getCardName());
            Debug.Log("carta " + i.ToString() + " jugador 2 (después de repartir): { 0} " + prueba2[i].getCardName());
            Debug.Log("carta " + i.ToString() + " jugador 3 (después de repartir): { 0} " + prueba3[i].getCardName());
            Debug.Log("carta " + i.ToString() + " jugador 4 (después de repartir): { 0} " + prueba4[i].getCardName());
        }
        */

        player1 = new Player("player1", handPlayer1);
        player2 = new Player("player2", handPlayer2);
        player3 = new Player("player3", handPlayer3);
        player4 = new Player("player4", handPlayer4);

        players = new Player[]{player1, player2, player3, player4};

        //Debug.Log("Mano del jugador 2: ", handplayer2);

        //mainPlayer = RandomPlayer(players);

        //GAME IS SET, LET'S PLAY, SinglePlayer

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instanceManager == null)
        {
            //if not, set instance to this
            instanceManager = this; //Sets this to not be destroyed when reloading scene

            DontDestroyOnLoad(gameObject);

            //If instance already exists and it's not this:
        }
        else if (instanceManager != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            DestroyImmediate(gameObject);
        }
    }

  
    public void NewGame()
    {
        deck = new Deck();

        handPlayer1 = new List<Card>();
        handPlayer2 = new List<Card>();
        handPlayer3 = new List<Card>();
        handPlayer4 = new List<Card>();

        deck.shuffle();

        while (!deck.isDeckEmpty())
        {
            handPlayer1.Add(deck.dealCards());
            handPlayer2.Add(deck.dealCards());
            handPlayer3.Add(deck.dealCards());
            handPlayer4.Add(deck.dealCards());
        }

        player1 = new Player("player1", handPlayer1);
        player2 = new Player("player2", handPlayer2);
        player3 = new Player("player3", handPlayer3);
        player4 = new Player("player4", handPlayer4);

        players = new Player[] { player1, player2, player3, player4 };

        playersInPlay.Add(player1);
        playersInPlay.Add(player2);
        playersInPlay.Add(player3);
        playersInPlay.Add(player4);

        mainPlayer = RandomPlayer(playersInPlay);

        playerInTurn = RandomPlayer(playersInPlay);

        singlePlayer = new SinglePlayer(mainPlayer, playersInPlay);

    }

    public void PlaySingleGame()
    {
        winnerPlayer = null;
        
        while(winnerPlayer == null)
        {
            PlayTurnPre();
            PlayTurnPost();
        }
    }

    public void PlayTurnPre()
    {
        UpdatePlayers();

        //Conocer el valor de la carta que tiene el usuario y actualizarlo en la UI

        mainPlayer.getCardToPlay();
    }

    public void PlayTurnPost()
    {
        playerInPlay = singlePlayer.NextTurn();

        if (playerInTurn != null) // si no ha sido una jugada de empate, en cuyo caso se deberían entregar las cartas a la pila para la siguiente ronda
        {
            playerInTurn = playerInPlay;
            playerInTurn.addCardsToHand(cardsToWin);
        }
    }

    public void UpdatePlayers() //Actualizacion de los jugadores, Comprueba si hay jugadores sin cartas
    {
        if (singlePlayer.WhoIsLoser() != null && singlePlayer.WhoIsLoser() != mainPlayer) // Si no ha perdido la partida el jugador humano, pero si algún otro jugador
        {
            playersInPlay.Remove(singlePlayer.WhoIsLoser()); // se retira al jugador perdedor de la partida

            if (singlePlayer.singlePlayers.Count == 1) // Ha ganado la partida
            {
                winnerPlayer = singlePlayer.WhoIsWinner();
            }

        }
    }

    public int PropertyChoosed() // Property choosed by the player
    {
        int random;
        random = UnityEngine.Random.Range(0, 8);

        return random;
    }

    public Player RandomPlayer(List <Player> playersInPlay)
    {
        int random;
        random = UnityEngine.Random.Range(0, playersInPlay.Count-1);

        return playersInPlay[random];  
    }

    public void AddCardsToWin(Card cardToWin)
    {
        cardsToWin.Add(cardToWin);
    }

    public List<Card> CardsToWin()
    {
        return cardsToWin;
    }   

    /*
    public void Shuffle<Card>(List<Card> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;

        while (n>1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    
    public void InstanceCard(int posX)
    {
        Instantiate(card, initialPosition + new Vector2(posX, 0, 0), Quaternion.identity);
        Card cardSelect = Card.GetComponent<Card>();
        cardSelect = cardsList[Random.Range(0, cardsList.Count)];
    }
    */

}