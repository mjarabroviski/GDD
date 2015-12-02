using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Persistencia;
using Persistencia.Entidades;
using Configuracion;
using Herramientas;
using Filtros;

namespace AerolineaFrba.Listado_Estadistico
{
    public partial class Listado_Estadistico : Form
    {
        private List<Estadistica> _estadisticas = new List<Estadistica>();

        public Listado_Estadistico()
        {
            InitializeComponent();
        }

        private void LblCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Listado_Estadistico_Load(object sender, EventArgs e)
        {
            ActualizarRecursos(null);
        }

        private void LimpiarFiltros() {
            cboAnio.Text = string.Empty;
            cboListado.Text = string.Empty;
            cboSemestre.Text = string.Empty;
        }

        private void LimpiarDataGridView()
        {
            DgvListado.DataSource = null;
            DgvListado.Columns.Clear();
        }

        private void ActualizarRecursos(List<Estadistica> estadisticas) {

            #region Cargar Recursos

            //Cargo el combo de años
            //Se muestran estadisticas de aca a 3 anios
            var dataSourceAño = new List<object>();
            for (var i = 1990; i <= Convert.ToInt32(Configuracion.ConfiguracionDeVariables.FechaSistema.AddYears(3).Year); i++)
                dataSourceAño.Add(new { Name = i.ToString(), Value = i });
            cboAnio.DataSource = dataSourceAño;
            cboAnio.ValueMember = "Value";
            cboAnio.DisplayMember = "Name";

            //Cargo el combo de semestres
            var dataSourceSemestre = new List<object>();
            dataSourceSemestre.Add(new { Name = "Enero - Junio", Value = 1 });
            dataSourceSemestre.Add(new { Name = "Julio - Diciembre", Value = 2 });
            cboSemestre.ValueMember = "Value";
            cboSemestre.DisplayMember = "Name";
            cboSemestre.DataSource = dataSourceSemestre;

            //Cargo el combo con los posibles listados a pedir
            var dataSourceListado = new List<object>();
            dataSourceListado.Add(new { Name = "Destinos con más pasajes comprados", Value = 1 });
            dataSourceListado.Add(new { Name = "Destinos con más aeronaves vacías", Value = 2 });
            dataSourceListado.Add(new { Name = "Clientes con más puntos acumulados a la fecha", Value = 3 });
            dataSourceListado.Add(new { Name = "Destinos con más pasajes cancelados", Value = 4 });
            dataSourceListado.Add(new { Name = "Aeronaves con mayor cantidad de días fuera de servicio", Value = 5 });
            cboListado.DataSource = dataSourceListado;
            cboListado.ValueMember = "Value";
            cboListado.DisplayMember = "Name";

            #endregion

            LimpiarDataGridView();
        }

        private void LblLimpiar_Click(object sender, EventArgs e)
        {
            ActualizarRecursos(null);
            LimpiarFiltros();
        }

        private void LblFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validaciones

                var filtrosSeteados = false;
                var exceptionMessage = string.Empty;

                if ((!ValidadorDeTipos.IsEmpty(cboAnio.Text) || cboAnio.Text != "") && (!ValidadorDeTipos.IsEmpty(cboSemestre.Text) || cboSemestre.Text != "") && (!ValidadorDeTipos.IsEmpty(cboListado.Text) || cboListado.Text != ""))
                    filtrosSeteados = true;

                if (!filtrosSeteados)
                    exceptionMessage = "No se puede obtener el listado estadístico. Verifique que haya ingresado los filtros correctamente.";

                if (!ValidadorDeTipos.IsEmpty(exceptionMessage))
                    throw new Exception(exceptionMessage);

                #endregion

                var mesDesde = "";
                var diaHasta = "";
                var mesHasta = "";


                switch ((int)cboSemestre.SelectedValue)
                {
                    case 1: mesDesde = "01"; mesHasta = "06"; break;
                    case 2: mesDesde = "07"; mesHasta = "12"; break;
                }

