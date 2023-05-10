using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck
{
    public Card[] deck;
    private int actualCard;
    public static int MAXCARDS = 40;
    public Card cCarbon, cShell, cGlass, cLeather, cCork, cBone, cOak, cBamboo, cPaper, cPine, cDiamond, cBoron, cAlumina, cSilicon, cBorosilicate, cSoda, cBrick, cMarble, cSandstone, cConcrete, cPtfe, cPolyurethane, cBrubber, cPla, cAbs, cPolystyrene, cNrubber, cPp, cPvc, cPhenolic, cGold, cSilver, cTungsten, cTitanium, cNickel, cBronze, cCopper, cSteel, cMagnesium, cAluminum;
    public Sprite Carbon = Resources.Load<Sprite>("Sprites/H Carbon Composite");
    public string metal = "Metal and alloys";
    public string hybrids = "Hybrids: composites, foams, natural materials";
    public string ceramics = "Ceramics and glasses";
    public string polymers = "Polymers and elastomers";
    private bool empty;
    private Card cardDealed;


    public Deck()
    {

        cDiamond = new Card(Resources.Load<Sprite>("Sprites/C Industrial diamond"), "Industrial diamond", ceramics, 467000, 3510, 1130, 2870, 1610, 510, 237000, 7.4, 0.49);
        cBoron = new Card(Resources.Load<Sprite>("Sprites/C Boron carbide"), "Boron carbide", ceramics, 75, 2400, 450, 280, 27, 1190, 9.1, 180, 0.1);
        cAlumina = new Card(Resources.Load<Sprite>("Sprites/C Alumina"), "Alumina", ceramics, 23, 3890, 370, 470, 32, 810, 2.8, 57, 0.75);
        cSilicon = new Card(Resources.Load<Sprite>("Sprites/C Silicon"), "Silicon", ceramics, 12, 2330, 150, 170, 150, 690, 4.0, 25, 0.75);
        cBorosilicate = new Card(Resources.Load<Sprite>("Sprites/C Borosilicate glass"), "Borosilicate glass", ceramics, 6, 2250, 63, 27, 1.2, 780, 1.7, 15, 21);
        cSoda = new Card(Resources.Load<Sprite>("Sprites/C Soda-lime glass"), "Soda-lime glass", ceramics, 1.5, 2470, 70, 33, 1, 900, 0.76, 14, 24);
        cBrick = new Card(Resources.Load<Sprite>("Sprites/C Brick"), "Brick", ceramics, 1.1, 1850, 23, 9.5, 0.6, 800, 0.22, 5.6, 18);
        cMarble = new Card(Resources.Load<Sprite>("Sprites/C Marble"), "Marble", ceramics, 0.73, 2790, 60, 8, 5.5, 870, 0.17, 3.4, 1.4);
        cSandstone = new Card(Resources.Load<Sprite>("Sprites/C Sandstone"), "Sandstone", ceramics, 0.52, 2450, 20, 13, 3, 880, 0.06, 3.4, 1.4);
        cConcrete = new Card(Resources.Load<Sprite>("Sprites/C Concrete"), "Concrete", ceramics, 0.05, 2450, 20, 1.25, 1.6, 940, 0.1, 3.4, 14);

        cCarbon = new Card(Resources.Load<Sprite>("Sprites/H Carbon Composite"), "Carbon Composite", hybrids, 40, 1550, 110, 800, 1.9, 970, 35, 1410, 0.75);
        cShell = new Card(Resources.Load<Sprite>("Sprites/H Shell"), "Shell", hybrids, 3.1, 1950, 48, 58, 3, 1350, -1.2, 1000, 0.1);
        cGlass = new Card(Resources.Load<Sprite>("Sprites/H Glass"), "Glass composite", hybrids, 29, 1860, 22, 190, 0.48, 1100, 10, 160, 0.75);
        cLeather = new Card(Resources.Load<Sprite>("Sprites/H Leather"), "Leather", hybrids, 19, 930, 0.3, 23, 0.16, 1630, 4.3, 11500, 0.75);
        cCork = new Card(Resources.Load<Sprite>("Sprites/H Cork"), "Cork", hybrids, 8, 180, 0.03, 1.5, 0.04, 2000, 0.19, 700, 0.1);
        cBone = new Card(Resources.Load<Sprite>("Sprites/H Bone"), "Bone", hybrids, 5.2, 1950, 20, 140, 3, 1350, 0.4, 1000, 0.1);
        cOak = new Card(Resources.Load<Sprite>("Sprites/H Oak"), "Oak", hybrids, 2.4, 770, 14, 98, 0.37, 1690, 0.6, 700, 9);
        cBamboo = new Card(Resources.Load<Sprite>("Sprites/H Bamboo"), "Bamboo", hybrids, 1.7, 700, 18, 41, 0.14, 1690, 0.32, 700, 1.5);
        cPaper = new Card(Resources.Load<Sprite>("Sprites/H Paper"), "Paper", hybrids, 1.1, 670, 6, 37, 0.12, 1370, 1.17, 1700, 72);
        cPine = new Card(Resources.Load<Sprite>("Sprites/H Pine"), "Pine", hybrids, 1, 450, 9.8, 60, 0.22, 1690, 0.37, 700, 9);

        cGold = new Card(Resources.Load<Sprite>("Sprites/M Gold"), "Gold", metal, 40050, 19400, 79, 200, 310, 130, 26800, 252000, 53);
        cSilver = new Card(Resources.Load<Sprite>("Sprites/M Silver"), "Silver", metal, 608, 10550, 71, 300, 420, 240, 100, 2310, 66);
        cTungsten = new Card(Resources.Load<Sprite>("Sprites/M Tungsten"), "Tungsten", metal, 56, 18700, 350, 1860, 120, 140, 34, 160, 36);
        cTitanium = new Card(Resources.Load<Sprite>("Sprites/M Titanium"), "Titanium", metal, 21, 4600, 110, 960, 11, 650, 46, 200, 22);
        cNickel = new Card(Resources.Load<Sprite>("Sprites/M Nickel"), "Nickel", metal, 17, 8890, 210, 770, 79, 460, 12, 230, 28);
        cBronze = new Card(Resources.Load<Sprite>("Sprites/M Bronze"), "Bronze", metal, 8, 8720, 120, 540, 75, 390, 4.2, 840, 43);
        cCopper = new Card(Resources.Load<Sprite>("Sprites/M Copper"), "Copper", metal, 6.8, 8940, 130, 330, 280, 380, 3.7, 310, 50);
        cSteel = new Card(Resources.Load<Sprite>("Sprites/M Stainless steel"), "Stainless steel", metal, 6.5, 7850, 200, 1360, 18, 490, 5, 140, 38);
        cMagnesium = new Card(Resources.Load<Sprite>("Sprites/M Magnesium"), "Magnesium", metal, 3.1, 1850, 45, 330, 100, 1010, 35, 980, 30);
        cAluminum = new Card(Resources.Load<Sprite>("Sprites/M Aluminum"), "Aluminum", metal, 2.4, 2700, 75, 300, 160, 950, 13, 1200, 33);

        cPtfe = new Card(Resources.Load<Sprite>("Sprites/P PTFE"), "PTFE", polymers, 13, 2170, 0.5, 25, 0.25, 1030, 6, 460, 0.75);
        cPolyurethane = new Card(Resources.Load<Sprite>("Sprites/P Polyurethane"), "Polyurethane", polymers, 5.5, 1140, 0.02, 38, 0.29, 1680, 3.7, 98, 0.75);
        cBrubber = new Card(Resources.Load<Sprite>("Sprites/P Butyl rubber"), "Butyl rubber", polymers, 4.3, 910, 0.002, 7.5, 0.09, 2150, 6.6, 130, 3.1);
        cPla = new Card(Resources.Load<Sprite>("Sprites/P PLA"), "PLA", polymers, 3.1, 1260, 3.5, 59, 0.15, 1200, 2.8, 1320, 0.6);
        cAbs = new Card(Resources.Load<Sprite>("Sprites/P ABS"), "ABS", polymers, 2.8, 1110, 2, 41, 0.26, 1650, 3.8, 180, 0.75);
        cPolystyrene = new Card(Resources.Load<Sprite>("Sprites/P Polystyrene"), "Polystyrene", polymers, 2.3, 1050, 1.9, 46, 0.13, 1720, 3.8, 140, 2.6);
        cNrubber = new Card(Resources.Load<Sprite>("Sprites/P Natural rubber"), "Natural rubber", polymers, 2.2, 930, 0.002, 27, 0.12, 2150, 2.1, 17500, 0.1);
        cPp = new Card(Resources.Load<Sprite>("Sprites/P PP"), "PP", polymers, 2.1, 900, 1.2, 35, 0.14, 1910, 3.1, 39, 5.6);
        cPvc = new Card(Resources.Load<Sprite>("Sprites/P PVC"), "PVC", polymers, 1.9, 1440, 3.1, 53, 0.22, 1400, 2.5, 210, 0.75);
        cPhenolic = new Card(Resources.Load<Sprite>("Sprites/P Phenolic"), "Phenolic", polymers, 1.8, 1280, 3.8, 48, 0.15, 1500, 3.6, 52, 0.75);

        actualCard = 0;

        /*
        //GameObject.Find("/Sprites/H Shell").GetComponent<Sprite>()

        deck[0] = cCarbon;
        deck[1] = cShell;
        deck[2] = cGlass;
        

        deck[0] = cCarbon;
        */

        //this.deck = deck;
        //this.deck = new Card[] { cCarbon, cShell, cGlass, cLeather, cCork, cBone, cOak, cBamboo, cPaper, cPine, cDiamond, cBoron, cAlumina, cSilicon, cBorosilicate, cSoda, cBrick, cMarble, cSandstone, cConcrete, cPtfe, cPolyurethane, cBrubber, cPla, cAbs, cPolystyrene, cNrubber, cPp, cPvc, cPhenolic, cGold, cSilver, cTungsten, cTitanium, cNickel, cBronze, cCopper, cSteel, cMagnesium, cAluminum  };
        deck = new Card[] { cCarbon, cShell, cGlass, cLeather, cCork, cBone, cOak, cBamboo, cPaper, cPine, cDiamond, cBoron, cAlumina, cSilicon, cBorosilicate, cSoda, cBrick, cMarble, cSandstone, cConcrete, cPtfe, cPolyurethane, cBrubber, cPla, cAbs, cPolystyrene, cNrubber, cPp, cPvc, cPhenolic, cGold, cSilver, cTungsten, cTitanium, cNickel, cBronze, cCopper, cSteel, cMagnesium, cAluminum  };

    }

    public Card dealCards()
    {
        
        if(actualCard < MAXCARDS)
        {
            cardDealed = deck[actualCard];
            actualCard++;
        }
        else
        {
            actualCard = 0;
            cardDealed = deck[actualCard];
        }
       
        return cardDealed;
    }

    public bool isDeckEmpty()
    {
        if (actualCard == MAXCARDS)
            empty = true;
        else
            empty = false;

        return empty;
    } 

    /*
    public void shuffle()
    {
        System.Random random = new System.Random();

        for (int i = (deck.Length - 1); i > 0; i--)
        {
            int j = random.Next();
            Card aux = deck[i];
            deck[i] = deck[j];
            deck[j] = aux;
        }
    }
    */

    public void shuffle()
    {
        int random;

        for (int i = (deck.Length - 1); i > -1; i--)
        {
            random = Random.Range(deck.Length - 1, i);
            Card aux = deck[i];
            deck[i] = deck[random];
            deck[random] = aux;
        }
    }

}

