using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mundo.Business.Entity;

namespace Mundo.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable(nameof(Pessoa));

            builder.Property(p => p.Id)
                .IsRequired();

            builder.Property(p => p.Nome)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .IsRequired();

            builder.Property(p => p.Altura);

            builder.HasMany(p => p.Pets)
                .WithOne(p => p.Pessoa)
                .HasForeignKey(p => p.PessoaId);
        }
    }
}
