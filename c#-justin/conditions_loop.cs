// Bedingungen
// https://www.tutorialspoint.com/csharp/csharp_decision_making.htm
bool duHast2Franken = true;
duHast2Franken = !duHast2Franken;
Console.WriteLine("Wenn du mir 2 Franken gibst, dann gib ich dir ein Weggli");
if (duHast2Franken) {
  Console.WriteLine("Ich gib dir ein Weggli!");
} else {
  Console.WriteLine("Sorry, kein Weggli für dich.");
}

if (!duHast2Franken) {
  Console.WriteLine("Warum hast du kein Geld?");
}

// loops
Console.WriteLine("LOOPS");
// https://www.tutorialspoint.com/csharp/csharp_loops.htm

// WHILE-Loop (führe den Codeblock solange die Bedingung wahr ist)
int j = 1;
while(j < 10) {
  Console.WriteLine(j);
  j = j + 1;

  // breache ab, wenn j = 5 ist
  if (j == 5) {
    break;				
  }
}


// For-Loop
// Etas hochzählen oder herunterzählen und etwas tun dabei
// struktur: for (vorbereitung; bedingung; aufzählungscode) { /* code */ }
for (int i = 1; i < 10; i = i + 1) {
  // ignorieren den nachfolgenden Code, wenn i = 5
  if (i == 5) {
    continue;	
  }

  Console.WriteLine("for-loop" + i);
}

// resultat:
//	for-loop1
//	for-loop2
//	for-loop3
//	for-loop4
//	for-loop6
//	for-loop7
//	for-loop8
//	for-loop9


for (int i = 0; i < 10; i = i + 1) {

  if(i==2){
    continue;
  }


  Console.WriteLine("Ich bin " + i + " Jahre alt.");
}
