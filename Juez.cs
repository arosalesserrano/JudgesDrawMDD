using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using Newtonsoft.Json;

namespace JudgesDrawMDD
{   
    public class EstadisticasJueces : INotifyPropertyChanged
    {
        private int totalJueces;
        public int TotalJueces
        {
            get
            {
                return this.totalJueces;
            }
            set
            {
                if (value != this.totalJueces)
                {
                    this.totalJueces = value;
                    OnChanged("TotalJueces");
                }
            }
        }

        private int totalJuecesWarning;
        public int TotalJuecesWarning
        {
            get
            {
                return this.totalJuecesWarning;
            }
            set
            {
                if (value != this.totalJuecesWarning)
                {
                    this.totalJuecesWarning = value;
                    OnChanged("TotalJuecesWarning");
                }
            }
        }

        private int totalJuecesPresentes;
        public int TotalJuecesPresentes
        {
            get
            {
                return this.totalJuecesPresentes;
            }
            set
            {
                if (value != this.totalJuecesPresentes)
                {
                    this.totalJuecesPresentes = value;
                    OnChanged("TotalJuecesPresentes");
                }
            }
        }

        private int totalJuecesCountries;
        public int TotalJuecesCountries
        {
            get
            {
                return this.totalJuecesCountries;
            }
            set
            {
                if (value != this.totalJuecesCountries)
                {
                    this.totalJuecesCountries = value;
                    OnChanged("TotalJuecesCountries");
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

    public class Jueces : ObservableCollection<Juez>
    {
        private ChartValues<int> _JuecesN1;
        private ChartValues<int> _JuecesN2;
        private ChartValues<int> _JuecesN3;
        private ChartValues<int> _JuecesN4;

        public Jueces() { }

        public Jueces(string archivo) : base()
        {
            basededatos<Juez> bdjueces = new basededatos<Juez>(archivo);
            bdjueces.Cargar();
            foreach (Juez j in bdjueces.valores)
            {
                Add(j);
            }
        }
        public void Guardarjueces(string archivo)
        {
            basededatos<Juez> bdjueces2 = new basededatos<Juez>(archivo);
            bdjueces2.GuardarObservableCollection(this);

        }
        public ObservableCollection<Juez> juecespresentes()
        {

            return new ObservableCollection<Juez>(from item in this where item.Presence select item);
        }
        public ObservableCollection<Juez> juecessinwarning()
        {

            return new ObservableCollection<Juez>(from item in this where !item.Warning select item);
        }

        public ObservableCollection<Juez> juecesconwarning()
        {

            return new ObservableCollection<Juez>(from item in this where item.Warning select item);
        }

        public ObservableCollection<Juez> juecespresentessinwarning()
        {

            return new ObservableCollection<Juez>(from item in this where !item.Warning & item.Presence select item);
        }


        public ChartValues<int> JuecesN1
        {
            get
            {
                _JuecesN1 = new ChartValues<int>();
                _JuecesN1.Add(this.Where(x => x.Category == 1).Count());

                return _JuecesN1;

            }
        }
        public ChartValues<int> JuecesN2
        {
            get
            {
                _JuecesN2 = new ChartValues<int>();

                _JuecesN2.Add(this.Where(x => x.Category == 2).Count());
                return _JuecesN2;

            }
        }

        public ChartValues<int> JuecesN3
        {
            get
            {
                _JuecesN3 = new ChartValues<int>();

                _JuecesN3.Add(this.Where(x => x.Category == 3).Count());
                return _JuecesN3;

            }
        }
        public ChartValues<int> JuecesN4
        {
            get
            {
                _JuecesN4 = new ChartValues<int>();

                _JuecesN4.Add(this.Where(x => x.Category == 4).Count());
                return _JuecesN4;

            }
        }
    }
        public class Relative: INotifyPropertyChanged
    {
        
        private string _Juez;
        private string _CatMod;

        public string Juez
        {
            get
            {
                return this._Juez;
            }
            set
            {
                if (value != this._Juez)
                {
                    this._Juez = value;
                    OnChanged("Juez");
                }
            }
        }

        public string CatMod
        {
            get
            {
                return this._CatMod;
            }
            set
            {
                if (value != this._CatMod)
                {
                    this._CatMod = value;
                    OnChanged("CatMod");
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

    public class Relatives:ObservableCollection<Relative>
    {
        public Relatives() { }

    }

    public class Juez : INotifyPropertyChanged
    {
        private bool presence;
        private bool warning;
        private string judgeName;
        private string country;
        // Campos: Presence,ID,JUDGE Name,Country,Category,Total E,Total A
        public bool Presence
        {
            get
            {
                return this.presence;
            }

            set
            {
                if (value != this.presence)
                {
                    this.presence = value;
                    OnChanged("Presence");
                }
            }
        }
        public int ID { get; set; }
        public string JudgeName
        {
            get
            {
                return this.judgeName;
            }

            set
            {
                if (value != this.judgeName)
                {
                    this.judgeName = value;
                    OnChanged("JudgeName");
                }
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                if (value != this.country)
                {
                    this.country = value;
                    OnChanged("Country");
                }
            }
        }
        public string CountryFlag
        {
            get
            {
                if (Country == "EUG" || Country == "UEG")
                {
                    return @"Images/uu.png";
                }
                else
                {
                    return @"/FamFamFam.Flags.Wpf;component/Images/" + ISO3166.FromAlpha3(Country.ToUpper()).Alpha2 + ".png";
                }
            }
         }
        public int Category { get; set; }
        public int Total { get { return TotalE + TotalA; } }
        public int TotalE { get; set; }
        public int TotalA { get; set; }
        public int TotalF { get { return TotalFE + TotalFA; } }
        public int TotalFE { get; set; }
        public int TotalFA { get; set; }
        public bool Warning
        {
            get
            {
                return this.warning;
            }

            set
            {
                if (value != this.warning)
                {
                    this.warning = value;
                    OnChanged("Warning");
                }
            }
        }

        public void IncrementarparticipacionA()
        {       
            TotalA++;
        }
        public void IncrementarparticipacionE()
        {
            TotalE++;
        }
        public void DecrementarparticipacionA()
        {
            if (this.TotalA > 0)
            {
                TotalA--;
            }
        }
        public void DecrementarparticipacionE()
        {
            if(this.TotalE > 0)
            {
                TotalE--;
            }
        }

        public void IncrementarparticipacionFA()
        {
            TotalFA++;
        }
        public void IncrementarparticipacionFE()
        {
            TotalFE++;
        }
        public void DecrementarparticipacionFA()
        {
            if (this.TotalFA > 0)
            {
                TotalFA--;
            }
        }
        public void DecrementarparticipacionFE()
        {
            if (this.TotalFE > 0)
            {
                TotalFE--;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    public class EstadoPresencia
    {
        private static Dictionary<int, EstadoPresencia> getAll;
        /// <summary>

        /// Initializes static members of the FormulaOneTeam class.

        /// </summary>
        static EstadoPresencia()
        {
            getAll = new Dictionary<int, EstadoPresencia>()
                {
                    { 0, new EstadoPresencia { Id = 0, Estado = "N"  } },
                    { 1, new EstadoPresencia { Id = 1, Estado = "Y"} },
                    { 2, new EstadoPresencia { Id = 2, Estado = "" } }
                };
        }
        /// <summary>
        /// Gets the entire list
        /// </summary>
        public static Dictionary<int, EstadoPresencia> GetAll
        {
            get
            {
                return getAll;
            }
        }
        /// <summary>
        /// Gets or sets the id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Estado { get; set; }
    }

    public class CategoriaJueces
    {
        private static Dictionary<int, CategoriaJueces> getAll;
        /// <summary>
        /// Initializes static members 
        /// </summary>
        static CategoriaJueces()
        {
            getAll = new Dictionary<int, CategoriaJueces>()
                {
                    { 0, new CategoriaJueces { Id = 0, Categoria = 0 } },
                    { 1, new CategoriaJueces { Id = 1, Categoria = 1  } },
                    { 2, new CategoriaJueces { Id = 2, Categoria = 2  } },
                    { 3, new CategoriaJueces { Id = 3, Categoria = 3 } },
                    { 4, new CategoriaJueces { Id = 4, Categoria = 4 } }
                };  
        }
        /// <summary>
        /// Gets the entire list of Judge Categories
        /// </summary>
        public static Dictionary<int, CategoriaJueces> GetAll
        {
            get
            {
                return getAll;
            }
        }
        /// <summary>
        /// Gets or sets the id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public int Categoria { get; set; }
    }

    public class TipoCompeticion
    {
        private static Dictionary<int, TipoCompeticion> getAll;
        /// <summary>
        /// Initializes static members 
        /// </summary>
        static TipoCompeticion()
        {
            getAll = new Dictionary<int, TipoCompeticion>()
                {
                    { 0, new TipoCompeticion { Id = 0, Competicion = "QUALIFICATION"  } },
                    { 1, new TipoCompeticion { Id = 1, Competicion = "FINAL" } }
                };
        }
        /// <summary>
        /// Gets the entire list of Judge Categories
        /// </summary>
        public static Dictionary<int, TipoCompeticion> GetAll
        {
            get
            {
                return getAll;
            }
        }
        /// <summary>
        /// Gets or sets the id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Competicion { get; set; }
    }

    public class CategoriaModalidadEjercicio
    {
        private static List<CategoriaModalidadEjercicio> getAll;
        /// <summary>
        /// Initializes static members 
        /// </summary>
        static CategoriaModalidadEjercicio()
        {
            getAll = new List<CategoriaModalidadEjercicio>()
                {
                                        { new CategoriaModalidadEjercicio { Id = 0, Categoria = "11-16",Modalidad = "WP",Ejercicio = "BAL", CatModEj = "11-16 WP BAL", CatMod="11-16 WP" } },
                                        { new CategoriaModalidadEjercicio { Id = 1,  Categoria = "11-16",Modalidad = "WP",Ejercicio = "DYN",CatModEj = "11-16 WP DYN", CatMod="11-16 WP"  } },
                                        { new CategoriaModalidadEjercicio { Id = 2,  Categoria = "11-16",Modalidad = "MP",Ejercicio = "BAL",CatModEj = "11-16 MP BAL", CatMod="11-16 MP" } },
                                        { new CategoriaModalidadEjercicio { Id = 3, Categoria = "11-16",Modalidad = "MP",Ejercicio = "DYN",CatModEj = "11-16 MP DYN", CatMod="11-16 MP" } },
                                        { new CategoriaModalidadEjercicio { Id = 4, Categoria = "11-16",Modalidad = "MXP",Ejercicio = "BAL",CatModEj = "11-16 MXP BAL", CatMod="11-16 MXP" } },
                                        { new CategoriaModalidadEjercicio { Id = 5, Categoria = "11-16",Modalidad = "MXP",Ejercicio = "DYN" ,CatModEj = "11-16 MXP DYN", CatMod="11-16 MXP" } },
                                        { new CategoriaModalidadEjercicio { Id = 6, Categoria = "11-16",Modalidad = "WG",Ejercicio = "BAL",CatModEj = "11-16 WG BAL", CatMod="11-16 WG" } },
                                        { new CategoriaModalidadEjercicio { Id = 7, Categoria = "11-16",Modalidad = "WG",Ejercicio = "DYN",CatModEj = "11-16 WG DYN", CatMod="11-16 WG"  } },
                                        { new CategoriaModalidadEjercicio { Id = 8, Categoria = "11-16",Modalidad = "MG",Ejercicio = "BAL",CatModEj = "11-16 MG BAL", CatMod="11-16 MG" } },
                                        { new CategoriaModalidadEjercicio { Id = 9, Categoria = "11-16",Modalidad = "MG",Ejercicio = "DYN",CatModEj = "11-16 MG DYN", CatMod="11-16 MG" } },

                                        { new CategoriaModalidadEjercicio { Id = 10, Categoria = "12-18",Modalidad = "WP",Ejercicio = "BAL",CatModEj = "12-18 WP BAL", CatMod="12-18 WP" } },
                                        { new CategoriaModalidadEjercicio { Id = 11,  Categoria = "12-18",Modalidad = "WP",Ejercicio = "DYN",CatModEj = "12-18 WP DYN", CatMod="12-18 WP" } },
                                         { new CategoriaModalidadEjercicio { Id = 12,  Categoria = "12-18",Modalidad = "WP",Ejercicio = "COM",CatModEj = "12-18 WP COM", CatMod="12-18 WP" } },
                                        { new CategoriaModalidadEjercicio { Id = 13,  Categoria = "12-18",Modalidad = "MP",Ejercicio = "BAL",CatModEj = "12-18 MP BAL", CatMod="12-18 MP" } },
                                        { new CategoriaModalidadEjercicio { Id = 14, Categoria = "12-18",Modalidad = "MP",Ejercicio = "DYN",CatModEj = "12-18 MP DYN", CatMod="12-18 MP" } },
                                         { new CategoriaModalidadEjercicio { Id = 15, Categoria = "12-18",Modalidad = "MP",Ejercicio = "COM",CatModEj = "12-18 MP COM", CatMod="12-18 MP" } },
                                        { new CategoriaModalidadEjercicio { Id = 16, Categoria = "12-18",Modalidad = "MXP",Ejercicio = "BAL",CatModEj = "12-18 MXP BAL", CatMod="12-18 MXP" } },
                                        { new CategoriaModalidadEjercicio { Id = 17, Categoria = "12-18",Modalidad = "MXP",Ejercicio = "DYN",CatModEj = "12-18 MXP DYN", CatMod="12-18 MXP" } },
                                         { new CategoriaModalidadEjercicio { Id = 18, Categoria = "12-18",Modalidad = "MXP",Ejercicio = "COM",CatModEj = "12-18 MXP COM", CatMod="12-18 MXP" } },
                                        { new CategoriaModalidadEjercicio { Id = 19, Categoria = "12-18",Modalidad = "WG",Ejercicio = "BAL",CatModEj = "12-18 WG BAL", CatMod="12-18 WG" } },
                                        { new CategoriaModalidadEjercicio { Id = 20, Categoria = "12-18",Modalidad = "WG",Ejercicio = "DYN",CatModEj = "12-18 WG DYN", CatMod="12-18 WG" } },
                                         { new CategoriaModalidadEjercicio { Id = 21, Categoria = "12-18",Modalidad = "WG",Ejercicio = "COM",CatModEj = "12-18 WG COM", CatMod="12-18 WG" } },
                                        { new CategoriaModalidadEjercicio { Id = 22, Categoria = "12-18",Modalidad = "MG",Ejercicio = "BAL",CatModEj = "12-18 MG BAL", CatMod="12-18 MG" } },
                                        { new CategoriaModalidadEjercicio { Id = 23, Categoria = "12-18",Modalidad = "MG",Ejercicio = "DYN",CatModEj = "12-18 MG DYN", CatMod="12-18 MG" } },
                                         { new CategoriaModalidadEjercicio { Id = 24, Categoria = "12-18",Modalidad = "MG",Ejercicio = "COM",CatModEj = "12-18 MG COM", CatMod="12-18 MG" } },

                                          { new CategoriaModalidadEjercicio { Id = 25, Categoria = "13-19",Modalidad = "WP",Ejercicio = "BAL",CatModEj = "13-19 WP BAL",CatMod="13-19 WP" } },
                                        { new CategoriaModalidadEjercicio { Id = 26,  Categoria = "13-19",Modalidad = "WP",Ejercicio = "DYN",CatModEj = "13-19 WP DYN",CatMod="13-19 WP" } },
                                         { new CategoriaModalidadEjercicio { Id = 27,  Categoria = "13-19",Modalidad = "WP",Ejercicio = "COM",CatModEj = "13-19 MP COM",CatMod="13-19 WP" } },
                                        { new CategoriaModalidadEjercicio { Id = 28,  Categoria = "13-19",Modalidad = "MP",Ejercicio = "BAL",CatModEj = "13-19 MP BAL",CatMod="13-19 MP" } },
                                        { new CategoriaModalidadEjercicio { Id = 29, Categoria = "13-19",Modalidad = "MP",Ejercicio = "DYN",CatModEj = "13-19 MP DYN",CatMod="13-19 MP" } },
                                         { new CategoriaModalidadEjercicio { Id = 30, Categoria = "13-19",Modalidad = "MP",Ejercicio = "COM",CatModEj = "13-19 MP COM",CatMod="13-19 MP" } },
                                        { new CategoriaModalidadEjercicio { Id = 31, Categoria = "13-19",Modalidad = "MXP",Ejercicio = "BAL",CatModEj = "13-19 MXP BAL",CatMod="13-19 MXP" } },
                                        { new CategoriaModalidadEjercicio { Id = 32, Categoria = "13-19",Modalidad = "MXP",Ejercicio = "DYN",CatModEj = "13-19 MXP DYN",CatMod="13-19 MXP" } },
                                         { new CategoriaModalidadEjercicio { Id = 33, Categoria = "13-19",Modalidad = "MXP",Ejercicio = "COM",CatModEj = "13-19 MXP COM",CatMod="13-19 MXP" } },
                                        {  new CategoriaModalidadEjercicio { Id = 34, Categoria = "13-19",Modalidad = "WG",Ejercicio = "BAL",CatModEj = "13-19 WG BAL",CatMod="13-19 WG" } },
                                        {  new CategoriaModalidadEjercicio { Id = 35, Categoria = "13-19",Modalidad = "WG",Ejercicio = "DYN",CatModEj = "13-19 WG DYN",CatMod="13-19 WG" } },
                                         { new CategoriaModalidadEjercicio { Id = 36, Categoria = "13-19",Modalidad = "WG",Ejercicio = "COM",CatModEj = "13-19 WG COM",CatMod="13-19 WG" } },
                                        {  new CategoriaModalidadEjercicio { Id = 37, Categoria = "13-19",Modalidad = "MG",Ejercicio = "BAL",CatModEj = "13-19 MG BAL",CatMod="13-19 MG" } },
                                        {  new CategoriaModalidadEjercicio { Id = 38, Categoria = "13-19",Modalidad = "MG",Ejercicio = "DYN",CatModEj = "13-19 MG DYN",CatMod="13-19 MG" } },
                                         { new CategoriaModalidadEjercicio { Id = 39, Categoria = "13-19",Modalidad = "MG",Ejercicio = "COM",CatModEj = "13-19 MG COM",CatMod="13-19 MG" } },

                                            { new CategoriaModalidadEjercicio { Id = 40, Categoria = "SENIOR",Modalidad = "WP",Ejercicio = "BAL",CatModEj = "SENIOR WP BAL",CatMod="SENIOR WP" } },
                                        { new CategoriaModalidadEjercicio { Id = 41,  Categoria = "SENIOR",Modalidad = "WP",Ejercicio = "DYN",CatModEj = "SENIOR WP DYN",CatMod="SENIOR WP" } },
                                         { new CategoriaModalidadEjercicio { Id = 42,  Categoria = "SENIOR",Modalidad = "WP",Ejercicio = "COM",CatModEj = "SENIOR MP COM",CatMod="SENIOR WP" } },
                                        {  new CategoriaModalidadEjercicio { Id = 43,  Categoria = "SENIOR",Modalidad = "MP",Ejercicio = "BAL",CatModEj = "SENIOR MP BAL",CatMod="SENIOR MP" } },
                                        {  new CategoriaModalidadEjercicio { Id = 44, Categoria = "SENIOR",Modalidad = "MP",Ejercicio = "DYN",CatModEj = "SENIOR MP DYN",CatMod="SENIOR MP" } },
                                         { new CategoriaModalidadEjercicio { Id = 45, Categoria = "SENIOR",Modalidad = "MP",Ejercicio = "COM",CatModEj = "SENIOR MP COM",CatMod="SENIOR MP" } },
                                        {  new CategoriaModalidadEjercicio { Id = 46, Categoria = "SENIOR",Modalidad = "MXP",Ejercicio = "BAL",CatModEj = "SENIOR MXP BAL",CatMod="SENIOR MXP" } },
                                        {  new CategoriaModalidadEjercicio { Id = 47, Categoria = "SENIOR",Modalidad = "MXP",Ejercicio = "DYN",CatModEj = "SENIOR MXP DYN",CatMod="SENIOR MXP" } },
                                         { new CategoriaModalidadEjercicio { Id = 48, Categoria = "SENIOR",Modalidad = "MXP",Ejercicio = "COM",CatModEj = "SENIOR MXP COM",CatMod="SENIOR MXP" } },
                                        { new CategoriaModalidadEjercicio { Id = 49, Categoria = "SENIOR",Modalidad = "WG",Ejercicio = "BAL",CatModEj = "SENIOR WG BAL",CatMod="SENIOR WG" } },
                                        { new CategoriaModalidadEjercicio { Id = 50, Categoria = "SENIOR",Modalidad = "WG",Ejercicio = "DYN",CatModEj = "SENIOR WG DYN",CatMod="SENIOR WG" } },
                                         {new CategoriaModalidadEjercicio { Id = 51, Categoria = "SENIOR",Modalidad = "WG",Ejercicio = "COM",CatModEj = "SENIOR WG COM",CatMod="SENIOR WG" } },
                                        { new CategoriaModalidadEjercicio { Id = 52, Categoria = "SENIOR",Modalidad = "MG",Ejercicio = "BAL",CatModEj = "SENIOR MG BAL",CatMod="SENIOR MG" } },
                                        { new CategoriaModalidadEjercicio { Id = 53, Categoria = "SENIOR",Modalidad = "MG",Ejercicio = "DYN",CatModEj = "SENIOR MG DYN",CatMod="SENIOR MG" } },
                                         { new CategoriaModalidadEjercicio { Id = 54, Categoria = "SENIOR",Modalidad = "MG",Ejercicio = "COM",CatModEj = "SENIOR MG COM",CatMod="SENIOR MG" } }

                };
        }
        /// <summary>
        /// Gets the entire list of Judge Categories
        /// </summary>
        public static List<CategoriaModalidadEjercicio> GetAll
        {
            get
            {
                return getAll;
            }
        }
        /// <summary>
        /// Gets or sets the id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Categoria { get; set; }
        public string Modalidad { get; set; }
        public string Ejercicio { get; set; }
        public string CatModEj { get; set; }
        public string CatMod { get; set; }
        public string D1Judge { get; set; }
        public string D2Judge { get; set; }
    }

    public class NoSameCountryInSame
    {
        private static Dictionary<int, NoSameCountryInSame> getAll;
        /// <summary>
        /// Initializes static members 
        /// </summary>
        static NoSameCountryInSame()
        {
            getAll = new Dictionary<int, NoSameCountryInSame>()
                {
                    { 0, new NoSameCountryInSame { Id = 0, Valor = "No same country in same panel"  } },
                    { 1, new NoSameCountryInSame { Id = 1, Valor = "No same country in same role" } }
                };
        }
        /// <summary>
        /// Gets the entire list of Judge Categories
        /// </summary>
        public static Dictionary<int, NoSameCountryInSame> GetAll
        {
            get
            {
                return getAll;
            }
        }
        /// <summary>
        /// Gets or sets the id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Valor { get; set; }
    }

    public class F3Condition

    /*                                <ComboBoxItem Content="3 Randomized"/>
                            <ComboBoxItem Content="3 With finalists"/>
                            <ComboBoxItem Content="3 Without finalists"/>
                            <ComboBoxItem Content="3 Randomized based on least amount of sessions judged"/>*/
    {
        private static List<F3Condition> getAll;
        /// <summary>
        /// Initializes static members 
        /// </summary>
        static F3Condition()
        {
            getAll = new List<F3Condition>()
                {
                    { new F3Condition { Id = 0, Valor = "Randomized"  } },
                    { new F3Condition { Id = 1, Valor = "With finalists" } },
                    { new F3Condition { Id = 2, Valor = "Without finalists" } },
                    { new F3Condition { Id = 3, Valor = "Randomized based on least amount of sessions judged" } }

                };
        }
        /// <summary>
        /// Gets the entire list of Judge Categories
        /// </summary>
        public static List<F3Condition> GetAll
        {
            get
            {
                return getAll;
            }
        }
        /// <summary>
        /// Gets or sets the id 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Valor { get; set; }
    }


}
