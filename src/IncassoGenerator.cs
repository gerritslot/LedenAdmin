using System;
using System.Collections.Generic;
using System.Xml.Linq;

public class IncassoGenerator
{
    public void GenereerIncasso(List<Lid> leden, string bestandsnaam)
    {
        var xml = new XElement("Document",
            new XElement("CstmrCdtTrfInitn",
                leden.Select(lid => new XElement("PmtInf",
                    new XElement("PmtId", Guid.NewGuid().ToString()),
                    new XElement("Amt", new XElement("InstdAmt", "25.00")), // Contributiebedrag
                    new XElement("Cdtr", new XElement("Nm", lid.Naam)),
                    new XElement("CdtrAcct", new XElement("Id", new XElement("IBAN", "NL91ABNA0417164300"))), // Voorbeeld IBAN
                    new XElement("Dbtr", new XElement("Nm", lid.Naam)),
                    new XElement("DbtrAcct", new XElement("Id", new XElement("IBAN", "NL91ABNA0417164300"))) // Voorbeeld IBAN
                ))
            ));

        xml.Save(bestandsnaam);
    }
}