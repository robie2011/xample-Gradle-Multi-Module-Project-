				
public class Program
{
	
	static int funktionMitEinZahl(){
		return 123;	
	}
	
	static int funktionNimmZahlUndGibtZahlZurück(int b){
		int zahl = b;
		return zahl * 2;
	}
	
	static string begrüssung(){
		return "Hello!";
	}
	
	static void nimmtNixEntgegenUndGibtNixZurück() {
		// sende Email
	}
	
	
	public static void Main()
	{
		// basics:
		// https://github.com/robie2011/Dev-Examples/blob/master/c%23-justin/basics.cs
		
		// conditions & loops
		// https://github.com/robie2011/Dev-Examples/blob/master/c%23-justin/conditions_loop.cs
		
		
		// Funktionen
		//	* Ist quasi eine Komplettanweisung mit mehreren Teilschritte
		//	* Hat eine Ausgabetyp (wenn keine Ausgabe, dann void)
		// 	* KANN eingaben entgegennehmen (oder keine Eingabe)
		//  * Wird aufgerufen mit Klammern. Bsp. Console.WriteLine()
		
		Console.WriteLine(funktionMitEinZahl()); // 123

		Console.WriteLine(funktionNimmZahlUndGibtZahlZurück(8)); // 16
		
		Console.WriteLine(begrüssung()); // "Hello!"
		
		nimmtNixEntgegenUndGibtNixZurück();
		
		Console.WriteLine("===== Klassen ====== ");
		Baum justinBaum = new Baum(2, 10.24f, "Justin-Baum");
		//justinBaum.blätter = 2;
		
		Baum robertBaum = new Baum(13, 30.13f, "Robert-Baum");
		//robertBaum.blätter = 13;
		
		Console.WriteLine(justinBaum.zeigInformationen()); // 2
		Console.WriteLine(robertBaum.blätter); // 13
		
		Console.WriteLine(justinBaum.zeigInformationen()); 
		// Ich bin Justin-Baum und meine Höhe ist 102.4 Meter. Anzahl Blätter sind 4
		Console.WriteLine(robertBaum.zeigInformationen());
		// Ich bin Robert-Baum und meine Höhe ist 301.3 Meter. Anzahl Blätter sind 26
		
		justinBaum.gibWasser();
		Console.WriteLine(justinBaum.zeigInformationen()); 
		// Ich bin Justin-Baum und meine Höhe ist 153.6 Meter. Anzahl Blätter sind 8
		justinBaum.gibWasser();
		justinBaum.gibWasser();
		Console.WriteLine(justinBaum.zeigInformationen()); 
		// Ich bin Justin-Baum und meine Höhe ist 345.6 Meter. Anzahl Blätter sind 32
		Console.WriteLine(robertBaum.zeigInformationen());
		// Ich bin Robert-Baum und meine Höhe ist 301.3 Meter. Anzahl Blätter sind 26
		
	}
}

// Klassen: Zusammengehörende Informationen und Funktionen
class Baum {
	// public / protected (automatisch) / private
	public int blätter;
	public float höhe;
	public string name;
	
	// Konstruktor
	public Baum(int _blätter, float _höhe, string _name){
		blätter = _blätter * 2;
		höhe = _höhe * 10;
		name = _name;
	}
	
	public string zeigInformationen(){
		return "Ich bin " + name +" und meine Höhe ist " + höhe +" Meter. Anzahl Blätter sind " + blätter; 
	}
	
	public void gibWasser(){
		blätter = blätter * 2;
		höhe = höhe * 1.5f;
	}
}
