using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mundo.Business.Entities;

namespace Mundo.Data.Mappings
{
    public class PetMapping : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable(nameof(Pet));

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.PessoaId)
                .IsRequired();

            builder.Property(p => p.Nome)
                .IsRequired();

            builder.Property(p => p.Tipo)
                .IsRequired();

            builder.Property(p => p.DataNascimento);

            builder.HasOne(p => p.Pessoa)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.PessoaId);
        }
    }
}
