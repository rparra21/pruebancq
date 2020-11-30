using MvcUserInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUserInterface.Utils
{
    public class CargaCombos
    {
        #region Metodos para la carga de los combos del index

        //Metodo para crear la lista que usa el combo de colaboradores
        public SelectList ToSelectListColaboradores(List<Colaborador> colaboradores)
        {
            try
            {
                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem()
                {
                    Text = "Todos",
                    Value = 0.ToString()
                });
                foreach (var row in colaboradores)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row.Nombre,
                        Value = row.ColaboradorId.ToString()
                    });
                }

                return new SelectList(list, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para cargar las prioridades
        public List<Combo> CargarPrioridades()
        {
            try
            {
                List<Combo> listaPrioridades = new List<Combo>();
                string[] prioridades = new string[4] { "Todos", "Alta", "Media", "Baja" };
                for (int i = 0; i < prioridades.Length; i++)
                {
                    Combo prioridad = new Combo();
                    prioridad.Valor = prioridades[i];
                    prioridad.Texto = prioridades[i];
                    listaPrioridades.Add(prioridad);
                }

                return listaPrioridades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para crear la lista que usa el combo de prioridades
        public SelectList ToSelectListPrioridades()
        {
            try
            {
                List<Combo> data = CargarPrioridades();
                List<SelectListItem> list = new List<SelectListItem>();

                foreach (var row in data)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row.Texto,
                        Value = row.Valor.ToString()
                    });
                }

                return new SelectList(list, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para cargar los estados
        public List<Combo> CargarEstados()
        {
            List<Combo> listaEstados = new List<Combo>();
            string[] estados = new string[4] { "Todos", "Pendiente", "En Proceso", "Finalizada" };
            for (int i = 0; i < estados.Length; i++)
            {
                Combo estado = new Combo();
                estado.Valor = estados[i];
                estado.Texto = estados[i];
                listaEstados.Add(estado);
            }

            return listaEstados;
        }

        //Metodo para crear la lista que usa el combo de estados
        public SelectList ToSelectListEstados()
        {
            List<Combo> data = CargarEstados();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var row in data)
            {
                list.Add(new SelectListItem()
                {
                    Text = row.Texto,
                    Value = row.Valor.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        #endregion

        #region Metodos para la carga de los combos de agregar y editar

        //Metodo para crear la lista que usa el combo de colaboradores
        public SelectList ToSelectListColaboradoresDos(List<Colaborador> colaboradores)
        {
            try
            {
                List<SelectListItem> list = new List<SelectListItem>();
                foreach (var row in colaboradores)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row.Nombre,
                        Value = row.ColaboradorId.ToString()
                    });
                }

                return new SelectList(list, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para cargar las prioridades
        public List<Combo> CargarPrioridadesDos()
        {
            try
            {
                List<Combo> listaPrioridades = new List<Combo>();
                string[] prioridades = new string[3] { "Alta", "Media", "Baja" };
                for (int i = 0; i < prioridades.Length; i++)
                {
                    Combo prioridad = new Combo();
                    prioridad.Valor = prioridades[i];
                    prioridad.Texto = prioridades[i];
                    listaPrioridades.Add(prioridad);
                }

                return listaPrioridades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para crear la lista que usa el combo de prioridades
        public SelectList ToSelectListPrioridadesDos()
        {
            try
            {
                List<Combo> data = CargarPrioridadesDos();
                List<SelectListItem> list = new List<SelectListItem>();

                foreach (var row in data)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row.Texto,
                        Value = row.Valor.ToString()
                    });
                }

                return new SelectList(list, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Metodo para cargar los estados
        public List<Combo> CargarEstadosDos()
        {
            List<Combo> listaEstados = new List<Combo>();
            string[] estados = new string[3] { "Pendiente", "En Proceso", "Finalizada" };
            for (int i = 0; i < estados.Length; i++)
            {
                Combo estado = new Combo();
                estado.Valor = estados[i];
                estado.Texto = estados[i];
                listaEstados.Add(estado);
            }

            return listaEstados;
        }

        //Metodo para crear la lista que usa el combo de estados
        public SelectList ToSelectListEstadosDos()
        {
            List<Combo> data = CargarEstadosDos();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (var row in data)
            {
                list.Add(new SelectListItem()
                {
                    Text = row.Texto,
                    Value = row.Valor.ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        #endregion
    }
}