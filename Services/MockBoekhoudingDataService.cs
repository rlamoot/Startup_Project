using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo_Boekhouding.Services
{
    public class MockBoekhoudingDataService : IBoekhoudingDataService
    {
        #region fields
        private IList<Klant> _klanten;
        private IList<Leverancier> _leveranciers;
        private IList<AankoopFactuur> _aankoopDagboek;
        private IList<VerkoopFactuur> _verkoopDagboek;
        private IList<KasVerrichting> _kasboek;
        #endregion

        //constructor:
        public MockBoekhoudingDataService()
        {
            InitLijsten();
        }
        private void InitLijsten()
        {
            InitKlanten();
            InitLeveranciers();
            InitAankoopDagBoek();
            InitVerkoopDagBoek();
            InitKasBoek();
        }

        private void InitLeveranciers()
        {
            _leveranciers = new List<Leverancier>()
            {
                new Leverancier(){ ContactNr=6, NaamBedrijf="Bedrijf A", BTWNr="00014578441", Straat="Bedrijfstraat 1", Postcode=9000,Gemeente="Gent" },
                new Leverancier(){ ContactNr=7, NaamBedrijf="Bedrijf B", BTWNr="0008965321",Straat="Bedrijfstraat 2",Postcode=8500,Gemeente="Brugge"}
            };
        }

        private void InitKlanten()
        {
            _klanten = new List<Klant>()
            {
                new Klant(){ ContactNr=1,Voornaam = "Jan", Familienaam="Jansen", BTWNr="", Straat="Kerkstraat 8", Postcode=9000,Gemeente="Gent" },
                new Klant(){ ContactNr=2,Voornaam="Piet", Familienaam="Pieters", BTWNr="12345647",Straat="Molenstraat 10",Postcode=8500,Gemeente="Brugge"},
                new Klant(){ ContactNr=3,Voornaam="Joris", Familienaam="Joris", BTWNr="12345648",Straat="Molenstraat 1",Postcode=8500,Gemeente="Brugge"},
                new Klant(){ ContactNr=4,Voornaam="Korneel", Familienaam="Kornelis", BTWNr="",Straat="Molenstraat 2",Postcode=8500,Gemeente="Brugge"},
                new Klant(){ ContactNr=5,Voornaam="Jos", Familienaam="De Klos", BTWNr="",Straat="Molenstraat 3",Postcode=8500,Gemeente="Brugge"}
            };
        }

        private void InitKasBoek()
        {
            _kasboek = new List<KasVerrichting>(){
                new KasVerrichting() {  UniekNr = "14001", FactuurDatum = new DateTime(2020,1,13), Type="Bedrijfskosten", Omschrijving="Benzine",Contact=_klanten[0], BedragExclBTW=60.0,  BTWTarief=21},
                new KasVerrichting() {  UniekNr = "14002", FactuurDatum = new DateTime(2020,1,30), Contact=_klanten[0]}, //Verder aan te vullen
                new KasVerrichting() {  UniekNr = "14003", FactuurDatum = new DateTime(2020,2,1), Contact=_klanten[1]},//Verder aan te vullen
                new KasVerrichting() {  UniekNr = "14004", FactuurDatum = new DateTime(2020,2,25), Contact=_klanten[1]}//Verder aan te vullen
            };
        }

        private void InitVerkoopDagBoek()
        {
            _verkoopDagboek = new List<VerkoopFactuur>()
            {
                new VerkoopFactuur(){UniekNr = "20001", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Ading1", Omschrijving = "Ading 1", BedragExclBTW = 250.69, BTWTarief = 21, Status = "Open", BetaalDatum = default, Contact = _klanten[2]},
                new VerkoopFactuur(){UniekNr = "20002", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Ading2", Omschrijving = "Ading 2", BedragExclBTW = 250.69, BTWTarief = 21, Status = "Betaald", BetaalDatum = new DateTime(2020,9,1), Contact = _klanten[2]},
                new VerkoopFactuur(){UniekNr = "20003", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Ading3", Omschrijving = "Ading 3", BedragExclBTW = 250.69, BTWTarief = 21, Status = "Open", BetaalDatum = default, Contact = _klanten[2]},
                new VerkoopFactuur(){UniekNr = "20004", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Ading4", Omschrijving = "Ading 4", BedragExclBTW = 250.69, BTWTarief = 21, Status = "Betaald", BetaalDatum = new DateTime(2020,9,1), Contact = _klanten[2]}
            };
        }

        private void InitAankoopDagBoek()
        {
            _aankoopDagboek = new List<AankoopFactuur>()
            {
                new AankoopFactuur(){UniekNr = "30001", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Vding1", Omschrijving = "Vding 1", BedragExclBTW = 250.69, BTWTarief = 21, Status = "Open", BetaalDatum = default, Contact = _leveranciers[1]},
                new AankoopFactuur(){UniekNr = "30002", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Vding2", Omschrijving = "Vding 2", BedragExclBTW = 250.69, BTWTarief = 6, Status = "Betaald", BetaalDatum = new DateTime(2020,9,1), Contact = _leveranciers[0]},
                new AankoopFactuur(){UniekNr = "30003", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Vding3", Omschrijving = "Vding 3", BedragExclBTW = 250.69, BTWTarief = 21, Status = "Open", BetaalDatum = default, Contact = _leveranciers[1]},
                new AankoopFactuur(){UniekNr = "30004", Maand = "AUG", FactuurDatum = new DateTime(2020,8,15), Type = "Vding4", Omschrijving = "Vding 4", BedragExclBTW = 250.69, BTWTarief = 0, Status = "Betaald", BetaalDatum = new DateTime(2020,9,1), Contact = _leveranciers[0]}

            };
        }
        public IList<Klant> GeefAlleKlanten()
        {
            return _klanten;
        }
        public IList<Leverancier> GeefAlleLeveranciers()
        {
            return _leveranciers;
        }

        public IList<AankoopFactuur> GeefAankoopDagboek()
        {
            return _aankoopDagboek;
        }

        public IList<VerkoopFactuur> GeefVerkoopDagboek()
        {
            return _verkoopDagboek;
        }
        public IList<KasVerrichting> GeefKasboek()
        {
            return _kasboek;
        }

        //toevoeging aankoopfacturen
        public IList<AankoopFactuur> VoegAankoopFactuurToe(AankoopFactuur factuur)
        {
            _aankoopDagboek.Add(factuur);
            return _aankoopDagboek;
        }
        public void WijzigAankoopFactuur(AankoopFactuur nieuwefactuur)
        {

            int index = _aankoopDagboek.IndexOf(nieuwefactuur);
            if (index >= 0)
            {
                _aankoopDagboek[index] = nieuwefactuur;
            }
        }
        public IList<AankoopFactuur> VerwijderAankoopFactuur(AankoopFactuur factuur)
        {
            _aankoopDagboek.Remove(factuur);
            return _aankoopDagboek;
        }
        //Verkoopfactuur

        public IList<VerkoopFactuur> VoegVerkoopFactuurToe(VerkoopFactuur factuur)
        {
            _verkoopDagboek.Add(factuur);
            return _verkoopDagboek;
        }
        public void WijzigVerkoopFactuur(VerkoopFactuur selectedFactuur)
        {

            int index = _verkoopDagboek.IndexOf(selectedFactuur);
            if (index >= 0)
            {
                _verkoopDagboek[index] = selectedFactuur;
            }
        }
        public IList<VerkoopFactuur> VerwijderVerkoopFactuur(VerkoopFactuur selectedFactuur)
        {
            _verkoopDagboek.Remove(selectedFactuur);
            return _verkoopDagboek;
        }

        //verwijder, wijzig en toevoegen van klant
        public IList<Klant> VoegKlantToe(Klant klant)
        {
            int ContactNr = (_klanten.Count > 0) ? _klanten.Max(b => b.ContactNr) + 1 : 1;
            klant.ContactNr = ContactNr;
            _klanten.Add(klant);
            return _klanten;
        }
        public void WijzigKlant(Klant selectedKlant)
        {
            int index = _klanten.IndexOf(selectedKlant);
            if (index >= 0)
            {
                _klanten[index] = selectedKlant;
            }
        }
        public IList<Klant> VerwijderKlant(Klant selectedKlant)
        {
            _klanten.Remove(selectedKlant);
            return _klanten;
        }

        //verwijder, wijzig en toevoegen van klant
        public void WijzigLeverancier(Leverancier selectedLeverancier)
        {
            int index = _leveranciers.IndexOf(selectedLeverancier);
            if (index >= 0) _leveranciers[index] = selectedLeverancier;
        }

        public IList<Leverancier> VerwijderLeverancier(Leverancier selectedLeverancier)
        {
            _leveranciers.Remove(selectedLeverancier);
            return _leveranciers;
        }

        public IList<Leverancier> VoegLeverancierToe(Leverancier leverancier)
        {
            _leveranciers.Add(leverancier);
            return _leveranciers;
        }
    }
}
