using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JudgesDrawMDD
{
    public class Horario : ObservableCollection<LineaHorario>
    {
        public Horario() { }
        public Horario(string archivo) : base()
        {

            basededatos<LineaHorario> bdhorario = new basededatos<LineaHorario>(archivo);
            bdhorario.Cargar();
            foreach (LineaHorario lh in bdhorario.valores)
            {
                Add(lh);
            }
        }
        public void GuardarHorario(string archivo)
        {
            basededatos<LineaHorario> bdhorario = new basededatos<LineaHorario>(archivo);
            bdhorario.GuardarObservableCollection(this);

        }
    }

   public class LineaHorario : INotifyPropertyChanged
    {
         private string _SessionDate ;
         private string _SessionDay ;
         private string _SessionNumber ;
         private string _SessionTime ;

         private string _CatModExP1 ;
         private string _CompetitionP1 ;


         private int _E1JudgeP1 ;
         private int _E2JudgeP1 ;
         private int _E3JudgeP1 ;
         private int _E4JudgeP1 ;
        private int _E5JudgeP1;
        private int _E6JudgeP1;
        private int _A1JudgeP1 ;
         private int _A2JudgeP1 ;
         private int _A3JudgeP1 ;
         private int _A4JudgeP1 ;
        private int _A5JudgeP1;
        private int _A6JudgeP1;
        private int _REJudgeP1 ;
         private int _RAJudgeP1 ;
         private int _TJudgeP1 ;



         private int _E1JudgeP2 ;
         private int _E2JudgeP2 ;
         private int _E3JudgeP2 ;
         private int _E4JudgeP2 ;
        private int _E5JudgeP2;
        private int _E6JudgeP2;
        private int _A1JudgeP2 ;
         private int _A2JudgeP2 ;
         private int _A3JudgeP2 ;
         private int _A4JudgeP2 ;
        private int _A5JudgeP2;
        private int _A6JudgeP2;
        private int _TJudgeP2 ;
         private int _REJudgeP2 ;
         private int _RAJudgeP2 ;



         private int _L1Judge ;
         private int _L2Judge ;
         private int _INQJudge ;

         private string _CatModExP2 ;
         private string _CompetitionP2 ;

         private int _Relative1P1 ;
         private int _Relative2P1 ;
         private int _Relative3P1 ;
         private int _Relative4P1 ;
         private int _Relative1P2 ;
         private int _Relative2P2 ;
         private int _Relative3P2 ;
         private int _Relative4P2 ;

        public string SessionDate
        {
            get
            {
                return this._SessionDate;
            }

            set
            {
                if (value != this._SessionDate)
                {
                    this._SessionDate = value;
                    OnChanged("SessionDate");
                }
            }
        }
        public string SessionDay
        {
            get
            {
                return this._SessionDay;
            }

            set
            {
                if (value != this._SessionDay)
                {
                    this._SessionDay = value;
                    OnChanged("SessionDay");
                }
            }
        }
        public string SessionNumber
        {
            get
            {
                return this._SessionNumber;
            }

            set
            {
                if (value != this._SessionNumber)
                {
                    this._SessionNumber = value;
                    OnChanged("SessionNumber");
                }
            }
        }
        public string SessionTime
        {
            get
            {
                return this._SessionTime;
            }

            set
            {
                if (value != this._SessionTime)
                {
                    this._SessionTime = value;
                    OnChanged("SessionTime");
                }
            }
        }

        public string CompetitionP1
        {
            get
            {
                return this._CompetitionP1;
            }

            set
            {
                if (value != this._CompetitionP1)
                {
                    this._CompetitionP1 = value;
                    OnChanged("CompetitionP1");
                }
            }
        }

        public string CatModExP1
        {
            get
            {
                return this._CatModExP1;
            }

            set
            {
                if (value != this._CatModExP1)
                {
                    this._CatModExP1 = value;
                    OnChanged("CatModExP1");
                }
            }
        }

        public string CompetitionP2
        {
            get
            {
                return this._CompetitionP2;
            }

            set
            {
                if (value != this._CompetitionP2)
                {
                    this._CompetitionP2 = value;
                    OnChanged("CompetitionP2");
                }
            }
        }

        public string CatModExP2
        {
            get
            {
                return this._CatModExP2;
            }

            set
            {
                if (value != this._CatModExP2)
                {
                    this._CatModExP2 = value;
                    OnChanged("CatModExP2");
                }
            }
        }

        // Valores Draw P1

        public int E1JudgeP1
        {
            get
            {
                return this._E1JudgeP1;
            }

            set
            {
                if (value != this._E1JudgeP1)
                {
                    this._E1JudgeP1 = value;
                    OnChanged("E1JudgeP1");
                }
            }
        }

        public int E2JudgeP1
        {
            get
            {
                return this._E2JudgeP1;
            }

            set
            {
                if (value != this._E2JudgeP1)
                {
                    this._E2JudgeP1 = value;
                    OnChanged("E2JudgeP1");
                }
            }
        }

        public int E3JudgeP1
        {
            get
            {
                return this._E3JudgeP1;
            }

            set
            {
                if (value != this._E3JudgeP1)
                {
                    this._E3JudgeP1 = value;
                    OnChanged("E3JudgeP1");
                }
            }
        }
        public int E4JudgeP1
        {
            get
            {
                return this._E4JudgeP1;
            }

            set
            {
                if (value != this._E4JudgeP1)
                {
                    this._E4JudgeP1 = value;
                    OnChanged("E4JudgeP1");
                }
            }
        }
        public int E5JudgeP1
        {
            get
            {
                return this._E5JudgeP1;
            }

            set
            {
                if (value != this._E5JudgeP1)
                {
                    this._E5JudgeP1 = value;
                    OnChanged("E5JudgeP1");
                }
            }
        }
        public int E6JudgeP1
        {
            get
            {
                return this._E6JudgeP1;
            }

            set
            {
                if (value != this._E6JudgeP1)
                {
                    this._E6JudgeP1 = value;
                    OnChanged("E6JudgeP1");
                }
            }
        }
        public int A1JudgeP1
        {
            get
            {
                return this._A1JudgeP1;
            }

            set
            {
                if (value != this._A1JudgeP1)
                {
                    this._A1JudgeP1 = value;
                    OnChanged("A1JudgeP1");
                }
            }
        }
        public int A2JudgeP1
        {
            get
            {
                return this._A2JudgeP1;
            }

            set
            {
                if (value != this._A2JudgeP1)
                {
                    this._A2JudgeP1 = value;
                    OnChanged("A2JudgeP1");
                }
            }
        }
        public int A3JudgeP1
        {
            get
            {
                return this._A3JudgeP1;
            }

            set
            {
                if (value != this._A3JudgeP1)
                {
                    this._A3JudgeP1 = value;
                    OnChanged("A3JudgeP1");
                }
            }
        }
        public int A4JudgeP1
        {
            get
            {
                return this._A4JudgeP1;
            }

            set
            {
                if (value != this._A4JudgeP1)
                {
                    this._A4JudgeP1 = value;
                    OnChanged("A4JudgeP1");
                }
            }
        }
        public int A5JudgeP1
        {
            get
            {
                return this._A5JudgeP1;
            }

            set
            {
                if (value != this._A5JudgeP1)
                {
                    this._A5JudgeP1 = value;
                    OnChanged("A5JudgeP1");
                }
            }
        }
        public int A6JudgeP1
        {
            get
            {
                return this._A6JudgeP1;
            }

            set
            {
                if (value != this._A6JudgeP1)
                {
                    this._A6JudgeP1 = value;
                    OnChanged("A6JudgeP1");
                }
            }
        }
        public int REJudgeP1
        {
            get
            {
                return this._REJudgeP1;
            }

            set
            {
                if (value != this._REJudgeP1)
                {
                    this._REJudgeP1 = value;
                    OnChanged("REJudgeP1");
                }
            }
        }
        public int RAJudgeP1
        {
            get
            {
                return this._RAJudgeP1;
            }

            set
            {
                if (value != this._RAJudgeP1)
                {
                    this._RAJudgeP1 = value;
                    OnChanged("RAJudgeP1");
                }
            }
        }
        public int TJudgeP1
        {
            get
            {
                return this._TJudgeP1;
            }

            set
            {
                if (value != this._TJudgeP1)
                {
                    this._TJudgeP1 = value;
                    OnChanged("TJudgeP1");
                }
            }
        }

        // Valores Draw P2

        public int E1JudgeP2
        {
            get
            {
                return this._E1JudgeP2;
            }

            set
            {
                if (value != this._E1JudgeP2)
                {
                    this._E1JudgeP2 = value;
                    OnChanged("E1JudgeP2");
                }
            }
        }

        public int E2JudgeP2
        {
            get
            {
                return this._E2JudgeP2;
            }

            set
            {
                if (value != this._E2JudgeP2)
                {
                    this._E2JudgeP2 = value;
                    OnChanged("E2JudgeP2");
                }
            }
        }

        public int E3JudgeP2
        {
            get
            {
                return this._E3JudgeP2;
            }

            set
            {
                if (value != this._E3JudgeP2)
                {
                    this._E3JudgeP2 = value;
                    OnChanged("E3JudgeP2");
                }
            }
        }
        public int E4JudgeP2
        {
            get
            {
                return this._E4JudgeP2;
            }

            set
            {
                if (value != this._E4JudgeP2)
                {
                    this._E4JudgeP2 = value;
                    OnChanged("E4JudgeP2");
                }
            }
        }
        public int E5JudgeP2
        {
            get
            {
                return this._E5JudgeP2;
            }

            set
            {
                if (value != this._E5JudgeP2)
                {
                    this._E5JudgeP2 = value;
                    OnChanged("E5JudgeP2");
                }
            }
        }
        public int E6JudgeP2
        {
            get
            {
                return this._E6JudgeP2;
            }

            set
            {
                if (value != this._E6JudgeP2)
                {
                    this._E6JudgeP2 = value;
                    OnChanged("E6JudgeP2");
                }
            }
        }
        public int A1JudgeP2
        {
            get
            {
                return this._A1JudgeP2;
            }

            set
            {
                if (value != this._A1JudgeP2)
                {
                    this._A1JudgeP2 = value;
                    OnChanged("A1JudgeP2");
                }
            }
        }
        public int A2JudgeP2
        {
            get
            {
                return this._A2JudgeP2;
            }

            set
            {
                if (value != this._A2JudgeP2)
                {
                    this._A2JudgeP2 = value;
                    OnChanged("A2JudgeP2");
                }
            }
        }
        public int A3JudgeP2
        {
            get
            {
                return this._A3JudgeP2;
            }

            set
            {
                if (value != this._A3JudgeP2)
                {
                    this._A3JudgeP2 = value;
                    OnChanged("A3JudgeP2");
                }
            }
        }
        public int A4JudgeP2
        {
            get
            {
                return this._A4JudgeP2;
            }

            set
            {
                if (value != this._A4JudgeP2)
                {
                    this._A4JudgeP2 = value;
                    OnChanged("A4JudgeP2");
                }
            }
        }
        public int A5JudgeP2
        {
            get
            {
                return this._A5JudgeP2;
            }

            set
            {
                if (value != this._A5JudgeP2)
                {
                    this._A5JudgeP2 = value;
                    OnChanged("A5JudgeP2");
                }
            }
        }
        public int A6JudgeP2
        {
            get
            {
                return this._A6JudgeP2;
            }

            set
            {
                if (value != this._A6JudgeP2)
                {
                    this._A6JudgeP2 = value;
                    OnChanged("A6JudgeP2");
                }
            }
        }
        public int REJudgeP2
        {
            get
            {
                return this._REJudgeP2;
            }

            set
            {
                if (value != this._REJudgeP2)
                {
                    this._REJudgeP2 = value;
                    OnChanged("REJudgeP2");
                }
            }
        }
        public int RAJudgeP2
        {
            get
            {
                return this._RAJudgeP2;
            }

            set
            {
                if (value != this._RAJudgeP2)
                {
                    this._RAJudgeP2 = value;
                    OnChanged("RAJudgeP2");
                }
            }
        }
        public int TJudgeP2
        {
            get
            {
                return this._TJudgeP2;
            }

            set
            {
                if (value != this._TJudgeP2)
                {
                    this._TJudgeP2 = value;
                    OnChanged("TJudgeP2");
                }
            }
        }


        // Valores Draw Generales
        public int L1Judge
        {
            get
            {
                return this._L1Judge;
            }

            set
            {
                if (value != this._L1Judge)
                {
                    this._L1Judge = value;
                    OnChanged("L1Judge");
                }
            }
        }
        public int L2Judge
        {
            get
            {
                return this._L2Judge;
            }

            set
            {
                if (value != this._L2Judge)
                {
                    this._L2Judge = value;
                    OnChanged("L2Judge");
                }
            }
        }
        public int INQJudge
        {
            get
            {
                return this._INQJudge;
            }

            set
            {
                if (value != this._INQJudge)
                {
                    this._INQJudge = value;
                    OnChanged("INQJudge");
                }
            }
        }

        public int Relative1P1
        {
            get
            {
                return this._Relative1P1;
            }

            set
            {
                if (value != this._Relative1P1)
                {
                    this._Relative1P1 = value;
                    OnChanged("Relative1P1");
                }
            }
        }
        public int Relative2P1
        {
            get
            {
                return this._Relative2P1;
            }

            set
            {
                if (value != this._Relative2P1)
                {
                    this._Relative2P1 = value;
                    OnChanged("Relative2P1");
                }
            }
        }
        public int Relative3P1
        {
            get
            {
                return this._Relative3P1;
            }

            set
            {
                if (value != this._Relative3P1)
                {
                    this._Relative3P1 = value;
                    OnChanged("Relative3P1");
                }
            }
        }
        public int Relative4P1
        {
            get
            {
                return this._Relative4P1;
            }

            set
            {
                if (value != this._Relative4P1)
                {
                    this._Relative4P1 = value;
                    OnChanged("Relative4P1");
                }
            }
        }

        public int Relative1P2
        {
            get
            {
                return this._Relative1P2;
            }

            set
            {
                if (value != this._Relative1P2)
                {
                    this._Relative1P2 = value;
                    OnChanged("Relative1P2");
                }
            }
        }
        public int Relative2P2
        {
            get
            {
                return this._Relative2P2;
            }

            set
            {
                if (value != this._Relative2P2)
                {
                    this._Relative2P2 = value;
                    OnChanged("Relative2P2");
                }
            }
        }
        public int Relative3P2
        {
            get
            {
                return this._Relative3P2;
            }

            set
            {
                if (value != this._Relative3P2)
                {
                    this._Relative3P2 = value;
                    OnChanged("Relative3P2");
                }
            }
        }
        public int Relative4P2
        {
            get
            {
                return this._Relative4P2;
            }

            set
            {
                if (value != this._Relative4P2)
                {
                    this._Relative4P2 = value;
                    OnChanged("Relative4P2");
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
    public class CategoriasCompeticion : ObservableCollection<Categoria>
    {
        CategoriasCompeticion(string archivo) : base()
        {
            basededatos<Categoria> bdcategorias = new basededatos<Categoria>(archivo);
            bdcategorias.Cargar();
            foreach (Categoria cat in bdcategorias.valores)
            {
                Add(cat);
            }
        }
        public void GuardarCategorias(string archivo)
        {
            basededatos<Categoria> bdcategorias = new basededatos<Categoria>(archivo);
            bdcategorias.GuardarObservableCollection(this);

        }

    }
    public class Categoria
{
    public int Id { get; set; }
    public string Denominacion { get; set; }
}
    public class ModalidadesCompeticion : ObservableCollection<Modalidad>
    {
        ModalidadesCompeticion(string archivo) : base()
        {
            basededatos<Modalidad> bdmod = new basededatos<Modalidad>(archivo);
            bdmod.Cargar();
            foreach (Modalidad mod in bdmod.valores)
            {
                Add(mod);
            }
        }
        public void GuardarModalidades(string archivo)
        {
            basededatos<Modalidad> bdmod = new basededatos<Modalidad>(archivo);
            bdmod.GuardarObservableCollection(this);
        }

    }
    public class Modalidad
    {
        public int Id { get; set; }
        public string Denominacion { get; set; }
    }

    public class Rotacion
    {   
       public string FQ { get; set; }
        public string Categoria { get; set; }
        public string Modalidad { get; set; }
        public string Ejercicio { get; set; }
        public string CatModEj { get; set; }
        public string D1Judge { get; set; }
        public string D2Judge { get; set; }
    }
    public class DifficultyJudgges
    {
        public string Categoria { get; set; }
        public string Modalidad { get; set; }
        public string Ejercicio { get; set; }
        public string D1Judge { get; set; }
        public string D2Judge { get; set; }
    }
}
