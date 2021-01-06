using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
namespace JudgesDrawMDD
{   
    public class EventFinalCountries : ObservableCollection<FinalCountries>
    {
        public EventFinalCountries() { }
        public EventFinalCountries(string archivo) : base()
        {
            basededatos<FinalCountries> bdhorario = new basededatos<FinalCountries>(archivo);
            bdhorario.Cargar();
            foreach (FinalCountries lh in bdhorario.valores)
            {
                Add(lh);
            }
        }
        public void Guardar(string archivo)
        {
            basededatos<FinalCountries> bdhorario = new basededatos<FinalCountries>(archivo);
            bdhorario.GuardarObservableCollection(this);
        }
    }

    public class FinalCountries : INotifyPropertyChanged
    {
        public FinalCountries() { }

        private string _CatModEx;
        private string _Country1;
        private string _Country2;
        private string _Country3;
        private string _Country4;
        private string _Country5;
        private string _Country6;
        private string _Country7;
        private string _Country8;
        private string _Country9;
        private string _Country10;
        private string _CountryR1;
        private string _CountryR2;

        public string CatModEx
        {
            get
            {
                return this._CatModEx;
            }

            set
            {
                if (value != this._CatModEx)
                {
                    this._CatModEx = value;
                    OnChanged("CatModEx");

                }
            }
        }
        public string Country1
        {
            get
            {
                return this._Country1;
            }

            set
            {
                if (value != this._Country1)
                {
                    this._Country1 = value;
                    OnChanged("Country1");

                }
            }
        }
        public string CountryFlag1
        {
            get
            {
                if (!string.IsNullOrEmpty(Country1))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country1.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country2
        {
            get
            {
                return this._Country2;
            }

            set
            {
                if (value != this._Country2)
                {
                    this._Country2 = value;
                    OnChanged("Country2");

                }
            }
        }
        public string CountryFlag2
        {
            get
            {
                if (!string.IsNullOrEmpty(Country2))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country2.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country3
        {
            get
            {
                return this._Country3;
            }

            set
            {
                if (value != this._Country3)
                {
                    this._Country3 = value;
                    OnChanged("Country3");

                }
            }
        }
        public string CountryFlag3
        {
            get
            {
                if (!string.IsNullOrEmpty(Country3))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country3.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country4
        {
            get
            {
                return this._Country4;
            }

            set
            {
                if (value != this._Country4)
                {
                    this._Country4 = value;
                    OnChanged("Country4");

                }
            }
        }
        public string CountryFlag4
        {
            get
            {
                if (!string.IsNullOrEmpty(Country4))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country4.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country5
        {
            get
            {
                return this._Country5;
            }

            set
            {
                if (value != this._Country5)
                {
                    this._Country5 = value;
                    OnChanged("Country5");

                }
            }
        }
        public string CountryFlag5
        {
            get
            {
                if (!string.IsNullOrEmpty(Country5))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country5.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country6
        {
            get
            {
                return this._Country6;
            }

            set
            {
                if (value != this._Country6)
                {
                    this._Country6 = value;
                    OnChanged("Country6");

                }
            }
        }
        public string CountryFlag6
        {
            get
            {
                if (!string.IsNullOrEmpty(Country6))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country6.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country7
        {
            get
            {
                return this._Country7;
            }

            set
            {
                if (value != this._Country7)
                {
                    this._Country7 = value;
                    OnChanged("Country7");

                }
            }
        }
        public string CountryFlag7
        {
            get
            {
                if (!string.IsNullOrEmpty(Country7))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country7.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country8
        {
            get
            {
                return this._Country8;
            }

            set
            {
                if (value != this._Country8)
                {
                    this._Country8 = value;
                    OnChanged("Country8");

                }
            }
        }
        public string CountryFlag8
        {
            get
            {
                if (!string.IsNullOrEmpty(Country8))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country8.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string Country9
        {
            get
            {
                return this._Country9;
            }

            set
            {
                if (value != this._Country9)
                {
                    this._Country9 = value;
                    OnChanged("Country9");

                }
            }
        }
        public string CountryFlag9
        {
            get
            {
                if (!string.IsNullOrEmpty(Country9))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country9.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }

        public string Country10
        {
            get
            {
                return this._Country10;
            }

            set
            {
                if (value != this._Country10)
                {
                    this._Country10 = value;
                    OnChanged("Country10");

                }
            }
        }
        public string CountryFlag10
        {
            get
            {
                if (!string.IsNullOrEmpty(Country10))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country10.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }
        public string CountryR1
        {
            get
            {
                return this._CountryR1;
            }

            set
            {
                if (value != this._CountryR1)
                {
                    this._CountryR1 = value;
                    OnChanged("CountryR1");

                }
            }
        }
        public string CountryFlagR1
        {
            get
            {
                if (!string.IsNullOrEmpty(CountryR1))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(CountryR1.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        } 
        public string CountryR2
        {
            get
            {
                return this._CountryR2;
            }

            set
            {
                if (value != this._CountryR2)
                {
                    this._CountryR2 = value;
                    OnChanged("CountryR2");
                }
            }
        }

        public string CountryFlagR2
        {
            get
            {
                if (!string.IsNullOrEmpty(CountryR2))
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(CountryR2.ToUpper()).Alpha2 + ".png";
                }
                else
                {
                    return null;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
    public class Evento : INotifyPropertyChanged
    {
        // Datos del evento
        private string _Event_Name;
        private string _Date;
        private string _Place;
        private string _Event_logo;
        // Panel 1 Clasificaciones
        private string _P1QNoSameCountryInSame;
        private string _P1QNoLimitCat4Judges;
        private int _P1QEjudges;
        private int _P1QAjudges;
        private int _P1QREjudges;
        private int _P1QRAjudges;
        private int _P1QTjudges;
        private int _P1QMaxCat4judges;
        //Panel 1 Finales
        private string _P1F3Condition;
        private string _P1FNoSameCountryInSame;
        private string _P1FReserveContriesToReserveJudges;
        private string _P1FNoLimitCat4Judges;
        private int _P1FEjudges;
        private int _P1FAjudges;
        private int _P1FREjudges;
        private int _P1FRAjudges;
        private int _P1FTjudges;
        private int _P1FMaxCat4judges;
        // Panel 2 Clasificaciones
        private string _P2QNoSameCountryInSame;
        private string _P2QNoLimitCat4Judges;
        private int _P2QEjudges;
        private int _P2QAjudges;
        private int _P2QREjudges;
        private int _P2QRAjudges;
        private int _P2QTjudges;
        private int _P2QMaxCat4judges;
        // Panel 2 Finales
        private string _P2F3Condition;
        private string _P2FNoSameCountryInSame;
        private string _P2FReserveContriesToReserveJudges;
        private string _P2FNoLimitCat4Judges;
        private int _P2FEjudges;
        private int _P2FAjudges;
        private int _P2FREjudges;
        private int _P2FRAjudges;
        private int _P2FTjudges;
        private int _P2FMaxCat4judges;
        // Linea e Inquiry
        private int _Ljudges;
        private int _Ijudges;
        // Jurado Superior
        private string _SJPJudge;
        private string _SJD1Judge;
        private string _SJD2Judge;
        private string _SJE1Judge;
        private string _SJE2Judge;
        private string _SJA1Judge;
        private string _SJA2Judge;
        private string _CPJP1;
        private string _CPJP2;
        private string _WP1116BALD1;
        private string _WP1116BALD2;
        private string _WP1116DYND1;
        private string _WP1116DYND2;
        private string _MP1116BALD1;
        private string _MP1116BALD2;
        private string _MP1116DYND1;
        private string _MP1116DYND2;
        private string _MXP1116BALD1;
        private string _MXP1116BALD2;
        private string _MXP1116DYND1;
        private string _MXP1116DYND2;
        private string _WG1116BALD1;
        private string _WG1116BALD2;
        private string _WG1116DYND1;
        private string _WG1116DYND2;
        private string _MG1116BALD1;
        private string _MG1116BALD2;
        private string _MG1116DYND1;
        private string _MG1116DYND2;

        private string _WP1218BALD1;
        private string _WP1218BALD2;
        private string _WP1218DYND1;
        private string _WP1218DYND2;
        private string _WP1218COMD1;
        private string _WP1218COMD2;
        private string _MP1218BALD1;
        private string _MP1218BALD2;
        private string _MP1218DYND1;
        private string _MP1218DYND2;
        private string _MP1218COMD1;
        private string _MP1218COMD2;
        private string _MXP1218BALD1;
        private string _MXP1218BALD2;
        private string _MXP1218DYND1;
        private string _MXP1218DYND2;
        private string _MXP1218COMD1;
        private string _MXP1218COMD2;
        private string _WG1218BALD1;
        private string _WG1218BALD2;
        private string _WG1218DYND1;
        private string _WG1218DYND2;
        private string _WG1218COMD1;
        private string _WG1218COMD2;
        private string _MG1218BALD1;
        private string _MG1218BALD2;
        private string _MG1218DYND1;
        private string _MG1218DYND2;
        private string _MG1218COMD1;
        private string _MG1218COMD2;


        private string _WP1319BALD1;
        private string _WP1319BALD2;
        private string _WP1319DYND1;
        private string _WP1319DYND2;
        private string _WP1319COMD1;
        private string _WP1319COMD2;
        private string _MP1319BALD1;
        private string _MP1319BALD2;
        private string _MP1319DYND1;
        private string _MP1319DYND2;
        private string _MP1319COMD1;
        private string _MP1319COMD2;
        private string _MXP1319BALD1;
        private string _MXP1319BALD2;
        private string _MXP1319DYND1;
        private string _MXP1319DYND2;
        private string _MXP1319COMD1;
        private string _MXP1319COMD2;
        private string _WG1319BALD1;
        private string _WG1319BALD2;
        private string _WG1319DYND1;
        private string _WG1319DYND2;
        private string _WG1319COMD1;
        private string _WG1319COMD2;
        private string _MG1319BALD1;
        private string _MG1319BALD2;
        private string _MG1319DYND1;
        private string _MG1319DYND2;
        private string _MG1319COMD1;
        private string _MG1319COMD2;

        private string _WPSENBALD1;
        private string _WPSENBALD2;
        private string _WPSENDYND1;
        private string _WPSENDYND2;
        private string _WPSENCOMD1;
        private string _WPSENCOMD2;
        private string _MPSENBALD1;
        private string _MPSENBALD2;
        private string _MPSENDYND1;
        private string _MPSENDYND2;
        private string _MPSENCOMD1;
        private string _MPSENCOMD2;
        private string _MXPSENBALD1;
        private string _MXPSENBALD2;
        private string _MXPSENDYND1;
        private string _MXPSENDYND2;
        private string _MXPSENCOMD1;
        private string _MXPSENCOMD2;
        private string _WGSENBALD1;
        private string _WGSENBALD2;
        private string _WGSENDYND1;
        private string _WGSENDYND2;
        private string _WGSENCOMD1;
        private string _WGSENCOMD2;
        private string _MGSENBALD1;
        private string _MGSENBALD2;
        private string _MGSENDYND1;
        private string _MGSENDYND2;
        private string _MGSENCOMD1;
        private string _MGSENCOMD2;

        private string _Panel1Name;
        private string _Panel2Name;
        private string _MaxJuecesE;
        private string _MaxJuecesA;
        private bool _HasAgeGroup1116;
        private bool _HasAgeGroup1218;
        private bool _HasAgeGroup1319;
        private bool _HasSenior;


        public string Event_Name
        {
            get
            {
                return this._Event_Name;
            }

            set
            {
                if (value != this._Event_Name)
                {
                    this._Event_Name = value;
                    OnChanged("Event_Name");

                }
            }
        }
        public string Date
        {
            get
            {
                return this._Date;
            }

            set
            {
                if (value != this._Date)
                {
                    this._Date = value;
                    OnChanged("Date");

                }
             }
        }
        public string Place
        {
            get
            {
                return this._Place;
            }

            set
            {
                if (value != this._Place)
                {
                    this._Place = value;
                    OnChanged("Place");

                }
            }
        }
        public string Event_logo
        {
            get
            {
                return this._Event_logo;
            }

            set
            {
                if (value != this._Event_logo)
                {
                    this._Event_logo = value;
                    OnChanged("Event_logo");

                }
            }
        }

        // Otras caracteristicas

        public string Panel1Name
        {
            get
            {
                return this._Panel1Name;
            }

            set
            {
                if (value != this._Panel1Name)
                {
                    this._Panel1Name = value;
                    OnChanged("Panel1Name");

                }
            }
        }
        public string Panel2Name
        {
            get
            {
                return this._Panel2Name;
            }

            set
            {
                if (value != this._Panel2Name)
                {
                    this._Panel2Name = value;
                    OnChanged("Panel2Name");

                }
            }
        }
        public string MaxJuecesE
        {
            get
            {
                return this._MaxJuecesE;
            }

            set
            {
                if (value != this._MaxJuecesE)
                {
                    this._MaxJuecesE = value;
                    OnChanged("MaxJuecesE");

                }
            }
        }
        public string MaxJuecesA
        {
            get
            {
                return this._MaxJuecesA;
            }

            set
            {
                if (value != this._MaxJuecesA)
                {
                    this._MaxJuecesA = value;
                    OnChanged("MaxJuecesA");

                }
            }
        }

        public bool HasAgeGroup1116
        {
            get
            {
                return this._HasAgeGroup1116;
            }

            set
            {
                if (value != this._HasAgeGroup1116)
                {
                    this._HasAgeGroup1116 = value;
                    OnChanged("HasAgeGroup1116");
                }
            }
        }

        public bool HasAgeGroup1218
        {
            get
            {
                return this._HasAgeGroup1218;
            }

            set
            {
                if (value != this._HasAgeGroup1218)
                {
                    this._HasAgeGroup1218 = value;
                    OnChanged("HasAgeGroup1218");
                }
            }
        }
        public bool HasAgeGroup1319
        {
            get
            {
                return this._HasAgeGroup1319;
            }

            set
            {
                if (value != this._HasAgeGroup1319)
                {
                    this._HasAgeGroup1319 = value;
                    OnChanged("HasAgeGroup1319");
                }
            }
        }
        public bool HasSenior
        {
            get
            {
                return this._HasSenior;
            }

            set
            {
                if (value != this._HasSenior)
                {
                    this._HasSenior = value;
                    OnChanged("HasSenior");
                }
            }
        }

        // Panel 1 Clasificaciones
        public string P1QNoSameCountryInSame
        {
            get
            {
                return this._P1QNoSameCountryInSame;
            }

            set
            {
                if (value != this._P1QNoSameCountryInSame)
                {
                    this._P1QNoSameCountryInSame = value;
                    OnChanged("P1QNoSameCountryInSame");

                }
            }
        }
        public string P1QNoLimitCat4Judges
        {
            get
            {
                return this._P1QNoLimitCat4Judges;
            }

            set
            {
                if (value != this._P1QNoLimitCat4Judges)
                {
                    this._P1QNoLimitCat4Judges = value;
                    OnChanged("P1QNoLimitCat4Judges");

                }
            }
        }
        public int P1QEjudges
        {
            get
            {
                return this._P1QEjudges;
            }

            set
            {
                if (value != this._P1QEjudges)
                {
                    this._P1QEjudges = value;
                    OnChanged("P1QEjudges");

                }
            }
        }
        public int P1QAjudges
        {
            get
            {
                return this._P1QAjudges;
            }

            set
            {
                if (value != this._P1QAjudges)
                {
                    this._P1QAjudges = value;
                    OnChanged("P1QAjudges");

                }
            }
        }
        public int P1QREjudges
        {
            get
            {
                return this._P1QREjudges;
            }

            set
            {
                if (value != this._P1QREjudges)
                {
                    this._P1QREjudges = value;
                    OnChanged("P1QREjudges");

                }
            }
        }
        public int P1QRAjudges
        {
            get
            {
                return this._P1QRAjudges;
            }

            set
            {
                if (value != this._P1QRAjudges)
                {
                    this._P1QRAjudges = value;
                    OnChanged("P1QRAjudges");

                }
            }
        }
        public int P1QTjudgeS
        {
            get
            {
                return this._P1QEjudges;
            }

            set
            {
                if (value != this._P1QEjudges)
                {
                    this._P1QEjudges = value;
                    OnChanged("P1QEjudges");

                }
            }
        }
        public int P1QMaxCat4judges
        {
            get
            {
                return this._P1QMaxCat4judges;
            }

            set
            {
                if (value != this._P1QMaxCat4judges)
                {
                    this._P1QMaxCat4judges = value;
                    OnChanged("P1QMaxCat4judges");

                }
            }
        }
        
        public int P1QTjudges
        {
            get
            {
                return this._P1QTjudges;
            }

            set
            {
                if (value != this._P1QTjudges)
                {
                    this._P1QTjudges = value;
                    OnChanged("P1QTjudges");

                }
            }
        }


        //Panel 1 Finales
        public string P1F3Condition
        {
            get
            {
                return this._P1F3Condition;
            }

            set
            {
                if (value != this._P1F3Condition)
                {
                    this._P1F3Condition = value;
                    OnChanged("P1F3Condition");

                }
            }
        }
        public string P1FNoSameCountryInSame
        {
            get
            {
                return this._P1FNoSameCountryInSame;
            }

            set
            {
                if (value != this._P1FNoSameCountryInSame)
                {
                    this._P1FNoSameCountryInSame = value;
                    OnChanged("P1FNoSameCountryInSame");

                }
            }
        }
        
         public string P1FReserveContriesToReserveJudges
        {
            get
            {
                return this._P1FReserveContriesToReserveJudges;
            }

            set
            {
                if (value != this._P1FReserveContriesToReserveJudges)
                {
                    this._P1FReserveContriesToReserveJudges = value;
                    OnChanged("P1FReserveContriesToReserveJudges");

                }
            }
        }
        public string P1FNoLimitCat4Judges
        {
            get
            {
                return this._P1FNoLimitCat4Judges;
            }

            set
            {
                if (value != this._P1FNoLimitCat4Judges)
                {
                    this._P1FNoLimitCat4Judges = value;
                    OnChanged("P1FNoLimitCat4Judges");

                }
            }
        }
        public int P1FEjudges
        {
            get
            {
                return this._P1FEjudges;
            }

            set
            {
                if (value != this._P1FEjudges)
                {
                    this._P1FEjudges = value;
                    OnChanged("P1FEjudges");

                }
            }
        }
        public int P1FAjudges
        {
            get
            {
                return this._P1FAjudges;
            }

            set
            {
                if (value != this._P1FAjudges)
                {
                    this._P1FAjudges = value;
                    OnChanged("P1FAjudges");

                }
            }
        }
        public int P1FREjudges
        {
            get
            {
                return this._P1FREjudges;
            }

            set
            {
                if (value != this._P1FREjudges)
                {
                    this._P1FREjudges = value;
                    OnChanged("P1FREjudges");

                }
            }
        }
        public int P1FRAjudges
        {
            get
            {
                return this._P1FRAjudges;
            }

            set
            {
                if (value != this._P1FRAjudges)
                {
                    this._P1FRAjudges = value;
                    OnChanged("P1FRAjudges");

                }
            }
        }
        public int P1FTjudges
        {
            get
            {
                return this._P1FTjudges;
            }

            set
            {
                if (value != this._P1FTjudges)
                {
                    this._P1FTjudges = value;
                    OnChanged("P1FTjudges");

                }
            }
        }
        public int P1FMaxCat4judges
        {
            get
            {
                return this._P1FMaxCat4judges;
            }

            set
            {
                if (value != this._P1FMaxCat4judges)
                {
                    this._P1FMaxCat4judges = value;
                    OnChanged("P1FMaxCat4judges");

                }
            }
        }
        // Panel 2 Clasificaciones
        public string P2QNoSameCountryInSame
        {
            get
            {
                return this._P2QNoSameCountryInSame;
            }

            set
            {
                if (value != this._P2QNoSameCountryInSame)
                {
                    this._P2QNoSameCountryInSame = value;
                    OnChanged("P2QNoSameCountryInSame");

                }
            }
        }
        public string P2QNoLimitCat4Judges
        {
            get
            {
                return this._P2QNoLimitCat4Judges;
            }

            set
            {
                if (value != this._P2QNoLimitCat4Judges)
                {
                    this._P2QNoLimitCat4Judges = value;
                    OnChanged("P2QNoLimitCat4Judges");

                }
            }
        }
        public int P2QEjudges
        {
            get
            {
                return this._P2QEjudges;
            }

            set
            {
                if (value != this._P2QEjudges)
                {
                    this._P2QEjudges = value;
                    OnChanged("P2QEjudges");

                }
            }
        }
        public int P2QAjudges
        {
            get
            {
                return this._P2QAjudges;
            }

            set
            {
                if (value != this._P2QAjudges)
                {
                    this._P2QAjudges = value;
                    OnChanged("P2QAjudges");

                }
            }
        }
        public int P2QREjudges
        {
            get
            {
                return this._P2QREjudges;
            }

            set
            {
                if (value != this._P2QREjudges)
                {
                    this._P2QREjudges = value;
                    OnChanged("P2QREjudges");

                }
            }
        }
        public int P2QRAjudges
        {
            get
            {
                return this._P2QRAjudges;
            }

            set
            {
                if (value != this._P2QRAjudges)
                {
                    this._P2QRAjudges = value;
                    OnChanged("P2QRAjudges");

                }
            }
        }
        public int P2QTjudgeS
        {
            get
            {
                return this._P2QEjudges;
            }

            set
            {
                if (value != this._P2QEjudges)
                {
                    this._P2QEjudges = value;
                    OnChanged("P2QEjudges");

                }
            }
        }
        public int P2QMaxCat4judges
        {
            get
            {
                return this._P2QMaxCat4judges;
            }

            set
            {
                if (value != this._P2QMaxCat4judges)
                {
                    this._P2QMaxCat4judges = value;
                    OnChanged("P2QMaxCat4judges");

                }
            }
        }
        public int P2QTjudges
        {
            get
            {
                return this._P2QTjudges;
            }

            set
            {
                if (value != this._P2QTjudges)
                {
                    this._P2QTjudges = value;
                    OnChanged("P2QTjudges");

                }
            }
        }
        //Panel 2 Finales
        public string P2F3Condition
        {
            get
            {
                return this._P2F3Condition;
            }

            set
            {
                if (value != this._P2F3Condition)
                {
                    this._P2F3Condition = value;
                    OnChanged("P2F3Condition");

                }
            }
        }
        public string P2FNoSameCountryInSame
        {
            get
            {
                return this._P2FNoSameCountryInSame;
            }

            set
            {
                if (value != this._P2FNoSameCountryInSame)
                {
                    this._P2FNoSameCountryInSame = value;
                    OnChanged("P2FNoSameCountryInSame");

                }
            }
        }
        public string P2FReserveContriesToReserveJudges
        {
            get
            {
                return this._P2FReserveContriesToReserveJudges;
            }

            set
            {
                if (value != this._P2FReserveContriesToReserveJudges)
                {
                    this._P2FReserveContriesToReserveJudges = value;
                    OnChanged("P2FReserveContriesToReserveJudges");

                }
            }
        }
        public string P2FNoLimitCat4Judges
        {
            get
            {
                return this._P2FNoLimitCat4Judges;
            }

            set
            {
                if (value != this._P2FNoLimitCat4Judges)
                {
                    this._P2FNoLimitCat4Judges = value;
                    OnChanged("P2FNoLimitCat4Judges");

                }
            }
        }
        public int P2FEjudges
        {
            get
            {
                return this._P2FEjudges;
            }

            set
            {
                if (value != this._P2FEjudges)
                {
                    this._P2FEjudges = value;
                    OnChanged("P2FEjudges");

                }
            }
        }
        public int P2FAjudges
        {
            get
            {
                return this._P2FAjudges;
            }

            set
            {
                if (value != this._P2FAjudges)
                {
                    this._P2FAjudges = value;
                    OnChanged("P2FAjudges");

                }
            }
        }
        public int P2FREjudges
        {
            get
            {
                return this._P2FREjudges;
            }

            set
            {
                if (value != this._P2FREjudges)
                {
                    this._P2FREjudges = value;
                    OnChanged("P2FREjudges");

                }
            }
        }
        public int P2FRAjudges
        {
            get
            {
                return this._P2FRAjudges;
            }

            set
            {
                if (value != this._P2FRAjudges)
                {
                    this._P2FRAjudges = value;
                    OnChanged("P2FRAjudges");

                }
            }
        }
        public int P2FTjudges
        {
            get
            {
                return this._P2FTjudges;
            }

            set
            {
                if (value != this._P2FTjudges)
                {
                    this._P2FTjudges = value;
                    OnChanged("P2FTjudges");

                }
            }
        }
        public int P2FMaxCat4judges
        {
            get
            {
                return this._P2FMaxCat4judges;
            }

            set
            {
                if (value != this._P2FMaxCat4judges)
                {
                    this._P2FMaxCat4judges = value;
                    OnChanged("P2FMaxCat4judges");

                }
            }
        }        
        // Linea e Inquiry
        public int Ljudges
        {
            get
            {
                return this._Ljudges;
            }

            set
            {
                if (value != this._Ljudges)
                {
                    this._Ljudges = value;
                    OnChanged("Ljudges");

                }
            }
        }
        public int Ijudges
        {
            get
            {
                return this._Ijudges;
            }

            set
            {
                if (value != this._Ijudges)
                {
                    this._Ijudges = value;
                    OnChanged("Ijudges");

                }
            }
        }
        // Jurado Superior

        public string SJPJudge
        {
            get
            {
                return this._SJPJudge;
            }

            set
            {
                if (value != this._SJPJudge)
                {
                    this._SJPJudge = value;
                    OnChanged("SJPJudge");

                }
            }
        }
        public string SJD1Judge
        {
            get
            {
                return this._SJD1Judge;
            }

            set
            {
                if (value != this._SJD1Judge)
                {
                    this._SJD1Judge = value;
                    OnChanged("SJD1Judge");

                }
            }
        }
        public string SJD2Judge
        {
            get
            {
                return this._SJD2Judge;
            }

            set
            {
                if (value != this._SJD2Judge)
                {
                    this._SJD2Judge = value;
                    OnChanged("SJD2Judge");

                }
            }
        }
        public string SJE1Judge
        {
            get
            {
                return this._SJE1Judge;
            }

            set
            {
                if (value != this._SJE1Judge)
                {
                    this._SJE1Judge = value;
                    OnChanged("SJE1Judge");

                }
            }
        }
        public string SJE2Judge
        {
            get
            {
                return this._SJE2Judge;
            }

            set
            {
                if (value != this._SJE2Judge)
                {
                    this._SJE2Judge = value;
                    OnChanged("SJE2Judge");

                }
            }
        }
        public string SJA1Judge
        {
            get
            {
                return this._SJA1Judge;
            }

            set
            {
                if (value != this._SJA1Judge)
                {
                    this._SJA1Judge = value;
                    OnChanged("SJA1Judge");

                }
            }
        }
        public string SJA2Judge
        {
            get
            {
                return this._SJA2Judge;
            }

            set
            {
                if (value != this._SJA2Judge)
                {
                    this._SJA2Judge = value;
                    OnChanged("SJA2Judge");

                }
            }
        }
        public string CPJP1
        {
            get
            {
                return this._CPJP1;
            }

            set
            {
                if (value != this._CPJP1)
                {
                    this._CPJP1 = value;
                    OnChanged("CPJP1");

                }
            }
        }
        public string CPJP2
        {
            get
            {
                return this._CPJP2;
            }

            set
            {
                if (value != this._CPJP2)
                {
                    this._CPJP2 = value;
                    OnChanged("CPJP2");

                }
            }
        }

        // Jueces de Dificultad

            //11-16
        public string WP1116BALD1
        {
            get
            {
                return this._WP1116BALD1;
            }

            set
            {
                if (value != this._WP1116BALD1)
                {
                    this._WP1116BALD1 = value;
                    OnChanged("WP1116BALD1");

                }
            }
        }
        public string WP1116BALD2
        {
            get
            {
                return this._WP1116BALD2;
            }

            set
            {
                if (value != this._WP1116BALD2)
                {
                    this._WP1116BALD2 = value;
                    OnChanged("WP1116BALD2");

                }
            }
        }
        public string WP1116DYND1
        {
            get
            {
                return this._WP1116DYND1;
            }

            set
            {
                if (value != this._WP1116DYND1)
                {
                    this._WP1116DYND1 = value;
                    OnChanged("WP1116DYND1");

                }
            }
        }
        public string WP1116DYND2
        {
            get
            {
                return this._WP1116DYND2;
            }

            set
            {
                if (value != this._WP1116DYND2)
                {
                    this._WP1116DYND2 = value;
                    OnChanged("WP1116DYND2");

                }
            }
        }
        public string MP1116BALD1
        {
            get
            {
                return this._MP1116BALD1;
            }

            set
            {
                if (value != this._MP1116BALD1)
                {
                    this._MP1116BALD1 = value;
                    OnChanged("MP1116BALD1");

                }
            }
        }
        public string MP1116BALD2
        {
            get
            {
                return this._MP1116BALD2;
            }

            set
            {
                if (value != this._MP1116BALD2)
                {
                    this._MP1116BALD2 = value;
                    OnChanged("MP1116BALD2");

                }
            }
        }
        public string MP1116DYND1
        {
            get
            {
                return this._MP1116DYND1;
            }

            set
            {
                if (value != this._MP1116DYND1)
                {
                    this._MP1116DYND1 = value;
                    OnChanged("MP1116DYND1");

                }
            }
        }
        public string MP1116DYND2
        {
            get
            {
                return this._MP1116DYND2;
            }

            set
            {
                if (value != this._MP1116DYND2)
                {
                    this._MP1116DYND2 = value;
                    OnChanged("MP1116DYND2");

                }
            }
        }
        public string MXP1116BALD1
        {
            get
            {
                return this._MXP1116BALD1;
            }

            set
            {
                if (value != this._MXP1116BALD1)
                {
                    this._MXP1116BALD1 = value;
                    OnChanged("MXP1116BALD1");

                }
            }
        }
        public string MXP1116BALD2
        {
            get
            {
                return this._MXP1116BALD2;
            }

            set
            {
                if (value != this._MXP1116BALD2)
                {
                    this._MXP1116BALD2 = value;
                    OnChanged("MXP1116BALD2");

                }
            }
        }
        public string MXP1116DYND1
        {
            get
            {
                return this._MXP1116DYND1;
            }

            set
            {
                if (value != this._MXP1116DYND1)
                {
                    this._MXP1116DYND1 = value;
                    OnChanged("MXP1116DYND1");

                }
            }
        }
        public string MXP1116DYND2
        {
            get
            {
                return this._MXP1116DYND2;
            }

            set
            {
                if (value != this._MXP1116DYND2)
                {
                    this._MXP1116DYND2 = value;
                    OnChanged("MXP1116DYND2");

                }
            }
        }
        public string WG1116BALD1
        {
            get
            {
                return this._WG1116BALD1;
            }

            set
            {
                if (value != this._WG1116BALD1)
                {
                    this._WG1116BALD1 = value;
                    OnChanged("WG1116BALD1");

                }
            }
        }
        public string WG1116BALD2
        {
            get
            {
                return this._WG1116BALD2;
            }

            set
            {
                if (value != this._WG1116BALD2)
                {
                    this._WG1116BALD2 = value;
                    OnChanged("WG1116BALD2");

                }
            }
        }
        public string WG1116DYND1
        {
            get
            {
                return this._WG1116DYND1;
            }

            set
            {
                if (value != this._WG1116DYND1)
                {
                    this._WG1116DYND1 = value;
                    OnChanged("WG1116DYND1");

                }
            }
        }
        public string WG1116DYND2
        {
            get
            {
                return this._WG1116DYND2;
            }

            set
            {
                if (value != this._WG1116DYND2)
                {
                    this._WG1116DYND2 = value;
                    OnChanged("WG1116DYND2");

                }
            }
        }
        public string MG1116BALD1
        {
            get
            {
                return this._MG1116BALD1;
            }

            set
            {
                if (value != this._MG1116BALD1)
                {
                    this._MG1116BALD1 = value;
                    OnChanged("MG1116BALD1");

                }
            }
        }
        public string MG1116BALD2
        {
            get
            {
                return this._MG1116BALD2;
            }

            set
            {
                if (value != this._MG1116BALD2)
                {
                    this._MG1116BALD2 = value;
                    OnChanged("MG1116BALD2");

                }
            }
        }
        public string MG1116DYND1
        {
            get
            {
                return this._MG1116DYND1;
            }

            set
            {
                if (value != this._MG1116DYND1)
                {
                    this._MG1116DYND1 = value;
                    OnChanged("MG1116DYND1");

                }
            }
        }
        public string MG1116DYND2
        {
            get
            {
                return this._MG1116DYND2;
            }

            set
            {
                if (value != this._MG1116DYND2)
                {
                    this._MG1116DYND2 = value;
                    OnChanged("MG1116DYND2");

                }
            }
        }

        // 12-18 **************************************************

        public string WP1218BALD1
        {
            get
            {
                return this._WP1218BALD1;
            }

            set
            {
                if (value != this._WP1218BALD1)
                {
                    this._WP1218BALD1 = value;
                    OnChanged("WP1218BALD1");

                }
            }
        }
        public string WP1218BALD2
        {
            get
            {
                return this._WP1218BALD2;
            }

            set
            {
                if (value != this._WP1218BALD2)
                {
                    this._WP1218BALD2 = value;
                    OnChanged("WP1218BALD2");

                }
            }
        }
        public string WP1218DYND1
        {
            get
            {
                return this._WP1218DYND1;
            }

            set
            {
                if (value != this._WP1218DYND1)
                {
                    this._WP1218DYND1 = value;
                    OnChanged("WP1218DYND1");

                }
            }
        }
        public string WP1218DYND2
        {
            get
            {
                return this._WP1218DYND2;
            }

            set
            {
                if (value != this._WP1218DYND2)
                {
                    this._WP1218DYND2 = value;
                    OnChanged("WP1218DYND2");

                }
            }
        }
        public string WP1218COMD1
        {
            get
            {
                return this._WP1218COMD1;
            }

            set
            {
                if (value != this._WP1218COMD1)
                {
                    this._WP1218COMD1 = value;
                    OnChanged("WP1218COMD1");

                }
            }
        }
        public string WP1218COMD2
        {
            get
            {
                return this._WP1218COMD2;
            }

            set
            {
                if (value != this._WP1218COMD2)
                {
                    this._WP1218COMD2 = value;
                    OnChanged("WP1218COMD2");

                }
            }
        }
        public string MP1218BALD1
        {
            get
            {
                return this._MP1218BALD1;
            }

            set
            {
                if (value != this._MP1218BALD1)
                {
                    this._MP1218BALD1 = value;
                    OnChanged("MP1218BALD1");

                }
            }
        }
        public string MP1218BALD2
        {
            get
            {
                return this._MP1218BALD2;
            }

            set
            {
                if (value != this._MP1218BALD2)
                {
                    this._MP1218BALD2 = value;
                    OnChanged("MP1218BALD2");

                }
            }
        }
        public string MP1218DYND1
        {
            get
            {
                return this._MP1218DYND1;
            }

            set
            {
                if (value != this._MP1218DYND1)
                {
                    this._MP1218DYND1 = value;
                    OnChanged("MP1218DYND1");

                }
            }
        }
        public string MP1218DYND2
        {
            get
            {
                return this._MP1218DYND2;
            }

            set
            {
                if (value != this._MP1218DYND2)
                {
                    this._MP1218DYND2 = value;
                    OnChanged("MP1218DYND2");

                }
            }
        }
        public string MP1218COMD1
        {
            get
            {
                return this._MP1218COMD1;
            }

            set
            {
                if (value != this._MP1218COMD1)
                {
                    this._MP1218COMD1 = value;
                    OnChanged("MP1218COMD1");

                }
            }
        }
        public string MP1218COMD2
        {
            get
            {
                return this._MP1218COMD2;
            }

            set
            {
                if (value != this._MP1218COMD2)
                {
                    this._MP1218COMD2 = value;
                    OnChanged("MP1218COMD2");

                }
            }
        }
        public string MXP1218BALD1
        {
            get
            {
                return this._MXP1218BALD1;
            }

            set
            {
                if (value != this._MXP1218BALD1)
                {
                    this._MXP1218BALD1 = value;
                    OnChanged("MXP1218BALD1");

                }
            }
        }
        public string MXP1218BALD2
        {
            get
            {
                return this._MXP1218BALD2;
            }

            set
            {
                if (value != this._MXP1218BALD2)
                {
                    this._MXP1218BALD2 = value;
                    OnChanged("MXP1218BALD2");

                }
            }
        }
        public string MXP1218DYND1
        {
            get
            {
                return this._MXP1218DYND1;
            }

            set
            {
                if (value != this._MXP1218DYND1)
                {
                    this._MXP1218DYND1 = value;
                    OnChanged("MXP1218DYND1");

                }
            }
        }
        public string MXP1218DYND2
        {
            get
            {
                return this._MXP1218DYND2;
            }

            set
            {
                if (value != this._MXP1218DYND2)
                {
                    this._MXP1218DYND2 = value;
                    OnChanged("MXP1218DYND2");

                }
            }
        }
        public string MXP1218COMD1
        {
            get
            {
                return this._MXP1218COMD1;
            }

            set
            {
                if (value != this._MXP1218COMD1)
                {
                    this._MXP1218COMD1 = value;
                    OnChanged("MXP1218COMD1");

                }
            }
        }
        public string MXP1218COMD2
        {
            get
            {
                return this._MXP1218COMD2;
            }

            set
            {
                if (value != this._MXP1218COMD2)
                {
                    this._MXP1218COMD2 = value;
                    OnChanged("MXP1218COMD2");

                }
            }
        }
        public string WG1218BALD1
        {
            get
            {
                return this._WG1218BALD1;
            }

            set
            {
                if (value != this._WG1218BALD1)
                {
                    this._WG1218BALD1 = value;
                    OnChanged("WG1218BALD1");

                }
            }
        }
        public string WG1218BALD2
        {
            get
            {
                return this._WG1218BALD2;
            }

            set
            {
                if (value != this._WG1218BALD2)
                {
                    this._WG1218BALD2 = value;
                    OnChanged("WG1218BALD2");

                }
            }
        }
        public string WG1218DYND1
        {
            get
            {
                return this._WG1218DYND1;
            }

            set
            {
                if (value != this._WG1218DYND1)
                {
                    this._WG1218DYND1 = value;
                    OnChanged("WG1218DYND1");

                }
            }
        }
        public string WG1218DYND2
        {
            get
            {
                return this._WG1218DYND2;
            }

            set
            {
                if (value != this._WG1218DYND2)
                {
                    this._WG1218DYND2 = value;
                    OnChanged("WG1218DYND2");

                }
            }
        }
        public string WG1218COMD1
        {
            get
            {
                return this._WG1218COMD1;
            }

            set
            {
                if (value != this._WG1218COMD1)
                {
                    this._WG1218COMD1 = value;
                    OnChanged("WG1218COMD1");

                }
            }
        }
        public string WG1218COMD2
        {
            get
            {
                return this._WG1218COMD2;
            }

            set
            {
                if (value != this._WG1218COMD2)
                {
                    this._WG1218COMD2 = value;
                    OnChanged("WG1218COMD2");

                }
            }
        }
        public string MG1218BALD1
        {
            get
            {
                return this._MG1218BALD1;
            }

            set
            {
                if (value != this._MG1218BALD1)
                {
                    this._MG1218BALD1 = value;
                    OnChanged("MG1218BALD1");

                }
            }
        }
        public string MG1218BALD2
        {
            get
            {
                return this._MG1218BALD2;
            }

            set
            {
                if (value != this._MG1218BALD2)
                {
                    this._MG1218BALD2 = value;
                    OnChanged("MG1218BALD2");

                }
            }
        }
        public string MG1218DYND1
        {
            get
            {
                return this._MG1218DYND1;
            }

            set
            {
                if (value != this._MG1218DYND1)
                {
                    this._MG1218DYND1 = value;
                    OnChanged("MG1218DYND1");

                }
            }
        }
        public string MG1218DYND2
        {
            get
            {
                return this._MG1218DYND2;
            }

            set
            {
                if (value != this._MG1218DYND2)
                {
                    this._MG1218DYND2 = value;
                    OnChanged("MG1218DYND2");

                }
            }
        }
        public string MG1218COMD1
        {
            get
            {
                return this._MG1218COMD1;
            }

            set
            {
                if (value != this._MG1218COMD1)
                {
                    this._MG1218COMD1 = value;
                    OnChanged("MG1218COMD1");

                }
            }
        }
        public string MG1218COMD2
        {
            get
            {
                return this._MG1218COMD2;
            }

            set
            {
                if (value != this._MG1218COMD2)
                {
                    this._MG1218COMD2 = value;
                    OnChanged("MG1218COMD2");

                }
            }
        }

        // 13-19 ******************************************************


        public string WP1319BALD1
        {
            get
            {
                return this._WP1319BALD1;
            }

            set
            {
                if (value != this._WP1319BALD1)
                {
                    this._WP1319BALD1 = value;
                    OnChanged("WP1319BALD1");

                }
            }
        }
        public string WP1319BALD2
        {
            get
            {
                return this._WP1319BALD2;
            }

            set
            {
                if (value != this._WP1319BALD2)
                {
                    this._WP1319BALD2 = value;
                    OnChanged("WP1319BALD2");

                }
            }
        }
        public string WP1319DYND1
        {
            get
            {
                return this._WP1319DYND1;
            }

            set
            {
                if (value != this._WP1319DYND1)
                {
                    this._WP1319DYND1 = value;
                    OnChanged("WP1319DYND1");

                }
            }
        }
        public string WP1319DYND2
        {
            get
            {
                return this._WP1319DYND2;
            }

            set
            {
                if (value != this._WP1319DYND2)
                {
                    this._WP1319DYND2 = value;
                    OnChanged("WP1319DYND2");

                }
            }
        }
        public string WP1319COMD1
        {
            get
            {
                return this._WP1319COMD1;
            }

            set
            {
                if (value != this._WP1319COMD1)
                {
                    this._WP1319COMD1 = value;
                    OnChanged("WP1319COMD1");

                }
            }
        }
        public string WP1319COMD2
        {
            get
            {
                return this._WP1319COMD2;
            }

            set
            {
                if (value != this._WP1319COMD2)
                {
                    this._WP1319COMD2 = value;
                    OnChanged("WP1319COMD2");

                }
            }
        }
        public string MP1319BALD1
        {
            get
            {
                return this._MP1319BALD1;
            }

            set
            {
                if (value != this._MP1319BALD1)
                {
                    this._MP1319BALD1 = value;
                    OnChanged("MP1319BALD1");

                }
            }
        }
        public string MP1319BALD2
        {
            get
            {
                return this._MP1319BALD2;
            }

            set
            {
                if (value != this._MP1319BALD2)
                {
                    this._MP1319BALD2 = value;
                    OnChanged("MP1319BALD2");

                }
            }
        }
        public string MP1319DYND1
        {
            get
            {
                return this._MP1319DYND1;
            }

            set
            {
                if (value != this._MP1319DYND1)
                {
                    this._MP1319DYND1 = value;
                    OnChanged("MP1319DYND1");

                }
            }
        }
        public string MP1319DYND2
        {
            get
            {
                return this._MP1319DYND2;
            }

            set
            {
                if (value != this._MP1319DYND2)
                {
                    this._MP1319DYND2 = value;
                    OnChanged("MP1319DYND2");

                }
            }
        }
        public string MP1319COMD1
        {
            get
            {
                return this._MP1319COMD1;
            }

            set
            {
                if (value != this._MP1319COMD1)
                {
                    this._MP1319COMD1 = value;
                    OnChanged("MP1319COMD1");

                }
            }
        }
        public string MP1319COMD2
        {
            get
            {
                return this._MP1319COMD2;
            }

            set
            {
                if (value != this._MP1319COMD2)
                {
                    this._MP1319COMD2 = value;
                    OnChanged("MP1319COMD2");

                }
            }
        }
        public string MXP1319BALD1
        {
            get
            {
                return this._MXP1319BALD1;
            }

            set
            {
                if (value != this._MXP1319BALD1)
                {
                    this._MXP1319BALD1 = value;
                    OnChanged("MXP1319BALD1");

                }
            }
        }
        public string MXP1319BALD2
        {
            get
            {
                return this._MXP1319BALD2;
            }

            set
            {
                if (value != this._MXP1319BALD2)
                {
                    this._MXP1319BALD2 = value;
                    OnChanged("MXP1319BALD2");

                }
            }
        }
        public string MXP1319DYND1
        {
            get
            {
                return this._MXP1319DYND1;
            }

            set
            {
                if (value != this._MXP1319DYND1)
                {
                    this._MXP1319DYND1 = value;
                    OnChanged("MXP1319DYND1");

                }
            }
        }
        public string MXP1319DYND2
        {
            get
            {
                return this._MXP1319DYND2;
            }

            set
            {
                if (value != this._MXP1319DYND2)
                {
                    this._MXP1319DYND2 = value;
                    OnChanged("MXP1319DYND2");

                }
            }
        }
        public string MXP1319COMD1
        {
            get
            {
                return this._MXP1319COMD1;
            }

            set
            {
                if (value != this._MXP1319COMD1)
                {
                    this._MXP1319COMD1 = value;
                    OnChanged("MXP1319COMD1");

                }
            }
        }
        public string MXP1319COMD2
        {
            get
            {
                return this._MXP1319COMD2;
            }

            set
            {
                if (value != this._MXP1319COMD2)
                {
                    this._MXP1319COMD2 = value;
                    OnChanged("MXP1319COMD2");

                }
            }
        }
        public string WG1319BALD1
        {
            get
            {
                return this._WG1319BALD1;
            }

            set
            {
                if (value != this._WG1319BALD1)
                {
                    this._WG1319BALD1 = value;
                    OnChanged("WG1319BALD1");

                }
            }
        }
        public string WG1319BALD2
        {
            get
            {
                return this._WG1319BALD2;
            }

            set
            {
                if (value != this._WG1319BALD2)
                {
                    this._WG1319BALD2 = value;
                    OnChanged("WG1319BALD2");

                }
            }
        }
        public string WG1319DYND1
        {
            get
            {
                return this._WG1319DYND1;
            }

            set
            {
                if (value != this._WG1319DYND1)
                {
                    this._WG1319DYND1 = value;
                    OnChanged("WG1319DYND1");

                }
            }
        }
        public string WG1319DYND2
        {
            get
            {
                return this._WG1319DYND2;
            }

            set
            {
                if (value != this._WG1319DYND2)
                {
                    this._WG1319DYND2 = value;
                    OnChanged("WG1319DYND2");

                }
            }
        }
        public string WG1319COMD1
        {
            get
            {
                return this._WG1319COMD1;
            }

            set
            {
                if (value != this._WG1319COMD1)
                {
                    this._WG1319COMD1 = value;
                    OnChanged("WG1319COMD1");

                }
            }
        }
        public string WG1319COMD2
        {
            get
            {
                return this._WG1319COMD2;
            }

            set
            {
                if (value != this._WG1319COMD2)
                {
                    this._WG1319COMD2 = value;
                    OnChanged("WG1319COMD2");

                }
            }
        }
        public string MG1319BALD1
        {
            get
            {
                return this._MG1319BALD1;
            }

            set
            {
                if (value != this._MG1319BALD1)
                {
                    this._MG1319BALD1 = value;
                    OnChanged("MG1319BALD1");

                }
            }
        }
        public string MG1319BALD2
        {
            get
            {
                return this._MG1319BALD2;
            }

            set
            {
                if (value != this._MG1319BALD2)
                {
                    this._MG1319BALD2 = value;
                    OnChanged("MG1319BALD2");

                }
            }
        }
        public string MG1319DYND1
        {
            get
            {
                return this._MG1319DYND1;
            }

            set
            {
                if (value != this._MG1319DYND1)
                {
                    this._MG1319DYND1 = value;
                    OnChanged("MG1319DYND1");

                }
            }
        }
        public string MG1319DYND2
        {
            get
            {
                return this._MG1319DYND2;
            }

            set
            {
                if (value != this._MG1319DYND2)
                {
                    this._MG1319DYND2 = value;
                    OnChanged("MG1319DYND2");

                }
            }
        }
        public string MG1319COMD1
        {
            get
            {
                return this._MG1319COMD1;
            }

            set
            {
                if (value != this._MG1319COMD1)
                {
                    this._MG1319COMD1 = value;
                    OnChanged("MG1319COMD1");

                }
            }
        }
        public string MG1319COMD2
        {
            get
            {
                return this._MG1319COMD2;
            }

            set
            {
                if (value != this._MG1319COMD2)
                {
                    this._MG1319COMD2 = value;
                    OnChanged("MG1319COMD2");

                }
            }
        }

        // SENIOR *********************************************************************

        public string WPSENBALD1
        {
            get
            {
                return this._WPSENBALD1;
            }

            set
            {
                if (value != this._WPSENBALD1)
                {
                    this._WPSENBALD1 = value;
                    OnChanged("WPSENBALD1");

                }
            }
        }
        public string WPSENBALD2
        {
            get
            {
                return this._WPSENBALD2;
            }

            set
            {
                if (value != this._WPSENBALD2)
                {
                    this._WPSENBALD2 = value;
                    OnChanged("WPSENBALD2");

                }
            }
        }
        public string WPSENDYND1
        {
            get
            {
                return this._WPSENDYND1;
            }

            set
            {
                if (value != this._WPSENDYND1)
                {
                    this._WPSENDYND1 = value;
                    OnChanged("WPSENDYND1");

                }
            }
        }
        public string WPSENDYND2
        {
            get
            {
                return this._WPSENDYND2;
            }

            set
            {
                if (value != this._WPSENDYND2)
                {
                    this._WPSENDYND2 = value;
                    OnChanged("WPSENDYND2");

                }
            }
        }
        public string WPSENCOMD1
        {
            get
            {
                return this._WPSENCOMD1;
            }

            set
            {
                if (value != this._WPSENCOMD1)
                {
                    this._WPSENCOMD1 = value;
                    OnChanged("WPSENCOMD1");

                }
            }
        }
        public string WPSENCOMD2
        {
            get
            {
                return this._WPSENCOMD2;
            }

            set
            {
                if (value != this._WPSENCOMD2)
                {
                    this._WPSENCOMD2 = value;
                    OnChanged("WPSENCOMD2");

                }
            }
        }
        public string MPSENBALD1
        {
            get
            {
                return this._MPSENBALD1;
            }

            set
            {
                if (value != this._MPSENBALD1)
                {
                    this._MPSENBALD1 = value;
                    OnChanged("MPSENBALD1");

                }
            }
        }
        public string MPSENBALD2
        {
            get
            {
                return this._MPSENBALD2;
            }

            set
            {
                if (value != this._MPSENBALD2)
                {
                    this._MPSENBALD2 = value;
                    OnChanged("MPSENBALD2");

                }
            }
        }
        public string MPSENDYND1
        {
            get
            {
                return this._MPSENDYND1;
            }

            set
            {
                if (value != this._MPSENDYND1)
                {
                    this._MPSENDYND1 = value;
                    OnChanged("MPSENDYND1");

                }
            }
        }
        public string MPSENDYND2
        {
            get
            {
                return this._MPSENDYND2;
            }

            set
            {
                if (value != this._MPSENDYND2)
                {
                    this._MPSENDYND2 = value;
                    OnChanged("MPSENDYND2");

                }
            }
        }
        public string MPSENCOMD1
        {
            get
            {
                return this._MPSENCOMD1;
            }

            set
            {
                if (value != this._MPSENCOMD1)
                {
                    this._MPSENCOMD1 = value;
                    OnChanged("MPSENCOMD1");

                }
            }
        }
        public string MPSENCOMD2
        {
            get
            {
                return this._MPSENCOMD2;
            }

            set
            {
                if (value != this._MPSENCOMD2)
                {
                    this._MPSENCOMD2 = value;
                    OnChanged("MPSENCOMD2");

                }
            }
        }
        public string MXPSENBALD1
        {
            get
            {
                return this._MXPSENBALD1;
            }

            set
            {
                if (value != this._MXPSENBALD1)
                {
                    this._MXPSENBALD1 = value;
                    OnChanged("MXPSENBALD1");

                }
            }
        }
        public string MXPSENBALD2
        {
            get
            {
                return this._MXPSENBALD2;
            }

            set
            {
                if (value != this._MXPSENBALD2)
                {
                    this._MXPSENBALD2 = value;
                    OnChanged("MXPSENBALD2");

                }
            }
        }
        public string MXPSENDYND1
        {
            get
            {
                return this._MXPSENDYND1;
            }

            set
            {
                if (value != this._MXPSENDYND1)
                {
                    this._MXPSENDYND1 = value;
                    OnChanged("MXPSENDYND1");

                }
            }
        }
        public string MXPSENDYND2
        {
            get
            {
                return this._MXPSENDYND2;
            }

            set
            {
                if (value != this._MXPSENDYND2)
                {
                    this._MXPSENDYND2 = value;
                    OnChanged("MXPSENDYND2");

                }
            }
        }
        public string MXPSENCOMD1
        {
            get
            {
                return this._MXPSENCOMD1;
            }

            set
            {
                if (value != this._MXPSENCOMD1)
                {
                    this._MXPSENCOMD1 = value;
                    OnChanged("MXPSENCOMD1");

                }
            }
        }
        public string MXPSENCOMD2
        {
            get
            {
                return this._MXPSENCOMD2;
            }

            set
            {
                if (value != this._MXPSENCOMD2)
                {
                    this._MXPSENCOMD2 = value;
                    OnChanged("MXPSENCOMD2");

                }
            }
        }
        public string WGSENBALD1
        {
            get
            {
                return this._WGSENBALD1;
            }

            set
            {
                if (value != this._WGSENBALD1)
                {
                    this._WGSENBALD1 = value;
                    OnChanged("WGSENBALD1");

                }
            }
        }
        public string WGSENBALD2
        {
            get
            {
                return this._WGSENBALD2;
            }

            set
            {
                if (value != this._WGSENBALD2)
                {
                    this._WGSENBALD2 = value;
                    OnChanged("WGSENBALD2");

                }
            }
        }
        public string WGSENDYND1
        {
            get
            {
                return this._WGSENDYND1;
            }

            set
            {
                if (value != this._WGSENDYND1)
                {
                    this._WGSENDYND1 = value;
                    OnChanged("WGSENDYND1");

                }
            }
        }
        public string WGSENDYND2
        {
            get
            {
                return this._WGSENDYND2;
            }

            set
            {
                if (value != this._WGSENDYND2)
                {
                    this._WGSENDYND2 = value;
                    OnChanged("WGSENDYND2");

                }
            }
        }
        public string WGSENCOMD1
        {
            get
            {
                return this._WGSENCOMD1;
            }

            set
            {
                if (value != this._WGSENCOMD1)
                {
                    this._WGSENCOMD1 = value;
                    OnChanged("WGSENCOMD1");

                }
            }
        }
        public string WGSENCOMD2
        {
            get
            {
                return this._WGSENCOMD2;
            }

            set
            {
                if (value != this._WGSENCOMD2)
                {
                    this._WGSENCOMD2 = value;
                    OnChanged("WGSENCOMD2");

                }
            }
        }
        public string MGSENBALD1
        {
            get
            {
                return this._MGSENBALD1;
            }

            set
            {
                if (value != this._MGSENBALD1)
                {
                    this._MGSENBALD1 = value;
                    OnChanged("MGSENBALD1");

                }
            }
        }
        public string MGSENBALD2
        {
            get
            {
                return this._MGSENBALD2;
            }

            set
            {
                if (value != this._MGSENBALD2)
                {
                    this._MGSENBALD2 = value;
                    OnChanged("MGSENBALD2");

                }
            }
        }
        public string MGSENDYND1
        {
            get
            {
                return this._MGSENDYND1;
            }

            set
            {
                if (value != this._MGSENDYND1)
                {
                    this._MGSENDYND1 = value;
                    OnChanged("MGSENDYND1");

                }
            }
        }
        public string MGSENDYND2
        {
            get
            {
                return this._MGSENDYND2;
            }

            set
            {
                if (value != this._MGSENDYND2)
                {
                    this._MGSENDYND2 = value;
                    OnChanged("MGSENDYND2");

                }
            }
        }
        public string MGSENCOMD1
        {
            get
            {
                return this._MGSENCOMD1;
            }

            set
            {
                if (value != this._MGSENCOMD1)
                {
                    this._MGSENCOMD1 = value;
                    OnChanged("MGSENCOMD1");

                }
            }
        }
        public string MGSENCOMD2
        {
            get
            {
                return this._MGSENCOMD2;
            }

            set
            {
                if (value != this._MGSENCOMD2)
                {
                    this._MGSENCOMD2 = value;
                    OnChanged("MGSENCOMD2");

                }
            }
        }

        public Evento()
        {
            Event_Name = "";
            Date = "";
            Place = "";
            Event_logo = "";
            // Panel 1 Clasificaciones
            P1QNoSameCountryInSame = "";
            P1QEjudges = 0;
            P1QAjudges = 0;
            P1QREjudges = 0;
            P1QRAjudges = 0;
            P1QTjudges = 0;
            P1QMaxCat4judges = 0;
            //Panel 1 Finales
            P1F3Condition = "";
            P1FNoSameCountryInSame = "";
            P1FEjudges = 0;
            P1FAjudges = 0;
            P1FREjudges = 0;
            P1FRAjudges = 0;
            P1FTjudges = 0;
            P1FMaxCat4judges = 0;
            // Panel 2 Clasificaciones
            P2QNoSameCountryInSame = "";
            P2QEjudges = 0;
            P2QAjudges = 0;
            P2QREjudges = 0;
            P2QRAjudges = 0;
            P2QTjudges = 0;
            P2QMaxCat4judges = 0;
            // Panel 2 Finales
            P2F3Condition = "";
            P2FNoSameCountryInSame = "";
            P2FEjudges = 0;
            P2FAjudges = 0;
            P2FREjudges = 0;
            P2FRAjudges = 0;
            P2FTjudges = 0;
            P2FMaxCat4judges = 0;
            Ljudges = 0;
            Ijudges = 0;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class Evento_De_Trabajo : INotifyPropertyChanged
    {
        private bool _IsSelected;
        public string Event_Name { get; set; }
        public string SaveDate { get; set; }
        public string Event_folder { get; set; }
        public bool IsSelected
        {
            get
            {
                return this._IsSelected;
            }

            set
            {
                if (value != this._IsSelected)
                {
                    this._IsSelected = value;
                    OnChanged("IsSelected");
                }
            }
        }
        public Evento Evento_ { get; set; }
        public Jueces Jueces_ { get; set; }
        public Horario Horario_ { get; set; }
        public EventFinalCountries EventFinalCountries_ { get; set; }
        public Relatives Relatives_ { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class Lista_Eventos_Guardados : ObservableCollection<Evento_De_Trabajo>
    {
        public Lista_Eventos_Guardados() { }
        public Lista_Eventos_Guardados(string archivo) : base()
        {

            basededatos<Evento_De_Trabajo> bdEventos_Guardados = new basededatos<Evento_De_Trabajo>(archivo);
            bdEventos_Guardados.Cargar();
            foreach (Evento_De_Trabajo ev_gu in bdEventos_Guardados.valores)
            {
                Add(ev_gu);
            }
        }
        public void Guardar(string archivo)
        {
            basededatos<Evento_De_Trabajo> bdEventos_Guardados = new basededatos<Evento_De_Trabajo>(archivo);
            bdEventos_Guardados.GuardarObservableCollection(this);

        }
    }

}


