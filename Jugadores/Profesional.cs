using System;

namespace SistemaDeportivos
{
    public class Profesional : IJugador
    {
        public int _minutosCorridos = 0;
        public const int MaxMinutos = 40;

        public bool Correr(int minutos)
        {
            if (Cansado())
            {
                Console.WriteLine("El jugador esta muy cansado para correr.");
                return false;
            }

            int totalIntento = _minutosCorridos + minutos;

            if (totalIntento <= MaxMinutos)
            {
                _minutosCorridos = totalIntento;
                Console.WriteLine($"El profesional corrió {minutos} minutos");
                return true;
            }
            else
            {
                _minutosCorridos = MaxMinutos;
                Console.WriteLine("El jugador se cansó antes de terminar.");
                return false;
            }
        }

        public bool Cansado()
        {
            return _minutosCorridos >= MaxMinutos;
        }

        public void Descansar(int minutos)
        {
            _minutosCorridos -= minutos;
            if (_minutosCorridos < 0)
            {
                _minutosCorridos = 0;
            }
            Console.WriteLine($"El jugador descansó {minutos} minutos.");
        }
    }
}