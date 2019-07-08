  // basic: variable erstellen
  // typedefinieren variablenameDefinieren

  // bits
  // 1 Bit = (0, 1) -> 2 Informationen
  // 2 Bit = (00, 01, 10, 11) --> 4 Informationen
  // 3 Bit = ()

  // 1 2 3
  // -----
  // 0 0 0
  // 0 0 1
  // 0 1 0
  // 0 1 1
  // 1 0 0
  // 1 0 1
  // 1 1 0
  // 1 1 1

  // formel:
  // 2^AnzahlBits
  // zbsp: 3Bit = 2^3 = 8
  // zbsp: 32Bit = 2^32 = 4'294'967'296
  // zbsp: 64Bit = 2^64 = 1.844674407E19

  // ***** Zahlen ***** 
  // https://www.tutorialspoint.com/csharp/csharp_data_types
  // ganze zahl: integer (32Bit)
  // ganze zahl: long (64bit)
  // dezimalzahl: float (32bit) abkürzung: f
  // dezimalzahl: double (64bit), abkürzung: d
  // dezimalzahl: decimal (128bit), abkürzung: m

  int ganzeZahl = 132;
  decimal dezimalZahl = 13.231m;
  double doubleZahl64Bit = 13.1324d;
  float floatZahl = 312.23f;
  int jahr = 2019;

  // Abkürzung: jahr += 3;
  jahr = jahr + 3;

  // Abkürzung: Console.WriteLine(jahr++);
  // Console.WriteLine(jahr + 1);

  // Console.WriteLine(jahr);



  // Wahrheitswert (1 Bit)
  // Werte: true oder false
  bool isHeuteSonne = true;
  //Console.WriteLine(isHeuteSonne);
  isHeuteSonne = false;

  // Buchstabe (16 Bit)

  // Byte (8 Bit, 0 - 255)
  byte meinByte = 85;

  // **** Aritmentische Operatoren *****
  // https://www.tutorialspoint.com/csharp/csharp_operators.htm
  // * multiplikation
  // + addition
  // - subtraktion
  // / division
  // ++ Inkrementieren
  // -- Dekrementieren
  int seite_a = 13;
  int seite_b = 2;
  int fläche = seite_a * seite_b; 


  // **** Relational Operatoren *****
  // == Gleich
  // <  Links ist kleiner als rechts
  // >  Links ist grösesr als rechts
  // >= Links ist grösser oder gleich wie rechts
  // <= Links ist kleiner oder gleich wie rechts
  int jahr1 = 2019;
  int jahr2 = 2021;
  Console.WriteLine(jahr1 == jahr2);

  int jahr3 = 2019;
  int jahr4 = 2019;
  Console.WriteLine(jahr3 == jahr4);

  Console.WriteLine("Ist jahr1 grösser als jahr2?");
  Console.WriteLine(jahr1 > jahr2);


  Console.WriteLine("Ist jahr1 kleiner als jahr2?");
  Console.WriteLine(jahr1 < jahr2);

  // **** Logische Operatoren *****
  // && Logische Und-Vergleich
  // A		B		Resultat
  // Ja		Ja		Ja
  // Ja		Nein	Nein
  // Nein		Ja		Nein
  // Nein		Nein	Nein

  bool istHeuteKeinUnterricht = true;
  bool istHeuteFerien = true;

  Console.WriteLine("Wenn heute kein Unterricht ist UND wir haben Ferien, dann freue ich mich sehr !");
  Console.WriteLine(istHeuteKeinUnterricht && istHeuteFerien);

  // || Logische Oder-Vergleich
  // A		B		Resultat
  // Ja		Ja		Ja
  // Ja		Nein	Ja
  // Nein		Ja		Ja
  // Nein		Nein	Nein
  istHeuteKeinUnterricht = true;
  bool istHeuteSonne = false;
  Console.WriteLine("Wenn heute kein Unterricht ist ODER es ist sonnig, dann freue ich mich sehr!");
  Console.WriteLine(istHeuteKeinUnterricht || istHeuteSonne);

  // ! Negation-Operator
  // A		Resultat
  // Ja		Nein
  // Nein		Ja
  Console.WriteLine("Heute ist NICHT istHeuteSonne");
  Console.WriteLine(!istHeuteSonne);
  Console.WriteLine(!!istHeuteSonne);
  Console.WriteLine(!!!!!!!!!!!!!!!!istHeuteSonne);

  // *********** Text *********** 
  // Char (Buchstabe)
  char a1 = 'a';
  Console.WriteLine(a1);

  // Array
  // Speicherung: H a l l o   W e l t
  // Index: 		0 1 2 3 4 5 6 7 8 9
  string text = "Hallo Welt";
  Console.WriteLine(text);

  Console.WriteLine(text[0]); // Zugriff auf Index-Operator []

  Console.WriteLine("Konkatination");
  string wiegehts = ", Wie gehts? ";
  Console.WriteLine(text + wiegehts + istHeuteSonne);
