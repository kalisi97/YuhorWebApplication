using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace YuhorWebApp.DataAccessLayer
{
    public class BrokerBaze
    {
        SqlCommand komanda;
        SqlConnection konekcija;
        SqlTransaction transakcija;

        void konektujSe()
        {
            konekcija = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Yuhor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        BrokerBaze()
        {
            konektujSe();
        }

        public static BrokerBaze broker;
        public static BrokerBaze Sesija()
        {
            if (broker == null) broker = new BrokerBaze();
            return broker;
        }


        #region Artikal
        public string SacuvajArtikal(Artikal artikal)
        {
            SqlTransaction transakcija = null;
            string poruka = string.Empty;
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);
                
                switch (artikal.Status)
                {
                    case Status.Dodat:

                        komanda.CommandText =
                        $"insert into Artikal output inserted.artikalID values ('{artikal.naziv}', {artikal.pdv}, {artikal.rabat}, '{artikal.pdv}, {artikal.rabat}' , @aktuelnaCena)";
                        komanda.Parameters.AddWithValue("aktuelnaCena", DBNull.Value);
                        artikal.artikalID = Convert.ToInt32(komanda.ExecuteScalar());
                        break;
                    case Status.Izmenjen:
                        komanda.CommandText = $"update Artikal set naziv='{artikal.naziv}', pdv={artikal.pdv}, rabat={artikal.rabat}, artikalProcenti='{artikal.pdv}, {artikal.rabat}' where artikalID={artikal.artikalID}";
                        komanda.ExecuteNonQuery();
                        break;
                    case Status.Obrisan:
                        komanda.CommandText = $"Delete from Artikal where artikalID={artikal.artikalID}";
                        komanda.ExecuteNonQuery();
     
                        break;
                    default:
                        break;
                }

                foreach (Cena cena in artikal.ListaCena)
                {
                    SqlCommand komanda1 = new SqlCommand();
                    komanda1.Transaction = transakcija;
                    komanda1.Connection = konekcija;
                    switch (cena.Status)
                    {
                        case Status.Izmenjen:
                            komanda1.CommandText = $"update Cena set iznos={cena.iznos} where artikalID={artikal.artikalID} and datumOd=@datumOd";
                            komanda1.Parameters.Add("@datumOd", SqlDbType.DateTime2).Value = cena.datumOd;
                            komanda1.ExecuteNonQuery();
                            break;
                        case Status.Dodat:

                            komanda1.CommandText = $"insert into Cena values (@datumOd,@iznos,@artikalID)";
                            komanda1.Parameters.Add("@artikalID", SqlDbType.Int).Value = artikal.artikalID;
                            komanda1.Parameters.Add("@datumOd", SqlDbType.DateTime2).Value = cena.datumOd;
                            komanda1.Parameters.Add("@iznos", SqlDbType.Float).Value = cena.iznos;
                            komanda1.ExecuteNonQuery();
                            break;
                        case Status.Obrisan:

                            komanda1.CommandText = $"delete from Cena where datumOd = (@datumOd) and artikalID = {artikal.artikalID}";
                            komanda1.Parameters.Add("@datumOd", SqlDbType.DateTime2).Value = cena.datumOd;
                            komanda1.ExecuteNonQuery();
                            break;
                        default:
                            break;
                    }
                }
                
                transakcija.Commit();

                poruka = "Uspesno!";
                return poruka;
            }
            catch (Exception ex)
            {
                transakcija.Rollback();
                poruka = ex.Message.ToString();
                return poruka;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public Artikal VratiArtikal(int artikalId)
        {
            Artikal a = new Artikal();
            try
            {
                konekcija.Open();
                komanda = new SqlCommand("", konekcija, transakcija)
                {
                    CommandText = $"Select * from Artikal where artikalID={artikalId}"
                };
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    a.artikalID = citac.GetInt32(0);
                    a.naziv = citac.GetString(1);
                    a.pdv = citac.GetDouble(2);
                    a.rabat = citac.GetDouble(3);
                    a.aktuelnaCena = GetFloatValueOrDefault(citac, "aktuelnaCena");
                }
                citac.Close();


                komanda.CommandText = $"Select * from Cena where artikalID={artikalId}";
                citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Cena cena = new Cena
                    {
                        
                        datumOd = (DateTime)citac["datumOd"],
                        iznos = citac.GetDouble(1),
                        Artikal = a
                        
                       
                    };

                    a.ListaCena.Add(cena);

                }
                citac.Close();
                return a;
            }
            catch (Exception e)
            {
                return null;
            }
            finally { 
                if (konekcija != null) 
                    konekcija.Close(); 
            }
        }

        public BindingList<Artikal> VratiArtikle()
        {
            BindingList<Artikal> lista = new BindingList<Artikal>();
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija)
                {
                    CommandText = "Select * from Artikal"
                };
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Artikal a = new Artikal
                    {
                      artikalID = citac.GetInt32(0),
                      naziv = citac.GetString(1),
                      pdv = citac.GetDouble(2),
                      rabat = citac.GetDouble(3),
                      aktuelnaCena = GetFloatValueOrDefault(citac, "aktuelnaCena")

                };

                    lista.Add(a);
                }
                citac.Close();
                transakcija.Commit();

                return lista;
            }
            catch (Exception e)
            {
                transakcija.Rollback();
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        #endregion

        #region Reklamacija
        public List<Kupac> VratiKupce()
        {
            List<Kupac> lista = new List<Kupac>();
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija)
                {
                    CommandText = "Select * from Kupac"
                };
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Kupac k = new Kupac
                    {
                        kupacID = citac.GetInt32(0),
                        naziv = citac.GetString(1),
                        tr = citac.GetString(2),
                        mb = citac.GetString(3),
                        pib = citac["pib"].ToString()
                    };

                    lista.Add(k);
                }
                citac.Close();
                transakcija.Commit();

                return lista;
            }
            catch (Exception)
            {
                transakcija.Rollback();
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public BindingList<Reklamacija> VratiReklamacije()
        {
            BindingList<Reklamacija> lista = new BindingList<Reklamacija>();
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija)
                {
                    CommandText = "Select * from Reklamacija r join Kupac k on (r.kupacID = k.kupacID)"
                };
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Reklamacija r = new Reklamacija
                    {
                        brojReklamacije = citac.GetInt32(0),
                        datum = (DateTime)citac["datum"],
                        razlog = citac.GetString(2),
                        naziv = citac.GetString(4),
                        ukupno = GetFloatValueOrDefault(citac, "ukupno"),
                     
                        Kupac = new Kupac
                        {
                            kupacID = citac.GetInt32(6),
                            naziv = citac.GetString(7),
                            tr = citac.GetString(8),
                            mb = citac.GetString(9),
                            pib = citac["pib"].ToString()
                        }
                  
                    };

                    lista.Add(r);
                }
                citac.Close();
                transakcija.Commit();

                return lista;
            }
            catch (Exception e)
            {
                transakcija.Rollback();
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

    
        public float GetFloatValueOrDefault(SqlDataReader citac, string nazivKolone)
        {
            float data = (citac.IsDBNull(citac.GetOrdinal(nazivKolone)))
                        ? 0 : float.Parse(citac[nazivKolone].ToString());
            return data;
        }

        public string SacuvajReklamaciju(Reklamacija r)
        {
            SqlTransaction transakcija = null;
            string poruka = string.Empty;
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);

                switch (r.Status)
                {
                    case Status.Dodat:

                        komanda.CommandText =
                       $"insert into Reklamacija output inserted.brojReklamacije values (@datum, '{r.razlog}', {r.Kupac.kupacID}, '{r.naziv}',@ukupno)";
                        komanda.Parameters.Add("@datum", SqlDbType.DateTime2).Value = r.datum;
                        komanda.Parameters.AddWithValue("ukupno", DBNull.Value);
                        r.brojReklamacije = Convert.ToInt32(komanda.ExecuteScalar());
                        break;
                    case Status.Izmenjen:
                
                        komanda.CommandText = $"update Reklamacija set datum=@datum, razlog='{r.razlog}', kupacID={r.Kupac.kupacID}, naziv = '{r.naziv}' where brojReklamacije={r.brojReklamacije}";
                        komanda.Parameters.Add("@datum", SqlDbType.DateTime2).Value = r.datum;
                        komanda.ExecuteNonQuery();
                        break;
                    case Status.Obrisan:
                        komanda.CommandText = $"Delete from Reklamacija where brojReklamacije={r.brojReklamacije}";

                        komanda.ExecuteNonQuery();
                        break;
                    default:
                        break;
                }

                foreach (StavkaReklamacije sr in r.StavkeReklamacije)
                {
                    SqlCommand komanda1 = new SqlCommand();
                    komanda1.Transaction = transakcija;
                    komanda1.Connection = konekcija;
                    switch (sr.Status)
                    {
                        case Status.Izmenjen:
                            komanda1.CommandText = $"Update StavkaReklamacije set kolicina={sr.kolicina}, artikalID={sr.Artikal.artikalID}, razlog = '{sr.razlog}' where brojReklamacije={sr.brojReklamacije} and rb={sr.rb}";
                            komanda1.ExecuteNonQuery();
                            break;
                        case Status.Dodat:
                           
                            komanda1.CommandText = $"insert into StavkaReklamacije (brojReklamacije,  kolicina, artikalID, razlog) values ({r.brojReklamacije}, {sr.kolicina}, {sr.Artikal.artikalID}, '{sr.razlog}')";
                          
                            komanda1.ExecuteNonQuery();
                            break;
                        case Status.Obrisan:
                            komanda1.CommandText = $"Delete from StavkaReklamacije where brojReklamacije={sr.brojReklamacije} and rb={sr.rb}";
                            komanda1.ExecuteNonQuery();
                            break;
                        default:
                            break;
                    }
                }

                transakcija.Commit();

                poruka = "Uspesno!";
                return poruka;
            }
            catch (Exception ex)
            {
                transakcija.Rollback();
                poruka = ex.Message.ToString();
                return poruka;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }

        public Reklamacija VratiReklamaciju(int reklamacijaBr)
        {
            Reklamacija r = new Reklamacija();
            try
            {
                konekcija.Open();
                komanda = new SqlCommand("", konekcija, transakcija)
                {
                    CommandText = $"Select * from Reklamacija r inner join Kupac k on r.kupacID = k.kupacID where brojReklamacije={reklamacijaBr}"
                };
                SqlDataReader citac = komanda.ExecuteReader();

                while (citac.Read())
                {
                    r.brojReklamacije = citac.GetInt32(0);
                    r.datum = (DateTime)citac["datum"];
                    r.razlog = citac.GetString(2);
                    r.naziv = citac.GetString(4);
                    r.ukupno = GetFloatValueOrDefault(citac, "ukupno");
                    r.Kupac = new Kupac
                    {
                        kupacID = citac.GetInt32(6),
                        naziv = citac.GetString(7),
                        pib = citac.GetString(8),
                        mb = citac.GetString(9),
                        tr = citac.GetString(10)
                    };
            
                }
                citac.Close();
                
                komanda.CommandText = $"Select * from StavkaReklamacije sr inner join Artikal a on sr.artikalID = a.artikalID where brojReklamacije={reklamacijaBr}";
                citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    StavkaReklamacije sf = new StavkaReklamacije
                    {
                        brojReklamacije = citac.GetInt32(0),
                        rb = citac.GetInt32(1),
                        kolicina = citac.GetInt32(2),
                        razlog = citac.GetString(4),
                        Artikal = new Artikal
                        {
                            artikalID = citac.GetInt32(5),
                            naziv = citac.GetString(6),
                            pdv = citac.GetDouble(7),
                            rabat = citac.GetDouble(8)
                        }
                    };
                    sf.Artikal.aktuelnaCena = GetFloatValueOrDefault(citac, "aktuelnaCena");
                    

                    r.StavkeReklamacije.Add(sf);
                }
                citac.Close();
                
                return r;
            }
            catch (Exception e)
            {
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        #endregion

        #region Kupac 
        public string SacuvajKupca(Kupac Kupac)
        {
            string poruka = string.Empty;
            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija);

                switch (Kupac.Status)
                {
                    case Status.Dodat:
                        komanda.CommandText = $"Insert into Kupac values( '{Kupac.naziv}', '{Kupac.tr}','{Kupac.mb}','{Kupac.pib}')";
                        komanda.ExecuteNonQuery();
                        break;
                    case Status.Izmenjen:
                        komanda.CommandText = $"Update Kupac set naziv='{Kupac.naziv}', pib='{Kupac.pib}', mb='{Kupac.mb}', tr='{Kupac.tr}' where kupacID={Kupac.kupacID}";
                        komanda.ExecuteNonQuery();
                        break;
                    case Status.Obrisan:
                        komanda.CommandText = $"Delete from Kupac where kupacID={Kupac.kupacID}";
                        komanda.ExecuteNonQuery();
                        break;
                    default:
                        break;
                }

                transakcija.Commit();

                poruka = "Uspesno!";
                return poruka;
            }
            catch (Exception ex)
            {
                transakcija.Rollback();
                poruka = ex.Message.ToString();
                return poruka;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }


        public Kupac VratiKupca(int kupacId)
        {

            try
            {
                konekcija.Open();
                transakcija = konekcija.BeginTransaction();
                komanda = new SqlCommand("", konekcija, transakcija)
                {
                    CommandText = $"Select kupacID, naziv, tr, mb, pib from Kupac where kupacID={kupacId}"
                };
                SqlDataReader citac = komanda.ExecuteReader();
                while (citac.Read())
                {
                    Kupac k = new Kupac
                    {
                        kupacID = citac.GetInt32(0),
                        naziv = citac.GetString(1),
                        tr = citac.GetString(2),
                        mb = citac.GetString(3),
                        pib = citac["pib"].ToString()
                    };

                    citac.Close();

                    return k;
                }
                citac.Close();
                transakcija.Commit();

                return null;
            }
            catch (Exception e)
            {
                transakcija.Rollback();
                return null;
            }
            finally { if (konekcija != null) konekcija.Close(); }
        }
        #endregion
    }
}
