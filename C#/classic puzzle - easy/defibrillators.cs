using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Solution
{
    static void Main(string[] args)
    {
        // closest defibrillator station
        string closestStation = string.Empty;
        double closestDistance = Double.MaxValue;

        // read longitude location
        string LON = Console.ReadLine();
        double Longitude = Convert.ToDouble(LON.Replace(',', '.'));

        // read latitude location
        string LAT = Console.ReadLine();
        double Latitude = Convert.ToDouble(LAT.Replace(',', '.'));

        // read stations
        int N = int.Parse(Console.ReadLine());

        for (int i = 0; i < N; i++)
        {
            string DEFIB = Console.ReadLine();
            Console.Error.WriteLine(DEFIB);

            string[] substring = DEFIB.Split(';');
            string stationName = substring[1];
            double stationLON = Convert.ToDouble(substring[4].Replace(',', '.'));
            double stationLAT = Convert.ToDouble(substring[5].Replace(',', '.'));
            double distance = calculateDistance(Longitude, Latitude, stationLON, stationLAT);

            if (String.IsNullOrEmpty(closestStation))
            {
                closestStation = stationName;
                closestDistance = distance;
            }
            else if (closestDistance > distance)
            {
                closestStation = stationName;
                closestDistance = distance;
            }

        }

        // output closest defibrillator station
        Console.WriteLine(closestStation);
    }

    private static double calculateDistance(double userLON, double userLAT, double stationLON, double stationLAT)
    {
        double x = (stationLON - userLON) * Math.Cos((userLAT + stationLAT) / 2);
        double y = (stationLAT - userLAT);

        return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
    }
}
