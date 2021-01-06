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

        private int _SettingsP1EJudges;
        private int _SettingsP1AJudges;
        private int _SettingsP1REJudges;
        private int _SettingsP1RAJudges;
        private int _SettingsP1C4Judges;

        private string _SettingsP1Condition1;
        private string _SettingsP1Condition2;
        private string _SettingsP1Condition3;
        private string _SettingsP1Condition4;

        private int _SettingsP2EJudges;
        private int _SettingsP2AJudges;
        private int _SettingsP2REJudges;
        private int _SettingsP2RAJudges;
        private int _SettingsP2C4Judges;

        private string _SettingsP2Condition1;
        private string _SettingsP2Condition2;
        private string _SettingsP2Condition3;
        private string _SettingsP2Condition4;

        private int _SettingsTJudges;
        private int _SettingsLJudges;
        private int _SettingsIJudges;

        public int SettingsP1EJudges
        {
            get
            {
                return this._SettingsP1EJudges;
            }

            set
            {
                if (value != this._SettingsP1EJudges)
                {
                    this._SettingsP1EJudges = value;
                    OnChanged("SettingsP1EJudges");
                }
            }
        }

        public int SettingsP1AJudges
        {
            get
            {
                return this._SettingsP1AJudges;
            }

            set
            {
                if (value != this._SettingsP1AJudges)
                {
                    this._SettingsP1AJudges = value;
                    OnChanged("SettingsP1AJudges");
                }
            }
        }

        public int SettingsP1REJudges
        {
            get
            {
                return this._SettingsP1REJudges;
            }

            set
            {
                if (value != this._SettingsP1REJudges)
                {
                    this._SettingsP1REJudges = value;
                    OnChanged("SettingsP1REJudges");
                }
            }
        }

        public int SettingsP1RAJudges
        {
            get
            {
                return this._SettingsP1RAJudges;
            }

            set
            {
                if (value != this._SettingsP1RAJudges)
                {
                    this._SettingsP1AJudges = value;
                    OnChanged("SettingsP1RAJudges");
                }
            }
        }

        public int SettingsP1C4Judges
        {
            get
            {
                return this._SettingsP1C4Judges;
            }

            set
            {
                if (value != this._SettingsP1C4Judges)
                {
                    this._SettingsP1C4Judges = value;
                    OnChanged("SettingsP1C4Judges");
                }
            }
        }

        public int SettingsP2EJudges
        {
            get
            {
                return this._SettingsP2EJudges;
            }

            set
            {
                if (value != this._SettingsP2EJudges)
                {
                    this._SettingsP2EJudges = value;
                    OnChanged("SettingsP2EJudges");
                }
            }
        }

        public int SettingsP2AJudges
        {
            get
            {
                return this._SettingsP2AJudges;
            }

            set
            {
                if (value != this._SettingsP2AJudges)
                {
                    this._SettingsP2AJudges = value;
                    OnChanged("SettingsP2AJudges");
                }
            }
        }

        public int SettingsP2REJudges
        {
            get
            {
                return this._SettingsP2REJudges;
            }

            set
            {
                if (value != this._SettingsP2REJudges)
                {
                    this._SettingsP2REJudges = value;
                    OnChanged("SettingsP2REJudges");
                }
            }
        }

        public int SettingsP2RAJudges
        {
            get
            {
                return this._SettingsP2RAJudges;
            }

            set
            {
                if (value != this._SettingsP2RAJudges)
                {
                    this._SettingsP2AJudges = value;
                    OnChanged("SettingsP2RAJudges");
                }
            }
        }

        public int SettingsP2C4Judges
        {
            get
            {
                return this._SettingsP2C4Judges;
            }

            set
            {
                if (value != this._SettingsP2C4Judges)
                {
                    this._SettingsP2C4Judges = value;
                    OnChanged("SettingsP2C4Judges");
                }
            }
        }

        public int SettingsTJudges
        {
            get
            {
                return this._SettingsTJudges;
            }

            set
            {
                if (value != this._SettingsTJudges)
                {
                    this._SettingsTJudges = value;
                    OnChanged("SettingsTJudges");
                }
            }
        }

        public int SettingsLJudges
        {
            get
            {
                return this._SettingsLJudges;
            }

            set
            {
                if (value != this._SettingsLJudges)
                {
                    this._SettingsLJudges = value;
                    OnChanged("SettingsLJudges");
                }
            }
        }

        public int SettingsIJudges
        {
            get
            {
                return this._SettingsIJudges;
            }

            set
            {
                if (value != this._SettingsIJudges)
                {
                    this._SettingsIJudges = value;
                    OnChanged("SettingsIJudges");
                }
            }
        }

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

        public string SettingsP1Condition1
        {
            get
            {
                return this._SettingsP1Condition1;
            }

            set
            {
                if (value != this._SettingsP1Condition1)
                {
                    this._SettingsP1Condition1 = value;
                    OnChanged("SettingsP1Condition1");
                }
            }
        }

        public string SettingsP1Condition2
        {
            get
            {
                return this._SettingsP1Condition2;
            }

            set
            {
                if (value != this._SettingsP1Condition2)
                {
                    this._SettingsP1Condition2 = value;
                    OnChanged("SettingsP1Condition2");
                }
            }
        }

        public string SettingsP1Condition3
        {
            get
            {
                return this._SettingsP1Condition3;
            }

            set
            {
                if (value != this._SettingsP1Condition3)
                {
                    this._SettingsP1Condition3 = value;
                    OnChanged("SettingsP1Condition3");
                }
            }
        }
        public string SettingsP1Condition4
        {
            get
            {
                return this._SettingsP1Condition4;
            }

            set
            {
                if (value != this._SettingsP1Condition4)
                {
                    this._SettingsP1Condition4 = value;
                    OnChanged("SettingsP1Condition4");
                }
            }
        }


        public string SettingsP2Condition1
        {
            get
            {
                return this._SettingsP2Condition1;
            }

            set
            {
                if (value != this._SettingsP2Condition1)
                {
                    this._SettingsP2Condition1 = value;
                    OnChanged("SettingsP2Condition1");
                }
            }
        }

        public string SettingsP2Condition2
        {
            get
            {
                return this._SettingsP2Condition2;
            }

            set
            {
                if (value != this._SettingsP2Condition2)
                {
                    this._SettingsP2Condition2 = value;
                    OnChanged("SettingsP2Condition2");
                }
            }
        }

        public string SettingsP2Condition3
        {
            get
            {
                return this._SettingsP2Condition3;
            }

            set
            {
                if (value != this._SettingsP2Condition3)
                {
                    this._SettingsP2Condition3 = value;
                    OnChanged("SettingsP2Condition3");
                }
            }
        }
        public string SettingsP2Condition4
        {
            get
            {
                return this._SettingsP2Condition4;
            }

            set
            {
                if (value != this._SettingsP2Condition4)
                {
                    this._SettingsP2Condition4 = value;
                    OnChanged("SettingsP2Condition4");
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
