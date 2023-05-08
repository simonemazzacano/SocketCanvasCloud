using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace esSocketWPF
{
    /// <summary>
    /// Logica di interazione per GestioneDrive.xaml
    /// </summary>
    public partial class GestioneDrive : Window
    {
        private DriveService service;
        private FileList canvasCartella;
        private string inkFileName;
        private string idCartella;
        public byte[] arrReturn;
        public GestioneDrive(string inkFileName)
        {
            InitializeComponent();
            this.inkFileName = inkFileName;
            Init();
            AggiornaLst();
        }

        private void Init()
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,
                                 DriveService.Scope.DriveFile};
            string clientId = "355135089322-slkatfni9fre32j4qsqais9fbcgkapum.apps.googleusercontent.com";      // From https://console.developers.google.com
            string clientSecret = "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";

            var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            {
                ClientId = clientId,
                ClientSecret = clientSecret
            }, scopes, Environment.UserName, CancellationToken.None, new FileDataStore("Daimto.GoogleDrive.Auth.Store")).Result;

            service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Drive API SocketCanvas",
            });

            CreaCartella();
        }
        private void GetCanvasAttuali()
        {
            FilesResource.ListRequest req = service.Files.List();
            req.Q = "mimeType='text/plain' and trashed=false and '" + idCartella + "' in parents";
            canvasCartella = req.Execute();
        }
        private void CreaCartella()
        {
            FilesResource.ListRequest req = service.Files.List();
            req.Q = "mimeType='application/vnd.google-apps.folder' and trashed=false and title contains 'SocketCanvas'";
            FileList files = req.Execute();
            if (files.Items.Count() == 0)
            {
                // Create metaData for a new Directory
                Google.Apis.Drive.v2.Data.File bodyFold = new Google.Apis.Drive.v2.Data.File();
                bodyFold.Title = "SocketCanvas";
                bodyFold.Description = "Folder cotenente i disegni creati";
                bodyFold.MimeType = "application/vnd.google-apps.folder";

                try
                {
                    FilesResource.InsertRequest request = service.Files.Insert(bodyFold);
                    Google.Apis.Drive.v2.Data.File _ = request.Execute();
                    files = req.Execute();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Errore: " + e.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            idCartella = files.Items[0].Id;
        }

        private void UploadFile()
        {
            Google.Apis.Drive.v2.Data.File body = new Google.Apis.Drive.v2.Data.File();
            string fileName =  chkPersonalizza.IsChecked == false || string.IsNullOrEmpty(txtNomeCanvas.Text) ? inkFileName : txtNomeCanvas.Text;
            body.Title = fileName + "-" + DateTime.Now.ToString("s");
            body.Description = "File uploaded by Socket Canvas";
            body.Parents = new List<ParentReference>() { new ParentReference() { Id = idCartella } };

            byte[] byteArray = System.IO.File.ReadAllBytes(inkFileName);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);

            FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, "text/plain");
            request.Upload();

            AggiornaLst();
        }

        private void AggiornaLst()
        {
            GetCanvasAttuali();

            FilesResource.ListRequest req = service.Files.List();
            req.Q = "mimeType='text/plain' and trashed=false and '" + idCartella + "' in parents";
            canvasCartella = req.Execute();
            lstCaricati.Items.Clear();
            foreach (var item in canvasCartella.Items)
            {
                lstCaricati.Items.Add(item.Title);
            }
        }

        private void MostraCanvasSelezionato()
        {
            GetCanvasAttuali();
            int idxSelezionato = lstCaricati.SelectedIndex;
            if(idxSelezionato == -1) throw new Exception("nessun canvas selezionato");
            var selected = canvasCartella.Items[idxSelezionato];

            var x = service.HttpClient.GetByteArrayAsync(selected.DownloadUrl);
            byte[] arrBytes = x.Result;

            arrReturn = arrBytes;
        }

        private void w_Chiusura(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btnUsaSelezionato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //mostra message box con messaggio di conferma e se si clicca ok allora esegue il codice
                MessageBoxResult result = MessageBox.Show("Il canvas attuale verrà sovrascritto da quello selezionato, continuare? Verra visualizzato alla" +
                    "chiusura della pagina", "Conferma", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    MostraCanvasSelezionato();
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCaricaCanvas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UploadFile();
                AggiornaLst();
            }catch (Exception ex)
            {
                MessageBox.Show("Errore: " + ex.Message, "Errore", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //se chkPersonalizza è checckato allora abilita txtNomeCanvas
        private void chkPersonalizza_Checked(object sender, RoutedEventArgs e)
        {
            txtNomeCanvas.IsEnabled = true;
        }

        //se chkPersonalizza non è checckato allora disabilita txtNomeCanvas
        private void chkPersonalizza_Unchecked(object sender, RoutedEventArgs e)
        {
            txtNomeCanvas.IsEnabled = false;
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            //message box per spiegare il funzionamento dell'interfaccia
            MessageBox.Show("Usa selezionato carica nel canvas invio il canvas selezionato dal list box\n" +
                "Carica attuale carica nella cartella drive il canvas invio corrente, con opzione di rinominarlo a piacere spuntando 'Personalizza nome'", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
