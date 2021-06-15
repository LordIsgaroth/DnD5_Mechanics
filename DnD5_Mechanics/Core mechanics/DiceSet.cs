using System;
using System.Collections.Generic;

namespace DnD5_Mechanics
{
    /// <summary>
    /// Представляет набор N игровых костей одного типа
    /// </summary>
    public class DiceSet
    {
        private static Dictionary<string, DiceSet> diceSets = new Dictionary<string, DiceSet>();

        private string name;
        private int quantity;
        private int edges;

        public string Name { get => name; }
        public int Quantity { get => quantity; }
        public int Edges { get => edges; }

        /// <summary>
        /// Конструктор на основании количества костей и количества граней
        /// </summary>
        /// <param name="quantity">Количество костей</param>
        /// <param name="edges">Количество граней каждой кости</param>
        private DiceSet(int quantity, int edges)
        {
            name = quantity + "d" + edges;
            this.quantity = quantity;
            this.edges = edges;
        }

        /// <summary>
        /// Проверяет, является ли переданное количество граней корректным относительно правил D&D
        /// </summary>
        /// <param name="edges">Количество граней</param>
        private static bool CorrectEdges(int edges)
        {
            if (edges == 4 || edges == 6 || edges == 8 || edges == 10 || edges == 12 || edges == 20 || edges == 100) return true;
            else return false;
        }

        /// <summary>
        /// Получает набор костей по имени
        /// </summary>
        /// <param name="name">Имя вида ndm, где n - количество костей, m - количество граней, напирмер 10d6</param>    
        public static DiceSet GetByName(string name)
        {
            if (diceSets.ContainsKey(name))
            {
                return diceSets[name];
            }
            else
            {
                Tuple<int, int> numbersFromName = GetNumbersFromName(name);

                return new DiceSet(numbersFromName.Item1, numbersFromName.Item2);
            }
        }

        /// <summary>
        /// Получает набор из двух чисел из строки 
        /// </summary>
        /// <param name="name">Имя вида ndm, где n - количество костей, m - количество граней, напирмер 10d6</param>
        /// <returns></returns>
        private static Tuple<int, int> GetNumbersFromName(string name)
        {
            string[] parts = name.Split('d');

            if (parts.Length != 2) throw new ArgumentException("Неверный формат названия набора костей!");

            int quantity;
            int edges;

            if (int.TryParse(parts[0], out quantity) && int.TryParse(parts[1], out edges))
            {
                if (quantity < 1) throw new ArgumentException("Количество не может быть меньше 1!");
                if (!CorrectEdges(edges)) throw new ArgumentException($"Кость с количеством граней {edges} отсутствует в правилах D&D!");

                return new Tuple<int, int>(quantity, edges);
            }
            else throw new ArgumentException("Неверный формат названия набора костей!");
        }
    }
}
