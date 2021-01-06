using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using System.Security.Cryptography;

namespace JudgesDrawMDD
{


    public class Valores
    {
        public string Valor { get; set; }
        public Valores(string pvalor)
        {
            Valor = pvalor;
        }
    }

    public class ListaValores : ObservableCollection<Valores>
    {
        public ListaValores() { }
    }



    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Definicion de variables globales 

        basededatos<Evento> bdevento;
        public static Evento evento = new Evento();
        string rutageneraldelevento;
        string logoevento;
        public static Jueces jueces = new Jueces();
        public int numero_evento_trabajo;
        Countries CountrystringCollection = new Countries();
        Evento_De_Trabajo evento_de_trabajo = new Evento_De_Trabajo();
        Lista_Eventos_Guardados lista_eventos_guardados;
        Lista_Eventos_Guardados lista_eventos_guardados_trabajo;
        Horario horario = new Horario();
        EventFinalCountries eventfinalcountries = new EventFinalCountries();
        EstadisticasJueces estadisticasJueces = new EstadisticasJueces();
        List<CategoriaModalidadEjercicio> CME = new List<CategoriaModalidadEjercicio>();
        F3Condition F3C = new F3Condition();
        Relatives relatives = new Relatives();
        Relatives relativesP1 = new Relatives();
        Relatives relativesP2 = new Relatives();
        //Relative relative = new Relative();
        int indicehorario = 0;

        public Func<ChartPoint, string> PointLabel { get; set; }

        public void PieChart()
        {
            PointLabel = chartPoint => string.Format("{0}({1:P})", chartPoint.Y, chartPoint.Participation);
            DataContext = this;
        }



        public MainWindow()
        {

            InitializeComponent();

            this.PieChart();

            numero_evento_trabajo = 0;
            // al iniciar, cargamos la lista de eventos, seleccionamos el primero y descargamos la lista
            try
            {
                lista_eventos_guardados = new Lista_Eventos_Guardados(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\listaeventos.json");
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom("Linea 99. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
            // cogemos el último evento guardado
            numero_evento_trabajo = lista_eventos_guardados.Count - 1;
            Inicialiar_Evento_de_lista(numero_evento_trabajo);
            GridHome.Visibility = Visibility.Visible;
            GridJudges.Visibility = Visibility.Hidden;
            GridDJAssign.Visibility = Visibility.Hidden;
            GridSchedule.Visibility = Visibility.Hidden;
            GridDrawSettings.Visibility = Visibility.Hidden;
            GridFinalsCountries.Visibility = Visibility.Hidden;
            GridDraw.Visibility = Visibility.Hidden;

        }

        private void InicializarJuecesD()
        {
            Jueces juecesd = new Jueces();
            foreach (Juez j in jueces.Where(x => x.Country == "UEG" && x.JudgeName != evento.SJPJudge && x.JudgeName != evento.SJE1Judge && x.JudgeName != evento.SJE2Judge && x.JudgeName != evento.SJA1Judge && x.JudgeName != evento.SJA2Judge && x.JudgeName != evento.SJD1Judge && x.JudgeName != evento.SJD2Judge && x.JudgeName != evento.CPJP1 && x.JudgeName != evento.CPJP2))
            {
                
                juecesd.Add(j);
            }

            CBWP1116BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1116BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1116DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1116DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1218BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1218BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1218DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1218DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1218COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1218COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1319BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1319BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1319DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1319DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1319COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWP1319COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);

            CBWPSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);

            CBWPSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWPSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);

            CBMP1116BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1116BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1116DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1116DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1218BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1218BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1218DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1218DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1218COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1218COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1319BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1319BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1319DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1319DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1319COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMP1319COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMPSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);

