using System;
using System.Data;
using Oracle.DataAccess.Client;

namespace BackSafe.AccesoDatos
{
    public class ConexionBD
    {
        private String nombreBaseDeDatos;

        public String NombreBaseDeDatos
        {
            get { return nombreBaseDeDatos; }
            set { nombreBaseDeDatos = value; }
        }

        private String nombreTabla;

        public String NombreTabla
        {
            get { return nombreTabla; }
            set { nombreTabla = value; }
        }

        private String cadenaConexion;

        public String CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        private String intruccioneSQL;

        public String IntruccioneSQL
        {
            get { return intruccioneSQL; }
            set { intruccioneSQL = value; }
        }

        private OracleConnection dbConnection;

        public OracleConnection DbConnection
        {
            get { return dbConnection; }
            set { dbConnection = value; }
        }

        private DataSet dbDat;

        public DataSet DbDat
        {
            get { return dbDat; }
            set { dbDat = value; }
        }

        private OracleDataAdapter dbDataAdapter;

        public OracleDataAdapter DbDataAdapter
        {
            get { return dbDataAdapter; }
            set { dbDataAdapter = value; }
        }

        private Boolean esSelect;

        public Boolean EsSelect
        {
            get { return esSelect; }
            set { esSelect = value; }
        }

        private OracleCommand variableSQL { get; set; }

        public void abrirConexion()
        {
            try
            {
                this.DbConnection.Open();
            }
            catch (OracleException ex)
            {
                throw new Exception("Error al abrir la conexion ", ex);

            }
        }

        public void cerrarConexion()
        {
            try
            {
                this.DbConnection.Close();
            }
            catch (OracleException ex)
            {
                throw new Exception("Error al cerrar la conexion ", ex);

            }
        }

        private void comprobarConexion()
        {
            if (this.NombreBaseDeDatos == "")
            {
                throw new Exception("Base de datos en blanco");

            }

            if (this.NombreTabla == "")
            {
                throw new Exception("Tabla en blanco");

            }

            if (this.CadenaConexion == "")
            {
                throw new Exception("Cadena Conexion en blanco");

            }

            if (this.IntruccioneSQL == "")
            {
                throw new Exception("SQL en blanco");

            }

            try
            {
                this.DbConnection = new OracleConnection(this.CadenaConexion);
            }

            catch (OracleException ex)
            {
                throw new Exception("Error al conectar ", ex);

            }

            this.abrirConexion();
        }

        public void conectar()
        {

            comprobarConexion();

            if (this.EsSelect)
            {
                this.DbDat = new System.Data.DataSet();
                try
                {
                    this.DbDataAdapter = new OracleDataAdapter(this.IntruccioneSQL, this.DbConnection);
                    this.DbDataAdapter.Fill(this.DbDat, this.NombreTabla);
                }
                catch (OracleException ex)
                {
                    throw new Exception("Error en el SQL ", ex);

                }
            }
            else
            {
                try
                {
                    variableSQL = new OracleCommand(this.IntruccioneSQL, this.DbConnection);
                    variableSQL.ExecuteNonQuery();
                }
                catch (OracleException ex)
                {
                    throw new Exception("Error en el SQL ", ex);

                }

            }
            this.cerrarConexion();
        }


