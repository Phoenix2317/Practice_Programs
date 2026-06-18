// See https://aka.ms/new-console-template for more information


Sword basicSword = new Sword(SwordMat.Iron, Gem.None, 100, 20);
Sword magicSword = basicSword with { Mat = SwordMat.Steel, gem = Gem.Diamond };
Sword mythicSword = magicSword with { Mat = SwordMat.Binarium, gem = Gem.Bitstone};

Console.Write("The basic sword is made of: ");
Console.WriteLine(basicSword);
Console.Write("The magic sword is made of: ");
Console.WriteLine(magicSword);
Console.Write("The mythical sword is made of: ");
Console.WriteLine(mythicSword);


public enum SwordMat { Wood, Bronze, Iron, Steel, Binarium }

public enum Gem { Emerald, Amber, Sapphire, Diamond, Bitstone , None }

/*
 * Generates a default class making it easy to swap things out and create new ones with the "with" keyword.
 * It also generates a ToString method that prints the properties of the class. 
 */
public record Sword(SwordMat Mat, Gem gem, int length, int crossguardWidth) 
{
   
}