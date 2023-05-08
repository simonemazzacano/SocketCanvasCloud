# SocketCanvasCloud
Invio di Canvas tramite socket e possibilità di salvarli e caricarli da Google Drive

- Usare come credenziali la mail scolastica
- La prima volta che fa un operazione sulla finestra di Gestione Drive si apre la pagina per autenticarsi
- A me non arriva nessuna credenziale o informazione, la cartella compare sul drive personale se la si vuole vedere dal sito
- Gli account che possono entrare li devo accettare io dalla dashboard di google cloud(per ora ho inserito solo la sua scolastica)
- Se si chiude una schermata vanno riavviate entrambe

    Funzionamento generale
    Gestione Canvas -->
    Nell'interfaccia ci sono degli InkCanvas che hanno la proprietà Strokes di tipo StrokeCollection che contiene tutti i tratti disegnati
    StrokeCollection può essere salvata su file con il formato ISF(Ink Serialized Format, dovrebbe essere base64)
    Per modificare il contenuto del InkCanvas si può assegnare a Strokes un altro StrokeCollection
    Quindi quello che faccio io è
    Per trasformare da InkCanvas a byte[] faccio canvInvio.Strokes.Save(fs, true), poi leggo il file sotto forma di bytes (File.ReadAllBytes(inkFileName)) e i byte sono già pronti per essere inviati
    Per trasformare da byte[] a InkCanvas scrivo prima su file i byte arrivati (File.WriteAllBytes(inkFileName, dati)) e poi passo il file al costruttore di StrokeCollection (StrokeCollection strokes = new StrokeCollection(fs);) e lo assegno a inkCanvas.Strokes
    
    Gestione socket-->
    Send è un semplice socket.Send(byte della conversione canvas)
    Il Receive essendo che deve essere costantemente in ascolto è un while(true) dentro un Task che legge il buffer quando c'è qualcosa