        public void retornarDatosFunciones()
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                this.dbDataAdapter = new OracleDataAdapter(variableSQL);
                this.DbDat = new System.Data.DataSet();
                this.dbDataAdapter.Fill(DbDat, this.NombreTabla);
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public void retornarDatosExamenes(decimal idAtencion)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("id_atencion", idAtencion);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                this.dbDataAdapter = new OracleDataAdapter(variableSQL);
                this.DbDat = new System.Data.DataSet();
                this.dbDataAdapter.Fill(DbDat, this.NombreTabla);
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public void retornarDatosVisitaMedicaPorIdMedico(decimal idMedico)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("id_medico", idMedico);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                this.dbDataAdapter = new OracleDataAdapter(variableSQL);
                this.DbDat = new System.Data.DataSet();
                this.dbDataAdapter.Fill(DbDat, this.NombreTabla);
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public void retornarVisitaMedicaPorFecha(DateTime fecha)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("fecha_visita", OracleDbType.Date,fecha, ParameterDirection.Input);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                this.dbDataAdapter = new OracleDataAdapter(variableSQL);
                this.DbDat = new System.Data.DataSet();
                this.dbDataAdapter.Fill(DbDat, this.NombreTabla);
            }
            catch (OracleException ex)
            {

                throw;
            }
        }


        public bool conectarProcCrearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno, 
                                            string direccion, decimal telefono, string email, decimal idPerfil)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rut",rut);
                variableSQL.Parameters.Add("contraseña", contraseña);
                variableSQL.Parameters.Add("nombre", nombre);
                variableSQL.Parameters.Add("ape_paterno", appaterno);
                variableSQL.Parameters.Add("ape_materno", apmaterno);
                variableSQL.Parameters.Add("direccion", direccion);
                variableSQL.Parameters.Add("telefono", telefono);
                variableSQL.Parameters.Add("email", email);
                variableSQL.Parameters.Add("id_perfil_usuario", idPerfil);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Se conecta al Procedimiento en donde se creara tanto el usuario como la empresa.
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="contraseña"></param>
        /// <param name="nombre"></param>
        /// <param name="appaterno"></param>
        /// <param name="apmaterno"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="idPerfil"></param>
        /// <param name="nomEmpresa"></param>
        /// <param name="runEmpresa"></param>
        /// <returns></returns>
        public bool conectarProcCrearUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                            string direccion, decimal telefono, string email, decimal idPerfil, string nomEmpresa, string runEmpresa)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rut", rut);
                variableSQL.Parameters.Add("contraseña", contraseña);
                variableSQL.Parameters.Add("nombre", nombre);
                variableSQL.Parameters.Add("ape_paterno", appaterno);
                variableSQL.Parameters.Add("ape_materno", apmaterno);
                variableSQL.Parameters.Add("direccion", direccion);
                variableSQL.Parameters.Add("telefono", telefono);
                variableSQL.Parameters.Add("email", email);
                variableSQL.Parameters.Add("id_perfil_usuario", idPerfil);
                variableSQL.Parameters.Add("nomEmpresa", nomEmpresa);
                variableSQL.Parameters.Add("runEmpresa", runEmpresa);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearEmpresa(decimal usuarioId, string nomEmpresa, string runEmpresa)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("usuarioId", usuarioId);
                variableSQL.Parameters.Add("nomEmpresa", nomEmpresa);
                variableSQL.Parameters.Add("runEmpresa", runEmpresa);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcModificarEmpresa(decimal idEmpresa, string nombreEmpresa, string rutEmpresa)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("idEmpresa", idEmpresa);
                variableSQL.Parameters.Add("nombreEmpresa", nombreEmpresa);
                variableSQL.Parameters.Add("rutEmpresa", rutEmpresa);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcModificarUsuario(decimal rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rut", rut);
                variableSQL.Parameters.Add("contraseña", contraseña);
                variableSQL.Parameters.Add("mnombre", nombre);
                variableSQL.Parameters.Add("mape_paterno", appaterno);
                variableSQL.Parameters.Add("mape_materno", apmaterno);
                variableSQL.Parameters.Add("mdireccion", direccion);
                variableSQL.Parameters.Add("mtelefono", telefono);
                variableSQL.Parameters.Add("memail", email);
                variableSQL.Parameters.Add("mid_perfil_usuario", idPerfil);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearVisita(DateTime fecVisita, decimal idContrato, decimal idMedico)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("fec_visita", fecVisita);
                variableSQL.Parameters.Add("id_contrato", idContrato);
                variableSQL.Parameters.Add("id_medico", idMedico);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcEliminarCapacitacion(decimal idCapactiacion)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("id_capacitacion", idCapactiacion);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcCrearTipoEval(string desc)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("descripcion", desc);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcModificarTipoEval(decimal id_tipoev, string desc)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("id_evaluacion", id_tipoev);
                variableSQL.Parameters.Add("descripcion_mod", desc);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcEliminarTipoEvaluacion(decimal idTipoEvaluacion)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("id_tipoEvaluacion", idTipoEvaluacion);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcEliminarEmpresa(decimal run_empresa)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("run_empresa", run_empresa);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcCrearPlan(string descPlan, decimal idContrato)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_plan", descPlan);
                variableSQL.Parameters.Add("id_contrato", idContrato);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearExamen(string descExamen, DateTime fecExamen, decimal idTipoExamen, decimal idAtencion)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_examen", descExamen);
                variableSQL.Parameters.Add("f_examen", fecExamen);
                variableSQL.Parameters.Add("id_tipo_examen", idTipoExamen);
                variableSQL.Parameters.Add("id_atencion", idAtencion);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearCurso(string descCurso, decimal capacId)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_curso", descCurso);
                variableSQL.Parameters.Add("capac_id", capacId);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearContrato(string descContrato, DateTime fecInicioContrato, decimal idEmpresa)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_contrato", descContrato);
                variableSQL.Parameters.Add("fecha_inicio_contrato", fecInicioContrato);
                variableSQL.Parameters.Add("id_empresa", idEmpresa);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearCapacitacion(string descCapacitacion, decimal minParticipantes, string nomExpositor,
                                                  DateTime fecFinal, decimal idPlanCapacitacion)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_capacitacion", descCapacitacion);
                variableSQL.Parameters.Add("min_participantes", minParticipantes);
                variableSQL.Parameters.Add("nom_expositor", nomExpositor);
                variableSQL.Parameters.Add("fecha_final", fecFinal);
                variableSQL.Parameters.Add("id_plan_capacitacion", idPlanCapacitacion);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcCrearAtencion(string descAtencion, decimal idFicha, decimal idVisitaMedica)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_atencion", descAtencion);
                variableSQL.Parameters.Add("id_ficha", idFicha);
                variableSQL.Parameters.Add("id_visita_medica", idVisitaMedica);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }


        public bool conectarProcCerrarPlan(decimal idPlan)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("id_plan", idPlan);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCerrarContrato(decimal idContrato)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("id_contrato", idContrato);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }
        
       public string retornarConfirmacionLogin(decimal rut, string contraseña)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("idPerfil", OracleDbType.Int32, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("rutUsuario", rut);
                variableSQL.Parameters.Add("contrUsuario", contraseña);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                string idPerfil = variableSQL.Parameters["idPerfil"].Value.ToString();

                return idPerfil;

            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        //public void conectarProcInsertarInteraccion(DataTable datosInteraccion, DataTable idParticipantes) {

        //    comprobarConexion();

        //    try
        //    {
        //        variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
        //        variableSQL.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramDatos = new SqlParameter();
        //        paramDatos.ParameterName = "@datos";
        //        paramDatos.Value = datosInteraccion;
        //        SqlParameter paramParticipantes = new SqlParameter();
        //        paramParticipantes.ParameterName = "@valores";
        //        paramParticipantes.Value = idParticipantes;
        //        SqlParameter paramIdCaso = new SqlParameter();
        //        paramIdCaso.ParameterName = "@idCaso";
        //        paramIdCaso.Value = 0;
        //        variableSQL.Parameters.Add(paramDatos);
        //        variableSQL.Parameters.Add(paramParticipantes);
        //        variableSQL.Parameters.Add(paramIdCaso);
        //        variableSQL.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        throw new Exception("Error en el SQL "+ex.Message);
        //    }
        //    cerrarConexion();
        //}

        //public void conectarProcInsertarCasoInteraccion(DataTable datosInteraccion, DataTable idParticipantes, int tipoCaso, int idcurso)
        //{
        //    comprobarConexion();
        //    try
        //    {
        //        variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
        //        variableSQL.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramDatos = new SqlParameter();
        //        paramDatos.ParameterName = "@datos";
        //        paramDatos.Value = datosInteraccion;
        //        SqlParameter paramParticipantes = new SqlParameter();
        //        paramParticipantes.ParameterName = "@valores";
        //        paramParticipantes.Value = idParticipantes;
        //        SqlParameter paramAsignatura = new SqlParameter();
        //        paramAsignatura.ParameterName = "@idAsignatura";
        //        paramAsignatura.Value = idcurso;
        //        SqlParameter paramTipoCaso = new SqlParameter();
        //        paramTipoCaso.ParameterName = "@idTipoCaso";
        //        paramTipoCaso.Value = tipoCaso;
        //        variableSQL.Parameters.Add(paramDatos);
        //        variableSQL.Parameters.Add(paramParticipantes);
        //        variableSQL.Parameters.Add(paramAsignatura);
        //        variableSQL.Parameters.Add(paramTipoCaso);
        //        variableSQL.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw new Exception("Error en el SQL " + ex.Message);
        //    }

        //    cerrarConexion();
        //}

        //public void conectarProcFinalizarCasoInteraccion(int idCaso)
        //{
        //    comprobarConexion();
        //    try
        //    {
        //        variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
        //        variableSQL.CommandType = CommandType.StoredProcedure;
        //        SqlParameter paramIdCaso = new SqlParameter();
        //        paramIdCaso.ParameterName = "@idCaso";
        //        paramIdCaso.Value = idCaso;
        //        variableSQL.Parameters.Add(paramIdCaso);
        //        variableSQL.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw new Exception("Error en el SQL " + ex.Message);
        //    }

        //    cerrarConexion();
        //}
    }
}

