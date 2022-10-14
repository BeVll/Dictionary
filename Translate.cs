using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    internal class Translate
    {
        public List<Word> words { get; set; }
        public string Name { get; set; }
        public Translate() { 
            words = new List<Word>();
        }
        public void AddWord()
        {
            
            Word word = new Word();
            Console.WriteLine("Введите слово -> ");
            word.lan1 = Console.ReadLine();
            string str = string.Empty;
            while (str != "-")
            {
                word = AddWordTranslate(word);
                Console.WriteLine("Добавить еще перевод? (Нет -, Да любое другое)");
                str = Console.ReadLine();
            }
             
            words.Add(word);
        }
        public void DeleteWord()
        {
            Console.Clear();
            int id = -1;
            ShowWords();
            do
            {
                Console.WriteLine("Введите ид слова -> ");
                id = Convert.ToInt32(Console.ReadLine());
                if (id < 0 && id > words.Count - 1)
                    Console.WriteLine("Неправильное ид!");
                else
                    break;
            } while (id < 0 && id > words.Count - 1);
            words.RemoveAt(id);
        }
        public void DeleteTranslate(int id_word)
        {
            Console.Clear();
            int id = -1;
            words[id_word].ShowTranslates();
            do
            {
                Console.WriteLine("Введите ид перевода -> ");
                id = Convert.ToInt32(Console.ReadLine());
                if (id < 0 && id > words[id_word].lan2.Count - 1)
                    Console.WriteLine("Неправильное ид!");
                else
                    break;
            } while (id < 0 && id > words[id_word].lan2.Count - 1);
            words[id_word].lan2.RemoveAt(id);
        }

        public void ChangeTranslate(int id_word)
        {
            Console.Clear();
            int id = -1;
            words[id_word].ShowTranslates();
            do
            {
                Console.WriteLine("Введите ид перевода -> ");
                id = Convert.ToInt32(Console.ReadLine());
                if (id < 0 && id > words[id_word].lan2.Count - 1)
                    Console.WriteLine("Неправильное ид!");
                else
                    break;
            } while (id < 0 && id > words[id_word].lan2.Count - 1);
            Console.WriteLine("Введите новый перевод -> ");
            words[id_word].lan2[id] = Console.ReadLine();
        }
        public void ShowWords()
        {
            for(int i = 0; i < words.Count; i++)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine($"ID: {i}");
                Console.WriteLine($"Слово: {words[i].lan1}");
                Console.WriteLine($"Переводы: ");
                for (int x = 0; x < words[i].lan2.Count; x++)
                {
                    Console.Write($"{words[i].lan2[x]}; ");
                }
            }
        }
        public Word AddWordTranslate(Word w)
        {
            Console.WriteLine("Введите перевод слова -> ");
            string tr = Console.ReadLine();
            w.lan2.Add(tr);
            return w;
        }
        public void AddWordTranslateToList(int id)
        {
            Console.WriteLine("Введите перевод слова -> ");
            string tr = Console.ReadLine();
            words[id].lan2.Add(tr);
        }
    }
}
