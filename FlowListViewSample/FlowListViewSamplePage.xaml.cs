using System.Collections.ObjectModel;
using Xamarin.Forms;
using DLToolkit.Forms.Controls;
using FlowListViewSample.Model;

namespace FlowListViewSample
{
    public partial class FlowListViewSamplePage : ContentPage
    {
        ObservableCollection<ItemModel> Items = new ObservableCollection<ItemModel>();

        private double width = 0;
        private double height = 0;

        public FlowListViewSamplePage()
        {
            InitializeComponent();
            FlowListView.Init();

            FlowList.FlowItemsSource = Items;

            for (var i = 1; i <= 30; i++)
            {
                var itemModel = new ItemModel()
                {
                    Title = "Test-" + i.ToString()
                };

                Items.Add(itemModel);
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    // Landscape : 2 items per row
                    FlowList.FlowColumnCount = 2;

                }
                else
                {
                    // Portrait : 1 item per row
                    FlowList.FlowColumnCount = 1;
                }
            }
        }
    }
}
