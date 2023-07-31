using Bills.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bills.Models;

namespace Bills.ViewModels
{
    public class TariffViewModel : NotifyPropertyChangedBase
    {
        public Tariff Model { get; set; }
        public TariffViewModel(Tariff model)
        {
            Model = model;
            _communalResource = new CommunalResourceViewModel(model.Resource);
        }
        public int Id
        {
            get {return Model.Id;} 
            set {Model.Id = value; OnPropertyChanged(nameof(Id)); }
        }
        public decimal Price
        {
            get { return Model.Price; }
            set { Model.Price = value; OnPropertyChanged(nameof(Price)); }
        }
        private CommunalResourceViewModel _communalResource;
        public CommunalResourceViewModel CommunalResource
        {
            get => _communalResource;
            set
            {
                _communalResource = value;
                Model.Resource = value.Model;
                OnPropertyChanged();
            }
        }
        public override int GetHashCode()
        {
            return Model.Id.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is TariffViewModel)) return false;
            return (obj as TariffViewModel).Model.Id == Model.Id;
        }
    }
}
