using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Registro_Actividades
{
    public partial class Frm_Registros : Form
    {
        String Str_Cadena_Conexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Actividades.accdb;Persist Security Info=False;";

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Frm_Registros
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public Frm_Registros()
        {
            InitializeComponent();
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Form1_Load
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                Limpiar();
                Consultar_Fecha();
                Consultar_Empresa();
                Consultar_Sindicato();
                Consultar_Fotos();

                Lbl_Fecha_Seleccionada.Text = Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString()).ToString("dd/MMM/yyyy");
            }
            catch (Exception ex)
            {
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Fecha
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public void Consultar_Fecha()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                Str_Sql = "select fecha, actividad from Ope_Actividades where fecha = @fecha";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    Txt_Actividades.Text = Registro["actividad"].ToString();
                    Mnt_Cal_Fecha.SelectionStart = Convert.ToDateTime( Registro["fecha"].ToString());
                }

            }
            catch (Exception ex)
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Fecha
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public DataTable Consultar_Actividades_Fecha_Reporte()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                Str_Sql = "select fecha, actividad from Ope_Actividades where fecha BETWEEN @fecha and @fecha_fin order by fecha asc";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Dtp_Fecha_Inicio.Value)));
                Obj_Comando.Parameters.Add("@fecha_fin", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Dtp_Fecha_Fin.Value)));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();

                
            }
            catch (Exception ex)
            {
            }
            return Dt_Consulta;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Empresa
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public void Consultar_Empresa()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                Str_Sql = "select imagen from cat_empresas";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                //Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    String Str_Ruta_Logo = Registro["imagen"].ToString();

                    System.Drawing.Image Imagen_Editar = System.Drawing.Image.FromFile(Str_Ruta_Logo);
                    Cambiar_Tamanio_Imagen(Imagen_Editar, Pct_Box_Empresa, 160, 95);
                }

            }
            catch (Exception ex)
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Empresa
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public Image Obtener_Imagen_Empresa()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            System.Drawing.Image Imagen_Editar  = null;
            try
            {
                Str_Sql = "select imagen from cat_empresas";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                //Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    String Str_Ruta_Logo = Registro["imagen"].ToString();

                    Imagen_Editar = System.Drawing.Image.FromFile(Str_Ruta_Logo);
                }

            }
            catch (Exception ex)
            {
            }

            return Imagen_Editar;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Obtener_Imagen_Sindicato
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public Image Obtener_Imagen_Sindicato()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            System.Drawing.Image Imagen_Editar = null;
            try
            {
                Str_Sql = "select imagen from cat_sindicato";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                //Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    String Str_Ruta_Logo = Registro["imagen"].ToString();

                    Imagen_Editar = System.Drawing.Image.FromFile(Str_Ruta_Logo);
                    
                }

            }
            catch (Exception ex)
            {
            }

            return Imagen_Editar;
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Sindicato
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public void Consultar_Sindicato()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                Str_Sql = "select imagen from cat_sindicato";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                //Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    String Str_Ruta_Logo = Registro["imagen"].ToString();

                    System.Drawing.Image Imagen_Editar = System.Drawing.Image.FromFile(Str_Ruta_Logo);
                    Cambiar_Tamanio_Imagen(Imagen_Editar, Pct_Box_Sindicato, 160, 95);
                }

            }
            catch (Exception ex)
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Fotos
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public void Consultar_Fotos()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                Str_Sql = "select no_media, fecha, imagen from ope_media where fecha = @fecha";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


                if (Dt_Consulta != null && Dt_Consulta.Rows.Count > 0)
                {
                    Grid_Fotos.DataSource = Dt_Consulta;
                    Pct_Box_Foto.Visible = true;
                }
                else
                {
                    Grid_Fotos.DataSource = new DataTable();
                    Pct_Box_Foto.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Consultar_Fotos
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public DataTable Consultar_Fotos_Dia(String Str_Fecha)
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                Str_Sql = "select no_media, fecha, imagen from ope_media where fecha = @fecha";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                Obj_Comando.Parameters.Add("@fecha", Str_Fecha);

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();


            }
            catch (Exception ex)
            {
            }

            return Dt_Consulta;
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Btn_Nuevo_Click
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Btn_Nuevo_Click(object sender, EventArgs e)
        {
           

        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Btn_Modificar_Click
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Btn_Modificar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Txt_Actividades.Text))
            {
                Alta();
                MessageBox.Show("Elemento guardado", "Aviso");
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Btn_Agregar_Imagen_Click
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Btn_Agregar_Imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog Ope_fil_Ventana = new OpenFileDialog();
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            String Str_Sql = "";
            String Str_Ruta = "";
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            System.Drawing.Image imageIn = null;
            Double Db_No_Media = 0;

            try
            {
                Str_Ruta = "C:/Registro_Actividades/Actividades/" + string.Format("{0:dd_MM_yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())) + "/";
                Ope_fil_Ventana.Filter = ".jpg|*.jpg";

                if (!System.IO.Directory.Exists(Str_Ruta))
                {
                    System.IO.Directory.CreateDirectory(Str_Ruta);
                }


                Str_Sql = "select max(No_Media) as No_Media from ope_media";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                
                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();

                foreach (DataRow Registro in Dt_Consulta.Rows)
                {
                    Db_No_Media = Convert.ToDouble(Registro["No_Media"].ToString()) + 1;
                }

                //*************************************************************************************************
                if (Ope_fil_Ventana.ShowDialog() == DialogResult.OK)
                {
                    Str_Ruta += Db_No_Media + ".jpg";
                    //FileStream foto = new FileStream(Ope_fil_Ventana.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    //Byte[] arreglo = new Byte[foto.Length];
                    //BinaryReader reader = new BinaryReader(foto);
                    //arreglo = reader.ReadBytes(Convert.ToInt32(foto.Length));


                    //  se pasa el archivo como copia
                    if(!System.IO.File.Exists(Str_Ruta))
                        System.IO.File.Copy(Ope_fil_Ventana.FileName, Str_Ruta);

                    // Se extraen los bytes del buffer para asignarlos como valor para el 
                    // parámetro.

                    Str_Sql = "insert into ope_media (fecha, imagen) values ('" + string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())) + "','" + Str_Ruta + "')";

                    Obj_Comando = new OleDbCommand();
                    Obj_Conexion.Open();
                    Obj_Comando.Connection = Obj_Conexion;
                    Obj_Comando.CommandText = Str_Sql;
                    Obj_Comando.ExecuteNonQuery();
                    Obj_Conexion.Close();
                }

                Consultar_Fotos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Aviso", MessageBoxButtons.OK);
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Btn_Quitar_Click
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Btn_Quitar_Click(object sender, EventArgs e)
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
         
            try
            {


                if (Grid_Fotos.CurrentRow != null)
                {
                    if (MessageBox.Show("Desea eliminar la foto", "Aviso", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                    {

                        Str_Sql = "delete from ope_media where no_media = " + Grid_Fotos.CurrentRow.Cells["no_media"].Value.ToString() + "";
                        Obj_Conexion.Open();
                        Obj_Comando.Connection = Obj_Conexion;
                        Obj_Comando.CommandText = Str_Sql;
                        Obj_Comando.ExecuteNonQuery();
                        Obj_Conexion.Close();


                        Pct_Box_Foto.Image = null;
                        Pct_Box_Foto.Refresh();


                        if (System.IO.File.Exists(Grid_Fotos.CurrentRow.Cells["imagen"].Value.ToString()))
                        {
                            System.IO.File.Delete(Grid_Fotos.CurrentRow.Cells["imagen"].Value.ToString());
                        }

                    }
                }
                else
                {
                    MessageBox.Show("No existen fotos que eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Consultar_Fotos();
            }
            catch (Exception ex)
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Alta
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Alta()
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            String Str_Sql = ""; 
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();

            try
            {
                Str_Sql = "select fecha, actividad from Ope_Actividades where fecha = @fecha";
                Obj_Conexion.Open();
                Obj_Comando.Connection = Obj_Conexion;
                Obj_Comando.CommandText = Str_Sql;
                Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                if (Obj_Reader != null && Obj_Reader.HasRows == true)
                {
                    Dt_Consulta.Load(Obj_Reader);
                }

                Obj_Conexion.Close();



                if (Dt_Consulta != null && Dt_Consulta.Rows.Count == 0)
                {
                    Str_Sql = "insert into ope_actividades (fecha, actividad) values ('" + string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())) + "','" + Txt_Actividades.Text + "')";

                    Obj_Comando = new OleDbCommand();
                    Obj_Conexion.Open();
                    Obj_Comando.Connection = Obj_Conexion;
                    Obj_Comando.CommandText = Str_Sql;
                    Obj_Comando.ExecuteNonQuery();
                    Obj_Conexion.Close();
                }
                else
                {
                    Obj_Comando = new OleDbCommand();
                    Str_Sql = "update ope_actividades set actividad = @actividad where fecha = @fecha";
                    Obj_Conexion.Open();
                    Obj_Comando.Connection = Obj_Conexion;
                    Obj_Comando.CommandText = Str_Sql;
                    Obj_Comando.Parameters.Add("@actividad", Txt_Actividades.Text); 
                    Obj_Comando.Parameters.Add("@fecha", string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString())));

                    Obj_Comando.ExecuteNonQuery();
                    Obj_Conexion.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Limpiar
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Limpiar()
        {
            try
            {
                //  limpía la caja
                Txt_Actividades.Text = "";
                Pct_Box_Foto.Image = null;
                Pct_Box_Foto.Refresh();
                Grid_Fotos.DataSource = new DataTable();
            }
            catch (Exception ex)
            {
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Mnt_Cal_Fecha_DateChanged
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Mnt_Cal_Fecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                Limpiar();
                Consultar_Fecha();
                Consultar_Fotos();
                Lbl_Fecha_Seleccionada.Text = Convert.ToDateTime(Mnt_Cal_Fecha.SelectionStart.ToString()).ToString("dd/MMM/yyyy");
            }
            catch (Exception ex)
            {
            }
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Grid_Fotos_SelectionChanged
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Grid_Fotos_SelectionChanged(object sender, EventArgs e)
        {
            OleDbConnection Obj_Conexion = new OleDbConnection(Str_Cadena_Conexion);
            OleDbCommand Obj_Comando = new OleDbCommand();
            OleDbDataReader Obj_Reader;
            DataSet Ds_Fill = new System.Data.DataSet();
            DataTable Dt_Consulta = new System.Data.DataTable();
            String Str_Sql = "";
            try
            {
                if (Grid_Fotos.CurrentRow != null)
                {
                    Str_Sql = "select imagen from ope_media where no_media = @no_media";
                    Obj_Conexion.Open();
                    Obj_Comando.Connection = Obj_Conexion;
                    Obj_Comando.CommandText = Str_Sql;
                    Obj_Comando.Parameters.Add("@no_media", Grid_Fotos.CurrentRow.Cells["no_media"].Value.ToString());

                    Obj_Reader = Obj_Comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                    if (Obj_Reader != null && Obj_Reader.HasRows == true)
                    {
                        Dt_Consulta.Load(Obj_Reader);
                    }

                    Obj_Conexion.Close();

                    foreach (DataRow Registro in Dt_Consulta.Rows)
                    {
                        String Str_Ruta_Logo = Registro["imagen"].ToString();

                        System.Drawing.Image Imagen_Editar = System.Drawing.Image.FromFile(Str_Ruta_Logo);
                        Cambiar_Tamanio_Imagen(Imagen_Editar, Pct_Box_Foto, 659, 448);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION:    Cambiar_Tamanio_Imagen
        ///DESCRIPCION:             
        ///PARAMETROS:
        ///CREO:                    Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO:              04/Marzo/2013
        ///MODIFICO:
        ///FECHA_MODIFICO:
        ///CAUSA_MODIFICACION:
        ///*******************************************************************************
        private void Cambiar_Tamanio_Imagen(System.Drawing.Image Imagen_, System.Windows.Forms.PictureBox Pic_Box_, int Int_Width, int Int_Heigth )
        {
            System.Drawing.Image Imagen_Editada;
            System.Drawing.Image Imagen_Original = Imagen_;

            try
            {
                //Si el ancho de pixceles sobrepasa los 480 se reduce la imagen a los 480 pixceles
                if ((Imagen_Original.Width > Int_Width) || (Imagen_Original.Height > Int_Heigth))
                {
                    //Asignamos el valor del ancho y alto
                    int Ancho = 0;
                    int Alto = 0;

                    if (Imagen_Original.Width > Int_Width)
                    {
                        Ancho = Int_Width;
                    }
                    else
                    {
                        Ancho = Imagen_Original.Width;
                    }


                    if (Imagen_Original.Height > Int_Heigth)
                    {
                        Alto = Int_Heigth;
                    }
                    else
                    {
                        Alto = Imagen_Original.Height;
                    }

                    //Aqui editamos la imagen
                    System.Drawing.Image.GetThumbnailImageAbort Abort = new System.Drawing.Image.GetThumbnailImageAbort(Devolucion_llamada);
                    Imagen_Editada = Imagen_Original.GetThumbnailImage(Ancho, Alto, Abort, IntPtr.Zero);


                    //Se elimina el archivo de temporal
                    Imagen_Original.Dispose();

                    Pic_Box_.Image = Imagen_Editada;
                }
                else
                {
                    Pic_Box_.Image = Imagen_Original;
                }
                

            }
            catch (Exception ex)
            {
                
            }

        }

        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Devolucion_llamada
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        public bool Devolucion_llamada()
        {
            return true;
        }
        ///*******************************************************************************
        ///NOMBRE DE LA FUNCION  :  Btn_Reporte_Click
        ///DESCRIPCION           :  
        ///PARAMETROS            :
        ///CREO                  :  Hugo Enrique Ramírez Aguilera
        ///FECHA_CREO            :  10/Enero/2016
        ///MODIFICO              :
        ///FECHA_MODIFICO        :
        ///CAUSA_MODIFICACION    :
        ///*******************************************************************************
        private void Btn_Reporte_Click(object sender, EventArgs e)
        {
            SaveFileDialog Sfd_Ruta_Archivo = new SaveFileDialog();
            System.Drawing.Image Imagen_Empresa = null;
            System.Drawing.Image Imagen_Sindicato = null;
            Int32 Fila = 8;
            DataTable Dt_Fechas = new System.Data.DataTable();
            DataTable Dt_Imagenes = new System.Data.DataTable();
            Int32 Cont_Imagenes = 0;
            Int32 Cont_Fotos = 0;
            Int32 Int_Posicion_Columna = 0; 
            OfficeOpenXml.Drawing.ExcelPicture Exc_Imagen_Foto = null;
            try
            {
                Imagen_Empresa = Obtener_Imagen_Empresa();
                Imagen_Sindicato = Obtener_Imagen_Sindicato();
                 // *******************************************************************************************************************************
                //  se obtiene la ruta del archivo
                Sfd_Ruta_Archivo.Filter = "Execl files (*.xlsx)|*.xlsx";
                Sfd_Ruta_Archivo.FilterIndex = 0;
                Sfd_Ruta_Archivo.RestoreDirectory = true;

                // *******************************************************************************************************************************

                //  validacion a la ruta del archivo
                if (Sfd_Ruta_Archivo.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Sfd_Ruta_Archivo.FileName))
                    {
                        File.Delete(Sfd_Ruta_Archivo.FileName);
                    }

                    FileInfo newFile = new FileInfo(Sfd_Ruta_Archivo.FileName);

                    using (ExcelPackage Excel_Actividades = new ExcelPackage(newFile))
                    {
                        ExcelWorksheet Detallado = Excel_Actividades.Workbook.Worksheets.Add("Actividades");

                        Detallado.Column(2).Width = 12;

                        //  logos **********************************************************************************************************
                        OfficeOpenXml.Drawing.ExcelPicture Exc_Imagen_Empresa = null;
                        Exc_Imagen_Empresa = Detallado.Drawings.AddPicture("Logo_Empresa", Imagen_Empresa);
                        Exc_Imagen_Empresa.From.Column = 1;
                        Exc_Imagen_Empresa.From.Row = 0;
                        Exc_Imagen_Empresa.SetSize(170, 120);

                        Exc_Imagen_Empresa.From.ColumnOff = Pixel2MTU(2);
                        Exc_Imagen_Empresa.From.RowOff = Pixel2MTU(2);


                        OfficeOpenXml.Drawing.ExcelPicture Exc_Imagen_Sindicato = null;
                        Exc_Imagen_Sindicato = Detallado.Drawings.AddPicture("Logo_Sindicato", Imagen_Sindicato);
                        Exc_Imagen_Sindicato.From.Column = 10;
                        Exc_Imagen_Sindicato.From.Row = 0;
                        Exc_Imagen_Sindicato.SetSize(170, 120);

                        Exc_Imagen_Sindicato.From.ColumnOff = Pixel2MTU(2);
                        Exc_Imagen_Sindicato.From.RowOff = Pixel2MTU(2);


                        //  encabezado **********************************************************************************************
                        Detallado.Cells["E3"].Value = "Actividades realizadas";
                        Detallado.Cells["E3"].Style.Font.Bold = true;
                        Detallado.Cells["E3:J3"].Merge = true;
                        Detallado.Cells["E3:J3"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["E3:J3"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                        Detallado.Cells["E4"].Value = Convert.ToDateTime( Dtp_Fecha_Inicio.Value).ToString("dd/MMM/yyyy") + " a " + Convert.ToDateTime( Dtp_Fecha_Fin.Value).ToString("dd/MMM/yyyy");
                        Detallado.Cells["E4"].Style.Font.Bold = true;
                        Detallado.Cells["E4:J4"].Merge = true;
                        Detallado.Cells["E4:J4"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                        Detallado.Cells["E4:J4"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                       

                        //  registro de actividades ************************************************************************************************
                        Dt_Fechas = Consultar_Actividades_Fecha_Reporte();

                        foreach (DataRow Registro in Dt_Fechas.Rows)
                        {
                            //  encabezado  *********************************************************************************************************
                            Detallado.Cells["B" + Fila].Value = "Fecha";
                            Detallado.Cells["B" + Fila].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Detallado.Cells["B" + Fila].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                            

                            Detallado.Cells["C" + Fila].Value = "Actividad";
                            Detallado.Cells["C" + Fila].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            Detallado.Cells["C" + Fila].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                            Detallado.Cells["C"+Fila +":O" + Fila].Merge = true;
                            Detallado.Cells["C" + Fila + ":O" + Fila].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            Detallado.Cells["C" + Fila + ":O" + Fila].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                           

                            Fila++;
                            
                            //  detalle *********************************************************************************************************

                            Detallado.Row(Fila).Height = 150;
                            Detallado.Cells["B" + Fila].Value = Convert.ToDateTime(Registro["Fecha"].ToString()).ToString("dd/MM/yyyy");
                            Detallado.Cells["B" + Fila].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                            Detallado.Cells["B" + Fila].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;

                            Detallado.Cells["C" + Fila].Value = Registro["Actividad"].ToString();
                            Detallado.Cells["C" + Fila + ":O" + Fila].Merge = true;
                            Detallado.Cells["C" + Fila + ":O" + Fila].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                            Detallado.Cells["C" + Fila + ":O" + Fila].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                            Detallado.Cells["C" + Fila + ":O" + Fila].Style.WrapText = true;
                            Fila = Fila + 1;

                            //  imagenes *********************************************************************************************************
                            Dt_Imagenes = new System.Data.DataTable();
                            Dt_Imagenes = Consultar_Fotos_Dia(Convert.ToDateTime(Registro["Fecha"].ToString()).ToString("dd/MM/yyyy"));

                            Cont_Imagenes = 0;
                            int Registros_Recorridos = 0;

                            if (Dt_Imagenes.Rows.Count > 0)
                            {
                                foreach (DataRow Dr_Fotos in Dt_Imagenes.Rows)
                                {
                                    //  se obtiene la foto del dia
                                    String Str_Ruta_Logo = Dr_Fotos["imagen"].ToString();
                                    System.Drawing.Image Imagen_Editar = System.Drawing.Image.FromFile(Str_Ruta_Logo);

                                    Exc_Imagen_Foto = null;
                                    Exc_Imagen_Sindicato = Detallado.Drawings.AddPicture("Foto_" + Cont_Fotos.ToString(), Imagen_Editar);

                                    Exc_Imagen_Sindicato.From.Column = Cont_Imagenes * 4;
                                    Exc_Imagen_Sindicato.From.Row = Fila;
                                    Exc_Imagen_Sindicato.SetSize(190, 190);

                                    Exc_Imagen_Sindicato.From.ColumnOff = Pixel2MTU(2);
                                    Exc_Imagen_Sindicato.From.RowOff = Pixel2MTU(2);

                                    //  fin de la insercion de la imagen
                                    Cont_Imagenes++;
                                    Cont_Fotos++;
                                    Registros_Recorridos++;

                                    if (Cont_Imagenes > 3)
                                    {
                                        Cont_Imagenes = 0;
                                        if (Registros_Recorridos < Dt_Imagenes.Rows.Count - 1)
                                            Fila = Fila + 12;
                                    }

                                }// fin foreach fotos

                                if (Cont_Imagenes <= 3)
                                {
                                    Fila = Fila + 10;
                                }
                                //  fin de los detalles *********************************************************************************************************
                                Fila = Fila + 2;
                            }
                            else
                            {   
                                //  fin de los detalles *********************************************************************************************************
                                Fila = Fila + 1;
                            }
                        }


                        //  se guarda el archivo ****************************************************************************************
                        Excel_Actividades.Save();

                        MessageBox.Show("El reporte se creo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }// fin del using

                }// fin del sdf_ruta_archivo
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Aviso", MessageBoxButtons.OK);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pixels"></param>
        /// <returns></returns>
        public int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }
    }
}
