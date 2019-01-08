import ch.rajakone.examples.Example;
import ch.rajakone.kotlin.examples.Counter;

public class Starter
{ 
	public static void main(String [] args)
	{
		Example example = new Example();
		System.out.println("hello from ':app' module");
		System.out.println("this is the value from Example-Class: ");
		System.out.println("	" + example.value);
		


		System.out.println("");
		System.out.println("");
		System.out.println("");
		System.out.println("kotlin demostration");
		Counter c = new Counter(1);
		System.out.println("Counter Class: " + c.getI());
		System.out.println("set new value for counter");
		c.setI(45);
		System.out.println("Counter Class: " + c.getI());
		

	}

}