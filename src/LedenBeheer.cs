using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class LedenBeheer
{
    private const string LedenBestand = "leden.csv";

    public List<Lid> Leden { get; set; } = new List<Lid>();

    public void LaadLeden()
    {
        if (File.Exists(LedenBestand))
        {
            var regels = File.ReadAllLines(LedenBestand);
            Leden = regels.Select(r =>
            {
                var velden = r.Split(',');
                return new Lid
                {
                    Naam = velden[0],
                    Adres = velden[1],
                    Postcode = velden[2],
                    Woonplaats = velden[3],
                    Email = velden[4],
                    Telefoon = velden[5]
                };
            }).ToList();
        }
    }

    public void BewaarLeden()
    {
        var regels = Leden.Select(l => $"{l.Naam},{l.Adres},{l.Postcode},{l.Woonplaats},{l.Email},{l.Telefoon}");
        File.WriteAllLines(LedenBestand, regels);
    }

    public void VoegLidToe(Lid lid) => Leden.Add(lid);
    public void WijzigLid(int index, Lid lid) => Leden[index] = lid;
    public void VerwijderLid(int index) => Leden.RemoveAt(index);
}