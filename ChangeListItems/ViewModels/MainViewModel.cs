using ChangeListItems.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ChangeListItems.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Equipment> _myEquipmentList;
        public ObservableCollection<Equipment> MyEquipmentList
        {
            get => _myEquipmentList;
            set 
            {
                _myEquipmentList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyEquipmentList)));
            }
        }
        public Command ChangeEquipments { get; set; }

        public MainViewModel() 
        {
            MyEquipmentList = new ObservableCollection<Equipment>();
            ChangeEquipments = new Command(() => ChangeListItems());
        }

        int currentCount = 1;
        private List<int> GetNumbers()
        {
            List<int> numbers = new List<int>();
            int newCount = currentCount + 5;
            for (int i = currentCount; i < newCount; i++)
            {
                numbers.Add(i);
            }
            currentCount = newCount;
            return numbers;
        }

        private void ChangeListItems() 
        {
            var equipments = GetNumbers().Select(num => new Equipment() { Title = $"List Item No: {num.ToString()}" } );
            MyEquipmentList = new ObservableCollection<Equipment>(equipments);
        }
    }
}
