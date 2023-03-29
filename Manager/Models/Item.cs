using Manager.Enums;

namespace Application.Models
{
    public class Item
    {
        public string ItemCode { get; set; }

        public string Description { get; set; }

        public bool Active { get; set; }

        public string? CustomerDescription { get; set; }

        public bool SalesItem { get; set; }

        public bool StockItem { get; set; }

        public bool PurchasedItem { get; set; }

        public string Barcode { get; set; }

        public EManageItem ManageItemBy { get; set; }

        public decimal MinimumInventory { get; set; }

        public decimal MaximumInventory { get; set; }

        public string? Remarks { get; set; }

        public string ImagePath { get; set; }
    }
}
