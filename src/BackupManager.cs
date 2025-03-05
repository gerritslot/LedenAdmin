using System;
using System.IO;

public class BackupManager
{
    public void MaakBackup(string bronBestand)
    {
        string backupBestand = $"{DateTime.Now:yyMMdd}_backup.csv";
        File.Copy(bronBestand, backupBestand, true);
    }

    public void RestoreBackup(string backupBestand, string doelBestand)
    {
        File.Copy(backupBestand, doelBestand, true);
    }
}