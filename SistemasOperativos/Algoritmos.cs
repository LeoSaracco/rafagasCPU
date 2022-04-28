using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace SistemasOperativos
{
    class Algoritmos
    {
        public void Diseño(DataGridView dgvInicial, DataGridView dgvGrafico)
        {
            for (int i = 0; i < dgvInicial.Rows.Count + 1; i++) // Agrego columnas 
            {
                dgvGrafico.Columns.Add("", "");
            }
            dgvGrafico.Rows.Add(3);
            dgvGrafico.Rows[1].Cells[0].Value = 0;
        }

        public void DiseñoDinamicoRR(DataGridView dgvGrafico)
        {
            for (int i = 0; i < 1; i++) // Agrego columnas 
            {
                dgvGrafico.Columns.Add("", "");
                if (dgvGrafico.Rows.Count == 0)
                {
                    dgvGrafico.Rows.Add(3);
                }
            }
        }

        public void FirstComeFirstServed(DataGridView dgvInicial, DataGridView dgvGrafico)
        {
            Diseño(dgvInicial, dgvGrafico);
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                dgvGrafico.Rows[0].Cells[i + 1].Value = Convert.ToString(dgvInicial.Rows[i].Cells[0].Value);//Paso nombre de los procesos de una grilla a la otra
                dgvGrafico.Rows[2].Cells[i + 1].Value = Convert.ToDouble(dgvInicial.Rows[i].Cells[1].Value);//Paso ráfagas de una grilla a la otra
            }
            double aux = 0;
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                aux += Convert.ToDouble(dgvGrafico.Rows[2].Cells[i + 1].Value); //Acumulo valor de la fila de RAFAGAS
                dgvGrafico.Rows[1].Cells[i + 1].Value = aux; //Se lo paso a la fila de TE y TR
            }
            dgvGrafico.DefaultCellStyle.BackColor = Color.LightGray;
            dgvGrafico.AlternatingRowsDefaultCellStyle.BackColor = Color.Red;
        }

        public void Prioridades(DataGridView dgvInicial, DataGridView dgvGrafico)
        {
            Diseño(dgvInicial, dgvGrafico);
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                dgvGrafico.Rows[0].Cells[i + 1].Value = Convert.ToString(dgvInicial.Rows[i].Cells[0].Value);//Paso nombre de los procesos de una grilla a la otra
                dgvGrafico.Rows[2].Cells[i + 1].Value = Convert.ToDouble(dgvInicial.Rows[i].Cells[1].Value);//Paso ráfagas de una grilla a la otra
            }
            double aux = 0;
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                aux += Convert.ToDouble(dgvGrafico.Rows[2].Cells[i + 1].Value); //Acumulo valor de la fila de RAFAGAS
                dgvGrafico.Rows[1].Cells[i + 1].Value = aux; //Se lo paso a la fila de TE y TR
            }
            dgvGrafico.DefaultCellStyle.BackColor = Color.Azure;
            dgvGrafico.AlternatingRowsDefaultCellStyle.BackColor = Color.Gold;
        }

        public void ShortesJobFirst(DataGridView dgvInicial, DataGridView dgvGrafico)
        {
            Diseño(dgvInicial, dgvGrafico);
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                dgvGrafico.Rows[0].Cells[i + 1].Value = Convert.ToString(dgvInicial.Rows[i].Cells[0].Value);//Paso nombre de los procesos de una grilla a la otra
                dgvGrafico.Rows[2].Cells[i + 1].Value = Convert.ToDouble(dgvInicial.Rows[i].Cells[1].Value);//Paso ráfagas de una grilla a la otra
            }
            double aux = 0;
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                aux += Convert.ToDouble(dgvGrafico.Rows[2].Cells[i + 1].Value); //Acumulo valor de la fila de RAFAGAS
                dgvGrafico.Rows[1].Cells[i + 1].Value = aux; //Se lo paso a la fila de TE y TR
            }
            dgvGrafico.DefaultCellStyle.BackColor = Color.LightCoral;
            dgvGrafico.AlternatingRowsDefaultCellStyle.BackColor = Color.MediumSpringGreen;
        }

        public void RoundRobin(DataGridView dgvInicial, DataGridView dgvGrafico, DataGridView dgvInicial_aux, TextBox txtQuantum)
        {
            bool auxBool = false;
            int quantum = Convert.ToInt16(txtQuantum.Text);
            for (int j = 0; j < dgvInicial.Columns.Count; j++)//Clono grilla a una auxiliar
            {
                for (int i = 0; i < dgvInicial.Rows.Count; i++)
                {
                    dgvInicial_aux.Rows[i].Cells[j].Value = dgvInicial.Rows[i].Cells[j].Value;
                }
            }
            DiseñoDinamicoRR(dgvGrafico);
            dgvGrafico.Rows[1].Cells[0].Value = 0;

            int contador = 0, acumQ = 0;
            while (auxBool == false)
            {
                for (int filas = 0; filas < dgvInicial_aux.Rows.Count; filas++)
                {
                    if (Convert.ToInt16(dgvInicial_aux.Rows[filas].Cells[1].Value) > 0)
                    {
                        DiseñoDinamicoRR(dgvGrafico);

                        if ((Convert.ToDouble(dgvInicial_aux.Rows[filas].Cells[1].Value) < quantum) && (Convert.ToDouble(dgvInicial_aux.Rows[filas].Cells[1].Value) > 0))
                        {
                            dgvGrafico.Rows[2].Cells[contador + 1].Value = Convert.ToDouble(dgvInicial_aux.Rows[filas].Cells[1].Value);
                            acumQ = Convert.ToInt16(dgvInicial_aux.Rows[filas].Cells[1].Value);
                            dgvInicial_aux.Rows[filas].Cells[1].Value = 0;
                            dgvGrafico.Rows[0].Cells[contador + 1].Value = Convert.ToString(dgvInicial_aux.Rows[filas].Cells[0].Value);
                        }
                        if ((Convert.ToDouble(dgvInicial_aux.Rows[filas].Cells[1].Value) >= 0) && (Convert.ToDouble(dgvInicial_aux.Rows[filas].Cells[1].Value) >= quantum))
                        {
                            dgvInicial_aux.Rows[filas].Cells[1].Value = Convert.ToDouble(dgvInicial_aux.Rows[filas].Cells[1].Value) - quantum;
                            dgvGrafico.Rows[0].Cells[contador + 1].Value = Convert.ToString(dgvInicial_aux.Rows[filas].Cells[0].Value);
                            dgvGrafico.Rows[2].Cells[contador + 1].Value = quantum;
                        }
                        contador++;
                    }
                }
                auxBool = GrillaCeroRR(dgvInicial_aux);
            }
            double auxRR = 0;
            for (int i = 0; i < (dgvGrafico.Columns.Count - 1); i++)
            {
                auxRR += Convert.ToDouble(dgvGrafico.Rows[2].Cells[i + 1].Value); //Acumulo valor de la fila de RAFAGAS
                dgvGrafico.Rows[1].Cells[i + 1].Value = auxRR; //Se lo paso a la fila de TE y TR
            }
            dgvGrafico.DefaultCellStyle.BackColor = Color.SandyBrown;
            dgvGrafico.AlternatingRowsDefaultCellStyle.BackColor = Color.Moccasin;

        }
        public void ordeno_grilla(DataGridView tablaUsuario, int columna, int algoritmo)
        {
            for (int VecesRecorroColum = 0; VecesRecorroColum < tablaUsuario.Rows.Count; VecesRecorroColum++)
            {
                for (int f = 0; f < tablaUsuario.Rows.Count; f++)
                {
                    double datoA = 0, datoB = 0;
                    datoA = Convert.ToDouble(tablaUsuario[columna, f].Value);
                    if (f < tablaUsuario.Rows.Count - 1)
                        datoB = Convert.ToDouble(tablaUsuario[columna, f + 1].Value);
                    if (datoA > datoB)
                    {
                        if (algoritmo == 1) //Algoritmo 1 ---> SJF
                        {
                            intercambioValores(tablaUsuario, columna, f);
                            intercambioValores(tablaUsuario, columna - 1, f);
                            intercambioValores(tablaUsuario, columna + 1, f);
                        }
                        else //Algoritmo ---> Prioridades
                        {
                            intercambioValores(tablaUsuario, columna, f);
                            intercambioValores(tablaUsuario, columna - 1, f);
                            intercambioValores(tablaUsuario, columna - 2, f);
                        }

                    }
                }
            }
        }
        public void intercambioValores(DataGridView tablaUsuario, int columna, int fila)
        {
            string aux;
            aux = Convert.ToString(tablaUsuario[columna, fila].Value);
            if (fila < tablaUsuario.Rows.Count - 1)
            {
                tablaUsuario[columna, fila].Value = tablaUsuario[columna, fila + 1].Value;
                tablaUsuario[columna, fila + 1].Value = aux;
            }
        }

        public bool GrillaCeroRR(DataGridView dgvInicial_aux)
        {
            double acumulador = 0;
            for (int i = 0; i < dgvInicial_aux.Rows.Count; i++)
            {
                if (Convert.ToDouble(dgvInicial_aux.Rows[i].Cells[1].Value) > 0)
                {
                    acumulador = Convert.ToDouble(dgvInicial_aux.Rows[i].Cells[1].Value);
                    break;
                }
                else
                {
                    //acumulador = Convert.ToDouble(dgvInicial_aux.Rows[i].Cells[1].Value);
                    continue;
                }
            }
            if (acumulador == 0)
                return (true);
            else
                return (false);
        }
        public bool GrillaCeroFull(DataGridView dgvInicial, int columna)
        {
            double acumulador = 0;
            for (int i = 0; i < dgvInicial.Rows.Count; i++)
            {
                if (Convert.ToString(dgvInicial.Rows[i].Cells[columna].Value) == "")
                {
                    acumulador++;
                    break;
                }
                else
                {
                    //acumulador = Convert.ToDouble(dgvInicial_aux.Rows[i].Cells[1].Value);
                    continue;
                }
            }
            if (acumulador == 0)
                return (true);
            else
                return (false);
        }
    }
}