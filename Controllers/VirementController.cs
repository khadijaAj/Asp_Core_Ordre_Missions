﻿using gestion_ordre_mission.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_ordre_mission.Controllers
{
    public class VirementController : Controller
    {
        // GET: Virement
        private readonly DbContextIndimnite db;

        public VirementController(DbContextIndimnite context)
        {
            db = context;
        }
        public string nompers;
        public string mois;
        public string anneee;
        public string numop;
        public string numv;
        public string faitpar;
        public string name;
        public double totale_final;
        public int totale_dep, totale_kilo;

        //calcule
        int Taux = 0;
        int NbJourDecouche = 0;
        int RepasMidi = 0;
        int nbJour1 = 0;
        int nbJour2 = 0;
        int nbJours = 0;
        int NbRepasMidi = 0;
        int NbRepasSoir = 0;
        int TolaleDecouche = 0;
        int TotaleRepasMidi = 0;
        int TotaleRepasSoir = 0;
        int TotaleDeplacement = 0;
        double total_dep = 0;

        public double total = 0;//sssssssssssssssssssssd
        List<int> listeJours = new List<int>();
        bool testCinqMatin = false;
        bool testMinhuit = false;

        public string numOV;
        public string numOP;
        public string banquee;
        public string comptee;


        // GET: Virement

        public IActionResult ListVirement()
        {
            
            return View();
        }
        public IActionResult FormOrdreVirement()
        {
            
            return View();
        }

        public IActionResult OrdreVirementPdf()
        {
            return View();
        }
        public IActionResult GeneratePDF()
        {

            string curr_Date = null;
            curr_Date = System.DateTime.Today.ToString("dd/MM/yyyy");
            numOV = Request.Form["numero"].ToString();
            numOP = Request.Form["numop"].ToString();
            banquee = Request.Form["banque"].ToString();
            comptee = Request.Form["compte"].ToString();
            ViewData["numero"] = numOV;
            ViewData["numop"] = numOP;
            ViewData["banque"] = banquee;
            ViewData["compte"] = comptee;
            ViewData["date"] = curr_Date;

            totale_dep = (int)HttpContext.Session.GetInt32("totale_dep");
            totale_kilo = (int)HttpContext.Session.GetInt32("totale_kilo");

            Console.WriteLine("Test Test Test: " + totale_dep );


            HttpContext.Session.SetInt32("total_final", (int)(totale_dep + totale_kilo)); 
            var pdfprint = new ViewAsPdf("OrdreVirementPdf",ViewData);
            return pdfprint;
        }
        public IActionResult get_data()
        {


            nompers = Request.Form["NomPersonel"].ToString();
            HttpContext.Session.SetString("pers", nompers);
            mois = Request.Form["annee"].ToString();
            anneee = Request.Form["mois"].ToString();
            numop = Request.Form["nump"].ToString();
            numv = Request.Form["numv"].ToString();
            faitpar = Request.Form["faitpar"].ToString();
            ViewBag.selectedValue = nompers;
            ViewBag.valueYear = mois;
            ViewBag.valueMonth = anneee;
            ViewData["nompers"] = nompers;
            ViewBag.numop = numop;
            ViewBag.numv = numv;
            ViewBag.faitpart = faitpar;
            Kilo();
            get_parametre_for_kilometrage();


            var pdf = new ViewAsPdf("test2",ViewData);
            return pdf;
        }

        public void Kilo()
        {
            // recuperer donnee de la form

            string nomP = Request.Form["NomPersonel"].ToString();
            name = nomP;
            string anneeOrdre = Request.Form["annee"].ToString();
            string moisOrdre = Request.Form["mois"].ToString();

            ViewBag.selectedValue = nomP;
            ViewBag.valueYear = anneeOrdre;
            ViewBag.valueMonth = moisOrdre;

            int nbAller = 0;
            int nbRetour = 0;
            double kms = 0;
            int year = Convert.ToInt32(anneeOrdre);
            int month = Convert.ToInt32(moisOrdre);
            List<OrdreMission> orders = db.ordremission.Where(s => s.dateDepart.Year == year && (s.dateDepart.Month == month || s.dateArrivee.Month == month) && s.personel.Nom
             == nomP).ToList();
            foreach (var order in orders)
            {
                ViewData["nom"] = nomP;
                ViewData["mois"] = moisOrdre;
                DateTime now = DateTime.Now;
                ViewData["date"] = now.ToString("MM/dd/yyyy");
                ViewData["taux"] = 1.2;
                if (order.dateDepart.Month == month && order.dateArrivee.Month != month)
                {
                    nbAller = nbAller + 1;
                    kms = kms + order.trajet.distance;

                }
                else if (order.dateDepart.Month != month && order.dateArrivee.Month == month)
                {
                    nbRetour = nbRetour + 1;
                    kms = kms + order.trajet.distance;
                }
                else if (order.dateDepart.Month == month && order.dateArrivee.Month == month)
                {
                    nbAller = nbAller + 1;
                    nbRetour = nbRetour + 1;
                    kms = kms + order.trajet.distance;
                }
                ///test nb cheuveux
                if (order.nombreCheuvaux > 6 && order.nombreCheuvaux < 10)
                {
                    ViewData["taux"] = 1.75;
                }
                else if (order.nombreCheuvaux > 10)
                {
                    ViewData["taux"] = 2.30;
                }
                ViewData["kms"] = kms;
                @ViewData["aller"] = nbAller;
                @ViewData["retour"] = nbRetour;

                ViewData["total"] = (double)ViewData["taux"] * (int)kms * (nbAller + nbRetour);
                HttpContext.Session.SetInt32("totale_kilo", (int)((double)ViewData["taux"] * (int)kms * (nbAller + nbRetour)));
            }




        }

        public void get_parametre_for_kilometrage()
        {
            string nomP = Request.Form["NomPersonel"].ToString();
            var x = (from item in db.personnels where item.Nom == nomP select item.Role).SingleOrDefault();
            if (x == "economique")
            {
                var y = (from item in db.param_paiement where item.Art == 920 & item.num2 == 15 select item).SingleOrDefault();
                ViewData["art"] = y.Art;
                ViewData["num1"] = y.num1;
                ViewData["num2"] = y.num2;
            }
            else
            {
                var y = (from item in db.param_paiement where item.Art == 907 & item.num1 == 10 select item).SingleOrDefault();
                ViewData["art"] = y.Art;
                ViewData["num1"] = y.num1;
                ViewData["num2"] = y.num2;
            }
        }


        /***************deplacement*******************/
        public IActionResult get_data2()
        {
            string curr_Date = null;
            curr_Date = System.DateTime.Today.ToString("dd/MM/yyyy");
           
            nompers = Request.Form["NomPersonel"].ToString();
            HttpContext.Session.SetString("pers" , nompers);
            mois = Request.Form["annee"].ToString();
            anneee = Request.Form["mois"].ToString();
            numop = Request.Form["nump"].ToString();
            numv = Request.Form["numv"].ToString();
            faitpar = Request.Form["faitpar"].ToString();
            ViewBag.selectedValue = nompers;
            ViewBag.valueYear = mois;
            ViewBag.valueMonth = anneee;
            ViewData["nompers"] = curr_Date;
            ViewData["date"] = nompers;
            ViewBag.numop = numop;
            ViewBag.numv = numv;
            ViewBag.faitpart = faitpar;
            Deplacement();
            get_parametre_for_deplacement();
            var pdf = new ViewAsPdf("test3",ViewData);
            return pdf;
        }




        public IActionResult Deplacement()
        {
            List<grilleTb> listeGrille = new List<grilleTb>();

            int k = 0;
            int Decouches = 0;
            // recuperer donnee de la form
            string nomP = Request.Form["NomPersonel"].ToString();
            name = nomP;
            string anneeOrdre = Request.Form["annee"].ToString();
            string moisOrdre = Request.Form["mois"].ToString();
            ViewBag.selectedValue = nomP;
            ViewBag.valueYear = anneeOrdre;
            ViewBag.valueMonth = moisOrdre;

            int year = Convert.ToInt32(anneeOrdre);
            int month = Convert.ToInt32(moisOrdre);


            List<int> TotaleJourDecoucheMois = new List<int>();
            List<int> TotaleReppasMidiMois = new List<int>();
            List<int> TotaleReppasSoirMois = new List<int>();

            List<OrdreMission> orders = db.ordremission.Where(s => s.dateDepart.Year == year && (s.dateDepart.Month == month || s.dateArrivee.Month == month) && s.personel.Nom
             == nomP).ToList();

            foreach (var ordre in orders)
            {
                testCinqMatin = false;
                testMinhuit = false;

                // calcule jours Decouche
                TotaleJourDecoucheMois.Add(CalculeNbJourDecouche(ordre, month));
                for (k = 0; k < NbJourDecouche; k++)
                {

                    listeJours.Add(ordre.dateDepart.Day + k);
                }

                for (k = 0; k < nbJour1; k++)
                {
                    listeJours.Add(k + 1);
                }
                for (k = 0; k < nbJour2; k++)
                {
                    listeJours.Add(ordre.dateDepart.Day + k);
                }
                // ajouter une decouche si condition minhuit et cinq matin
                if (testCinqMatin == true) { listeJours.Add(ordre.dateDepart.Day - 1); }
                if (testMinhuit == true) { listeJours.Add(ordre.dateArrivee.Day); }

                // calcule nbre de repas midi
                TotaleReppasMidiMois.Add(CalculeNbRepasMidi(ordre, month));

                // calculer nbre de repas soir
                TotaleReppasSoirMois.Add(CalculeNbRepasSooir(ordre, month));

            }

            listeJours.Sort();
            // remplir liste de grille

            for (int i = 0; i < listeJours.Count; i++)
            {

                foreach (var ordre in orders)
                {

                    // dans meme mois
                    if (ordre.dateDepart.Month == month && ordre.dateArrivee.Month == month)
                    {
                        if (listeJours[i] >= ordre.dateDepart.Day && listeJours[i] <= ordre.dateArrivee.Day - 1)
                        {
                            List<Boolean> result = VerifierRepas(listeJours[i], ordre, month);
                            listeGrille.Add(new grilleTb(listeJours[i], result[0], result[1]));
                        }
                        // si condition cinq matin = true ou condMinHuit = true
                        if (ordre.dateDepart.Day - 1 == listeJours[i] || ordre.dateArrivee.Day == listeJours[i])
                        {
                            listeGrille.Add(new grilleTb(listeJours[i], false, false));
                            Decouches += 1;


                        }

                    }
                    // si sans depart dans le mois precendant
                    else if (ordre.dateDepart.Month == month && ordre.dateArrivee.Month != month)
                    {
                        if (listeJours[i] >= ordre.dateDepart.Day)
                        {
                            List<Boolean> result = VerifierRepas(listeJours[i], ordre, month);
                            listeGrille.Add(new grilleTb(listeJours[i], result[0], result[1]));
                        }
                        // si condition cinq matin = true
                        if (ordre.dateDepart.Day - 1 == listeJours[i])
                        {
                            listeGrille.Add(new grilleTb(listeJours[i], false, false));
                            Decouches += 1;
                        }

                    }
                    // si arrivee dans le mois prochain
                    else if (ordre.dateDepart.Month != month && ordre.dateArrivee.Month == month)
                    {
                        if (listeJours[i] <= ordre.dateArrivee.Day - 1)
                        {
                            List<Boolean> result = VerifierRepas(listeJours[i], ordre, month);
                            listeGrille.Add(new grilleTb(listeJours[i], result[0], result[1]));
                        }
                        // si condMinHuit = true
                        if (ordre.dateArrivee.Day == listeJours[i])
                        {
                            listeGrille.Add(new grilleTb(listeJours[i], false, false));
                            Decouches += 1;
                        }

                    }
                }


            }

            if (orders.Count() > 0)
            {

                // calcule de taux 
                Taux = CalculeTaux(orders[0]);

                // totale decouche
                foreach (var elem in TotaleJourDecoucheMois)
                {
                    Decouches = Decouches + elem;
                }
                TolaleDecouche = Taux * Decouches;

                // totale Repas Midi
                RepasMidi = 0;
                foreach (var elem in TotaleReppasMidiMois)
                {
                    RepasMidi = RepasMidi + elem;
                }
                TotaleRepasMidi = Taux * RepasMidi;

                //totale Repas Soir
                int RepasSoir = 0;
                foreach (var elem in TotaleReppasSoirMois)
                {
                    RepasSoir = RepasSoir + elem;
                }
                TotaleRepasSoir = Taux * RepasSoir;

                // totale de paimement de deplacement
                TotaleDeplacement = TolaleDecouche + TotaleRepasMidi + TotaleRepasSoir;


                listeJours.Sort();

                ViewData["mois"] = moisOrdre;
                ViewBag.nbRepasMidi = RepasMidi;
                ViewBag.nbRepasSoir = RepasSoir;
                ViewBag.listeGrille = listeGrille;
                ViewBag.size = listeGrille.Count;
                ViewBag.listeJours = listeJours;
                DateTime now = DateTime.Now;
                ViewData["date"] = now.ToString("MM/dd/yyyy");
                ViewData["taux"] = Taux;
                ViewData["NbJourDecouche"] = Decouches;
                ViewData["NbRepasMidi"] = RepasMidi;
                ViewData["NbRepasSoir"] = RepasSoir;
                ViewData["TolaleDecouche"] = TolaleDecouche;
                ViewData["TotaleRepasMidi"] = TotaleRepasMidi;
                ViewData["TotaleRepasSoir"] = TotaleRepasSoir;
                ViewData["TotaleDeplacement"] = TotaleDeplacement;
                HttpContext.Session.SetInt32("totale_dep" ,TotaleDeplacement);


                OrdreMission ordreMession = orders[0];

                return View(ordreMession);
            }
            else
            {

                return View("Test");
            }


        }
        // calcule repas soir
        public int CalculeNbRepasSooir(OrdreMission ordreMission, int month)
        {

            // calcule repas soir
            // NbRepasSoir se diminue lorsque le heure depart de personnel est >21:00 
            // NbRepasMidi se diminue lorsque le heure D'arrive dans le dernier jour est <19:00
            // si ces condition n'existe pas NbRepasMidi egale à NbJourDecouché

            DateTime HeureDepart = DateTime.Parse(ordreMission.heureDepart, System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureArreve = DateTime.Parse(ordreMission.heureArrivee, System.Globalization.CultureInfo.CurrentCulture);
            int NbJourDecouche0 = CalculeNbJourDecouche(ordreMission, month);
            NbRepasSoir = NbJourDecouche0;

            DateTime HeureCondition19 = DateTime.Parse("19:00", System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureCondition21 = DateTime.Parse("21:00", System.Globalization.CultureInfo.CurrentCulture);

            int result19 = DateTime.Compare(HeureArreve, HeureCondition19);
            int result21 = DateTime.Compare(HeureDepart, HeureCondition21);
            if (result19 < 0)
            {
                NbRepasSoir = NbRepasSoir - 1;
            }
            if (result21 > 0)
            {
                NbRepasSoir = NbRepasSoir - 1;
            }
            else
            {
                NbRepasSoir = NbRepasSoir;
            }

            return NbRepasSoir;
        }
        // calcule repas midi
        public int CalculeNbRepasMidi(OrdreMission ordreMission, int month)
        {
            // calcule repas midi
            // NbRepasMidi se diminue lorsque le heure Depart de personnel est >14:00 
            // NbRepasMidi se diminue lorsque le heure D'arrive dans le dernier jour est <11:00
            // si ces condition n'existe pas NbRepasMidi egale à NbJourDecouché
            int NbJourDecouche0 = CalculeNbJourDecouche(ordreMission, month);

            DateTime HeureDepart = DateTime.Parse(ordreMission.heureDepart, System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureArreve = DateTime.Parse(ordreMission.heureArrivee, System.Globalization.CultureInfo.CurrentCulture);

            NbRepasMidi = NbJourDecouche0;
            DateTime HeureConditionTime14 = DateTime.Parse("14:00", System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureConditionTime11 = DateTime.Parse("11:00", System.Globalization.CultureInfo.CurrentCulture);
            int resultTime14 = DateTime.Compare(HeureDepart, HeureConditionTime14);
            int resultTime11 = DateTime.Compare(HeureArreve, HeureConditionTime11);
            if (resultTime14 > 0)
            {
                NbRepasMidi = NbRepasMidi - 1;

            }
            if (resultTime11 < 0)
            {
                NbRepasMidi = NbRepasMidi - 1;

            }
            else
            {
                NbRepasMidi = NbRepasMidi;

            }
            return NbRepasMidi;
        }
        public int CalculeNbJourDecouche(OrdreMission ordreMission, int month)
        {

            nbJour1 = 0;
            nbJour2 = 0;
            nbJours = 0;
            DateTime dateDepart = ordreMission.dateDepart;
            DateTime dateArreve = ordreMission.dateArrivee;

            if (dateDepart.Month == dateArreve.Month)
            {

                TimeSpan Diff_dates = dateArreve.Subtract(dateDepart);
                NbJourDecouche = Diff_dates.Days;

                DateTime HeureDepart = DateTime.Parse(ordreMission.heureDepart, System.Globalization.CultureInfo.CurrentCulture);
                DateTime HeureArreve = DateTime.Parse(ordreMission.heureArrivee, System.Globalization.CultureInfo.CurrentCulture);

                // NbDecouche s'augmente lorsque le heure Depart de personnel est <=05:00 
                // NbDecouche s'augmente lorsque le heure D'arrive dans le dernier jour est >= 00:00
                DateTime HeureConditionCinqMatin = DateTime.Parse("05:00", System.Globalization.CultureInfo.CurrentCulture);
                DateTime HeureConditionMinuit = DateTime.Parse("23:00", System.Globalization.CultureInfo.CurrentCulture);
                int resultCinqMatin = DateTime.Compare(HeureDepart, HeureConditionCinqMatin);
                int resultMinuit = DateTime.Compare(HeureArreve, HeureConditionMinuit);
                if (resultCinqMatin <= 0)
                {

                    testCinqMatin = true;
                }
                if (resultMinuit >= 0)
                {

                    testMinhuit = true;
                }

            }
            else
            {
                DateTime HeureDepart = DateTime.Parse(ordreMission.heureDepart, System.Globalization.CultureInfo.CurrentCulture);
                DateTime HeureArreve = DateTime.Parse(ordreMission.heureArrivee, System.Globalization.CultureInfo.CurrentCulture);
                DateTime HeureConditionCinqMatin = DateTime.Parse("05:00", System.Globalization.CultureInfo.CurrentCulture);
                DateTime HeureConditionMinuit = DateTime.Parse("23:00", System.Globalization.CultureInfo.CurrentCulture);
                int resultCinqMatin = DateTime.Compare(HeureDepart, HeureConditionCinqMatin);
                int resultMinuit = DateTime.Compare(HeureArreve, HeureConditionMinuit);

                if (dateArreve.Month == month)
                {

                    nbJour1 = dateArreve.Day - 1;
                    if (resultMinuit >= 0)
                    {

                        testMinhuit = true;
                    }


                }
                if (dateDepart.Month == month)
                {

                    var lastDayOfMonth = DateTime.DaysInMonth(dateDepart.Year, dateDepart.Month);
                    nbJour2 = lastDayOfMonth - dateDepart.Day;
                    if (resultCinqMatin <= 0)
                    {

                        testCinqMatin = true;
                    }
                }

                nbJours = nbJour1 + nbJour2;
                NbJourDecouche = 0;
            }



            int resulats = NbJourDecouche + nbJours;
            return resulats;
        }

        // calcule Taux
        public int CalculeTaux(OrdreMission ordreMission)
        {
            // trauver le taux
            int echlonP = ordreMission.echlon;
            int echelleP = ordreMission.personel.Echelle;
            if (echlonP >= 702)
            {
                Taux = 100;
            }
            else
            {


                // test statique
                if (NbJourDecouche <= 15)
                {
                    if (echelleP >= 1 && echelleP <= 5)
                    {

                        var param = db.parametre.Where(s => s.nom == "grp5").FirstOrDefault<Parameter>();

                        Taux = param.valeur1;

                    }
                    else if (echelleP >= 6 && echelleP <= 7)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp4").FirstOrDefault<Parameter>();

                        Taux = param.valeur1;
                    }
                    else if (echelleP >= 8 && echelleP <= 10)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp3").FirstOrDefault<Parameter>();

                        Taux = param.valeur1;
                    }
                    else if (echelleP == 11)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp2").FirstOrDefault<Parameter>();

                        Taux = param.valeur1;
                    }
                    else if (echelleP >= 12)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp1").FirstOrDefault<Parameter>();

                        Taux = param.valeur1;
                    }
                }
                else
                {

                    if (echelleP >= 1 && echelleP <= 5)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp5").FirstOrDefault<Parameter>();

                        Taux = param.valeur2;

                    }
                    else if (echelleP >= 6 && echelleP <= 7)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp4").FirstOrDefault<Parameter>();

                        Taux = param.valeur2;
                    }
                    else if (echelleP >= 9 && echelleP <= 10)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp3").FirstOrDefault<Parameter>();

                        Taux = param.valeur2;
                    }
                    else if (echelleP == 11)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp2").FirstOrDefault<Parameter>();

                        Taux = param.valeur2;
                    }
                    else if (echelleP >= 12)
                    {
                        var param = db.parametre.Where(s => s.nom == "grp1").FirstOrDefault<Parameter>();

                        Taux = param.valeur2;
                    }

                }

            }
            return Taux;
        }
        public List<Boolean> verifierRepasCasDepart(OrdreMission ordre)
        {
            List<Boolean> resultComparaison = new List<Boolean>();
            DateTime HeureDepart = DateTime.Parse(ordre.heureDepart, System.Globalization.CultureInfo.CurrentCulture);

            DateTime HeureConditionTime14 = DateTime.Parse("14:00", System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureConditionTime21 = DateTime.Parse("21:00", System.Globalization.CultureInfo.CurrentCulture);

            int resultTime14 = DateTime.Compare(HeureDepart, HeureConditionTime14);
            int resultTime21 = DateTime.Compare(HeureDepart, HeureConditionTime21);

            // n'a pas de repas dejeuner et de diner
            if (resultTime21 > 0)
            {
                resultComparaison.Add(false);
                resultComparaison.Add(false);
            }
            // il a les deux repas
            else if (resultTime14 <= 0)
            {
                resultComparaison.Add(true);
                resultComparaison.Add(true);
            }
            // il n'a pas de dejeuner et il a le diner
            else if (resultTime14 >= 0)
            {
                resultComparaison.Add(false);
                resultComparaison.Add(true);
            }



            return resultComparaison;
        }

        // verifier Repas
        public List<Boolean> VerifierRepas(int jour, OrdreMission ordre, int mounth)
        {
            List<Boolean> resultat = new List<Boolean>();
            List<Boolean> resultat2 = new List<Boolean>();

            if (jour != ordre.dateDepart.Day && jour != (ordre.dateArrivee.Day - 1))
            {
                resultat.Add(true);
                resultat.Add(true);
            }
            if (jour == ordre.dateDepart.Day)
            {
                resultat2 = verifierRepasCasDepart(ordre);
                resultat.Add(resultat2[0]);
                resultat.Add(resultat2[1]);
            }
            if (jour == ordre.dateArrivee.Day - 1)
            {
                resultat2 = verifierRepasCasArrivee(ordre);
                resultat.Add(resultat2[0]);
                resultat.Add(resultat2[1]);
            }

            return resultat;
        }
        public List<Boolean> verifierRepasCasArrivee(OrdreMission ordre)
        {
            List<Boolean> resultComparaison = new List<Boolean>();
            DateTime HeurArrivee = DateTime.Parse(ordre.heureArrivee, System.Globalization.CultureInfo.CurrentCulture);

            DateTime HeureConditionTime11 = DateTime.Parse("11:00", System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureConditionTime14 = DateTime.Parse("14:00", System.Globalization.CultureInfo.CurrentCulture);
            DateTime HeureConditionTime19 = DateTime.Parse("19:00", System.Globalization.CultureInfo.CurrentCulture);
            int resultTime11 = DateTime.Compare(HeurArrivee, HeureConditionTime11);
            int resultTime14 = DateTime.Compare(HeurArrivee, HeureConditionTime14);
            int resultTime19 = DateTime.Compare(HeurArrivee, HeureConditionTime19);
            // n'a pas de repas dejeuner et de diner
            if (resultTime11 <= 0)
            {
                resultComparaison.Add(false);
                resultComparaison.Add(false);
            }
            // il a les deux repas
            if (resultTime19 >= 0)
            {
                resultComparaison.Add(true);
                resultComparaison.Add(true);
            }
            // il n'a pas de dejeuner et il a le diner
            if (resultTime19 < 0 && resultTime14 > 0)
            {
                resultComparaison.Add(true);
                resultComparaison.Add(false);
            }

            return resultComparaison;
        }


        public void get_parametre_for_deplacement()
        {
            string nomP = Request.Form["NomPersonel"].ToString();
            var x = (from item in db.personnels where item.Nom == nomP select item.Role).SingleOrDefault();
            if (x == "economique")
            {
                var y = (from item in db.param_paiement where item.Art == 920 & item.num2 == 14 select item).SingleOrDefault();
                ViewData["art"] = y.Art;
                ViewData["num1"] = y.num1;
                ViewData["num2"] = y.num2;
            }
            else
            {
                var y = (from item in db.param_paiement where item.Art == 907 & item.num1 == 34 select item).SingleOrDefault();
                ViewData["art"] = y.Art;
                ViewData["num1"] = y.num1;
                ViewData["num2"] = y.num2;
            }
        }

        public IActionResult virementKilometrage()
        {

            //var mylist = new List<OrdreMission>();

            //var list = db.ordremission.GroupBy(p => p.personel.IdPers);
            //foreach (var result in list)
            //{
            //    mylist.Add(result.ToList().ElementAt(0));
            //}
            List<Personnel> list = new List<Personnel>();
            var x = from p in db.personnels select new { p.Nom, p.Prenom };
            foreach (var item in x)
            {
                list.Add(new Personnel(item.Nom, item.Prenom));
            }
            ViewBag.list = list;
            return View(db.ordremission.ToList()) ;
        }

        public IActionResult virementDeplacement()
        {
            //var mylist = new List<OrdreMission>();

            //var list = db.ordremission.GroupBy(p => p.personel.IdPers);
            //foreach (var result in list)
            //{
            //    mylist.Add(result.ToList().ElementAt(0));
            //}
            List<Personnel> list = new List<Personnel>();
            var x = from p in db.personnels select new { p.Nom, p.Prenom };
            foreach (var item in x)
            {
                list.Add(new Personnel(item.Nom, item.Prenom));
            }
            ViewBag.list = list;

            return View(db.ordremission.ToList());
        }
        public IActionResult test2()
        {


            return View();
        }
        public IActionResult test3()
        {

            ViewBag.tt = TotaleDeplacement;
            return View();
        }



    }
}

