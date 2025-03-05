protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
{
    _backupManager.MaakBackup("leden.csv");
    base.OnClosing(e);
}