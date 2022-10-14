using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Dictionary
{
    internal class ControlDictionary
    {
        public List<Translate> translates = new List<Translate>();
        public string Path { get; set; }
        public void SaveDictionary()
        {
            string json = JsonConvert.SerializeObject(translates);

            File.WriteAllText(Path + "\\dictionary.json", json);
        }
        public void LoadDictionary()
        {
            if (File.Exists(Path + "\\dictionary.json") == false)
                File.Create(Path + "\\dictionary.json");
            else
            {
                string json = File.ReadAllText(Path + "\\dictionary.json");
                if (json.Length > 0)
                    translates = JsonConvert.DeserializeObject<List<Translate>>(json);
            }
        }
        public void CreateDictionary()
        {
            Translate tl = new Translate();
            Console.WriteLine("Введите название словаря(рус-англ и тд) -> ");
            tl.Name = Console.ReadLine();
            translates.Add(tl);
        }
        public void DeleteDictionary()
        {
            int id = -1;
            ShowDictionaries();
            do
            {
                Console.WriteLine("Введите ид словаря -> ");
                id = Convert.ToInt32(Console.ReadLine());
                if (id < 0 && id > translates.Count - 1)
                    Console.WriteLine("Неправильное ид!");
                else
                    break;
            } while (id < 0 && id > translates.Count - 1);
            translates.RemoveAt(id);
        }
        public void ShowDictionaries()
        {
            for(int i = 0; i < translates.Count; i++)
            {
                Console.WriteLine("================================================================");
                Console.WriteLine($"ID: {i}");
                Console.WriteLine($"Название: {translates[i].Name}");
                Console.WriteLine($"Количество слов: {translates[i].words.Count}");
            }
        }
        public void Menu()
        {
            int menu = 0;
            while(menu != 5)
            {
                Console.Clear();
                Console.WriteLine("1 - Создать словарь;");
                Console.WriteLine("2 - Удалить словарь;");
                Console.WriteLine("3 - Изменить словарь/Найти перевод;");
                Console.WriteLine("4 - Сохранить слово и переводы в файл;");
                Console.WriteLine("5 - Выход;");
                menu = Convert.ToInt32(Console.ReadLine());
                if(menu == 1)
                    CreateDictionary();
                else if (menu == 2)
                    DeleteDictionary();
                else if (menu == 3)
                {
                    menu = 0;
                    int id = -1;
                    ShowDictionaries();
                    do
                    {
                        Console.WriteLine("Введите ид словаря -> ");
                        id = Convert.ToInt32(Console.ReadLine());
                        if (id < 0 && id > translates.Count - 1)
                            Console.WriteLine("Неправильное ид!");
                        else
                            break;
                    } while (id < 0 && id > translates.Count - 1);
                    menu = 0;

                    while (menu != 5)
                    {
                        Console.Clear();
                        Console.WriteLine("1 - Добавить слово;");
                        Console.WriteLine("2 - Удалить слово;");
                        Console.WriteLine("3 - Изменить слово;");
                        Console.WriteLine("4 - Найти перевод слово;");
                        Console.WriteLine("5 - Выход;");

                        menu = Convert.ToInt32(Console.ReadLine());
                        if (menu == 1)
                            translates[id].AddWord();
                        else if (menu == 2)
                            translates[id].DeleteWord();
                        else if (menu == 3)
                        {
                            Console.Clear();
                            translates[id].ShowWords();
                            int id_word = -1;
                            do
                            {
                                Console.WriteLine("Введите ид слова -> ");
                                id_word = Convert.ToInt32(Console.ReadLine());
                                if (id_word < 0 && id > translates[id_word].words.Count - 1)
                                    Console.WriteLine("Неправильное ид!");
                                else
                                    break;
                            } while (id < 0 && id > translates[id_word].words.Count - 1);

                            while (menu != 5)
                            {
                                Console.Clear();

                                Console.WriteLine("1 - Добавить перевод;");
                                Console.WriteLine("2 - Удалить перевод;");
                                Console.WriteLine("3 - Изменить перевод;");
                                Console.WriteLine("4 - Изменить слово;");
                                Console.WriteLine("5 - Выход;");
                                menu = Convert.ToInt32(Console.ReadLine());
                                if (menu == 1)
                                    translates[id].AddWordTranslateToList(id_word);
                                else if (menu == 2)
                                    translates[id].DeleteTranslate(id_word);
                                else if (menu == 3)
                                    translates[id].ChangeTranslate(id_word);
                                else if (menu == 4)
                                {
                                    Console.WriteLine("Введите новое слово -> ");
                                    translates[id].words[id_word].lan1 = Console.ReadLine();
                                }
                            }
                            SaveDictionary();
                        }

                        else if (menu == 4)
                        {
                            Console.Clear();

                            Console.WriteLine("Введите слово ->");
                            string word = Console.ReadLine();
                            if (translates[id].words.Exists(s => s.lan1 == word))
                            {
                                Word w = translates[id].words.Find(s => s.lan1 == word);
                                w.ShowTranslates();
                                
                            }
                            else
                            {
                                Console.WriteLine("Перевод не найден!");
                            }
                            Console.ReadKey();
                        }
                        SaveDictionary();
                    }
                    SaveDictionary();
                }
                else if(menu == 4)
                {
                    ShowDictionaries();
                    int id = -1;
                    do
                    {
                        Console.WriteLine("Введите ид словаря -> ");
                        id = Convert.ToInt32(Console.ReadLine());
                        if (id < 0 && id > translates.Count - 1)
                            Console.WriteLine("Неправильное ид!");
                        else
                            break;
                    } while (id < 0 && id > translates.Count - 1);

                    Console.Clear();
                    translates[id].ShowWords();
                    int id_word = -1;
                    do
                    {
                        Console.WriteLine("Введите ид слова -> ");
                        id_word = Convert.ToInt32(Console.ReadLine());
                        if (id_word < 0 && id > translates[id_word].words.Count - 1)
                            Console.WriteLine("Неправильное ид!");
                        else
                            break;
                    } while (id < 0 && id > translates[id_word].words.Count - 1);

                    Console.WriteLine("Введите путь -> ");
                    string ph = Console.ReadLine();
                    string fisrt = $"Word: {translates[id_word].words[id_word].lan1}";
                    string second = "Translates: ";
                    foreach(string tr in translates[id_word].words[id_word].lan2)
                    {
                        second += tr + " ";
                    }
                    File.WriteAllText(ph+ $"\\{translates[id_word].words[id_word].lan1}.txt", fisrt+"\n"+second);
                    SaveDictionary();
                }
                SaveDictionary();
            }
        }
    }
}
