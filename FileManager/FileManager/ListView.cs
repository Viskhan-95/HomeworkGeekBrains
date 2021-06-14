using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    class ListView
    {
        ListView lv;
        private IList items;
        private int selectedIndex;

        public object SelectedItem { get { return items[SelectedIndex]; } }

        public void Arrow()
        {
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        lv.SelectedIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        lv.SelectedIndex++;
                        break;
                    default:
                        break;
                }
            } while (cki.Key != ConsoleKey.Enter);
            Console.Clear();
        }

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                value = Math.Abs(value % items.Count);
                selectedIndex = value;
                Draw();
            }
        }

        public ListView(IList items)
        {
            this.items = items;
            SelectedIndex = 0;
            Draw();
        }

        private void Draw()
        {
            Console.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == selectedIndex)
                {
                    var tmp = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = tmp;
                    Console.WriteLine(items[i]);
                    Console.ForegroundColor = Console.BackgroundColor;
                    Console.BackgroundColor = tmp;
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
            }
        }
    }
}
