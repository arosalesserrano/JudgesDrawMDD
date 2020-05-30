using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
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

    public class ListaValores: ObservableCollection<Valores>
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
        Evento_De_Trabajo evento_de_trabajo = new Evento_De_Trabajo();
        Lista_Eventos_Guardados lista_eventos_guardados;
        Lista_Eventos_Guardados lista_eventos_guardados_trabajo;
        Horario horario = new Horario();
        EventFinalCountries eventfinalcountries = new EventFinalCountries();
        EstadisticasJueces estadisticasJueces = new EstadisticasJueces();
        List<CategoriaModalidadEjercicio> CME = new List<CategoriaModalidadEjercicio>();
        Relatives relatives = new Relatives();
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
            Countries CountrystringCollection = new Countries();

            InitializeComponent();
            this.PieChart();

            numero_evento_trabajo = 0;
            // al iniciar, cargamos la lista de eventos, seleccionamos el primero y descargamos la lista
            try
            {
                lista_eventos_guardados = new Lista_Eventos_Guardados("listaeventos.json");
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }
            // cogemos el último evento guardado
            numero_evento_trabajo = lista_eventos_guardados.Count - 1;
            Inicialiar_Evento_de_lista(numero_evento_trabajo);

            for (int i = lista_eventos_guardados.Count - 1; i >= 0; i--)
            {

                lista_eventos_guardados.RemoveAt(i);
            }

            CBJudgeNameRel.ItemsSource = jueces;
            CBJudgeNameRel.DisplayMemberPath = "JudgeName";
            CBJudgeNameRel.SelectedValuePath = "JudgeName";

            CBCompetitionP1.ItemsSource = TipoCompeticion.GetAll;
            CBCompetitionP2.ItemsSource = TipoCompeticion.GetAll;

            CBp1QNoSameCountryInSame.ItemsSource = NoSameCountryInSame.GetAll;
            CBp1F3Condition.ItemsSource = F3Condition.GetAll;
            CBp1FNoSameCountryInSame.ItemsSource = NoSameCountryInSame.GetAll;

            CBSJPresident.ItemsSource = jueces;
            CBSJPresident.DisplayMemberPath = "JudgeName";
            CBSJPresident.SelectedValuePath = "JudgeName";

            CBSJD1.ItemsSource = jueces;
            CBSJD1.DisplayMemberPath = "JudgeName";
            CBSJD1.SelectedValuePath = "JudgeName";

            CBSJD2.ItemsSource = jueces;
            CBSJD2.DisplayMemberPath = "JudgeName";
            CBSJD2.SelectedValuePath = "JudgeName";

            CBSJE1.ItemsSource = jueces;
            CBSJE1.DisplayMemberPath = "JudgeName";
            CBSJE1.SelectedValuePath = "JudgeName";

            CBSJE2.ItemsSource = jueces;
            CBSJE2.DisplayMemberPath = "JudgeName";
            CBSJE2.SelectedValuePath = "JudgeName";

            CBSJA1.ItemsSource = jueces;
            CBSJA1.DisplayMemberPath = "JudgeName";
            CBSJA1.SelectedValuePath = "JudgeName";

            CBSJA2.ItemsSource = jueces;
            CBSJA2.DisplayMemberPath = "JudgeName";
            CBSJA2.SelectedValuePath = "JudgeName";

            CBSCJPPanel1.ItemsSource = jueces;
            CBSCJPPanel1.DisplayMemberPath = "JudgeName";
            CBSCJPPanel1.SelectedValuePath = "JudgeName";

            CBSCJPPanel2.ItemsSource = jueces;
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


            CBSJPresident.ItemsSource = jueces;
            CBSJD1.ItemsSource = jueces;
            CBSJD2.ItemsSource = jueces;
            CBSJE1.ItemsSource = jueces;
            CBSJE2.ItemsSource = jueces;
            CBSJA1.ItemsSource = jueces;
            CBSJA2.ItemsSource = jueces;

            CBSCJPPanel1.ItemsSource = jueces;
            CBSCJPPanel2.ItemsSource = jueces;


            CBWP1116BALD1.ItemsSource = jueces;
            CBWP1116BALD2.ItemsSource = jueces;
            CBWP1116DYND1.ItemsSource = jueces;
            CBWP1116DYND2.ItemsSource = jueces;
            CBWP1218BALD1.ItemsSource = jueces;
            CBWP1218BALD2.ItemsSource = jueces;
            CBWP1218DYND1.ItemsSource = jueces;
            CBWP1218DYND2.ItemsSource = jueces;
            CBWP1218COMD1.ItemsSource = jueces;
            CBWP1218COMD2.ItemsSource = jueces;
            CBWP1319BALD1.ItemsSource = jueces;
            CBWP1319BALD2.ItemsSource = jueces;
            CBWP1319DYND1.ItemsSource = jueces;
            CBWP1319DYND2.ItemsSource = jueces;
            CBWP1319COMD2.ItemsSource = jueces;
            CBWP1319COMD1.ItemsSource = jueces;

            CBWPSENBALD1.ItemsSource = jueces;
            CBWPSENBALD2.ItemsSource = jueces;
            CBWPSENDYND1.ItemsSource = jueces;
            CBWPSENDYND2.ItemsSource = jueces;
            CBWPSENCOMD2.ItemsSource = jueces;
            CBWPSENCOMD1.ItemsSource = jueces;

            CBWPSENBALD1.ItemsSource = jueces;
            CBWPSENBALD2.ItemsSource = jueces;
            CBWPSENDYND1.ItemsSource = jueces;
            CBWPSENDYND2.ItemsSource = jueces;
            CBWPSENCOMD1.ItemsSource = jueces;
            CBWPSENCOMD2.ItemsSource = jueces;

            CBMP1116BALD1.ItemsSource = jueces;
            CBMP1116BALD2.ItemsSource = jueces;
            CBMP1116DYND1.ItemsSource = jueces;
            CBMP1116DYND2.ItemsSource = jueces;
            CBMP1218BALD1.ItemsSource = jueces;
            CBMP1218BALD2.ItemsSource = jueces;
            CBMP1218DYND1.ItemsSource = jueces;
            CBMP1218DYND2.ItemsSource = jueces;
            CBMP1218COMD1.ItemsSource = jueces;
            CBMP1218COMD2.ItemsSource = jueces;
            CBMP1319BALD1.ItemsSource = jueces;
            CBMP1319BALD2.ItemsSource = jueces;
            CBMP1319DYND1.ItemsSource = jueces;
            CBMP1319DYND2.ItemsSource = jueces;
            CBMP1319COMD1.ItemsSource = jueces;
            CBMP1319COMD2.ItemsSource = jueces;
            CBMPSENBALD1.ItemsSource = jueces;
            CBMPSENBALD2.ItemsSource = jueces;
            CBMPSENDYND1.ItemsSource = jueces;
            CBMPSENDYND2.ItemsSource = jueces;
            CBMPSENCOMD2.ItemsSource = jueces;
            CBMPSENCOMD1.ItemsSource = jueces;
            CBMPSENBALD1.ItemsSource = jueces;
            CBMPSENBALD2.ItemsSource = jueces;
            CBMPSENDYND1.ItemsSource = jueces;
            CBMPSENDYND2.ItemsSource = jueces;
            CBMPSENCOMD1.ItemsSource = jueces;
            CBMPSENCOMD2.ItemsSource = jueces;

            CBMXP1116BALD1.ItemsSource = jueces;
            CBMXP1116BALD2.ItemsSource = jueces;
            CBMXP1116DYND1.ItemsSource = jueces;
            CBMXP1116DYND2.ItemsSource = jueces;
            CBMXP1218BALD1.ItemsSource = jueces;
            CBMXP1218BALD2.ItemsSource = jueces;
            CBMXP1218DYND1.ItemsSource = jueces;
            CBMXP1218DYND2.ItemsSource = jueces;
            CBMXP1218COMD1.ItemsSource = jueces;
            CBMXP1218COMD2.ItemsSource = jueces;
            CBMXP1319BALD1.ItemsSource = jueces;
            CBMXP1319BALD2.ItemsSource = jueces;
            CBMXP1319DYND1.ItemsSource = jueces;
            CBMXP1319DYND2.ItemsSource = jueces;
            CBMXP1319COMD1.ItemsSource = jueces;
            CBMXP1319COMD2.ItemsSource = jueces;
            CBMXPSENBALD1.ItemsSource = jueces;
            CBMXPSENBALD2.ItemsSource = jueces;
            CBMXPSENDYND1.ItemsSource = jueces;
            CBMXPSENDYND2.ItemsSource = jueces;
            CBMXPSENCOMD1.ItemsSource = jueces;
            CBMXPSENCOMD2.ItemsSource = jueces;
            CBMXPSENBALD1.ItemsSource = jueces;
            CBMXPSENBALD2.ItemsSource = jueces;
            CBMXPSENDYND1.ItemsSource = jueces;
            CBMXPSENDYND2.ItemsSource = jueces;
            CBMXPSENCOMD1.ItemsSource = jueces;
            CBMXPSENCOMD2.ItemsSource = jueces;

            CBWG1116BALD1.ItemsSource = jueces;
            CBWG1116BALD2.ItemsSource = jueces;
            CBWG1116DYND1.ItemsSource = jueces;
            CBWG1116DYND2.ItemsSource = jueces;
            CBWG1218BALD1.ItemsSource = jueces;
            CBWG1218BALD2.ItemsSource = jueces;
            CBWG1218DYND1.ItemsSource = jueces;
            CBWG1218DYND2.ItemsSource = jueces;
            CBWG1218COMD1.ItemsSource = jueces;
            CBWG1218COMD2.ItemsSource = jueces;
            CBWG1319BALD1.ItemsSource = jueces;
            CBWG1319BALD2.ItemsSource = jueces;
            CBWG1319DYND1.ItemsSource = jueces;
            CBWG1319DYND2.ItemsSource = jueces;
            CBWG1319COMD1.ItemsSource = jueces;
            CBWG1319COMD2.ItemsSource = jueces;
            CBWGSENBALD1.ItemsSource = jueces;
            CBWGSENBALD2.ItemsSource = jueces;
            CBWGSENDYND1.ItemsSource = jueces;
            CBWGSENDYND2.ItemsSource = jueces;
            CBWGSENCOMD1.ItemsSource = jueces;
            CBWGSENCOMD2.ItemsSource = jueces;
            CBWGSENBALD1.ItemsSource = jueces;
            CBWGSENBALD2.ItemsSource = jueces;
            CBWGSENDYND1.ItemsSource = jueces;
            CBWGSENDYND2.ItemsSource = jueces;
            CBWGSENCOMD1.ItemsSource = jueces;
            CBWGSENCOMD2.ItemsSource = jueces;

            CBMG1116BALD1.ItemsSource = jueces;
            CBMG1116BALD2.ItemsSource = jueces;
            CBMG1116DYND1.ItemsSource = jueces;
            CBMG1116DYND2.ItemsSource = jueces;
            CBMG1218BALD1.ItemsSource = jueces;
            CBMG1218BALD2.ItemsSource = jueces;
            CBMG1218DYND1.ItemsSource = jueces;
            CBMG1218DYND2.ItemsSource = jueces;
            CBMG1218COMD1.ItemsSource = jueces;
            CBMG1218COMD2.ItemsSource = jueces;
            CBMG1319BALD1.ItemsSource = jueces;
            CBMG1319BALD2.ItemsSource = jueces;
            CBMG1319DYND1.ItemsSource = jueces;
            CBMG1319DYND2.ItemsSource = jueces;
            CBMG1319COMD1.ItemsSource = jueces;
            CBMG1319COMD2.ItemsSource = jueces;
            CBMGSENBALD1.ItemsSource = jueces;
            CBMGSENBALD2.ItemsSource = jueces;
            CBMGSENDYND1.ItemsSource = jueces;
            CBMGSENDYND2.ItemsSource = jueces;
            CBMGSENCOMD1.ItemsSource = jueces;
            CBMGSENCOMD2.ItemsSource = jueces;
            CBMGSENBALD1.ItemsSource = jueces;
            CBMGSENBALD2.ItemsSource = jueces;
            CBMGSENDYND1.ItemsSource = jueces;
            CBMGSENDYND2.ItemsSource = jueces;
            CBMGSENCOMD1.ItemsSource = jueces;
            CBMGSENCOMD2.ItemsSource = jueces;




        }

        private void Inicialiar_Evento_de_lista(int num_evento)
        {
            /*principio de inicialización*/
            evento_de_trabajo = lista_eventos_guardados[num_evento];
            // vaciamos la lista de eventos guardados

            evento = evento_de_trabajo.Evento_; // inicializamos evento
            InicializarCME();


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

            foreach (LineaHorario lh in evento_de_trabajo.Horario_)
            {
                horario.Add(lh);
            }

            foreach (FinalCountries fc in evento_de_trabajo.EventFinalCountries_)
            {
                eventfinalcountries.Add(fc);
            }

            FinalCountriesDataGrid.ItemsSource = eventfinalcountries;
            RelativesDataGrid.ItemsSource = relatives;               
            ScheduleDataGrid.ItemsSource = horario;
            JuecesDataGrid.ItemsSource = jueces;

            GridDrawSettings.DataContext = evento;
            GridDatosEvento.DataContext = evento;
            GridSchedule.DataContext = evento;
            GridDifficultyJudges.DataContext = evento;
            GridDraw.DataContext = evento;
            Lnombreevento.Content = evento_de_trabajo.Event_Name;
            Lfechaevento.Content = evento_de_trabajo.SaveDate;

            StackPanelJueces.DataContext = estadisticasJueces;
            ActualizarEstadisticasJueces();


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

            GridDrawSettings.DataContext = null;
            GridDatosEvento.DataContext = null;
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
            bool? Result = new MessageBoxCustom("Are you sure, You want to close application ? ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

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
                    lista_eventos_guardados = new Lista_Eventos_Guardados("listaeventos.json");
                }
                catch (Exception ex)
                {
                    _ = new MessageBoxCustom(ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
                }
                if (lista_eventos_guardados.Count()>5)
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
                lista_eventos_guardados.Guardar("listaeventos.json");
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
            bool? Result = new MessageBoxCustom("Are you sure?, all draws will erase ", MessageType.Confirmation, MessageButtons.YesNo).ShowDialog();

            if (Result.Value)
            {
                foreach (Juez j in JuecesDataGrid.ItemsSource)
                {
                    j.TotalA = 0;
                    j.TotalE = 0;
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
                    item.PropertyChanged -= Horario_PropertyChanged;

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
                    if(j.IsSelected)
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
            JuecesDataGrid.Columns[9].Visibility = Visibility.Visible;
        }

        private void HabiliarVistaWarning_Unchecked(object sender, RoutedEventArgs e)
        {
            JuecesDataGrid.Columns[9].Visibility = Visibility.Collapsed;
        }

        private void BTnCargarExcel_ClickAsync(object sender, RoutedEventArgs e)
        {
            string txtFilePath;
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            if (browsefile == true)
            {


                txtFilePath = openfile.FileName;

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                //Static File From Base Path...........
                //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "TestExcel.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //Dynamic File Using Uploader...........
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(txtFilePath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;

                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                DataTable dt = new DataTable();
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    dt.Columns.Add(strColumn, typeof(string));
                }

                for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    string strData = "";
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += strCellData + "|";
                        }
                        catch (Exception ex)
                        {
                            douCellData = (double)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                }

                DHInportExcel.IsOpen = true;

                BTnCargarExcel.Visibility = Visibility.Hidden;
                JuecesDataGridInport.ItemsSource = dt.DefaultView;
                JuecesDataGridInport.Visibility = Visibility.Visible;
                BTnAppendJudges.Visibility = Visibility.Visible;
                BTnLoadJudges.Visibility = Visibility.Visible;
                BTnDelInportJudges.Visibility = Visibility.Visible;
                excelBook.Close(true, null, null);
                excelApp.Quit();

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
            for (int i = 0; i < JuecesDataGridInport.Items.Count - 1; i++)
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
                juez.Category = int.Parse(categoriajuez);
                juez.ID = int.Parse(numerojuez);

                jueces.Add(juez);
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
                for (int i = 0; i < JuecesDataGridInport.Items.Count - 1; i++)
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
                    juez.Category = int.Parse(categoriajuez);
                    juez.ID = int.Parse(numerojuez);
                    jueces.Add(juez);
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
            JuecesDataGrid.Items.Refresh();
        }

        private void GridSchedule_GotFocus(object sender, RoutedEventArgs e)
        {
            InicializarCME();
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

        private void TBNumerosJueces_TextChanged(object sender, TextChangedEventArgs e)

        {
            TextBox TB = new TextBox();
            TB = (TextBox)sender;

            //  ActualizarEtiquetasNombre();
            //  ActualizarEtiquetasPais();
            //  ActualizarBanderaPais();
        }


        private void NombreEvento_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Control tmp = sender as Control;
            tmp.FontSize = e.NewSize.Height / tmp.FontFamily.LineSpacing;
        }

        private void Panel1Draw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Panel2Draw_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LimpiarDrawP1_Click(object sender, RoutedEventArgs e)
        { 
        
        }

        private void LimpiarDrawP2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TimeLineDraw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LimpiarDraw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LimpiarDrawTLI_Click(object sender, RoutedEventArgs e)
        {

        }
        

        private void ImprimirDraw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
                        
            Descargar_Evento_actual();
            lista_eventos_guardados = null;
            //Cargar lita de eventos y seleccionar el siguiente
            try
            {
                lista_eventos_guardados = new Lista_Eventos_Guardados("listaeventos.json");
            }
            catch (Exception ex)
            {
                bool? Result = new MessageBoxCustom(ex.Message, MessageType.Confirmation, MessageButtons.Ok).ShowDialog();
            }

            lista_eventos_guardados_trabajo = new Lista_Eventos_Guardados();
            lista_eventos_guardados_trabajo.CollectionChanged += ListaEventos_CollectionChanged;

            foreach (Evento_De_Trabajo j in lista_eventos_guardados)
            {
                lista_eventos_guardados_trabajo.Add(j);
            }



            DHEventsList.IsOpen = true;

            ICEvents.ItemsSource = lista_eventos_guardados_trabajo.OrderByDescending(x=>DateTime.Parse(x.SaveDate));

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
            DHEventsList.IsOpen = false;
            //Hay que localizar el evento de trabajo con IsSelected a true
            lista_eventos_guardados_trabajo.Guardar("listaeventos.json");
            foreach (Evento_De_Trabajo j in lista_eventos_guardados_trabajo)
            {
               if(j.IsSelected)
                {
                    Inicialiar_Evento_de_lista(lista_eventos_guardados_trabajo.IndexOf(j));

                    for (int i = lista_eventos_guardados_trabajo.Count - 1; i >= 0; i--)
                    {

                        lista_eventos_guardados.RemoveAt(i);
                    }
                }
            }
        }
    }

    }
