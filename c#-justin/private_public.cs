using System;


class PersonOffen {
	public string Name;	
}

// Variante - Klassisch
class PersonGeschlossen {
	private string Name;
	
	public string getName(){
		return Name;
	}
	
	public void setName(string name){
		if (name == "") {
			throw new Exception("Name ist leer");
		}
        
        if (name.Length < 5) {
            throw new Exception("Name zu klein");
        }
		Name = name;
	}
}

// Variante 1
class PersonMitProperties {
    private string _name;
    
    public string Name {
        get 
        { 
            return _name; 
        }
        
        set
        {
            if (value == "") {
                throw new Exception("Name ist leer");
            }

            if (value.Length < 5) {
                throw new Exception("Name zu klein");
            }
            _name = value;
        }
    }

}

// Variante 2
class PersonMitPropertiesVariante2 {
    public string Name {get; set;}
    public int Alter { get; set; }
}


public static class Solution
{
    private static void Main()
    {
		Console.WriteLine("Beispiel 1");
		PersonOffen p1 = new PersonOffen();
		p1.Name = ""; // works
        Console.WriteLine(p1.Name);
        Console.WriteLine("END-1");
        
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Beispiel 2");
        PersonGeschlossen p2 = new PersonGeschlossen();
        
        // Error: `PersonGeschlossen.Name' is inaccessible due to its protection level
        // p2.Name = "Justin"; 
        
        p2.setName("Justin");
        
        // p2.setName(""); // System.Exception: Name ist leer
        
        // p2.setName("abc"); // 
        
        Console.WriteLine(p2.getName());
        
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("Beispiel 3");
        PersonMitPropertiesVariante2 p3 = new PersonMitPropertiesVariante2();
        p3.Name = "Jusn";
        p3.Alter = 16;
        Console.WriteLine(p3.Name + ", " + p3.Alter);
        
        
    }
}
