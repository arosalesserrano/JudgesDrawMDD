using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace JudgesDrawMDD
{
    public class basededatos<T>
    {
        public ObservableCollection<T> valores = new ObservableCollection<T>();
        public List<T> valoresList = new List<T>();

        public string ruta;
        public basededatos(string r)
        {
            ruta = r;
        }
        public void Guardar()
        {
            string texto = JsonConvert.SerializeObject(valores);
            File.WriteAllText(ruta, texto);

        }
        public void GuardarList()
        {
            string texto = JsonConvert.SerializeObject(valoresList);
            File.WriteAllText(ruta, texto);

        }
        public void GuardarObservableCollection(ObservableCollection<T> valoresaguardar)
        {
            string texto = JsonConvert.SerializeObject(valoresaguardar);
            File.WriteAllText(ruta, texto);

        }
        public void CargarList()
        {
            try
            {
                string archivo = File.ReadAllText(ruta);
                valoresList = JsonConvert.DeserializeObject<List<T>>(archivo);

            }
            catch (Exception) { }

        }
        public void Cargar()
        {
            try
            {
                string archivo = File.ReadAllText(ruta);
                valores = JsonConvert.DeserializeObject<ObservableCollection<T>>(archivo);

            }
            catch (Exception ex) {
                MessageBox.Show("Ha ocurrido un error intentando cargar el archivo: " + ex.Message, "Problemas", MessageBoxButton.OK, MessageBoxImage.Warning);

            }

        }
        public void Insertar(T nuevo)
        {
            valores.Add(nuevo);
            Guardar();
        }
        public List<T> Buscar(Func<T, bool> criterio)
        {
            return valores.Where(criterio).ToList();
        }
        public int Contar(Func<T, bool> criterio)
        {
            return valores.Where(criterio).ToList().Count();
        }
        public void Eliminar(Func<T, bool> criterio)
        {
   //         valores = valores.Where(x => !criterio(x)).ToList();

        }
        public void Actualizar(Func<T, bool> criterio, T nuevo)
              {
                  valoresList = valoresList.Select(x =>
                  {
                      if (criterio(x)) x = nuevo;
                      return x;

                  }
                  ).ToList();
              }
    }
}
