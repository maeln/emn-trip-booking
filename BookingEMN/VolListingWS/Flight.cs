using System;

public class Flight
{
    private int id;
    private int heure_depart;
    private int heure_arrivee;
    private string ville_depart;
    private string ville_arrive;

	public Flight(int id, int hd, int ha, string vd, string va)
	{
        this.id = id;
        this.heure_depart = hd;
        this.heure_arrivee = ha;
        this.ville_depart = vd;
        this.ville_arrive = va;
	}

    public int get_id()
    {
        return this.id;
    }

    public int get_heure_depart()
    {
        return this.heure_depart;
    }

    public int get_heure_arrivee()
    {
        return this.heure_arrivee;
    }

    public string get_ville_depart()
    {
        return this.ville_depart;
    }

    public string get_ville_arrivee()
    {
        return this.ville_arrive;
    }
}
