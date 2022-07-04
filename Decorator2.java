// Example took from: https://www.philipphauer.de/study/se/design-pattern/decorator.php

// I took the example from the website. This example there should be a "good" example
// for decorators. The idea is to have multiple diches and to "build" them together
// to a single dish. From the dish you can get a description and a total price.

// I think that example is just plain shit. Just read the code.

// Dish
public interface Gericht {
    public double getPreis();
    public void druckeBeschreibung();
}

class Hueftsteak implements Gericht {
    public void druckeBeschreibung() {
        System.out.print("Hüftsteak");
    }
    public double getPreis() {
        return 13.0;
    }
}

class Tofu implements Gericht {
    public void druckeBeschreibung() {
        System.out.print("Tofu");
    }
    public double getPreis() {
        return 8.50;
    }
}

class Garnelen implements Gericht {
    public void druckeBeschreibung() {
        System.out.print("Garnelen");
    }
    public double getPreis() {
        return 13.50;
    }

}

class WienerSchnitzel implements Gericht {
    public void druckeBeschreibung() {
        System.out.print("WienerSchnitzel");
    }
    public double getPreis() {
        return 10.50;
    }
}

public abstract class Beilage implements Gericht {
    protected Gericht gericht;

    public Beilage(Gericht gericht) {
        this.gericht = gericht;
    }
}

class Pommes extends Beilage {
    public Pommes(Gericht gericht) {
        super(gericht);
    }
    public void druckeBeschreibung() {
        gericht.druckeBeschreibung();
        System.out.print(", Pommes");
    }
    public double getPreis() {
        return gericht.getPreis() + 2.50;
    }
}

class Salat extends Beilage {
    public Salat(Gericht gericht) {
        super(gericht);
    }
    public void druckeBeschreibung() {
        gericht.druckeBeschreibung();
        System.out.print(", Salat");
    }
    public double getPreis() {
        return gericht.getPreis() + 2.25;
    }
}

class Nudeln extends Beilage {
    public Nudeln(Gericht gericht) {
        super(gericht);
    }
    public void druckeBeschreibung() {
        gericht.druckeBeschreibung();
        System.out.print(", Nudeln");
    }
    public double getPreis() {
        return gericht.getPreis() + 4.50;
    }
}

class Suppe extends Beilage {
    public Suppe(Gericht gericht) {
        super(gericht);
    }
    public void druckeBeschreibung() {
        gericht.druckeBeschreibung();
        System.out.print(", Suppe");
    }
    public double getPreis() {
        return gericht.getPreis() + 1.50;
    }
}

class Bratkartoffeln extends Beilage {
    public Bratkartoffeln(Gericht gericht) {
        super(gericht);
    }
    public void druckeBeschreibung() {
        gericht.druckeBeschreibung();
        System.out.print(", Bratkartoffeln");
    }
    public double getPreis() {
        return gericht.getPreis() + 1.50;
    }
}

public static void main(String[] args) {
    Gericht gericht = new Salat(new Nudeln(new Hueftsteak()));
    gericht.druckeBeschreibung();
    //Hüftsteak, Nudeln, Salat
    System.out.println(" für "+gericht.getPreis() + " Euro");
    // für 19.75 Euro

    gericht = new Suppe(gericht);
    gericht.druckeBeschreibung();
    //Hüftsteak, Nudeln, Salat, Suppe
    System.out.println(" für "+gericht.getPreis() + " Euro");
    // für 21.25 Euro
}