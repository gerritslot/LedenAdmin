using System.Windows;

public partial class MainWindow : Window
{
    private LedenBeheer _ledenBeheer = new LedenBeheer();
    private BackupManager _backupManager = new BackupManager();
    private IncassoGenerator _incassoGenerator = new IncassoGenerator();
    private ImportExportManager _importExportManager = new ImportExportManager();

    public MainWindow()
    {
        InitializeComponent();
        _ledenBeheer.LaadLeden();
        LedenGrid.ItemsSource = _ledenBeheer.Leden;
    }

    private void VoegToe_Click(object sender, RoutedEventArgs e)
    {
        var lid = new Lid(); // Voeg een dialoogvenster toe om gegevens in te voeren
        _ledenBeheer.VoegLidToe(lid);
        _ledenBeheer.BewaarLeden();
    }

    private void Wijzig_Click(object sender, RoutedEventArgs e)
    {
        var geselecteerdLid = LedenGrid.SelectedItem as Lid;
        if (geselecteerdLid != null)
        {
            // Voeg een dialoogvenster toe om gegevens te wijzigen
            _ledenBeheer.BewaarLeden();
        }
    }

    private void Verwijder_Click(object sender, RoutedEventArgs e)
    {
        var geselecteerdLid = LedenGrid.SelectedItem as Lid;
        if (geselecteerdLid != null)
        {
            _ledenBeheer.VerwijderLid(_ledenBeheer.Leden.IndexOf(geselecteerdLid));
            _ledenBeheer.BewaarLeden();
        }
    }

    private void Backup_Click(object sender, RoutedEventArgs e)
    {
        _backupManager.MaakBackup("leden.csv");
    }

    private void Restore_Click(object sender, RoutedEventArgs e)
    {
        // Voeg een dialoogvenster toe om een backup te selecteren
        _backupManager.RestoreBackup("backup.csv", "leden.csv");
        _ledenBeheer.LaadLeden();
        LedenGrid.ItemsSource = _ledenBeheer.Leden;
    }

    private void Incasso_Click(object sender, RoutedEventArgs e)
    {
        _incassoGenerator.GenereerIncasso(_ledenBeheer.Leden, "incasso.xml");
    }
}