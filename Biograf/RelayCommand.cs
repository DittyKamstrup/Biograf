using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biograf
{
    public class RelayCommand : ICommand
    {
        //private Action methodToExecute = null;
        //private Func<bool> methodToDetectCanExecute = null;

        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute): this(execute, null)
        {
            this._execute = execute;
        }


        public RelayCommand(Action _execute, Func<bool> _canExecute)
        {
            this._execute = _execute;
            this._canExecute = _canExecute;
        }

        public void Execute(object parameter)
        {
            this._execute();
        }
        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }
            else
            {
                return this._canExecute();
            }
        }

        private Action addNewFilm;

        //public RelayCommand(Action addNewFilm)
        //{
        //    this.addNewFilm = addNewFilm;
        //}

        public event EventHandler CanExecuteChanged;

    }
}