            CBMXP1116BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1116BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1116DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1116DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1218BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1218BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1218DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1218DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1218COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1218COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1319BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1319BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1319DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1319DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1319COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXP1319COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMXPSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);

            CBWG1116BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1116BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1116DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1116DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1218BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1218BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1218DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1218DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1218COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1218COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1319BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1319BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1319DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1319DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1319COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWG1319COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBWGSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);

            CBMG1116BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1116BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1116DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1116DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1218BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1218BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1218DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1218DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1218COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1218COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1319BALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1319BALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1319DYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1319DYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1319COMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMG1319COMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENBALD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENBALD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENDYND1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENDYND2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENCOMD1.ItemsSource = juecesd.OrderBy(x => x.JudgeName);
            CBMGSENCOMD2.ItemsSource = juecesd.OrderBy(x => x.JudgeName);


        }

        private void Inicialiar_Evento_de_lista(int num_evento)
        {
            /*principio de inicialización*/
            evento_de_trabajo = lista_eventos_guardados[num_evento];
            // vaciamos la lista de eventos guardados

            evento = evento_de_trabajo.Evento_; // inicializamos evento

            jueces.CollectionChanged += Jueces_CollectionChanged;
            horario.CollectionChanged += Horario_CollectionChanged;
            relatives.CollectionChanged += Relatives_CollectionChanged;
            eventfinalcountries.CollectionChanged += EventFinalCountries_CollectionChanged;

            foreach (Juez j in evento_de_trabajo.Jueces_)
            {
                jueces.Add(j);
            }

            foreach (Relative rel in evento_de_trabajo.Relatives_)
            {
                relatives.Add(rel);
            }

            foreach (FinalCountries fc in evento_de_trabajo.EventFinalCountries_)
            {
                eventfinalcountries.Add(fc);
            }

            foreach (LineaHorario lh in evento_de_trabajo.Horario_)
            {
                horario.Add(lh);
            }

            //        RestablecerConteoParticipacionesJueces();

            GridDrawSettings.DataContext = evento;
            GridDifficultyJudges.DataContext = evento;
            GridDatosEvento.DataContext = evento;
            GridInformacionEvento.DataContext = evento;
            GridSchedule.DataContext = evento;
            GridDraw.DataContext = evento;
            Lnombreevento.Content = evento_de_trabajo.Event_Name;
            Lfechaevento.Content = evento_de_trabajo.SaveDate;

            InicializarCME();
            InicializarJuecesD();

            FinalCountriesDataGrid.ItemsSource = eventfinalcountries;
            RelativesDataGrid.ItemsSource = relatives;
            ScheduleDataGrid.ItemsSource = horario;
            JuecesDataGrid.ItemsSource = jueces;
            CBJudgeNameRel.ItemsSource = jueces;
            CBJudgeNameRel.DisplayMemberPath = "JudgeName";
            CBJudgeNameRel.SelectedValuePath = "JudgeName";

            CBCompetitionP1.ItemsSource = TipoCompeticion.GetAll;
            CBCompetitionP2.ItemsSource = TipoCompeticion.GetAll;


            CBSJPresident.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJPresident.DisplayMemberPath = "JudgeName";
            CBSJPresident.SelectedValuePath = "JudgeName";

            CBSJD1.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJD1.DisplayMemberPath = "JudgeName";
            CBSJD1.SelectedValuePath = "JudgeName";

            CBSJD2.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJD2.DisplayMemberPath = "JudgeName";
            CBSJD2.SelectedValuePath = "JudgeName";

            CBSJE1.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJE1.DisplayMemberPath = "JudgeName";
            CBSJE1.SelectedValuePath = "JudgeName";

            CBSJE2.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJE2.DisplayMemberPath = "JudgeName";
            CBSJE2.SelectedValuePath = "JudgeName";

            CBSJA1.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJA1.DisplayMemberPath = "JudgeName";
            CBSJA1.SelectedValuePath = "JudgeName";

            CBSJA2.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSJA2.DisplayMemberPath = "JudgeName";
            CBSJA2.SelectedValuePath = "JudgeName";

            CBSCJPPanel1.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSCJPPanel1.DisplayMemberPath = "JudgeName";
            CBSCJPPanel1.SelectedValuePath = "JudgeName";

            CBSCJPPanel2.ItemsSource = jueces.OrderBy(x => x.Category).ThenBy(x => x.JudgeName);
            CBSCJPPanel2.DisplayMemberPath = "JudgeName";
            CBSCJPPanel2.SelectedValuePath = "JudgeName";

            // Establecer valores para selección de 4 o 6 jueces

            Valores valor1 = new Valores("4");
            Valores valor2 = new Valores("6");

            ListaValores listanumerojuecespaneles = new ListaValores();

            listanumerojuecespaneles.Add(valor1);
            listanumerojuecespaneles.Add(valor2);

            CBMaxEjueces.ItemsSource = listanumerojuecespaneles;
            CBMaxEjueces.DisplayMemberPath = "Valor";
            CBMaxEjueces.SelectedValuePath = "Valor";

            CBMaxAjueces.ItemsSource = listanumerojuecespaneles;
            CBMaxAjueces.DisplayMemberPath = "Valor";
            CBMaxAjueces.SelectedValuePath = "Valor";


            CBGCountries.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC1.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC2.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC3.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC4.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC5.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC6.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC7.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC8.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC9.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFC10.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);

            CBGCountriesFCR1.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);
            CBGCountriesFCR2.ItemsSource = CountrystringCollection.OrderBy(x => x.Alpha3);


            StackPanelJueces.DataContext = estadisticasJueces;
            PCSectoresNivelesJueces.DataContext = jueces;

            SeriesCollection Series = new SeriesCollection
            {
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {20, 30, 35, 45, 65, 85},
                    Title = "Electricity"
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {10, 12, 18, 20, 38, 40},
                    Title = "Water"
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {5, 8, 12, 15, 22, 25},
                    Title = "Solar"
                },
                new StackedAreaSeries
                {
                    Values = new ChartValues<double> {10, 12, 18, 20, 38, 40},
                    Title = "Gas"
                }
            };




















            indicehorario = 0;

            // Cargar el logo

            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri(evento.Event_logo, UriKind.Absolute);
                bi3.EndInit();
                IEventlogo.Source = bi3;
                IMGLogoEvento.Source = bi3;
                logoevento = evento.Event_logo;
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Ha ocurrido un problema al cargar el logo del evento: " + ex.Message, "Problemas", MessageBoxButton.OK, MessageBoxImage.Warning);
                //cambiarrutageneraldelevento();
            }

            ActualizarEstadisticasJueces();


            cargarlineahorario();
            /* Fin de la inicialización*/
        }

        private void Descargar_Evento_actual()
        {

            // Descargar jueces
            Eliminar_Contenido_Jueces();


            // eliminar el contenido de jueces
            RelativesDataGrid.ItemsSource = null;

            for (int i = relatives.Count - 1; i >= 0; i--)
            {

                relatives.RemoveAt(i);
            }

            //elimnar contenido de horario
            ScheduleDataGrid.ItemsSource = null;

            for (int i = horario.Count - 1; i >= 0; i--)
            {

                horario.RemoveAt(i);
            }
            //finals countries
            FinalCountriesDataGrid.ItemsSource = null;

            for (int i = eventfinalcountries.Count - 1; i >= 0; i--)
            {

                eventfinalcountries.RemoveAt(i);
            }

            GridDrawSettings.DataContext = null;
            GridDatosEvento.DataContext = null;
            GridInformacionEvento.DataContext = null;
            GridSchedule.DataContext = null;
            GridDifficultyJudges.DataContext = null;
        }

        private void InicializarCME()
        {
            CME.Clear();
            // Cuando se seleccionan modalidades en la pagina inicial del evento, hay que rehacer las posibilidades de selección de las modalidades y categorias
            if (evento.HasAgeGroup1116)
            {
                foreach (CategoriaModalidadEjercicio cat in CategoriaModalidadEjercicio.GetAll.Where(d => d.Categoria.Contains("11-16")))
                {
                    CME.Add(cat);
                }
            }
            if (evento.HasAgeGroup1218)
            {
                foreach (CategoriaModalidadEjercicio cat in CategoriaModalidadEjercicio.GetAll.Where(d => d.Categoria.Contains("12-18")))
                {
                    CME.Add(cat);
                }
            }
            if (evento.HasAgeGroup1319)
            {
                foreach (CategoriaModalidadEjercicio cat in CategoriaModalidadEjercicio.GetAll.Where(d => d.Categoria.Contains("13-19")))
                {
                    CME.Add(cat);
                }
            }
            if (evento.HasSenior)
            {
                foreach (CategoriaModalidadEjercicio cat in CategoriaModalidadEjercicio.GetAll.Where(d => d.Categoria.Contains("SENIOR")))
                {
                    CME.Add(cat);
                }
            }

            //  CME.Add(CategoriaModalidadEjercicio.GetAll.Where(d => d.Value.Categoria.Contains("11-16") | d.Value.Categoria.Contains("SENIOR")));
            CBCatModRel.ItemsSource = CME.GroupBy(x => x.CatMod).Select(y => y.First());
            CBCatModExP1.ItemsSource = CME;   // CategoriaModalidadEjercicio.GetAll.Where(d => d.Categoria.Contains("11-16") | d.Categoria.Contains("SENIOR"));
            CBCatModExP2.ItemsSource = CME; //CategoriaModalidadEjercicio.GetAll.Where(d => d.Categoria.Contains("SENIOR"));
            CBCatModExFC.ItemsSource = CME;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;

        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("Are you sure ? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                //Guardar nuevo evento en lista de eventos
                evento_de_trabajo.Event_Name = evento.Event_Name;
                evento_de_trabajo.SaveDate = DateTime.Now.ToString();
                evento_de_trabajo.Jueces_ = jueces;
                evento_de_trabajo.Horario_ = horario;
                evento_de_trabajo.Relatives_ = relatives;
                evento_de_trabajo.EventFinalCountries_ = eventfinalcountries;
                //Para guardar en la lista de eventos hay que volver a cargar la lista
                //comprobando que el número de eventos de trabajo guardados no supera el límite máximo de 5
                try
                {
                    lista_eventos_guardados = new Lista_Eventos_Guardados(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\listaeventos.json");
                }
                catch (Exception ex)
                {
                    _ = new MessageBoxCustom("Linea 533. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                }
                if (lista_eventos_guardados.Count() > 5)
                {
                    //si hay 5 borra el último
                    lista_eventos_guardados.RemoveAt(0);
                }
                //ponemos a false todos los eventos para que el unico sea
                foreach (Evento_De_Trabajo j in lista_eventos_guardados)
                {
                    if (j.IsSelected)
                    {
                        j.IsSelected = false;
                    }
                }
                //Hacemos que el último evento guardado sea el señalado porque se cargará en la próxima sesión
                evento_de_trabajo.IsSelected = true;
                lista_eventos_guardados.Add(evento_de_trabajo);
                lista_eventos_guardados.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\listaeventos.json");
                Application.Current.Shutdown();
            }
        }

        private void ListViewMenuLateral_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ListViewMenuLateral.SelectedIndex)
            {
                case 0:
                    GridHome.Visibility = Visibility.Visible;
                    GridJudges.Visibility = Visibility.Hidden;
                    GridDJAssign.Visibility = Visibility.Hidden;
                    GridSchedule.Visibility = Visibility.Hidden;
                    GridDrawSettings.Visibility = Visibility.Hidden;
                    GridFinalsCountries.Visibility = Visibility.Hidden;
                    GridDraw.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    GridHome.Visibility = Visibility.Hidden;
                    GridJudges.Visibility = Visibility.Visible;
                    GridDJAssign.Visibility = Visibility.Hidden;
                    GridSchedule.Visibility = Visibility.Hidden;
                    GridDrawSettings.Visibility = Visibility.Hidden;
                    GridFinalsCountries.Visibility = Visibility.Hidden;
                    GridDraw.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    GridHome.Visibility = Visibility.Hidden;
                    GridJudges.Visibility = Visibility.Hidden;
                    GridDJAssign.Visibility = Visibility.Visible;
                    GridSchedule.Visibility = Visibility.Hidden;
                    GridDrawSettings.Visibility = Visibility.Hidden;
                    GridFinalsCountries.Visibility = Visibility.Hidden;
                    GridDraw.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    GridHome.Visibility = Visibility.Hidden;
                    GridDJAssign.Visibility = Visibility.Hidden;
                    GridJudges.Visibility = Visibility.Hidden;
                    GridSchedule.Visibility = Visibility.Visible;
                    GridDrawSettings.Visibility = Visibility.Hidden;
                    GridFinalsCountries.Visibility = Visibility.Hidden;
                    GridDraw.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    GridHome.Visibility = Visibility.Hidden;
                    GridDJAssign.Visibility = Visibility.Hidden;
                    GridJudges.Visibility = Visibility.Hidden;
                    GridSchedule.Visibility = Visibility.Hidden;
                    GridDrawSettings.Visibility = Visibility.Visible;
                    GridFinalsCountries.Visibility = Visibility.Hidden;
                    GridDraw.Visibility = Visibility.Hidden;
                    break;
                case 5:
                    GridHome.Visibility = Visibility.Hidden;
                    GridDJAssign.Visibility = Visibility.Hidden;
                    GridJudges.Visibility = Visibility.Hidden;
                    GridSchedule.Visibility = Visibility.Hidden;
                    GridDrawSettings.Visibility = Visibility.Hidden;
                    GridFinalsCountries.Visibility = Visibility.Visible;
                    GridDraw.Visibility = Visibility.Hidden;
                    break;
                case 6:
                    //Actualizar antes de hacer visible el control correspondiente
                    cargarlineahorario();
                    GridHome.Visibility = Visibility.Hidden;
                    GridDJAssign.Visibility = Visibility.Hidden;
                    GridJudges.Visibility = Visibility.Hidden;
                    GridSchedule.Visibility = Visibility.Hidden;
                    GridDrawSettings.Visibility = Visibility.Hidden;
                    GridFinalsCountries.Visibility = Visibility.Hidden;
                    GridDraw.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void JuecesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            if (e.EditAction == DataGridEditAction.Commit)
            {

                var column = e.Column as DataGridColumn;

                if (column != null && column.DisplayIndex > 0)
                {
                    int rowIndex = e.Row.GetIndex();
                    ComboBox el = e.EditingElement as ComboBox;



                    if (column.Header.ToString() == "Country")
                    {
                        if (!string.IsNullOrEmpty(el.Text))
                        {
                            JuecesDataGrid.Focus();
                            JuecesDataGrid.CurrentCell = new DataGridCellInfo(JuecesDataGrid.Items[rowIndex], JuecesDataGrid.Columns[column.DisplayIndex - 1]);
                            JuecesDataGrid.BeginEdit();
                        }

                    }
                }

                ActualizarEstadisticasJueces();
            }
        }

        private void CheckAllPresence_Checked(object sender, RoutedEventArgs e)
        {
            foreach (Juez j in JuecesDataGrid.ItemsSource)
            {
                j.Presence = true;
            }
            estadisticasJueces.TotalJuecesPresentes = jueces.Count();

        }

        private void CheckAllPresence_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (Juez j in JuecesDataGrid.ItemsSource)
            {
                j.Presence = false;
            }
            estadisticasJueces.TotalJuecesPresentes = 0;
        }

        private void ResetTotalJudgeParticipatios_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("Are you sure?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                foreach (Juez j in JuecesDataGrid.ItemsSource)
                {
                    j.TotalA = 0;
                    j.TotalE = 0;
                    j.TotalFA = 0;
                    j.TotalFE = 0;
                }
                JuecesDataGrid.Items.Refresh();
            }
        }

        public ObservableCollection<Juez> Valores_unicos_Country(ObservableCollection<Juez> valores)
        {
            ObservableCollection<Juez> resultado = new ObservableCollection<Juez>();
            for (int i = 0; i < valores.Count; i++)
            {
                if (!(resultado.Where(x => x.Country == valores[i].Country).ToList().Count() > 0))
                {
                    resultado.Add(valores[i]);

                }
            }
            return resultado;
        }

        public ObservableCollection<Juez> Valores_unicos_CountryList(List<Juez> valores)
        {
            ObservableCollection<Juez> resultado = new ObservableCollection<Juez>();
            for (int i = 0; i < valores.Count; i++)
            {
                if (!(resultado.Where(x => x.Country == valores[i].Country).ToList().Count() > 0))
                {
                    resultado.Add(valores[i]);

                }
            }
            return resultado;
        }


        public ObservableCollection<Juez> Valores_unicos_Categorias(ObservableCollection<Juez> valores)
        {
            ObservableCollection<Juez> resultado = new ObservableCollection<Juez>();
            for (int i = 0; i < valores.Count; i++)
            {
                if (!(resultado.Where(x => x.Category == valores[i].Category).ToList().Count() > 0))
                {
                    resultado.Add(valores[i]);

                }
            }
            return resultado;
        }

        public ObservableCollection<Juez> Valores_unicos_CategoriasList(ObservableCollection<Juez> valores)
        {
            ObservableCollection<Juez> resultado = new ObservableCollection<Juez>();
            for (int i = 0; i < valores.Count; i++)
            {
                if (!(resultado.Where(x => x.Category == valores[i].Category).ToList().Count() > 0))
                {
                    resultado.Add(valores[i]);
                }
            }
            return resultado;
        }

        private void JuecesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Only act on Commit

            if (e.EditAction == DataGridEditAction.Commit)

            {
                // Juez juez = e.Row.DataContext as Juez;
            }
        }

        private void JuecesDataGrid_PreviewDeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == DataGrid.DeleteCommand)
            {
                bool? Result = new MessageBoxCustom("Are you sure?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

                if (Result.Value)
                {
                    ActualizarEstadisticasJueces();

                }
                else
                {
                    // Cancel Delete.
                    e.Handled = true;
                }
            }
        }

        private void ActualizarEstadisticasJueces()
        {
            estadisticasJueces.TotalJuecesPresentes = jueces.juecespresentes().Count();
            estadisticasJueces.TotalJuecesWarning = jueces.juecesconwarning().Count();
            estadisticasJueces.TotalJuecesCountries = Valores_unicos_Country(jueces).Count();
            estadisticasJueces.TotalJueces = jueces.Count();
        }

        public void Jueces_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Juez item in e.NewItems)
                    item.PropertyChanged += Juez_PropertyChanged;

            if (e.OldItems != null)
                foreach (Juez item in e.OldItems)
                    item.PropertyChanged -= Juez_PropertyChanged;
        }

        public void ListaEventos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Evento_De_Trabajo item in e.NewItems)
                    item.PropertyChanged += Evento_De_Trabajo_PropertyChanged;

            if (e.OldItems != null)
                foreach (Evento_De_Trabajo item in e.OldItems)
                    item.PropertyChanged -= Evento_De_Trabajo_PropertyChanged;
        }


        public void Horario_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (LineaHorario item in e.NewItems)
                    item.PropertyChanged += Horario_PropertyChanged;

            if (e.OldItems != null)
                foreach (LineaHorario item in e.OldItems)
                {
                    item.PropertyChanged -= Horario_PropertyChanged;
                    // Al eliminar una línea hay que poner el indice del horario a 0 por si el draw está mostrando el último sorteo
                    indicehorario = 0;
                }
        }

        public void Relatives_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (Relative item in e.NewItems)
                    item.PropertyChanged += Relatives_PropertyChanged;

            if (e.OldItems != null)
                foreach (Relative item in e.OldItems)
                    item.PropertyChanged -= Relatives_PropertyChanged;

        }

        public void EventFinalCountries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (FinalCountries item in e.NewItems)
                    item.PropertyChanged += EventFinalCountries_PropertyChanged;

            if (e.OldItems != null)
                foreach (FinalCountries item in e.OldItems)
                    item.PropertyChanged -= EventFinalCountries_PropertyChanged;

        }

        void EventFinalCountries_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

        }

        void Juez_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ActualizarEstadisticasJueces();
        }

        void Evento_De_Trabajo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Al seleccionar uno de los eventos de trabajo, deben deseleccionarse los demás
            var modifiedItem = (sender as Evento_De_Trabajo);
            if (modifiedItem.IsSelected)
            {
                // Desactivar el evento previamente seleccionado y refrescar el listado
                foreach (Evento_De_Trabajo j in lista_eventos_guardados_trabajo)
                {
                    if (j.IsSelected)
                    {
                        if (j.Event_Name != modifiedItem.Event_Name || j.SaveDate != modifiedItem.SaveDate)
                        {
                            j.IsSelected = false;

                        }
                    }
                }

            }

        }

        void Horario_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Habrá que hacer estadísticas del horario
        }

        void Relatives_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Habrá que hacer estadísticas de los familiares
        }

        private void HabiliarVistaWarning_Checked(object sender, RoutedEventArgs e)
        {
            JuecesDataGrid.Columns[12].Visibility = Visibility.Visible;
        }

        private void HabiliarVistaWarning_Unchecked(object sender, RoutedEventArgs e)
        {
            JuecesDataGrid.Columns[12].Visibility = Visibility.Collapsed;
        }

        private void BTnCargarExcel_ClickAsync(object sender, RoutedEventArgs e)
        {
            string txtFilePath;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".csv";
            openfile.Filter = "(.csv)|*.csv";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {


                txtFilePath = openfile.FileName;
                DataTable dt = new DataTable();
                dt.Columns.Add("#Judge", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Country", typeof(string));
                dt.Columns.Add("Category", typeof(string));
                // We change file extension here to make sure it's a .csv file.
                // TODO: Error checking.
                string[] lines = File.ReadAllLines(txtFilePath);
                string[] data;
                // lines.Select allows me to project each line as a Person. 
                // This will give me an IEnumerable<Person> back.
                foreach (string line in lines)
                {
                    data = line.Split(';');

                    dt.Rows.Add(data);
                }



                DHInportExcel.IsOpen = true;

                BTnCargarExcel.Visibility = Visibility.Hidden;
                JuecesDataGridInport.ItemsSource = dt.DefaultView;
                JuecesDataGridInport.Visibility = Visibility.Visible;
                BTnAppendJudges.Visibility = Visibility.Visible;
                BTnLoadJudges.Visibility = Visibility.Visible;
                BTnDelInportJudges.Visibility = Visibility.Visible;
                //  excelBook.Close(true, null, null);
                //  excelApp.Quit();

            }
        }

        private void BTnAppendJudges_Click(object sender, RoutedEventArgs e)
        {

            //recorrer el grid dtgrid e insertarlo en juecesdatagrid
            string numerojuez = "";
            string nombrejuez = "";
            string paisjuez = "";
            string categoriajuez = "";

            int j = 0;
            try
            {
                for (int i = 1; i < JuecesDataGridInport.Items.Count - 1; i++)
                {
                    numerojuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                    j++;
                    nombrejuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                    j++;
                    paisjuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                    j++;
                    categoriajuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                    j = 0;

                    //añadir los elementos al datagrid de jueces

                    Juez juez = new Juez();
                    juez.JudgeName = nombrejuez;
                    try
                    {
                        juez.Category = int.Parse(categoriajuez);

                    }
                    catch
                    {
                        juez.Category = 0;
                    }
                    try
                    {
                        juez.ID = int.Parse(numerojuez);
                    }
                    catch
                    {
                        juez.ID = 0;
                    }
                    juez.ID = int.Parse(numerojuez);
                    jueces.Add(juez);
                }
            }

            catch (Exception ex)
            {
                bool? Result2 = new MessageBoxCustom("Linea 1087. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
            BTnCargarExcel.Visibility = Visibility.Visible;
            DHInportExcel.IsOpen = false;
        }




        private void Eliminar_Contenido_Jueces()
        {

            // eliminar el contenido de jueces
            JuecesDataGrid.ItemsSource = null;
            if (jueces.Count() > 0)
            {
                jueces.Remove(x => x.ID > 0);
                ActualizarEstadisticasJueces();
            }
        }

        private void BTnLoadJudges_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("through this action you delete the judges an the draws. Sure?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();
            if (Result.Value)
            {
                Eliminar_Contenido_Jueces();

                //recorrer el grid dtgrid e insertarlo en juecesdatagrid
                string numerojuez = "";
                string nombrejuez = "";
                string paisjuez = "";
                string categoriajuez = "";
                int j = 0;
                try
                {


                    for (int i = 1; i < JuecesDataGridInport.Items.Count - 1; i++)
                    {
                        numerojuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                        j++;
                        nombrejuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                        j++;
                        paisjuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                        j++;
                        categoriajuez = (JuecesDataGridInport.Items[i] as System.Data.DataRowView).Row.ItemArray[j].ToString();
                        j = 0;

                        //añadir los elementos al datagrid de jueces

                        Juez juez = new Juez();
                        juez.JudgeName = nombrejuez;
                        juez.Country = paisjuez;
                        try
                        {
                            juez.Category = int.Parse(categoriajuez);

                        }
                        catch
                        {
                            juez.Category = 0;
                        }
                        try
                        {
                            juez.ID = int.Parse(numerojuez);
                        }
                        catch
                        {
                            juez.ID = 0;
                        }
                        jueces.Add(juez);
                    }
                }
                catch (Exception ex)
                {
                    bool? Result2 = new MessageBoxCustom("Linea 1087. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                }
                JuecesDataGrid.ItemsSource = jueces;
                BTnCargarExcel.Visibility = Visibility.Visible;
                DHInportExcel.IsOpen = false;

            }
        }

        private void BTnDelInportJudges_Click(object sender, RoutedEventArgs e)
        {
            BTnCargarExcel.Visibility = Visibility.Visible;
            DHInportExcel.IsOpen = false;
        }

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {

        }

        private void GridDJAssign_LostFocus(object sender, RoutedEventArgs e)
        {
            ScheduleDataGrid.Items.Refresh();


        }

        private void GridHome_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!DHEventsList.IsOpen)
            {
                JuecesDataGrid.Items.Refresh();
                InicializarJuecesD();

            }
        }

        private void GridSchedule_GotFocus(object sender, RoutedEventArgs e)
        {
            InicializarCME();

        }

        private void GridJudges_LostFocus(object sender, RoutedEventArgs e)
        {
            ScheduleDataGrid.Items.Refresh();
            InicializarJuecesD();

        }




        private void RelativesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {

                var column = e.Column as DataGridColumn;

                if (column != null && column.DisplayIndex > 0)
                {
                    int rowIndex = e.Row.GetIndex();
                    ComboBox el = e.EditingElement as ComboBox;



                    if (column.Header.ToString() == "Judge Name")
                    {
                        if (!string.IsNullOrEmpty(el.Text))
                        {
                            RelativesDataGrid.Focus();
                            RelativesDataGrid.CurrentCell = new DataGridCellInfo(JuecesDataGrid.Items[rowIndex], JuecesDataGrid.Columns[column.DisplayIndex - 1]);
                            RelativesDataGrid.BeginEdit();
                        }

                    }
                }

                // Habrá que actualizar estadísticas
            }

        }
        private void FinalCountriesDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {

                var column = e.Column as DataGridColumn;

                if (column != null && column.DisplayIndex > 0)
                {
                    int rowIndex = e.Row.GetIndex();
                    ComboBox el = e.EditingElement as ComboBox;



                    if (column.Header.ToString() == "Judge Name")
                    {
                        if (!string.IsNullOrEmpty(el.Text))
                        {
                            RelativesDataGrid.Focus();
                            RelativesDataGrid.CurrentCell = new DataGridCellInfo(JuecesDataGrid.Items[rowIndex], JuecesDataGrid.Columns[column.DisplayIndex - 1]);
                            RelativesDataGrid.BeginEdit();
                        }

                    }
                }

                // Habrá que actualizar estadísticas
            }

        }
        private void RelativesDataGrid_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void RelativesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Only act on Commit

            if (e.EditAction == DataGridEditAction.Commit)

            {

                // Juez juez = e.Row.DataContext as Juez;


            }

        }

        private void FinalCountriesDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Only act on Commit

            if (e.EditAction == DataGridEditAction.Commit)

            {

                // Juez juez = e.Row.DataContext as Juez;


            }

        }
        private void FinalCountriesDataGrid_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

        }




        private void NombreEvento_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Control tmp = sender as Control;
            tmp.FontSize = e.NewSize.Height / tmp.FontFamily.LineSpacing;
        }



        private void LimpiarDrawP1_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure ?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                limpiar_asginaciones_juecesP1();
            }

        }

        private void LimpiarDrawP2_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure ?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                limpiar_asginaciones_juecesP2();
            }

        }

        private void TimeLineDraw_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure you want to draw time, line and inquiry?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {


                // se eliminan asignaciones anteriores
                limpiar_asginaciones_juecesLTI();
                ObservableCollection<Juez> listajuecesdisponibles = new ObservableCollection<Juez>();
                //añadir jueces presentes
                for (int i = 0; i < jueces.juecespresentes().Count; i++)
                {
                    listajuecesdisponibles.Add(jueces.juecespresentessinwarning()[i]);
                }

                //quitar los jueces que tienen familiares en el panel 1 y 2
                foreach (Relative r in relativesP1)
                {
                    eliminardelistadejuecesNombre(r.Juez, listajuecesdisponibles);
                }
                foreach (Relative r in relativesP2)
                {
                    eliminardelistadejuecesNombre(r.Juez, listajuecesdisponibles);
                }
                // eliminar de la lista de jueces disponibles los jueces del panel superior
                eliminardelistadejuecesNombre(CBSJPresident.Text, listajuecesdisponibles);
                eliminardelistadejuecesNombre(CBSJD1.Text, listajuecesdisponibles);
                eliminardelistadejuecesNombre(CBSJD2.Text, listajuecesdisponibles);
                eliminardelistadejuecesNombre(CBSJE1.Text, listajuecesdisponibles);
                eliminardelistadejuecesNombre(CBSJE2.Text, listajuecesdisponibles);
                eliminardelistadejuecesNombre(CBSJA1.Text, listajuecesdisponibles);
                eliminardelistadejuecesNombre(CBSJA2.Text, listajuecesdisponibles);
                // eliminar de la lista de jueces disponibles los CPJ y DJ
                eliminardelistadejuecesTB(TBP1CPJ, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1D1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1D2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2CPJ, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2D1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2D2, listajuecesdisponibles);
                //eliminar de la lista los jueces de los paneles
                eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                //             CBp1QTjudges , CBLjudges,CBIjudges

                // Revisar el numero de jueces disponibles



                // Calcular jueces necesarios
                int totaljuecessolicitados = evento.Ljudges + evento.Ijudges;

                if (horario[indicehorario].CompetitionP2 == "QUALIFICATION")
                {
                    totaljuecessolicitados += evento.P2QTjudges;
                }
                else
                {
                    totaljuecessolicitados += evento.P2FTjudges;

                }

                if (horario[indicehorario].CompetitionP1 == "QUALIFICATION")
                {
                    totaljuecessolicitados += evento.P1QTjudges;
                }
                else
                {
                    totaljuecessolicitados += evento.P1FTjudges;

                }



                if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count())
                {
                    Panel2Warning.Text = "Not enough judges";
                    ImagewarningP2.Visibility = Visibility.Visible;

                }
                else
                {
                    if (horario[indicehorario].CompetitionP1 == "QUALIFICATION")
                    {
                        if (evento.P1QTjudges == 1)
                        {
                            TBP1T1.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                            eliminardelistadejuecesTB(TBP1T1, listajuecesdisponibles);
                        }

                    }
                    else
                    {
                        if (evento.P1FTjudges == 1)
                        {
                            TBP1T1.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                            eliminardelistadejuecesTB(TBP1T1, listajuecesdisponibles);
                        }
                    }


                    if (horario[indicehorario].CompetitionP2 == "QUALIFICATION")
                    {
                        if (evento.P2QTjudges == 1)
                        {
                            TBP2T1.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                            eliminardelistadejuecesTB(TBP2T1, listajuecesdisponibles);
                        }

                    }
                    else
                    {
                        if (evento.P2FTjudges == 1)
                        {
                            TBP2T1.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                            eliminardelistadejuecesTB(TBP2T1, listajuecesdisponibles);
                        }
                    }


                    if (evento.Ljudges == 1)
                    {
                        TBL1.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                        eliminardelistadejuecesTB(TBL1, listajuecesdisponibles);
                    }
                    else
                    {
                        TBL1.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                        eliminardelistadejuecesTB(TBL1, listajuecesdisponibles);

                        TBL2.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                        eliminardelistadejuecesTB(TBL2, listajuecesdisponibles);
                    }
                }

                if (evento.Ijudges == 1)
                {
                    TBINQ.Text = juezlibredelamayorcategoria(listajuecesdisponibles);
                }


                // Guardar el panel sorteado

                guardarjuecesTLI(indicehorario);
            }
        }




        private void LimpiarDraw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LimpiarDrawTLI_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                limpiar_asginaciones_juecesLTI();
                guardarjuecesTLI(indicehorario);
            }

        }


        private void ImprimirDraw_Click(object sender, RoutedEventArgs e)
        {


            // Visual v = sender as Visual; 
            Visual v = print as Visual; // the object (it is a DataGrid) that you want to print out, not a window 
            PrintDialog prtDlg = new PrintDialog();
            if (prtDlg.ShowDialog() == true)
            {
                // because 96 pixels in an inch for WPF window 
                double marginLeft = 0; // left margin is 0.75 inches 
                double marginTop = 0; // top margin is 0.75 inches 
                double marginRight = 0; // right margin is 0.75 inches 
                double marginBottom = 0; // bottom margin is 0.75 inches 

                // the following steps do not works for a WPF window 
                FrameworkElement win = v as FrameworkElement;
                Transform oldLayoutTransform = win.LayoutTransform;
                Size oldSize = new Size(win.ActualWidth, win.ActualHeight);

                System.Printing.PrintCapabilities pCapability = prtDlg.PrintQueue.GetPrintCapabilities(prtDlg.PrintTicket);

                // calculate print area that you want 
                double printWidth = (pCapability.PageImageableArea.ExtentWidth - pCapability.PageImageableArea.OriginWidth)
                     - (marginLeft + marginRight);
                double printHeight = (pCapability.PageImageableArea.ExtentHeight - pCapability.PageImageableArea.OriginHeight)
                 - (marginTop + marginBottom);

                // calculate the scale 
                double scale = Math.Min(printWidth / oldSize.Width, printHeight / oldSize.Height);
                if (scale > 1.0)
                {
                    // keep the original size and layout if printable area is greater than the object being printed 
                    scale = 1.0;
                }

                // store the original layouttransform 
                win.LayoutTransform = new ScaleTransform(scale, scale);

                //  new Size of the visual
                Size newSize = new Size(oldSize.Width * scale, oldSize.Height * scale);
                win.Measure(newSize);

                //centralize print area 
                // double xStartPrint = marginLeft;// + (printWidth - newSize.Width) / 2.0;
                // double yStartPrint = marginTop;// + (printHeight - newSize.Height) / 2.0;
                // win.Arrange(new Rect(new Point(xStartPrint, yStartPrint), newSize));

                // print out the visual
                prtDlg.PrintVisual(win as Visual, "PrintTest");

                // resotre the original layouttransform and size on screen 
                // win.LayoutTransform = oldLayoutTransform;
                // win.Measure(oldSize);
                // win.Arrange(new Rect(new Point(0, 0), oldSize));
            }




        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            /*              
             // Descargar_Evento_actual();
              lista_eventos_guardados = null;
              //Cargar lita de eventos y seleccionar el siguiente
              try
              {
                  lista_eventos_guardados = new Lista_Eventos_Guardados(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\listaeventos.json");
              }
              catch (Exception ex)
              {
                  bool? Result = new MessageBoxCustom("Linea 1490. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
              }

              lista_eventos_guardados_trabajo = new Lista_Eventos_Guardados();
              lista_eventos_guardados_trabajo.CollectionChanged += ListaEventos_CollectionChanged;

              foreach (Evento_De_Trabajo j in lista_eventos_guardados)
              {
                  lista_eventos_guardados_trabajo.Add(j);
              }



              DHEventsList.IsOpen = true;

              ICEvents.ItemsSource = lista_eventos_guardados_trabajo.OrderByDescending(x=>DateTime.Parse(x.SaveDate));
            */
            /*
            numero_evento_trabajo = +1;

            Inicialiar_Evento_de_lista(numero_evento_trabajo);

            for (int i = lista_eventos_guardados.Count - 1; i >= 0; i--)
            {

                lista_eventos_guardados.RemoveAt(i);
            }
            */

        }

        private void BTnLoadEvent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DHEventsList.IsOpen = false;
                //Hay que localizar el evento de trabajo con IsSelected a true
                try
                {
                    lista_eventos_guardados_trabajo.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\listaeventos.json");
                }
                catch (Exception ex)
                {
                    bool? Result = new MessageBoxCustom("Linea 1533. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                }
                foreach (Evento_De_Trabajo j in lista_eventos_guardados_trabajo)
                {
                    if (j.IsSelected)
                    {

                        Descargar_Evento_actual();
                        Inicialiar_Evento_de_lista(lista_eventos_guardados_trabajo.IndexOf(j));

                        for (int i = lista_eventos_guardados_trabajo.Count - 1; i >= 0; i--)
                        {

                            lista_eventos_guardados.RemoveAt(i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom("Linea 1552. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
        }

        private void TBNumerosJueces_TextChanged(object sender, TextChangedEventArgs e)

        {
            TextBox TB = new TextBox();
            TB = (TextBox)sender;
         //   ActualizarJuecesTextBox();
            ActualizarEtiquetasNombre();
            ActualizarEtiquetasPais();
            ActualizarBanderaPais();
        }


        private void ActualizarJuecesTextBox()
        {
            if ((string.IsNullOrEmpty(TBP1E1.Text) ? -1 : int.Parse(TBP1E1.Text)) > -1)
            {
                if (horario[indicehorario].E1JudgeP1 > 0)
                {
                    if (horario[indicehorario].CompetitionP1 == "QUALIFICATION")
                    {
                        jueces.Where(x => x.ID == horario[indicehorario].E1JudgeP1).FirstOrDefault().DecrementarparticipacionE();
                    }
                    else
                    {
                        jueces.Where(x => x.ID == horario[indicehorario].E1JudgeP1).FirstOrDefault().DecrementarparticipacionFE();

                    }
                }

                    horario[indicehorario].E1JudgeP1 = (string.IsNullOrEmpty(TBP1E1.Text) ? 0 : int.Parse(TBP1E1.Text));
                    if (horario[indicehorario].E1JudgeP1 > 0)
                    {
                        if (horario[indicehorario].CompetitionP1 == "QUALIFICATION")
                        {
                            jueces.Where(x => x.ID == horario[indicehorario].E1JudgeP1).FirstOrDefault().IncrementarparticipacionE();
                        }
                        else
                        {
                            jueces.Where(x => x.ID == horario[indicehorario].E1JudgeP1).FirstOrDefault().IncrementarparticipacionFE();

                        }
                    }
             
            }
            EtiquetaNombre(TBP1E1, NameE1P1);
            EtiquetaNombre(TBP1E2, NameE2P1);
            EtiquetaNombre(TBP1E3, NameE3P1);
            EtiquetaNombre(TBP1E4, NameE4P1);
            EtiquetaNombre(TBP1E5, NameE5P1);
            EtiquetaNombre(TBP1E6, NameE6P1);
            EtiquetaNombre(TBP1A1, NameA1P1);
            EtiquetaNombre(TBP1A2, NameA2P1);
            EtiquetaNombre(TBP1A3, NameA3P1);
            EtiquetaNombre(TBP1A4, NameA4P1);
            EtiquetaNombre(TBP1A5, NameA5P1);
            EtiquetaNombre(TBP1A6, NameA6P1);
            EtiquetaNombre(TBP2CPJ, NameCPJP2);
            EtiquetaNombre(TBP2D1, NameD1P2);
            EtiquetaNombre(TBP2D2, NameD2P2);
            EtiquetaNombre(TBP2E1, NameE1P2);
            EtiquetaNombre(TBP2E2, NameE2P2);
            EtiquetaNombre(TBP2E3, NameE3P2);
            EtiquetaNombre(TBP2E4, NameE4P2);
            EtiquetaNombre(TBP2E5, NameE5P2);
            EtiquetaNombre(TBP2E6, NameE6P2);
            EtiquetaNombre(TBP2A1, NameA1P2);
            EtiquetaNombre(TBP2A2, NameA2P2);
            EtiquetaNombre(TBP2A3, NameA3P2);
            EtiquetaNombre(TBP2A4, NameA4P2);
            EtiquetaNombre(TBP2A5, NameA5P2);
            EtiquetaNombre(TBP2A6, NameA6P2);
            EtiquetaNombre(TBP1T1, NameTJ1);
            EtiquetaNombre(TBP2T1, NameTJ2);
            EtiquetaNombre(TBL1, NameL1);
            EtiquetaNombre(TBL2, NameL2);
            EtiquetaNombre(TBP1RE, NameREP1);
            EtiquetaNombre(TBP1RA, NameRAP1);
            EtiquetaNombre(TBP2RE, NameREP2);
            EtiquetaNombre(TBP2RA, NameRAP2);
            EtiquetaNombre(TBINQ, NameINQ);

        }



        private void ActualizarEtiquetasNombre()
        {
            EtiquetaNombre(TBP1CPJ, NameCPJP1);
            EtiquetaNombre(TBP1D1, NameD1P1);
            EtiquetaNombre(TBP1D2, NameD2P1);
            EtiquetaNombre(TBP1E1, NameE1P1);
            EtiquetaNombre(TBP1E2, NameE2P1);
            EtiquetaNombre(TBP1E3, NameE3P1);
            EtiquetaNombre(TBP1E4, NameE4P1);
            EtiquetaNombre(TBP1E5, NameE5P1);
            EtiquetaNombre(TBP1E6, NameE6P1);
            EtiquetaNombre(TBP1A1, NameA1P1);
            EtiquetaNombre(TBP1A2, NameA2P1);
            EtiquetaNombre(TBP1A3, NameA3P1);
            EtiquetaNombre(TBP1A4, NameA4P1);
            EtiquetaNombre(TBP1A5, NameA5P1);
            EtiquetaNombre(TBP1A6, NameA6P1);
            EtiquetaNombre(TBP2CPJ, NameCPJP2);
            EtiquetaNombre(TBP2D1, NameD1P2);
            EtiquetaNombre(TBP2D2, NameD2P2);
            EtiquetaNombre(TBP2E1, NameE1P2);
            EtiquetaNombre(TBP2E2, NameE2P2);
            EtiquetaNombre(TBP2E3, NameE3P2);
            EtiquetaNombre(TBP2E4, NameE4P2);
            EtiquetaNombre(TBP2E5, NameE5P2);
            EtiquetaNombre(TBP2E6, NameE6P2);
            EtiquetaNombre(TBP2A1, NameA1P2);
            EtiquetaNombre(TBP2A2, NameA2P2);
            EtiquetaNombre(TBP2A3, NameA3P2);
            EtiquetaNombre(TBP2A4, NameA4P2);
            EtiquetaNombre(TBP2A5, NameA5P2);
            EtiquetaNombre(TBP2A6, NameA6P2);
            EtiquetaNombre(TBP1T1, NameTJ1);
            EtiquetaNombre(TBP2T1, NameTJ2);
            EtiquetaNombre(TBL1, NameL1);
            EtiquetaNombre(TBL2, NameL2);
            EtiquetaNombre(TBP1RE, NameREP1);
            EtiquetaNombre(TBP1RA, NameRAP1);
            EtiquetaNombre(TBP2RE, NameREP2);
            EtiquetaNombre(TBP2RA, NameRAP2);
            EtiquetaNombre(TBINQ, NameINQ);

        }
        private void ActualizarEtiquetasPais()
        {
            try
            {
                EtiquetaPais(TBP1CPJ, CtryCPJP1);
                EtiquetaPais(TBP1D1, CtryD1P1);
                EtiquetaPais(TBP1D2, CtryD2P1);
                EtiquetaPais(TBP1E1, CtryE1P1);
                EtiquetaPais(TBP1E2, CtryE2P1);
                EtiquetaPais(TBP1E3, CtryE3P1);
                EtiquetaPais(TBP1E4, CtryE4P1);
                EtiquetaPais(TBP1E5, CtryE5P1);
                EtiquetaPais(TBP1E6, CtryE6P1);
                EtiquetaPais(TBP1A1, CtryA1P1);
                EtiquetaPais(TBP1A2, CtryA2P1);
                EtiquetaPais(TBP1A3, CtryA3P1);
                EtiquetaPais(TBP1A4, CtryA4P1);
                EtiquetaPais(TBP1A5, CtryA5P1);
                EtiquetaPais(TBP1A6, CtryA6P1);
                EtiquetaPais(TBP2CPJ, CtryCPJP2);
                EtiquetaPais(TBP2D1, CtryD1P2);
                EtiquetaPais(TBP2D2, CtryD2P2);
                EtiquetaPais(TBP2E1, CtryE1P2);
                EtiquetaPais(TBP2E2, CtryE2P2);
                EtiquetaPais(TBP2E3, CtryE3P2);
                EtiquetaPais(TBP2E4, CtryE4P2);
                EtiquetaPais(TBP2E5, CtryE5P2);
                EtiquetaPais(TBP2E6, CtryE6P2);
                EtiquetaPais(TBP2A1, CtryA1P2);
                EtiquetaPais(TBP2A2, CtryA2P2);
                EtiquetaPais(TBP2A3, CtryA3P2);
                EtiquetaPais(TBP2A4, CtryA4P2);
                EtiquetaPais(TBP2A5, CtryA5P2);
                EtiquetaPais(TBP2A6, CtryA6P2);
                EtiquetaPais(TBP1T1, CtryTJ1);
                EtiquetaPais(TBP2T1, CtryTJ2);
                EtiquetaPais(TBL1, CtryL1);
                EtiquetaPais(TBL2, CtryL2);
                EtiquetaPais(TBP1RE, CtryREP1);
                EtiquetaPais(TBP1RA, CtryRAP1);
                EtiquetaPais(TBP2RE, CtryREP2);
                EtiquetaPais(TBP2RA, CtryRAP2);
                EtiquetaPais(TBINQ, CtryINQ);

            }
            catch (Exception ex)
            {
                MessageBox.Show("A exception just occurred with ActualizarEtiquetasPais process: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }
        private void ActualizarBanderaPais()
        {
            BanderaPais(TBP1CPJ, FlagCPJP1);
            BanderaPais(TBP1D1, FlagD1P1);
            BanderaPais(TBP1D2, FlagD2P1);
            BanderaPais(TBP1E1, FlagE1P1);
            BanderaPais(TBP1E2, FlagE2P1);
            BanderaPais(TBP1E3, FlagE3P1);
            BanderaPais(TBP1E4, FlagE4P1);
            BanderaPais(TBP1E5, FlagE5P1);
            BanderaPais(TBP1E6, FlagE6P1);
            BanderaPais(TBP1A1, FlagA1P1);
            BanderaPais(TBP1A2, FlagA2P1);
            BanderaPais(TBP1A3, FlagA3P1);
            BanderaPais(TBP1A4, FlagA4P1);
            BanderaPais(TBP1A5, FlagA5P1);
            BanderaPais(TBP1A6, FlagA6P1);
            BanderaPais(TBP2CPJ, FlagCPJP2);
            BanderaPais(TBP2D1, FlagD1P2);
            BanderaPais(TBP2D2, FlagD2P2);
            BanderaPais(TBP2E1, FlagE1P2);
            BanderaPais(TBP2E2, FlagE2P2);
            BanderaPais(TBP2E3, FlagE3P2);
            BanderaPais(TBP2E4, FlagE4P2);
            BanderaPais(TBP2E5, FlagE5P2);
            BanderaPais(TBP2E6, FlagE6P2);
            BanderaPais(TBP2A1, FlagA1P2);
            BanderaPais(TBP2A2, FlagA2P2);
            BanderaPais(TBP2A3, FlagA3P2);
            BanderaPais(TBP2A4, FlagA4P2);
            BanderaPais(TBP2A5, FlagA5P2);
            BanderaPais(TBP2A6, FlagA6P2);
            BanderaPais(TBP1T1, FlagTJ1);
            BanderaPais(TBP2T1, FlagTJ2);
            BanderaPais(TBL1, FlagL1);
            BanderaPais(TBL2, FlagL2);
            BanderaPais(TBP1RE, FlagREP1);
            BanderaPais(TBP1RA, FlagRAP1);
            BanderaPais(TBP2RE, FlagREP2);
            BanderaPais(TBP2RA, FlagRAP2);
            BanderaPais(TBINQ, FlagINQ);
        }
        private void EtiquetaNombre(TextBox TB, Label LB)
        {
            int i = 0;
            if (int.TryParse(TB.Text, out i))
            {
                if (jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
                {
                    LB.Content = jueces.Where(x => x.ID.ToString() == TB.Text).First().JudgeName.ToString();
                }
                else
                {
                    LB.Content = "--";
                }
            }
            else
            {
                LB.Content = "--";
            }

        }
        private void EtiquetaPais(TextBox TB, Label LB)
        {
            try
            {

                int i = 0;
                if (int.TryParse(TB.Text, out i))
                {
                    if (jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
                    {
                        LB.Content = jueces.Where(x => x.ID.ToString() == TB.Text).First().Country.ToString();
                    }
                    else
                    {
                        LB.Content = "--";
                    }
                }
                else
                {
                    LB.Content = "--";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("A exception just occurred with EtiquetaPais process: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }
        private void BanderaPais(TextBox TB, Image IM)
        {
            int i = 0;
            if (int.TryParse(TB.Text, out i))
            {
                if (jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0 && i > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
                {
                    IM.Source = new BitmapImage(new Uri(jueces.Where(x => x.ID.ToString() == TB.Text).First().CountryFlag, UriKind.Relative));
                    IM.Visibility = Visibility.Visible;

                }
                else
                {
                    IM.Visibility = Visibility.Collapsed;

                }
            }
            else
            {
                IM.Visibility = Visibility.Collapsed;
            }

        }

        private void limpiar_asginaciones_juecesLTI()

        {
            TBP2T1.Text = "0";
            TBL2.Text = "0";
            TBP1T1.Text = "0";
            TBL1.Text = "0";
            TBINQ.Text = "0";

            FlagTJ1.Visibility = Visibility.Collapsed;
            FlagTJ2.Visibility = Visibility.Collapsed;
            FlagL1.Visibility = Visibility.Collapsed;
            FlagL2.Visibility = Visibility.Collapsed;

            FlagINQ.Visibility = Visibility.Collapsed;

        }

        private void limpiar_asginaciones_juecesP2()
        {
            // En principio se limita a poner a 0 el textbox de cada juez del panel. Las banderas simplemente se ocultan haciendo que no sean visibles
            // Al limpiar habría que hacer el proceso de borrado de total de participaciones de ese juez antes de eliminarlo.
            if (horario[indicehorario].CompetitionP2 == "QUALIFICATION")
            {
                decrementarparticipacionEjuez(TBP2E1);
                decrementarparticipacionEjuez(TBP2E2);
                decrementarparticipacionEjuez(TBP2E3);
                decrementarparticipacionEjuez(TBP2E4);
                decrementarparticipacionEjuez(TBP2E5);
                decrementarparticipacionEjuez(TBP2E6);
                decrementarparticipacionAjuez(TBP2A1);
                decrementarparticipacionAjuez(TBP2A2);
                decrementarparticipacionAjuez(TBP2A3);
                decrementarparticipacionAjuez(TBP2A4);
                decrementarparticipacionAjuez(TBP2A5);
                decrementarparticipacionAjuez(TBP2A6);
            }
            else
            {
                decrementarparticipacionFEjuez(TBP2E1);
                decrementarparticipacionFEjuez(TBP2E2);
                decrementarparticipacionFEjuez(TBP2E3);
                decrementarparticipacionFEjuez(TBP2E4);
                decrementarparticipacionFEjuez(TBP2E5);
                decrementarparticipacionFEjuez(TBP2E6);
                decrementarparticipacionFAjuez(TBP2A1);
                decrementarparticipacionFAjuez(TBP2A2);
                decrementarparticipacionFAjuez(TBP2A3);
                decrementarparticipacionFAjuez(TBP2A4);
                decrementarparticipacionFAjuez(TBP2A5);
                decrementarparticipacionFAjuez(TBP2A6);

            }

            TBP2RE.Text = "0";

            TBP2RA.Text = "0";


            FlagE1P2.Visibility = Visibility.Collapsed;
            FlagE2P2.Visibility = Visibility.Collapsed;
            FlagE3P2.Visibility = Visibility.Collapsed;
            FlagE4P2.Visibility = Visibility.Collapsed;
            FlagE5P2.Visibility = Visibility.Collapsed;
            FlagE6P2.Visibility = Visibility.Collapsed;
            FlagA1P2.Visibility = Visibility.Collapsed;
            FlagA2P2.Visibility = Visibility.Collapsed;
            FlagA3P2.Visibility = Visibility.Collapsed;
            FlagA4P2.Visibility = Visibility.Collapsed;
            FlagA5P2.Visibility = Visibility.Collapsed;
            FlagA6P2.Visibility = Visibility.Collapsed;

            FlagREP2.Visibility = Visibility.Collapsed;
            FlagRAP2.Visibility = Visibility.Collapsed;

            Panel2Cat1Enumjudges.Content = "0";
            Panel2Cat2Enumjudges.Content = "0";
            Panel2Cat3Enumjudges.Content = "0";
            Panel2Cat4Enumjudges.Content = "0";
            Panel2Cat1Anumjudges.Content = "0";
            Panel2Cat2Anumjudges.Content = "0";
            Panel2Cat3Anumjudges.Content = "0";
            Panel2Cat4Anumjudges.Content = "0";
            Panel2EAvgjudges.Content = "0";
            Panel2AAvgjudges.Content = "0";

            Panel2Warning.Text = "";
            ImagewarningP2.Visibility = Visibility.Collapsed;


            JuecesDataGrid.Items.Refresh();

        }

        private void limpiar_asginaciones_juecesP1()
        {
            // En principio se limita a poner a 0 el textbox de cada juez del panel. Las banderas simplemente se ocultan haciendo que no sean visibles
            // Al limpiar habría que hacer el proceso de borrado de total de participaciones de ese juez antes de eliminarlo.
            if (horario[indicehorario].CompetitionP1 == "QUALIFICATION")
            {
                decrementarparticipacionEjuez(TBP1E1);
                decrementarparticipacionEjuez(TBP1E2);
                decrementarparticipacionEjuez(TBP1E3);
                decrementarparticipacionEjuez(TBP1E4);
                decrementarparticipacionEjuez(TBP1E5);
                decrementarparticipacionEjuez(TBP1E6);
                decrementarparticipacionAjuez(TBP1A1);
                decrementarparticipacionAjuez(TBP1A2);
                decrementarparticipacionAjuez(TBP1A3);
                decrementarparticipacionAjuez(TBP1A4);
                decrementarparticipacionAjuez(TBP1A5);
                decrementarparticipacionAjuez(TBP1A6);
            }
            else
            {
                decrementarparticipacionFEjuez(TBP1E1);
                decrementarparticipacionFEjuez(TBP1E2);
                decrementarparticipacionFEjuez(TBP1E3);
                decrementarparticipacionFEjuez(TBP1E4);
                decrementarparticipacionFEjuez(TBP1E5);
                decrementarparticipacionFEjuez(TBP1E6);
                decrementarparticipacionFAjuez(TBP1A1);
                decrementarparticipacionFAjuez(TBP1A2);
                decrementarparticipacionFAjuez(TBP1A3);
                decrementarparticipacionFAjuez(TBP1A4);
                decrementarparticipacionFAjuez(TBP1A5);
                decrementarparticipacionFAjuez(TBP1A6);
            }

            TBP1RE.Text = "0";

            TBP1RA.Text = "0";


            FlagE1P1.Visibility = Visibility.Collapsed;
            FlagE2P1.Visibility = Visibility.Collapsed;
            FlagE3P1.Visibility = Visibility.Collapsed;
            FlagE4P1.Visibility = Visibility.Collapsed;
            FlagE5P1.Visibility = Visibility.Collapsed;
            FlagE6P1.Visibility = Visibility.Collapsed;
            FlagA1P1.Visibility = Visibility.Collapsed;
            FlagA2P1.Visibility = Visibility.Collapsed;
            FlagA3P1.Visibility = Visibility.Collapsed;
            FlagA4P1.Visibility = Visibility.Collapsed;
            FlagA5P1.Visibility = Visibility.Collapsed;
            FlagA6P1.Visibility = Visibility.Collapsed;

            FlagREP1.Visibility = Visibility.Collapsed;
            FlagRAP1.Visibility = Visibility.Collapsed;

            Panel1Cat1Enumjudges.Content = "0";
            Panel1Cat2Enumjudges.Content = "0";
            Panel1Cat3Enumjudges.Content = "0";
            Panel1Cat4Enumjudges.Content = "0";
            Panel1Cat1Anumjudges.Content = "0";
            Panel1Cat2Anumjudges.Content = "0";
            Panel1Cat3Anumjudges.Content = "0";
            Panel1Cat4Anumjudges.Content = "0";
            Panel1EAvgjudges.Content = "0";
            Panel1AAvgjudges.Content = "0";

            Panel1Warning.Text = "";
            ImagewarningP1.Visibility = Visibility.Collapsed;


            JuecesDataGrid.Items.Refresh();

        }

        private void incrementarparticipacionAjuez(TextBox TB)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().IncrementarparticipacionA();
            }

        }

        private void incrementarparticipacionFAjuez(TextBox TB)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().IncrementarparticipacionFA();
            }

        }

        private void incrementarparticipacionEjuez(TextBox TB)
        {


            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().IncrementarparticipacionE();
            }

        }
        private void incrementarparticipacionFEjuez(TextBox TB)
        {


            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().IncrementarparticipacionFE();
            }

        }

        private void decrementarparticipacionAjuez(TextBox TB)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().DecrementarparticipacionA();
                TB.Text = "0";
            }
        }
        private void decrementarparticipacionFAjuez(TextBox TB)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().DecrementarparticipacionFA();
                TB.Text = "0";
            }
        }

        private void decrementarparticipacionEjuez(TextBox TB)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().DecrementarparticipacionE();
                TB.Text = "0";
            }
        }
        private void decrementarparticipacionFEjuez(TextBox TB)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0 && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().DecrementarparticipacionFE();
                TB.Text = "0";
            }
        }
        private void actualizarresumenpaneles(int panel)
        {
            if (panel == 1)
            {
                actualizarpanel(TBP1E1, "E", 1);
                actualizarpanel(TBP1E2, "E", 1);
                actualizarpanel(TBP1E3, "E", 1);
                actualizarpanel(TBP1E4, "E", 1);
                actualizarpanel(TBP1E5, "E", 1);
                actualizarpanel(TBP1E6, "E", 1);
                actualizarpanel(TBP1A1, "A", 1);
                actualizarpanel(TBP1A2, "A", 1);
                actualizarpanel(TBP1A3, "A", 1);
                actualizarpanel(TBP1A4, "A", 1);
                actualizarpanel(TBP1A5, "A", 1);
                actualizarpanel(TBP1A6, "A", 1);
            }
            else
            {
                actualizarpanel(TBP2E1, "E", 2);
                actualizarpanel(TBP2E2, "E", 2);
                actualizarpanel(TBP2E3, "E", 2);
                actualizarpanel(TBP2E4, "E", 2);
                actualizarpanel(TBP2E5, "E", 2);
                actualizarpanel(TBP2E6, "E", 2);
                actualizarpanel(TBP2A1, "A", 2);
                actualizarpanel(TBP2A2, "A", 2);
                actualizarpanel(TBP2A3, "A", 2);
                actualizarpanel(TBP2A4, "A", 2);
                actualizarpanel(TBP2A5, "A", 2);
                actualizarpanel(TBP2A6, "A", 2);
            }
        }

        private void actualizarpanel(TextBox TB, string rol, int panel)
        {
            double total1;
            double total2;
            double resultado;
            if (!string.IsNullOrEmpty(TB.Text) && !(TB.Text == "0") && jueces.Where(x => x.ID.ToString() == TB.Text).Count() > 0)
            {
                if (panel == 1)
                {
                    if (rol == "E")
                    {
                        switch (jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().Category)
                        {
                            case 1:
                                Panel1Cat1Enumjudges.Content = (int.Parse(Panel1Cat1Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 2:
                                Panel1Cat2Enumjudges.Content = (int.Parse(Panel1Cat2Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 3:
                                Panel1Cat3Enumjudges.Content = (int.Parse(Panel1Cat3Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 4:
                                Panel1Cat4Enumjudges.Content = (int.Parse(Panel1Cat4Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                        }
                        total1 = (double)(int.Parse(Panel1Cat1Enumjudges.Content.ToString()) + 2 * int.Parse(Panel1Cat2Enumjudges.Content.ToString()) + 3 * int.Parse(Panel1Cat3Enumjudges.Content.ToString()) + 4 * int.Parse(Panel1Cat4Enumjudges.Content.ToString()));
                        total2 = (double)(int.Parse(Panel1Cat1Enumjudges.Content.ToString()) + int.Parse(Panel1Cat2Enumjudges.Content.ToString()) + int.Parse(Panel1Cat3Enumjudges.Content.ToString()) + int.Parse(Panel1Cat4Enumjudges.Content.ToString()));
                        resultado = total1 / total2;

                        Panel1EAvgjudges.Content = String.Format("{0:0.00}", resultado);
                    }
                    else
                    {
                        switch (jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().Category)
                        {
                            case 1:
                                Panel1Cat1Anumjudges.Content = (int.Parse(Panel1Cat1Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 2:
                                Panel1Cat2Anumjudges.Content = (int.Parse(Panel1Cat2Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 3:
                                Panel1Cat3Anumjudges.Content = (int.Parse(Panel1Cat3Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 4:
                                Panel1Cat4Anumjudges.Content = (int.Parse(Panel1Cat4Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                        }
                        total1 = (double)(int.Parse(Panel1Cat1Anumjudges.Content.ToString()) + 2 * int.Parse(Panel1Cat2Anumjudges.Content.ToString()) + 3 * int.Parse(Panel1Cat3Anumjudges.Content.ToString()) + 4 * int.Parse(Panel1Cat4Anumjudges.Content.ToString()));
                        total2 = (double)(int.Parse(Panel1Cat1Anumjudges.Content.ToString()) + int.Parse(Panel1Cat2Anumjudges.Content.ToString()) + int.Parse(Panel1Cat3Anumjudges.Content.ToString()) + int.Parse(Panel1Cat4Anumjudges.Content.ToString()));
                        resultado = total1 / total2;

                        Panel1AAvgjudges.Content = String.Format("{0:0.00}", resultado);
                    }
                }
                else
                {
                    if (rol == "E")
                    {
                        switch (jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().Category)
                        {
                            case 1:
                                Panel2Cat1Enumjudges.Content = (int.Parse(Panel2Cat1Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 2:
                                Panel2Cat2Enumjudges.Content = (int.Parse(Panel2Cat2Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 3:
                                Panel2Cat3Enumjudges.Content = (int.Parse(Panel2Cat3Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 4:
                                Panel2Cat4Enumjudges.Content = (int.Parse(Panel2Cat4Enumjudges.Content.ToString()) + 1).ToString();
                                break;
                        }
                        total1 = (double)(int.Parse(Panel2Cat1Enumjudges.Content.ToString()) + 2 * int.Parse(Panel2Cat2Enumjudges.Content.ToString()) + 3 * int.Parse(Panel2Cat3Enumjudges.Content.ToString()) + 4 * int.Parse(Panel2Cat4Enumjudges.Content.ToString()));
                        total2 = (double)(int.Parse(Panel2Cat1Enumjudges.Content.ToString()) + int.Parse(Panel2Cat2Enumjudges.Content.ToString()) + int.Parse(Panel2Cat3Enumjudges.Content.ToString()) + int.Parse(Panel2Cat4Enumjudges.Content.ToString()));
                        resultado = total1 / total2;

                        Panel2EAvgjudges.Content = String.Format("{0:0.00}", resultado);
                    }
                    else
                    {
                        switch (jueces.Where(x => x.ID.ToString() == TB.Text).FirstOrDefault().Category)
                        {
                            case 1:
                                Panel2Cat1Anumjudges.Content = (int.Parse(Panel2Cat1Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 2:
                                Panel2Cat2Anumjudges.Content = (int.Parse(Panel2Cat2Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 3:
                                Panel2Cat3Anumjudges.Content = (int.Parse(Panel2Cat3Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                            case 4:
                                Panel2Cat4Anumjudges.Content = (int.Parse(Panel2Cat4Anumjudges.Content.ToString()) + 1).ToString();
                                break;
                        }
                        total1 = (double)(int.Parse(Panel2Cat1Anumjudges.Content.ToString()) + 2 * int.Parse(Panel2Cat2Anumjudges.Content.ToString()) + 3 * int.Parse(Panel2Cat3Anumjudges.Content.ToString()) + 4 * int.Parse(Panel2Cat4Anumjudges.Content.ToString()));
                        total2 = (double)(int.Parse(Panel2Cat1Anumjudges.Content.ToString()) + int.Parse(Panel2Cat2Anumjudges.Content.ToString()) + int.Parse(Panel2Cat3Anumjudges.Content.ToString()) + int.Parse(Panel2Cat4Anumjudges.Content.ToString()));
                        resultado = total1 / total2;

                        Panel2AAvgjudges.Content = String.Format("{0:0.00}", resultado);
                    }


                }
            }

        }

        private string juezlibredelamenorcategoria(ObservableCollection<Juez> lj)
        {
            ObservableCollection<Juez> jcs = new ObservableCollection<Juez>();

            //hacer un array de numeros aleatorios no repetidos para que, en caso de jueces de cat4 no sean siempre los mismos en la primera rotacion
            Thread.Sleep(20);
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int[] iarr = new int[lj.Count];

            int r, temp;
            r = 1;
            for (int i = 0; i < lj.Count; i++)
            {
                iarr[i] = i;
            }
            for (int i = lj.Count - 1; i > -1; i--)
            {
                r = rnd.Next(1, lj.Count);
                temp = iarr[r];
                iarr[r] = iarr[i];
                iarr[i] = temp;
            }

            //añadir los jueces a la lista, pero de manera aleatoria

            for (int i = 0; i < lj.Count; i++)
            {
                jcs.Add(lj[iarr[i]]);
            }
            if (jcs.Count() > 0)
            {
                return jcs.Where(x => x.Category == lj.Min(j => j.Category)).First().ID.ToString();

            }
            else
            {
                return "0";
            }
        }


        private string juezlibredelamayorcategoria(ObservableCollection<Juez> lj)
        {
            ObservableCollection<Juez> jcs = new ObservableCollection<Juez>();

            //hacer un array de numeros aleatorios no repetidos para que, en caso de jueces de cat4 no sean siempre los mismos en la primera rotacion
            Thread.Sleep(20);
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int[] iarr = new int[lj.Count];

            int r, temp;
            r = 1;
            for (int i = 0; i < lj.Count; i++)
            {
                iarr[i] = i;
            }
            for (int i = lj.Count - 1; i > -1; i--)
            {
                r = rnd.Next(1, lj.Count);
                temp = iarr[r];
                iarr[r] = iarr[i];
                iarr[i] = temp;
            }

            //añadir los jueces a la lista, pero de manera aleatoria

            for (int i = 0; i < lj.Count; i++)
            {
                jcs.Add(lj[iarr[i]]);
            }


            if (jcs.Count() > 0)
            {
                return jcs.Where(x => x.Category == lj.Max(j => j.Category)).First().ID.ToString();

            }
            else
            {
                return "0";
            }

        }

        private string buscarjuezmenorcategoriaEA(ObservableCollection<Juez> lj, string rol, int panel, string CBpr, int maximocat4, int numjuez)
        {
            // Llenar la colección con los jueces con menor categoria y del pais adecuado, quitando los de cat4 que no correspondan
            ObservableCollection<Juez> jcs = new ObservableCollection<Juez>();

            //hacer un array de numeros aleatorios no repetidos para que, en caso de jueces de cat4 no sean siempre los mismos en la primera rotacion
            Thread.Sleep(20);
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int[] iarr = new int[lj.Count];

            int r, temp;
            r = 1;
            for (int i = 0; i < lj.Count; i++)
            {
                iarr[i] = i;
            }
            for (int i = lj.Count - 1; i > -1; i--)
            {
                r = rnd.Next(1, lj.Count);
                temp = iarr[r];
                iarr[r] = iarr[i];
                iarr[i] = temp;
            }

            // acumulador de numero de jueces cat4 

            int acumcat4 = 0;
            int minCat = lj.Min(x => x.Category);
            int maxCat = lj.Max(x => x.Category);

            int catbuscada = minCat;

            bool encontrado = false;

            if (rol == "E")
            {
                while (!encontrado && catbuscada < maxCat + 1)
                {
                    for (int i = 0; i < lj.Count; i++)
                    {
                        if (lj[iarr[i]].Category == catbuscada && PaisCorrectoPanelORol(lj[iarr[i]], "E", panel, CBpr))
                        {
                            if (lj[iarr[i]].Category == 4)
                            {
                                acumcat4++;
                                if (acumcat4 < maximocat4 + 1)
                                {
                                    jcs.Add(lj[iarr[i]]);
                                    encontrado = true;
                                }
                            }
                            else
                            {
                                jcs.Add(lj[iarr[i]]);
                                encontrado = true;
                            }

                        }
                    }
                    if (!encontrado) // si no se ha encontrado se sube la participación buscada
                    {
                        catbuscada++;
                    }

                }

            }
            else
            {
                while (!encontrado && catbuscada < maxCat + 1)
                {
                    for (int i = 0; i < lj.Count; i++)
                    {
                        if (lj[iarr[i]].Category == catbuscada && PaisCorrectoPanelORol(lj[iarr[i]], "A", panel, CBpr))
                        {
                            if (lj[iarr[i]].Category == 4)
                            {
                                acumcat4++;
                                if (acumcat4 < maximocat4 + 1)
                                {
                                    jcs.Add(lj[iarr[i]]);
                                    encontrado = true;
                                }
                            }
                            else
                            {
                                jcs.Add(lj[iarr[i]]);
                                encontrado = true;
                            }

                        }
                    }
                    if (!encontrado) // si no se ha encontrado se sube la participación buscada
                    {
                        catbuscada++;
                    }
                }


            }

            // sortear de nuevo entre los jueces que quedan en la lista,
            Thread.Sleep(20);
            Random rnd2 = new Random((int)DateTime.Now.Ticks);



            if (jcs.Count() > 0)
            {
                return jcs[rnd2.Next(0, jcs.Count() - 1)].ID.ToString();

            }
            else
            {
                return "0";
            }

        }


        private string BuscarjuezmenorcategoriayparticipacionFinalesEA(ObservableCollection<Juez> lj, string rol, int panel, string CBpr, int maximocat4, int numjuez)
        {
            // Llenar la colección con los jueces con menor participación y del pais adecuado, quitando los de cat4 que no correspondan
            ObservableCollection<Juez> jcs = new ObservableCollection<Juez>();
            List<Juez> jcscatpart = new List<Juez>();
            ObservableCollection<Juez> jcscat2 = new ObservableCollection<Juez>();
            ObservableCollection<Juez> jcscat3 = new ObservableCollection<Juez>();
            ObservableCollection<Juez> jcscat4 = new ObservableCollection<Juez>();
            //hacer un array de numeros aleatorios no repetidos para que, en caso de jueces de cat4 no sean siempre los mismos en la primera rotacion

            int acumcat4 = 0;


            if (rol == "A")
            {
                jcscatpart = lj.OrderBy(x => x.Category).ThenBy(y => y.TotalF).ThenBy(y => y.TotalFA).ToList();

                foreach (Juez j in jcscatpart)
                {
                    if (PaisCorrectoPanelORol(j, "A", panel, CBpr))
                    {
                        if (j.Category == 4)
                        {
                            acumcat4++;
                            if (acumcat4 < maximocat4 + 1)
                            {
                                jcs.Add(j);

                            }
                        }
                        else
                        {
                            jcs.Add(j);

                        }



                    }
                }
            }

            else

            {

                jcscatpart = lj.OrderBy(x => x.Category).ThenBy(y => y.TotalF).ThenBy(y => y.TotalFE).ToList();

                foreach (Juez j in jcscatpart)
                {
                    if (PaisCorrectoPanelORol(j, "E", panel, CBpr))
                    {
                        if (j.Category == 4)
                        {
                            acumcat4++;
                            if (acumcat4 < maximocat4 + 1)
                            {
                                jcs.Add(j);

                            }
                        }
                        else
                        {
                            jcs.Add(j);

                        }



                    }
                }
            }

            if (jcs.Count() > 0)
            {
                return jcs[0].ID.ToString();

            }
            else
            {
                return "0";
            }



        }



        private string buscarjuezEA(ObservableCollection<Juez> lj, string rol, int panel, string CBpr, int maximocat4, int numjuez)
        {
            // busca en la lista facilitada, un juez con la mayor categoria y con la menor participación

            // Llenar la colección con los jueces con menor participación y del pais adecuado, quitando los de cat4 que no correspondan
            ObservableCollection<Juez> jcs = new ObservableCollection<Juez>();

            //hacer un array de numeros aleatorios no repetidos para que, en caso de jueces de cat4 no sean siempre los mismos en la primera rotacion
            Thread.Sleep(20);
            Random rnd = new Random((int)DateTime.Now.Ticks);
            int[] iarr = new int[lj.Count];

            int r, temp;
            r = 1;
            for (int i = 0; i < lj.Count; i++)
            {
                iarr[i] = i;
            }
            for (int i = lj.Count - 1; i > -1; i--)
            {
                r = rnd.Next(1, lj.Count);
                temp = iarr[r];
                iarr[r] = iarr[i];
                iarr[i] = temp;
            }

            // acumulador de numero de jueces cat4 
            int acumcat4 = 0;
            int minpartE = lj.Min(x => x.TotalE);
            int maxpartE = lj.Max(x => x.TotalE);
            int partEbuscada = minpartE;
            int minpartA = lj.Min(x => x.TotalA);
            int maxpartA = lj.Max(x => x.TotalA);
            int partAbuscada = minpartA;
            bool encontrado = false;

            if (rol == "E")
            {
                while (!encontrado && partEbuscada < maxpartE + 1)
                {
                    for (int i = 0; i < lj.Count; i++)
                    {
                        if (lj[iarr[i]].TotalE == partEbuscada && PaisCorrectoPanelORol(lj[iarr[i]], "E", panel, CBpr))
                        {
                            if (lj[iarr[i]].Category == 4)
                            {
                                acumcat4++;
                                if (acumcat4 < maximocat4 + 1)
                                {
                                    jcs.Add(lj[iarr[i]]);
                                    encontrado = true;
                                }
                            }
                            else
                            {
                                jcs.Add(lj[iarr[i]]);
                                encontrado = true;
                            }

                        }
                    }
                    if (!encontrado) // si no se ha encontrado se sube la participación buscada
                    {
                        partEbuscada++;
                    }
                }

            }
            else
            {
                while (!encontrado && partAbuscada < maxpartA + 1)
                {
                    for (int i = 0; i < lj.Count; i++)
                    {
                        if (lj[iarr[i]].TotalA == partAbuscada && PaisCorrectoPanelORol(lj[iarr[i]], "A", panel, CBpr))
                        {
                            if (lj[iarr[i]].Category == 4)
                            {
                                acumcat4++;
                                if (acumcat4 < maximocat4 + 1)
                                {
                                    jcs.Add(lj[iarr[i]]);
                                    encontrado = true;
                                }
                            }
                            else
                            {
                                jcs.Add(lj[iarr[i]]);
                                encontrado = true;
                            }

                        }
                    }
                    if (!encontrado) // si no se ha encontrado se sube la participación buscada
                    {
                        partAbuscada++;
                    }
                }


            }

            // sortear de nuevo entre los jueces que quedan en la lista, sin tener en cuenta categoria ..
            Thread.Sleep(20);
            Random rnd2 = new Random((int)DateTime.Now.Ticks);

            if (jcs.Count() > 0)
            {
                return jcs[rnd2.Next(0, jcs.Count() - 1)].ID.ToString();

            }
            else
            {
                return "0";
            }


        }

        private bool PaisCorrectoPanelORol(Juez ju, string rol, int panel, string panelorol)
        {
            // comprobar que el pais es correcto teniendo en cuenta la información del text box del panel 1
            if (panelorol == "With No same country in same role")
            {
                // la lista de paises se limita a los paises del mismo rol
                if (rol == "E")
                {
                    if (panel == 1)
                    {
                        if (ju.Country.ToString() == CtryE1P1.Content.ToString() || ju.Country.ToString() == CtryE2P1.Content.ToString() || ju.Country.ToString() == CtryE3P1.Content.ToString() || ju.Country.ToString() == CtryE4P1.Content.ToString() || ju.Country.ToString() == CtryE5P1.Content.ToString() || ju.Country.ToString() == CtryE6P1.Content.ToString() || ju.Country.ToString() == CtryREP1.Content.ToString())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }

                    }
                    else
                    {
                        if (ju.Country.ToString() == CtryE1P2.Content.ToString() || ju.Country.ToString() == CtryE2P2.Content.ToString() || ju.Country.ToString() == CtryE3P2.Content.ToString() || ju.Country.ToString() == CtryE4P2.Content.ToString() || ju.Country.ToString() == CtryE5P2.Content.ToString() || ju.Country.ToString() == CtryE6P2.Content.ToString() || ju.Country.ToString() == CtryREP2.Content.ToString())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }


                    }
                }
                else
                {
                    if (panel == 1)
                    {
                        if (ju.Country.ToString() == CtryA1P1.Content.ToString() || ju.Country.ToString() == CtryA2P1.Content.ToString() || ju.Country.ToString() == CtryA3P1.Content.ToString() || ju.Country.ToString() == CtryA4P1.Content.ToString() || ju.Country.ToString() == CtryA5P1.Content.ToString() || ju.Country.ToString() == CtryA6P1.Content.ToString() || ju.Country.ToString() == CtryRAP1.Content.ToString())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }

                    }
                    else
                    {
                        if (ju.Country.ToString() == CtryA1P2.Content.ToString() || ju.Country.ToString() == CtryA2P2.Content.ToString() || ju.Country.ToString() == CtryA3P2.Content.ToString() || ju.Country.ToString() == CtryA4P2.Content.ToString() || ju.Country.ToString() == CtryA5P2.Content.ToString() || ju.Country.ToString() == CtryA6P2.Content.ToString() || ju.Country.ToString() == CtryRAP2.Content.ToString())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }


                    }


                }
            }
            else
            {
                if (panel == 1)
                {
                    if (ju.Country.ToString() == CtryA1P1.Content.ToString() || ju.Country.ToString() == CtryA2P1.Content.ToString() || ju.Country.ToString() == CtryA3P1.Content.ToString() || ju.Country.ToString() == CtryA4P1.Content.ToString() || ju.Country.ToString() == CtryA5P1.Content.ToString() || ju.Country.ToString() == CtryA6P1.Content.ToString() || ju.Country.ToString() == CtryRAP1.Content.ToString() || ju.Country.ToString() == CtryE1P1.Content.ToString() || ju.Country.ToString() == CtryE2P1.Content.ToString() || ju.Country.ToString() == CtryE3P1.Content.ToString() || ju.Country.ToString() == CtryE4P1.Content.ToString() || ju.Country.ToString() == CtryE5P1.Content.ToString() || ju.Country.ToString() == CtryE6P1.Content.ToString() || ju.Country.ToString() == CtryREP1.Content.ToString())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    if (ju.Country.ToString() == CtryA1P2.Content.ToString() || ju.Country.ToString() == CtryA2P2.Content.ToString() || ju.Country.ToString() == CtryA3P2.Content.ToString() || ju.Country.ToString() == CtryA4P2.Content.ToString() || ju.Country.ToString() == CtryA5P2.Content.ToString() || ju.Country.ToString() == CtryA6P2.Content.ToString() || ju.Country.ToString() == CtryRAP2.Content.ToString() || ju.Country.ToString() == CtryE1P2.Content.ToString() || ju.Country.ToString() == CtryE2P2.Content.ToString() || ju.Country.ToString() == CtryE3P2.Content.ToString() || ju.Country.ToString() == CtryE4P2.Content.ToString() || ju.Country.ToString() == CtryE5P2.Content.ToString() || ju.Country.ToString() == CtryE6P2.Content.ToString() || ju.Country.ToString() == CtryREP2.Content.ToString())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }

        }


        private void eliminardelistadejuecesTB(TextBox TB, ObservableCollection<Juez> lj)
        {
            if ((string.IsNullOrEmpty(TB.Text) ? 0 : int.Parse(TB.Text)) > 0)
            {
                if (lj.Where(x => x.ID == int.Parse(TB.Text)).Count() > 0)
                {
                    lj.Remove(lj.Where(x => x.ID == int.Parse(TB.Text)).First());
                }
            }
        }

        private void eliminardelistadejuecesNombre(string nombre, ObservableCollection<Juez> lj)
        {
            if (!string.IsNullOrEmpty(nombre))
            {
                if (lj.Where(x => x.JudgeName == nombre).Count() > 0)
                {
                    lj.Remove(lj.Where(x => x.JudgeName == nombre).First());
                }
            }
        }

        private void Panel1Draw_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Start the draw?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                // Se eliminan las asignaciones del panel 
                limpiar_asginaciones_juecesP1();
                //se eliminan los posibles warning de sorteor anteriores
                Panel1Warning.Text = "";
                ImagewarningP1.Visibility = Visibility.Collapsed;
                //se reinicia el resumen del panel
                Panel1Cat1Enumjudges.Content = "0";
                Panel1Cat2Enumjudges.Content = "0";
                Panel1Cat3Enumjudges.Content = "0";
                Panel1Cat4Enumjudges.Content = "0";
                Panel1Cat1Anumjudges.Content = "0";
                Panel1Cat2Anumjudges.Content = "0";
                Panel1Cat3Anumjudges.Content = "0";
                Panel1Cat4Anumjudges.Content = "0";
                Panel1EAvgjudges.Content = "0";
                Panel1AAvgjudges.Content = "0";

                ObservableCollection<Juez> listajuecesdisponibles = new ObservableCollection<Juez>();
                //añadir jueces disponibles y sin warning
                for (int i = 0; i < jueces.juecespresentessinwarning().Count; i++)
                {
                    listajuecesdisponibles.Add(jueces.juecespresentessinwarning()[i]);
                }

                //quitar los jueces que tienen familiares en el panel 1
                foreach (Relative r in relativesP1)
                {
                    eliminardelistadejuecesNombre(r.Juez, listajuecesdisponibles);
                }
                // eliminar de la lista de jueces disponibles los jueces del panel superior
                eliminardelistadejuecesNombre(evento.SJPJudge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJD1Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJD2Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJE1Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJE2Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJA1Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJA2Judge, listajuecesdisponibles);
                // eliminar de la lista de juecces disponibles los CPJ y DJ de los 2 paneles 
                eliminardelistadejuecesTB(TBP1CPJ, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1D1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1D2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2CPJ, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2D1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2D2, listajuecesdisponibles);
                //eliminar de la lista los jueces del otro panel
                eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2E6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                //eliminar de la lista los INQ Linea y tiempo
                eliminardelistadejuecesTB(TBP1T1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBL2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2T1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBL1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBINQ, listajuecesdisponibles);
                //ver cuantos cat 4 hay en el listado de jueces disponibles
                int cat4 = 0;
                int cat4adescontar;
                int totaljuecessolicitados = 0;
                int maxcat4Qjueces;
                int maxcat4Fjueces;
                // contar cat 4
                cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();

                maxcat4Qjueces = 0;
                switch (evento.P1QNoLimitCat4Judges)
                {
                    case "Limited Cat 4 Judges":
                        {
                            maxcat4Qjueces = evento.P1QMaxCat4judges;
                        }
                        break;
                    case "Unlimited Cat 4 judges":
                        {
                            maxcat4Qjueces = 1000; //ponemos una cantidad que no se dará
                        }
                        break;
                    case "Without Cat 4 judges":
                        {
                            maxcat4Qjueces = 0;
                        }
                        break;

                }

                cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();
                if (horario[indicehorario].CompetitionP1 == "QUALIFICATION")
                {
                    //  if (cat4 > (string.IsNullOrEmpty(CBP1QMaxCat4judges.Text) ? 0 : int.Parse(CBP1QMaxCat4judges.Text)))
                    //  {

                    totaljuecessolicitados = evento.P1QEjudges;
                    totaljuecessolicitados += evento.P1QAjudges;
                    totaljuecessolicitados += evento.P1QREjudges;
                    totaljuecessolicitados += evento.P1QRAjudges;
                    if (cat4 < 1 + maxcat4Qjueces)
                    {
                        cat4adescontar = 0;

                    }
                    else
                    {

                        cat4adescontar = cat4 - maxcat4Qjueces;
                    }
                    if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count() - cat4adescontar)
                    {
                        Panel1Warning.Text = "Not enough judges. We need " + totaljuecessolicitados.ToString() + " judges and we have " + (listajuecesdisponibles.Count() - cat4adescontar).ToString() + " judges.";
                        ImagewarningP1.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                        int paisescat123 = 0;
                        int paisestotales = 0;
                        int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                        int paises = 0;
                        int paisessolicitados = 0;
                        // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                        paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                        paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                        // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                        paisescat4 = paisestotales - paisescat123;
                        // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                        if (paisescat4 > maxcat4Qjueces)
                        {
                            paisescat4 = maxcat4Qjueces;
                        }
                        paises = paisescat4 + paisescat123;

                        if (evento.P1QNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                        {
                            if ((evento.P1QEjudges + evento.P1QREjudges) > (evento.P1QAjudges + evento.P1QRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                            {
                                paisessolicitados = evento.P1QEjudges + evento.P1QREjudges;
                            }
                            else
                            {
                                paisessolicitados = evento.P1QAjudges + evento.P1QRAjudges;
                            }
                        }
                        else // si no se pueden repetir nacionalidades en el panel
                        {
                            paisessolicitados = totaljuecessolicitados;
                        }
                        if (paises < paisessolicitados)
                        {
                            Panel1Warning.Text = "Not enough countries for draw";
                            ImagewarningP1.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            //seguimos con el sorteo
                            Thread.Sleep(20);
                            Random rnd = new Random((int)DateTime.Now.Ticks);

                            int[] ordensorteorol = new int[12];

                            int r, temp;
                            r = 1;
                            for (int i = 0; i < 12; i++)
                            {
                                ordensorteorol[i] = i;
                            }
                            for (int i = 12 - 1; i > -1; i--)
                            {
                                r = rnd.Next(1, 12);
                                temp = ordensorteorol[r];
                                ordensorteorol[r] = ordensorteorol[i];
                                ordensorteorol[i] = temp;
                            }

                            for (int i = 0; i < 12; i++)
                            {
                                switch (ordensorteorol[i])
                                {
                                    case 0:  // Sorteamos E1
                                        if (evento.P1QEjudges > 0)
                                        {
                                            TBP1E1.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 1);
                                            eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                                        }
                                        break;
                                    case 1:// Sorteamos E2
                                        if (evento.P1QEjudges > 1)
                                        {
                                            TBP1E2.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 2);
                                            eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                                        }
                                        break;
                                    case 2:// Sorteamos E3
                                        if (evento.P1QEjudges > 2)
                                        {
                                            TBP1E3.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 3);
                                            eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                                        }
                                        break;
                                    case 3:// Sorteamos E4
                                        if (evento.P1QEjudges > 3)
                                        {
                                            TBP1E4.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                                        }
                                        break;
                                    case 4:// Sorteamos E5
                                        if (evento.P1QEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                        {
                                            TBP1E5.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                                        }
                                        break;
                                    case 5:// Sorteamos E6
                                        if (evento.P1QEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                        {
                                            TBP1E6.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                                        }
                                        break;

                                    case 6:// Sorteamos A1
                                        if (evento.P1QAjudges > 0)
                                        {
                                            TBP1A1.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 1);
                                            eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                                        }
                                        break;
                                    case 7:// Sorteamos A2
                                        if (evento.P1QAjudges > 1)
                                        {
                                            TBP1A2.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 2);
                                            eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                                        }
                                        break;
                                    case 8:// Sorteamos A3
                                        if (evento.P1QAjudges > 2)
                                        {
                                            TBP1A3.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 3);
                                            eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                                        }
                                        break;
                                    case 9:// Sorteamos A4
                                        if (evento.P1QAjudges > 3)
                                        {
                                            TBP1A4.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                                        }
                                        break;
                                    case 10:// Sorteamos A5
                                        if (evento.P1QAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                        {
                                            TBP1A5.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                                        }
                                        break;
                                    case 11:// Sorteamos A6
                                        if (evento.P1QAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                        {
                                            TBP1A6.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                                        }
                                        break;

                                }
                            }

                            switch (evento.P1QREjudges)
                            {
                                case 1:
                                    TBP1RE.Text = buscarjuezEA(listajuecesdisponibles, "E", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 5);
                                    eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                                    break;
                                default:
                                    break;
                            }


                            switch (evento.P1QRAjudges)
                            {
                                case 1:
                                    TBP1RA.Text = buscarjuezEA(listajuecesdisponibles, "A", 1, evento.P1QNoSameCountryInSame, maxcat4Qjueces, 6);
                                    eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                                    break;
                                default:
                                    break;
                            }




                        }
                    }
                    incrementarparticipacionEjuez(TBP1E1);
                    incrementarparticipacionEjuez(TBP1E2);
                    incrementarparticipacionEjuez(TBP1E3);
                    incrementarparticipacionEjuez(TBP1E4);
                    incrementarparticipacionEjuez(TBP1E5);
                    incrementarparticipacionEjuez(TBP1E6);

                    incrementarparticipacionAjuez(TBP1A1);
                    incrementarparticipacionAjuez(TBP1A2);
                    incrementarparticipacionAjuez(TBP1A3);
                    incrementarparticipacionAjuez(TBP1A4);
                    incrementarparticipacionAjuez(TBP1A5);
                    incrementarparticipacionAjuez(TBP1A6);


                    //  }
                }
                else //Si son finales....
                {


                    totaljuecessolicitados = evento.P1FEjudges;
                    totaljuecessolicitados += evento.P1FAjudges;
                    totaljuecessolicitados += evento.P1FREjudges;
                    totaljuecessolicitados += evento.P1FRAjudges;
                    maxcat4Fjueces = 0;
                    switch (evento.P1FNoLimitCat4Judges)
                    {
                        case "Limited Cat 4 Judges":
                            {
                                maxcat4Fjueces = evento.P1FMaxCat4judges;
                            }
                            break;
                        case "Unlimited Cat 4 judges":
                            {
                                maxcat4Fjueces = 1000; //ponemos una cantidad que no se dará
                            }
                            break;
                        case "Without Cat 4 judges":
                            {
                                maxcat4Fjueces = 0;
                            }
                            break;

                    }
                    if (cat4 < 1 + maxcat4Fjueces)
                    {
                        cat4adescontar = 0;
                    }
                    else
                    {
                        cat4adescontar = cat4 - maxcat4Fjueces;
                    }
                    if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count() - cat4adescontar)
                    {
                        Panel1Warning.Text = "Not enough judges. We need " + totaljuecessolicitados.ToString() + " judges and we have " + (listajuecesdisponibles.Count() - cat4adescontar).ToString() + " judges.";
                        ImagewarningP1.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        //comprobar que hay el número mínimo de paises. Dependiendo de si la selección es de sólo pa

                        switch (evento.P1F3Condition)
                        {
                            case "Randomized":
                                {
                                    //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                                    int paisescat123 = 0;
                                    int paisestotales = 0;
                                    int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                    int paises = 0;
                                    int paisessolicitados = 0;
                                    // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                    paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                    paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                    // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                    paisescat4 = paisestotales - paisescat123;
                                    // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                    if (paisescat4 > maxcat4Fjueces)
                                    {
                                        paisescat4 = maxcat4Fjueces;
                                    }
                                    paises = paisescat4 + paisescat123;
                                    if (evento.P1FNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                                    {
                                        if ((evento.P1FEjudges + evento.P1FREjudges) > (evento.P1FAjudges + evento.P1FRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                                        {
                                            paisessolicitados = evento.P1FEjudges + evento.P1FREjudges;
                                        }
                                        else
                                        {
                                            paisessolicitados = evento.P1FAjudges + evento.P1FRAjudges;
                                        }
                                    }
                                    else // si no se pueden repetir nacionalidades en el panel
                                    {
                                        paisessolicitados = totaljuecessolicitados;
                                    }
                                    if (paises < paisessolicitados)
                                    {
                                        Panel1Warning.Text = "Not enough countries for draw";
                                        ImagewarningP1.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        //seguimos con el sorteo
                                        Thread.Sleep(20);
                                        Random rnd = new Random((int)DateTime.Now.Ticks);

                                        int[] ordensorteorol = new int[12];

                                        int r, temp;
                                        r = 1;
                                        for (int i = 0; i < 12; i++)
                                        {
                                            ordensorteorol[i] = i;
                                        }
                                        for (int i = 12 - 1; i > -1; i--)
                                        {
                                            r = rnd.Next(1, 12);
                                            temp = ordensorteorol[r];
                                            ordensorteorol[r] = ordensorteorol[i];
                                            ordensorteorol[i] = temp;
                                        }

                                        for (int i = 0; i < 12; i++)
                                        {
                                            switch (ordensorteorol[i])
                                            {
                                                case 0:  // Sorteamos E1
                                                    if (evento.P1FEjudges > 0)
                                                    {
                                                        TBP1E1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 1:// Sorteamos E2
                                                    if (evento.P1FEjudges > 1)
                                                    {
                                                        TBP1E2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 2:// Sorteamos E3
                                                    if (evento.P1FEjudges > 2)
                                                    {
                                                        TBP1E3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 3:// Sorteamos E4
                                                    if (evento.P1FEjudges > 3)
                                                    {
                                                        TBP1E4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 4:// Sorteamos E5
                                                    if (evento.P1FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP1E5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 5:// Sorteamos E6
                                                    if (evento.P1FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP1E6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                                                    }
                                                    break;

                                                case 6:// Sorteamos A1
                                                    if (evento.P1FAjudges > 0)
                                                    {
                                                        TBP1A1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 7:// Sorteamos A2
                                                    if (evento.P1FAjudges > 1)
                                                    {
                                                        TBP1A2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 8:// Sorteamos A3
                                                    if (evento.P1FAjudges > 2)
                                                    {
                                                        TBP1A3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 9:// Sorteamos A4
                                                    if (evento.P1FAjudges > 3)
                                                    {
                                                        TBP1A4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 10:// Sorteamos A5
                                                    if (evento.P1FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP1A5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 11:// Sorteamos A6
                                                    if (evento.P1FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP1A6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                                                    }
                                                    break;

                                            }
                                        }

                                        switch (evento.P1FREjudges)
                                        {
                                            case 1:
                                                TBP1RE.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }


                                        switch (evento.P1FRAjudges)
                                        {
                                            case 1:
                                                TBP1RA.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                break;
                            case "With finalists":
                                {
                                    //recorremos la lista de jueces disponibles eliminando los que NO son de la nacionalidad de la categoria de que se trata

                                    ObservableCollection<Juez> juecesaeliminar = new ObservableCollection<Juez>();
                                    ObservableCollection<Juez> juecesdisponiblesnacionalidadesreserva = new ObservableCollection<Juez>();

                                    FinalCountries fcount = eventfinalcountries.Where(x => x.CatModEx == horario[indicehorario].CatModExP1).FirstOrDefault();
                                    {
                                        foreach (Juez j in listajuecesdisponibles)
                                        {
                                            if (j.Country != fcount.Country1 && j.Country != fcount.Country2 && j.Country != fcount.Country3 && j.Country != fcount.Country4 && j.Country != fcount.Country5 && j.Country != fcount.Country6 && j.Country != fcount.Country7
                                                && j.Country != fcount.Country8 && j.Country != fcount.Country9 && j.Country != fcount.Country10 && j.Country != fcount.CountryR1 && j.Country != fcount.CountryR2)
                                            {
                                                juecesaeliminar.Add(j);
                                            }
                                        }

                                    }

                                    //recorremos la lista de jueces a eliminar y vamos eliminando de la lista de jueces disponibles


                                    foreach (Juez j in juecesaeliminar)
                                    {

                                        listajuecesdisponibles.Remove(j);

                                    }

                                    // hay que contar cuantas nacionalidades distintas nos exige la final

                                    int nacionalidadessolicitadas = 0;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country1) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country2) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country3) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country4) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country5) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country6) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country7) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country8) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country9) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country10) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.CountryR1) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.CountryR2) ? 0 : 1;

                                    // contar cat 4
                                    cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();

                                    maxcat4Fjueces = 0;
                                    switch (evento.P1FNoLimitCat4Judges)
                                    {
                                        case "Limited Cat 4 Judges":
                                            {
                                                maxcat4Fjueces = evento.P1FMaxCat4judges;
                                            }
                                            break;
                                        case "Unlimited Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 1000; //ponemos una cantidad que no se dará
                                            }
                                            break;
                                        case "Without Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 0;
                                            }
                                            break;

                                    }
                                    if (cat4 < 1 + maxcat4Fjueces)
                                    {
                                        cat4adescontar = 0;

                                    }
                                    else
                                    {

                                        cat4adescontar = cat4 - maxcat4Fjueces;
                                    }

                                    if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count() - cat4adescontar)
                                    {
                                        Panel1Warning.Text = "There are not enough judges";
                                        ImagewarningP1.Visibility = Visibility.Visible;

                                    }
                                    else
                                    {
                                        // revisar que hay jueces con nacionalidades suficientes teniendo en cuenta las restricciones de cat4 si existieran

                                        int paisescat123 = 0;
                                        int paisestotales = 0;
                                        int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                        int paises = 0;

                                        // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                        paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                        paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                                                                                                             // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                        paisescat4 = paisestotales - paisescat123;
                                        // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                        if (paisescat4 > maxcat4Fjueces)
                                        {
                                            paisescat4 = maxcat4Fjueces;
                                        }
                                        paises = paisescat4 + paisescat123;


                                        if (nacionalidadessolicitadas > paises)
                                        {
                                            Panel1Warning.Text = "There are not enough judges of the requested nationalities";
                                            ImagewarningP1.Visibility = Visibility.Visible;
                                        }
                                        else
                                        {
                                            //seguimos con el sorteo

                                            // gestionamos la lista de jueces de reserva, haciendo que sean lista aparte

                                                foreach (Juez j in listajuecesdisponibles)
                                                {
                                                    if (j.Country == fcount.CountryR1 || j.Country == fcount.CountryR2)
                                                    {
                                                        juecesdisponiblesnacionalidadesreserva.Add(j);
                                                    }
                                                }
                                                foreach (Juez j in juecesdisponiblesnacionalidadesreserva)
                                                {
                                                    if (j.Country == fcount.CountryR1 || j.Country == fcount.CountryR2)
                                                    {
                                                        listajuecesdisponibles.Remove(j);
                                                    }
                                                }




                                            Thread.Sleep(20);
                                            Random rnd = new Random((int)DateTime.Now.Ticks);

                                            int[] ordensorteorol = new int[12];

                                            int r, temp;
                                            r = 1;
                                            for (int i = 0; i < 12; i++)
                                            {
                                                ordensorteorol[i] = i;
                                            }
                                            for (int i = 12 - 1; i > -1; i--)
                                            {
                                                r = rnd.Next(1, 12);
                                                temp = ordensorteorol[r];
                                                ordensorteorol[r] = ordensorteorol[i];
                                                ordensorteorol[i] = temp;
                                            }

                                            for (int i = 0; i < 12; i++)
                                            {
                                                switch (ordensorteorol[i])
                                                {
                                                    case 0:  // Sorteamos E1
                                                        if (evento.P1FEjudges > 0)
                                                        {
                                                            TBP1E1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                            eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 1:// Sorteamos E2
                                                        if (evento.P1FEjudges > 1)
                                                        {
                                                            TBP1E2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                            eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 2:// Sorteamos E3
                                                        if (evento.P1FEjudges > 2)
                                                        {
                                                            TBP1E3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                            eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 3:// Sorteamos E4
                                                        if (evento.P1FEjudges > 3)
                                                        {
                                                            TBP1E4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 4:// Sorteamos E5
                                                        if (evento.P1FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                        {
                                                            TBP1E5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 5:// Sorteamos E6
                                                        if (evento.P1FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                        {
                                                            TBP1E6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                                                        }
                                                        break;

                                                    case 6:// Sorteamos A1
                                                        if (evento.P1FAjudges > 0)
                                                        {
                                                            TBP1A1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                            eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 7:// Sorteamos A2
                                                        if (evento.P1FAjudges > 1)
                                                        {
                                                            TBP1A2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                            eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 8:// Sorteamos A3
                                                        if (evento.P1FAjudges > 2)
                                                        {
                                                            TBP1A3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                            eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 9:// Sorteamos A4
                                                        if (evento.P1FAjudges > 3)
                                                        {
                                                            TBP1A4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 10:// Sorteamos A5
                                                        if (evento.P1FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                        {
                                                            TBP1A5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 11:// Sorteamos A6
                                                        if (evento.P1FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                        {
                                                            TBP1A6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                                                        }
                                                        break;

                                                }
                                            }

                                            if (evento.P1FReserveContriesToReserveJudges == "Reserve judges only from reserve countries")
                                            {

                                                switch (evento.P1FREjudges)
                                                {
                                                    case 1:
                                                        TBP1RE.Text = buscarjuezmenorcategoriaEA(juecesdisponiblesnacionalidadesreserva, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                        eliminardelistadejuecesTB(TBP1RE, juecesdisponiblesnacionalidadesreserva);
                                                        break;
                                                    default:
                                                        break;
                                                }


                                                switch (evento.P1FRAjudges)
                                                {
                                                    case 1:
                                                        TBP1RA.Text = buscarjuezmenorcategoriaEA(juecesdisponiblesnacionalidadesreserva, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                        eliminardelistadejuecesTB(TBP1RA, juecesdisponiblesnacionalidadesreserva);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (evento.P1FREjudges)
                                                {
                                                    case 1:
                                                        TBP1RE.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                        eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                                                        break;
                                                    default:
                                                        break;
                                                }


                                                switch (evento.P1FRAjudges)
                                                {
                                                    case 1:
                                                        TBP1RA.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                        eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }


                                        }

                                    }
                                }

                                break;
                            case "Without finalists":
                                {
                                    //recorremos la lista de jueces disponibles eliminando los que SI son de la nacionalidad de la categoria de que se trata

                                    ObservableCollection<Juez> juecesaeliminarwof = new ObservableCollection<Juez>();

                                    FinalCountries fc = eventfinalcountries.Where(x => x.CatModEx == horario[indicehorario].CatModExP1).FirstOrDefault();
                                    {
                                        foreach (Juez j in listajuecesdisponibles)
                                        {
                                            if (j.Country == fc.Country1 || j.Country == fc.Country2 || j.Country == fc.Country3 || j.Country == fc.Country4 || j.Country == fc.Country5 || j.Country == fc.Country6 || j.Country == fc.Country7
                                                || j.Country == fc.Country8 || j.Country == fc.Country9 || j.Country == fc.Country10 || j.Country == fc.CountryR1 || j.Country == fc.CountryR2)
                                            {
                                                juecesaeliminarwof.Add(j);

                                            }
                                        }

                                    }


                                    foreach (Juez j in juecesaeliminarwof)
                                    {

                                        listajuecesdisponibles.Remove(j);

                                    }

                                    //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                                    int paisescat123 = 0;
                                    int paisestotales = 0;
                                    int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                    int paises = 0;
                                    int paisessolicitados = 0;
                                    // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                    paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                    paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                    // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                    paisescat4 = paisestotales - paisescat123;
                                    // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                    // contar cat 4
                                    cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();

                                    maxcat4Fjueces = 0;
                                    switch (evento.P1FNoLimitCat4Judges)
                                    {
                                        case "Limited Cat 4 Judges":
                                            {
                                                maxcat4Fjueces = evento.P1FMaxCat4judges;
                                            }
                                            break;
                                        case "Unlimited Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 1000; //ponemos una cantidad que no se dará
                                            }
                                            break;
                                        case "Without Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 0;
                                            }
                                            break;

                                    }
                                    if (paisescat4 > maxcat4Fjueces)
                                    {
                                        paisescat4 = maxcat4Fjueces;
                                    }
                                    paises = paisescat4 + paisescat123;
                                    if (evento.P1FNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                                    {
                                        if ((evento.P1FEjudges + evento.P1FREjudges) > (evento.P1FAjudges + evento.P1FRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                                        {
                                            paisessolicitados = evento.P1FEjudges + evento.P1FREjudges;
                                        }
                                        else
                                        {
                                            paisessolicitados = evento.P1FAjudges + evento.P1FRAjudges;
                                        }
                                    }
                                    else // si no se pueden repetir nacionalidades en el panel
                                    {
                                        paisessolicitados = totaljuecessolicitados;
                                    }
                                    if (paises < paisessolicitados)
                                    {
                                        Panel1Warning.Text = "There are not enough judges of the requested nationalities";
                                        ImagewarningP1.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        //seguimos con el sorteo
                                        Thread.Sleep(20);
                                        Random rnd = new Random((int)DateTime.Now.Ticks);

                                        int[] ordensorteorol = new int[12];

                                        int r, temp;
                                        r = 1;
                                        for (int i = 0; i < 12; i++)
                                        {
                                            ordensorteorol[i] = i;
                                        }
                                        for (int i = 12 - 1; i > -1; i--)
                                        {
                                            r = rnd.Next(1, 12);
                                            temp = ordensorteorol[r];
                                            ordensorteorol[r] = ordensorteorol[i];
                                            ordensorteorol[i] = temp;
                                        }

                                        for (int i = 0; i < 12; i++)
                                        {
                                            switch (ordensorteorol[i])
                                            {
                                                case 0:  // Sorteamos E1
                                                    if (evento.P1FEjudges > 0)
                                                    {
                                                        TBP1E1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 1:// Sorteamos E2
                                                    if (evento.P1FEjudges > 1)
                                                    {
                                                        TBP1E2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 2:// Sorteamos E3
                                                    if (evento.P1FEjudges > 2)
                                                    {
                                                        TBP1E3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 3:// Sorteamos E4
                                                    if (evento.P1FEjudges > 3)
                                                    {
                                                        TBP1E4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 4:// Sorteamos E5
                                                    if (evento.P1FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP1E5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 5:// Sorteamos E6
                                                    if (evento.P1FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP1E6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                                                    }
                                                    break;

                                                case 6:// Sorteamos A1
                                                    if (evento.P1FAjudges > 0)
                                                    {
                                                        TBP1A1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 7:// Sorteamos A2
                                                    if (evento.P1FAjudges > 1)
                                                    {
                                                        TBP1A2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 8:// Sorteamos A3
                                                    if (evento.P1FAjudges > 2)
                                                    {
                                                        TBP1A3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 9:// Sorteamos A4
                                                    if (evento.P1FAjudges > 3)
                                                    {
                                                        TBP1A4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 10:// Sorteamos A5
                                                    if (evento.P1FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP1A5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 11:// Sorteamos A6
                                                    if (evento.P1FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP1A6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                                                    }
                                                    break;

                                            }
                                        }

                                        switch (evento.P1FREjudges)
                                        {
                                            case 1:
                                                TBP1RE.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }


                                        switch (evento.P1FRAjudges)
                                        {
                                            case 1:
                                                TBP1RA.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }



                                    }

                                }

                                break;
                            case "Randomized based on least amount of sessions judged":
                                {
                                    //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                                    int paisescat123 = 0;
                                    int paisestotales = 0;
                                    int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                    int paises = 0;
                                    int paisessolicitados = 0;
                                    // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                    paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                    paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                    // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                    paisescat4 = paisestotales - paisescat123;
                                    // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                    if (paisescat4 > maxcat4Fjueces)
                                    {
                                        paisescat4 = maxcat4Fjueces;
                                    }
                                    paises = paisescat4 + paisescat123;
                                    if (evento.P1FNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                                    {
                                        if ((evento.P1FEjudges + evento.P1FREjudges) > (evento.P1FAjudges + evento.P1FRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                                        {
                                            paisessolicitados = evento.P1FEjudges + evento.P1FREjudges;
                                        }
                                        else
                                        {
                                            paisessolicitados = evento.P1FAjudges + evento.P1FRAjudges;
                                        }
                                    }
                                    else // si no se pueden repetir nacionalidades en el panel
                                    {
                                        paisessolicitados = totaljuecessolicitados;
                                    }
                                    if (paises < paisessolicitados)
                                    {
                                        Panel1Warning.Text = "Not enough countries for draw";
                                        ImagewarningP1.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        //seguimos con el sorteo
                                        Thread.Sleep(20);
                                        Random rnd = new Random((int)DateTime.Now.Ticks);

                                        int[] ordensorteorol = new int[12];

                                        int r, temp;
                                        r = 1;
                                        for (int i = 0; i < 12; i++)
                                        {
                                            ordensorteorol[i] = i;
                                        }
                                        for (int i = 12 - 1; i > -1; i--)
                                        {
                                            r = rnd.Next(1, 12);
                                            temp = ordensorteorol[r];
                                            ordensorteorol[r] = ordensorteorol[i];
                                            ordensorteorol[i] = temp;
                                        }

                                        for (int i = 0; i < 12; i++)
                                        {
                                            switch (ordensorteorol[i])
                                            {
                                                case 0:  // Sorteamos E1
                                                    if (evento.P1FEjudges > 0)
                                                    {
                                                        TBP1E1.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 1:// Sorteamos E2
                                                    if (evento.P1FEjudges > 1)
                                                    {
                                                        TBP1E2.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 2:// Sorteamos E3
                                                    if (evento.P1FEjudges > 2)
                                                    {
                                                        TBP1E3.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 3:// Sorteamos E4
                                                    if (evento.P1FEjudges > 3)
                                                    {
                                                        TBP1E4.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 4:// Sorteamos E5
                                                    if (evento.P1FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP1E5.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 5:// Sorteamos E6
                                                    if (evento.P1FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP1E6.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                                                    }
                                                    break;

                                                case 6:// Sorteamos A1
                                                    if (evento.P1FAjudges > 0)
                                                    {
                                                        TBP1A1.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 7:// Sorteamos A2
                                                    if (evento.P1FAjudges > 1)
                                                    {
                                                        TBP1A2.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 8:// Sorteamos A3
                                                    if (evento.P1FAjudges > 2)
                                                    {
                                                        TBP1A3.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 9:// Sorteamos A4
                                                    if (evento.P1FAjudges > 3)
                                                    {
                                                        TBP1A4.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 10:// Sorteamos A5
                                                    if (evento.P1FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP1A5.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 11:// Sorteamos A6
                                                    if (evento.P1FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP1A6.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                                                    }
                                                    break;

                                            }
                                        }

                                        switch (evento.P1FREjudges)
                                        {
                                            case 1:
                                                TBP1RE.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }


                                        switch (evento.P1FRAjudges)
                                        {
                                            case 1:
                                                TBP1RA.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 1, evento.P1FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                break;
                        }


                    }

                    incrementarparticipacionFEjuez(TBP1E1);
                    incrementarparticipacionFEjuez(TBP1E2);
                    incrementarparticipacionFEjuez(TBP1E3);
                    incrementarparticipacionFEjuez(TBP1E4);
                    incrementarparticipacionFEjuez(TBP1E5);
                    incrementarparticipacionFEjuez(TBP1E6);

                    incrementarparticipacionFAjuez(TBP1A1);
                    incrementarparticipacionFAjuez(TBP1A2);
                    incrementarparticipacionFAjuez(TBP1A3);
                    incrementarparticipacionFAjuez(TBP1A4);
                    incrementarparticipacionFAjuez(TBP1A5);
                    incrementarparticipacionFAjuez(TBP1A6);
                }

            }
            actualizarresumenpaneles(1);

            JuecesDataGrid.Items.Refresh();

            GuardarJuecesHorarioP1(indicehorario);
        }


        private void Panel2Draw_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Start the draw?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                // Se eliminan las asignaciones del panel 
                limpiar_asginaciones_juecesP2();
                //se eliminan los posibles warning de sorteor anteriores
                Panel2Warning.Text = "";
                ImagewarningP2.Visibility = Visibility.Collapsed;
                //se reinicia el resumen del panel
                Panel2Cat1Enumjudges.Content = "0";
                Panel2Cat2Enumjudges.Content = "0";
                Panel2Cat3Enumjudges.Content = "0";
                Panel2Cat4Enumjudges.Content = "0";
                Panel2Cat1Anumjudges.Content = "0";
                Panel2Cat2Anumjudges.Content = "0";
                Panel2Cat3Anumjudges.Content = "0";
                Panel2Cat4Anumjudges.Content = "0";
                Panel2EAvgjudges.Content = "0";
                Panel2AAvgjudges.Content = "0";

                ObservableCollection<Juez> listajuecesdisponibles = new ObservableCollection<Juez>();
                //añadir jueces disponibles y sin warning
                for (int i = 0; i < jueces.juecespresentessinwarning().Count; i++)
                {
                    listajuecesdisponibles.Add(jueces.juecespresentessinwarning()[i]);
                }

                //quitar los jueces que tienen familiares en el panel 1
                foreach (Relative r in relativesP2)
                {
                    eliminardelistadejuecesNombre(r.Juez, listajuecesdisponibles);
                }
                // eliminar de la lista de jueces disponibles los jueces del panel superior
                eliminardelistadejuecesNombre(evento.SJPJudge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJD1Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJD2Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJE1Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJE2Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJA1Judge, listajuecesdisponibles);
                eliminardelistadejuecesNombre(evento.SJA2Judge, listajuecesdisponibles);
                // eliminar de la lista de juecces disponibles los CPJ y DJ de los 2 paneles 
                eliminardelistadejuecesTB(TBP1CPJ, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1D1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1D2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2CPJ, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2D1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP2D2, listajuecesdisponibles);
                //eliminar de la lista los jueces del otro panel
                eliminardelistadejuecesTB(TBP1E1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1E6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A3, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A4, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A5, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1A6, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1RE, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1RA, listajuecesdisponibles);
                //eliminar de la lista los INQ Linea y tiempo
                eliminardelistadejuecesTB(TBP1T1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBL2, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBP1T1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBL1, listajuecesdisponibles);
                eliminardelistadejuecesTB(TBINQ, listajuecesdisponibles);
                //ver cuantos cat 4 hay en el listado de jueces disponibles
                int cat4 = 0;
                int cat4adescontar;
                int totaljuecessolicitados = 0;
                int maxcat4Qjueces;
                int maxcat4Fjueces;
                maxcat4Qjueces = 0;
                switch (evento.P2QNoLimitCat4Judges)
                {
                    case "Limited Cat 4 Judges":
                        {
                            maxcat4Qjueces = evento.P2QMaxCat4judges;
                        }
                        break;
                    case "Unlimited Cat 4 judges":
                        {
                            maxcat4Qjueces = 1000; //ponemos una cantidad que no se dará
                        }
                        break;
                    case "Without Cat 4 judges":
                        {
                            maxcat4Qjueces = 0;
                        }
                        break;

                }

                cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();
                if (horario[indicehorario].CompetitionP2 == "QUALIFICATION")
                {
                    //  if (cat4 > (string.IsNullOrEmpty(CBP2QMaxCat4judges.Text) ? 0 : int.Parse(CBP2QMaxCat4judges.Text)))
                    //  {

                    totaljuecessolicitados = evento.P2QEjudges;
                    totaljuecessolicitados += evento.P2QAjudges;
                    totaljuecessolicitados += evento.P2QREjudges;
                    totaljuecessolicitados += evento.P2QRAjudges;
                    if (cat4 < 1 + maxcat4Qjueces)
                    {
                        cat4adescontar = 0;

                    }
                    else
                    {

                        cat4adescontar = cat4 - maxcat4Qjueces;
                    }
                    if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count() - cat4adescontar)
                    {
                        Panel2Warning.Text = "Not enough judges. We need " + totaljuecessolicitados.ToString() + " judges and we have " + (listajuecesdisponibles.Count() - cat4adescontar).ToString() + " judges.";
                        ImagewarningP2.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                        int paisescat123 = 0;
                        int paisestotales = 0;
                        int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                        int paises = 0;
                        int paisessolicitados = 0;
                        // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                        paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                        paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                        // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                        paisescat4 = paisestotales - paisescat123;
                        // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                        if (paisescat4 > maxcat4Qjueces)
                        {
                            paisescat4 = maxcat4Qjueces;
                        }
                        paises = paisescat4 + paisescat123;

                        if (evento.P2QNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                        {
                            if ((evento.P2QEjudges + evento.P2QREjudges) > (evento.P2QAjudges + evento.P2QRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                            {
                                paisessolicitados = evento.P2QEjudges + evento.P2QREjudges;
                            }
                            else
                            {
                                paisessolicitados = evento.P2QAjudges + evento.P2QRAjudges;
                            }
                        }
                        else // si no se pueden repetir nacionalidades en el panel
                        {
                            paisessolicitados = totaljuecessolicitados;
                        }
                        if (paises < paisessolicitados)
                        {
                            Panel2Warning.Text = "Not enough countries for draw";
                            ImagewarningP2.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            //seguimos con el sorteo
                            Thread.Sleep(20);
                            Random rnd = new Random((int)DateTime.Now.Ticks);

                            int[] ordensorteorol = new int[12];

                            int r, temp;
                            r = 1;
                            for (int i = 0; i < 12; i++)
                            {
                                ordensorteorol[i] = i;
                            }
                            for (int i = 12 - 1; i > -1; i--)
                            {
                                r = rnd.Next(1, 12);
                                temp = ordensorteorol[r];
                                ordensorteorol[r] = ordensorteorol[i];
                                ordensorteorol[i] = temp;
                            }

                            for (int i = 0; i < 12; i++)
                            {
                                switch (ordensorteorol[i])
                                {
                                    case 0:  // Sorteamos E1
                                        if (evento.P2QEjudges > 0)
                                        {
                                            TBP2E1.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 1);
                                            eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                                        }
                                        break;
                                    case 1:// Sorteamos E2
                                        if (evento.P2QEjudges > 1)
                                        {
                                            TBP2E2.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 2);
                                            eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                                        }
                                        break;
                                    case 2:// Sorteamos E3
                                        if (evento.P2QEjudges > 2)
                                        {
                                            TBP2E3.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 3);
                                            eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                                        }
                                        break;
                                    case 3:// Sorteamos E4
                                        if (evento.P2QEjudges > 3)
                                        {
                                            TBP2E4.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                                        }
                                        break;
                                    case 4:// Sorteamos E5
                                        if (evento.P2QEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                        {
                                            TBP2E5.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP2E5, listajuecesdisponibles);
                                        }
                                        break;
                                    case 5:// Sorteamos E6
                                        if (evento.P2QEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                        {
                                            TBP2E6.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP2E6, listajuecesdisponibles);
                                        }
                                        break;

                                    case 6:// Sorteamos A1
                                        if (evento.P2QAjudges > 0)
                                        {
                                            TBP2A1.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 1);
                                            eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                                        }
                                        break;
                                    case 7:// Sorteamos A2
                                        if (evento.P2QAjudges > 1)
                                        {
                                            TBP2A2.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 2);
                                            eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                                        }
                                        break;
                                    case 8:// Sorteamos A3
                                        if (evento.P2QAjudges > 2)
                                        {
                                            TBP2A3.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 3);
                                            eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                                        }
                                        break;
                                    case 9:// Sorteamos A4
                                        if (evento.P2QAjudges > 3)
                                        {
                                            TBP2A4.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                                        }
                                        break;
                                    case 10:// Sorteamos A5
                                        if (evento.P2QAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                        {
                                            TBP2A5.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                                        }
                                        break;
                                    case 11:// Sorteamos A6
                                        if (evento.P2QAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                        {
                                            TBP2A6.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 4);
                                            eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                                        }
                                        break;

                                }
                            }

                            switch (evento.P2QREjudges)
                            {
                                case 1:
                                    TBP2RE.Text = buscarjuezEA(listajuecesdisponibles, "E", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 5);
                                    eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                                    break;
                                default:
                                    break;
                            }


                            switch (evento.P2QRAjudges)
                            {
                                case 1:
                                    TBP2RA.Text = buscarjuezEA(listajuecesdisponibles, "A", 2, evento.P2QNoSameCountryInSame, maxcat4Qjueces, 6);
                                    eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                                    break;
                                default:
                                    break;
                            }




                        }
                    }
                    incrementarparticipacionEjuez(TBP2E1);
                    incrementarparticipacionEjuez(TBP2E2);
                    incrementarparticipacionEjuez(TBP2E3);
                    incrementarparticipacionEjuez(TBP2E4);
                    incrementarparticipacionEjuez(TBP2E5);
                    incrementarparticipacionEjuez(TBP2E6);

                    incrementarparticipacionAjuez(TBP2A1);
                    incrementarparticipacionAjuez(TBP2A2);
                    incrementarparticipacionAjuez(TBP2A3);
                    incrementarparticipacionAjuez(TBP2A4);
                    incrementarparticipacionAjuez(TBP2A5);
                    incrementarparticipacionAjuez(TBP2A6);


                    //  }
                }
                else //Si son finales....
                {

                    totaljuecessolicitados = evento.P2FEjudges;
                    totaljuecessolicitados += evento.P2FAjudges;
                    totaljuecessolicitados += evento.P2FREjudges;
                    totaljuecessolicitados += evento.P2FRAjudges;
                    maxcat4Fjueces = 0;
                    switch (evento.P2FNoLimitCat4Judges)
                    {
                        case "Limited Cat 4 Judges":
                            {
                                maxcat4Fjueces = evento.P2FMaxCat4judges;
                            }
                            break;
                        case "Unlimited Cat 4 judges":
                            {
                                maxcat4Fjueces = 1000; //ponemos una cantidad que no se dará
                            }
                            break;
                        case "Without Cat 4 judges":
                            {
                                maxcat4Fjueces = 0;
                            }
                            break;

                    }
                    if (cat4 < 1 + maxcat4Fjueces)
                    {
                        cat4adescontar = 0;

                    }
                    else
                    {

                        cat4adescontar = cat4 - maxcat4Fjueces;
                    }
                    if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count() - cat4adescontar)
                    {
                        Panel2Warning.Text = "Not enough judges. We need " + totaljuecessolicitados.ToString() + " judges and we have " + (listajuecesdisponibles.Count() - cat4adescontar).ToString() + " judges.";
                        ImagewarningP2.Visibility = Visibility.Visible;

                    }
                    else
                    {
                        //comprobar que hay el número mínimo de paises. Dependiendo de si la selección es de sólo pa

                        switch (evento.P2F3Condition)
                        {
                            case "Randomized":
                                {
                                    //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                                    int paisescat123 = 0;
                                    int paisestotales = 0;
                                    int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                    int paises = 0;
                                    int paisessolicitados = 0;
                                    // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                    paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                    paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                    // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                    paisescat4 = paisestotales - paisescat123;
                                    // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                    if (paisescat4 > maxcat4Fjueces)
                                    {
                                        paisescat4 = maxcat4Fjueces;
                                    }
                                    paises = paisescat4 + paisescat123;
                                    if (evento.P2FNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                                    {
                                        if ((evento.P2FEjudges + evento.P2FREjudges) > (evento.P2FAjudges + evento.P2FRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                                        {
                                            paisessolicitados = evento.P2FEjudges + evento.P2FREjudges;
                                        }
                                        else
                                        {
                                            paisessolicitados = evento.P2FAjudges + evento.P2FRAjudges;
                                        }
                                    }
                                    else // si no se pueden repetir nacionalidades en el panel
                                    {
                                        paisessolicitados = totaljuecessolicitados;
                                    }
                                    if (paises < paisessolicitados)
                                    {
                                        Panel2Warning.Text = "Not enough countries for draw";
                                        ImagewarningP2.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        //seguimos con el sorteo
                                        Thread.Sleep(20);
                                        Random rnd = new Random((int)DateTime.Now.Ticks);

                                        int[] ordensorteorol = new int[12];

                                        int r, temp;
                                        r = 1;
                                        for (int i = 0; i < 12; i++)
                                        {
                                            ordensorteorol[i] = i;
                                        }
                                        for (int i = 12 - 1; i > -1; i--)
                                        {
                                            r = rnd.Next(1, 12);
                                            temp = ordensorteorol[r];
                                            ordensorteorol[r] = ordensorteorol[i];
                                            ordensorteorol[i] = temp;
                                        }

                                        for (int i = 0; i < 12; i++)
                                        {
                                            switch (ordensorteorol[i])
                                            {
                                                case 0:  // Sorteamos E1
                                                    if (evento.P2FEjudges > 0)
                                                    {
                                                        TBP2E1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 1:// Sorteamos E2
                                                    if (evento.P2FEjudges > 1)
                                                    {
                                                        TBP2E2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 2:// Sorteamos E3
                                                    if (evento.P2FEjudges > 2)
                                                    {
                                                        TBP2E3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 3:// Sorteamos E4
                                                    if (evento.P2FEjudges > 3)
                                                    {
                                                        TBP2E4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 4:// Sorteamos E5
                                                    if (evento.P2FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP2E5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 5:// Sorteamos E6
                                                    if (evento.P2FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP2E6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E6, listajuecesdisponibles);
                                                    }
                                                    break;

                                                case 6:// Sorteamos A1
                                                    if (evento.P2FAjudges > 0)
                                                    {
                                                        TBP2A1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 7:// Sorteamos A2
                                                    if (evento.P2FAjudges > 1)
                                                    {
                                                        TBP2A2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 8:// Sorteamos A3
                                                    if (evento.P2FAjudges > 2)
                                                    {
                                                        TBP2A3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 9:// Sorteamos A4
                                                    if (evento.P2FAjudges > 3)
                                                    {
                                                        TBP2A4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 10:// Sorteamos A5
                                                    if (evento.P2FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP2A5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 11:// Sorteamos A6
                                                    if (evento.P2FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP2A6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                                                    }
                                                    break;

                                            }
                                        }

                                        switch (evento.P2FREjudges)
                                        {
                                            case 1:
                                                TBP2RE.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }


                                        switch (evento.P2FRAjudges)
                                        {
                                            case 1:
                                                TBP2RA.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                break;
                            case "With finalists":
                                {
                                    //recorremos la lista de jueces disponibles eliminando los que NO son de la nacionalidad de la categoria de que se trata

                                    ObservableCollection<Juez> juecesaeliminar = new ObservableCollection<Juez>();
                                    ObservableCollection<Juez> juecesdisponiblesnacionalidadesreserva = new ObservableCollection<Juez>();

                                    FinalCountries fcount = eventfinalcountries.Where(x => x.CatModEx == horario[indicehorario].CatModExP2).FirstOrDefault();
                                    {
                                        foreach (Juez j in listajuecesdisponibles)
                                        {
                                            if (j.Country != fcount.Country1 && j.Country != fcount.Country2 && j.Country != fcount.Country3 && j.Country != fcount.Country4 && j.Country != fcount.Country5 && j.Country != fcount.Country6 && j.Country != fcount.Country7
                                                && j.Country != fcount.Country8 && j.Country != fcount.Country9 && j.Country != fcount.Country10 && j.Country != fcount.CountryR1 && j.Country != fcount.CountryR2)
                                            {
                                                juecesaeliminar.Add(j);
                                            }
                                        }

                                    }

                                    //recorremos la lista de jueces a eliminar y vamos eliminando de la lista de jueces disponibles


                                    foreach (Juez j in juecesaeliminar)
                                    {

                                        listajuecesdisponibles.Remove(j);

                                    }

                                    // hay que contar cuantas nacionalidades distintas nos exige la final

                                    int nacionalidadessolicitadas = 0;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country1) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country2) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country3) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country4) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country5) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country6) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country7) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country8) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country9) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.Country10) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.CountryR1) ? 0 : 1;
                                    nacionalidadessolicitadas += string.IsNullOrEmpty(fcount.CountryR2) ? 0 : 1;
                                    // contar cat 4
                                    cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();

                                    maxcat4Fjueces = 0;
                                    switch (evento.P2FNoLimitCat4Judges)
                                    {
                                        case "Limited Cat 4 Judges":
                                            {
                                                maxcat4Fjueces = evento.P2FMaxCat4judges;
                                            }
                                            break;
                                        case "Unlimited Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 1000; //ponemos una cantidad que no se dará
                                            }
                                            break;
                                        case "Without Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 0;
                                            }
                                            break;

                                    }
                                    if (cat4 < 1 + maxcat4Fjueces)
                                    {
                                        cat4adescontar = 0;

                                    }
                                    else
                                    {

                                        cat4adescontar = cat4 - maxcat4Fjueces;
                                    }

                                    if (totaljuecessolicitados + 1 > listajuecesdisponibles.Count() - cat4adescontar)
                                    {
                                        Panel2Warning.Text = "There are not enough judges";
                                        ImagewarningP2.Visibility = Visibility.Visible;

                                    }
                                    else
                                    {
                                        // revisar que hay jueces con nacionalidades suficientes teniendo en cuenta las restricciones de cat4 si existieran

                                        int paisescat123 = 0;
                                        int paisestotales = 0;
                                        int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                        int paises = 0;

                                        // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                        paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                        paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                                                                                                             // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                        paisescat4 = paisestotales - paisescat123;
                                        // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                        if (paisescat4 > maxcat4Fjueces)
                                        {
                                            paisescat4 = maxcat4Fjueces;
                                        }
                                        paises = paisescat4 + paisescat123;


                                        if (nacionalidadessolicitadas > paises)
                                        {
                                            Panel2Warning.Text = "There are not enough judges of the requested nationalities";
                                            ImagewarningP2.Visibility = Visibility.Visible;
                                        }
                                        else
                                        {
                                            //seguimos con el sorteo

                                            // gestionamos la lista de jueces de reserva, haciendo que sean lista aparte

                                                foreach (Juez j in listajuecesdisponibles)
                                                {
                                                    if (j.Country == fcount.CountryR1 || j.Country == fcount.CountryR2)
                                                    {
                                                        juecesdisponiblesnacionalidadesreserva.Add(j);
                                                    }
                                                }
                                                foreach (Juez j in juecesdisponiblesnacionalidadesreserva)
                                                {
                                                    if (j.Country == fcount.CountryR1 || j.Country == fcount.CountryR2)
                                                    {
                                                        listajuecesdisponibles.Remove(j);
                                                    }
                                                }




                                            Thread.Sleep(20);
                                            Random rnd = new Random((int)DateTime.Now.Ticks);

                                            int[] ordensorteorol = new int[12];

                                            int r, temp;
                                            r = 1;
                                            for (int i = 0; i < 12; i++)
                                            {
                                                ordensorteorol[i] = i;
                                            }
                                            for (int i = 12 - 1; i > -1; i--)
                                            {
                                                r = rnd.Next(1, 12);
                                                temp = ordensorteorol[r];
                                                ordensorteorol[r] = ordensorteorol[i];
                                                ordensorteorol[i] = temp;
                                            }

                                            for (int i = 0; i < 12; i++)
                                            {
                                                switch (ordensorteorol[i])
                                                {
                                                    case 0:  // Sorteamos E1
                                                        if (evento.P2FEjudges > 0)
                                                        {
                                                            TBP2E1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                            eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 1:// Sorteamos E2
                                                        if (evento.P2FEjudges > 1)
                                                        {
                                                            TBP2E2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                            eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 2:// Sorteamos E3
                                                        if (evento.P2FEjudges > 2)
                                                        {
                                                            TBP2E3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                            eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 3:// Sorteamos E4
                                                        if (evento.P2FEjudges > 3)
                                                        {
                                                            TBP2E4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 4:// Sorteamos E5
                                                        if (evento.P2FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                        {
                                                            TBP2E5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP2E5, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 5:// Sorteamos E6
                                                        if (evento.P2FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                        {
                                                            TBP2E6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP2E6, listajuecesdisponibles);
                                                        }
                                                        break;

                                                    case 6:// Sorteamos A1
                                                        if (evento.P2FAjudges > 0)
                                                        {
                                                            TBP2A1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                            eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 7:// Sorteamos A2
                                                        if (evento.P2FAjudges > 1)
                                                        {
                                                            TBP2A2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                            eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 8:// Sorteamos A3
                                                        if (evento.P2FAjudges > 2)
                                                        {
                                                            TBP2A3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                            eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 9:// Sorteamos A4
                                                        if (evento.P2FAjudges > 3)
                                                        {
                                                            TBP2A4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 10:// Sorteamos A5
                                                        if (evento.P2FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                        {
                                                            TBP2A5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                                                        }
                                                        break;
                                                    case 11:// Sorteamos A6
                                                        if (evento.P2FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                        {
                                                            TBP2A6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                            eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                                                        }
                                                        break;

                                                }
                                            }

                                            if (evento.P2FReserveContriesToReserveJudges == "Reserve judges only from reserve countries")
                                            {

                                                switch (evento.P2FREjudges)
                                                {
                                                    case 1:
                                                        TBP2RE.Text = buscarjuezmenorcategoriaEA(juecesdisponiblesnacionalidadesreserva, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                        eliminardelistadejuecesTB(TBP2RE, juecesdisponiblesnacionalidadesreserva);
                                                        break;
                                                    default:
                                                        break;
                                                }


                                                switch (evento.P2FRAjudges)
                                                {
                                                    case 1:
                                                        TBP2RA.Text = buscarjuezmenorcategoriaEA(juecesdisponiblesnacionalidadesreserva, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                        eliminardelistadejuecesTB(TBP2RA, juecesdisponiblesnacionalidadesreserva);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                switch (evento.P2FREjudges)
                                                {
                                                    case 1:
                                                        TBP2RE.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                        eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                                                        break;
                                                    default:
                                                        break;
                                                }


                                                switch (evento.P2FRAjudges)
                                                {
                                                    case 1:
                                                        TBP2RA.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                        eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }


                                        }

                                    }
                                }

                                break;
                            case "Without finalists":
                                {
                                    //recorremos la lista de jueces disponibles eliminando los que SI son de la nacionalidad de la categoria de que se trata

                                    ObservableCollection<Juez> juecesaeliminarwof = new ObservableCollection<Juez>();

                                    FinalCountries fc = eventfinalcountries.Where(x => x.CatModEx == horario[indicehorario].CatModExP2).FirstOrDefault();
                                    {
                                        foreach (Juez j in listajuecesdisponibles)
                                        {
                                            if (j.Country == fc.Country1 || j.Country == fc.Country2 || j.Country == fc.Country3 || j.Country == fc.Country4 || j.Country == fc.Country5 || j.Country == fc.Country6 || j.Country == fc.Country7
                                                || j.Country == fc.Country8 || j.Country == fc.Country9 || j.Country == fc.Country10 || j.Country == fc.CountryR1 || j.Country == fc.CountryR2)
                                            {
                                                juecesaeliminarwof.Add(j);

                                            }
                                        }

                                    }


                                    foreach (Juez j in juecesaeliminarwof)
                                    {

                                        listajuecesdisponibles.Remove(j);

                                    }

                                    //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                                    int paisescat123 = 0;
                                    int paisestotales = 0;
                                    int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                    int paises = 0;
                                    int paisessolicitados = 0;
                                    // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                    paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                    paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                    // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                    paisescat4 = paisestotales - paisescat123;
                                    // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                    cat4 = listajuecesdisponibles.Where(x => x.Category == 4).Count();
                                    maxcat4Fjueces = 0;
                                    switch (evento.P2FNoLimitCat4Judges)
                                    {
                                        case "Limited Cat 4 Judges":
                                            {
                                                maxcat4Fjueces = evento.P2FMaxCat4judges;
                                            }
                                            break;
                                        case "Unlimited Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 1000; //ponemos una cantidad que no se dará
                                            }
                                            break;
                                        case "Without Cat 4 judges":
                                            {
                                                maxcat4Fjueces = 0;
                                            }
                                            break;

                                    }
                                    if (paisescat4 > maxcat4Fjueces)
                                    {
                                        paisescat4 = maxcat4Fjueces;
                                    }
                                    paises = paisescat4 + paisescat123;
                                    if (evento.P2FNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                                    {
                                        if ((evento.P2FEjudges + evento.P2FREjudges) > (evento.P2FAjudges + evento.P2FRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                                        {
                                            paisessolicitados = evento.P2FEjudges + evento.P2FREjudges;
                                        }
                                        else
                                        {
                                            paisessolicitados = evento.P2FAjudges + evento.P2FRAjudges;
                                        }
                                    }
                                    else // si no se pueden repetir nacionalidades en el panel
                                    {
                                        paisessolicitados = totaljuecessolicitados;
                                    }
                                    if (paises < paisessolicitados)
                                    {
                                        Panel2Warning.Text = "There are not enough judges of the requested nationalities";
                                        ImagewarningP2.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        //seguimos con el sorteo
                                        Thread.Sleep(20);
                                        Random rnd = new Random((int)DateTime.Now.Ticks);

                                        int[] ordensorteorol = new int[12];

                                        int r, temp;
                                        r = 1;
                                        for (int i = 0; i < 12; i++)
                                        {
                                            ordensorteorol[i] = i;
                                        }
                                        for (int i = 12 - 1; i > -1; i--)
                                        {
                                            r = rnd.Next(1, 12);
                                            temp = ordensorteorol[r];
                                            ordensorteorol[r] = ordensorteorol[i];
                                            ordensorteorol[i] = temp;
                                        }

                                        for (int i = 0; i < 12; i++)
                                        {
                                            switch (ordensorteorol[i])
                                            {
                                                case 0:  // Sorteamos E1
                                                    if (evento.P2FEjudges > 0)
                                                    {
                                                        TBP2E1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 1:// Sorteamos E2
                                                    if (evento.P2FEjudges > 1)
                                                    {
                                                        TBP2E2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 2:// Sorteamos E3
                                                    if (evento.P2FEjudges > 2)
                                                    {
                                                        TBP2E3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 3:// Sorteamos E4
                                                    if (evento.P2FEjudges > 3)
                                                    {
                                                        TBP2E4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 4:// Sorteamos E5
                                                    if (evento.P2FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP2E5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 5:// Sorteamos E6
                                                    if (evento.P2FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP2E6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E6, listajuecesdisponibles);
                                                    }
                                                    break;

                                                case 6:// Sorteamos A1
                                                    if (evento.P2FAjudges > 0)
                                                    {
                                                        TBP2A1.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 7:// Sorteamos A2
                                                    if (evento.P2FAjudges > 1)
                                                    {
                                                        TBP2A2.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 8:// Sorteamos A3
                                                    if (evento.P2FAjudges > 2)
                                                    {
                                                        TBP2A3.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 9:// Sorteamos A4
                                                    if (evento.P2FAjudges > 3)
                                                    {
                                                        TBP2A4.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 10:// Sorteamos A5
                                                    if (evento.P2FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP2A5.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 11:// Sorteamos A6
                                                    if (evento.P2FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP2A6.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                                                    }
                                                    break;

                                            }
                                        }

                                        switch (evento.P2FREjudges)
                                        {
                                            case 1:
                                                TBP2RE.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }


                                        switch (evento.P2FRAjudges)
                                        {
                                            case 1:
                                                TBP2RA.Text = buscarjuezmenorcategoriaEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }



                                    }

                                }

                                break;
                            case "Randomized based on least amount of sessions judged":
                                {
                                    //comprobar que hay el número mínimo de paises. se necesitan tantos paises distintos como jueces en total para no tener paises repetidos en el panel y 4 para no tenerlos en el rol

                                    int paisescat123 = 0;
                                    int paisestotales = 0;
                                    int paisescat4 = 0; //son nacionalidades representadas sólo por jueces cat 4
                                    int paises = 0;
                                    int paisessolicitados = 0;
                                    // son los paises distintos de jueces de Cat 1,2,3 más los permitidos de cat 4
                                    paisescat123 = Valores_unicos_CountryList(listajuecesdisponibles.Where(x => x.Category < 4).ToList()).Count(); // nacionalidades distintas categorias 1,2,3
                                    paisestotales = Valores_unicos_CountryList(listajuecesdisponibles.ToList()).Count(); // total nacionalidades distintas
                                    // tenemos que averiguar cuanto contribuyen a las nacionalidades distintas los cat 4 por si, debido al límite, no pudiésemos contar con todos.
                                    paisescat4 = paisestotales - paisescat123;
                                    // si las nacionalidades cat 4 > son mayores que los permitidos, hay que contar sólo con el número máximo de cat 4 permitidos
                                    if (paisescat4 > maxcat4Fjueces)
                                    {
                                        paisescat4 = maxcat4Fjueces;
                                    }
                                    paises = paisescat4 + paisescat123;
                                    if (evento.P2FNoSameCountryInSame == "With No same country in same role") //pueden repetirse paises en distinto rol
                                    {
                                        if ((evento.P2FEjudges + evento.P2FREjudges) > (evento.P2FAjudges + evento.P2FRAjudges)) // buscamos el mayor número de jueces en roles distintos y este es el número maximo de nacionalidades necesarias
                                        {
                                            paisessolicitados = evento.P2FEjudges + evento.P2FREjudges;
                                        }
                                        else
                                        {
                                            paisessolicitados = evento.P2FAjudges + evento.P2FRAjudges;
                                        }
                                    }
                                    else // si no se pueden repetir nacionalidades en el panel
                                    {
                                        paisessolicitados = totaljuecessolicitados;
                                    }
                                    if (paises < paisessolicitados)
                                    {
                                        Panel2Warning.Text = "Not enough countries for draw";
                                        ImagewarningP2.Visibility = Visibility.Visible;
                                    }
                                    else
                                    {
                                        //seguimos con el sorteo
                                        Thread.Sleep(20);
                                        Random rnd = new Random((int)DateTime.Now.Ticks);

                                        int[] ordensorteorol = new int[12];

                                        int r, temp;
                                        r = 1;
                                        for (int i = 0; i < 12; i++)
                                        {
                                            ordensorteorol[i] = i;
                                        }
                                        for (int i = 12 - 1; i > -1; i--)
                                        {
                                            r = rnd.Next(1, 12);
                                            temp = ordensorteorol[r];
                                            ordensorteorol[r] = ordensorteorol[i];
                                            ordensorteorol[i] = temp;
                                        }

                                        for (int i = 0; i < 12; i++)
                                        {
                                            switch (ordensorteorol[i])
                                            {
                                                case 0:  // Sorteamos E1
                                                    if (evento.P2FEjudges > 0)
                                                    {
                                                        TBP2E1.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP2E1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 1:// Sorteamos E2
                                                    if (evento.P2FEjudges > 1)
                                                    {
                                                        TBP2E2.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP2E2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 2:// Sorteamos E3
                                                    if (evento.P2FEjudges > 2)
                                                    {
                                                        TBP2E3.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP2E3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 3:// Sorteamos E4
                                                    if (evento.P2FEjudges > 3)
                                                    {
                                                        TBP2E4.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 4:// Sorteamos E5
                                                    if (evento.P2FEjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP2E5.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 5:// Sorteamos E6
                                                    if (evento.P2FEjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesE) ? 0 : int.Parse(evento.MaxJuecesE)) == 6)
                                                    {
                                                        TBP2E6.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2E6, listajuecesdisponibles);
                                                    }
                                                    break;

                                                case 6:// Sorteamos A1
                                                    if (evento.P2FAjudges > 0)
                                                    {
                                                        TBP2A1.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 1);
                                                        eliminardelistadejuecesTB(TBP2A1, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 7:// Sorteamos A2
                                                    if (evento.P2FAjudges > 1)
                                                    {
                                                        TBP2A2.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 2);
                                                        eliminardelistadejuecesTB(TBP2A2, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 8:// Sorteamos A3
                                                    if (evento.P2FAjudges > 2)
                                                    {
                                                        TBP2A3.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 3);
                                                        eliminardelistadejuecesTB(TBP2A3, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 9:// Sorteamos A4
                                                    if (evento.P2FAjudges > 3)
                                                    {
                                                        TBP2A4.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A4, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 10:// Sorteamos A5
                                                    if (evento.P2FAjudges > 4 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP2A5.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A5, listajuecesdisponibles);
                                                    }
                                                    break;
                                                case 11:// Sorteamos A6
                                                    if (evento.P2FAjudges > 5 && (string.IsNullOrEmpty(evento.MaxJuecesA) ? 0 : int.Parse(evento.MaxJuecesA)) == 6)
                                                    {
                                                        TBP2A6.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 4);
                                                        eliminardelistadejuecesTB(TBP2A6, listajuecesdisponibles);
                                                    }
                                                    break;

                                            }
                                        }

                                        switch (evento.P2FREjudges)
                                        {
                                            case 1:
                                                TBP2RE.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "E", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 5);
                                                eliminardelistadejuecesTB(TBP2RE, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }


                                        switch (evento.P2FRAjudges)
                                        {
                                            case 1:
                                                TBP2RA.Text = BuscarjuezmenorcategoriayparticipacionFinalesEA(listajuecesdisponibles, "A", 2, evento.P2FNoSameCountryInSame, maxcat4Fjueces, 6);
                                                eliminardelistadejuecesTB(TBP2RA, listajuecesdisponibles);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                                break;
                        }



                    }

                    incrementarparticipacionFEjuez(TBP2E1);
                    incrementarparticipacionFEjuez(TBP2E2);
                    incrementarparticipacionFEjuez(TBP2E3);
                    incrementarparticipacionFEjuez(TBP2E4);
                    incrementarparticipacionFEjuez(TBP2E5);
                    incrementarparticipacionFEjuez(TBP2E6);

                    incrementarparticipacionFAjuez(TBP2A1);
                    incrementarparticipacionFAjuez(TBP2A2);
                    incrementarparticipacionFAjuez(TBP2A3);
                    incrementarparticipacionFAjuez(TBP2A4);
                    incrementarparticipacionFAjuez(TBP2A5);
                    incrementarparticipacionFAjuez(TBP2A6);






                }

            }
            actualizarresumenpaneles(2);

            //guardar las condiciones de sorteo

            // MALLLLL HAY QUE MOSTRAR PRIMERO LOS SETTING Y LUEGO GUARDARLOS
            LBESTP2Draw.Content = string.IsNullOrEmpty(evento.P2FEjudges.ToString()) ? "0" : evento.P2FEjudges.ToString();
            LBASTP2Draw.Content = string.IsNullOrEmpty(evento.P2FAjudges.ToString()) ? "0" : evento.P2FAjudges.ToString();
            LBRESTP2Draw.Content = string.IsNullOrEmpty(evento.P2FREjudges.ToString()) ? "0" : evento.P2FREjudges.ToString();
            LBRASTP2Draw.Content = string.IsNullOrEmpty(evento.P2FRAjudges.ToString()) ? "0" : evento.P2FRAjudges.ToString();
            LBC4STP2Draw.Content = string.IsNullOrEmpty(evento.P2FMaxCat4judges.ToString()) ? "0" : evento.P2FMaxCat4judges.ToString();

            TBCondicion1P2.Text = string.IsNullOrEmpty(evento.P2F3Condition) ? "" : evento.P2F3Condition;
            TBCondicion2P2.Text = string.IsNullOrEmpty(evento.P2FNoSameCountryInSame) ? "" : evento.P2FNoSameCountryInSame;
            TBCondicion3P2.Text = string.IsNullOrEmpty(evento.P2FReserveContriesToReserveJudges) ? "" : evento.P2FReserveContriesToReserveJudges;
            TBCondicion4P2.Text = string.IsNullOrEmpty(evento.P2FNoLimitCat4Judges) ? "" : evento.P2FNoLimitCat4Judges;


            horario[indicehorario].SettingsP2EJudges = string.IsNullOrEmpty(evento.P2FEjudges.ToString()) ? 0 : evento.P2FEjudges;
            horario[indicehorario].SettingsP2AJudges = string.IsNullOrEmpty(evento.P2FAjudges.ToString()) ? 0 : evento.P2FAjudges;
            horario[indicehorario].SettingsP2REJudges = string.IsNullOrEmpty(evento.P2FREjudges.ToString()) ? 0 : evento.P2FREjudges;
            horario[indicehorario].SettingsP2RAJudges = string.IsNullOrEmpty(evento.P2FRAjudges.ToString()) ? 0 : evento.P2FRAjudges;
            horario[indicehorario].SettingsP2C4Judges = string.IsNullOrEmpty(evento.P2FMaxCat4judges.ToString()) ? 0 : evento.P2FMaxCat4judges;

            horario[indicehorario].SettingsP2Condition1 = string.IsNullOrEmpty(evento.P2F3Condition) ? "" : evento.P2F3Condition;
            horario[indicehorario].SettingsP2Condition2 = string.IsNullOrEmpty(evento.P2FNoSameCountryInSame) ? "" : evento.P2FNoSameCountryInSame;
            horario[indicehorario].SettingsP2Condition3 = string.IsNullOrEmpty(evento.P2FReserveContriesToReserveJudges) ? "" : evento.P2FReserveContriesToReserveJudges;
            horario[indicehorario].SettingsP2Condition4 = string.IsNullOrEmpty(evento.P2FNoLimitCat4Judges) ? "" : evento.P2FNoLimitCat4Judges;

            JuecesDataGrid.Items.Refresh();

            GuardarJuecesHorarioP2(indicehorario);
        }
        private void GuardarJuecesHorarioP1(int ind)
        {
            horario[ind].A1JudgeP1 = string.IsNullOrEmpty(TBP1A1.Text) ? 0 : int.Parse(TBP1A1.Text);
            horario[ind].A2JudgeP1 = string.IsNullOrEmpty(TBP1A2.Text) ? 0 : int.Parse(TBP1A2.Text);
            horario[ind].A3JudgeP1 = string.IsNullOrEmpty(TBP1A3.Text) ? 0 : int.Parse(TBP1A3.Text);
            horario[ind].A4JudgeP1 = string.IsNullOrEmpty(TBP1A4.Text) ? 0 : int.Parse(TBP1A4.Text);
            horario[ind].A5JudgeP1 = string.IsNullOrEmpty(TBP1A5.Text) ? 0 : int.Parse(TBP1A5.Text);
            horario[ind].A6JudgeP1 = string.IsNullOrEmpty(TBP1A6.Text) ? 0 : int.Parse(TBP1A6.Text);
            horario[ind].E1JudgeP1 = string.IsNullOrEmpty(TBP1E1.Text) ? 0 : int.Parse(TBP1E1.Text);
            horario[ind].E2JudgeP1 = string.IsNullOrEmpty(TBP1E2.Text) ? 0 : int.Parse(TBP1E2.Text);
            horario[ind].E3JudgeP1 = string.IsNullOrEmpty(TBP1E3.Text) ? 0 : int.Parse(TBP1E3.Text);
            horario[ind].E4JudgeP1 = string.IsNullOrEmpty(TBP1E4.Text) ? 0 : int.Parse(TBP1E4.Text);
            horario[ind].E5JudgeP1 = string.IsNullOrEmpty(TBP1E5.Text) ? 0 : int.Parse(TBP1E5.Text);
            horario[ind].E6JudgeP1 = string.IsNullOrEmpty(TBP1E6.Text) ? 0 : int.Parse(TBP1E6.Text);

            horario[ind].REJudgeP1 = string.IsNullOrEmpty(TBP1RE.Text) ? 0 : int.Parse(TBP1RE.Text);
            horario[ind].RAJudgeP1 = string.IsNullOrEmpty(TBP1RA.Text) ? 0 : int.Parse(TBP1RA.Text);
        }

        private void GuardarJuecesHorarioP2(int ind)
        {
            horario[ind].A1JudgeP2 = string.IsNullOrEmpty(TBP2A1.Text) ? 0 : int.Parse(TBP2A1.Text);
            horario[ind].A2JudgeP2 = string.IsNullOrEmpty(TBP2A2.Text) ? 0 : int.Parse(TBP2A2.Text);
            horario[ind].A3JudgeP2 = string.IsNullOrEmpty(TBP2A3.Text) ? 0 : int.Parse(TBP2A3.Text);
            horario[ind].A4JudgeP2 = string.IsNullOrEmpty(TBP2A4.Text) ? 0 : int.Parse(TBP2A4.Text);
            horario[ind].A5JudgeP2 = string.IsNullOrEmpty(TBP2A5.Text) ? 0 : int.Parse(TBP2A5.Text);
            horario[ind].A6JudgeP2 = string.IsNullOrEmpty(TBP2A6.Text) ? 0 : int.Parse(TBP2A6.Text);
            horario[ind].E1JudgeP2 = string.IsNullOrEmpty(TBP2E1.Text) ? 0 : int.Parse(TBP2E1.Text);
            horario[ind].E2JudgeP2 = string.IsNullOrEmpty(TBP2E2.Text) ? 0 : int.Parse(TBP2E2.Text);
            horario[ind].E3JudgeP2 = string.IsNullOrEmpty(TBP2E3.Text) ? 0 : int.Parse(TBP2E3.Text);
            horario[ind].E4JudgeP2 = string.IsNullOrEmpty(TBP2E4.Text) ? 0 : int.Parse(TBP2E4.Text);
            horario[ind].E5JudgeP2 = string.IsNullOrEmpty(TBP2E5.Text) ? 0 : int.Parse(TBP2E5.Text);
            horario[ind].E6JudgeP2 = string.IsNullOrEmpty(TBP2E6.Text) ? 0 : int.Parse(TBP2E6.Text);
            horario[ind].REJudgeP2 = string.IsNullOrEmpty(TBP2RE.Text) ? 0 : int.Parse(TBP2RE.Text);
            horario[ind].RAJudgeP2 = string.IsNullOrEmpty(TBP2RA.Text) ? 0 : int.Parse(TBP2RA.Text);
        }

        private void guardarjuecesTLI(int ind)
        {
            horario[ind].TJudgeP2 = string.IsNullOrEmpty(TBP2T1.Text) ? 0 : int.Parse(TBP2T1.Text);
            horario[ind].TJudgeP1 = string.IsNullOrEmpty(TBP1T1.Text) ? 0 : int.Parse(TBP1T1.Text);
            horario[ind].L1Judge = string.IsNullOrEmpty(TBL1.Text) ? 0 : int.Parse(TBL1.Text);
            horario[ind].L2Judge = string.IsNullOrEmpty(TBL2.Text) ? 0 : int.Parse(TBL2.Text);
            horario[ind].INQJudge = string.IsNullOrEmpty(TBINQ.Text) ? 0 : int.Parse(TBINQ.Text);
        }

        private void limpiar_asginaciones_jueces()
        {
            // En principio se limita a poner a 0 el textbox de cada juez del panel. Las banderas simplemente se ocultan haciendo que no sean visibles
            // Al limpiar habría que hacer el proceso de borrado de total de participaciones de ese juez antes de eliminarlo.

            limpiar_asginaciones_juecesP1();
            limpiar_asginaciones_juecesP2();
            limpiar_asginaciones_juecesLTI();
        }

        private void cargarlineahorario()
        {
            try
            {
                Panel1Draw.IsEnabled = false;
                Panel2Draw.IsEnabled = false;
                //  limpiar_asginaciones_jueces();
                // Se cargan datos de CPD, Ds,Linea tiempo apelacion y los familiares informados de ese panel
                TBP1CPJ.Text = jueces.Where(x => x.JudgeName == evento.CPJP1).FirstOrDefault().ID.ToString();
                TBP1D1.Text = "0";
                TBP1D2.Text = "0";

                TBP2CPJ.Text = jueces.Where(x => x.JudgeName == evento.CPJP2).FirstOrDefault().ID.ToString();
                TBP2D1.Text = "0";
                TBP2D2.Text = "0";

                TBP2T1.Text = horario[indicehorario].TJudgeP2.ToString();
                TBP1T1.Text = horario[indicehorario].TJudgeP1.ToString();
                TBL1.Text = horario[indicehorario].L1Judge.ToString();
                TBL2.Text = horario[indicehorario].L2Judge.ToString();
                TBINQ.Text = horario[indicehorario].INQJudge.ToString();

                SessionN.Content = "Session " + horario[indicehorario].SessionNumber;

                if (!string.IsNullOrEmpty(horario[indicehorario].CatModExP1))
                {
                    Panel1Draw.IsEnabled = true;
                    if (!string.IsNullOrEmpty(horario[indicehorario].SessionDate) && !string.IsNullOrEmpty(horario[indicehorario].SessionDay))
                    {
                        LBFecha.Content = horario[indicehorario].SessionDate;
                        LBDia.Content = " Day "+horario[indicehorario].SessionDay; 
                        LBHorario.Content=" " + DateTime.Parse(horario[indicehorario].SessionDate).ToString("dddd", CultureInfo.CreateSpecificCulture("en-US"));
                    }
                    //  TBP1D1.Text= (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1,"D1")).GetValue(evento);
                    LBSesion.Content = "Session " + horario[indicehorario].SessionNumber;
                    LBHora.Content = " " + horario[indicehorario].SessionTime;
                    CompeticionCategoriaHorarioP1.Content = horario[indicehorario].CompetitionP1 + " " + categoria(horario[indicehorario].CatModExP1);
                    CategoriaModalidadEjercicioCompeticionP1.Content = categoria(horario[indicehorario].CatModExP1) + " " + modalidad(horario[indicehorario].CatModExP1) + "    " + ejercicio(horario[indicehorario].CatModExP1) + " " + horario[indicehorario].CompetitionP1;
                    if (!string.IsNullOrEmpty((string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1, "D1")).GetValue(evento)))
                    {
                        TBP1D1.Text = string.IsNullOrEmpty(jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1, "D1")).GetValue(evento)).FirstOrDefault().ID.ToString()) ? "0" : jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1, "D1")).GetValue(evento)).FirstOrDefault().ID.ToString(); //string.IsNullOrEmpty(CBp1QEjudges.Text) ? 0 : int.Parse(CBp1QEjudges.Text);
                    }
                    if (!string.IsNullOrEmpty((string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1, "D2")).GetValue(evento)))
                    {
                        TBP1D2.Text = string.IsNullOrEmpty(jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1, "D2")).GetValue(evento)).FirstOrDefault().ID.ToString()) ? "0" : jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP1, "D2")).GetValue(evento)).FirstOrDefault().ID.ToString(); //string.IsNullOrEmpty(CBp1QEjudges.Text) ? 0 : int.Parse(CBp1QEjudges.Text);
                    }
                    TBP1E1.Text = horario[indicehorario].E1JudgeP1.ToString();
                    TBP1E2.Text = horario[indicehorario].E2JudgeP1.ToString();
                    TBP1E3.Text = horario[indicehorario].E3JudgeP1.ToString();
                    TBP1E4.Text = horario[indicehorario].E4JudgeP1.ToString();
                    TBP1E5.Text = horario[indicehorario].E5JudgeP1.ToString();
                    TBP1E6.Text = horario[indicehorario].E6JudgeP1.ToString();
                    TBP1A1.Text = horario[indicehorario].A1JudgeP1.ToString();
                    TBP1A2.Text = horario[indicehorario].A2JudgeP1.ToString();
                    TBP1A3.Text = horario[indicehorario].A3JudgeP1.ToString();
                    TBP1A4.Text = horario[indicehorario].A4JudgeP1.ToString();
                    TBP1A5.Text = horario[indicehorario].A5JudgeP1.ToString();
                    TBP1A6.Text = horario[indicehorario].A6JudgeP1.ToString();
                    TBP1RE.Text = horario[indicehorario].REJudgeP1.ToString();
                    TBP1RA.Text = horario[indicehorario].RAJudgeP1.ToString();
                    //vaciar Relatives P1
                    for (int i = relativesP1.Count - 1; i >= 0; i--)
                    {

                        relativesP1.RemoveAt(i);
                    }
                    foreach (Relative r in relatives.Where(x => x.CatMod == categoria(horario[indicehorario].CatModExP1) + " " + modalidad(horario[indicehorario].CatModExP1)))
                    {
                        relativesP1.Add(r);
                    }

                    DGRelativesP1.ItemsSource = relativesP1;

                    //actualizar resumen del panel 1
                    Panel1Cat1Enumjudges.Content = "0";
                    Panel1Cat2Enumjudges.Content = "0";
                    Panel1Cat3Enumjudges.Content = "0";
                    Panel1Cat4Enumjudges.Content = "0";
                    Panel1Cat1Anumjudges.Content = "0";
                    Panel1Cat2Anumjudges.Content = "0";
                    Panel1Cat3Anumjudges.Content = "0";
                    Panel1Cat4Anumjudges.Content = "0";
                    Panel1EAvgjudges.Content = "0";
                    Panel1AAvgjudges.Content = "0";

                    Panel1Warning.Text = "";
                    ImagewarningP1.Visibility = Visibility.Collapsed;
                    actualizarresumenpaneles(1);

                }

                if (!string.IsNullOrEmpty(horario[indicehorario].CatModExP2))
                {
                    Panel2Draw.IsEnabled = true;
                    if (!string.IsNullOrEmpty(horario[indicehorario].SessionDate) && !string.IsNullOrEmpty(horario[indicehorario].SessionDay))
                    {
                        LBFecha.Content = horario[indicehorario].SessionDate;
                        LBDia.Content = " Day " + horario[indicehorario].SessionDay;
                        LBHorario.Content = " " + DateTime.Parse(horario[indicehorario].SessionDate).ToString("dddd", CultureInfo.CreateSpecificCulture("en-US"));
                    }
                    LBSesion.Content = "Session " + horario[indicehorario].SessionNumber;
                    LBHora.Content = " " + horario[indicehorario].SessionTime;
                 
                    CompeticionCategoriaHorarioP2.Content = horario[indicehorario].CompetitionP2 + " " + categoria(horario[indicehorario].CatModExP2);
                    CategoriaModalidadEjercicioCompeticionP2.Content = categoria(horario[indicehorario].CatModExP2) + " " + modalidad(horario[indicehorario].CatModExP2) + "    " + ejercicio(horario[indicehorario].CatModExP2) + " " + horario[indicehorario].CompetitionP2;
                    if (!string.IsNullOrEmpty((string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP2, "D1")).GetValue(evento)))
                    {
                        TBP2D1.Text = string.IsNullOrEmpty(jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP2, "D1")).GetValue(evento)).FirstOrDefault().ID.ToString()) ? "0" : jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP2, "D1")).GetValue(evento)).FirstOrDefault().ID.ToString(); //string.IsNullOrEmpty(CBp1QEjudges.Text) ? 0 : int.Parse(CBp1QEjudges.Text);
                    }
                    if (!string.IsNullOrEmpty((string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP2, "D2")).GetValue(evento)))
                    {
                        TBP2D2.Text = string.IsNullOrEmpty(jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP2, "D2")).GetValue(evento)).FirstOrDefault().ID.ToString()) ? "0" : jueces.Where(x => x.JudgeName == (string)evento.GetType().GetProperty(catmodexprop(horario[indicehorario].CatModExP2, "D2")).GetValue(evento)).FirstOrDefault().ID.ToString(); //string.IsNullOrEmpty(CBp1QEjudges.Text) ? 0 : int.Parse(CBp1QEjudges.Text);
                    }
                    TBP2E1.Text = horario[indicehorario].E1JudgeP2.ToString();
                    TBP2E2.Text = horario[indicehorario].E2JudgeP2.ToString();
                    TBP2E3.Text = horario[indicehorario].E3JudgeP2.ToString();
                    TBP2E4.Text = horario[indicehorario].E4JudgeP2.ToString();
                    TBP2E5.Text = horario[indicehorario].E5JudgeP2.ToString();
                    TBP2E6.Text = horario[indicehorario].E6JudgeP2.ToString();
                    TBP2A1.Text = horario[indicehorario].A1JudgeP2.ToString();
                    TBP2A2.Text = horario[indicehorario].A2JudgeP2.ToString();
                    TBP2A3.Text = horario[indicehorario].A3JudgeP2.ToString();
                    TBP2A4.Text = horario[indicehorario].A4JudgeP2.ToString();
                    TBP2A5.Text = horario[indicehorario].A5JudgeP2.ToString();
                    TBP2A6.Text = horario[indicehorario].A6JudgeP2.ToString();
                    TBP2RE.Text = horario[indicehorario].REJudgeP2.ToString();
                    TBP2RA.Text = horario[indicehorario].RAJudgeP2.ToString();
                    //vaciar Relatives P2
                    for (int i = relativesP2.Count - 1; i >= 0; i--)
                    {

                        relativesP2.RemoveAt(i);
                    }
                    foreach (Relative r in relatives.Where(x => x.CatMod == categoria(horario[indicehorario].CatModExP2) + " " + modalidad(horario[indicehorario].CatModExP2)))
                    {
                        relativesP2.Add(r);
                    }

                    DGRelativesP2.ItemsSource = relativesP2;
                    //actualizar resumen panel 2
                    Panel2Cat1Enumjudges.Content = "0";
                    Panel2Cat2Enumjudges.Content = "0";
                    Panel2Cat3Enumjudges.Content = "0";
                    Panel2Cat4Enumjudges.Content = "0";
                    Panel2Cat1Anumjudges.Content = "0";
                    Panel2Cat2Anumjudges.Content = "0";
                    Panel2Cat3Anumjudges.Content = "0";
                    Panel2Cat4Anumjudges.Content = "0";
                    Panel2EAvgjudges.Content = "0";
                    Panel2AAvgjudges.Content = "0";

                    Panel2Warning.Text = "";
                    ImagewarningP2.Visibility = Visibility.Collapsed;
                    actualizarresumenpaneles(2);
                }
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom("Linea 4805. " + ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
        }

        private string modalidad(string catmodej)
        {
            string[] cadena;
            cadena = catmodej.Split(' ');
            return cadena[1];

            //  Where(x => x.JudgeName == lista[0].MG1116BALD1).FirstOrDefault();
        }

        private string categoria(string catmodej)
        {
            string[] cadena;
            cadena = catmodej.Split(' ');
            return cadena[0];

            //  Where(x => x.JudgeName == lista[0].MG1116BALD1).FirstOrDefault();
        }
        private string catmodexprop(string catmodej, string juezd)
        { // obtiene el nombre de la propiedad de la clase WP1116BALD1 evento a partir de la cadena 
            string[] cadena;
            cadena = catmodej.Split(' ');
            string cat = cadena[0];
            if (cat == "11-16" || cat == "12-18" || cat == "13-19")
            {
                cat = cat.Remove(2, 1);//quitamos el guión

            }
            return cadena[1] + cat + cadena[2] + juezd; //modalidad+categoria(singuion)

            //  Where(x => x.JudgeName == lista[0].MG1116BALD1).FirstOrDefault();
        }


        private string ejercicio(string catmodej)
        {
            string[] cadena;
            cadena = catmodej.Split(' ');
            return cadena[2];

            //  Where(x => x.JudgeName == lista[0].MG1116BALD1).FirstOrDefault();
        }

        private void Atras_Click(object sender, RoutedEventArgs e)
        {
            if (indicehorario - 1 < 0)
            {
                MessageBox.Show("This is the firt session.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                GuardarJuecesHorarioP1(indicehorario);
                GuardarJuecesHorarioP2(indicehorario);
                guardarjuecesTLI(indicehorario);

                indicehorario--;
                cargarlineahorario();
            }
        }
        private void Adelante_Click(object sender, RoutedEventArgs e)
        {
            if (indicehorario + 1 > horario.Count() - 1)
            {

                MessageBox.Show("This is the last session.No more sessions were found in the schedule.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                GuardarJuecesHorarioP1(indicehorario);
                GuardarJuecesHorarioP2(indicehorario);
                guardarjuecesTLI(indicehorario);
                indicehorario++;
                cargarlineahorario();

            }


        }
        private void cargareventoendraw()
        {
            if (string.IsNullOrEmpty(evento.Event_logo))
            {


            }
            else
            {

                BitmapImage bi3 = new BitmapImage();
                try
                {
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(evento.Event_logo, UriKind.Absolute);
                    bi3.EndInit();
                    IMGLogoEvento.Source = bi3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A handled exception just occurred with the event logo: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void ResetWarnings_Click(object sender, RoutedEventArgs e)
        {
            bool? Result = new MessageBoxCustom("Are you sure?", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                foreach (Juez j in JuecesDataGrid.ItemsSource)
                {
                    j.Warning = false;
                }
                JuecesDataGrid.Items.Refresh();
            }
        }

        private void GridDraw_GotFocus(object sender, RoutedEventArgs e)
        {

            //  cargarlineahorario();
        }

        private void LimpiarDrawP1_Click_1(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure ?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                limpiar_asginaciones_juecesP1();
                GuardarJuecesHorarioP1(indicehorario);
            }
        }

        private void LimpiarDrawP2_Click_1(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure ?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                limpiar_asginaciones_juecesP2();
                GuardarJuecesHorarioP2(indicehorario);
            }
        }

        private void ScheduleDataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // Only act on Commit

            if (e.EditAction == DataGridEditAction.Commit)

            {
                LineaHorario lihor = e.Row.DataContext as LineaHorario;

                // por cada nuevo item se revisa si es final y si hay una línea en finals countries con la categoría de la final
                if (lihor.CompetitionP1 == "FINAL")
                {
                    if (eventfinalcountries.Where(x => x.CatModEx == lihor.CatModExP1).Count() == 0)
                    {
                        FinalCountries nuevofc = new FinalCountries();
                        nuevofc.CatModEx = lihor.CatModExP1;
                        eventfinalcountries.Add(nuevofc);
                    }
                }
                if (lihor.CompetitionP2 == "FINAL")
                {
                    if (eventfinalcountries.Where(x => x.CatModEx == lihor.CatModExP2).Count() == 0)
                    {
                        FinalCountries nuevofc = new FinalCountries();
                        nuevofc.CatModEx = lihor.CatModExP2;
                        eventfinalcountries.Add(nuevofc);
                    }

                }


            }
        }
        private void RestablecerConteoParticipacionesJueces()
        {
            //Recorrer el horario, y por cada línea de horario, establecer el conteo de jueces
            TextBox tb = new TextBox();
            foreach (LineaHorario linhor in horario)
            {
                if (linhor.CompetitionP1 == "FINAL")
                {
                    tb.Text = linhor.E1JudgeP1.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E2JudgeP1.ToString();
                    incrementarparticipacionFEjuez(tb);

                    tb.Text = linhor.E3JudgeP1.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E4JudgeP1.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E5JudgeP1.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E6JudgeP1.ToString();
                    incrementarparticipacionFEjuez(tb);

                    tb.Text = linhor.A1JudgeP1.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A2JudgeP1.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A3JudgeP1.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A4JudgeP1.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A5JudgeP1.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A6JudgeP1.ToString();
                    incrementarparticipacionFAjuez(tb);
                }
                else
                {
                    tb.Text = linhor.E1JudgeP1.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E2JudgeP1.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E3JudgeP1.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E4JudgeP1.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E5JudgeP1.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E6JudgeP1.ToString();
                    incrementarparticipacionEjuez(tb);

                    tb.Text = linhor.A1JudgeP1.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A2JudgeP1.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A3JudgeP1.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A4JudgeP1.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A5JudgeP1.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A6JudgeP1.ToString();
                    incrementarparticipacionAjuez(tb);

                }
                if (linhor.CompetitionP2 == "FINAL")
                {
                    tb.Text = linhor.E1JudgeP2.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E2JudgeP2.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E3JudgeP2.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E4JudgeP2.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E5JudgeP2.ToString();
                    incrementarparticipacionFEjuez(tb);
                    tb.Text = linhor.E6JudgeP2.ToString();
                    incrementarparticipacionFEjuez(tb);

                    tb.Text = linhor.A1JudgeP2.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A2JudgeP2.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A3JudgeP2.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A4JudgeP2.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A5JudgeP2.ToString();
                    incrementarparticipacionFAjuez(tb);
                    tb.Text = linhor.A6JudgeP2.ToString();
                    incrementarparticipacionFAjuez(tb);
                }
                else
                {
                    tb.Text = linhor.E1JudgeP2.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E2JudgeP2.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E3JudgeP2.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E4JudgeP2.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E5JudgeP2.ToString();
                    incrementarparticipacionEjuez(tb);
                    tb.Text = linhor.E6JudgeP2.ToString();
                    incrementarparticipacionEjuez(tb);

                    tb.Text = linhor.A1JudgeP2.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A2JudgeP2.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A3JudgeP2.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A4JudgeP2.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A5JudgeP2.ToString();
                    incrementarparticipacionAjuez(tb);
                    tb.Text = linhor.A6JudgeP2.ToString();
                    incrementarparticipacionAjuez(tb);

                }

                

            }




        }

        private void ResetCountersJudgeParticipations_Click(object sender, RoutedEventArgs e)
        {
            foreach (Juez j in JuecesDataGrid.ItemsSource)
            {
                j.TotalA = 0;
                j.TotalE = 0;
            }

            RestablecerConteoParticipacionesJueces();
            JuecesDataGrid.Items.Refresh();
        }


        private void BTDeleteAllDraws_Click(object sender, RoutedEventArgs e)
        {
            if (!(System.Windows.MessageBox.Show("Are you sure?", "Please confirm.", MessageBoxButton.YesNo) == MessageBoxResult.No))
            {
                for (indicehorario = 0; indicehorario < horario.Count(); indicehorario++)
                {
                    limpiar_asginaciones_juecesP1();
                    GuardarJuecesHorarioP1(indicehorario);
                    limpiar_asginaciones_juecesP2();
                    GuardarJuecesHorarioP2(indicehorario);
                    limpiar_asginaciones_juecesLTI();
                    guardarjuecesTLI(indicehorario);
                }

                foreach (Juez j in JuecesDataGrid.ItemsSource)
                {
                    j.TotalA = 0;
                    j.TotalE = 0;
                    j.TotalFA = 0;
                    j.TotalFE = 0;
                }
                JuecesDataGrid.Items.Refresh();
                indicehorario = 0;

            }
        }

        private void BTLoadEventLogo_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    logoevento = openFileDialog.FileName;
                    evento.Event_logo = logoevento;
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(logoevento, UriKind.Absolute);
                    bi3.EndInit();
                    IEventlogo.Source = bi3;
                    IMGLogoEvento.Source = bi3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A exception just occurred with the event logo: " + ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
        }

        private void CBWP1116BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWP1116DYND1.SelectedValue = CBWP1116BALD1.SelectedValue;
        }

        private void CBWP1116BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWP1116DYND2.SelectedValue = CBWP1116BALD2.SelectedValue;

        }

        private void CBMP1116BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMP1116DYND1.SelectedValue = CBMP1116BALD1.SelectedValue;

        }

        private void CBMP1116BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMP1116DYND2.SelectedValue = CBMP1116BALD2.SelectedValue;

        }

        private void CBMXP1116BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXP1116DYND1.SelectedValue = CBMXP1116BALD1.SelectedValue;

        }

        private void CBMXP1116BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXP1116DYND2.SelectedValue = CBMXP1116BALD2.SelectedValue;
        }

        private void CBWG1116BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWG1116DYND1.SelectedValue = CBWG1116BALD1.SelectedValue;
        }

        private void CBWG1116BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWG1116DYND2.SelectedValue = CBWG1116BALD2.SelectedValue;
        }

        private void CBMG1116BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMG1116DYND1.SelectedValue = CBMG1116BALD1.SelectedValue;
        }

        private void CBMG1116BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMG1116DYND2.SelectedValue = CBMG1116BALD2.SelectedValue;

        }

        private void CBWP1218BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWP1218DYND1.SelectedValue = CBWP1218BALD1.SelectedValue;
            CBWP1218COMD1.SelectedValue = CBWP1218BALD1.SelectedValue;
        }

        private void CBWP1218BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWP1218DYND2.SelectedValue = CBWP1218BALD2.SelectedValue;
            CBWP1218COMD2.SelectedValue = CBWP1218BALD2.SelectedValue;

        }

        private void CBMP1218BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMP1218DYND1.SelectedValue = CBMP1218BALD1.SelectedValue;
            CBMP1218COMD1.SelectedValue = CBMP1218BALD1.SelectedValue;

        }

        private void CBMP1218BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMP1218DYND2.SelectedValue = CBMP1218BALD2.SelectedValue;
            CBMP1218COMD2.SelectedValue = CBMP1218BALD2.SelectedValue;

        }

        private void CBMXP1218BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXP1218DYND1.SelectedValue = CBMXP1218BALD1.SelectedValue;
            CBMXP1218COMD1.SelectedValue = CBMXP1218BALD1.SelectedValue;

        }

        private void CBMXP1218BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXP1218DYND2.SelectedValue = CBMXP1218BALD2.SelectedValue;
            CBMXP1218COMD2.SelectedValue = CBMXP1218BALD2.SelectedValue;
        }

        private void CBWG1218BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWG1218DYND1.SelectedValue = CBWG1218BALD1.SelectedValue;
            CBWG1218COMD1.SelectedValue = CBWG1218BALD1.SelectedValue;

        }

        private void CBWG1218BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWG1218DYND2.SelectedValue = CBWG1218BALD2.SelectedValue;
            CBWG1218COMD2.SelectedValue = CBWG1218BALD2.SelectedValue;

        }

        private void CBMG1218BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMG1218DYND1.SelectedValue = CBMG1218BALD1.SelectedValue;
            CBMG1218COMD1.SelectedValue = CBMG1218BALD1.SelectedValue;

        }

        private void CBMG1218BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMG1218DYND2.SelectedValue = CBMG1218BALD2.SelectedValue;
            CBMG1218COMD2.SelectedValue = CBMG1218BALD2.SelectedValue;

        }

        private void CBWP1319BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWP1319DYND1.SelectedValue = CBWP1319BALD1.SelectedValue;
            CBWP1319COMD1.SelectedValue = CBWP1319BALD1.SelectedValue;

        }

        private void CBWP1319BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWP1319DYND2.SelectedValue = CBWP1319BALD2.SelectedValue;
            CBWP1319COMD2.SelectedValue = CBWP1319BALD2.SelectedValue;


        }

        private void CBMP1319BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMP1319DYND1.SelectedValue = CBMP1319BALD1.SelectedValue;
            CBMP1319COMD1.SelectedValue = CBMP1319BALD1.SelectedValue;
        }

        private void CBMP1319BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMP1319DYND2.SelectedValue = CBMP1319BALD2.SelectedValue;
            CBMP1319COMD2.SelectedValue = CBMP1319BALD2.SelectedValue;

        }

        private void CBMXP1319BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXP1319DYND1.SelectedValue = CBMXP1319BALD1.SelectedValue;
            CBMXP1319COMD1.SelectedValue = CBMXP1319BALD1.SelectedValue;

        }

        private void CBMXP1319BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXP1319DYND2.SelectedValue = CBMXP1319BALD2.SelectedValue;
            CBMXP1319COMD2.SelectedValue = CBMXP1319BALD2.SelectedValue;

        }

        private void CBWG1319BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWG1319DYND1.SelectedValue = CBWG1319BALD1.SelectedValue;
            CBWG1319COMD1.SelectedValue = CBWG1319BALD1.SelectedValue;

        }

        private void CBWG1319BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWG1319DYND2.SelectedValue = CBWG1319BALD2.SelectedValue;
            CBWG1319COMD2.SelectedValue = CBWG1319BALD2.SelectedValue;

        }

        private void CBMG1319BALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMG1319DYND1.SelectedValue = CBMG1319BALD1.SelectedValue;
            CBMG1319COMD1.SelectedValue = CBMG1319BALD1.SelectedValue;

        }

        private void CBMG1319BALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMG1319DYND2.SelectedValue = CBMG1319BALD2.SelectedValue;
            CBMG1319COMD2.SelectedValue = CBMG1319BALD2.SelectedValue;

        }

        private void CBWPSENBALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWPSENDYND1.SelectedValue = CBWPSENBALD1.SelectedValue ;
            CBWPSENCOMD1.SelectedValue = CBWPSENBALD1.SelectedValue;

        }

        private void CBWPSENBALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWPSENDYND2.SelectedValue = CBWPSENBALD2.SelectedValue;
            CBWPSENCOMD2.SelectedValue = CBWPSENBALD2.SelectedValue;

        }

        private void CBMPSENBALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMPSENDYND1.SelectedValue = CBMPSENBALD1.SelectedValue;
            CBMPSENCOMD1.SelectedValue = CBMPSENBALD1.SelectedValue;

        }

        private void CBMPSENBALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMPSENDYND2.SelectedValue = CBMPSENBALD2.SelectedValue;
            CBMPSENCOMD2.SelectedValue = CBMPSENBALD2.SelectedValue;

        }

        private void CBMXPSENBALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXPSENDYND1.SelectedValue = CBMXPSENBALD1.SelectedValue;
            CBMXPSENCOMD1.SelectedValue = CBMXPSENBALD1.SelectedValue;

        }

        private void CBMXPSENBALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMXPSENDYND2.SelectedValue = CBMXPSENBALD2.SelectedValue;
            CBMXPSENCOMD2.SelectedValue = CBMXPSENBALD2.SelectedValue;

        }

        private void CBWGSENBALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWGSENDYND1.SelectedValue = CBWGSENBALD1.SelectedValue;
            CBWGSENCOMD1.SelectedValue = CBWGSENBALD1.SelectedValue;

        }

        private void CBWGSENBALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBWGSENDYND2.SelectedValue = CBWGSENBALD2.SelectedValue;
            CBWGSENCOMD2.SelectedValue = CBWGSENBALD2.SelectedValue;

        }

        private void CBMGSENBALD1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMGSENDYND1.SelectedValue = CBMGSENBALD1.SelectedValue;
            CBMGSENCOMD1.SelectedValue = CBMGSENBALD1.SelectedValue;

        }

        private void CBMGSENBALD2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CBMGSENDYND2.SelectedValue = CBMGSENBALD2.SelectedValue;
            CBMGSENCOMD2.SelectedValue = CBMGSENBALD2.SelectedValue;

        }
    }
        

}
