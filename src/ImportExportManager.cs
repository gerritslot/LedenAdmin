using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ImportExportManager
{
    public void ExporteerLeden(List<Lid> leden, string bestandsnaam)
    {
        var regels = leden.Select(l => $"{l.Naam},{l.Adres},{l.Postcode},{l.Woonplaats},{l.Email},{l.Telefoon}");
        File.WriteAllLines(bestandsnaam, regels);
    }

    public List<Lid> ImporteerLeden(string bestandsnaam)
    {
        var regels = File.ReadAllLines(bestandsnaam);
        return regels.Select(r =>
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