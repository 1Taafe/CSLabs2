using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab67
{
    class ApplicationsViewModel
    {
        private RelayCommand openAddingWindow;
        public RelayCommand OpenAddingWindow
        {
            get
            {
                return openAddingWindow ?? (openAddingWindow = new RelayCommand(obj =>
                {
                    AddWindow addWindow = new AddWindow();
                    if (AddWindow.isOpened == false)
                    {
                        addWindow.Show();
                        AddWindow.isOpened = true;
                    }
                }));

            }
        }

        private RelayCommand changeLang;
        public RelayCommand ChangeLang
        {
            get
            {
                return changeLang ?? (changeLang = new RelayCommand(obj =>
                {
                    if(MainWindow.mainWindow.WindowLanguage == "Russian")
                    {
                        MainWindow.mainWindow.SwitchLanguageEng();
                        MainWindow.mainWindow.WindowLanguage = "English";
                    }
                    else
                    {
                        MainWindow.mainWindow.SwitchLanguageRussian();
                        MainWindow.mainWindow.WindowLanguage = "Russian";
                    }
                }));

            }
        }
    }
}
