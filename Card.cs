using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{
    private Sprite cardImage;
    private string cardName, cardFamily;
    private double Price, Density, YoungModulus, ElasticLimit, ThermalConductivity, HeatCapacity, CO2, WaterUsage, RecycleFraction;
    private double[] Properties;

    public Card(Sprite cardImage, string cardName, string cardFamily, double Price, double Density, double YoungModulus, double ElasticLimit, double ThermalConductivity, double HeatCapacity, double CO2, double WaterUsage, double RecycleFraction)
    {
        this.cardImage = cardImage;
        this.cardName = cardName;
        this.cardFamily = cardFamily;
        this.Price = Price;
        this.Density = Density;
        this.YoungModulus = YoungModulus;
        this.ElasticLimit = ElasticLimit;
        this.ThermalConductivity = ThermalConductivity;
        this.HeatCapacity = HeatCapacity;
        this.CO2 = CO2;
        this.WaterUsage = WaterUsage;
        this.RecycleFraction = RecycleFraction;

        Properties = new double[] {Price, Density, YoungModulus, ElasticLimit, ThermalConductivity, HeatCapacity, CO2, WaterUsage, RecycleFraction};

        /*
        Properties = new double[9];
        Properties[0] = Price;
        Properties[1] = Density;
        Properties[2] = YoungModulus;
        Properties[3] = ElasticLimit;
        Properties[4] = ThermalConductivity;
        Properties[5] = HeatCapacity;
        Properties[6] = CO2;
        Properties[7] = WaterUsage;
        Properties[8] = RecycleFraction;
        */
    }

    public Sprite getCardImage()
    {
        return cardImage;
    }

    public string getCardName()
    {
        return cardName;
    }

    public string getCardFamily()
    {
        return cardFamily;
    }

    public double[] getProperties()
    {
        return Properties;
    }
    
    public double getPrice()
    {
        return Price;
    }

    public double getDensity()
    {
        return Density;
    }

    public double getYoung()
    {
        return YoungModulus;
    }

    public double getElastic()
    {
        return ElasticLimit;
    }

    public double getThermal()
    {
        return ThermalConductivity;
    }

    public double getHeat()
    {
        return HeatCapacity;
    }

    public double getCO2()
    {
        return CO2;
    }

    public double getWater()
    {
        return WaterUsage;
    }

    public double getRecycle()
    {
        return RecycleFraction;
    }

}
