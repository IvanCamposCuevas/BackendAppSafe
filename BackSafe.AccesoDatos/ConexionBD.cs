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

        public OracleCommand variableSQL { get; set; }

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

        public void comprobarConexion()
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

        public void retornarDatosVisitaMedicaPorIdEmpresa(decimal idEmpresa)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("id_empresa", idEmpresa);
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

        public bool conectarProcCrearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno, 
                                            string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rut",rut);
                variableSQL.Parameters.Add("contrasena", contraseña);
                variableSQL.Parameters.Add("nombre", nombre);
                variableSQL.Parameters.Add("ape_paterno", appaterno);
                variableSQL.Parameters.Add("ape_materno", apmaterno);
                variableSQL.Parameters.Add("direccion", direccion);
                variableSQL.Parameters.Add("telefono", telefono);
                variableSQL.Parameters.Add("email", email);
                variableSQL.Parameters.Add("id_perfil_usuario", idPerfil);
                variableSQL.Parameters.Add("empresaID", idEmpresa);

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
        /// Metodo para conectar procedimiento que crea un usuario y un medico
        /// </summary>
        /// <param name="rut"></param>
        /// <param name="contrasena"></param>
        /// <param name="nombre"></param>
        /// <param name="appaterno"></param>
        /// <param name="apmaterno"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="idPerfil"></param>
        /// <param name="idEmpresa"></param>
        /// <param name="disponibilidad"></param>
        /// <param name="mailPrivado"></param>
        /// <param name="telefonoPriv"></param>
        /// <returns></returns>
        public bool conectarProcCrearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa, string disponibilidad, string mailPrivado, decimal telefonoPriv)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rut", rut);
                variableSQL.Parameters.Add("contrasena", contraseña);
                variableSQL.Parameters.Add("nombre", nombre);
                variableSQL.Parameters.Add("ape_paterno", appaterno);
                variableSQL.Parameters.Add("ape_materno", apmaterno);
                variableSQL.Parameters.Add("direccion", direccion);
                variableSQL.Parameters.Add("telefono", telefono);
                variableSQL.Parameters.Add("email", email);
                variableSQL.Parameters.Add("id_perfil_usuario", idPerfil);
                variableSQL.Parameters.Add("empresaID", idEmpresa);
                variableSQL.Parameters.Add("disponibilidad", disponibilidad);
                variableSQL.Parameters.Add("mail_privado", mailPrivado);
                variableSQL.Parameters.Add("tel_privado", telefonoPriv);
                

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
        /// Conectar Procedimiento de creacion de Usuario y Trabajador
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
        /// <param name="idEmpresa"></param>
        /// <param name="mailPrivado"></param>
        /// <param name="telPrivado"></param>
        /// <param name="estadoRiesgo"></param>
        /// <param name="contratoId"></param>
        /// <returns></returns>
        public bool conectarProcCrearUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email, decimal idPerfil, decimal idEmpresa, string mailPrivado, decimal telPrivado,
                                    string estadoRiesgo, decimal contratoId)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rut", rut);
                variableSQL.Parameters.Add("contrasena", contraseña);
                variableSQL.Parameters.Add("nombre", nombre);
                variableSQL.Parameters.Add("ape_paterno", appaterno);
                variableSQL.Parameters.Add("ape_materno", apmaterno);
                variableSQL.Parameters.Add("direccion", direccion);
                variableSQL.Parameters.Add("telefono", telefono);
                variableSQL.Parameters.Add("email", email);
                variableSQL.Parameters.Add("id_perfil_usuario", idPerfil);
                variableSQL.Parameters.Add("empresaID", idEmpresa);
                variableSQL.Parameters.Add("mailprivado", mailPrivado);
                variableSQL.Parameters.Add("telprivado", telPrivado);
                variableSQL.Parameters.Add("estriesgo",estadoRiesgo);
                variableSQL.Parameters.Add("contratoid", contratoId);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }
        public bool conectarProcCrearEmpresa(string nomEmpresa, string runEmpresa, string dirEmpresa, decimal telEmpresa, string corEmpresa)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("nomEmpresa", nomEmpresa);
                variableSQL.Parameters.Add("runEmpresa", runEmpresa);
                variableSQL.Parameters.Add("dirEmpresa", dirEmpresa);
                variableSQL.Parameters.Add("telEmpresa", telEmpresa);
                variableSQL.Parameters.Add("corEmpresa", corEmpresa);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcModificarEmpresa(decimal idEmpresa, string nomEmpresa_mod, string runEmpresa_mod, string dirEmpresa_mod, decimal telEmpresa_mod, string corEmpresa_mod)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("idEmpresa", idEmpresa);
                variableSQL.Parameters.Add("nomEmpresa_mod", nomEmpresa_mod);
                variableSQL.Parameters.Add("runEmpresa_mod", runEmpresa_mod);
                variableSQL.Parameters.Add("dirEmpresa_mod", dirEmpresa_mod);
                variableSQL.Parameters.Add("telEmpresa_mod", telEmpresa_mod);
                variableSQL.Parameters.Add("corEmpresa_mod", corEmpresa_mod);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcModificarUsuario(string rut, string contraseña, string nombre, string appaterno, string apmaterno,
                                    string direccion, decimal telefono, string email)
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

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public bool conectarProcCrearVisita(string fecVisita, decimal idEmpresa, decimal idMedico)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("fec_visita", OracleDbType.Date, fecVisita, ParameterDirection.Input);
                variableSQL.Parameters.Add("id_contrato", idEmpresa);
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

        public bool conectarProcEliminarTipoEvaluacion(string descevaluacion)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("descevaluacion", descevaluacion);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcEliminarEmpresa(string rutempresa)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rutempresa", rutempresa);
                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                return true;
            }
            catch (OracleException)
            {

                throw;
            }
        }

        public bool conectarProcEliminarUsuario(string rut)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("rutUsuario", rut);
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

        public bool conectarProcCrearAtencion(string descAtencion, string rut, decimal idVisitaMedica, string fechaAtencion)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("desc_atencion", descAtencion);
                variableSQL.Parameters.Add("rut_trabajador", rut);
                variableSQL.Parameters.Add("fechaAtencion",OracleDbType.Date ,fechaAtencion, ParameterDirection.Input);
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
        
       public void retornarConfirmacionLogin(string rut, string contraseña)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("rutUsuario", rut);
                variableSQL.Parameters.Add("contrUsuario", contraseña);

                variableSQL.ExecuteNonQuery();
                cerrarConexion();
                this.dbDataAdapter = new OracleDataAdapter(variableSQL);
                this.DbDat = new System.Data.DataSet();
                this.dbDataAdapter.Fill(DbDat, this.NombreTabla);

                //string idPerfil = variableSQL.Parameters["idPerfil"].Value.ToString();

                //return idPerfil;

            }
            catch (OracleException ex)
            {

                throw;
            }
        }

        public void retornarEvaluacionesSupervisor(decimal idEmpresa)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("empresaId", idEmpresa);
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

        public void retornarInformesPorEmpresa(decimal idEmpresa)
        {
            comprobarConexion();

            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("idEmpresa", idEmpresa);
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

        public void retornarConsulta(string rut)
        {
            comprobarConexion();
            try
            {
                variableSQL = new OracleCommand(this.intruccioneSQL, this.dbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                variableSQL.Parameters.Add("c_resultadoconsulta", OracleDbType.RefCursor, ParameterDirection.ReturnValue);
                variableSQL.Parameters.Add("Rut", rut);
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
    }
}

