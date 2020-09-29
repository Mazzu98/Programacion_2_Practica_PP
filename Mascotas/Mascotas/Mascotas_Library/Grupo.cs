using System;
using System.Collections.Generic;
using System.Text;

namespace Mascotas_Library
{
    public class Grupo
    {
        private List<Mascota> manada;
        private string nombre;
        private static EtipoManada tipo;

        public EtipoManada Tipo { set => tipo = value; }

        static Grupo()
        {
            Grupo.tipo = EtipoManada.Unica;
        }

        private Grupo()
        {
            this.manada = new List<Mascota>();
        }

        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }

        public Grupo(string nombre, EtipoManada tipo) : this(nombre)
        {
            Grupo.tipo = tipo;
        }

        public static bool operator ==(Grupo g, Mascota m)
        {
            return g.manada.Contains(m);
        }

        public static bool operator !=(Grupo g, Mascota m)
        {
            return !(g == m);
        }

        public static Grupo operator +(Grupo g, Mascota m)
        {
            if(!(g == m))
            {
                g.manada.Add(m);
            }
            else
            {
                Console.WriteLine("Ya está " + m.ToString() + " En el grupo");
            }
            return g;
        }

        public static Grupo operator -(Grupo g, Mascota m)
        {
            if (g == m)
            {
                g.manada.Remove(m);
            }
            else
            {
                Console.WriteLine("No está " + m.ToString() + " En el grupo");
            }
            return g;
        }

        public static implicit operator string(Grupo g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Grupo: {g.nombre} - tipo: {Grupo.tipo}");
            sb.AppendLine($"Integrantes ({g.manada.Count})");
            foreach(Mascota mascota in g.manada)
            {
                sb.AppendLine(mascota.ToString());
            }

            return sb.ToString();
        }

    }
}
