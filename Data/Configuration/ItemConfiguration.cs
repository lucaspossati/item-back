using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Application.Models;

namespace Data.Configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.ItemCode);

            builder.Property(x => x.ItemCode).HasColumnName("item_code").
                HasMaxLength(25).IsRequired();

            builder.Property(x => x.Description).HasColumnName("description").
                HasMaxLength(300).IsRequired();

            builder.Property(x => x.Active).HasColumnName("active").IsRequired();

            builder.Property(x => x.CustomerDescription).HasColumnName("customer_description").
                HasMaxLength(300);

            builder.Property(x => x.SalesItem).HasColumnName("sales_item").IsRequired();

            builder.Property(x => x.StockItem).HasColumnName("stock_item").IsRequired();

            builder.Property(x => x.PurchasedItem).HasColumnName("purchased_item").IsRequired();

            builder.Property(x => x.Barcode).HasColumnName("barcode").
                HasMaxLength(100).IsRequired();

            builder.Property(x => x.ManageItemBy).HasColumnName("manage_item_by").IsRequired(); 

            builder.Property(x => x.MinimumInventory).HasColumnName("minimum_inventory").IsRequired(); 

            builder.Property(x => x.MaximumInventory).HasColumnName("maximum_inventory").IsRequired();
            
            builder.Property(x => x.Remarks).HasColumnName("remarks").HasMaxLength(int.MaxValue); 

            builder.Property(x => x.ImagePath).HasColumnName("image_path")
                .HasMaxLength(int.MaxValue).IsRequired();
        }
    }
}
