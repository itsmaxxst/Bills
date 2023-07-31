using Bills.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bills.Models;
using System.Windows.Controls;

namespace Bills.ViewModels;
    public class CommunalResourceViewModel : NotifyPropertyChangedBase
    {
        public CommunalResource Model { get; set; }
        public CommunalResourceViewModel(CommunalResource model)
        {
            Model = model;
        }
        public int Id
        {
            get {return Model.Id;} 
            set {Model.Id = value; OnPropertyChanged(nameof(Id)); }
        }
        public string Title
        {
            get { return Model.Title; }
            set { Model.Title = value; OnPropertyChanged(nameof(Title)); }
        }
        public override int GetHashCode()
        {
            return Model.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CommunalResourceViewModel)) return false;
            return (obj as CommunalResourceViewModel).Model.Id == Model.Id;
        }
}
