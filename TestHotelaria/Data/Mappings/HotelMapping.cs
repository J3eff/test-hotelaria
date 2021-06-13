using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHotelaria.Models;

namespace TestHotelaria.Data.Mappings
{
    public class HotelMapping : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(h => h.ResumoHotel)
                .IsRequired()
                .HasColumnType("varchar(1000)");

            builder.Property(h => h.Endereco)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(h => h.Comodidade)
                .IsRequired()
                .HasColumnType("varchar(300)");


            builder.ToTable("Hoteis");
        }
    }
}