                switch (mesHasta)
                {
                    case "01":
                    case "03":
                    case "05":
                    case "07":
                    case "08":
                    case "10":
                    case "12": diaHasta = "31"; break;
                    case "04":
                    case "06":
                    case "09":
                    case "11": diaHasta = "30"; break;
                    case "02": diaHasta = "28"; break;
                }

                string fechaDesde = cboAnio.SelectedValue.ToString() + "/" + mesDesde + "/01" + " " + "12:00:00";
                string fechaHasta = cboAnio.SelectedValue.ToString() + "/" + mesHasta + "/" + diaHasta + " " + "12:00:00";

                //Creo los filtros con los que se ejecuta la consulta.
                var filtros = new EstadisticaFiltros
                {
                    FechaDesde = fechaDesde,
                    FechaHasta = fechaHasta,
                };

                List<Estadistica> listado = new List<Estadistica>();
                switch ((int)cboListado.SelectedValue)
                {
                    case 1:
                        listado = EstadisticaPersistencia.ObtenerDestinosConMasPasajesComprados(filtros);
                        break;

                    case 2:
                        listado = EstadisticaPersistencia.ObtenerDestinosConMasAeronavesVacias(filtros);
                        break;

                    case 3:
                        listado = EstadisticaPersistencia.ObtenerClientesConMasPuntosAcumulados(filtros);
                        break;

                    case 4:
                        listado = EstadisticaPersistencia.ObtenerDestinosConMasPasajesCancelados(filtros);
                        break;

                    case 5:
                        listado = EstadisticaPersistencia.ObtenerAeronavesConMayorCantDeDiasFueraDeServicio(filtros);
                        break;
                }

                if (listado == null || listado.Count == 0)
                    throw new Exception("No se encontraron estadísticas según los filtros informados.");

                CargarGrilla(listado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención");
                LimpiarDataGridView();
            }
        }

        private void CargarGrilla(List<Estadistica> listado)
        {
            #region Generar el diccionario con las estadísticas
            var estadisticasDictionary = new Dictionary<string, Estadistica>();
            if (listado == null)
            {
                //El datasource debe estar vacío
                DgvListado.DataSource = null;
            }
            else
            {
                //El datasource debe ser la lista de los parametros a consultar y sus metricas que recibió por parametro
                estadisticasDictionary = listado.ToDictionary(a => a.Parametro, a => a);
            }

            #endregion

            if (estadisticasDictionary != null)
            {
                //Parseo el diccionario y muestro en la grilla según el listado pedido
                switch ((int)cboListado.SelectedValue)
                {
                    case 1:
                        var bind1 = estadisticasDictionary.Values.Select(a => new
                        {
                            Destino = a.Parametro,
                            Cantidad_Pasajes_Comprados = a.Valor
                        });
                        DgvListado.DataSource = bind1.ToList();
                        break;

                    case 2:
                        var bind2 = estadisticasDictionary.Values.Select(a => new
                        {
                            Destino = a.Parametro,
                            Cantidad_Butacas_Libres = a.Valor
                        });
                        DgvListado.DataSource = bind2.ToList();
                        break;
                    case 3:
                        var bind3 = estadisticasDictionary.Values.Select(a => new
                        {
                            Cliente = a.Parametro,
                            Puntos = a.Valor
                        });
                        DgvListado.DataSource = bind3.ToList();
                        break;
                    case 4:
                        var bind4 = estadisticasDictionary.Values.Select(a => new
                        {
                            Destino = a.Parametro,
                            Cantidad_Pasajes_Cancelados = a.Valor
                        });
                        DgvListado.DataSource = bind4.ToList();
                        break;
                    case 5:
                        var bind5 = estadisticasDictionary.Values.Select(a => new
                        {
                            Aeronave = a.Parametro,
                            Cantidad_Dias = a.Valor
                        });
                        DgvListado.DataSource = bind5.ToList();
                        break;
                }

                DgvListado.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            DgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
